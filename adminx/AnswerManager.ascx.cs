using INVI.Entity;
using INVI.Business;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace INVI.INVINews.Admin
{
    public partial class PollAnswerManager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!PermissionBRL.CheckPermission("ManagerPoll")) Response.End();
                this.NapListbox();
            }
        }

        public void NapListbox()
        {
            if (Session["PollID"] != null)
            {
                lstbAnswer.Items.Clear();
                int pollID = Convert.ToInt32(Session["PollID"]);
                lstbAnswer.DataSource = PollAnswerBRL.GetByPollID(pollID);
                lstbAnswer.DataTextField = "sAnswer";
                lstbAnswer.DataValueField = "iAnswerID";
                lstbAnswer.DataBind();
            }
        }

        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (Session["PollID"] != null)
                    {
                        PollAnswerEntity entity = new PollAnswerEntity();
                        entity.iCount = 0;
                        entity.iPollID = Convert.ToInt32(Session["PollID"]);
                        entity.sAnswer = txtAdd.Text;
                        PollAnswerBRL.Add(entity);
                        NapListbox();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=AnswerManager';</script>");
                }
            }

          
        }
        protected void lbtnRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstbAnswer.Items.Count; i++)
            {
                if (lstbAnswer.Items[i].Selected)
                {
                    PollAnswerEntity entity = new PollAnswerEntity();
                    entity.iAnswerID = Convert.ToInt32(lstbAnswer.Items[i].Value);
                    PollAnswerBRL.Remove(entity);
                }
            }
            NapListbox();
        }
    }
}