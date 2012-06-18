using INVI.Entity;
using INVI.Business;
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
using System.Collections.Generic;

public partial class uc_ListNewsByTag : System.Web.UI.UserControl
{
    private int m_newsID = 0;
    public int NewsID
    {
        get { return m_newsID; }
        set { m_newsID = value; }
    }
    private byte m_pagesize = 8;
    public byte PageSize
    {
        get { return m_pagesize; }
        set { m_pagesize = value; }
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
        NewsEntity oNews = NewsBRL.GetOne(m_newsID);
        List<NewsEntity> lst = NewsBRL.GetByTag(oNews.sTag);
        lst = lst.FindAll(
            delegate(NewsEntity obj)
            {
                return obj.bVerified;
            }
        );
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = lst;
        pds.AllowPaging = true;
        pds.PageSize = m_pagesize;
        rptrNewsByTag.DataSource = pds;
        rptrNewsByTag.DataBind();
        lst.Clear();
    }
}
