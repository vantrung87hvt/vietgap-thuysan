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

public partial class adminx_ucQuanHuyenManager : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblThongbao.Text = "";
        if (!IsPostBack)
        {
            LoadDropDownList();
            napgrvQuanHuyen();
        }
    }
    private void LoadDropDownList()
    {     
        ddlTinh.DataValueField = "PK_iTinhID";
        ddlTinh.DataTextField = "sTenTinh";
        ddlTinh.DataSource = TinhBRL.GetAll();
        ddlTinh.DataBind();

    }
    private void napgrvQuanHuyen()
    {
        List<QuanHuyenEntity> lstQuanHuyen = QuanHuyenBRL.GetAll();
        grvQuanHuyen.DataSource = QuanHuyenEntity.Sort(lstQuanHuyen, "sTen", "ASC");
        grvQuanHuyen.DataKeyNames = new string[] { "PK_iQuanHuyenID" };
        grvQuanHuyen.DataBind();
    }

    protected void napForm(int QuanHuyenID)
    {
        QuanHuyenEntity QuanHuyen = QuanHuyenBRL.GetOne(QuanHuyenID);
        if (QuanHuyen != null)
        {
            txtTen.Text = QuanHuyen.sTen;
            txtKyTu.Text = QuanHuyen.sKytuviettat;
            cbQuan.Checked = QuanHuyen.bQuanHuyen;            
            ddlTinh.SelectedValue = QuanHuyen.FK_iTinhThanhID.ToString();
        }

    }

    protected void grvQuanHuyen_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<QuanHuyenEntity> listQuanHuyen = QuanHuyenBRL.GetAll();
        grvQuanHuyen.DataSource = QuanHuyenEntity.Sort(listQuanHuyen, e.SortExpression, ViewState["SortDirection"].ToString());
        grvQuanHuyen.DataBind();
    }

    protected void grvQuanHuyen_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvQuanHuyen.PageIndex = e.NewPageIndex;
        napgrvQuanHuyen();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        btnOK.CommandName = "Add";
        pnAdd.Visible = true;
        btnOK.Text = "Thêm";
        reset();
    }

    protected void grvQuanHuyen_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int QuanHuyenID = Convert.ToInt32(grvQuanHuyen.DataKeys[e.NewSelectedIndex].Values["PK_iQuanHuyenID"]);
        btnOK.CommandName = "Edit";
        btnOK.Text = "Sửa";
        btnOK.CommandArgument = QuanHuyenID.ToString();
        btnOK.CausesValidation = false;
        pnAdd.Visible = true;
        napForm(QuanHuyenID);
    }


    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{
            try
            {
                foreach (GridViewRow row in grvQuanHuyen.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int QuanHuyenID = Convert.ToInt32(grvQuanHuyen.DataKeys[row.RowIndex].Values["PK_iQuanHuyenID"]);
                    if (chkDelete != null && chkDelete.Checked)
                        QuanHuyenBRL.Remove(QuanHuyenID);
                }
                napgrvQuanHuyen();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=QuanHuyenManager';</script>");
            }
        //}
       
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
        txtKyTu.Text = "";
        cbQuan.Checked = false;
        ddlTinh.SelectedIndex = 0;
    }
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearchByID.Text;
        int QuanHuyenID = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            QuanHuyenID = 0;
        else QuanHuyenID = Int16.Parse(txtID.Text);
        List<QuanHuyenEntity> lstQuanHuyen = QuanHuyenBRL.GetAll();
        if (QuanHuyenID == 0)
        {
            lstQuanHuyen = lstQuanHuyen.FindAll(
            delegate(QuanHuyenEntity oQuanHuyen)
            {
                return oQuanHuyen.sTen.ToUpper().Contains(strSearch.ToUpper()) || oQuanHuyen.sKytuviettat.ToUpper().Contains(strSearch.ToUpper());
            }
            );
        }
        else
        {
            lstQuanHuyen = lstQuanHuyen.FindAll(
            delegate(QuanHuyenEntity oCQuanHuyen)
            {
                return oCQuanHuyen.PK_iQuanHuyenID == QuanHuyenID;
            }
            );
        }
        lblThongbao.Text = "";
        grvQuanHuyen.DataSource = lstQuanHuyen;
        grvQuanHuyen.DataKeyNames = new string[] { "PK_iQuanHuyenID" };
        grvQuanHuyen.DataBind();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napgrvQuanHuyen();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{
            try
            {

                QuanHuyenEntity oQuanHuyen = new QuanHuyenEntity();
                oQuanHuyen.sTen = txtTen.Text;
                oQuanHuyen.sKytuviettat = txtKyTu.Text;
                oQuanHuyen.bQuanHuyen = cbQuan.Checked;
                oQuanHuyen.FK_iTinhThanhID = Convert.ToInt16(ddlTinh.SelectedValue);
                if (btnOK.CommandName == "Edit")
                {
                    int QuanHuyenID = Convert.ToInt32(btnOK.CommandArgument);
                    oQuanHuyen.PK_iQuanHuyenID = QuanHuyenID;
                    QuanHuyenBRL.Edit(oQuanHuyen);
                    btnOK.CausesValidation = true;
                    lblThongbao.Text = "Cập nhật thành công";
                }
                else
                {
                    int QuanHuyenAddID = QuanHuyenBRL.Add(oQuanHuyen);
                    lblThongbao.Text = "Thêm thành công";
                }

                //Nạp lại dữ liệu
                pnAdd.Visible = false;
                napgrvQuanHuyen();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=QuanHuyenManager';</script>");
            }
        //}


    }
}
