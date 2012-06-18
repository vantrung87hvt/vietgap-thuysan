using INVI.Entity;
using INVI.Business;
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
using System.Collections.Generic;


namespace INVI.INVINews.Module
{
    public partial class Poll : System.Web.UI.UserControl
    {
        private int m_newsID=0;
        public int NewsID
        {
            get
            { return m_newsID; }
            set
            { m_newsID = value; }
        }

        #region Methods
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.napThamdo();
            }
        }

        protected void btnBophieu_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (RepeaterItem item in rptrPoll.Items)
                {
                    Button btn = item.FindControl("btnBophieu") as Button;
                    if (btn.CommandArgument == ((Button)sender).CommandArgument)
                    {
                        RadioButtonList optlPhuongan = item.FindControl("optlPhuongan") as RadioButtonList;
                        int answerID = Convert.ToInt32(optlPhuongan.SelectedValue);
                        PollAnswerBRL.SetAnswer(answerID);
                    }
                }
            }
            catch
            {
            }
        }
        #endregion

        private void napThamdo()
        {
            //Get Thamdo
            List<PollEntity> lstPoll = new List<PollEntity>();
            if (m_newsID == 0)
            {
                
                if (Request.QueryString["catID"] != null)
                {
                    int categoryID;
                    bool result = Int32.TryParse(Request.QueryString["catID"], out categoryID);
                    if (result)
                    {
                        lstPoll = PollBRL.GetByCategoryID(categoryID);
                    }
                }
                if (Request.QueryString["newsID"] != null)
                {
                    int newsID;
                    bool result = Int32.TryParse(Request.QueryString["newsID"], out newsID);
                    if (result)
                    {
                        List<NewsCategoryEntity> lstNewsCat = NewsCategoryBRL.GetByiNewsID(newsID);
                        foreach (NewsCategoryEntity oNewsCat in lstNewsCat)
                        {
                            List<PollEntity> lst = PollBRL.GetByCategoryID(oNewsCat.iCategoryID);
                            foreach (PollEntity enPoll in lst)
                            {
                                if (lstPoll.Exists(
                                    delegate(PollEntity obj)
                                    {
                                        return obj.iPollID == enPoll.iPollID;
                                    }
                                    ))
                                    lstPoll.Add(enPoll);
                            }
                        }
                    }
                }
            }
            else
            {
                lstPoll = PollBRL.GetByNewsID(m_newsID);
            }
            rptrPoll.DataSource = lstPoll;
            rptrPoll.DataBind();

        }

        protected void rptrPoll_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                PollEntity oPoll = e.Item.DataItem as PollEntity;
                Label lblCauhoi = e.Item.FindControl("lblCauhoi") as Label;
                RadioButtonList optlPhuongan = e.Item.FindControl("optlPhuongan") as RadioButtonList;

                lblCauhoi.Text = oPoll.sQuestion;
                // Add Answers
                List<PollAnswerEntity> lstAnswer = PollAnswerBRL.GetByPollID(oPoll.iPollID);
                optlPhuongan.DataSource = lstAnswer;
                optlPhuongan.DataTextField = "sAnswer";
                optlPhuongan.DataValueField = "iAnswerID";
                optlPhuongan.DataBind();
            }
        }
}
}
