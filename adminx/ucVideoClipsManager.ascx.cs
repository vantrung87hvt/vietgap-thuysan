using INVI.Entity;
using INVI.Business;
using INVI.INVILibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Globalization;
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
                    string strEx = "wmv|mpg|avi|mpeg|mp4";
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

                        HttpPostedFile objHttpPostedFile = fluVideoClips.PostedFile;
                        int intContentlength = objHttpPostedFile.ContentLength;
                        bytVideo = new Byte[intContentlength];
                        objHttpPostedFile.InputStream.Read(bytVideo, 0, intContentlength);
                        entity.bVideoClip = bytVideo;
                        entity.iDungluong = bytVideo.Length;
                        entity.sMota = txtMota.Text;
                        entity.sTieude = txtTieude.Text;
                        entity.sTentep = fileEx;
                        entity.FK_iCategoryID = 9;
                    }
                }
                else if (btnOK.CommandName == "Add")
                {
                    lblLoi.Text = "Bạn chưa chọn tệp video";
                    return;
                }
                else if (bVideoClip != null)
                {
                    entity.bVideoClip = bVideoClip;
                    bVideoClip = null;
                }
                else
                {
                    // Nếu là sửa chữa thì check xem nếu đã có logo trong CSDL thì thôi không thông báo
                    if (!Convert.ToBoolean(Session["hasLogo"].ToString()) == true)
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
                List<VideoClipEntity> lstClips = new List<VideoClipEntity>();
                lstClips.Add(entity);
                rptVideoClips.DataSource = lstClips;
                rptVideoClips.DataBind();
            }
            else
            {
                entity.iSolanxem = 0;
                VideoClipBRL.Add(entity);
                lblLoi.Text = "Bổ sung thành công";
                List<VideoClipEntity> lstClips = new List<VideoClipEntity>();
                lstClips.Add(entity);
                rptVideoClips.DataSource = lstClips;
                rptVideoClips.DataBind();
                Response.Write("<script language=\"javascript\">alert('Bổ sung thành công!');location='Default.aspx?page=VideoClipsManager';</script>");

            }
            //Nạp lại dữ liệu
        }
        catch (Exception ex)
        {
            Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=VideoClipsManager';</script>");
        }
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
                bVideoClip = oVideoClip.bVideoClip;
                List<VideoClipEntity> lstClips = new List<VideoClipEntity>();
                lstClips.Add(oVideoClip);
                rptVideoClips.DataSource = lstClips;
                rptVideoClips.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=VideoClipsManager';</script>");
        }
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
}