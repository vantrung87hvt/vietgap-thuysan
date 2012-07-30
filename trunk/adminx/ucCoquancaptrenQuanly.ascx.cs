using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.Business;
public partial class adminx_ucCoquancaptrenQuanly : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!PermissionBRL.CheckPermission("Quanlycoquancaptren")) Response.End();
        napGrid();
    }
    private void napGrid()
    {
        List<CoquancaptrenEntity> lstCoquancaptren = CoquancaptrenBRL.GetAll();
        grvCoquancaptren.DataSource = lstCoquancaptren;
        grvCoquancaptren.DataKeyNames = new String[] { "PK_iCoquancaptrenID" };
        grvCoquancaptren.DataBind();
    }

    protected void grvCoquancaptren_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvCoquancaptren.PageIndex = e.NewPageIndex;
        napGrid();
    }
    protected void grvCoquancaptren_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int PK_iCoquancaptrenID = Convert.ToInt32(grvCoquancaptren.DataKeys[e.NewSelectedIndex].Values["PK_iCoquancaptrenID"].ToString());
        napForm(PK_iCoquancaptrenID);
    }
    private void napForm(int PK_iCoquancaptrenID)
    {
        txtTen.Text = CoquancaptrenBRL.GetOne(PK_iCoquancaptrenID).sTencoquan;
        btnOK.Text = "Lưu";
        btnOK.CommandName = "EDIT";
        btnOK.CommandArgument = PK_iCoquancaptrenID.ToString();
        pnAdd.Visible = true;
    }
    protected void grvCoquancaptren_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<CoquancaptrenEntity> lstCoquancaptren = CoquancaptrenBRL.GetAll();
        grvCoquancaptren.DataSource = CoquancaptrenEntity.Sort(lstCoquancaptren, e.SortExpression, ViewState["SortDirection"].ToString());
        grvCoquancaptren.DataBind();
    }
    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        pnAdd.Visible = true;
        txtTen.Text = "";
        btnOK.CommandName = "ADDNEW";
        
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                if (btnOK.CommandName.ToUpper() == "ADDNEW")
                {
                    CoquancaptrenEntity oCoquancaptren = new CoquancaptrenEntity();
                    oCoquancaptren.sTencoquan = txtTen.Text;
                    CoquancaptrenBRL.Add(oCoquancaptren);
                    Response.Write("<script language=\"javascript\">alert('Thêm mới thành công!');location='Default.aspx?page=CoquancaptrenQuanly';</script>");
                    napGrid();
                }
                else if (btnOK.CommandName.ToUpper() == "EDIT")
                {
                    int PK_iCoquancaptrenID = Convert.ToInt32(btnOK.CommandArgument);
                    CoquancaptrenEntity oCoquancaptren = CoquancaptrenBRL.GetOne(PK_iCoquancaptrenID);
                    oCoquancaptren.sTencoquan = txtTen.Text;
                    CoquancaptrenBRL.Edit(oCoquancaptren);
                    Response.Write("<script language=\"javascript\">alert('Cập nhập thành công!');location='Default.aspx?page=CoquancaptrenQuanly';</script>");
                    napGrid();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=CoquancaptrenQuanly';</script>");
            }
        }
    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                foreach (GridViewRow row in grvCoquancaptren.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int coquancaptrenID = Convert.ToInt32(grvCoquancaptren.DataKeys[row.RowIndex].Values["PK_iCoquancaptrenID"]);
                    if (chkDelete != null && chkDelete.Checked)
                        CoquancaptrenBRL.Remove(coquancaptrenID);
                }
                napGrid();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=CoquancaptrenQuanly';</script>");
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtTen.Text = "";
        pnAdd.Visible = false;
    }
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearchByID.Text;
        int coquancaptrenID = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            coquancaptrenID = 0;
        else coquancaptrenID = Int16.Parse(txtID.Text);
        List<CoquancaptrenEntity> lstCoquancaptren = CoquancaptrenBRL.GetAll();
        if (coquancaptrenID == 0)
        {
            lstCoquancaptren = lstCoquancaptren.FindAll(
            delegate(CoquancaptrenEntity oCoquancaptren)
            {
                return oCoquancaptren.sTencoquan.ToUpper().Contains(strSearch.ToUpper());
            }
            );
        }
        else
        {
            lstCoquancaptren = lstCoquancaptren.FindAll(
            delegate(CoquancaptrenEntity oCoquancaptren)
            {
                return oCoquancaptren.PK_iCoquancaptrenID == coquancaptrenID;
            }
            );
        }
        lblThongbao.Text = "";
        grvCoquancaptren.DataSource = lstCoquancaptren;
        grvCoquancaptren.DataKeyNames = new string[] { "PK_iCoquancaptrenID" };
        grvCoquancaptren.DataBind();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napGrid();
    }
}