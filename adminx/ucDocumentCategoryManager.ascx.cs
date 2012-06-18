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
            List<LoaivanbanEntity> list = LoaivanbanBRL.GetAll();
            grvDocCategory.DataSource = LoaivanbanEntity.Sort(list,"PK_iLoaivanbanID", "DESC");
            grvDocCategory.DataKeyNames = new string[] { "PK_iLoaivanbanID" };            
            grvDocCategory.DataBind();
        }      
        protected void grvDocCategory_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int docCatID = Convert.ToInt32(grvDocCategory.DataKeys[e.NewSelectedIndex].Values["PK_iLoaivanbanID"]);
            Session["PK_iLoaivanbanID"] = docCatID.ToString(); ;
            Response.Redirect("~/adminx/Default.aspx?page=DocumentCategoryUpdate");
        }

        protected void grvDocCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvDocCategory.PageIndex = e.NewPageIndex;
            napGridView();
        }
        protected void grvDocCategory_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null)
                ViewState["SortDirection"] = "ASC";
            else
            {
                ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
            }
            List<LoaivanbanEntity> list = LoaivanbanBRL.GetAll();
            grvDocCategory.DataSource = LoaivanbanEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
            grvDocCategory.DataBind();
        }        
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    foreach (GridViewRow row in grvDocCategory.Rows)
                    {
                        CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                        if (chkDelete != null && chkDelete.Checked)
                        {
                            int docCatID = Convert.ToInt32(grvDocCategory.DataKeys[row.RowIndex].Values["PK_iLoaivanbanID"]);
                            LoaivanbanBRL.Remove(docCatID);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=DocumentCategoryManager';</script>");
                }
            }

        }
        protected void btnSearchByID_Click(object sender, EventArgs e)
        {
            string strSearch = txtSearchByID.Text;
            int iDocCatID = 0;
            if (txtID.Text.Length == 0 || txtID.Text == "")
                iDocCatID = 0;
            else iDocCatID = Int16.Parse(txtID.Text);
            List<LoaivanbanEntity> lstDocCat = LoaivanbanBRL.GetAll();
            if (iDocCatID == 0)
            {
                lstDocCat = lstDocCat.FindAll(
                delegate(LoaivanbanEntity oDocCat)
                {
                    return oDocCat.sTenloai.ToUpper().Contains(strSearch.ToUpper());
                }
                );
            }
            else
            {
                lstDocCat = lstDocCat.FindAll(
                delegate(LoaivanbanEntity oDocCat)
                {
                    return oDocCat.PK_iLoaivanbanID == iDocCatID;
                }
                );
            }
            lblThongbao.Text = "";
            grvDocCategory.DataSource = lstDocCat;
            grvDocCategory.DataKeyNames = new string[] { "PK_iLoaivanbanID" };
            grvDocCategory.DataBind();
            
        }
        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            napGridView();
        }
      
    }
