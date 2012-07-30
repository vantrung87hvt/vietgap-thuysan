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
public partial class adminx_ucListContact : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pnAdd.Visible = false;
        lblThongbao.Text = "";
        if (!IsPostBack)
        {
            if (!PermissionBRL.CheckPermission("QLDanhsachdanhba")) Response.End();
            napgrvContact();
        }
    }
    private void napgrvContact()
    {
        List<UContactEntity> lstContact = UContactBRL.GetAll();
        grvContact.DataSource = UContactEntity.Sort(lstContact, "tDate", "ASC");
        grvContact.DataKeyNames = new string[] { "PK_iUContactID" };
        grvContact.DataBind();
    }

    protected void napForm(int ContactID)
    {
        UContactEntity oUContact = UContactBRL.GetOne(ContactID);
        if (oUContact != null)
        {
            txtDate.Text = oUContact.tDate.ToString();
            txtEmail.Text = oUContact.sEmail;
            txtTieuDe.Text = oUContact.sTitle;
            txtNoiDung.Text = oUContact.sContent;
            ContactEntity oContact = ContactBRL.GetOne(oUContact.FK_iContactID);
            if (oContact != null)
            {
                txtHoTen.Text = oContact.sHoTen;
                try
                {
                    txtChucVu.Text = ChucVuBRL.GetOne(oContact.FK_iChucVuID).sTenChucVu;
                }
                catch { 
                }
                try
                {
                    txtPhongBan.Text = PhongBanBRL.GetOne(oContact.FK_iPhongBanID).sTenPhong;
                }
                catch
                {
                }

            }
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
        List<UContactEntity> listContact = UContactBRL.GetAll();
        grvContact.DataSource = UContactEntity.Sort(listContact, e.SortExpression, ViewState["SortDirection"].ToString());
        grvContact.DataBind();
    }

    protected void grvContact_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvContact.PageIndex = e.NewPageIndex;
        napgrvContact();
    }    
    protected void grvContact_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int ContactID = Convert.ToInt32(grvContact.DataKeys[e.NewSelectedIndex].Values["PK_iUContactID"]);        
        btnOK.CommandArgument = ContactID.ToString();
        btnOK.CausesValidation = false;
        pnAdd.Visible = true;
        napForm(ContactID);
    }


    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                foreach (GridViewRow row in grvContact.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int ContactID = Convert.ToInt32(grvContact.DataKeys[row.RowIndex].Values["PK_iUContactID"]);
                    if (chkDelete != null && chkDelete.Checked)
                        UContactBRL.Remove(ContactID);
                }
                napgrvContact();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=ListContact';</script>");
            }
        }

    }  

    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearchByID.Text;
        int ContactID = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            ContactID = 0;
        else ContactID = Int16.Parse(txtID.Text);
        List<UContactEntity> lstContact = UContactBRL.GetAll();
        if (ContactID == 0)
        {
            lstContact = lstContact.FindAll(
            delegate(UContactEntity oContact)
            {
                return oContact.sTitle.ToUpper().Contains(strSearch.ToUpper()) || oContact.sEmail.ToUpper().Contains(strSearch.ToUpper());
            }
            );
        }
        else
        {
            lstContact = lstContact.FindAll(
            delegate(UContactEntity oCContact)
            {
                return oCContact.PK_iUContactID == ContactID;
            }
            );
        }
        lblThongbao.Text = "";
        grvContact.DataSource = lstContact;
        grvContact.DataKeyNames = new string[] { "PK_iUContactID" };
        grvContact.DataBind();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napgrvContact();
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        pnAdd.Visible = false;
    }
}
