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
        if (!IsPostBack)
        {
            napgrvTinh();
        }
    }

    private void napgrvTinh()
    {
        List<TinhEntity> listTinh = TinhBRL.GetAll();
        grvTinh.DataSource = TinhEntity.Sort(listTinh, "sTentinh", "ASC");
        grvTinh.DataKeyNames = new string[] { "PK_iTinhID" };
        grvTinh.DataBind();
    }

    protected void napForm(Int16 TinhID)
    {
        TinhEntity TinhE = TinhBRL.GetOne(TinhID);
        if (TinhE != null)
        {
            Session["ID"] = TinhID;
            txtTentinh.Text = TinhE.sTentinh;
            txtKyhieu.Text = TinhE.sKyhieu;
        }

    }

    protected void grvTinh_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<TinhEntity> listTinh = TinhBRL.GetAll();
        grvTinh.DataSource = TinhEntity.Sort(listTinh, e.SortExpression, ViewState["SortDirection"].ToString());
        grvTinh.DataBind();
    }

    protected void grvTinh_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTinh.PageIndex = e.NewPageIndex;
        napgrvTinh();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        if (pnAdd.Visible == false)
            pnAdd.Visible = true;
        reset();
        btnInsert.Visible = true;
        btnUpdate.Visible = false;
        txtTentinh.Focus();
    }

    protected void grvTinh_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        Int16 TinhID = Convert.ToInt16(grvTinh.DataKeys[e.NewSelectedIndex].Values["PK_iTinhID"]);
        pnAdd.Visible = true;
        btnInsert.Visible = false;
        btnUpdate.Visible = true;
        napForm(TinhID);
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        TinhEntity te = new TinhEntity();
        te.sTentinh = txtTentinh.Text;
        te.sKyhieu = txtKyhieu.Text;
        TinhBRL.Add(te);
        reset();
        napgrvTinh();
        Response.Write("<script>alert('Đăng ký thành công!');</script>");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        TinhEntity t = new TinhEntity();
        t.PK_iTinhID = Int16.Parse(Session["ID"].ToString());
        t.sTentinh = txtTentinh.Text;
        t.sKyhieu = txtKyhieu.Text;
        TinhBRL.Edit(t);
        Response.Write("<script>alert('Cập nhật thành công!');</script>");
        napgrvTinh();
        reset();
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvTinh.Rows)
        {
            CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
            Int16 tinhID = Convert.ToInt16(grvTinh.DataKeys[row.RowIndex].Values["PK_iTinhID"]);
            if (chkDelete != null && chkDelete.Checked)
                TinhBRL.Remove(tinhID);
        }
        napgrvTinh();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        reset();
    }

    protected void reset()
    {
        txtTentinh.Text = "";
        txtKyhieu.Text = "";
    }
}
