using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Business;
using INVI.Entity;
using System.IO;
using System.Configuration;
public partial class uc_ucListServices : System.Web.UI.UserControl
{
    private List<NewsEntity> lstNews = new List<NewsEntity>();
    protected void Page_Load(object sender, EventArgs e)
    {
        bindCat();
    }

    private void bindCat()
    {
        int nhomtinID=7;
        string a = "vi-VN";
        if(Session["Lang"]!=null)
            a = Session["Lang"].ToString();
        if (a == "en-US")
        {
            nhomtinID = 8;
        }
        else
        {
            nhomtinID = 7;
        }
        lstNews = NewsBRL.GetByCategoryID(nhomtinID);
        if (lstNews==null || lstNews.Count <= 0) return;

        lstNews = lstNews.FindAll(delegate(NewsEntity oNews)
        {
            return oNews.bVerified == true;
        });
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = lstNews;
        pds.AllowPaging = true;
        if (lstNews.Count > 2)
        {
            pds.PageSize = 2;
            int curpage = 0;
            if (Request.QueryString["p"] != null)
            {
                curpage = Convert.ToInt32(Request.QueryString["p"]);
            }
            else
            {
                curpage = 1;
            }
            pds.CurrentPageIndex = curpage - 1;
            if (curpage == 1 && pds.DataSourceCount > pds.PageSize)
                lblPage.Text = "<strong>1</strong>";
            else if (pds.DataSourceCount == 0)
                lblPage.Text = "";
            else if (curpage > 1 && pds.DataSourceCount > pds.PageSize)
                lblPage.Text = "<a href='Content.aspx?mode=uc&page=ListServices&p=1'>[1]</a>";
            for (int i = 2; i <= pds.PageCount; i++)
            {
                if (i == curpage)
                    lblPage.Text = lblPage.Text + "<strong>[ " + i.ToString() + "]</strong>";
                else
                    lblPage.Text = lblPage.Text + " <a href='Content.aspx?mode=uc&page=ListServices&p=" + i.ToString() + "'>[" + i.ToString() + "]</a>";
            }

        }
        else
        {
            pds.PageSize = 2;
        }
        rptrNewsInHome.DataSource = pds;
        rptrNewsInHome.DataBind();

    }
    protected void rptrNewsInHome_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            {
                Label lblIDNews = e.Item.FindControl("lblIDNews") as Label;
                HyperLink lnkTitle = e.Item.FindControl("lnkTitle") as HyperLink;
                HyperLink lnkImage = e.Item.FindControl("lnkImage") as HyperLink;
                Image imgMinhhoa = e.Item.FindControl("imgMinhhoa") as Image;
                Label lblDesc = e.Item.FindControl("lblDesc") as Label;
                HyperLink lnkChitiet = e.Item.FindControl("lnkChitiet") as HyperLink;
                if (lnkTitle != null && imgMinhhoa != null && lnkChitiet != null && lnkImage != null && lblDesc != null)
                {
                    NewsEntity newsEntity = new NewsEntity();
                    newsEntity = NewsBRL.GetOne(Convert.ToInt32(lblIDNews.Text));
                    lnkTitle.NavigateUrl = "~/Content.aspx?sID=" + newsEntity.iNewsID;
                    lnkChitiet.NavigateUrl = "~/Content.aspx?sID=" + newsEntity.iNewsID;
                    lnkTitle.Text = INVI.INVILibrary.INVIString.GetCuttedString(newsEntity.sTitle, 70);
                    if (File.Exists(Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + newsEntity.sImage)))
                        imgMinhhoa.ImageUrl = ConfigurationManager.AppSettings["UploadPath"] + newsEntity.sImage;
                    else
                    {
                        Panel pnAnh = e.Item.FindControl("pnAnh") as Panel;
                        pnAnh.Visible = false;
                    }
                    lblDesc.Text = INVI.INVILibrary.INVIString.GetCuttedString(newsEntity.sDesc, 150);
                }


            }
        }
    }
    protected void rptrNewsInHome_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}