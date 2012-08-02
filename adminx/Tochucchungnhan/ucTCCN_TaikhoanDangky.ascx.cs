using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using INVI.Business;
using INVI.Entity;
using INVI.INVILibrary;

public partial class adminx_Tochucchungnhan_ucTCCN_TaikhoanDangky : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!PermissionBRL.CheckPermission("QLTaikhoandangkyvoiTCCN")) Response.End();
        if (Session["MasoVietGap"] != null)
            if (Session["MasoVietGap"].ToString().Length <= 0)
                Response.Write("<script language=\"javascript\">alert('Tổ chức của bạn chưa được cấp mã số. Nên không thể thực hiện được thao tác này.');location='Default.aspx';</script>");
        if (!IsPostBack)
        {
            this.napGridView();
        }
    }
    private void napGridView()
    {
        List<UserEntity> lstUser = new List<UserEntity>();
        int iUserID = 0;
        if (Session["userID"] != null)
            iUserID = Convert.ToInt32(Session["userID"].ToString());
        List<TochucchungnhanTaikhoanEntity> lstTochucTaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(iUserID);
        List<TaiKhoanDangKyToChucChungNhanEntity> lstTaikhoanDangkyVoiToChucCN = TaiKhoanDangKyToChucChungNhanBRL.GetByFK_iTochucchungnhanID(lstTochucTaikhoan[0].FK_iTochucchungnhanID);
        foreach (TaiKhoanDangKyToChucChungNhanEntity oTaikhoanDangkyVoiTCCN in lstTaikhoanDangkyVoiToChucCN)
            lstUser.Add(UserBRL.GetOne(oTaikhoanDangkyVoiTCCN.FK_iTaikhoanID));

        grvUsers.DataSource = lstUser;
        grvUsers.DataKeyNames = new string[] { "iUserID" };
        grvUsers.DataBind();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (btnOK.Text.CompareTo(Resources.language.them) == 0)
        {
            textBox_enordis(true);
            textBox_setText("");
            btnOK.Text = Resources.language.luu;
            btnOK.CommandName = "Add";
        }
        else
        {
            Page.Validate("vgUser");
            if (Page.IsValid)
            {
                int Result = 0;
                try
                {
                    UserEntity oUser = new UserEntity();
                    oUser.iGroupID = 3;
                    oUser.sEmail = txtEmail.Text;
                    oUser.sIP = txtIP.Text;
                    oUser.sUsername = txtUsername.Text;
                    if (btnOK.CommandName.CompareTo("Edit") == 0)
                    {
                        oUser.iUserID = Convert.ToInt32(btnOK.CommandArgument);
                        UserEntity obj = UserBRL.GetOne(oUser.iUserID);
                        oUser.sPassword = txtPassword.Text.Trim() == "" ? obj.sPassword : INVI.INVILibrary.INVISecurity.MD5(txtPassword.Text);
                        UserBRL.Edit(oUser);
                        lblThongbao.Text = Resources.language.capnhapthanhcong;
                        textBox_enordis(false);

                    }
                    else
                    {
                        if (txtPassword.Text.Trim() == "")
                            throw new Exception("Chưa nhập password");
                        oUser.sPassword = INVI.INVILibrary.INVISecurity.MD5(txtPassword.Text);
                        Result = UserBRL.Add(oUser);
                    }
                    if (Result > 0) lblThongbao.Text = Resources.language.taikhoannguoidungduocthemmoi;

                    Response.Redirect(Request.Url.ToString());
                }
                catch (Exception ex)
                {
                    lblThongbao.Text = ex.Message;
                }
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        textBox_setText("");
        btnOK.Text = Resources.language.them;
        textBox_enordis(false);
    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in grvUsers.Rows)
            {
                CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                int userID = Convert.ToInt32(grvUsers.DataKeys[row.RowIndex].Values["iUserID"]);
                if (chkDelete != null && chkDelete.Checked)
                {
                    int ssUserID = Convert.ToInt32(Session["UserID"]);
                    if (userID == ssUserID)
                        lblInfo.Text = "Bạn định xóa chính mình ?";
                    else
                    {
                        // Nếu User đang được gắn với Tổ chức chứng nhận nào đó
                        List<TochucchungnhanTaikhoanEntity> lstTochucTaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(userID);
                        if (lstTochucTaikhoan.Count > 0)
                            foreach (TochucchungnhanTaikhoanEntity oTochucTaikhoanE in lstTochucTaikhoan)
                                TochucchungnhanTaikhoanBRL.Remove(oTochucTaikhoanE.PK_iTochucchungnhanTaikhoanID);

                        List<CosonuoitrongEntity> lstCosonuoitrong = CosonuoitrongBRL.GetByFK_iUserID(userID);
                        if (lstCosonuoitrong.Count > 0)
                            foreach (CosonuoitrongEntity oCosonuoitrong in lstCosonuoitrong)
                                CosonuoitrongBRL.Remove(oCosonuoitrong.PK_iCosonuoitrongID);

                        UserBRL.Remove(userID);
                    }
                }
            }
            //Nap lai du lieu
            Response.Redirect(Request.Url.ToString());
        }
        catch (Exception ex)
        {
            Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=UserManager';</script>");
        }
    }
    protected void grvPosition_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int iUserID = Convert.ToInt32(grvUsers.DataKeys[e.NewSelectedIndex].Values["iUserID"]);
        btnOK.CommandName = "Edit";
        btnOK.CommandArgument = iUserID.ToString();
        textBox_enordis(true);
        btnOK.Text = Resources.language.luu;
        napForm(iUserID);
    }
    private void napForm(int iUserID)
    {
        UserEntity oUser = UserBRL.GetOne(iUserID);
        if (oUser != null)
        {
            txtEmail.Text = oUser.sEmail;

            txtUsername.Text = oUser.sUsername;
            txtIP.Text = oUser.sIP;
            napGridView();
        }
    }
    private void textBox_enordis(bool bEnable)
    {
        txtIP.Enabled = bEnable;
        txtEmail.Enabled = bEnable;
        txtPassword.Enabled = bEnable;
        txtUsername.Enabled = bEnable;
    }
    private void textBox_setText(String sText)
    {
        txtIP.Text = sText;
        txtEmail.Text = sText;
        txtPassword.Text = sText;
        txtUsername.Text = sText;
    }
    protected void grvPosition_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<UserEntity> list = UserBRL.GetAll();
        grvUsers.DataSource = UserEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
        grvUsers.DataBind();
    }
    protected void grvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvUsers.PageIndex = e.NewPageIndex;
        napGridView();
    }
    protected string getGroupName(Object x)
    {
        int iGroupID = int.Parse(x.ToString());
        String sGroupName = string.Empty;
        GroupEntity oGrp = new GroupEntity();
        oGrp = GroupBRL.GetOne(iGroupID);
        if (oGrp != null)
            sGroupName = oGrp.sName;
        return sGroupName;
    }    protected string getPasswordChar(Object x)
    {
        int iLen = x.ToString().Length;
        String sPasswordChar = string.Empty;
        for (int i = 0; i < iLen; i++)
            sPasswordChar += "*";
        return sPasswordChar;
    }
    protected void grvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblKiemduyet = null;
        lblKiemduyet = (Label)e.Row.FindControl("lblKiemduyet");
        if (lblKiemduyet != null)
        {
            bool bKichhoat = Convert.ToBoolean(lblKiemduyet.Text);
            lblKiemduyet.Text = bKichhoat ? "Kích hoạt" : "Chưa";
        }
    }
    public void SendEmailVerificationToUser(string sEmail,string strUsername, string iduser)
    {
        string body = "<b>Tài khoản</b>: ##UserName## đã được kích hoạt thành công. Bạn có thể sử dụng tài khoản này để đăng nhập và nhập các thông tin về Cơ sở nuôi trồng.";
        body += "Thực hiện việc gửi hồ sơ trực tuyến, đăng ký để được kiểm định, đánh giá và cấp mã số.";
        body = body.Replace("##UserName##", strUsername);
        INVIHelper.Send_Email(sEmail, "Tài khoản bạn đăng ký với Tổ chức chứng nhận đã được kích hoạt.", body);

    }
    protected void lbtnActive_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in grvUsers.Rows)
            {
                CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                int userID = Convert.ToInt32(grvUsers.DataKeys[row.RowIndex].Values["iUserID"]);
                if (chkDelete != null && chkDelete.Checked)
                {
                    UserEntity oUser = UserBRL.GetOne(userID);
                    oUser.bActive = chkDelete.Checked;
                    UserBRL.Edit(oUser);
                    TaiKhoanDangKyToChucChungNhanBRL.GetByFK_iTaikhoanID(userID)[0].bDuyet = chkDelete.Checked;
                    SendEmailVerificationToUser(oUser.sEmail,oUser.sUsername, "");
                }
            }
            //Nap lai du lieu
            Response.Redirect(Request.Url.ToString());
        }
        catch (Exception ex)
        {
            Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=UserManager';</script>");
        }
    }
}