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
using INVI.Business;
using INVI.Entity;
using System.Collections.Generic;

public partial class uc_ListRecentNews : System.Web.UI.UserControl
{
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
        List<NewsEntity> lst = NewsBRL.GetMostView();
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = lst;
        pds.AllowPaging = true;
        pds.PageSize = 8;
        rptrMostViewNews.DataSource = pds;
        rptrMostViewNews.DataBind();
        lst.Clear();
    }
}
