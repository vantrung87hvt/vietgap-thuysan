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
            if (Request.QueryString["do"] != null && Request.QueryString["do"] == "add")
            {
                //if (!PermissionBRL.CheckPermission("")) Response.End();
                clearForm();
                btnOK.Text = "Thêm";
            }
            else if (Session["PK_iFaqCateID"] != null)
            {
               // if (!PermissionBRL.CheckPermission("EditNews")) Response.End();
                int PK_iFaqCateID = Convert.ToInt32(Session["PK_iFaqCateID"]);
                this.napForm(PK_iFaqCateID);
                btnOK.CommandName = "Edit";
                btnOK.Text = "Sửa";
                btnOK.CommandArgument = PK_iFaqCateID.ToString();
            }
            else
                Response.Redirect("~/adminx/Default.aspx");
        }
    }
    /// <summary>
    /// Nạp danh sách nhóm cấp trên ra listbox
    /// </summary>
    /// <param name="PK_iFaqCateID"></param>
    /// <param name="sCap"></param>
    private void napForm(int PK_iFaqCateID)
    {
        CateFaqEntity entity = CateFaqBRL.GetOne(PK_iFaqCateID);
        if (entity != null)
        {
            txtTenLoai.Text = entity.sCateName;
            txtMota.Text = entity.sDesc;
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {

                CateFaqEntity entity = new CateFaqEntity();
                entity.sCateName = txtTenLoai.Text;
                entity.sDesc = txtMota.Text;
                if (btnOK.CommandName == "Edit")
                {
                    entity.PK_iFaqCateID = Convert.ToInt32(btnOK.CommandArgument);
                    CateFaqBRL.Edit(entity);
                }
                else
                    CateFaqBRL.Add(entity);
                lblThongbao.Text = "Cập nhật thành công";
                //Nạp lại dữ liệu
                Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=FAQCategoryUpdate';</script>");
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
        Session.Remove("PK_iFaqCateID");
    }
}
