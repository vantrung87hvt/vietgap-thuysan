using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using INVI.Entity;
using System.Collections.Generic;
using INVI.Business;

public partial class adminx_CategoryEdit : System.Web.UI.UserControl
{
    protected void Page_Init(object sender, EventArgs e)
    {
        this.napTable(Convert.ToInt32(ConfigurationManager.AppSettings["NhomtinGoc"]), "");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!PermissionBRL.CheckPermission("Quanlychuyenmuc")) Response.End();
        bool valid = true;
        if (Request.QueryString["id"] != null)
        {
            int categoryID;
            bool result = Int32.TryParse(Request.QueryString["id"], out categoryID);
            if (result)
            {
                CategoryEntity oCategory = CategoryBRL.GetOne(categoryID);
                if (oCategory != null)
                {
                    cboTop.Items.Add(new ListItem("-Chọn nhóm cấp trên-", ConfigurationManager.AppSettings["NhomtinGoc"]));
                    this.napNhomcaptren(Convert.ToInt32(ConfigurationManager.AppSettings["NhomtinGoc"]), Server.HtmlDecode("&nbsp;"));
                    napForm(categoryID);
                    MultiView1.SetActiveView(View2);
                }
                else
                    valid = false;
            }
            else
                valid = false;
        }
        else
            valid = false;
        if (!valid) MultiView1.SetActiveView(View1);
        if (!Page.IsPostBack)
        {
            Table1.DataBind();
        }
    }
    /// <summary>
    /// Nạp danh sách nhóm cấp trên ra combobox
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="sCap"></param>
    private void napNhomcaptren(int categoryID, string sCap)
    {
        List<CategoryEntity> lstCat = CategoryBRL.GetByTopID(categoryID);
        foreach (CategoryEntity oCat in lstCat)
        {
            ListItem item = (new ListItem(sCap + oCat.sTitle, oCat.iCategoryID.ToString()));
            cboTop.Items.Add(item);
            napNhomcaptren(oCat.iCategoryID, sCap + "--");
        }//foreach
                
    }
    private void napTable(int categoryID, string sCap)
    {
        List<CategoryEntity> lstCat = CategoryBRL.GetByTopID(categoryID);
        foreach (CategoryEntity oCat in lstCat)
        {
            TableRow row = new TableRow();
            row.ID = oCat.iCategoryID.ToString();
            TableCell tc = new TableCell();
            CheckBox chkDelete = new CheckBox();
            
            chkDelete.ID = "chkDelete" + row.ID;
            
            tc.Controls.Add(chkDelete);
            row.Cells.Add(tc);
            //
            tc = new TableCell();
            tc.Text = oCat.iCategoryID.ToString();
            row.Cells.Add(tc);
            
            tc = new TableCell();
            if (oCat.iTopID == 15)
                tc.Font.Bold = true;
            tc.Text = sCap + oCat.sTitle;
            row.Cells.Add(tc);
            tc = new TableCell();
            tc.Text = oCat.iOrder.ToString();
            row.Cells.Add(tc);

            tc = new TableCell();
            HyperLink lnkEdit = new HyperLink();
            lnkEdit.Text = "Sửa";
            lnkEdit.NavigateUrl = "~/adminx/Default.aspx?page=CategoryEdit&id=" + oCat.iCategoryID;
            tc.Controls.Add(lnkEdit as Control);
            row.Cells.Add(tc);
            Table1.Rows.Add(row);
            napTable(oCat.iCategoryID, sCap + sCap + "-");
        }//foreach

    }
    private void napForm(int categoryID)
    {
        CategoryEntity oCat = CategoryBRL.GetOne(categoryID);
        if (oCat != null)
        {
            txtTitle.Text = oCat.sTitle;
            txtOrder.Text = oCat.iOrder.ToString();
            txtDesc.Text = oCat.sDesc;
            btnOK.CommandName = "Edit";
            btnOK.CommandArgument = oCat.iCategoryID.ToString();
            cboTop.ClearSelection();
            try
            {   //cboTop.Items.FindByValue(oCat.iTopID.ToString()).Selected = true;
                cboTop.Items.FindByValue(oCat.iTopID.ToString()).Selected = true;
            }
            catch (Exception ex) { Console.Out.Write(ex.Message); }
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                CategoryEntity oCat = new CategoryEntity();
                oCat.sTitle = txtTitle.Text;
                oCat.sDesc = txtDesc.Text;
                oCat.iOrder = Convert.ToByte(txtOrder.Text);
                oCat.iTopID = Convert.ToInt32(cboTop.SelectedValue);
                if (btnOK.CommandName == "Edit")
                {
                    oCat.iCategoryID = Convert.ToInt32(btnOK.CommandArgument);
                    CategoryBRL.Edit(oCat);
                }
                else
                    CategoryBRL.Add(oCat);
                lblThongbao.Text = "Cập nhật thành công";
                //Nạp lại dữ liệu
                Response.Redirect(Request.Url.ToString());
                MultiView1.SetActiveView(View1);
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=CategoryEdit';</script>");
            }
        }
        
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        btnOK.CommandName = "Add";
        txtTitle.Text = "";
        txtOrder.Text = "0";
        txtDesc.Text = "";
        cboTop.ClearSelection();
        MultiView1.SetActiveView(View1);
    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (TableRow tr in Table1.Rows)
            {
                CheckBox chkDelete = tr.FindControl("chkDelete" + tr.ID) as CheckBox;
                if (chkDelete != null && chkDelete.Checked)
                {
                    int categoryID = Convert.ToInt32(tr.ID);
                    CategoryEntity obj = new CategoryEntity();
                    obj.iCategoryID = categoryID;
                    CategoryBRL.Remove(obj);
                }
            }
            //Nap lai du lieu
            Response.Redirect(Request.Url.ToString());
        }
        catch (Exception ex)
        { lblThongbao.Text = ex.Message; }
        
    }
    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                MultiView1.SetActiveView(View2);
            }
            catch (Exception ex)
            {
                lblThongbao.Text = ex.Message;
            }
        }
       
    }
}
