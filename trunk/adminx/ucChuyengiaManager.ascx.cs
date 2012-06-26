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
            napgrvChuyengia();
            
        }
    }

    private void napgrvChuyengia()
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
        List<ChuyengiaEntity> lstChuyengia = ChuyengiaBRL.GetByFK_iTochucchungnhanID(lstTochucTaikhoan[0].FK_iTochucchungnhanID);
        grvChuyengia.DataSource = ChuyengiaEntity.Sort(lstChuyengia, "sHoten", "ASC");
        grvChuyengia.DataKeyNames = new string[] { "PK_iChuyengiaID" };
        grvChuyengia.DataBind();
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
        ChuyengiaEntity oChuyengia = ChuyengiaBRL.GetOne(PK_iHosokemtheoID);
        if (oChuyengia != null)
        {
            txtHoten.Text = oChuyengia.sHoten;
            // truy vấn từ đối tượng trình độ
            txtTrinhdo.Text = TrinhdoChuyengiaBRL.GetOne(oChuyengia.FK_iTrinhdoID).sTrinhdo;
            txtSonamkinhnghiem.Text = oChuyengia.iNamkinhnghiem.ToString();
            // Ở đây phải lấy danh sách các chứng chỉ liên quan đến chuyên gia mà họ có
            //chkTCVN.Checked = oChuyengia.bTCVN190112003;
            //chkISO.Checked = oChuyengia.bISO190112002;
            //chkVietGAP.Checked = oChuyengia.bVietGapCer;
            chkDuyet.Checked = oChuyengia.bDuyet;
        }

    }

    protected void grvChuyengia_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<ChuyengiaEntity> lstChuyengia = ChuyengiaBRL.GetAll();
        grvChuyengia.DataSource = ChuyengiaEntity.Sort(lstChuyengia, e.SortExpression, ViewState["SortDirection"].ToString());
        grvChuyengia.DataBind();
    }

    protected void grvChuyengia_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvChuyengia.PageIndex = e.NewPageIndex;
        napgrvChuyengia();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        btnOK.CommandName = "Add";
        btnOK.Text = "Thêm";
        pnAdd.Visible = true;
        reset();
    }

    protected void grvChuyengia_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int ChuyengiaID = Convert.ToInt32(grvChuyengia.DataKeys[e.NewSelectedIndex].Values["PK_iChuyengiaID"]);
        btnOK.CommandName = "Edit";
        btnOK.Text = "Sửa";
        btnOK.CommandArgument = ChuyengiaID.ToString();
        btnOK.CausesValidation = false;
        pnAdd.Visible = true;
        napForm(ChuyengiaID);
    }


    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                foreach (GridViewRow row in grvChuyengia.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int ChuyengiaID = Convert.ToInt32(grvChuyengia.DataKeys[row.RowIndex].Values["PK_iChuyengiaID"]);
                    if (chkDelete != null && chkDelete.Checked)
                        ChuyengiaBRL.Remove(ChuyengiaID);
                }
                napgrvChuyengia();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=ChuyengiaManager';</script>");
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
        int ChuyengiaID = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            ChuyengiaID = 0;
        else ChuyengiaID = Int16.Parse(txtID.Text);
        List<ChuyengiaEntity> lstChuyengia = ChuyengiaBRL.GetAll();
        if (ChuyengiaID == 0)
        {
            lstChuyengia = lstChuyengia.FindAll(
            delegate(ChuyengiaEntity sChuyengia)
            {
                return sChuyengia.sHoten.ToUpper().Contains(strSearch.ToUpper());
            }
            );
        }
        else
        {
            lstChuyengia = lstChuyengia.FindAll(
            delegate(ChuyengiaEntity oChuyengia)
            {
                return oChuyengia.PK_iChuyengiaID == ChuyengiaID;
            }
            );
        }
        lblThongbao.Text = "";
        grvChuyengia.DataSource = lstChuyengia;
        grvChuyengia.DataKeyNames = new string[] { "PK_iChuyengiaID" };
        grvChuyengia.DataBind();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napgrvChuyengia();
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
                ChuyengiaEntity oChuyengia = new ChuyengiaEntity();
                oChuyengia.sHoten = txtHoten.Text;
                oChuyengia.FK_iTochucchungnhanID = oTochuc.PK_iTochucchungnhanID;
                //oChuyengia.sTrinhdo = txtTrinhdo.Text;
                oChuyengia.iNamkinhnghiem = short.Parse(txtSonamkinhnghiem.Text);
                //oChuyengia.bTCVN190112003 = chkTCVN.Checked;
                //oChuyengia.bISO190112002 = chkISO.Checked;
                //oChuyengia.bVietGapCer = chkVietGAP.Checked;
                if (btnOK.CommandName == "Edit")
                {
                    int ChuyengiaID = Convert.ToInt32(btnOK.CommandArgument);
                    oChuyengia.PK_iChuyengiaID = ChuyengiaID;
                    ChuyengiaBRL.Edit(oChuyengia);
                    btnOK.CausesValidation = true;
                    lblThongbao.Text = "Cập nhật thành công";
                }
                else
                {
                    int ChuyengiaID = ChuyengiaBRL.Add(oChuyengia);
                    lblThongbao.Text = "Thêm thành công";
                }

                //Nạp lại dữ liệu
                pnAdd.Visible = false;
                napgrvChuyengia();       
            }
            catch (Exception ex)
            {
                lblThongbao.Text = "Thất bại (" + ex.Message + ")";
                //Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=ChuyengiaManager';</script>");
            }
        //}
    }
    protected void lbtnDuyet_Click(object sender, EventArgs e)
    {

    }
}
