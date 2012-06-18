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
using INVI.Entity;
using INVI.Business;

public partial class uc_ucTinh : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblThongbao.Text = "";
        if (!IsPostBack)
        {
            LoadDropDownList();
            napgrvContact();
        }
    }
    private void LoadDropDownList()
    {
        ddlChucVu.DataValueField = "PK_iChucVuID";
        ddlChucVu.DataTextField = "sTenChucVu";
        ddlChucVu.DataSource = ChucVuBRL.GetAll();
        ddlChucVu.DataBind();
        //
        ddlPhong.DataValueField = "PK_iPhongBanID";
        ddlPhong.DataTextField = "sTenPhong";
        ddlPhong.DataSource = PhongBanBRL.GetAll();
        ddlPhong.DataBind();    

    }
    private void napgrvContact()
    {
        List<ContactEntity> lstContact = ContactBRL.GetAll();
        grvContact.DataSource = ContactEntity.Sort(lstContact, "sHoTen", "ASC");
        grvContact.DataKeyNames = new string[] { "PK_iContactID" };
        grvContact.DataBind();
    }

    protected void napForm(int ContactID)
    {
        ContactEntity Contact = ContactBRL.GetOne(ContactID);
        if (Contact != null)
        {            
            txtHoTen.Text = Contact.sHoTen;
            txtDienThoai.Text = Contact.sDienThoai;
            txtEmail.Text = Contact.sEmail;
            ddlChucVu.SelectedValue = Contact.FK_iChucVuID.ToString();
            ddlPhong.SelectedValue = Contact.FK_iPhongBanID.ToString();
        }

    }

    protected void grvContact_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<ContactEntity> listContact = ContactBRL.GetAll();
        grvContact.DataSource = ContactEntity.Sort(listContact, e.SortExpression, ViewState["SortDirection"].ToString());
        grvContact.DataBind();
    }

    protected void grvContact_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvContact.PageIndex = e.NewPageIndex;
        napgrvContact();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        btnOK.CommandName = "Add";
        btnOK.Text = "Thêm";
        pnAdd.Visible = true;
        reset();
    }

    protected void grvContact_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int ContactID = Convert.ToInt32(grvContact.DataKeys[e.NewSelectedIndex].Values["PK_iContactID"]);
        btnOK.CommandName = "Edit";
        btnOK.Text = "Sửa";
        btnOK.CommandArgument = ContactID.ToString();
        btnOK.CausesValidation = false;
        pnAdd.Visible = true;
        napForm(ContactID);
    }


    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
            try
            {
                foreach (GridViewRow row in grvContact.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int ContactID = Convert.ToInt32(grvContact.DataKeys[row.RowIndex].Values["PK_iContactID"]);
                    if (chkDelete != null && chkDelete.Checked)
                        ContactBRL.Remove(ContactID);
                }
                napgrvContact();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=ContactManager';</script>");
            }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        reset();
        btnOK.CommandName = "Add";
        pnAdd.Visible = false;
    }

    protected void reset()
    {
        txtHoTen.Text = "";
        txtDienThoai.Text = "";
        txtEmail.Text = "";    
    }
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearchByID.Text;
        int ContactID = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            ContactID = 0;
        else ContactID = Int16.Parse(txtID.Text);
        List<ContactEntity> lstContact = ContactBRL.GetAll();
        if (ContactID == 0)
        {
            lstContact = lstContact.FindAll(
            delegate(ContactEntity oContact)
            {
                return oContact.sHoTen.ToUpper().Contains(strSearch.ToUpper());
            }
            );
        }
        else
        {
            lstContact = lstContact.FindAll(
            delegate(ContactEntity oCContact)
            {
                return oCContact.PK_iContactID == ContactID;
            }
            );
        }
        lblThongbao.Text = "";
        grvContact.DataSource = lstContact;
        grvContact.DataKeyNames = new string[] { "PK_iContactID" };
        grvContact.DataBind();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napgrvContact();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
            try
            {
                ContactEntity oContact = new ContactEntity();
                oContact.sHoTen = txtHoTen.Text;
                oContact.sDienThoai = txtDienThoai.Text;
                oContact.sEmail = txtEmail.Text;
                oContact.FK_iChucVuID = Convert.ToInt32(ddlChucVu.SelectedValue);
                oContact.FK_iPhongBanID = Convert.ToInt32(ddlPhong.SelectedValue);
                if (btnOK.CommandName == "Edit")
                {
                    int ContactID = Convert.ToInt32(btnOK.CommandArgument);
                    oContact.PK_iContactID = ContactID;
                    ContactBRL.Edit(oContact);
                    btnOK.CausesValidation = true;
                    lblThongbao.Text = "Cập nhật thành công";
                }
                else
                {
                    int ContactAddID = ContactBRL.Add(oContact);
                    lblThongbao.Text = "Thêm thành công";
                }

                //Nạp lại dữ liệu
                pnAdd.Visible = false;
                napgrvContact();       
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=ContactManager';</script>");
            }
    }
}
