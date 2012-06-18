using INVI.Entity;
using INVI.Business;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Globalization;
using Aspose.Words;

namespace INVI.INVINews.Admin
{
    public partial class DocumentManager : System.Web.UI.UserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!PermissionBRL.CheckPermission("ManagerDocument")) Response.End();
            if (!IsPostBack)
            {        
                this.napGridView();
                napDdlLoaivanban();
            }
        }

        private void napGridView()
        {
            grvDocument.DataSource = DocumentBRL.GetAll();
            grvDocument.DataKeyNames = new string[] { "PK_iDocumentID" };
            grvDocument.DataBind();
        }
       
        protected void grvDocument_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            HyperLink hplTailieu;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int topID = Convert.ToInt32(grvDocument.DataKeys[e.Row.RowIndex].Values["iTopID"]);
                hplTailieu =(HyperLink)e.Row.FindControl("hplTailieu");
                hplTailieu.ToolTip = hplTailieu.Text;
                hplTailieu.Text = INVILibrary.INVIString.GetCuttedString(hplTailieu.Text, 12);
            }
        }
        protected void grvDocument_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int docID = Convert.ToInt32(grvDocument.DataKeys[e.NewSelectedIndex].Values["PK_iDocumentID"]);
            btnOK.CommandName = "Edit";
            btnOK.Text = "Sửa";
            btnOK.CommandArgument = docID.ToString();
            btnOK.CausesValidation = false;
            napForm(docID);
        }
        public void napDdlLoaivanban()
        {
            try
            {
                ddlLoaivanban.Items.Clear();
                List<LoaivanbanEntity> lstLoaivanban = LoaivanbanBRL.GetAll();
                //lstLoaivanban.Sort();
                ddlLoaivanban.DataSource = lstLoaivanban;
                ddlLoaivanban.DataValueField = "PK_iLoaivanbanID";
                ddlLoaivanban.DataTextField = "sTenloai";
                
                ddlLoaivanban.DataBind();
                ddlLoaivanban.Items.Insert(0, new ListItem("-- Chọn --", "0"));
            }
            catch (Exception ex)
            {

            }
        }
        private void napForm(int docID)
        {
            DocumentEntity oDoc = DocumentBRL.GetOne(docID);
            if (oDoc != null)
            {
                txtTitle.Text = oDoc.sTitle;
                txtAuthor.Text = oDoc.sAuthor;
                txtDesc.Text = oDoc.sDesc;
                img.Visible = true;
                img.ImageUrl = ConfigurationManager.AppSettings["UploadPath"]+ oDoc.sImage;
                lnkDocument.Visible = true;
                lnkDocument.Text = oDoc.sTitle;
                lnkDocument.NavigateUrl = ConfigurationManager.AppSettings["UploadPath"] + oDoc.sLinkFile;
                txtCoquanbanhanh.Text = oDoc.sCoquanbanhanh;
                txtNgaybanhanh_datepicker.Value = oDoc.dNgaybanhanh.ToString("dd/MM/yyyy");
                txtNgaydangcongbao_datepicker.Value = oDoc.dNgaydangcongbao.ToString("dd/MM/yyyy");
                txtNgayhethieuluc_datepicker.Value = oDoc.dNgayhethieuluc.ToString("dd/MM/yyyy");
                txtNgaycohieuluc_datepicker.Value = oDoc.dNgaycohieuluc.ToString("dd/MM/yyyy");
                txtPhamvi.Text = oDoc.sPhamvi;
                txtSokyhieu.Text = oDoc.sSokyhieu;
                ddlLoaivanban.SelectedValue = oDoc.FK_iLoaivanbanID.ToString();

                pnEdit.Visible = true;
            }
        }
         protected void btnOK_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    DateTime dNgaybanhanh, dNgaydangcongbao, dNgayhethieuluc, dNgaycohieuluc;
                    dNgaybanhanh = DateTime.ParseExact(txtNgaybanhanh_datepicker.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dNgaycohieuluc = DateTime.ParseExact(txtNgaycohieuluc_datepicker.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dNgaydangcongbao = DateTime.ParseExact(txtNgaydangcongbao_datepicker.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (txtNgayhethieuluc_datepicker.Value.Length > 0)
                        dNgayhethieuluc = DateTime.ParseExact(txtNgayhethieuluc_datepicker.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    else
                        dNgayhethieuluc = DateTime.Now.AddMonths(12);
                    int docID = 0;
                    if (Session["UserID"] == null)
                        Session["UserID"] = 2;
                    if (Session["UserID"] != null)
                    {
                        int userID = Convert.ToInt32(Session["UserID"]);
                        string strImageFile = uploadFile(fuImage, "jpg|jpeg|bmp|png|gif");
                        string strDocFile = uploadFile(fuDocument, "doc|docx|xls|xlsx|ppt|pptx|rar|zip|txt|pdf");
                        if (btnOK.CommandName == "Edit")
                        {
                            docID = Convert.ToInt32(btnOK.CommandArgument);
                            if (strImageFile == null)
                                strImageFile = img.ImageUrl.Replace(ConfigurationManager.AppSettings["UploadPath"], "");
                            if (strDocFile == null)
                                strDocFile = lnkDocument.NavigateUrl.Replace(ConfigurationManager.AppSettings["UploadPath"], "");
                            DocumentBRL.Edit(docID, txtTitle.Text, strDocFile, strImageFile, txtAuthor.Text, txtDesc.Text, userID, txtSokyhieu.Text, txtCoquanbanhanh.Text, dNgaybanhanh, dNgayhethieuluc, dNgaydangcongbao, txtPhamvi.Text, Convert.ToInt16(ddlLoaivanban.SelectedValue), dNgaycohieuluc);
                            btnOK.CausesValidation = true;
                        }
                        else
                            DocumentBRL.Add(txtTitle.Text, strDocFile, strImageFile, txtAuthor.Text, txtDesc.Text, userID, txtSokyhieu.Text, txtCoquanbanhanh.Text, dNgaybanhanh, dNgayhethieuluc, dNgaydangcongbao, txtPhamvi.Text, Convert.ToInt16(ddlLoaivanban.SelectedValue), dNgaycohieuluc);
                        lblThongbao.Text = "Cập nhật thành công";
                        //Nạp lại dữ liệu
                        pnEdit.Visible = false;
                        btnOK.Text = "Thêm";
                        Response.Redirect(Request.Url.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=DocumentManager';</script>");
                }
            }

           
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            btnOK.CommandName = "Add";
            clearForm();
        }
        public void clearForm()
        {
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtDesc.Text = "";
            lnkDocument.Visible = false;
            img.Visible = false;
            txtCoquanbanhanh.Text = "";
            txtNgaybanhanh_datepicker.Value = "";
            txtNgaydangcongbao_datepicker.Value = "";
            txtNgayhethieuluc_datepicker.Value = "";
            txtNgaycohieuluc_datepicker.Value = "";
            txtPhamvi.Text = "";
            txtSokyhieu.Text = "";
            ddlLoaivanban.SelectedIndex = 0;
        }
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    foreach (GridViewRow row in grvDocument.Rows)
                    {
                        System.Web.UI.WebControls.CheckBox chkDelete = row.FindControl("chkDelete") as System.Web.UI.WebControls.CheckBox;
                        int docID = Convert.ToInt32(grvDocument.DataKeys[row.RowIndex].Values["PK_iDocumentID"]);
                        if (chkDelete != null && chkDelete.Checked)
                        {
                            DocumentBRL.Remove(docID);
                            try
                            {
                                File.Delete(ConfigurationManager.AppSettings["UploadPath"] + DocumentBRL.GetOne(docID).sImage);
                                File.Delete(ConfigurationManager.AppSettings["UploadPath"] + DocumentBRL.GetOne(docID).sLinkFile);
                            }
                            catch { }
                        }
                    }
                    //Nap lai du lieu
                    Response.Redirect(Request.Url.ToString());
                }
                catch (Exception ex)
                {
                    Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=DocumentManager';</script>");
                }
            }
        }
        protected void grvDocument_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvDocument.PageIndex = e.NewPageIndex;
            napGridView();
        }
        protected void grvDocument_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null)
                ViewState["SortDirection"] = "ASC";
            else
            {
                ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
            }
            List<DocumentEntity> list=DocumentBRL.GetAll();
            grvDocument.DataSource = DocumentEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
            grvDocument.DataBind();
        }
        private string uploadFile(FileUpload fu, string strEx)
        {

                        if (fu.HasFile)
                        {
                            string fileEx = fu.FileName.Substring(fu.FileName.LastIndexOf('.')).Remove(0, 1);
                            string[] arrEx = strEx.Split('|');
                            bool valid = false;
                            foreach (string ex in arrEx)
                            {
                                if (ex.Equals(fileEx, StringComparison.OrdinalIgnoreCase))
                                    valid = true;
                            }
                            if (valid)
                            {
                                fu.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "\\" + "doc" + "\\" + Server.HtmlEncode(fu.FileName)));                       //

                                return fu.FileName;
                            }
                            else
                                return null;
                        }
                        else
                            return null;
        }

        protected void grvDocument_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lnkAddnew_Click(object sender, EventArgs e)
        {
            btnOK.CommandName = "Add";
            pnEdit.Visible = true;
            clearForm();
        }
}
}