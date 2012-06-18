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

    int PK_iUserID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            PK_iUserID = int.Parse(Session["UserID"].ToString());
        }
        lblThongbao.Text = "";
        if (!IsPostBack)
        {
            napgrvDanhgiavien();
            
        }
    }

    private void napgrvDanhgiavien()
    {
        if (Session["GroupID"].ToString() != "4") { 
            Response.Write("<script language=\"javascript\">alert('Bạn không phải Tổ chức chứng nhận, nên bạn không có quyền sử dụng chức năng này.');location='Default.aspx';</script>");
            return;
        }
        if (Session["UserID"] != null) PK_iUserID = Convert.ToInt32(Session["UserID"].ToString());
        List<TochucchungnhanTaikhoanEntity> lstTochucTaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(PK_iUserID);
        if (lstTochucTaikhoan.Count == 0)
        {
            Response.Write("<script>alert('Tài khoản này không liên quan đến bất cứ TCCN nào.');</script>");
            return;
        }
        List<DanhgiavienEntity> lstDanhgiavien = DanhgiavienBRL.GetByFK_iTochucchungnhanID(lstTochucTaikhoan[0].FK_iTochucchungnhanID);
        grvDanhgiavien.DataSource = DanhgiavienEntity.Sort(lstDanhgiavien, "sHoten", "ASC");
        grvDanhgiavien.DataKeyNames = new string[] { "PK_iDanhgiavienID" };
        grvDanhgiavien.DataBind();
    }

    public String BoolToString(bool f)
    {
        if (f)
            return "Có";
        else
            return "Không";
    }

    protected void napForm(int PK_iHosokemtheoID)
    {
        DanhgiavienEntity Danhgiavien = DanhgiavienBRL.GetOne(PK_iHosokemtheoID);
        if (Danhgiavien != null)
        {            
            txtHoten.Text = Danhgiavien.sHoten;
            txtTrinhdo.Text = Danhgiavien.sTrinhdo;
            txtSonamkinhnghiem.Text = Danhgiavien.iNamkinhnghiem.ToString();
            chkTCVN.Checked = Danhgiavien.bTCVN190112003;
            chkISO.Checked = Danhgiavien.bISO190112002;
            chkVietGAP.Checked = Danhgiavien.bVietGapCer;
            chkDuyet.Checked = Danhgiavien.bDuyet;
        }

    }

    protected void grvDanhgiavien_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<DanhgiavienEntity> lstDanhgiavien = DanhgiavienBRL.GetAll();
        grvDanhgiavien.DataSource = DanhgiavienEntity.Sort(lstDanhgiavien, e.SortExpression, ViewState["SortDirection"].ToString());
        grvDanhgiavien.DataBind();
    }

    protected void grvDanhgiavien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvDanhgiavien.PageIndex = e.NewPageIndex;
        napgrvDanhgiavien();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        btnOK.CommandName = "Add";
        btnOK.Text = "Thêm";
        pnAdd.Visible = true;
        reset();
    }

    protected void grvDanhgiavien_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int DanhgiavienID = Convert.ToInt32(grvDanhgiavien.DataKeys[e.NewSelectedIndex].Values["PK_iDanhgiavienID"]);
        btnOK.CommandName = "Edit";
        btnOK.Text = "Sửa";
        btnOK.CommandArgument = DanhgiavienID.ToString();
        btnOK.CausesValidation = false;
        pnAdd.Visible = true;
        napForm(DanhgiavienID);
    }


    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                foreach (GridViewRow row in grvDanhgiavien.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int DanhgiavienID = Convert.ToInt32(grvDanhgiavien.DataKeys[row.RowIndex].Values["PK_iDanhgiavienID"]);
                    if (chkDelete != null && chkDelete.Checked)
                        DanhgiavienBRL.Remove(DanhgiavienID);
                }
                napgrvDanhgiavien();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=DanhgiavienManager';</script>");
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
        txtHoten.Text = "";
        txtTrinhdo.Text = "";
        txtSonamkinhnghiem.Text = "";
        chkTCVN.Checked = false;
        chkISO.Checked = false;
        chkVietGAP.Checked = false;
    }
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearchByID.Text;
        int DanhgiavienID = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            DanhgiavienID = 0;
        else DanhgiavienID = Int16.Parse(txtID.Text);
        List<DanhgiavienEntity> lstDanhgiavien = DanhgiavienBRL.GetAll();
        if (DanhgiavienID == 0)
        {
            lstDanhgiavien = lstDanhgiavien.FindAll(
            delegate(DanhgiavienEntity sDanhgiavien)
            {
                return sDanhgiavien.sHoten.ToUpper().Contains(strSearch.ToUpper());
            }
            );
        }
        else
        {
            lstDanhgiavien = lstDanhgiavien.FindAll(
            delegate(DanhgiavienEntity oDanhgiavien)
            {
                return oDanhgiavien.PK_iDanhgiavienID == DanhgiavienID;
            }
            );
        }
        lblThongbao.Text = "";
        grvDanhgiavien.DataSource = lstDanhgiavien;
        grvDanhgiavien.DataKeyNames = new string[] { "PK_iDanhgiavienID" };
        grvDanhgiavien.DataBind();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napgrvDanhgiavien();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{
            try
            {
                TochucchungnhanEntity oTochuc = null;
                if (Session["UserID"] != null)
                    PK_iUserID = int.Parse(Session["UserID"].ToString());
                List<TochucchungnhanTaikhoanEntity> lstTochucTaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(PK_iUserID);

                if (lstTochucTaikhoan.Count > 0)
                    oTochuc = TochucchungnhanBRL.GetOne(lstTochucTaikhoan[0].FK_iTochucchungnhanID);
                DanhgiavienEntity oDanhgiavien = new DanhgiavienEntity();
                oDanhgiavien.sHoten = txtHoten.Text;
                oDanhgiavien.FK_iTochucchungnhanID = oTochuc.PK_iTochucchungnhanID;
                oDanhgiavien.sTrinhdo = txtTrinhdo.Text;
                oDanhgiavien.iNamkinhnghiem = short.Parse(txtSonamkinhnghiem.Text);
                oDanhgiavien.bTCVN190112003 = chkTCVN.Checked;
                oDanhgiavien.bISO190112002 = chkISO.Checked;
                oDanhgiavien.bVietGapCer = chkVietGAP.Checked;
                if (btnOK.CommandName == "Edit")
                {
                    int DanhgiavienID = Convert.ToInt32(btnOK.CommandArgument);
                    oDanhgiavien.PK_iDanhgiavienID = DanhgiavienID;
                    DanhgiavienBRL.Edit(oDanhgiavien);
                    btnOK.CausesValidation = true;
                    lblThongbao.Text = "Cập nhật thành công";
                }
                else
                {
                    int DanhgiavienID = DanhgiavienBRL.Add(oDanhgiavien);
                    lblThongbao.Text = "Thêm thành công";
                }

                //Nạp lại dữ liệu
                pnAdd.Visible = false;
                napgrvDanhgiavien();       
            }
            catch (Exception ex)
            {
                lblThongbao.Text = "Thất bại (" + ex.Message + ")";
                //Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=DanhgiavienManager';</script>");
            }
        //}
    }
    protected void lbtnDuyet_Click(object sender, EventArgs e)
    {

    }
}
