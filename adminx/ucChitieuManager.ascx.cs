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

public partial class uc_ucChitieuManager : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblThongbao.Text = "";
        if (!IsPostBack)
        {
            napGrvChitieu();
            napDllDanhmucchitieu();
            napDllMucdo();
            napDdlPhuongphapkiemtra();
        }
    }

    public void napGrvChitieu()
    {
        List<ChitieuEntity> lstChitieu = ChitieuBRL.GetAll();
        grvChiTieu.DataSource = ChitieuEntity.Sort(lstChitieu, "iThuthu", "ASC");
        grvChiTieu.DataKeyNames = new string[] { "PK_iChitieuID" };
        grvChiTieu.DataBind();
    }


    public String getsTendanhmucchitieu(int PK_iDanhmucID)
    {
        DanhmucchitieuEntity lstDanhmucchitieu = DanhmucchitieuBRL.GetOne(PK_iDanhmucID);
        return lstDanhmucchitieu.sTenchuyenmuc;
    }
    public String getsTenmucdo(int PK_iMucdoID)
    {
        MucdoEntity item = MucdoBRL.GetOne(PK_iMucdoID);
        return item.sTenmucdo;
    }

    private void napDllDanhmucchitieu()
    {
        List<DanhmucchitieuEntity> lstDanhmucchitieu = DanhmucchitieuBRL.GetAll();
        ddlDanhmucchitieu.Items.Clear();
        ddlDanhmucchitieu.DataSource = lstDanhmucchitieu;
        ddlDanhmucchitieu.DataTextField = "sTenchuyenmuc";
        ddlDanhmucchitieu.DataValueField = "PK_iDanhmucchitieuID";
        ddlDanhmucchitieu.DataBind();
    }

    private void napDllMucdo()
    {
        List<MucdoEntity> lstMucdo = MucdoBRL.GetAll();
        ddlMucdo.Items.Clear();
        ddlMucdo.DataSource = lstMucdo;
        ddlMucdo.DataTextField = "sTenmucdo";
        ddlMucdo.DataValueField = "PK_iMucdoID";
        ddlMucdo.DataBind();
    }

    private void napDdlPhuongphapkiemtra()
    {
        List<PhuongphapkiemtraEntity> lstPhuongphapkiemtra = PhuongphapkiemtraBRL.GetAll();
        ddlPhuongphapkiemtra.Items.Clear();
        ddlPhuongphapkiemtra.DataSource = lstPhuongphapkiemtra;
        ddlPhuongphapkiemtra.DataTextField = "sTenphuongphapkiemtra";
        ddlPhuongphapkiemtra.DataValueField = "PK_iPhuongphapkiemtraID";
        ddlPhuongphapkiemtra.DataBind();
    }

    public void setIndexDllDanhmucchitieu(int iData)
    {
        for (int i = 0; i < ddlDanhmucchitieu.Items.Count; ++i)
        {
            if (int.Parse(ddlDanhmucchitieu.Items[i].Value) == iData)
            {
                ddlDanhmucchitieu.SelectedIndex = i;
                break;
            }
        }
    }

    public void setIndexDllMucdo(int iData)
    {
        for (int i = 0; i < ddlMucdo.Items.Count; ++i)
        {
            if (int.Parse(ddlMucdo.Items[i].Value) == iData)
            {
                ddlMucdo.SelectedIndex = i;
                break;
            }
        }
    }

    public void napForm(int PK_iChiTieuID)
    {
        ChitieuEntity ChiTieu = ChitieuBRL.GetOne(PK_iChiTieuID);
        if (ChiTieu != null)
        {
            txtIThutu.Text = ChiTieu.iThuthu.ToString();
            txtNoidung.InnerText = ChiTieu.sNoidung;
            txtYeucauvietgap.InnerText = ChiTieu.sYeucauvietgap;
            txtGhichu.InnerText = ChiTieu.sGhichu;
            setIndexDllDanhmucchitieu(ChiTieu.FK_iDanhmucchitieuID);
            setIndexDllMucdo(ChiTieu.FK_iMucdoID);
        }

    }

    protected void grvChiTieu_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<ChitieuEntity> listChiTieu = ChitieuBRL.GetAll();
        grvChiTieu.DataSource = ChitieuEntity.Sort(listChiTieu, e.SortExpression, ViewState["SortDirection"].ToString());
        grvChiTieu.DataBind();
    }

    protected void grvChiTieu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvChiTieu.PageIndex = e.NewPageIndex;
        napGrvChitieu();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        btnOK.CommandName = "Add";
        btnOK.Text = "Thêm";
        pnAdd.Visible = true;
        reset();
    }

    protected void grvChiTieu_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int ChiTieuID = Convert.ToInt32(grvChiTieu.DataKeys[e.NewSelectedIndex].Values["PK_iChitieuID"]);
        btnOK.CommandName = "Edit";
        btnOK.Text = "Sửa";
        btnOK.CommandArgument = ChiTieuID.ToString();
        btnOK.CausesValidation = false;
        pnAdd.Visible = true;
        napForm(ChiTieuID);
    }


    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                foreach (GridViewRow row in grvChiTieu.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int ChiTieuID = Convert.ToInt32(grvChiTieu.DataKeys[row.RowIndex].Values["PK_iChitieuID"]);
                    if (chkDelete != null && chkDelete.Checked)
                        ChitieuBRL.Remove(ChiTieuID);
                }
                napGrvChitieu();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=ChitieuManager';</script>");
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
        txtNoidung.InnerText = "";
        txtGhichu.InnerText = "";
        txtYeucauvietgap.InnerText = "";
        txtIThutu.Text = "";
        ddlMucdo.SelectedIndex = 0;
        ddlPhuongphapkiemtra.SelectedIndex = 0;
        if (Session["iDanhmucchitieuIndex"] != null)
        {
            ddlDanhmucchitieu.SelectedIndex = Int16.Parse(Session["iDanhmucchitieuIndex"].ToString());
        }
    }
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearchByID.Text;
        int ChiTieuID = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            ChiTieuID = 0;
        else ChiTieuID = Int16.Parse(txtID.Text);
        List<ChitieuEntity> grvChitieu = ChitieuBRL.GetAll();
        if (ChiTieuID == 0)
        {
            grvChitieu = grvChitieu.FindAll(
            delegate(ChitieuEntity sChiTieu)
            {
                return sChiTieu.sNoidung.ToUpper().Contains(strSearch.ToUpper());
            }
            );
        }
        else
        {
            grvChitieu = grvChitieu.FindAll(
            delegate(ChitieuEntity oChiTieu)
            {
                return oChiTieu.PK_iChitieuID == ChiTieuID;
            }
            );
        }
        lblThongbao.Text = "";
        grvChiTieu.DataSource = grvChitieu;
        grvChiTieu.DataKeyNames = new string[] { "PK_iChitieuID" };
        grvChiTieu.DataBind();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napGrvChitieu();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                Session["iDanhmucchitieuIndex"] = ddlDanhmucchitieu.SelectedIndex;
                ChitieuEntity oChiTieu = new ChitieuEntity();
                oChiTieu.sNoidung = txtNoidung.InnerText;
                oChiTieu.iThuthu = Convert.ToInt16(txtIThutu.Text);
                oChiTieu.sYeucauvietgap = txtYeucauvietgap.InnerText;
                oChiTieu.sGhichu = txtGhichu.InnerText;
                oChiTieu.FK_iDanhmucchitieuID = Int16.Parse(ddlDanhmucchitieu.SelectedValue);
                oChiTieu.FK_iMucdoID = Int16.Parse(ddlMucdo.SelectedValue);
                if (btnOK.CommandName == "Edit")
                {
                    int ChiTieuID = Convert.ToInt32(btnOK.CommandArgument);
                    oChiTieu.PK_iChitieuID = ChiTieuID;
                    ChitieuBRL.Edit(oChiTieu);
                    btnOK.CausesValidation = true;
                    lblThongbao.Text = "Cập nhật thành công";
                }
                else
                {
                    int ChiTieuAddID = ChitieuBRL.Add(oChiTieu);
                    lblThongbao.Text = "Thêm thành công";
                }

                //Nạp lại dữ liệu
                pnAdd.Visible = false;
                napGrvChitieu();       
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=ChitieuManager';</script>");
            }
        }
    }
}
