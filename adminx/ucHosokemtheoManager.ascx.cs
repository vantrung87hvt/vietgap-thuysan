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

public partial class uc_HosokemtheoManager : System.Web.UI.UserControl
{
    public int PK_iUserID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
            Response.Redirect("~/");
        else
            PK_iUserID = int.Parse(Session["userID"].ToString());
        lblThongbao.Text = "";
        if (!IsPostBack)
        {
            napDllGiayto();
            napgrvHosokemtheo();
        }
    }

    private void napgrvHosokemtheo()
    {

        if (Session["userID"] == null)
            Response.Redirect("~/");
        else
            PK_iUserID = int.Parse(Session["userID"].ToString());

        List<TochucchungnhanTaikhoanEntity> lstTochucTaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(PK_iUserID);

        if (lstTochucTaikhoan.Count > 0)
        {
            List<DangkyHoatdongchungnhanEntity> oDangky = DangkyHoatdongchungnhanBRL.GetByFK_iTochucchungnhanID(lstTochucTaikhoan[0].FK_iTochucchungnhanID);
            List<HosokemtheoTochucchungnhanEntity> lstHosokemtheo = HosokemtheoTochucchungnhanBRL.GetByFK_iDangkyChungnhanVietGapID(oDangky[0].PK_iDangkyChungnhanVietGapID);
            grvHosokemtheo.DataSource = HosokemtheoTochucchungnhanEntity.Sort(lstHosokemtheo, "sTenhoso", "ASC");
            grvHosokemtheo.DataKeyNames = new string[] { "PK_iHosokemtheoID" };
            grvHosokemtheo.DataBind();
        }
        else
            Response.Write("<script>alert('Không có tổ chức chứng nhận nào được quản lý bởi tài khoản này');</script>");
    }

    private void napDllGiayto()
    {
        List<GiaytoEntity> lstGiayto = GiaytoBRL.GetAll();
        ddlGiayto.Items.Clear();
        ddlGiayto.DataSource = lstGiayto;
        ddlGiayto.DataTextField = "sTengiayto";
        ddlGiayto.DataValueField = "PK_iGiaytoID";
        ddlGiayto.DataBind();
    }

    protected void napForm(int PK_iHosokemtheoID)
    {
        HosokemtheoTochucchungnhanEntity oHoso = HosokemtheoTochucchungnhanBRL.GetOne(PK_iHosokemtheoID);
        if (oHoso != null)
        {
            GiaytoEntity oGiayto = GiaytoBRL.GetOne(oHoso.FK_iGiaytoID);
            ddlGiayto.Items.FindByValue(oGiayto.PK_iGiaytoID.ToString()).Selected = true;
        }

    }

    public String getsTengiayto(int PK_iGiaytoID)
    {
        GiaytoEntity oGiayto = GiaytoBRL.GetOne(PK_iGiaytoID);
        return oGiayto.sTengiayto;
    }

    protected void grvHosokemtheo_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<HosokemtheoTochucchungnhanEntity> listHosokemtheo = HosokemtheoTochucchungnhanBRL.GetAll();
        grvHosokemtheo.DataSource = HosokemtheoTochucchungnhanEntity.Sort(listHosokemtheo, e.SortExpression, ViewState["SortDirection"].ToString());
        grvHosokemtheo.DataBind();
    }

    protected void grvHosokemtheo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvHosokemtheo.PageIndex = e.NewPageIndex;
        napgrvHosokemtheo();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        btnOK.CommandName = "Add";
        btnOK.Text = "Thêm";
        pnAdd.Visible = true;
        reset();
    }

    protected void grvHosokemtheo_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int oHosoID = Convert.ToInt32(grvHosokemtheo.DataKeys[e.NewSelectedIndex].Values["PK_iHosokemtheoID"]);
        btnOK.CommandName = "Edit";
        btnOK.Text = "Sửa";
        btnOK.CommandArgument = oHosoID.ToString();
        btnOK.CausesValidation = false;
        pnAdd.Visible = true;
        napForm(oHosoID);
    }


    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                foreach (GridViewRow row in grvHosokemtheo.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int oHosoID = Convert.ToInt32(grvHosokemtheo.DataKeys[row.RowIndex].Values["PK_iHosokemtheoID"]);
                    if (chkDelete != null && chkDelete.Checked)
                        HosokemtheoTochucchungnhanBRL.Remove(oHosoID);
                }
                napgrvHosokemtheo();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=HosokemtheoManager';</script>");
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
        ddlGiayto.SelectedIndex = 0;
    }
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napgrvHosokemtheo();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {

                int FK_iGiayto = int.Parse(ddlGiayto.SelectedValue.ToString());
                HosokemtheoTochucchungnhanEntity oHoso = new HosokemtheoTochucchungnhanEntity();
                if (Session["UserID"] != null)
                    PK_iUserID = int.Parse(Session["UserID"].ToString());
                List<TochucchungnhanTaikhoanEntity> lstTochucTaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(PK_iUserID);
                if (lstTochucTaikhoan.Count <= 0)
                {
                    Response.Write("<script language=\"javascript\">alert('Bạn không phải Tổ chức chứng nhận, nên bạn không có quyền sử dụng chức năng này.');location='Default.aspx';</script>");
                    return;
                }
                TochucchungnhanEntity oTochuc = TochucchungnhanBRL.GetOne(lstTochucTaikhoan[0].FK_iTochucchungnhanID);
                oHoso.FK_iGiaytoID = FK_iGiayto;
                List<DangkyHoatdongchungnhanEntity> oDangky = DangkyHoatdongchungnhanBRL.GetByFK_iTochucchungnhanID(oTochuc.PK_iTochucchungnhanID);
                oHoso.FK_iDangkyChungnhanVietGapID = oDangky[0].PK_iDangkyChungnhanVietGapID;
                if (btnOK.CommandName == "Edit")
                {
                    int oHosoID = Convert.ToInt32(btnOK.CommandArgument);
                    oHoso.PK_iHosokemtheoID = oHosoID;
                    HosokemtheoTochucchungnhanBRL.Edit(oHoso);
                    btnOK.CausesValidation = true;
                    lblThongbao.Text = "Cập nhật thành công";
                }
                else
                {
                    List<HosokemtheoTochucchungnhanEntity> lstHoso = HosokemtheoTochucchungnhanBRL.GetByFK_iGiaytoID(FK_iGiayto);
                    if (lstHoso.Count > 0)
                    {
                        lblThongbao.Text = "Giấy tờ này đã có trong danh sách!";
                        pnAdd.Visible = false;
                        return;
                    }
                    int oHosoID = HosokemtheoTochucchungnhanBRL.Add(oHoso);
                    lblThongbao.Text = "Thêm thành công";
                }

                //Nạp lại dữ liệu
                pnAdd.Visible = false;
                napgrvHosokemtheo();       
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=HosokemtheoManager';</script>");
            }
        }
    }
}
