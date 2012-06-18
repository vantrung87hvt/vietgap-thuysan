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
using INVI.INVILibrary;
using INVI.Business;
using INVI.Entity;
using System.Collections.Generic;
using System.IO;

public partial class uc_ListNews : System.Web.UI.UserControl
{
    private int m_categoryID = 1;
    public int CategoryID
    {
        get { return m_categoryID; }
        set { m_categoryID = value; }
    }
    protected int currentPage=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //CategoryEntity oCat = CategoryBRL.GetOne(m_categoryID);
            //if (oCat != null)
            //    lblCatTitle.Text = oCat.sTitle;
        }
        if (Request.QueryString["page"] != null)
            try
            {
                currentPage = Convert.ToInt32(Request.QueryString["page"]);
            }
            catch { }
        bindNews(currentPage);
    }

    protected String getsTentacgia(int PK_iUserID)
    {
        String sRes = "";
        UserEntity oUser = UserBRL.GetOne(PK_iUserID);
        if (oUser != null)
        {
            sRes = oUser.sUsername + " - ";
        }
        return sRes;
    }

    private void bindNews(int currentPage)
    {
        //Nếu uc đang được gọi ở trang Content thì hiện thị thông tin ảnh lớn >< ngược lại hiển thị thông tin trang chủ
        if (Request.Url.AbsoluteUri.ToString().Contains("Content"))
        {
            string a = "vi-VN";
            if (Session["Lang"] != null)
                a = Session["Lang"].ToString();
            if (a == "en-US")
            {
                m_categoryID = 5;
            }
            else
            {
                m_categoryID = 3;
            }
        }
        PagedDataSource pds = new PagedDataSource();
        List<NewsEntity> lstNew = new List<NewsEntity>();
        List<NewsCategoryEntity> lstNewCate = NewsCategoryBRL.GetByiCategoryID(m_categoryID);
        for (int i = 0; i < lstNewCate.Count; ++i)
        {
            lstNew.Add(NewsBRL.GetOne(lstNewCate[i].iNewsID));
        }
        if (lstNew.Count <= 0)
            return;
        pds.DataSource = lstNew.FindAll(
            delegate(NewsEntity oNews)
            {
                return oNews.bVerified;
            }
        );
        pds.AllowPaging = true;
        pds.PageSize = 10;
        pds.CurrentPageIndex = currentPage > 0 ? currentPage : 0;
        rptrNewsInCat.DataSource = pds;
        rptrNewsInCat.DataBind();
        //
        //lnkPrev.NavigateUrl = "~/Default.aspx?page=" + (currentPage-1);
        //lnkNext.NavigateUrl = "~/Default.aspx?page=" + (currentPage+1);
        lnkPrev.NavigateUrl = Request.Url.AbsoluteUri.ToString() + "?page=" + (currentPage - 1);
        lnkNext.NavigateUrl = Request.Url.AbsoluteUri.ToString() + "?page=" + (currentPage + 1);
        lnkPrev.Visible = currentPage>0?true:false;
        lnkNext.Visible = currentPage!=0 && currentPage < pds.PageCount ? true : false;
    }
    protected void rptrNewsInCat_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
