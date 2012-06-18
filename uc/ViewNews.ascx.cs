/*
 * Create By : xtrung
 * On        : 06.07.08
*/

using INVI.Business;
using INVI.Entity;
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
namespace INVI.INVINews.Module
{
    public partial class ViewNews : System.Web.UI.UserControl
    {
        private int m_newsID;
        /// <summary>
        /// Thuộc tính mã tin tức
        /// </summary>
        public int NewsID
        {
            get { return m_newsID; }
            set { m_newsID = value; }
        }
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Request.QueryString["preCategoryID"] != null)
            {
                try
                {
                    //Hiện nhóm tin của tin đang xem
                    int CategoryID = Convert.ToInt32(Request.QueryString["preCategoryID"]);
                    CategoryEntity oCategory = CategoryBRL.GetOne(CategoryID);
                    if (oCategory!=null)
                    {
                        lnkCategory.Text = oCategory.sTitle;
                        lnkCategory.NavigateUrl = "~/Default.aspx?catID=" + CategoryID;
                    }
                    //end
                }
                catch (System.Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
            try
            {
                NewsEntity oNews = NewsBRL.GetOne(this.m_newsID);
                if (oNews != null)
                {
                    lblTieude.Text = oNews.sTitle;
                    lblNgaydang.Text = oNews.tDate.ToString("dd/MM/yyyy");
                    //imgMinhhoa.ImageUrl = ConfigurationManager.AppSettings["UploadPath"] + oNews.sImage;
                    //imgMinhhoa.Visible = (File.Exists(Server.MapPath(imgMinhhoa.ImageUrl))) ? true : false;
                    lblMota.Text = "" + oNews.sDesc;
                    lblNoidung.Text = oNews.sContent;
                    this.displayControl();
                }
                else
                {
                    lblMessage.Text = "Tin Này Không Tồn Tại Hoặc Chưa Được Kiểm Duyệt";
                    phXemtin.Visible = false;
                    phControl.Visible = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            //-------------------
        }

        private void displayControl()
        {
            phControl.Visible = true;
            Feedback1.NewsID = this.m_newsID;
            ListFeedback1.NewsID = this.m_newsID;
            //Rate1.NewsID = this.m_newsID;
            Poll1.NewsID = this.m_newsID;
            ListNewsMoreInCat1.NewsID = this.m_newsID;
        }
        
    }//end class
}