using INVI.Entity;
using INVI.Business;
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
namespace INVI.INVINews.Admin
{
    public partial class FeedbackManager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!PermissionBRL.CheckPermission("VerifyFeedback")) Response.End();
            if (!IsPostBack)
                this.napGridView();
        }

        private void napGridView()
        {
            grvFeedback.DataSource = FeedbackBRL.GetAll();
            grvFeedback.DataKeyNames = new string[] { "iFeedbackID","iNewsID" };
            grvFeedback.DataBind();
        }

        protected void grvFeedback_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink lnkNews= e.Row.FindControl("lnkNews") as HyperLink;
                int newsID = Convert.ToInt32(grvFeedback.DataKeys[e.Row.RowIndex].Values["iNewsID"]);
                NewsEntity entity=NewsBRL.GetOne(newsID);
                if (entity != null && lnkNews!=null)
                {
                    lnkNews.Text =getShortOf(entity.sTitle);
                    lnkNews.NavigateUrl = "~/Category.aspx?newsID=" + newsID;
                }
            }
        }

        protected void grvFeedback_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvFeedback.PageIndex = e.NewPageIndex;
            napGridView();
        }
        protected void grvFeedback_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null)
                ViewState["SortDirection"] = "ASC";
            else
            {
                ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
            }
            List<FeedbackEntity> list = FeedbackBRL.GetAll();
            grvFeedback.DataSource = FeedbackEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
            grvFeedback.DataBind();
        }
        protected void lbtnVerify_Click(object sender, EventArgs e)
        {
			LinkButton lbtn = sender as LinkButton;
			if (lbtn.CommandName == "VerifyOne")
			{
				int feedbackID = Convert.ToInt32(lbtn.CommandArgument);
				FeedbackBRL.SetVerify(feedbackID, true);
			}
			else
			{
				foreach (GridViewRow row in grvFeedback.Rows)
				{
					CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
					int feedbackID = Convert.ToInt32(grvFeedback.DataKeys[row.RowIndex].Values["iFeedbackID"]);
					if (chkDelete != null)
					{
						FeedbackBRL.SetVerify(feedbackID, chkDelete.Checked);
					}
				}
			}
            //Nap lai du lieu
            Response.Redirect(Request.Url.ToString());
        }
        protected string getShortOf(Object x)
        {
            if (x.ToString().Length < 50)
                return x.ToString();
            else
                return x.ToString().Substring(0, 50);
        }
    }
}