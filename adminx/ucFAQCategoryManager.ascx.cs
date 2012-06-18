using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.Business;

public partial class adminx_ucDocumentCategoryManager : System.Web.UI.UserControl
{
     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.napGridView();
        }

        private void napGridView()
        {
            List<CateFaqEntity> list = CateFaqBRL.GetAll();
            grvFAQCategory.DataSource = CateFaqEntity.Sort(list,"PK_iFaqCateID", "DESC");
            grvFAQCategory.DataKeyNames = new string[] { "PK_iFaqCateID" };            
            grvFAQCategory.DataBind();
        }      
        protected void grvFAQCategory_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int docCatID = Convert.ToInt32(grvFAQCategory.DataKeys[e.NewSelectedIndex].Values["PK_iFaqCateID"]);
            Session["PK_iFaqCateID"] = docCatID.ToString(); ;
            Response.Redirect("~/adminx/Default.aspx?page=FAQCategoryUpdate");
        }

        protected void grvFAQCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvFAQCategory.PageIndex = e.NewPageIndex;
            napGridView();
        }
        protected void grvFAQCategory_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null)
                ViewState["SortDirection"] = "ASC";
            else
            {
                ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
            }
            List<CateFaqEntity> list = CateFaqBRL.GetAll();
            grvFAQCategory.DataSource = CateFaqEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
            grvFAQCategory.DataBind();
        }        
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    foreach (GridViewRow row in grvFAQCategory.Rows)
                    {
                        CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                        if (chkDelete != null && chkDelete.Checked)
                        {
                            int faqCatID = Convert.ToInt32(grvFAQCategory.DataKeys[row.RowIndex].Values["PK_iFaqCateID"]);
                            CateFaqBRL.Remove(faqCatID);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=FAQCategoryManager';</script>");
                }
            }

           
        }
        protected void btnSearchByID_Click(object sender, EventArgs e)
        {
            string strSearch = txtSearchByID.Text;
            int faqCatID = 0;
            if (txtID.Text.Length == 0 || txtID.Text == "")
                faqCatID = 0;
            else faqCatID = Int16.Parse(txtID.Text);
            List<CateFaqEntity> lstFAQCat = CateFaqBRL.GetAll();
            if (faqCatID == 0)
            {
                lstFAQCat = lstFAQCat.FindAll(
                delegate(CateFaqEntity oFAQCat)
                {
                    return oFAQCat.sCateName.ToUpper().Contains(strSearch.ToUpper());
                }
                );
            }
            else
            {
                lstFAQCat = lstFAQCat.FindAll(
                delegate(CateFaqEntity oFAQCat)
                {
                    return oFAQCat.PK_iFaqCateID == faqCatID;
                }
                );
            }
            lblThongbao.Text = "";
            grvFAQCategory.DataSource = lstFAQCat;
            grvFAQCategory.DataKeyNames = new string[] { "PK_iFaqCateID" };
            grvFAQCategory.DataBind();
            
        }
        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            napGridView();
        }
      
    }
