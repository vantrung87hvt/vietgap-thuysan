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
using INVI.Entity;
using INVI.Business;
using System.IO;
using Aspose.Words;
using System.Text.RegularExpressions;

public partial class uc_ChitietCosonuoitrong : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CosonuoitrongID"] != null)
        {
            int PK_iCosonuoitrongID = 0;
            try
            {
                PK_iCosonuoitrongID = int.Parse(Session["CosonuoitrongID"].ToString());
            }
            catch
            {
                return;
            }
            try
            {
                CosonuoitrongEntity oCoso = CosonuoitrongBRL.GetOne(PK_iCosonuoitrongID);

                if (oCoso != null)
                {
                    lblMaso.Text = oCoso.sMaso_vietgap;
                    lblTencoso.Text = oCoso.sTencoso;
                    lblTenchucoso.Text = oCoso.sTenchucoso;
                    lblSodienthoai.Text = oCoso.sDienthoai;
                    lblDiachi.Text = oCoso.sAp + ", " + oCoso.sXa + ", " + QuanHuyenBRL.GetOne(oCoso.FK_iQuanHuyenID).sTen;
                    lblChukynuoi.Text = oCoso.iChukynuoi.ToString() + " tháng";
                    lblDientichaonuoi.Text = oCoso.fTongdientichmatnuoc.ToString() + " m<sup>2</sub>";
                    lblHinhthucnuoi.Text = HinhthucnuoiBRL.GetOne(oCoso.FK_iHinhthucnuoiID).sTenhinhthuc;
                    lblSanluongdukien.Text = oCoso.iSanluongdukien.ToString();
                    lblTongdientich.Text = oCoso.fTongdientich.ToString() + " m<sup>2</sub>";
                    lblTieude.Text = "";

                    if (oCoso.sSodoaonuoi.Trim() != String.Empty)
                    {
                        imgSodo.ImageUrl = "" + ConfigurationManager.AppSettings["UploadPath"] + oCoso.sSodoaonuoi;
                        imgSodo.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("~/");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/");
                lblMessage.Text = ex.Message;
            }
            
        }
    }
}
