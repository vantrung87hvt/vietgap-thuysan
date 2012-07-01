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
using System.Collections.Generic;

public partial class uc_ucLogin : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Đặt thuộc tính cho ô text đăng nhập để check enter
            login_user.Attributes.Add("onkeypress", "return Login(event,'" + btnLogin.ClientID + "')");
            login_pass_hint.Attributes.Add("onkeypress", "return Login(event,'" + btnLogin.ClientID + "')");
            //-------------//
            String user = "";
            try
            {
                user = Session["Username"].ToString();
            }
            catch (Exception ex) { }

            if (user != "")
            {
                pnlogin.Visible = false;
                pnsuccess.Visible = true;
                String strLink = "";
                if (Session["GroupID"].ToString() == "3")
                {
                    strLink = "UserMethods/Default.aspx";
                    //lbtWellcome.PostBackUrl = "~/UserMethods/Default.aspx";
                }
                else if (Session["GroupID"].ToString() == "4")
                {
                    strLink = "adminx/Tochucchungnhan/Default.aspx";
                }
                else if (Session["GroupID"].ToString() == "1" || Session["GroupID"].ToString() == "9")
                {
                    strLink = "adminx/Default.aspx";
                    //lbtWellcome.PostBackUrl = "~/adminx/Default.aspx";
                }
                String str = @"
                                <h3 style='margin-left:0px;'>Tài khoản</h3>
                                <ul class='succsess_login'>";
                int GroupID = Convert.ToInt32(Session["GroupID"].ToString());
                int userID = Convert.ToInt32(Session["UserID"].ToString());
                String sUser = String.Empty;
                switch (GroupID)
                {
                    case 1:
                        sUser = "<b>Quản trị (Lãnh đạo)</b>";
                        break;
                    case 4:
                        //List<TochucchungnhanTaikhoanEntity> lstTochucTaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(userID);
                        //if (lstTochucTaikhoan.Count > 0)
                        //    sUser = TochucchungnhanBRL.GetOne(lstTochucTaikhoan[0].FK_iTochucchungnhanID).sTochucchungnhan;
                        sUser = "<b>Quản trị (TCCN)</b>";
                        break;
                }
                if (Session["LangUsed"]!=null&&Session["LangUsed"].ToString() == "en-US")
                {
                    str += "<li style='background:url(CSS/Images/li_administrator.png) no-repeat top left;'><a href=" + strLink + " target='_blank'>" + sUser + "</a></li><li></li><li></li><li></li>";
                    str += "<li style='background:url(CSS/Images/li_logout-icon.png) no-repeat top left;'><a href='uc/Logout.aspx' target='_blank'>Đăng xuất</a></li>";
                }
                else
                {
                    str += "<li style='background:url(CSS/Images/li_administrator.png) no-repeat top left;'><a href=" + strLink + " target='_blank'>"+sUser+"</a></li>";
                    str += "<li style='background:url(CSS/Images/li_logout-icon.png) no-repeat top left;'><a href='uc/Logout.aspx' target='_parent'>Đăng xuất</a></li>";
                }
                str += "</ul>";
                lblAction.Text = str;
            }
        }
    }
    public void resetInput()
    {
        login_user.Attributes.CssStyle.Add("border", "border: 1px solid #E5E5E5;");
        login_pass_hint.Attributes.CssStyle.Add("border", "border: 1px solid #E5E5E5;");
        lblThongbao.Text = " ";
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //Kiểm tra số lần đăng nhập vượt quá số lần quy đinhj
        if (bIsOverTry())
        {
            lblThongbao.Text = "Nhập sai quá số lần quy định, vui lòng quay lại sau!";
            return;
        }
        resetInput();
        //Valid empty
        if (login_user.Value == "" || login_user.Value == "Tên đăng nhập")
        {
            login_user.Attributes.CssStyle.Add("border", "1px solid #F00 !important");
            return;
        }
        if (login_pass_hint.Value == "" || login_pass_hint.Value == "Mật khẩu")
        {
            login_pass_hint.Attributes.CssStyle.Add("border", "1px solid #F00 !important");
            return;
        }

        //Valid with database
        string username = login_user.Value;
        string password = INVISecurity.MD5(login_pass_hint.Value);
        UserEntity oUser = UserBRL.GetByUserPass(username, password);
        if ((oUser == null))
        {
            lblThongbao.Text = "<p class='err_login'>Tên đăng nhập hoặc mật khẩu không đúng!</p>";
        }
        //Response.Write("<script>alert('Đăng nhập không thành công');location='Default.aspx';</script>");
        else if (oUser.bActive == false)
        {
            lblThongbao.Text = "<p class='warring_login'>Tài khoản chưa được cấp phép truy cập!</p>";
        }
            //Response.Write("<script>alert('Tài khoản chưa được cấp phép truy nhập');location='Default.aspx';</script>");
        else
        {
            Session["UserID"] = oUser.iUserID;
            Session["Username"] = oUser.sUsername;
            Session["GroupID"] = oUser.iGroupID;
            Session["LoginCount"] = null; //Xóa Session lưu số lần đăng nhập
            if (oUser.iGroupID == 3)
            {
                List<CosonuoitrongEntity> csnt = CosonuoitrongBRL.GetByFK_iUserID(oUser.iUserID);
                if(csnt.Count>0)
                    Session["iCosonuoitrongID"] = csnt[0].PK_iCosonuoitrongID;
                //Response.Write("<script>alert('Đăng nhập thành công');location='UserMethods/Default.aspx';</script>");
                Response.Write("<script>location='UserMethods/Default.aspx';</script>");
            }
            else
            {

                Response.Write("<script>location='./Default.aspx';</script>");
                //Response.Write("<script>alert('Đăng nhập thành công');location='./Default.aspx';</script>");
            }
        }
    }

    /// <summary>
    /// Hàm kiểm tra số lần đăng nhập sai
    /// </summary>
    /// <returns>Boolean: true, nếu đăng nhập quá 10 lần, ngược lại false</returns>
    public Boolean bIsOverTry()
    {
        Boolean bRes = false;
        if (Session["LoginCount"] == null)
        {
            Session["LoginCount"] = 1;
        }
        else
        {
            short iLoginCount = short.Parse(Session["LoginCount"].ToString());
            if (iLoginCount >= 10)
            {
                bRes = true;
            }
            else
            {
                iLoginCount++;
                Session["LoginCount"] = iLoginCount;
            }
        }
        return bRes;
    }
}
