using INVI.Entity;
using INVI.Business;
using INVI.INVILibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using JockerSoft.Media;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Globalization;
using System.IO;
using System.Drawing;
public partial class adminx_ucVideoClipsManager : System.Web.UI.UserControl
{
    private static byte[] bVideoClip = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            napGridView();
        }
    }
    private void napGridView()
    {
        grvVideoClips.DataSource = VideoClipBRL.GetAll();
        grvVideoClips.DataKeyNames = new string[] { "PK_iVideoID" };
        grvVideoClips.DataBind();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        byte[] bytVideo = null;
        VideoClipEntity entity = new VideoClipEntity();
        try
        {
            entity.FK_iCategoryID = 0;

            // xu ly anh
            if (fluVideoClips.PostedFile != null)
            {
                if (fluVideoClips.PostedFile.ContentLength > 0)
                {
                    string strEx = "flv|mp4";
                    string fileEx = fluVideoClips.FileName.Substring(fluVideoClips.FileName.LastIndexOf('.')).Remove(0, 1);
                    string[] arrEx = strEx.Split('|');
                    bool valid = false;
                    foreach (string ex in arrEx)
                    {
                        if (ex.Equals(fileEx, StringComparison.OrdinalIgnoreCase))
                            valid = true;
                    }
                    if (valid)
                    {
                        string Path = GetUplaodImagePhysicalPath();
                        DirectoryInfo dirUploadImage = new DirectoryInfo(Path);
                        string fileUrl = Path + fluVideoClips.PostedFile.FileName;
                        HttpPostedFile objHttpPostedFile = fluVideoClips.PostedFile;
                        int intContentlength = objHttpPostedFile.ContentLength;
                        bytVideo = new Byte[intContentlength];
                        bVideoClip = bytVideo;
                        fluVideoClips.PostedFile.SaveAs(fileUrl);
                        entity.iDungluong = bytVideo.Length;
                        entity.sMota = txtMota.Text;
                        entity.sTieude = txtTieude.Text;
                        entity.sTentep = fluVideoClips.PostedFile.FileName.Trim();
                        entity.FK_iCategoryID = 9;
                        //entity.sAnhMinhHoa = createThumbnailImage(fluVideoClips.PostedFile.FileName);
                        entity.sAnhMinhHoa = " ";
                        entity.dNgaytai = DateTime.Today;
                    }
                }
                else if (btnOK.CommandName == "Add")
                {
                    lblLoi.Text = "Bạn chưa chọn tệp video";
                    return;
                }
                else if (bVideoClip != null)
                {
                    bVideoClip = null;
                }
                else
                {
                    // Nếu là sửa chữa thì check xem nếu đã có logo trong CSDL thì thôi không thông báo
                    if (!Convert.ToBoolean(Session["hasVideo"].ToString()) == true)
                        lblLoi.Text = "Bạn chưa chọn tệp video";
                    return;
                }
            }
            // Xử lý nút bấm
            if (btnOK.CommandName == "Edit")
            {
                entity.PK_iVideoID = Convert.ToInt32(btnOK.CommandArgument);
                entity.iSolanxem = entity.iSolanxem + 1;
                VideoClipBRL.Edit(entity);
                Response.Write("<script language=\"javascript\">alert('Cập nhập thành công!');location='Default.aspx?page=VideoClipsManager';</script>");
            }
            else
            {
                entity.iSolanxem = 0;
                VideoClipBRL.Add(entity);
                lblLoi.Text = "Bổ sung thành công";
                Response.Write("<script language=\"javascript\">alert('Bổ sung thành công!');location='Default.aspx?page=VideoClipsManager';</script>");

            }
            //Nạp lại dữ liệu
        }
        catch (Exception ex)
        {
            Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=VideoClipsManager';</script>");
        }
    }
    private String createThumbnailImage(String sFilename)
    {
        string _imagepath = ResolveUrl("~/upload/videos/") + sFilename.Split('.')[0] + ".jpg";
        String sVideoUploadPath = ResolveUrl("~/upload/videos/");
        sVideoUploadPath += sFilename;
        Bitmap bmp = FrameGrabber.GetFrameFromVideo(sVideoUploadPath, 0.2d);
        bmp.Save(_imagepath, System.Drawing.Imaging.ImageFormat.Gif);
        // Save directly frame on specified location
        FrameGrabber.SaveFrameFromVideo(sVideoUploadPath, 0.2d, _imagepath);
        return _imagepath;
    }
    string GetUplaodImagePhysicalPath()
    {
        return System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "upload\\videos\\";
    }
    public byte[] FileToByteArray(string _FileName)
    {
        byte[] _Buffer = null;
       try
        {
            // Open file for reading
            System.IO.FileStream _FileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            // attach filestream to binary reader
            System.IO.BinaryReader _BinaryReader = new System.IO.BinaryReader(_FileStream);

            // get total byte length of the file
            long _TotalBytes = new System.IO.FileInfo(_FileName).Length;

            // read entire file into buffer
            _Buffer = _BinaryReader.ReadBytes((Int32)_TotalBytes);

            // close file reader
            _FileStream.Close();
            _FileStream.Dispose();
            _BinaryReader.Close();
        }
        catch (Exception _Exception)
        {
            // Error
            Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
        }

        return _Buffer;
    }

    private void napForm(int PK_iVideoClipID)
    {
        try
        {
            VideoClipEntity oVideoClip = VideoClipBRL.GetOne(PK_iVideoClipID);
            if(oVideoClip!=null)
            {
                txtTieude.Text = oVideoClip.sTieude;
                txtMota.Text = oVideoClip.sMota;
                

                bVideoClip = FileToByteArray(oVideoClip.sTentep);
                if (bVideoClip != null && bVideoClip.Length > 0)
                    Session["hasVideo"] = true;
                btnOK.CommandName = "Edit";
                showVideo(oVideoClip.sTentep);
                //List<VideoClipEntity> lstClips = new List<VideoClipEntity>();
                //lstClips.Add(oVideoClip);
                //rptVideoClips.DataSource = lstClips;
                //rptVideoClips.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=VideoClipsManager';</script>");
        }
    }
    private void showVideo(String sVideoPath)
    {
        //LinkButton lbtnXemvideo = (LinkButton)e.CommandSource;
        String swfUrl = ResolveUrl("~/Plugin/flowplayer/flowplayer-3.2.11.swf");
        String sVideoUploadPath = ResolveUrl("~/upload/videos/");
        String sVideoContent = String.Format(@"
                <a
			         href='{0}'
			         style='display:block;width:520px;height:330px'
			         id='player'> 
		        </a>
		        <script>
		            var  player = $f('player_content', {1}, {
                },
            clip:   {
                        autoPlay: false,
                        autoBuffering: true,
                        provider: 'pseudo'
                        }
                    }
                }
            }
		        </script>
            ", sVideoUploadPath + sVideoPath, swfUrl);
        divVideo.InnerHtml = sVideoContent;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    protected void lbtnAddnew_Click(object sender, EventArgs e)
    {
        pnlEdit.Visible = true;
        btnOK.CommandName = "Add";
    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in grvVideoClips.Rows)
            {
                CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                short PK_iVideoID = Convert.ToInt16(grvVideoClips.DataKeys[row.RowIndex].Values["PK_iVideoID"]);
                if (chkDelete != null && chkDelete.Checked)
                {
                    VideoClipBRL.Remove(PK_iVideoID);
                }
            }
            //Nap lai du lieu
            Response.Redirect(Request.Url.ToString());
        }
        catch (Exception ex)
        {
            Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=VideoClipsManager';</script>");
        }
    }
    protected void grvVideoClips_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        short PK_iVideoID = Convert.ToInt16(grvVideoClips.DataKeys[e.NewSelectedIndex].Values["PK_iVideoID"]);
        btnOK.CommandName = "EDIT";
        btnOK.Text = "Sửa";
        pnlEdit.Visible = true;
        btnOK.CommandArgument = PK_iVideoID.ToString();
        napForm(PK_iVideoID);
    }
    protected void grvVideoClips_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<VideoClipEntity> list = VideoClipBRL.GetAll();
        grvVideoClips.DataSource = VideoClipEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
        grvVideoClips.DataBind();
    }
    protected void grvVideoClips_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "Xem")
        {
            LinkButton lbtnXemvideo = (LinkButton)e.CommandSource;
            String swfUrl = ResolveUrl("~/Plugin/flowplayer/flowplayer-3.2.11.swf");
            String sVideoUploadPath = ResolveUrl("~/upload/videos/");
            String sVideoContent = String.Format(@"
                <a  
			         href='{0}'
			         style='display:block;width:520px;height:330px'
			         id='player'> 
		        </a>
		        <script>
		            flowplayer('player', '{1}');
		        </script>
            ", sVideoUploadPath + lbtnXemvideo.CommandArgument, swfUrl);
            divVideo.InnerHtml = sVideoContent;
        }
    }
}