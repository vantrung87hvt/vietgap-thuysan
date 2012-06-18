using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.Business;
using System.Data;
public partial class adminx_ucXulyvipham : System.Web.UI.UserControl
{
    /// <summary>
    /// Xử lý các cơ sở nuôi trồng, các tổ chức chứng nhận
    /// 1. Lựa chọn hình thức xử lý
    /// 2. Lý do xử lý
    /// 3. Thiết lập giá trị cho trạng thái: iMucdo
    /// -1: cảnh cáo, 2: đình chỉ, 3: thu hồi
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["cosonuoitrongID"] != null)
        {
            int iCosonuoitrongID = Convert.ToInt32(Request.QueryString["cosonuoitrongID"].ToString());
            if (iCosonuoitrongID > 0)
                napDulieu(iCosonuoitrongID);
        }
    }
    private void napDulieu(int iCosonuoitrongID)
    {
        CosonuoitrongEntity oCosonuoitrong = CosonuoitrongBRL.GetOne(iCosonuoitrongID);
        if (oCosonuoitrong != null)
        {
            lblTencosonuoi.Text = oCosonuoitrong.sTencoso;
            lblDiachi.Text = oCosonuoitrong.sAp + ", " + oCosonuoitrong.sXa + ", " + QuanHuyenBRL.GetOne(oCosonuoitrong.FK_iQuanHuyenID).sTen + ", "+TinhBRL.GetOne(QuanHuyenBRL.GetOne(oCosonuoitrong.FK_iQuanHuyenID).FK_iTinhThanhID).sTentinh;
            lblSodienthoai.Text = oCosonuoitrong.sDienthoai;
            btnXuly.CommandArgument = iCosonuoitrongID.ToString();
            ddlHinhthucxuly.SelectedIndex = 0;
            List<PhatEntity> lstPhat = PhatBRL.GetByFK_iCosonuoiID(oCosonuoitrong.PK_iCosonuoitrongID);
            if (lstPhat != null && lstPhat.Count > 0)
            {
                PhatEntity.Sort(lstPhat, "dNgaythuchien", "DESC");
                lblTinhtrang.Text = getTinhtrang(lstPhat[0].iMucdo);
            }
            else
                lblTinhtrang.Text = "Hoạt động đúng phép.";
        }
    }
    protected void btnXuly_Click(object sender, EventArgs e)
    {
        PhatEntity oPhat = new PhatEntity();
        oPhat.FK_iCosonuoiID = Convert.ToInt32(btnXuly.CommandArgument);
        oPhat.iMucdo = Convert.ToInt16(ddlHinhthucxuly.SelectedValue);
        oPhat.sLydo = txtLydo.Text;
        oPhat.dNgaythuchien = DateTime.Today;
        PhatBRL.Add(oPhat);
        Response.Write("<script language=\"javascript\">alert('Xử lý thành công!');location='Default.aspx?page=Cosonuoitrong';</script>");
    }
    private String getTinhtrang(short iTinhtrang)
    {
        String sTinhtrang = String.Empty;
        switch (iTinhtrang)
        {
            case 0:
                sTinhtrang = "Khôi phục";break;
            case 1:
                sTinhtrang = "Cảnh cáo";break;
            case 2:
                sTinhtrang = "Đình chỉ";break;
            case 3:
                sTinhtrang = "Thu hồi";break;
        }
        return sTinhtrang;
    }
    protected void ddlHinhthucxuly_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (ddlHinhthucxuly.SelectedIndex)
        {
            case 0:
                txtLydo.Text = "Đã hoàn tất các thủ tục, khắc phục các lỗi tuân thủ tiêu chuẩn Việt Gap";
                break;
            case 1:
                txtLydo.Text = "Mắc lỗi trong tuân thủ VietGAP";
                txtLydo.Enabled = false;
                break;
            case 2:
                txtLydo.Text = "Không khắc phục các lỗi trong tuân thủ VietGAP";
                txtLydo.Enabled = false;
                break;
            case 3:
                txtLydo.Text = "a. Kết quả kiểm tra giám sát cho thấy bằng chứng không đáp ứng yêu cầu theo VietGAP hoặc sản phẩm nuôi không đảm bảo an toàn thực phẩm\n";
                txtLydo.Text +="b. Từ chối kiểm tra khi được yêu cầu hoặc xin hoãn kiểm tra 2 lần liên tiếp mà không có lý do chính đáng.\n";
                txtLydo.Text +="c. Vi phạm quy định về sử dụng mã số chứng nhận; sử dụng logo VietGAP không đúng theo quy định.\n";
                txtLydo.Text +="d. Vi phạm quy định về kiểm tra chứng nhận, xuất xứ sản phẩm nuôi.";
                break;
        }
    }
}