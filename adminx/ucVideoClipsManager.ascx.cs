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
                    string strEx = "jpg|jpeg|bmp|png|gif";
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

                    }
                }
                else if (btnOK.CommandName == "Add")
                {
                    lblLoi.Text = "Bạn chưa chọn logo";
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
                        lblLoi.Text = "Bạn chưa chọn logo";
                    return;
                }
            }
            // Xử lý nút bấm
            if (btnOK.CommandName == "Edit")
            {
                entity.PK_iVideoID = Convert.ToInt32(btnOK.CommandArgument);
                
                VideoClipBRL.Edit(entity);
                // Lấy dữ liệu về Tài khoản theo TCCN
                List<TochucchungnhanTaikhoanEntity> lsTochucchungnhantaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTochucchungnhanID(entity.PK_iTochucchungnhanID);
                if (lsTochucchungnhantaikhoan.Count > 0) // 
                {
                    TochucchungnhanTaikhoanEntity oTochucchungnhanTaikhoan = lsTochucchungnhantaikhoan[0];
                    oTochucchungnhanTaikhoan.FK_iTaikhoanID = Convert.ToInt32(ddlTaikhoan.SelectedValue);
                    oTochucchungnhanTaikhoan.FK_iTochucchungnhanID = entity.PK_iTochucchungnhanID;
                    oTochucchungnhanTaikhoan.dNgaythuchien = DateTime.Today;
                    oTochucchungnhanTaikhoan.bActive = true;
                    TochucchungnhanTaikhoanBRL.Edit(oTochucchungnhanTaikhoan);
                }
            }
            else
            {
                int iTochucchungnhanID = TochucchungnhanBRL.Add(entity);
                lblLoi.Text = "Bổ sung thành công";
                TochucchungnhanTaikhoanEntity oTochucTaikhoan = new TochucchungnhanTaikhoanEntity();
                oTochucTaikhoan.bActive = cbDuyet.Checked;

                oTochucTaikhoan.dNgaythuchien = DateTime.Today;
                oTochucTaikhoan.FK_iTaikhoanID = Convert.ToInt32(ddlTaikhoan.SelectedValue);
                oTochucTaikhoan.FK_iTochucchungnhanID = iTochucchungnhanID;
                TochucchungnhanTaikhoanBRL.Add(oTochucTaikhoan);
                Response.Write("<script language=\"javascript\">alert('Bổ sung thành công!');location='Default.aspx?page=TochuccapphepQuanly';</script>");

            }
            //Nạp lại dữ liệu
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    protected void lbtnAddnew_Click(object sender, EventArgs e)
    {

    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {

    }
    protected void grvChungchi_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
    protected void grvChungchi_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
}