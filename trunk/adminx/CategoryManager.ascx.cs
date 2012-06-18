using INVI.Entity;
using INVI.Business;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace INVI.INVINews.Admin
{
    public partial class CategoryManager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!PermissionBRL.CheckPermission("ManagerCategory"))Response.End();
            if (!IsPostBack)
            {
                this.napGridView();
                cboTop.Items.Add(new ListItem("-Chọn nhóm cấp trên-", "0"));
                this.napNhomcaptren(0, Server.HtmlDecode("&nbsp;"));
            }
        }

        private void napGridView()
        {
            grvCategory.DataSource = CategoryBRL.GetAll();
            grvCategory.DataKeyNames = new string[] { "iCategoryID", "iTopID" };

            grvCategory.DataBind();
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
                napNhomcaptren(oCat.iCategoryID, sCap + "-");
            }//foreach

        }
        protected void grvCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int topID = Convert.ToInt32(grvCategory.DataKeys[e.Row.RowIndex].Values["iTopID"]);
                Label lblNhomcaptren = e.Row.FindControl("lblNhomcaptren") as Label;
                if (lblNhomcaptren != null)
                {
                    if (topID == 0)
                        lblNhomcaptren.Text = "-Root-";
                    else
                    {
                        CategoryEntity oTop = CategoryBRL.GetOne(topID);
                        if (oTop != null)
                            lblNhomcaptren.Text = oTop.sTitle;
                    }
                }
            }
        }
        protected void grvCategory_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int categoryID = Convert.ToInt32(grvCategory.DataKeys[e.NewSelectedIndex].Values["iCategoryID"]);
            btnOK.CommandName = "Edit";
            btnOK.CommandArgument = categoryID.ToString();
            napForm(categoryID);
            //
        }

        private void napForm(int categoryID)
        {
            CategoryEntity oCat = CategoryBRL.GetOne(categoryID);
            if (oCat != null)
            {
                txtTitle.Text = oCat.sTitle;
                txtOrder.Text = oCat.iOrder.ToString();
                txtDesc.Text = oCat.sDesc;
                cboTop.ClearSelection();
                cboTop.Items.FindByValue(oCat.iTopID.ToString()).Selected = true;
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
                }
                catch (Exception ex)
                {
                    Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=CategoryManager';</script>");
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
        }
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    foreach (GridViewRow row in grvCategory.Rows)
                    {
                        CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                        int categoryID = Convert.ToInt32(grvCategory.DataKeys[row.RowIndex].Values["iCategoryID"]);
                        if (chkDelete != null && chkDelete.Checked)
                        {
                            CategoryEntity oCat = new CategoryEntity();
                            oCat.iCategoryID = categoryID;
                            CategoryBRL.Remove(oCat);
                        }
                    }
                    //Nap lai du lieu
                    Response.Redirect(Request.Url.ToString());
                }
                catch (Exception ex)
                {
                    Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=CategoryManager';</script>");
                }
            }

            
        }
        protected void grvCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvCategory.PageIndex = e.NewPageIndex;
            napGridView();
        }
        protected void grvCategory_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null)
                ViewState["SortDirection"] = "ASC";
            else
            {
                ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
            }
            List<CategoryEntity> list = CategoryBRL.GetAll();
            grvCategory.DataSource = CategoryEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
            grvCategory.DataBind();
        }
    }
}