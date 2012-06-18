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

public partial class uc_ListNewsMoreInCat : System.Web.UI.UserControl
{
    private byte m_pagesize = 8;
    public byte PageSize
    {
        get { return m_pagesize; }
        set { m_pagesize = value; }
    }
    private int m_newsID = 0;
    public int NewsID
    {
        get { return m_newsID; }
        set { m_newsID = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            bindNews();
        }
        catch { }
    }

    private void bindNews()
    {
        //Get List Category From NewsID
        List<NewsCategoryEntity> lstNewsCat = NewsCategoryBRL.GetByiNewsID(m_newsID);
        List<CategoryEntity> lstCat = new List<CategoryEntity>();
        foreach (NewsCategoryEntity oNewsCat in lstNewsCat)
        {
            lstCat.Add(CategoryBRL.GetOne(oNewsCat.iCategoryID));
        }
        //Get List News From List Cat
        List<NewsEntity> lst = new List<NewsEntity>();
        foreach (CategoryEntity oCat in lstCat)
        {
            List<NewsEntity> lstNews = NewsBRL.GetByCategoryID(oCat.iCategoryID);
            foreach (NewsEntity oNews in lstNews)
            {
                if (!lst.Exists(
                    delegate(NewsEntity obj)
                    {
                        return obj.iNewsID == oNews.iNewsID || oNews.iNewsID == m_newsID;
                    }
                ))
                    lst.Add(oNews);
            }
        }
        //Get Verified
        lst = lst.FindAll(
            delegate(NewsEntity oNews)
            {
                return oNews.bVerified;
            }
        );
        //Pageing and Bind to Repeater
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = lst;
        pds.AllowPaging = true;
        pds.PageSize = m_pagesize;
        rptrNewsMoreInCat.DataSource = pds;
        rptrNewsMoreInCat.DataBind();
        lst.Clear();
    }
}
