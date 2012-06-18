using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using INVI.INVILibrary;
using INVI.Business;
using INVI.Entity;
using System.Collections.Generic;

public partial class uc_ucLogin : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
        string id = txtID.Value;
        List<MasovietgapEntity> lst = MasovietgapBRL.GetAll();
        List<MasovietgapEntity> lst2 = new List<MasovietgapEntity>();
        lst.ForEach(
            delegate(MasovietgapEntity oMSVG)
            {
                if (oMSVG.sMaso.Contains(id)) 
                {
                    lst2.Add(oMSVG);
                }
            }
        );
        rptRE.DataSource = lst2;
        rptRE.DataBind();
        if (lst2.Count > 0)
        {
            lblLoi.Visible = false;
            pnKetQua.Visible = true;
        }
        else
        {
            lblLoi.Visible = true;
            pnKetQua.Visible = false;
        }

    }
    protected void rptRE_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            {

                Literal lblPK_iMaSoVietGapID = e.Item.FindControl("lblPK_iMaSoVietGapID") as Literal;
                MasovietgapEntity msvg = MasovietgapBRL.GetOne(Convert.ToInt32(lblPK_iMaSoVietGapID.Text));
                if (msvg != null)
                {
                    CosonuoitrongEntity csnt = CosonuoitrongBRL.GetOne(Convert.ToInt32(msvg.FK_iCosonuoitrongID));
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
                    QuanHuyenEntity quan = QuanHuyenBRL.GetOne(Convert.ToInt32(msvg.FK_iCosonuoitrongID));
                    lblDiaChi.Text += quan.sTen + ", ";
                    lblDiaChi.Text += TinhBRL.GetOne(Convert.ToInt16(quan.FK_iTinhThanhID)).sTentinh;
                    Literal lblDienThoai = e.Item.FindControl("lblDienThoai") as Literal;
                    lblDienThoai.Text = csnt.sDienthoai;
                    Literal lblTongDienTich = e.Item.FindControl("lblTongDienTich") as Literal;
                    lblTongDienTich.Text = csnt.fTongdientich.ToString() + " (m2)";
                    Literal lblTongDienTichMatNuoc = e.Item.FindControl("lblTongDienTichMatNuoc") as Literal;
                    lblTongDienTichMatNuoc.Text = csnt.fTongdientichmatnuoc.ToString() + " (m2)";
                    Literal lblDoiTuongNuoi = e.Item.FindControl("lblDoiTuongNuoi") as Literal;
                    DoituongnuoiEntity dt = DoituongnuoiBRL.GetOne(Convert.ToInt32(msvg.FK_iCosonuoitrongID));
                    if (dt != null)
                        lblDoiTuongNuoi.Text = dt.sTendoituong;
                    Literal lblNamSanXuat = e.Item.FindControl("lblNamSanXuat") as Literal;
                    lblNamSanXuat.Text = csnt.iNamsanxuat.ToString();
                    Literal lblChuKyNuoi = e.Item.FindControl("lblChuKyNuoi") as Literal;
                    lblChuKyNuoi.Text = csnt.iChukynuoi.ToString();
                    Literal lblNgayDangKy = e.Item.FindControl("lblNgayDangKy") as Literal;
                    lblNgayDangKy.Text = csnt.dNgaydangky.Date.ToShortDateString();

                    //Literal ltep = e.Item.FindControl("ltep") as Literal;
                    //ltep.Text = "</p>";
                }
            }

        }
    }
}
