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
public partial class adminx_ucGroup : System.Web.UI.UserControl
{
    private bool bAddnew;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!PermissionBRL.CheckPermission("ManagerGroup")) Response.End();
        if (!IsPostBack)
        {
            this.napGridView();
        }
        
    }
    private void napForm(int iGroupID)
    {
        GroupEntity oGroup = GroupBRL.GetOne(iGroupID);
        if (oGroup != null)
        {
            txtGroupName.Text = oGroup.sName;
            txtGroupDesc.Text = oGroup.sDesc;
            napGridView();
        }
    }
    
    private void napGridView()
    {
        grvGroup.DataSource = GroupBRL.GetAll();
        grvGroup.DataKeyNames = new string[] { "iGroupID" };
        grvGroup.DataBind();
    }
    protected void grvPosition_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<GroupEntity> list = GroupBRL.GetAll();
        grvGroup.DataSource = GroupEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
        grvGroup.DataBind();
    }
    protected void grvPosition_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int iGroupID = Convert.ToInt32(grvGroup.DataKeys[e.NewSelectedIndex].Values["iGroupID"]);
        btnOK.CommandName = "EDIT";
        btnOK.Text = "Sửa";
        bAddnew = false;
        pnlEdit.Visible = true;
        btnOK.CommandArgument = iGroupID.ToString();
        napForm(iGroupID);
    }
  
    protected void btnOK_Click(object sender, EventArgs e)
    {
            Page.Validate("vgGroup");
            if (Page.IsValid)
            {
                try
                {
                    GroupEntity oGroup = new GroupEntity();
                    oGroup.sName = txtGroupName.Text;
                    oGroup.sDesc = txtGroupDesc.Text;

                    if (bAddnew == false && btnOK.CommandName.ToUpper() == "EDIT")
                    {
                        oGroup.iGroupID = Convert.ToInt32(btnOK.CommandArgument);
                        GroupBRL.Edit(oGroup);
                        lblThongbao.Text = "Cập nhật thành công";
                    }
                    else if(btnOK.CommandName.ToUpper()=="ADDNEW")
                    {
                            GroupBRL.Add(oGroup);
                            lblThongbao.Text = "Thêm nhóm thành công";
                    }
                }
                catch (Exception ex)
                {
                    //lblThongbao.Text = ex.Message;
                    Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=Group';</script>");
                }
            }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if(btnOK.CommandName.ToUpper()=="EDIT")
            napForm(Convert.ToInt16(btnOK.CommandArgument));
    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                foreach (GridViewRow row in grvGroup.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int iGroupID = Convert.ToInt32(grvGroup.DataKeys[row.RowIndex].Values["iGroupID"]);
                    if (chkDelete != null && chkDelete.Checked)
                    {
                        GroupBRL.Remove(iGroupID);
                    }
                }
                //Nap lai du lieu
                Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=Group';</script>");
            }
        }

    }
    protected void lbtnAddnew_Click(object sender, EventArgs e)
    {
        txtGroupName.Enabled = true;
        txtGroupName.Text = "";
        txtGroupDesc.Text = "";
        txtGroupDesc.Enabled = true;
        btnOK.Text = "Lưu";
        btnOK.CommandName = "ADDNEW";
        pnlEdit.Visible = true;
    }
}
