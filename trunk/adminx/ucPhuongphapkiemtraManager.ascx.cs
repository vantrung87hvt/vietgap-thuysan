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
            napgrvPhuongphapkiemtra();
        }
    }

    private void napgrvPhuongphapkiemtra()
    {
        List<PhuongphapkiemtraEntity> lstPhuongphapkiemtra = PhuongphapkiemtraBRL.GetAll();
        grvPhuongphapkiemtra.DataSource = PhuongphapkiemtraEntity.Sort(lstPhuongphapkiemtra, "sTenphuongphapkiemtra", "ASC");
        grvPhuongphapkiemtra.DataKeyNames = new string[] { "PK_iPhuongphapkiemtraID" };
        grvPhuongphapkiemtra.DataBind();
    }

    protected void napForm(int PK_iPhuongphapkiemtraID)
    {
        PhuongphapkiemtraEntity PhuongPhapKiemTra = PhuongphapkiemtraBRL.GetOne(PK_iPhuongphapkiemtraID);
        if (PhuongPhapKiemTra != null)
        {            
            txtTenphuongphapkiemtra.Text = PhuongPhapKiemTra.sTenphuongphapkiemtra;
            
        }

    }

    protected void grvPhuongphapkiemtra_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<PhuongphapkiemtraEntity> listPhuongPhapKiemTra = PhuongphapkiemtraBRL.GetAll();
        grvPhuongphapkiemtra.DataSource = PhuongphapkiemtraEntity.Sort(listPhuongPhapKiemTra, e.SortExpression, ViewState["SortDirection"].ToString());
        grvPhuongphapkiemtra.DataBind();
    }

    protected void grvPhuongphapkiemtra_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvPhuongphapkiemtra.PageIndex = e.NewPageIndex;
        napgrvPhuongphapkiemtra();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        btnOK.CommandName = "Add";
        btnOK.Text = "Thêm";
        pnAdd.Visible = true;
        reset();
    }

    protected void grvPhuongphapkiemtra_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int PhuongphapkiemtraID = Convert.ToInt32(grvPhuongphapkiemtra.DataKeys[e.NewSelectedIndex].Values["PK_iPhuongphapkiemtraID"]);
        btnOK.CommandName = "Edit";
        btnOK.Text = "Sửa";
        btnOK.CommandArgument = PhuongphapkiemtraID.ToString();
        btnOK.CausesValidation = false;
        pnAdd.Visible = true;
        napForm(PhuongphapkiemtraID);
    }


    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvPhuongphapkiemtra.Rows)
        {
            CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
            int PhuongphapkiemtraID = Convert.ToInt32(grvPhuongphapkiemtra.DataKeys[row.RowIndex].Values["PK_iPhuongphapkiemtraID"]);
            if (chkDelete != null && chkDelete.Checked)
                PhuongphapkiemtraBRL.Remove(PhuongphapkiemtraID);
        }
        napgrvPhuongphapkiemtra();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        reset();
        btnOK.CommandName = "Add";
        pnAdd.Visible = false;
    }

    protected void reset()
    {
        txtTenphuongphapkiemtra.Text = "";
    }
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearchByID.Text;
        int PhuongphapkiemtraID = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            PhuongphapkiemtraID = 0;
        else PhuongphapkiemtraID = Int16.Parse(txtID.Text);
        List<PhuongphapkiemtraEntity> lstPhuongphapkiemtra = PhuongphapkiemtraBRL.GetAll();
        if (PhuongphapkiemtraID == 0)
        {
            lstPhuongphapkiemtra = lstPhuongphapkiemtra.FindAll(
            delegate(PhuongphapkiemtraEntity sPhuongphapkiemtra)
            {
                return sPhuongphapkiemtra.sTenphuongphapkiemtra.ToUpper().Contains(strSearch.ToUpper());
            }
            );
        }
        else
        {
            lstPhuongphapkiemtra = lstPhuongphapkiemtra.FindAll(
            delegate(PhuongphapkiemtraEntity oPhuongphapkiemtra)
            {
                return oPhuongphapkiemtra.PK_iPhuongphapkiemtraID == PhuongphapkiemtraID;
            }
            );
        }
        lblThongbao.Text = "";
        grvPhuongphapkiemtra.DataSource = lstPhuongphapkiemtra;
        grvPhuongphapkiemtra.DataKeyNames = new string[] { "PK_iPhuongphapkiemtraID" };
        grvPhuongphapkiemtra.DataBind();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napgrvPhuongphapkiemtra();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {        
        PhuongphapkiemtraEntity oPhuongphapkiemtra = new PhuongphapkiemtraEntity();
        oPhuongphapkiemtra.sTenphuongphapkiemtra = txtTenphuongphapkiemtra.Text;
        if (btnOK.CommandName == "Edit")
        {
            int PhuongphapkiemtraID = Convert.ToInt32(btnOK.CommandArgument);            
            oPhuongphapkiemtra.PK_iPhuongphapkiemtraID = PhuongphapkiemtraID;            
            PhuongphapkiemtraBRL.Edit(oPhuongphapkiemtra);            
            btnOK.CausesValidation = true;
            lblThongbao.Text = "Cập nhật thành công";
        }
        else
        {
            int PhuongphapkiemtraID = PhuongphapkiemtraBRL.Add(oPhuongphapkiemtra);
            lblThongbao.Text = "Thêm thành công";
        }
        
        //Nạp lại dữ liệu
        pnAdd.Visible = false;
        napgrvPhuongphapkiemtra();       
        
    }
    
}
