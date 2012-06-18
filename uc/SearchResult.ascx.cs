using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using INVI.Entity;
using System.Collections.Generic;
using INVI.Business;
using System.IO;

public partial class uc_SearchResult : System.Web.UI.UserControl
{
    protected int currentPage = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["page"] != null)
            try
            {
                currentPage = Convert.ToInt32(Request.QueryString["page"]);
            }
            catch { }
        bindNews(currentPage);
    }
    
    private void bindNews(int currentPage)
    {
        List<NewsEntity> lstNews = NewsBRL.GetVerified();
        PagedDataSource pds = new PagedDataSource();
        if (Request.QueryString["s"] != null)
        {
            string strSearch = Request.QueryString["s"];
            lstNews = lstNews.FindAll(
            delegate(NewsEntity oNews)
            {
                return oNews.sContent.ToUpper().Contains(strSearch.ToUpper()) || oNews.sTitle.ToUpper().Contains(strSearch.ToUpper());
            }
        );
        }
        else if (Request.QueryString["date"] != null)
        {

            DateTime date = DateTime.Now;
            try
            {
                date = DateTime.ParseExact(Request.QueryString["date"], "dd/MM/yyyy", null);
            }
            catch { }
            lstNews = lstNews.FindAll(
            delegate(NewsEntity oNews)
            {
                return oNews.tDate == date;
            }
            );
        }
        pds.DataSource = lstNews;
        if (pds.Count <= 0)
            lblMessage.Text = "Không có bản ghi nào";
        else
        {
            pds.AllowPaging = true;
            pds.PageSize = 10;
            pds.CurrentPageIndex = currentPage > 0 ? currentPage : 0;
            rptrNews.DataSource = pds;
            rptrNews.DataBind();
            //
            if (Request.QueryString["s"] != null)
            {
                lnkPrev.NavigateUrl = "~/Default.aspx?s=" + Request.QueryString["s"] + "page=" + (currentPage - 1);
                lnkNext.NavigateUrl = "~/Default.aspx?s=" + Request.QueryString["s"] + "page=" + (currentPage + 1);
            }
            if (Request.QueryString["date"] != null)
            {
                lnkPrev.NavigateUrl = "~/Default.aspx?date=" + Request.QueryString["date"] + "page=" + (currentPage - 1);
                lnkNext.NavigateUrl = "~/Default.aspx?date=" + Request.QueryString["date"] + "page=" + (currentPage + 1);
            }

            lnkPrev.Visible = currentPage > 0 ? true : false;
            lnkNext.Visible = currentPage > 0 && currentPage < pds.PageCount ? true : false;
        }
    }
    protected void rptrNews_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            NewsEntity oNews = e.Item.DataItem as NewsEntity;
            Image img = e.Item.FindControl("imgMinhhoa") as Image;
            if (oNews != null && img != null)
            {
                if (File.Exists(Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + oNews.sImage)))
                    img.ImageUrl = ConfigurationManager.AppSettings["UploadPath"] + oNews.sImage;
            }
        }
    }
}
