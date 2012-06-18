using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Maps_Maps : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
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
        Session["Lang"] =LanguageManager.CurrentCulture;
        Response.Redirect("Maps.aspx");

    }
}
