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
            napgrvChucVu();
        }
    }

    private void napgrvChucVu()
    {
        List<ChucVuEntity> lstChucVu = ChucVuBRL.GetAll();
        grvChucVu.DataSource = ChucVuEntity.Sort(lstChucVu, "sTenChucVu", "ASC");
        grvChucVu.DataKeyNames = new string[] { "PK_iChucVuID" };
        grvChucVu.DataBind();
    }

    protected void napForm(int chucvuID)
    {
        ChucVuEntity chucVu = ChucVuBRL.GetOne(chucvuID);
        if (chucVu != null)
        {            
            txtTenChucVu.Text = chucVu.sTenChucVu;
            txtCongViecPhuTrach.Text = chucVu.sCongviecphutrach;
        }

    }

    protected void grvChucVu_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<ChucVuEntity> listChucVu = ChucVuBRL.GetAll();
        grvChucVu.DataSource = ChucVuEntity.Sort(listChucVu, e.SortExpression, ViewState["SortDirection"].ToString());
        grvChucVu.DataBind();
    }

    protected void grvChucVu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvChucVu.PageIndex = e.NewPageIndex;
        napgrvChucVu();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        btnOK.CommandName = "Add";
        btnOK.Text = "Thêm";
        pnAdd.Visible = true;
        reset();
    }

    protected void grvChucVu_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int ChucVuID = Convert.ToInt32(grvChucVu.DataKeys[e.NewSelectedIndex].Values["PK_iChucVuID"]);
        btnOK.CommandName = "Edit";
        btnOK.Text = "Sửa";
        btnOK.CommandArgument = ChucVuID.ToString();
        btnOK.CausesValidation = false;
        pnAdd.Visible = true;
        napForm(ChucVuID);
    }

   
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
            try
            {
                foreach (GridViewRow row in grvChucVu.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    Int16 chucvuID = Convert.ToInt16(grvChucVu.DataKeys[row.RowIndex].Values["PK_iChucVuID"]);
                    if (chkDelete != null && chkDelete.Checked)
                        ChucVuBRL.Remove(chucvuID);
                }
                napgrvChucVu();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=ChucVuManager';</script>");
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
        txtTenChucVu.Text = "";
        txtCongViecPhuTrach.Text = "";        
    }
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearchByID.Text;
        int ChucVuID = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            ChucVuID = 0;
        else ChucVuID = Int16.Parse(txtID.Text);
        List<ChucVuEntity> lstChucVu = ChucVuBRL.GetAll();
        if (ChucVuID == 0)
        {
            lstChucVu = lstChucVu.FindAll(
            delegate(ChucVuEntity oChucVu)
            {
                return oChucVu.sTenChucVu.ToUpper().Contains(strSearch.ToUpper()) || oChucVu.sCongviecphutrach.ToUpper().Contains(strSearch.ToUpper());
            }
            );
        }
        else
        {
            lstChucVu = lstChucVu.FindAll(
            delegate(ChucVuEntity oCChucVu)
            {
                return oCChucVu.PK_iChucVuID == ChucVuID;
            }
            );
        }
        lblThongbao.Text = "";
        grvChucVu.DataSource = lstChucVu;
        grvChucVu.DataKeyNames = new string[] { "PK_iChucVuID" };
        grvChucVu.DataBind();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napgrvChucVu();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
            try
            {
                ChucVuEntity oChucVu = new ChucVuEntity();
                oChucVu.sTenChucVu = txtTenChucVu.Text;
                oChucVu.sCongviecphutrach = txtCongViecPhuTrach.Text;
                if (btnOK.CommandName == "Edit")
                {
                    int ChucVuID = Convert.ToInt32(btnOK.CommandArgument);
                    oChucVu.PK_iChucVuID = ChucVuID;
                    ChucVuBRL.Edit(oChucVu);
                    btnOK.CausesValidation = true;
                    lblThongbao.Text = "Cập nhật thành công";
                }
                else
                {
                    int ChucVuAddID = ChucVuBRL.Add(oChucVu);
                    lblThongbao.Text = "Thêm thành công";
                }

                //Nạp lại dữ liệu
                pnAdd.Visible = false;
                napgrvChucVu();       
        
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=ChucVuManager';</script>");
            }
    }
}
