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
public partial class adminx_Tochucchungnhan_ucChuyengia : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!PermissionBRL.CheckPermission("ManagerGroup")) Response.End();
        if (!IsPostBack)
        {
            napDdlTochucchungnhan();
            napDdlTrinhdo();
            this.napGridView();
        }
        
    }
    private void napForm(short PK_iChuyengiaID)
    {
        ChuyengiaEntity oChuyengia = ChuyengiaBRL.GetOne(PK_iChuyengiaID);
        if (oChuyengia != null)
        {
            txtHoten.Text = oChuyengia.sHoten;
            ddlTochucchungnhan.SelectedItem.Selected = false;
            ddlTochucchungnhan.Items.FindByValue(oChuyengia.FK_iTochucchungnhanID.ToString()).Selected = true;
            txtSonamkinhnghiem.Text = oChuyengia.iNamkinhnghiem.ToString();
            txtMaso.Text = oChuyengia.sMaso;
            if (oChuyengia.bDuyet)
            {
                ddlDuyet.Items[0].Selected = true;
            }
            else
            {
                ddlDuyet.Items[1].Selected = true;
            }
            imgAnhthe.ImageUrl = "ViewImage.aspx?ID=" + oChuyengia.PK_iChuyengiaID + "&type=Chuyengia";
            ddlTrinhdo.Items.FindByValue(oChuyengia.FK_iTrinhdoID.ToString()).Selected = true;
            napGridView();
        }
    }

    private void napDdlTochucchungnhan()
    {
        ddlTochucchungnhan.DataSource = TochucchungnhanBRL.GetAll();
        ddlTochucchungnhan.DataTextField = "sTochucchungnhan";
        ddlTochucchungnhan.DataValueField = "PK_iTochucchungnhanID";
        ddlTochucchungnhan.DataBind();
    }

    private void napDdlTrinhdo()
    {
        ddlTrinhdo.DataSource = TrinhdoChuyengiaBRL.GetAll();
        ddlTrinhdo.DataTextField = "sTrinhdo";
        ddlTrinhdo.DataValueField = "PK_iTrinhdochuyengiaID";
        ddlTrinhdo.DataBind();
    }

    private void napGridView()
    {
        grvChuyengia.DataSource = ChuyengiaBRL.GetAll();
        grvChuyengia.DataKeyNames = new string[] { "PK_iChuyengiaID" };
        grvChuyengia.DataBind();
    }
    protected void grvPosition_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<ChuyengiaEntity> list = ChuyengiaBRL.GetAll();
        grvChuyengia.DataSource = ChuyengiaEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
        grvChuyengia.DataBind();
    }
    protected void grvPosition_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        short PK_iChuyengiaID = Convert.ToInt16(grvChuyengia.DataKeys[e.NewSelectedIndex].Values["PK_iChuyengiaID"]);
        btnOK.CommandName = "EDIT";
        btnOK.Text = "Sửa";
        pnlEdit.Visible = true;
        btnOK.CommandArgument = PK_iChuyengiaID.ToString();
        napForm(PK_iChuyengiaID);
    }
  
    protected void btnOK_Click(object sender, EventArgs e)
    {
        //Page.Validate("vgChuyengia");
        //if (Page.IsValid)
        //{
            try
            {
                Int32 PK_iChuyengiaID;
                
                ChuyengiaEntity oChuyengia = new ChuyengiaEntity();
                oChuyengia.sHoten = txtHoten.Text;
                oChuyengia.FK_iTochucchungnhanID = int.Parse(ddlTochucchungnhan.SelectedValue);
                oChuyengia.iNamkinhnghiem = short.Parse(txtSonamkinhnghiem.Text);
                oChuyengia.sMaso = txtMaso.Text;
                oChuyengia.FK_iTrinhdoID = short.Parse(ddlTrinhdo.SelectedValue);
                if (ddlDuyet.SelectedValue.Equals("1"))
                {
                    oChuyengia.bDuyet = true;
                }
                else
                {
                    oChuyengia.bDuyet = false;
                }
                byte[] bytImage = null;
                // xu ly anh
                if (fAnhthe.PostedFile != null)
                {
                    if (fAnhthe.PostedFile.ContentLength > 0)
                    {
                        string strEx = "jpg|jpeg|bmp|png|gif";
                        string fileEx = fAnhthe.FileName.Substring(fAnhthe.FileName.LastIndexOf('.')).Remove(0, 1);
                        string[] arrEx = strEx.Split('|');
                        bool valid = false;
                        foreach (string ex in arrEx)
                        {
                            if (ex.Equals(fileEx, StringComparison.OrdinalIgnoreCase))
                                valid = true;
                        }
                        if (valid)
                        {

                            HttpPostedFile objHttpPostedFile = fAnhthe.PostedFile;
                            int intContentlength = objHttpPostedFile.ContentLength;
                            bytImage = new Byte[intContentlength];
                            objHttpPostedFile.InputStream.Read(bytImage, 0, intContentlength);
                            //oChuyengia.imAnh = bytImage;
                        }
                    }
                }
                else
                {
                    
                }

                if (btnOK.CommandName.ToUpper() == "EDIT")
                {
                    PK_iChuyengiaID = Convert.ToInt32(btnOK.CommandArgument);
                    ChuyengiaEntity oChuyengiaOld = ChuyengiaBRL.GetOne(PK_iChuyengiaID);
                    oChuyengia.imAnh = oChuyengiaOld.imAnh;
                    oChuyengia.iTrangthai = oChuyengiaOld.iTrangthai;
                    oChuyengia.PK_iChuyengiaID = PK_iChuyengiaID;
                    ChuyengiaBRL.Edit(oChuyengia);
                    lblThongbao.Text = "Cập nhật thành công";
                }
                else if(btnOK.CommandName.ToUpper()=="ADDNEW")
                {
                    ChuyengiaBRL.Add(oChuyengia);
                    lblThongbao.Text = "Thêm thành công";
                }
                napGridView();
            }
            catch (Exception ex)
            {
                //lblThongbao.Text = ex.Message;
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=Chuyengia';</script>");
            }
            pnlEdit.Visible = false;
        //}
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if(btnOK.CommandName.ToUpper()=="EDIT")
            napForm(Convert.ToInt16(btnOK.CommandArgument));
    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{
            try
            {
                foreach (GridViewRow row in grvChuyengia.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    short PK_iChuyengiaID = Convert.ToInt16(grvChuyengia.DataKeys[row.RowIndex].Values["PK_iChuyengiaID"]);
                    if (chkDelete != null && chkDelete.Checked)
                    {
                        ChuyengiaBRL.Remove(PK_iChuyengiaID);
                    }
                }
                //Nap lai du lieu
                Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=Chuyengia';</script>");
            }
        //}

    }
    protected void lbtnAddnew_Click(object sender, EventArgs e)
    {
        txtHoten.Text = "";
        txtMaso.Text = "";
        txtSonamkinhnghiem.Text = "";
        ddlDuyet.SelectedItem.Selected = ddlTochucchungnhan.SelectedItem.Selected = ddlTrinhdo.SelectedItem.Selected = false;
        btnOK.Text = "Lưu";
        btnOK.CommandName = "ADDNEW";
        pnlEdit.Visible = true;
    }
}
