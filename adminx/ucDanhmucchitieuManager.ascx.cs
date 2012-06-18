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
            napgrvDanhmucchitieu();
        }
    }

    private void napgrvDanhmucchitieu()
    {
        List<DanhmucchitieuEntity> lstDanhmucchitieu = DanhmucchitieuBRL.GetAll();
        grvDanhmucchitieu.DataSource = DanhmucchitieuEntity.Sort(lstDanhmucchitieu, "iThutu", "ASC");
        grvDanhmucchitieu.DataKeyNames = new string[] { "PK_iDanhmucchitieuID" };
        grvDanhmucchitieu.DataBind();
    }

    protected void napForm(int PK_iDanhmucchitieuID)
    {
        DanhmucchitieuEntity DanhMucChiTieu = DanhmucchitieuBRL.GetOne(PK_iDanhmucchitieuID);
        if (DanhMucChiTieu != null)
        {            
            txtTendanhmucchitieu.Text = DanhMucChiTieu.sTenchuyenmuc;
            txtIThutu.Text = DanhMucChiTieu.iThutu.ToString();
        }

    }

    protected void grvDanhmucchitieu_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<DanhmucchitieuEntity> listDanhmucchitieu = DanhmucchitieuBRL.GetAll();
        grvDanhmucchitieu.DataSource = DanhmucchitieuEntity.Sort(listDanhmucchitieu, e.SortExpression, ViewState["SortDirection"].ToString());
        grvDanhmucchitieu.DataBind();
    }

    protected void grvDanhmucchitieu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvDanhmucchitieu.PageIndex = e.NewPageIndex;
        napgrvDanhmucchitieu();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        btnOK.CommandName = "Add";
        btnOK.Text = "Thêm";
        pnAdd.Visible = true;
        reset();
    }

    protected void grvDanhmucchitieu_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int DanhmucchitieuID = Convert.ToInt32(grvDanhmucchitieu.DataKeys[e.NewSelectedIndex].Values["PK_iDanhmucchitieuID"]);
        btnOK.CommandName = "Edit";
        btnOK.Text = "Sửa";
        btnOK.CommandArgument = DanhmucchitieuID.ToString();
        btnOK.CausesValidation = false;
        pnAdd.Visible = true;
        napForm(DanhmucchitieuID);
    }


    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                foreach (GridViewRow row in grvDanhmucchitieu.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int DanhmucchitieuID = Convert.ToInt32(grvDanhmucchitieu.DataKeys[row.RowIndex].Values["PK_iDanhmucchitieuID"]);
                    if (chkDelete != null && chkDelete.Checked)
                        DanhmucchitieuBRL.Remove(DanhmucchitieuID);
                }
                napgrvDanhmucchitieu();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=DanhmucchitieuManager';</script>");
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
        txtTendanhmucchitieu.Text = "";
        txtIThutu.Text = ""; 
    }
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearchByID.Text;
        int DanhmucchitieuID = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            DanhmucchitieuID = 0;
        else DanhmucchitieuID = Int16.Parse(txtID.Text);
        List<DanhmucchitieuEntity> lstDanhmucchitieu = DanhmucchitieuBRL.GetAll();
        if (DanhmucchitieuID == 0)
        {
            lstDanhmucchitieu = lstDanhmucchitieu.FindAll(
            delegate(DanhmucchitieuEntity sDanhmucchitieu)
            {
                return sDanhmucchitieu.sTenchuyenmuc.ToUpper().Contains(strSearch.ToUpper());
            }
            );
        }
        else
        {
            lstDanhmucchitieu = lstDanhmucchitieu.FindAll(
            delegate(DanhmucchitieuEntity oDanhmucchitieu)
            {
                return oDanhmucchitieu.PK_iDanhmucchitieuID == DanhmucchitieuID;
            }
            );
        }
        lblThongbao.Text = "";
        grvDanhmucchitieu.DataSource = lstDanhmucchitieu;
        grvDanhmucchitieu.DataKeyNames = new string[] { "PK_iDanhmucchitieuID" };
        grvDanhmucchitieu.DataBind();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napgrvDanhmucchitieu();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {

                DanhmucchitieuEntity oDanhmucchitieu = new DanhmucchitieuEntity();
                oDanhmucchitieu.sTenchuyenmuc = txtTendanhmucchitieu.Text;
                oDanhmucchitieu.iThutu = Convert.ToInt16(txtIThutu.Text);
                if (btnOK.CommandName == "Edit")
                {
                    int DanhmucchitieuID = Convert.ToInt32(btnOK.CommandArgument);
                    oDanhmucchitieu.PK_iDanhmucchitieuID = DanhmucchitieuID;
                    DanhmucchitieuBRL.Edit(oDanhmucchitieu);
                    btnOK.CausesValidation = true;
                    lblThongbao.Text = "Cập nhật thành công";
                }
                else
                {
                    int DanhmucchitieuAddID = DanhmucchitieuBRL.Add(oDanhmucchitieu);
                    lblThongbao.Text = "Thêm thành công";
                }

                //Nạp lại dữ liệu
                pnAdd.Visible = false;
                napgrvDanhmucchitieu();   
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=DanhmucchitieuManager';</script>");
            }
        }
    
        
    }
}
