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


public partial class uc_ucDoituongnuoi : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            napgrvDotuongnuoi();
        }
    }

    private void napgrvDotuongnuoi()
    {
        List<DoituongnuoiEntity> listDoituongnuoi = DoituongnuoiBRL.GetAll();
        grvDoituongnuoi.DataSource = DoituongnuoiEntity.Sort(listDoituongnuoi, "sTendoituong", "ASC");
        grvDoituongnuoi.DataKeyNames = new string[] { "PK_iDoituongnuoiID" };
        grvDoituongnuoi.DataBind();
    }

    protected void napForm(int DoituongnuoiID)
    {
        DoituongnuoiEntity DoituongnuoiE = DoituongnuoiBRL.GetOne(DoituongnuoiID);
        if (DoituongnuoiE != null)
        {
            Session["ID"] = DoituongnuoiID;
            txtTendoituong.Text = DoituongnuoiE.sTendoituong;
        }

    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        if (pnAdd.Visible == false)
            pnAdd.Visible = true;
        reset();
        btnInsert.Visible = true;
        btnUpdate.Visible = false;
        txtTendoituong.Focus();
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        try
        {
            DoituongnuoiEntity dtn = new DoituongnuoiEntity();
            dtn.sTendoituong = txtTendoituong.Text;
            DoituongnuoiBRL.Add(dtn);
            reset();
            napgrvDotuongnuoi();
            Response.Write("<script>alert('Đăng ký thành công!');</script>");
        }
        catch (Exception ex) { }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            DoituongnuoiEntity dtn = new DoituongnuoiEntity();
            dtn.PK_iDoituongnuoiID = Int16.Parse(Session["ID"].ToString());
            dtn.sTendoituong = txtTendoituong.Text;
            DoituongnuoiBRL.Edit(dtn);
            Response.Write("<script>alert('Cập nhật thành công!');</script>");
            napgrvDotuongnuoi();
            reset();
        }
        catch (Exception ex) { }
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvDoituongnuoi.Rows)
        {
            CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
            int doituongnuoiID = Convert.ToInt32(grvDoituongnuoi.DataKeys[row.RowIndex].Values["PK_iDoituongnuoiID"]);
            if (chkDelete != null && chkDelete.Checked)
                DoituongnuoiBRL.Remove(doituongnuoiID);
        }
        napgrvDotuongnuoi();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        reset();
    }

    protected void reset()
    {
        txtTendoituong.Text = "";
    }

    protected void grvDoituongnuoi_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int doituongnuoiID = Convert.ToInt32(grvDoituongnuoi.DataKeys[e.NewSelectedIndex].Values["PK_iDoituongnuoiID"]);
        pnAdd.Visible = true;
        btnInsert.Visible = false;
        btnUpdate.Visible = true;
        napForm(doituongnuoiID);
    }

    protected void grvDoituongnuoi_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<DoituongnuoiEntity> listDoituongnuoi = DoituongnuoiBRL.GetAll();
        grvDoituongnuoi.DataSource = DoituongnuoiEntity.Sort(listDoituongnuoi, e.SortExpression, ViewState["SortDirection"].ToString());
        grvDoituongnuoi.DataBind();
    }

    protected void grvDoituongnuoi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvDoituongnuoi.PageIndex = e.NewPageIndex;
        napgrvDotuongnuoi();
    }
}

