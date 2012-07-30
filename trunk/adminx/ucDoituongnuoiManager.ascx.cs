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

public partial class adminx_ucDoituongnuoiManager : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblThongbao.Text = "";
        if (!IsPostBack)
        {
            if (!PermissionBRL.CheckPermission("Quanlydoituongnuoi")) Response.End();
            napgrvDoituongnuoi();
        }
    }
    private void napgrvDoituongnuoi()
    {
        List<DoituongnuoiEntity> lstDoituongnuoi = DoituongnuoiBRL.GetAll();
        grvDoituongnuoi.DataSource = DoituongnuoiEntity.Sort(lstDoituongnuoi, "sTendoituong", "ASC");
        grvDoituongnuoi.DataKeyNames = new string[] { "PK_iDoituongnuoiID" };
        grvDoituongnuoi.DataBind();
    }

    protected void napForm(int DoituongnuoiID)
    {
        DoituongnuoiEntity Doituongnuoi = DoituongnuoiBRL.GetOne(DoituongnuoiID);
        if (Doituongnuoi != null)
        {
            txtTen.Text = Doituongnuoi.sTendoituong;
            txtKytu.Text = Doituongnuoi.sKytu;            
        }

    }

    protected void grvDoituongnuoi_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<DoituongnuoiEntity> listDoituongnuoi = DoituongnuoiBRL.GetAll();
        grvDoituongnuoi.DataSource = DoituongnuoiEntity.Sort(listDoituongnuoi, e.SortExpression, ViewState["SortDirection"].ToString());
        grvDoituongnuoi.DataBind();
    }

    protected void grvDoituongnuoi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvDoituongnuoi.PageIndex = e.NewPageIndex;
        napgrvDoituongnuoi();
    }

    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        btnOK.CommandName = "Add";
        pnAdd.Visible = true;
        reset();
        btnOK.Text = "Thêm";
    }

    protected void grvDoituongnuoi_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int DoituongnuoiID = Convert.ToInt32(grvDoituongnuoi.DataKeys[e.NewSelectedIndex].Values["PK_iDoituongnuoiID"]);
        btnOK.CommandName = "Edit";
        btnOK.Text = "Sửa";
        btnOK.CommandArgument = DoituongnuoiID.ToString();
        btnOK.CausesValidation = false;
        pnAdd.Visible = true;
        napForm(DoituongnuoiID);
    }


    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                foreach (GridViewRow row in grvDoituongnuoi.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int DoituongnuoiID = Convert.ToInt32(grvDoituongnuoi.DataKeys[row.RowIndex].Values["PK_iDoituongnuoiID"]);
                    if (chkDelete != null && chkDelete.Checked)
                        DoituongnuoiBRL.Remove(DoituongnuoiID);
                }
                napgrvDoituongnuoi();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=DoituongnuoiManager';</script>");
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
        txtKytu.Text = "";        
    }
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearchByID.Text;
        int DoituongnuoiID = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            DoituongnuoiID = 0;
        else DoituongnuoiID = Int16.Parse(txtID.Text);
        List<DoituongnuoiEntity> lstDoituongnuoi = DoituongnuoiBRL.GetAll();
        if (DoituongnuoiID == 0)
        {
            lstDoituongnuoi = lstDoituongnuoi.FindAll(
            delegate(DoituongnuoiEntity oDoituongnuoi)
            {
                return oDoituongnuoi.sTendoituong.ToUpper().Contains(strSearch.ToUpper()) || oDoituongnuoi.sKytu.ToUpper().Contains(strSearch.ToUpper());
            }
            );
        }
        else
        {
            lstDoituongnuoi = lstDoituongnuoi.FindAll(
            delegate(DoituongnuoiEntity oCDoituongnuoi)
            {
                return oCDoituongnuoi.PK_iDoituongnuoiID == DoituongnuoiID;
            }
            );
        }
        lblThongbao.Text = "";
        grvDoituongnuoi.DataSource = lstDoituongnuoi;
        grvDoituongnuoi.DataKeyNames = new string[] { "PK_iDoituongnuoiID" };
        grvDoituongnuoi.DataBind();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napgrvDoituongnuoi();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                DoituongnuoiEntity oDoituongnuoi = new DoituongnuoiEntity();
                oDoituongnuoi.sTendoituong = txtTen.Text;
                oDoituongnuoi.sKytu = txtKytu.Text;
                if (btnOK.CommandName == "Edit")
                {
                    int DoituongnuoiID = Convert.ToInt32(btnOK.CommandArgument);
                    oDoituongnuoi.PK_iDoituongnuoiID = DoituongnuoiID;
                    DoituongnuoiBRL.Edit(oDoituongnuoi);
                    btnOK.CausesValidation = true;
                    lblThongbao.Text = "Cập nhật thành công";
                }
                else
                {
                    int DoituongnuoiAddID = DoituongnuoiBRL.Add(oDoituongnuoi);
                    lblThongbao.Text = "Thêm thành công";
                }

                //Nạp lại dữ liệu
                pnAdd.Visible = false;
                napgrvDoituongnuoi();

            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=DoituongnuoiManager';</script>");
            }
        }
    }
}
