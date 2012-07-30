using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.Business;

public partial class adminx_ucFaqCategory : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!PermissionBRL.CheckPermission("QuanlychuyenmucFAQ")) Response.End();
            napGridView();
        }
        if (Request.QueryString["do"] != null)
        {

        }
    }

    private void napGridView()
    {
        List<FaqEntity> list = FaqBRL.GetAll();
        grvFaqCategory.DataSource = FaqEntity.Sort(list, "sCateName", "DESC");
        grvFaqCategory.DataKeyNames = new string[] { "PK_iFaqCateID" };
        grvFaqCategory.DataBind();
    }

    protected void btnSearchByID_Click(object sender, EventArgs e)
    {

    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {

    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {

    }
    protected void grvFaqCategory_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int PK_iFaqCateID = Convert.ToInt32(grvFaqCategory.DataKeys[e.NewSelectedIndex].Values["PK_iFaqCateID"]);
        Session["PK_iFaqCateID"] = PK_iFaqCateID.ToString(); ;
        Response.Redirect("~/adminx/Default.aspx?page=FaqCategory");
    }
}