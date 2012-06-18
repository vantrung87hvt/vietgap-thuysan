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
public partial class adminx_ucPermission : System.Web.UI.UserControl
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            napGridView();
        }
    }
    private void napForm(int iPermissionID)
    {
        PermissionEntity oPer = PermissionBRL.GetOne(iPermissionID);
        if (oPer != null)
        {
            txtPerName.Text = oPer.sName;
            txtPerDesc.Text = oPer.sDesc;
            //sName = oPer.sName;
            napGridView();
        }
    }
    private void napGridView()
    {
        grvPermission.DataSource = PermissionBRL.GetAll();
        grvPermission.DataKeyNames = new string[] { "iPermissionID" };
        grvPermission.DataBind();
    }
    protected void grvPosition_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int iPermissionID = Convert.ToInt32(grvPermission.DataKeys[e.NewSelectedIndex].Values["iPermissionID"]);
        btnOK.CommandName = "Edit";
        btnOK.CommandArgument = iPermissionID.ToString();
        btnOK.Text = "Lưu";
        napForm(iPermissionID);
        
        txtPerDesc.Enabled = true;
        txtPerName.Enabled = true;
    }
    protected void grvPosition_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<PermissionEntity> list = PermissionBRL.GetAll();
        grvPermission.DataSource = PermissionEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
        grvPermission.DataBind();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
            try
            {
                if (btnOK.Text.CompareTo("Thêm") == 0)
                {
                    txtPerDesc.Text = "";
                    txtPerName.Text = "";
                    btnOK.Text = "Lưu";
                    btnOK.CommandName = "Add";
                    txtPerDesc.Enabled = true;
                    txtPerName.Enabled = true;

                }
                else
                {
                    PermissionEntity oPer = new PermissionEntity();
                    oPer.sName = txtPerName.Text;
                    oPer.sDesc = txtPerDesc.Text;

                    if (btnOK.CommandName.CompareTo("Edit") == 0)
                    {
                        oPer.iPermissionID = Convert.ToInt32(btnOK.CommandArgument);
                        PermissionBRL.Edit(oPer);
                        lblThongbao.Text = "Cập nhật thành công";
                    }
                    else
                        PermissionBRL.Add(oPer);

                    Response.Redirect(Request.Url.ToString());

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=Permission';</script>");
            }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtPerName.Text = "";
        txtPerDesc.Text = "";
        txtPerDesc.Enabled = false;
        txtPerName.Enabled = false;
        btnOK.Text = "Thêm";
        
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
            try
            {

                foreach (GridViewRow row in grvPermission.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int permissionID = Convert.ToInt32(grvPermission.DataKeys[row.RowIndex].Values["iPermissionID"]);
                    if (chkDelete != null && chkDelete.Checked)
                    {
                        PermissionEntity oPer = new PermissionEntity();
                        oPer.iPermissionID = permissionID;
                        PermissionBRL.Remove(oPer);
                    }
                }
                //Nap lai du lieu
                Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=Permission';</script>");
            }
    }
    protected void grvPermission_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvPermission.PageIndex = e.NewPageIndex;
        napGridView();
    }
}
