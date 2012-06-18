using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.Business;
public partial class adminx_ucHinhThucNuoiManager : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblThongbao.Text = "";
        if (!IsPostBack)
        {
            napgrvHinhThucNuoi();
        }
    }
    private void napgrvHinhThucNuoi()
    {
        List<HinhthucnuoiEntity> lstHinhthucnuoi = HinhthucnuoiBRL.GetAll();
        grvHinhThucNuoi.DataSource = HinhthucnuoiEntity.Sort(lstHinhthucnuoi, "sTenhinhthuc", "ASC");
        grvHinhThucNuoi.DataKeyNames = new string[] { "PK_iHinhthucnuoiID" };
        grvHinhThucNuoi.DataBind();
    }

    protected void napForm(int HinhthucnuoiID)
    {
        HinhthucnuoiEntity Hinhthucnuoi = HinhthucnuoiBRL.GetOne(HinhthucnuoiID);
        if (Hinhthucnuoi != null)
        {
            txtTen.Text = Hinhthucnuoi.sTenhinhthuc;            
        }

    }

    protected void grvHinhThucNuoi_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<HinhthucnuoiEntity> listHinhthucnuoi = HinhthucnuoiBRL.GetAll();
        grvHinhThucNuoi.DataSource = HinhthucnuoiEntity.Sort(listHinhthucnuoi, e.SortExpression, ViewState["SortDirection"].ToString());
        grvHinhThucNuoi.DataBind();
    }

    protected void grvHinhThucNuoi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvHinhThucNuoi.PageIndex = e.NewPageIndex;
        napgrvHinhThucNuoi();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        btnOK.CommandName = "Add";
        pnAdd.Visible = true;
        reset();
        btnOK.Text = "Thêm";
    }

    protected void grvHinhThucNuoi_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int HinhthucnuoiID = Convert.ToInt32(grvHinhThucNuoi.DataKeys[e.NewSelectedIndex].Values["PK_iHinhthucnuoiID"]);
        btnOK.CommandName = "Edit";
        btnOK.Text = "Sửa";
        btnOK.CommandArgument = HinhthucnuoiID.ToString();
        btnOK.CausesValidation = false;
        pnAdd.Visible = true;
        napForm(HinhthucnuoiID);
    }


    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {

                foreach (GridViewRow row in grvHinhThucNuoi.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int HinhthucnuoiID = Convert.ToInt32(grvHinhThucNuoi.DataKeys[row.RowIndex].Values["PK_iHinhthucnuoiID"]);
                    if (chkDelete != null && chkDelete.Checked)
                        HinhthucnuoiBRL.Remove(HinhthucnuoiID);
                }
                napgrvHinhThucNuoi();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=HinhThucNuoiManager';</script>");
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
        txtTen.Text = "";        
    }
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearchByID.Text;
        int HinhthucnuoiID = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            HinhthucnuoiID = 0;
        else HinhthucnuoiID = Int16.Parse(txtID.Text);
        List<HinhthucnuoiEntity> lstHinhthucnuoi = HinhthucnuoiBRL.GetAll();
        if (HinhthucnuoiID == 0)
        {
            lstHinhthucnuoi = lstHinhthucnuoi.FindAll(
            delegate(HinhthucnuoiEntity oHinhthucnuoi)
            {
                return oHinhthucnuoi.sTenhinhthuc.ToUpper().Contains(strSearch.ToUpper()) ;
            }
            );
        }
        else
        {
            lstHinhthucnuoi = lstHinhthucnuoi.FindAll(
            delegate(HinhthucnuoiEntity oCHinhthucnuoi)
            {
                return oCHinhthucnuoi.PK_iHinhthucnuoiID == HinhthucnuoiID;
            }
            );
        }
        lblThongbao.Text = "";
        grvHinhThucNuoi.DataSource = lstHinhthucnuoi;
        grvHinhThucNuoi.DataKeyNames = new string[] { "PK_iHinhthucnuoiID" };
        grvHinhThucNuoi.DataBind();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napgrvHinhThucNuoi();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
            try
            {
                HinhthucnuoiEntity oHinhthucnuoi = new HinhthucnuoiEntity();
                oHinhthucnuoi.sTenhinhthuc = txtTen.Text;
                if (btnOK.CommandName == "Edit")
                {
                    int HinhthucnuoiID = Convert.ToInt32(btnOK.CommandArgument);
                    oHinhthucnuoi.PK_iHinhthucnuoiID = HinhthucnuoiID;
                    HinhthucnuoiBRL.Edit(oHinhthucnuoi);
                    btnOK.CausesValidation = true;
                    lblThongbao.Text = "Cập nhật thành công";
                }
                else
                {
                    int HinhthucnuoiAddID = HinhthucnuoiBRL.Add(oHinhthucnuoi);
                    lblThongbao.Text = "Thêm thành công";
                }

                //Nạp lại dữ liệu
                pnAdd.Visible = false;
                napgrvHinhThucNuoi();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=HinhThucNuoiManager';</script>");
            }
    }
}
