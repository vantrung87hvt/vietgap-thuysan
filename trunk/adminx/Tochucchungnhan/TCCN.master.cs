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

public partial class adminx_Tochucchungnhan_TCCN : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["GroupID"] == null)
        {
            Response.Write("<script>alert('Bạn không có quyền vào trang này');location='../../Default.aspx'</script>");
            Response.End();
        }
        if (!Page.IsPostBack)
            napLogo();
    }
    private void napLogo()
    {
        int iUserID = 0;
        int iTochucchungnhanID;
        if(Session["userID"]!=null)
            iUserID = Convert.ToInt32(Session["userID"].ToString());
        List<TochucchungnhanTaikhoanEntity> lstTochucchungnhan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(iUserID);

        if (lstTochucchungnhan.Count > 0)
        {
            iTochucchungnhanID = lstTochucchungnhan[0].FK_iTochucchungnhanID;
            Session["iTochucchungnhanID"]=iTochucchungnhanID;
            imgLogo.ImageUrl = "../ViewImage.aspx?ID=" + iTochucchungnhanID;
        }
        else
        {
            return;
        }
    }
}
