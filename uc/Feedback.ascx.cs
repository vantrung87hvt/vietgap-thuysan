
using INVI.Entity;
using INVI.Business;
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
    public partial class Feedback : System.Web.UI.UserControl
    {
        private int m_newsID;        
        /// <summary>
        /// Thuộc tính TintucID
        /// </summary>
        public int NewsID
        {
            get { return m_newsID; }
            set { m_newsID = value; }
        }        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGui_Click(object sender, EventArgs e)
        {
            Page.Validate("vgNhapphanhoi");
            if (Page.IsValid)
            {
                int result=0;
                try
                {
                    FeedbackEntity entity = new FeedbackEntity();
                    entity.bVerified = false;
                    entity.iNewsID = this.m_newsID;
                    entity.sContent = txtNoidung.Text;
                    entity.sEmail = txtEmail.Text;
                    entity.sName = txtHoten.Text;
                    entity.sTitle = txtTieude.Text;
                    entity.tDate = DateTime.Now;
                    result = FeedbackBRL.Add(entity);                    
                }
                catch (Exception ex)
                {
                    lblMessage.Text=ex.Message;
                }
                if (result > 0) lblMessage.Text = Resources.language.phanhoidagui;
            }
        }
}
}