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
using System.Text.RegularExpressions;
public partial class uc_ucTochucchungnhanChitiet : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["TCCNID"] != null)
        {
            int PK_iTochucchungnhanID = 0;
            try
            {
                PK_iTochucchungnhanID = int.Parse(Session["TCCNID"].ToString());
            }
            catch 
            {
                return;
            }
            try
            {
                TochucchungnhanEntity oTochucchungnhan = TochucchungnhanBRL.GetOne(PK_iTochucchungnhanID);

                if (oTochucchungnhan != null)
                {
                    lblMasoTochucchungnhan.Text = oTochucchungnhan.sMaso;
                    lblTochucchungnhan.Text = oTochucchungnhan.sTochucchungnhan;
                    lblDienthoai.Text = oTochucchungnhan.sSodienthoai;
                    lblDiachi.Text = QuanHuyenBRL.GetOne(oTochucchungnhan.FK_iQuanHuyenID).sTen+", "+TinhBRL.GetOne(QuanHuyenBRL.GetOne(oTochucchungnhan.FK_iQuanHuyenID).FK_iTinhThanhID).sTentinh;
                    lblEmail.Text = oTochucchungnhan.sEmail;
                    lblSodangkyKinhdoanh.Text = oTochucchungnhan.sSodangkykinhdoanh;
                    lblCoquancapDangkyKinhdoanh.Text = oTochucchungnhan.sCoquancap;
                    lblCoquanQuanlyCaptren.Text = CoquancaptrenBRL.GetOne(oTochucchungnhan.FK_iCoquancaptrenID).sTencoquan;
                    imgLogo.ImageUrl = "adminx/ViewImage.aspx?ID=" + PK_iTochucchungnhanID;
                    imgLogo.Visible = true;
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