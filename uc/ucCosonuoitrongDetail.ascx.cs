using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.Business;
using INVI.INVILibrary;
using System.Configuration;
public partial class uc_ucCosonuoitrongDetail : System.Web.UI.UserControl
{
    private int iCosonuoitrongID = 0;        
    protected void Page_Load(object sender, EventArgs e)
    {   
        if (Session["iCosonuoitrongID"] != null)
        {
            iCosonuoitrongID = Convert.ToInt32(Session["iCosonuoitrongID"].ToString());
            napForm(iCosonuoitrongID);
        }
    }
    protected void napForm(int iCosonuoitrongID)
    {
        CosonuoitrongEntity oCosonuoitrong;
        try
        {
            oCosonuoitrong = CosonuoitrongBRL.GetOne(iCosonuoitrongID);
            if (oCosonuoitrong != null)
            {
                lblAp.Text = oCosonuoitrong.sAp;
                lblDientichAolang.Text = oCosonuoitrong.fDientichAolang.ToString();
                lblChukynuoi.Text = oCosonuoitrong.iChukynuoi.ToString();
                lblDienthoai.Text = oCosonuoitrong.sDienthoai;
                lblChucoso.Text = oCosonuoitrong.sTenchucoso;
                lblTencoso.Text = oCosonuoitrong.sTencoso;
                lblTongDienTichCoSoNuoi.Text = oCosonuoitrong.fTongdientich.ToString();
                lblTongdientichmatnuoc.Text = oCosonuoitrong.fTongdientichmatnuoc.ToString();
                lblXa.Text = oCosonuoitrong.sXa;
                lblDoituongnuoi.Text = DoituongnuoiBRL.GetOne(oCosonuoitrong.FK_iDoituongnuoiID).sTendoituong;
                lblQuanHuyen.Text = QuanHuyenBRL.GetOne(oCosonuoitrong.FK_iQuanHuyenID).sTen;
                lblNamsanxuat.Text = oCosonuoitrong.iNamsanxuat.ToString();
                lblTinh.Text = TinhBRL.GetOne(QuanHuyenBRL.GetOne(oCosonuoitrong.FK_iQuanHuyenID).FK_iTinhThanhID).sTentinh;
                ToadoEntity oToado = ToadoBRL.GetOne(oCosonuoitrong.FK_iToadoID);
                lblKinhdo.Text = oToado.Longitude;
                lblVido.Text = oToado.Latitude;
                lblSanluongdukien.Text = oCosonuoitrong.iSanluongdukien.ToString();
                chkKiemduyet.Checked = oCosonuoitrong.bDuyet;
                chkKiemduyet.Visible = true;
                if (oCosonuoitrong.sSodoaonuoi.Trim() != String.Empty)
                {
                    img.ImageUrl = "" + ConfigurationManager.AppSettings["UploadPath"] + oCosonuoitrong.sSodoaonuoi;
                    img.Visible = true;
                }
                else
                    img.Visible = false;
                pnCSNT.Visible = true;
               
            }
        }
        catch { }
        finally
        {

        }
    }
    protected void btnDKThongtinCoSoNuoi_Click(object sender, EventArgs e)
    {
        
        iCosonuoitrongID = Convert.ToInt32(Session["iCosonuoitrongID"].ToString());
        CosonuoitrongEntity oCosonuoitrong = CosonuoitrongBRL.GetOne(iCosonuoitrongID);
        oCosonuoitrong.bDuyet = chkKiemduyet.Checked;
        CosonuoitrongBRL.Edit(oCosonuoitrong);

    }
}