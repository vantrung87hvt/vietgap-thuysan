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
public partial class adminx_ucAdv : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!PermissionBRL.CheckPermission("Dangquangcao")) Response.End();
        if (!IsPostBack)
        {
            this.napGridView();
        }
    }
   
    private void napGridView()
    {
        grvAdv.DataSource = AdvBRL.GetAll();
        grvAdv.DataKeyNames = new string[] { "iAdvID" };
        grvAdv.DataBind();
    }
    protected string getPositionName(Object x)
    {
        int iPositionID = int.Parse(x.ToString());
        String sPositionName = string.Empty;
        PositionEntity oPos = new PositionEntity();
        oPos = PositionBRL.GetOne(iPositionID);
        if (oPos != null)
            sPositionName = oPos.sName;
        return sPositionName;
    }
    protected string getShortOf(Object x)
    {
        if (x.ToString().Length < 10)
            return x.ToString();
        else
            return x.ToString().Substring(0, 10);
    }
    
    
    protected void grvPosition_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int iAdvID = Convert.ToInt32(grvAdv.DataKeys[e.NewSelectedIndex].Values["iAdvID"]);
       
        Session["AdvID"] = iAdvID.ToString(); ;
        Response.Redirect("~/adminx/Default.aspx?page=AdvUpdate");
        /*btnOK.CommandName = "Edit";
        btnOK.CommandArgument = iAdvID.ToString();
        //textBox_enordis(true);
        btnOK.Text = Resources.language.luu;
        
        //bAddnew = false;*/
    }
    protected void grvPosition_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<AdvEntity> list = AdvBRL.GetAll();
        grvAdv.DataSource = AdvEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
        grvAdv.DataBind();

    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                foreach (GridViewRow row in grvAdv.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;

                    if (chkDelete != null && chkDelete.Checked)
                    {
                        int advID = Convert.ToInt32(grvAdv.DataKeys[row.RowIndex].Values["iAdvID"]);
                        AdvEntity oAdv = new AdvEntity();
                        oAdv.iAdvID = advID;
                        AdvBRL.Remove(oAdv);
                    }
                }
                //Nap lai du lieu
                Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=Adv';</script>");
            }
        }
    }
    protected void grvAdv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAdv.PageIndex = e.NewPageIndex;
        napGridView();
    }
   
}
