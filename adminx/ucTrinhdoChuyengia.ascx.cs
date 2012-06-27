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
public partial class adminx_Tochucchungnhan_ucTrinhdoChuyengia : System.Web.UI.UserControl
{
    private bool bAddnew;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!PermissionBRL.CheckPermission("ManagerGroup")) Response.End();
        if (!IsPostBack)
        {
            this.napGridView();
        }
        
    }
    private void napForm(short PK_iTrinhdoChuyengiaID)
    {
        TrinhdoChuyengiaEntity oTrinhdoChuyengia = TrinhdoChuyengiaBRL.GetOne(PK_iTrinhdoChuyengiaID);
        if (oTrinhdoChuyengia != null)
        {
            txtTentrinhdo.Text = oTrinhdoChuyengia.sTrinhdo;
            napGridView();
        }
    }
    
    private void napGridView()
    {
        grvTrinhdoChuyengia.DataSource = TrinhdoChuyengiaBRL.GetAll();
        grvTrinhdoChuyengia.DataKeyNames = new string[] { "PK_PK_iTrinhdoChuyengiaID" };
        grvTrinhdoChuyengia.DataBind();
    }
    protected void grvPosition_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<TrinhdoChuyengiaEntity> list = TrinhdoChuyengiaBRL.GetAll();
        grvTrinhdoChuyengia.DataSource = TrinhdoChuyengiaEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
        grvTrinhdoChuyengia.DataBind();
    }
    protected void grvPosition_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        short PK_iTrinhdoChuyengiaID = Convert.ToInt16(grvTrinhdoChuyengia.DataKeys[e.NewSelectedIndex].Values["PK_PK_iTrinhdoChuyengiaID"]);
        btnOK.CommandName = "EDIT";
        btnOK.Text = "Sửa";
        bAddnew = false;
        pnlEdit.Visible = true;
        btnOK.CommandArgument = PK_iTrinhdoChuyengiaID.ToString();
        napForm(PK_iTrinhdoChuyengiaID);
    }
  
    protected void btnOK_Click(object sender, EventArgs e)
    {
        //Page.Validate("vgTrinhdoChuyengia");
        if (Page.IsValid)
        {
            try
            {
                TrinhdoChuyengiaEntity oTrinhdoChuyengia = new TrinhdoChuyengiaEntity();
                oTrinhdoChuyengia.sTrinhdo = txtTentrinhdo.Text;

                if (bAddnew == false && btnOK.CommandName.ToUpper() == "EDIT")
                {
                    oTrinhdoChuyengia.PK_iTrinhdoChuyengiaID = Convert.ToInt16(btnOK.CommandArgument);
                    TrinhdoChuyengiaBRL.Edit(oTrinhdoChuyengia);
                    lblThongbao.Text = "Cập nhật thành công";
                }
                else if(btnOK.CommandName.ToUpper()=="ADDNEW")
                {
                        TrinhdoChuyengiaBRL.Add(oTrinhdoChuyengia);
                        lblThongbao.Text = "Thêm nhóm thành công";
                }
            }
            catch (Exception ex)
            {
                //lblThongbao.Text = ex.Message;
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=TrinhdoChuyengia';</script>");
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
                foreach (GridViewRow row in grvTrinhdoChuyengia.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    short PK_iTrinhdoChuyengiaID = Convert.ToInt16(grvTrinhdoChuyengia.DataKeys[row.RowIndex].Values["PK_iTrinhdoChuyengiaID"]);
                    if (chkDelete != null && chkDelete.Checked)
                    {
                        TrinhdoChuyengiaBRL.Remove(PK_iTrinhdoChuyengiaID);
                    }
                }
                //Nap lai du lieu
                Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=TrinhdoChuyengia';</script>");
            }
        }

    }
    protected void lbtnAddnew_Click(object sender, EventArgs e)
    {
        txtTentrinhdo.Enabled = true;
        txtTentrinhdo.Text = "";
        btnOK.Text = "Lưu";
        btnOK.CommandName = "ADDNEW";
        pnlEdit.Visible = true;
    }
}
