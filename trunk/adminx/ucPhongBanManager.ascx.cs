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
            napgrvPhongBan();
        }
    }

    private void napgrvPhongBan()
    {
        List<PhongBanEntity> lstPhongBan = PhongBanBRL.GetAll();
        grvPhongBan.DataSource = PhongBanEntity.Sort(lstPhongBan, "sTenPhong", "ASC");
        grvPhongBan.DataKeyNames = new string[] { "PK_iPhongBanID" };
        grvPhongBan.DataBind();
    }

    protected void napForm(int PhongBanID)
    {
        PhongBanEntity PhongBan = PhongBanBRL.GetOne(PhongBanID);
        if (PhongBan != null)
        {            
            txtTenPhongBan.Text = PhongBan.sTenPhong;
            txtDienThoai.Text = PhongBan.sDienThoai;
            txtFax.Text = PhongBan.sFax;
        }

    }

    protected void grvPhongBan_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<PhongBanEntity> listPhongBan = PhongBanBRL.GetAll();
        grvPhongBan.DataSource = PhongBanEntity.Sort(listPhongBan, e.SortExpression, ViewState["SortDirection"].ToString());
        grvPhongBan.DataBind();
    }

    protected void grvPhongBan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvPhongBan.PageIndex = e.NewPageIndex;
        napgrvPhongBan();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        btnOK.CommandName = "Add";
        btnOK.Text = "Thêm";
        pnAdd.Visible = true;
        reset();
    }

    protected void grvPhongBan_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int PhongBanID = Convert.ToInt32(grvPhongBan.DataKeys[e.NewSelectedIndex].Values["PK_iPhongBanID"]);
        btnOK.CommandName = "Edit";
        btnOK.Text = "Sửa";
        btnOK.CommandArgument = PhongBanID.ToString();
        btnOK.CausesValidation = false;
        pnAdd.Visible = true;
        napForm(PhongBanID);
    }


    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
            try
            {

                foreach (GridViewRow row in grvPhongBan.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int PhongBanID = Convert.ToInt32(grvPhongBan.DataKeys[row.RowIndex].Values["PK_iPhongBanID"]);
                    if (chkDelete != null && chkDelete.Checked)
                        PhongBanBRL.Remove(PhongBanID);
                }
                napgrvPhongBan();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=PhongBanManager';</script>");
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
        txtTenPhongBan.Text = "";
        txtDienThoai.Text = "";
        txtFax.Text = "";    
    }
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearchByID.Text;
        int PhongBanID = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            PhongBanID = 0;
        else PhongBanID = Int16.Parse(txtID.Text);
        List<PhongBanEntity> lstPhongBan = PhongBanBRL.GetAll();
        if (PhongBanID == 0)
        {
            lstPhongBan = lstPhongBan.FindAll(
            delegate(PhongBanEntity oPhongBan)
            {
                return oPhongBan.sTenPhong.ToUpper().Contains(strSearch.ToUpper());
            }
            );
        }
        else
        {
            lstPhongBan = lstPhongBan.FindAll(
            delegate(PhongBanEntity oCPhongBan)
            {
                return oCPhongBan.PK_iPhongBanID == PhongBanID;
            }
            );
        }
        lblThongbao.Text = "";
        grvPhongBan.DataSource = lstPhongBan;
        grvPhongBan.DataKeyNames = new string[] { "PK_iPhongBanID" };
        grvPhongBan.DataBind();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napgrvPhongBan();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
            try
            {

                PhongBanEntity oPhongBan = new PhongBanEntity();
                oPhongBan.sTenPhong = txtTenPhongBan.Text;
                oPhongBan.sDienThoai = txtDienThoai.Text;
                oPhongBan.sFax = txtFax.Text;
                if (btnOK.CommandName == "Edit")
                {
                    int PhongBanID = Convert.ToInt32(btnOK.CommandArgument);
                    oPhongBan.PK_iPhongBanID = PhongBanID;
                    PhongBanBRL.Edit(oPhongBan);
                    btnOK.CausesValidation = true;
                    lblThongbao.Text = "Cập nhật thành công";
                }
                else
                {
                    int PhongBanAddID = PhongBanBRL.Add(oPhongBan);
                    lblThongbao.Text = "Thêm thành công";
                }

                //Nạp lại dữ liệu
                pnAdd.Visible = false;
                napgrvPhongBan();       
        
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=PhongBanManager';</script>");
            }

    }
}
