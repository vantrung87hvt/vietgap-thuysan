using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Business;
using INVI.Entity;

public partial class adminx_ucDocumentCategoryUpdate : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!PermissionBRL.CheckPermission("Quanlytailieuquypham")) Response.End();
            if (Request.QueryString["do"] != null && Request.QueryString["do"] == "add")
            {
                //if (!PermissionBRL.CheckPermission("")) Response.End();
                clearForm();
                btnOK.Text = "Thêm";
            }
            else if (Session["PK_iLoaivanbanID"] != null)
            {
               // if (!PermissionBRL.CheckPermission("EditNews")) Response.End();
                int PK_iLoaivanbanID = Convert.ToInt32(Session["PK_iLoaivanbanID"]);
                this.napForm(PK_iLoaivanbanID);
                btnOK.CommandName = "Edit";
                btnOK.Text = "Sửa";
                btnOK.CommandArgument = PK_iLoaivanbanID.ToString();
            }
            else
                Response.Redirect("~/adminx/Default.aspx");
        }
    }
    /// <summary>
    /// Nạp danh sách nhóm cấp trên ra listbox
    /// </summary>
    /// <param name="PK_iLoaivanbanID"></param>
    /// <param name="sCap"></param>
    private void napForm(int PK_iLoaivanbanID)
    {
        LoaivanbanEntity entity = LoaivanbanBRL.GetOne(PK_iLoaivanbanID);
        if (entity != null)
        {
            txtTenLoai.Text = entity.sTenloai;            
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                LoaivanbanEntity entity = new LoaivanbanEntity();
                entity.sTenloai = txtTenLoai.Text;

                if (btnOK.CommandName == "Edit")
                {
                    entity.PK_iLoaivanbanID = Convert.ToInt32(btnOK.CommandArgument);
                    LoaivanbanBRL.Edit(entity);
                }
                else
                    LoaivanbanBRL.Add(entity);
                lblThongbao.Text = "Cập nhật thành công";
                //Nạp lại dữ liệu
                Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=DocumentCategoryUpdate';</script>");
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        clearForm();
    }
    private void clearForm()
    {
        btnOK.CommandName = "Add";
        txtTenLoai.Text = "";        
        Session.Remove("PK_iLoaivanbanID");
    }
}
