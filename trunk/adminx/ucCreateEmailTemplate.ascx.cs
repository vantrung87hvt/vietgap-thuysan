using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using INVI.INVILibrary;
public partial class adminx_ucCreateEmailTemplate : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {

                FileStream file = new FileStream(Server.MapPath("upload/emailactive.html"), FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file);
                sw.Write(ftbNoidung.Text);
                sw.Close();
                file.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=CreateEmailTemplate';</script>");
            }
        }

    }
    private void LoadData()
    {
        ftbNoidung.Text = INVIHelper.ReadFile("upload/emailactive.html");
    }
    
    

}