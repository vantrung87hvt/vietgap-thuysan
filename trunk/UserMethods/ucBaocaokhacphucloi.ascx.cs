using INVI.Entity;
using INVI.Business;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
public partial class adminx_ucBaocaokhacphucloi : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnBosung_Click(object sender, EventArgs e)
    {
        grvBaocaokhacphucloiChitiet.ShowFooter = true;

    }
    void taoBaocaokhacphucloi()
    {
        BaocaokhacphucloiEntity oBaocaokhacphucloi = new BaocaokhacphucloiEntity();
        oBaocaokhacphucloi.dNgaykiemtra = DateTime.Today;
        int iUserID = Convert.ToInt32(Session["userID"].ToString());
        oBaocaokhacphucloi.FK_iCosonuoiID = CosonuoitrongBRL.GetByFK_iUserID(iUserID)[0].PK_iCosonuoitrongID;
        oBaocaokhacphucloi.sDoankiemtra = "";
        oBaocaokhacphucloi.sTailieukiemtheo = "";

    }
    void napChitietbaocaokhacphucloi()
    {

        List<BaocaokhacphucloiChitietEntity> lstBaocaokhacphucol = BaocaokhacphucloiChitietBRL.GetAll();
        
        try
        {

            //grvBaocaokhacphucloiChitiet.DataSource = admin.LoadAll();

            grvBaocaokhacphucloiChitiet.DataBind();

        }

        catch (Exception ee)
        {

            //lblError.Text = ThrowError.LogAndThrowError(ee);

        }

        finally
        {

            //admin = null;

        }

    }
}