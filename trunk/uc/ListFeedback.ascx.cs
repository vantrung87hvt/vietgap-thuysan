
using INVI.Business;
using INVI.Entity;
using System.Collections.Generic;
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace INVI.INVINews.Module
{
    public partial class ListFeedback : System.Web.UI.UserControl
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
            List<FeedbackEntity> lstVerifiedByNews = FeedbackBRL.GetVerified(this.m_newsID);
            if (lstVerifiedByNews.Count > 0)
            {
                rptPhanhoi.DataSource = lstVerifiedByNews;
                rptPhanhoi.DataBind();
                lstVerifiedByNews.Clear();
            }
            else
                lblMessage.Text = Resources.language.chuacophanhoi;
        }
    }
}