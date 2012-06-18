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

public partial class uc_ListNewsByCatID : System.Web.UI.UserControl
{
    private int m_catID = 0;
    public int CategoryID
    {
        get { return m_catID; }
        set { m_catID = value; }
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
        List<NewsEntity> lst = NewsBRL.GetByCategoryID(m_catID);
        lst = lst.FindAll(
            delegate(NewsEntity oNews)
            {
                return oNews.bVerified;
            }
        );
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = lst;
        pds.AllowPaging = true;
        pds.PageSize = m_pagesize;
        rptrNewsByCatID.DataSource = pds;
        rptrNewsByCatID.DataBind();
        lst.Clear();
    }
}
