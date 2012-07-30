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
public partial class adminx_ucGroupPermission : System.Web.UI.UserControl
{
    //private bool bAddnew = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!PermissionBRL.CheckPermission("Phanquyenuser")) Response.End();
        if (!IsPostBack)
        {
            this.napGridView();
            ddlGroupName_loadData();
            ddlPermission_loadData(int.Parse(ddlGroupName.SelectedValue));
        }
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
    }
    protected string getPermissionName(Object x)
    {
        int iPermissionID = int.Parse(x.ToString());
        String sPermissionName = string.Empty;
        PermissionEntity oPermission = new PermissionEntity();
        oPermission = PermissionBRL.GetOne(iPermissionID);
        if (oPermission != null)
            sPermissionName = oPermission.sName;
        return sPermissionName;
    }
    private void napGridView()
    {
        if (ddlGroupName.Items.Count > 0)
        {
            grvGroupPermission.DataSource = GroupPermissionBRL.GetAll().FindAll(
                    delegate(GroupPermissionEntity groupPermEn)
                    {
                        return groupPermEn.iGroupID == int.Parse(ddlGroupName.SelectedValue);
                    }
                    );
        }
        else
        {
            grvGroupPermission.DataSource = GroupPermissionBRL.GetAll();
        }
        grvGroupPermission.DataKeyNames = new string[] { "iGroupPermissionID" };
        grvGroupPermission.DataBind();
    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvGroupPermission.Rows)
        {
            CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
            if (chkDelete != null && chkDelete.Checked)
            {
                int GroupPermissionID = Convert.ToInt32(grvGroupPermission.DataKeys[row.RowIndex].Values["iGroupPermissionID"]);
                GroupPermissionBRL.Remove(GroupPermissionID);
            }
        }
        //Nap lai du lieu
        Response.Redirect(Request.Url.ToString());
    }
    private void napForm(int iGroupPermissionID)
    {
        GroupPermissionEntity oGroupPermission = GroupPermissionBRL.GetOne(iGroupPermissionID);
        if (oGroupPermission != null)
        {
            ddlGroupName.ClearSelection();
            ddlGroupName.Items.FindByValue(oGroupPermission.iGroupID.ToString()).Selected = true;
            ddlPermission.ClearSelection();
            ddlPermission.Items.FindByValue(oGroupPermission.iPermissionID.ToString()).Selected = true;
            napGridView();
        }
    }
    
    protected void btnOK_Click(object sender, EventArgs e)
    {
        panAdd.Visible = true;
        Page.Validate("vgQuyennguoidung");
        if (Page.IsValid)
        {
            try
            {
                GroupPermissionEntity oGroupPermission = new GroupPermissionEntity();
                oGroupPermission.iGroupID = Int16.Parse(ddlGroupName.SelectedItem.Value);
                oGroupPermission.sValue = "";
                oGroupPermission.iGroupPermissionID = Int16.Parse(btnOK.CommandArgument);
                oGroupPermission.iPermissionID = Int16.Parse(ddlPermission.SelectedItem.Value);
                GroupPermissionBRL.Edit(oGroupPermission);
                lblThongbao.Text = Resources.language.capnhapthanhcong;
                Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ex)
            {
                lblThongbao.Text = ex.Message;
            }
            finally
            {
                panEdit.Visible = false;
            }
        }
    }

    //Hàm thêm quyền mới
    public void addPermission()
    {
        int iRes = 0;
        Page.Validate("vgQuyennguoidung");
        if (Page.IsValid)
        {
            try
            {
                GroupPermissionEntity oGroupPermission = new GroupPermissionEntity();
                oGroupPermission.iGroupID = Int16.Parse(ddlGroupName.SelectedItem.Value);
                oGroupPermission.iPermissionID = Int16.Parse(ddlPermission.SelectedItem.Value);
                oGroupPermission.sValue = "";
                iRes = GroupPermissionBRL.Add(oGroupPermission);
                Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ex)
            {
                lblThongbao.Text = ex.Message;
            }
            if (iRes > 0) lblThongbao.Text = Resources.language.nhomquyendaduocthem;
        }
    }
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        panEdit.Visible = false;
        panAdd.Visible = true;
    }
    private void ddlPermission_loadData(int PK_iGroupID)
    {
        ddlPermission.Items.Clear();
        List<PermissionEntity> lstPermission = PermissionBRL.GetByGroupID(PK_iGroupID);
        foreach (PermissionEntity oPermission in lstPermission)
        {
            ListItem item = (new ListItem(oPermission.sName, oPermission.iPermissionID.ToString()));
            ddlPermission.Items.Add(item);
        }//foreach
        if(ddlPermission.Items.Count>0) ddlPermission.SelectedIndex = 0;
    }
    private void ddlGroupName_loadData()
    {
        ddlGroupName.Items.Clear();
        List<GroupEntity> lstGroup = GroupBRL.GetAll();
        foreach (GroupEntity oGroup in lstGroup)
        {
            ListItem item = (new ListItem(oGroup.sName, oGroup.iGroupID.ToString()));
            ddlGroupName.Items.Add(item);
        }//foreach
        if(ddlGroupName.Items.Count>0) ddlGroupName.SelectedIndex = 0;
    }

    protected void grvGroupPermission_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        panEdit.Visible = true;
        panAdd.Visible = false;
        int iGroupPermissionID = Convert.ToInt32(grvGroupPermission.DataKeys[e.NewSelectedIndex].Values["iGroupPermissionID"]);
        btnOK.CommandName = "Edit";
        btnOK.CommandArgument = iGroupPermissionID.ToString();
        //textBox_enordis(true);
        btnOK.Text = "Lưu";
        napForm(iGroupPermissionID);
    }
    protected void grvGroupPermission_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<GroupPermissionEntity> list = GroupPermissionBRL.GetAll();
        grvGroupPermission.DataSource = GroupPermissionEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
        grvGroupPermission.DataBind();
    }
    protected void grvGroupPermission_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvGroupPermission.PageIndex = e.NewPageIndex;
        napGridView();
    }
    protected void ddlGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPermission_loadData(int.Parse(ddlGroupName.SelectedValue));
        napGridView();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        addPermission();
    }
    protected void lbtnThemmoi_Click(object sender, EventArgs e)
    {
        panAdd.Visible = true;
        panEdit.Visible = false;
    }
}
