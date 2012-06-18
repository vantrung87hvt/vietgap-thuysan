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
using INVI.Entity;
using INVI.Business;

public partial class uc_ucTinh : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblThongbao.Text = "";
        if (!IsPostBack)
        {
            napgrvMucdo();
        }
    }

    private void napgrvMucdo()
    {
        List<MucdoEntity> lstMucdo = MucdoBRL.GetAll();
        grvMucdo.DataSource = MucdoEntity.Sort(lstMucdo, "sTenmucdo", "ASC");
        grvMucdo.DataKeyNames = new string[] { "PK_iMucdoID" };
        grvMucdo.DataBind();
    }

    protected void napForm(int PK_iMucdoID)
    {
        MucdoEntity Mucdo = MucdoBRL.GetOne(PK_iMucdoID);
        if (Mucdo != null)
        {            
            txtTenmucdo.Text = Mucdo.sTenmucdo;
        }

    }

    protected void grvMucdo_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<MucdoEntity> listMucdo = MucdoBRL.GetAll();
        grvMucdo.DataSource = MucdoEntity.Sort(listMucdo, e.SortExpression, ViewState["SortDirection"].ToString());
        grvMucdo.DataBind();
    }

    protected void grvMucdo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvMucdo.PageIndex = e.NewPageIndex;
        napgrvMucdo();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        btnOK.CommandName = "Add";
        btnOK.Text = "Thêm";
        pnAdd.Visible = true;
        reset();
    }

    protected void grvMucdo_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int MucdoID = Convert.ToInt32(grvMucdo.DataKeys[e.NewSelectedIndex].Values["PK_iMucdoID"]);
        btnOK.CommandName = "Edit";
        btnOK.Text = "Sửa";
        btnOK.CommandArgument = MucdoID.ToString();
        btnOK.CausesValidation = false;
        pnAdd.Visible = true;
        napForm(MucdoID);
    }


    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {

                foreach (GridViewRow row in grvMucdo.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int MucdoID = Convert.ToInt32(grvMucdo.DataKeys[row.RowIndex].Values["PK_iMucdoID"]);
                    if (chkDelete != null && chkDelete.Checked)
                        MucdoBRL.Remove(MucdoID);
                }
                napgrvMucdo();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=MucdoManager';</script>");
            }
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        reset();
        btnOK.CommandName = "Add";
        pnAdd.Visible = false;
    }

    protected void reset()
    {
        txtTenmucdo.Text = "";
    }
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearchByID.Text;
        int MucdoID = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            MucdoID = 0;
        else MucdoID = Int16.Parse(txtID.Text);
        List<MucdoEntity> lstMucdo = MucdoBRL.GetAll();
        if (MucdoID == 0)
        {
            lstMucdo = lstMucdo.FindAll(
            delegate(MucdoEntity sMucdo)
            {
                return sMucdo.sTenmucdo.ToUpper().Contains(strSearch.ToUpper());
            }
            );
        }
        else
        {
            lstMucdo = lstMucdo.FindAll(
            delegate(MucdoEntity oMucdo)
            {
                return oMucdo.PK_iMucdoID == MucdoID;
            }
            );
        }
        lblThongbao.Text = "";
        grvMucdo.DataSource = lstMucdo;
        grvMucdo.DataKeyNames = new string[] { "PK_iMucdoID" };
        grvMucdo.DataBind();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napgrvMucdo();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {

                MucdoEntity oMucdo = new MucdoEntity();
                oMucdo.sTenmucdo = txtTenmucdo.Text;
                if (btnOK.CommandName == "Edit")
                {
                    int MucdoID = Convert.ToInt32(btnOK.CommandArgument);
                    oMucdo.PK_iMucdoID = MucdoID;
                    MucdoBRL.Edit(oMucdo);
                    btnOK.CausesValidation = true;
                    lblThongbao.Text = "Cập nhật thành công";
                }
                else
                {
                    int MucdoID = MucdoBRL.Add(oMucdo);
                    lblThongbao.Text = "Thêm thành công";
                }

                //Nạp lại dữ liệu
                pnAdd.Visible = false;
                napgrvMucdo();       
        
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=MucdoManager';</script>");
            }
        }

    }
}
