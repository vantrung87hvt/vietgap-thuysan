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
using INVI.Business;
using INVI.Entity;


public partial class adminx_Tochucchungnhan_ucChungchiChuyengia : System.Web.UI.UserControl
{
    private bool bAddnew;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!PermissionBRL.CheckPermission("QLCacloaichungchichuyengia")) Response.End();
        if (!Page.IsPostBack)
            napGridView();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            ChungchiEntity oChungchi = new ChungchiEntity();
            oChungchi.sTenChungchi = txtChungchi.Text;
            oChungchi.sMota = txtMota.Text;
            if (bAddnew == false && btnOK.CommandName.ToUpper() == "EDIT")
            {
                oChungchi.PK_iChungchiID = Convert.ToInt16(btnOK.CommandArgument);
                ChungchiBRL.Edit(oChungchi);
                lblThongbao.Text = "Cập nhật thành công";
            }
            else if (btnOK.CommandName.ToUpper() == "ADDNEW")
            {
                ChungchiBRL.Add(oChungchi);
                lblThongbao.Text = "Thêm nhóm thành công";
                napGridView();
                pnlEdit.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //lblThongbao.Text = ex.Message;
            Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=ChungchiManager';</script>");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (btnOK.CommandName.ToUpper() == "EDIT")
            napForm(Convert.ToInt16(btnOK.CommandArgument));
    }
    
    protected void lbtnAddnew_Click(object sender, EventArgs e)
    {
        txtChungchi.Enabled = true;
        txtChungchi.Text = "";
        txtMota.Enabled = true;
        txtMota.Text = "";
        btnOK.Text = "Lưu";
        btnOK.CommandName = "ADDNEW";
        pnlEdit.Visible = true;
    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
            try
            {
                foreach (GridViewRow row in grvChungchi.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    short PK_iTrinhdoChuyengiaID = Convert.ToInt16(grvChungchi.DataKeys[row.RowIndex].Values["PK_iChungchiID"]);
                    if (chkDelete != null && chkDelete.Checked)
                    {
                        ChungchiBRL.Remove(PK_iTrinhdoChuyengiaID);
                    }
                }
                //Nap lai du lieu
                Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=ChungchiManager';</script>");
            }
    }
    
    protected void grvChungchi_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    private void napForm(short PK_iChungchiID)
    {
        ChungchiEntity oChungchi = ChungchiBRL.GetOne(PK_iChungchiID);
        if (oChungchi != null)
        {
            txtChungchi.Text = oChungchi.sTenChungchi;
            txtMota.Text = oChungchi.sMota;
            napGridView();
        }
    }
    private void napGridView()
    {
        grvChungchi.DataSource = ChungchiBRL.GetAll();
        grvChungchi.DataKeyNames = new string[] { "PK_iChungchiID" };
        grvChungchi.DataBind();
    }
    protected void grvChungchi_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        short PK_iChungchiID = Convert.ToInt16(grvChungchi.DataKeys[e.NewSelectedIndex].Values["PK_iChungchiID"]);
        btnOK.CommandName = "EDIT";
        btnOK.Text = "Sửa";
        bAddnew = false;
        pnlEdit.Visible = true;
        btnOK.CommandArgument = PK_iChungchiID.ToString();
        napForm(PK_iChungchiID);
    }
}