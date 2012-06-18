using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.Business;
using INVI.INVILibrary;
public partial class uc_ucAbout : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            loadContent();
        }
    }
    private void loadContent()
    {
        try
        {
            lblContent.Text = ConfigBRL.GetOne(4).sValue;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}