using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.INVILibrary;
using System.Data;
using System.Data.SqlClient;

public partial class GenPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGen_Click(object sender, EventArgs e)
    {
        txtGenPass.Text = INVISecurity.MD5(txtPass.Text);
    }
}