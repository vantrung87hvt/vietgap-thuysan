/*
 * Create By : xtrung
 * On        : 08.07.08
*/

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
using System.Text;
namespace INVI.INVINews.Module
{
    public partial class Rate : System.Web.UI.UserControl
    {
        private int m_newsID;
        public int NewsID 
        {
            get { return m_newsID; }
            set { m_newsID = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                this.napBinhchon();
                this.napThongke();
            }
        }
        private void napThongke()
        {
            List<RateEntity> lstRate = RateBRL.GetByiNewsID(this.m_newsID);
            if (lstRate.Count>0)
            {
                RateEntity oRate = lstRate[0];
                StringBuilder sbThongke = new StringBuilder();
                sbThongke.Append(Resources.language.luotbinhchon + " : ");
                sbThongke.AppendLine(oRate.iCount.ToString());
                if (oRate.iCount > 0 && oRate.iRate > 0)
                {
                    int trungbinh = oRate.iRate / oRate.iCount;
                    if (trungbinh >= 1 && trungbinh <= 5)
                    {
                        imgStar.ImageUrl = "~/images/rating/rating_" + trungbinh.ToString() + ".gif";
                        imgStar.Visible = true;
                    }
                }
                lblThongkeBinhchon.Text = sbThongke.ToString();
            }
        }
        private void napBinhchon()
        {
            int[] diemBinhchon = new int[] {1,2,3,4,5 };            
            rdlstBinhchon.DataSource = diemBinhchon;
            rdlstBinhchon.DataBind();
            rdlstBinhchon.SelectedValue = "5";
            
        }

        protected void btnBinhchon_Click(object sender, EventArgs e)
        {
            //try
            //{
                int sodiem = Convert.ToInt32(rdlstBinhchon.SelectedValue);
                bool result;
                if (RateBRL.Exist(this.m_newsID))
                {
                    result=RateBRL.Edit(sodiem, this.m_newsID);
                }
                else
                {
                    RateEntity oRate=new RateEntity();
                    oRate.iRate=sodiem;
                    oRate.iCount=1;
                    oRate.iNewsID=this.m_newsID;
                    result=RateBRL.Add(oRate)>0;
                }
                if (result) lblThongbao.Text = Resources.language.camonbinhchon;
                this.napThongke();
            //}
            //catch(Exception ex)
            //{
            //    lblThongbao.Text = ex.Message;
            //}
        }
}
}