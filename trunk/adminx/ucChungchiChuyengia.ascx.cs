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


public partial class adminx_Tochucchungnhan_ucChungchiChuyengia : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            napGridView();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    
    protected void lbtnAddnew_Click(object sender, EventArgs e)
    {

    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {

    }
    protected void grvChungchi_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grvChungchi_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    private void napForm(short PK_iChungchiID)
    {
        ChungchiEntity oChungchi = ChungchiBRL.GetOne(PK_iChungchiID);
        if (oChungchi != null)
        {
            txtChungchi.Text = oChungchi.sTenChungchi;
            napGridView();
        }
    }
    private void napGridView()
    {
        grvChungchi.DataSource = ChungchiBRL.GetAll();
        grvChungchi.DataKeyNames = new string[] { "PK_iChungchiID" };
        grvChungchi.DataBind();
    }
}