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

public partial class adminx_ucTinhMa : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblThongbao.Text = "";
        if (!IsPostBack)
        {
            napgrvTinh();
        }
    }    
    private void napgrvTinh()
    {
        List<TinhEntity> lstTinh = TinhBRL.GetAll();
        grvTinh.DataSource = TinhEntity.Sort(lstTinh, "sTentinh", "ASC");
        grvTinh.DataKeyNames = new string[] { "PK_iTinhID" };
        grvTinh.DataBind();
    }

    protected void napForm(short TinhID)
    {
        TinhEntity Tinh = TinhBRL.GetOne(TinhID);
        if (Tinh != null)
        {
            txtTen.Text = Tinh.sTentinh;
            txtKyHieu.Text = Tinh.sKyhieu;
            txtISO31662.Text = Tinh.ISO31662;            
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
        btnOK.CommandName = "Add";
        btnOK.Text = "Thêm";
        pnAdd.Visible = true;
        reset();
    }

    protected void grvTinh_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        short TinhID = Convert.ToInt16(grvTinh.DataKeys[e.NewSelectedIndex].Values["PK_iTinhID"]);
        btnOK.CommandName = "Edit";
        btnOK.Text = "Sửa";
        btnOK.CommandArgument = TinhID.ToString();
        btnOK.CausesValidation = false;
        pnAdd.Visible = true;
        napForm(TinhID);
    }


    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                foreach (GridViewRow row in grvTinh.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    short TinhID = Convert.ToInt16(grvTinh.DataKeys[row.RowIndex].Values["PK_iTinhID"]);
                    if (chkDelete != null && chkDelete.Checked)
                        TinhBRL.Remove(TinhID);
                }
                napgrvTinh();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=TinhManager';</script>");
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
        txtTen.Text = "";
        txtKyHieu.Text = "";
        txtISO31662.Text = "";        
    }
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearchByID.Text;
        short TinhID = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            TinhID = 0;
        else TinhID = Int16.Parse(txtID.Text);
        List<TinhEntity> lstTinh = TinhBRL.GetAll();
        if (TinhID == 0)
        {
            lstTinh = lstTinh.FindAll(
            delegate(TinhEntity oTinh)
            {
                return oTinh.sTentinh.ToUpper().Contains(strSearch.ToUpper()) || oTinh.sKyhieu.ToUpper().Contains(strSearch.ToUpper());
            }
            );
        }
        else
        {
            lstTinh = lstTinh.FindAll(
            delegate(TinhEntity oCTinh)
            {
                return oCTinh.PK_iTinhID == TinhID;
            }
            );
        }
        lblThongbao.Text = "";
        grvTinh.DataSource = lstTinh;
        grvTinh.DataKeyNames = new string[] { "PK_iTinhID" };
        grvTinh.DataBind();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napgrvTinh();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {

                TinhEntity oTinh = new TinhEntity();
                oTinh.sTentinh = txtTen.Text;
                oTinh.sKyhieu = txtKyHieu.Text;
                oTinh.ISO31662 = txtISO31662.Text;
                if (btnOK.CommandName == "Edit")
                {
                    short TinhID = Convert.ToInt16(btnOK.CommandArgument);
                    oTinh.PK_iTinhID = TinhID;
                    TinhBRL.Edit(oTinh);
                    btnOK.CausesValidation = true;
                    lblThongbao.Text = "Cập nhật thành công";
                }
                else
                {
                    int TinhAddID = TinhBRL.Add(oTinh);
                    lblThongbao.Text = "Thêm thành công";
                }

                //Nạp lại dữ liệu
                pnAdd.Visible = false;
                napgrvTinh();

            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=TinhManager';</script>");
            }
        }

    }
}
