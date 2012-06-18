using INVI.Business;
using INVI.Entity;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class uc_ucSearchIDVietAp : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pnKQ.Visible=false;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {


        List<CosonuoitrongEntity> lst = CosonuoitrongBRL.GetAll();
        List<CosonuoitrongEntity> lst2 = new List<CosonuoitrongEntity>();
        lst.ForEach(
            delegate(CosonuoitrongEntity oCSNT)
            {
                if (oCSNT.sMaso_vietgap.Contains(txtMaSo.Text))
                {
                    lst2.Add(oCSNT);
                }
            }
        );
        rptRE.DataSource = lst2;
        rptRE.DataBind();  
        pnKQ.Visible=true;
    }

    protected void rptRE_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            {
                Literal lblPK_iCoSoID = e.Item.FindControl("lblPK_iCoSoID") as Literal;
                CosonuoitrongEntity csnt = CosonuoitrongBRL.GetOne(Convert.ToInt32(lblPK_iCoSoID.Text));
                Literal lblTenCoSo = e.Item.FindControl("lblTenCoSo") as Literal;
                lblTenCoSo.Text = csnt.sTencoso;
                Literal lblMaSoVietGap = e.Item.FindControl("lblMaSoVietGap") as Literal;
                lblMaSoVietGap.Text = csnt.sMaso_vietgap;
                Literal lblTenChuCoSo = e.Item.FindControl("lblTenChuCoSo") as Literal;
                lblTenChuCoSo.Text = csnt.sTenchucoso;
                Literal lblDiaChi = e.Item.FindControl("lblDiaChi") as Literal;
                if (!string.IsNullOrEmpty(csnt.sAp))
                {
                    lblDiaChi.Text = csnt.sAp + ", ";
                }
                if (!string.IsNullOrEmpty(csnt.sXa))
                {
                    lblDiaChi.Text += csnt.sXa + ", ";
                }
                QuanHuyenEntity quan = QuanHuyenBRL.GetOne(Convert.ToInt32(lblPK_iCoSoID.Text));
                lblDiaChi.Text += quan.sTen + ", ";
                lblDiaChi.Text += TinhBRL.GetOne(Convert.ToInt16(quan.FK_iTinhThanhID)).sTentinh;
                Literal lblDienThoai = e.Item.FindControl("lblDienThoai") as Literal;
                lblDienThoai.Text = csnt.sDienthoai;
                Literal lblTongDienTich = e.Item.FindControl("lblTongDienTich") as Literal;
                lblTongDienTich.Text = csnt.fTongdientich.ToString() + " (m2)";
                Literal lblTongDienTichMatNuoc = e.Item.FindControl("lblTongDienTichMatNuoc") as Literal;
                lblTongDienTichMatNuoc.Text = csnt.fTongdientichmatnuoc.ToString() + " (m2)";
                Literal lblDoiTuongNuoi = e.Item.FindControl("lblDoiTuongNuoi") as Literal;
                DoituongnuoiEntity dt = DoituongnuoiBRL.GetOne(Convert.ToInt32(lblPK_iCoSoID.Text));
                if (dt != null)
                    lblDoiTuongNuoi.Text = dt.sTendoituong;
                Literal lblNamSanXuat = e.Item.FindControl("lblNamSanXuat") as Literal;
                lblNamSanXuat.Text = csnt.iNamsanxuat.ToString();
                Literal lblChuKyNuoi = e.Item.FindControl("lblChuKyNuoi") as Literal;
                lblChuKyNuoi.Text = csnt.iChukynuoi.ToString();
                Literal lblNgayDangKy = e.Item.FindControl("lblNgayDangKy") as Literal;
                lblNgayDangKy.Text = csnt.dNgaydangky.Date.ToShortDateString();
            }

        }
    }
}
