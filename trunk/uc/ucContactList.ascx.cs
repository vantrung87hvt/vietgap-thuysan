using INVI.Entity;
using INVI.Business;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class uc_ucContactList : System.Web.UI.UserControl
{
    private List<ContactEntity> lstContact = new List<ContactEntity>();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblLoi.Text = "";
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                pnComment.Visible = true;
                pnList.Visible = false;
                int contactID = Convert.ToInt32(Request.QueryString["ID"]);
                ContactEntity oContact = ContactBRL.GetOne(contactID);
                if (oContact != null)
                {
                    btnSend.CommandArgument = oContact.PK_iContactID.ToString();
                }
                else
                {
                    LoadPhongBan();
                    pnComment.Visible = false;
                    pnList.Visible = true;
                }                    
            }
            else
            {
                LoadPhongBan();
                pnComment.Visible = false;
                pnList.Visible = true;
            }
        }
    }
    protected void rptContactList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            {
                Label lblPK_iContactID = e.Item.FindControl("lblPK_iContactID") as Label;
                Label lblChucVu = e.Item.FindControl("lblChucVu") as Label;
                Label lblDienThoai = e.Item.FindControl("lblDienThoai") as Label;
                Label lblEmail = e.Item.FindControl("lblEmail") as Label;
                HyperLink lnkName = e.Item.FindControl("hplName") as HyperLink;
                ContactEntity oContact = ContactBRL.GetOne(Convert.ToInt32(lblPK_iContactID.Text));
                //
                lnkName.NavigateUrl = "~/Contact.aspx?ID=" + oContact.PK_iContactID;
                lnkName.Text = oContact.sHoTen;
                lblDienThoai.Text = oContact.sDienThoai;
                ChucVuEntity oChucVu = ChucVuBRL.GetOne(oContact.FK_iChucVuID);
                if (oChucVu != null)
                {
                    lblChucVu.Text = oChucVu.sTenChucVu;
                }
                lblEmail.Text = oContact.sEmail;                
            }
        }
    }
    private void LoadPhongBan()
    {
        lstContact = ContactBRL.GetAll();
        rptPhongBan.DataSource = PhongBanBRL.GetAll();
        rptPhongBan.DataBind();
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        UContactEntity oUContact = new UContactEntity();
        oUContact.FK_iContactID = Convert.ToInt32(btnSend.CommandArgument);
        oUContact.sContent = txtNoiDung.Text;
        oUContact.sTitle = txtChuDe.Text;
        oUContact.tDate = DateTime.Now;
        oUContact.sEmail = txtEmail.Text;
        try
        {
            UContactBRL.Add(oUContact);
            if (Session["Lang"].ToString() == "en-US")
                Response.Write("<script>alert('Your message has been sent!');location='./Default.aspx';</script>");
            else               
                Response.Write("<script>alert('Nội dung liên hệ đã được gửi đi!');location='./Default.aspx';</script>");
        }
        catch (Exception ex)
        {
            lblLoi.Text = ex.Message.ToString();
        }
        
        
    }
    protected void rptPhongBan_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            {
                Label lblPK_iPhongBanID = e.Item.FindControl("lblPK_iPhongBanID") as Label;
                
                int PhongBanID = Convert.ToInt32(lblPK_iPhongBanID.Text);
                Repeater rptContactList = e.Item.FindControl("rptContactList") as Repeater;
                List<ContactEntity> lstContact_PB = new List<ContactEntity>();
                lstContact.ForEach(
                        delegate(ContactEntity oContact) {
                            if (oContact.FK_iPhongBanID == PhongBanID)
                                lstContact_PB.Add(oContact);
                        }
                    );
                if (lstContact_PB.Count > 0)
                {
                    Label lblTenPhongBan = e.Item.FindControl("lblTenPhongBan") as Label;
                    PhongBanEntity oPhongBan = PhongBanBRL.GetOne(Convert.ToInt32(lblPK_iPhongBanID.Text));
                    if(Session["Lang"].ToString()=="en-US")
                        lblTenPhongBan.Text = "Department: " + oPhongBan.sTenPhong;
                    else
                        lblTenPhongBan.Text = "Cơ quan: " + oPhongBan.sTenPhong;
                    rptContactList.DataSource = lstContact_PB;
                    rptContactList.DataBind();
                }
                else {
                    Panel pn = e.Item.FindControl("pn") as Panel;
                    pn.Visible = false;
                }
            }
        }
    }
}