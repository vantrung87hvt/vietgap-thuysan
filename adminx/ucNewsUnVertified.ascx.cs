using INVI.Entity;
using INVI.Business;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace INVI.INVINews.Admin
{
    public partial class NewsUnVertified : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.napGridView();
        }
        private void napGridView()
        {
            List<NewsEntity> list = NewsBRL.GetAll();
            list=list.FindAll(
            delegate(NewsEntity oNews)
            {
                return oNews.bVerified==false;
            }
            );
            grvNews.DataSource = NewsEntity.Sort(list, "tDate", "DESC");
            grvNews.DataKeyNames = new string[] { "iNewsID" };

            grvNews.DataBind();
        }

        protected void grvNews_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void grvNews_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int newsID = Convert.ToInt32(grvNews.DataKeys[e.NewSelectedIndex].Values["iNewsID"]);
            Session["NewsID"] = newsID.ToString(); ;
            Response.Redirect("~/adminx/Default.aspx?page=NewsUpdate");
        }

        protected void grvNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvNews.PageIndex = e.NewPageIndex;
            napGridView();
        }
        protected void grvNews_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null)
                ViewState["SortDirection"] = "ASC";
            else
            {
                ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
            }
            List<NewsEntity> list = NewsBRL.GetAll();
            list=list.FindAll(
            delegate(NewsEntity oNews)
            {
                return oNews.bVerified;
            }
            );
            grvNews.DataSource = NewsEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
            grvNews.DataBind();
        }
        protected void lbtnPoll_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            if (lbtn != null)
            {
                Session["NewsID"] = lbtn.CommandArgument;
                Response.Redirect("~/adminx/Default.aspx?page=PollManager");
            }
        }
        protected void lbtnVerify_Click(object sender, EventArgs e)
        {
            if (!PermissionBRL.CheckPermission("VerifyNews")) Response.End();
            foreach (GridViewRow row in grvNews.Rows)
            {
                CheckBox chk = row.FindControl("chkVerify") as CheckBox;
                int newsID = Convert.ToInt32(grvNews.DataKeys[row.RowIndex].Values["iNewsID"]);
                if (chk != null)
                {
                    NewsBRL.SetVerify(newsID, chk.Checked);
                }
            }
            //Nap lai du lieu
            Response.Redirect(Request.Url.ToString());
        }
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
                try
                {
                    if (!PermissionBRL.CheckPermission("DeleteNews")) Response.End();
                    foreach (GridViewRow row in grvNews.Rows)
                    {
                        CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                        if (chkDelete != null && chkDelete.Checked)
                        {
                            int newsID = Convert.ToInt32(grvNews.DataKeys[row.RowIndex].Values["iNewsID"]);
                            NewsEntity oNews = new NewsEntity();
                            oNews.iNewsID = newsID;
                            NewsBRL.Remove(oNews);
                            napGridView();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=NewsUnVertified';</script>");
                }
        }
        protected void btnSearchByID_Click(object sender, EventArgs e)
        {
            string strSearch = txtSearchByID.Text;
            int iNewID = 0;
            if (txtID.Text.Length == 0 || txtID.Text == "")
                iNewID = 0;
            else iNewID = Int16.Parse(txtID.Text);
            List<NewsEntity> lstNews = NewsBRL.GetAll();
            if (iNewID == 0)
            {
                lstNews = lstNews.FindAll(
                delegate(NewsEntity oNews)
                {
                    return oNews.sContent.ToUpper().Contains(strSearch.ToUpper()) || oNews.sTitle.ToUpper().Contains(strSearch.ToUpper()) && oNews.bVerified == false;
                }
                );
            }
            else
            {
                lstNews = lstNews.FindAll(
                delegate(NewsEntity oNews)
                {
                    return oNews.iNewsID == iNewID && oNews.bVerified == false;
                }
                );
            }
            lblThongbao.Text = "";
            grvNews.DataSource = lstNews;
            grvNews.DataKeyNames = new string[] { "iNewsID" };
            grvNews.DataBind();

        }
        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            napGridView();
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