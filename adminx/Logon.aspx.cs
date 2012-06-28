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
using INVI.INVILibrary;
using INVI.Business;
using INVI.Entity;

public partial class adminx_Logon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            Response.Write("<script>alert('Bạn đã đăng nhập');location='./Default.aspx';</script>");
            Response.End();
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        string password = INVISecurity.MD5(txtPassword.Text);
        UserEntity oUser=UserBRL.GetByUserPass(username, password);
        if (oUser == null)
        {
            Response.Write("<script>alert('Đăng nhập không thành công');location='./Logon.aspx';</script>");
        }
        else
        {
            Session["UserID"] = oUser.iUserID;
            Session["Username"] = oUser.sUsername;
            Session["GroupID"] = oUser.iGroupID;
            Response.Write("<script>alert('Đăng nhập thành công');location='./Default.aspx';</script>");
        }

        
    }

    
}
