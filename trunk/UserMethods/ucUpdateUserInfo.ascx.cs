using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Business;
using INVI.Entity;
using INVI.INVILibrary;
public partial class UserMethods_ucUpdateUserInfo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"] != null)
            {
                LoadToText();
            }
        }
             
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        UserEntity oUser = LoadInfo();
        if (INVISecurity.MD5(txtOldPassword.Text) != oUser.sPassword)
        {
            lblLoi.Text = "Mật khẩu cũ không chính xác";
            return;
        }
        oUser.sEmail = txtEmail.Text;
        oUser.sPassword = INVISecurity.MD5(txtPassword.Text);
        UserBRL.Edit(oUser);
        lblLoi.Text = "Cập nhật thành công";
    }
    private UserEntity LoadInfo()
    {
        int userid = Convert.ToInt32(Session["UserID"]);
        UserEntity oUser = UserBRL.GetOne(userid);
        return oUser;
    }
    private void LoadToText()
    {
        UserEntity oUser = LoadInfo();
        txtEmail.Text = oUser.sEmail;  
    }
}
