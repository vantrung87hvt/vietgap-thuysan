using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.Business;
using INVI.INVILibrary;
public partial class uc_ucRegister_ : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            napTinh();
            napDoituongnuoi();
            napNamsanxuat();
            reset();
        }
    }
    protected void btnRegistry_Click(object sender, EventArgs e)
    {
        try
        {
        if (insertUser())
        {
        CosonuoitrongEntity csnt = new CosonuoitrongEntity();
        csnt.sTencoso = regTencoso.Text;
        csnt.sTenchucoso = regTenchucoso.Text;
        csnt.sAp = regAp.Text;
        csnt.sXa = regXa.Text;
        //csnt.sHuyen = regHuyen.Text;
        csnt.sDienthoai = regDienthoai.Text;
        csnt.fTongdientich = float.Parse(regTongdientichcosonuoi.Text);
        csnt.fTongdientichmatnuoc = float.Parse(regTongdientichmatnuoc.Text);
        csnt.FK_iToadoID = 1;
        //csnt.FK_iTinhID = Int32.Parse(ddlTinh.SelectedValue);
        csnt.FK_iDoituongnuoiID = Int32.Parse(ddlDoituongnuoi.SelectedValue);
        csnt.iNamsanxuat = Int32.Parse(ddlNamsanxuat.SelectedItem.Text);
        csnt.bDuyet = false;
        csnt.dNgaydangky = DateTime.Now;
        csnt.iChukynuoi = int.Parse(regChukinuoi.Text);
        csnt.sSodoaonuoi = "";

        CosonuoitrongBRL.Add(csnt);
        Response.Write("<script>alert('Đăng ký thành công!');location='./Default.aspx';</script>");
        }
        else
        {
            Response.Write("<script>alert('Đăng ký không thành công!');location='./Registry.aspx';</script>");
        }
        }
        catch
        {
            Response.Write("<script>alert('Đăng ký bị lỗi!');location='./Registry.aspx';</script>");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        reset();
    }
    protected void napTinh()
    {
        ddlTinh.Items.Clear();
        List<TinhEntity> lstTinh = TinhBRL.GetAll();
        ddlTinh.DataSource = lstTinh;
        ddlTinh.DataTextField = "sTentinh";
        ddlTinh.DataValueField = "PK_iTinhID";
        ddlTinh.DataBind();
        ddlTinh.Items.Insert(0, new ListItem("--- Chọn ---", "0"));
    }

    protected void napDoituongnuoi()
    {
        ddlDoituongnuoi.Items.Clear();
        List<DoituongnuoiEntity> lstDoituongnuoi = DoituongnuoiBRL.GetAll();
        ddlDoituongnuoi.DataSource = lstDoituongnuoi;
        ddlDoituongnuoi.DataTextField = "sTendoituong";
        ddlDoituongnuoi.DataValueField = "PK_iDoituongnuoiID";
        ddlDoituongnuoi.DataBind();
        ddlDoituongnuoi.Items.Insert(0, new ListItem("--- Chọn ---", "0"));

    }
    protected Boolean insertUser()
    {
        try
        {
            string password = INVISecurity.MD5(regpassword.Text);

            UserEntity us = new UserEntity();
            us.sUsername = regusername.Text;
            us.sPassword = password;
            us.sEmail = regemail.Text;
            us.bActive = false;
            us.tLastVisit = DateTime.Now;
            us.sIP = null;
            us.iGroupID = 2;
            UserBRL.Add(us);
            return true;
        }
        catch
        {
            return false;
        }
    }
    protected void napNamsanxuat()
    {
        ddlNamsanxuat.Items.Insert(0, new ListItem("--- Chọn ---", "0"));
        for (int i = 2011; i >= 1990; i--)
        {
            ddlNamsanxuat.Items.Add(i.ToString());
        }
    }

    protected void reset()
    {
        regusername.Text = "";
        regpassword.Text = "";
        regrepass.Text = "";
        regemail.Text = "";
        regreemail.Text = "";

        regTencoso.Text = "";
        regTenchucoso.Text = "";
        regAp.Text = "";
        regXa.Text = "";
        regHuyen.Text = "";
        regDienthoai.Text = "";
        regTongdientichcosonuoi.Text = "0";
        regTongdientichmatnuoc.Text = "0";
        ddlDoituongnuoi.SelectedIndex = 0;
        ddlNamsanxuat.SelectedIndex = 0;
        regChukinuoi.Text = "";
    }

}