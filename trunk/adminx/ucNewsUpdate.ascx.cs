using INVI.Entity;
using INVI.Business;
using INVI.INVILibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Globalization;

public partial class adminx_NewsUpdate : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!PermissionBRL.CheckPermission("QLTintuc")) Response.End();
            this.napNhomcaptren(0, Server.HtmlDecode("&nbsp;"));
            if (Request.QueryString["do"] != null && Request.QueryString["do"] == "add")
            {
                if (!PermissionBRL.CheckPermission("Dangtin")) Response.End();
                clearForm();
            }
            else if (Session["newsID"] != null)
            {
                if (!PermissionBRL.CheckPermission("Capnhaptintuc")) Response.End();
                int newsID = Convert.ToInt32(Session["NewsID"]);
                this.napForm(newsID);
                btnOK.CommandName = "Edit";
                btnOK.Text = "Sửa";
                btnOK.CommandArgument = newsID.ToString();
            }
            else
                Response.Redirect("~/adminx/Default.aspx");
        }
    }
    /// <summary>
    /// Nạp danh sách nhóm cấp trên ra listbox
    /// </summary>
    /// <param name="newsID"></param>
    /// <param name="sCap"></param>
    private void napNhomcaptren(int categoryID, string sCap)
    {
        List<CategoryEntity> lstCat = CategoryBRL.GetByTopID(categoryID);
        foreach (CategoryEntity oCat in lstCat)
        {
            ListItem item = (new ListItem(sCap + oCat.sTitle, oCat.iCategoryID.ToString()));
            lstbNhomtin.Items.Add(item);
            napNhomcaptren(oCat.iCategoryID, Server.HtmlDecode("&nbsp;")+sCap + "-");
        }//foreach

    }
    private void napForm(int newsID)
    {
        NewsEntity entity = NewsBRL.GetOne(newsID);
        if (entity != null)
        {
            txtTitle.Text = entity.sTitle;
            txtDate_datepicker.Value = entity.tDate.ToString("dd/MM/yyyy");
            txtTag.Text = entity.sTag;
            ftbNoidung.Text = entity.sContent;
            txtDesc.Text = entity.sDesc;
            chkVerify.Checked = entity.bVerified;
            //Ảnh Minh Họa
            if (entity.sImage.Trim() != String.Empty)
                imgNews.ImageUrl = "" + ConfigurationManager.AppSettings["UploadPath"] + entity.sImage;
            else
                imgNews.Visible = false;
            //List nhóm tin
            NewsCategoryBRL.GetByiNewsID(newsID).ForEach(
                delegate(NewsCategoryEntity oNewsCat)
                {
                    lstbNhomtin.Items.FindByValue(oNewsCat.iCategoryID.ToString()).Selected = true;
                }
            );
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                NewsEntity entity = new NewsEntity();
                entity.sTitle = txtTitle.Text;
                entity.sDesc = txtDesc.Text;
                entity.sTag = txtTag.Text;
                entity.sContent = ftbNoidung.Text;
                entity.bVerified = chkVerify.Checked;
                entity.iUserID = Convert.ToInt32(Session["UserID"]);
                //  Ngày đăng
                DateTime date, datetime;
                bool result = DateTime.TryParseExact(txtDate_datepicker.Value, "dd/MM/yyyy", null, DateTimeStyles.None, out date);
                if (!result) throw new Exception("Ngày tháng không hợp lê");
                datetime = new DateTime(date.Year, date.Month, date.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                string sDatetime = datetime.ToString();
                //entity.tDate = date;
                entity.tDate = datetime;
                // Ảnh minh họa
                if (fuImage.HasFile)
                {
                    INVIHelper.UploadImage(fuImage);
                    entity.sImage = fuImage.FileName;
                }
                else if (txtUrl.Text.Length > 0)
                {
                    String[] s;
                    s = txtUrl.Text.Split('/');
                    String sFilename = s[s.Length - 1];
                    System.Net.WebClient objWebClient = new System.Net.WebClient();

                    objWebClient.DownloadFile(txtUrl.Text, HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + sFilename));

                    fuImage.SaveAs(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + sFilename));
                    entity.sImage = sFilename;

                }
                else
                    entity.sImage = imgNews.ImageUrl.Replace(ConfigurationManager.AppSettings["UploadPath"], "");
                //Nhóm tin
                List<Int32> lstCategory = new List<int>();
                for (int i = 0; i < lstbNhomtin.Items.Count; i++)
                {
                    if (lstbNhomtin.Items[i].Selected)
                    {
                        try
                        {
                            int categoryID = Convert.ToInt32(lstbNhomtin.Items[i].Value);
                            lstCategory.Add(categoryID);
                        }
                        catch { }
                    }
                }
                int[] arrCategory = lstCategory.ToArray();
                //
                if (btnOK.CommandName == "Edit")
                {
                    entity.iNewsID = Convert.ToInt32(btnOK.CommandArgument);
                    NewsBRL.Edit(entity.iNewsID, entity.sTitle, entity.sDesc, entity.sImage, entity.sTag, entity.tDate, entity.sContent, entity.bVerified, arrCategory);
                }
                else
                    NewsBRL.Add(entity.iUserID, entity.sTitle, entity.sDesc, entity.sImage, entity.sTag, entity.tDate, entity.sContent, entity.bVerified, arrCategory);
                lblThongbao.Text = "Cập nhật thành công";
                Response.Write("<script language=\"javascript\">alert('Cập nhập thành công');location='Default.aspx?page=NewsUpdate';</script>");
                //Nạp lại dữ liệu
                Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=NewsUpdate';</script>");
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
        btnOK.Text = "Thêm";
        txtTitle.Text = "";
        txtDate_datepicker.Value = DateTime.Now.ToString("dd/MM/yyyy");
        txtDesc.Text = "";
        Session.Remove("NewsID");
    }
}
