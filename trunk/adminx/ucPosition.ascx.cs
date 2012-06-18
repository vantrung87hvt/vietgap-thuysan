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

public partial class adminx_ucPosition : System.Web.UI.UserControl
{
    private string sName = String.Empty;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.napGridView();
            ddlPosition_loadData();
            
        }
    }
    private void ddlPosition_loadData()
    {
        ddlPositionID.Items.Clear();
        List<PositionEntity> lstPosition = PositionBRL.GetAll();
        foreach (PositionEntity oPos in lstPosition)
        {
            ListItem item = (new ListItem(oPos.iPositionID.ToString(),oPos.iPositionID.ToString()));

            ddlPositionID.Items.Add(item);

        }//foreach
        ddlPositionID.SelectedIndex = 0;
    }
    private void napGridView()
    {
        grvPosition.DataSource = PositionBRL.GetAll();
        grvPosition.DataKeyNames = new string[] { "iPositionID" };
        grvPosition.DataBind();
    }
    protected void ddlPositionID_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iPositionID = Int16.Parse(ddlPositionID.SelectedItem.Value);
        txtPosName.Enabled = true;
        PositionEntity oPos = PositionBRL.GetOne(iPositionID);
        txtPosName.Text = oPos.sName;
        btnOK.CommandName = "Edit";
        btnOK.Text = Resources.language.luu;
        
    }
    
    protected void grvPosition_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
       int iPositionID = Convert.ToInt32(grvPosition.DataKeys[e.NewSelectedIndex].Values["iPositionID"]);
       btnOK.CommandName = "Edit";
       
       btnOK.Text = Resources.language.luu; 
       napForm(iPositionID);
       
    }
    private void napForm(int iPositionID)
    {
        PositionEntity oPos = PositionBRL.GetOne(iPositionID);
        if (oPos != null)
        {
            txtPosName.Text = oPos.sName;
            txtPosName.Enabled = true;
            sName = oPos.sName;
            ddlPositionID.ClearSelection();
            ddlPositionID.Items.FindByValue(oPos.iPositionID.ToString()).Selected = true;
            napGridView();
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        
            if (btnOK.Text.CompareTo(Resources.language.them) == 0)
            {
                txtPosName.Enabled = true;
                txtPosName.Text = "";
                btnOK.Text = Resources.language.luu;
                btnOK.CommandName = "Add";
                
            }
            else
            {
                Page.Validate("vgPosition");
                if (Page.IsValid)
                {
                    int result = 0;
                try
                {
                    PositionEntity oPos = new PositionEntity();
                    oPos.sName = txtPosName.Text;
                    oPos.iPositionID = Convert.ToInt32(ddlPositionID.SelectedValue);
                    if (btnOK.CommandName=="Edit")
                    {

                        PositionBRL.Edit(oPos);
                        lblThongbao.Text = Resources.language.capnhapthanhcong;
                        txtPosName.Enabled = false;

                    }
                    else
                        result=PositionBRL.Add(oPos);
                    Response.Redirect(Request.Url.ToString());
                }
                catch (Exception ex)
                {
                    lblThongbao.Text = ex.Message;
                }
                if (result > 0) lblThongbao.Text = Resources.language.dathemmoivitriquangcao;
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtPosName.Text = sName;
        btnOK.Text = Resources.language.them;
        ddlPositionID.SelectedIndex = 0;
        
    }
    protected void grvPosition_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<PositionEntity> list = PositionBRL.GetAll();
        grvPosition.DataSource = PositionEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
        grvPosition.DataBind();
    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {

                foreach (GridViewRow row in grvPosition.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int positionID = Convert.ToInt32(grvPosition.DataKeys[row.RowIndex].Values["iPositionID"]);
                    if (chkDelete != null && chkDelete.Checked)
                    {
                        PositionEntity oPos = new PositionEntity();
                        oPos.iPositionID = positionID;
                        PositionBRL.Remove(oPos);
                    }
                }
                //Nap lai du lieu
                Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ex)
            {
                lblThongbao.Text = ex.Message;
            }
        }

    }
}
