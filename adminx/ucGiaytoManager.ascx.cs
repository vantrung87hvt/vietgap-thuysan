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

public partial class uc_ucGiaytoManager : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblThongbao.Text = "";
        if (!IsPostBack)
        {
            if (!PermissionBRL.CheckPermission("QLDanhmucgiaytokemtheo")) Response.End();
            napgrvGrayto();
        }
    }

    private void napgrvGrayto()
    {
        List<GiaytoEntity> lstGiayto = GiaytoBRL.GetAll();
        grvGiayto.DataSource = GiaytoEntity.Sort(lstGiayto, "sTengiayto", "ASC");
        grvGiayto.DataKeyNames = new string[] { "PK_iGiaytoID" };
        grvGiayto.DataBind();
    }

    protected void napForm(int PK_iGiaytoID)
    {
        GiaytoEntity oGiayto = GiaytoBRL.GetOne(PK_iGiaytoID);
        if (oGiayto != null)
        {
            txtTengiayto.Text = oGiayto.sTengiayto;
            chkLoaigiayto.Checked = oGiayto.bCSNT;
        }

    }

    protected void grvMucdo_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<GiaytoEntity> lstGiayto = GiaytoBRL.GetAll();
        grvGiayto.DataSource = GiaytoEntity.Sort(lstGiayto, e.SortExpression, ViewState["SortDirection"].ToString());
        grvGiayto.DataBind();
    }

    protected void grvMucdo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvGiayto.PageIndex = e.NewPageIndex;
        napgrvGrayto();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        btnOK.CommandName = "Add";
        btnOK.Text = "Thêm";
        pnAdd.Visible = true;
        reset();
    }

    protected void grvMucdo_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int GiayToID = Convert.ToInt32(grvGiayto.DataKeys[e.NewSelectedIndex].Values["PK_iGiaytoID"]);
        btnOK.CommandName = "Edit";
        btnOK.Text = "Sửa";
        btnOK.CommandArgument = GiayToID.ToString();
        btnOK.CausesValidation = false;
        pnAdd.Visible = true;
        napForm(GiayToID);
    }


    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                foreach (GridViewRow row in grvGiayto.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int GiayToID = Convert.ToInt32(grvGiayto.DataKeys[row.RowIndex].Values["PK_iGiaytoID"]);
                    if (chkDelete != null && chkDelete.Checked)
                        GiaytoBRL.Remove(GiayToID);
                }
                napgrvGrayto();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=GiaytoManager';</script>");
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
        txtTengiayto.Text = "";
    }
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearchByID.Text;
        int GiayToID = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            GiayToID = 0;
        else GiayToID = Int16.Parse(txtID.Text);
        List<GiaytoEntity> lstGiayto = GiaytoBRL.GetAll();
        if (GiayToID == 0)
        {
            lstGiayto = lstGiayto.FindAll(
            delegate(GiaytoEntity oGiayto)
            {
                return oGiayto.sTengiayto.ToUpper().Contains(strSearch.ToUpper());
            }
            );
        }
        else
        {
            lstGiayto = lstGiayto.FindAll(
            delegate(GiaytoEntity oGiayto)
            {
                return oGiayto.PK_iGiaytoID == GiayToID;
            }
            );
        }
        lblThongbao.Text = "";
        grvGiayto.DataSource = lstGiayto;
        grvGiayto.DataKeyNames = new string[] { "PK_iGiaytoID" };
        grvGiayto.DataBind();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napgrvGrayto();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
            try
            {
                GiaytoEntity oGiayto = new GiaytoEntity();
                oGiayto.sTengiayto = txtTengiayto.Text;
                oGiayto.bCSNT = chkLoaigiayto.Checked;
                if (btnOK.CommandName == "Edit")
                {
                    int GiayToID = Convert.ToInt32(btnOK.CommandArgument);
                    oGiayto.PK_iGiaytoID = GiayToID;
                    GiaytoBRL.Edit(oGiayto);
                    btnOK.CausesValidation = true;
                    lblThongbao.Text = "Cập nhật thành công";
                }
                else
                {
                    int GiayToID = GiaytoBRL.Add(oGiayto);

                    lblThongbao.Text = "Thêm thành công";
                }

                //Nạp lại dữ liệu
                pnAdd.Visible = false;
                napgrvGrayto();       
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=GiaytoManager';</script>");
            }
    }
    protected void grvGiayto_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblGiaytokemtheo = (Label)e.Row.FindControl("lblLoaiGiaytokemtheo");
            if (lblGiaytokemtheo != null)
                if (Convert.ToBoolean(lblGiaytokemtheo.Text) == true)
                    lblGiaytokemtheo.Text = "Hộ nuôi trồng";
                else
                    lblGiaytokemtheo.Text = "Tổ chức chứng nhận";
        }
    }
}
