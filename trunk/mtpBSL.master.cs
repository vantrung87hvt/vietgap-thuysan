using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.INVILibrary;
using System.Threading;
public partial class mtpBSL : System.Web.UI.MasterPage
{   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["GroupID"] != null)
        {
            int GroupID = Convert.ToInt32(Session["GroupID"].ToString());
            if (GroupID == 4 || GroupID == 1 || GroupID == 2)
                pnlTracuu.Visible = true;
            else
                pnlTracuu.Visible = false;
        }
    }
    protected void lnkTiengViet_Click(object sender, EventArgs e)
    {        
        Changelang("vi-VN");
    }
    protected void lnkEnglish_Click(object sender, EventArgs e)
    {
        Changelang("en-US");
    }
    private void Changelang(string nameCulture)
    {
        LanguageManager.CurrentCulture = (new System.Globalization.CultureInfo(nameCulture));
        Session["Lang"]= LanguageManager.CurrentCulture;
        //Response.Redirect("Default.aspx");   
        Response.Redirect(Request.Url.ToString());
    }
}
