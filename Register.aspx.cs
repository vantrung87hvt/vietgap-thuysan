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

public partial class testpage : MyUI
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegistry_Click(object sender, EventArgs e)
    {
        UserEntity oUser = new UserEntity();
        string password = INVI.INVILibrary.INVISecurity.MD5(txtPassword.Text);
        oUser.iGroupID = Convert.ToInt32(ddlDoituong.SelectedValue);
        oUser.sEmail = txtEmail.Text;
        oUser.sIP = Request.ServerVariables["REMOTE_ADDR"].Trim();
        oUser.sPassword = password;
        oUser.sUsername = txtUsername.Text;
        oUser.bActive = false;
        oUser.tLastVisit = DateTime.Now;
        try
        {
            if (UserBRL.getByUserName(txtUsername.Text) != null)
            {
                litThongtin.Text = "<b>Tài khoản này đã tồn tại</b>, xin nhập tài khoản khác.";
                return;
            }
            int FK_iUserID = UserBRL.Add(oUser);
            if (FK_iUserID>0)
                litThongtin.Text = "<b>Đăng ký thành công.</b>Các thông tin của bạn sẽ được gửi đến Quản trị để kiểm duyệt. Kết quả sẽ được gửi đến email mà bạn đã khai báo";
        }
        catch
        {

        }
        finally
        {

        }
    }
}