using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Business;
using INVI.INVILibrary;
using INVI.DataAccess;
using INVI.Entity;
public partial class uc_ucViewFaq : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["faqID"] != null)
            {
                int ifaqID = Convert.ToInt32(Request.QueryString["faqID"].ToString());
                if(ifaqID!=0)
                    loadQuestion(ifaqID);
            }
        }
    }
    private void loadQuestion(int PK_iFaqID)
    {
        try
        {
            FaqEntity oFaq = FaqBRL.GetOne(PK_iFaqID);
            litQuestionContents.Text = oFaq.sQuestion;
            List<FaqAnswersEntity> lstAnswers = FaqAnswersBRL.GetByFK_iFaqID(PK_iFaqID);
            rptrResultFaq.DataSource = lstAnswers;
            rptrResultFaq.DataBind();
            pnlFaq.Visible = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    protected void lnkBack_Click(object sender, EventArgs e)
    {
        
    }
}