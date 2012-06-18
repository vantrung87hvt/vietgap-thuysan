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

public partial class uc_ListDocument : System.Web.UI.UserControl
{
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
            bindDoc();
        }
        catch { }
    }
    private void bindDoc()
    {
        List<DocumentEntity> lst = DocumentBRL.GetAll();
        lst.Sort(DocumentEntity.COMPARISON_tDate);
        lst.Reverse();
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = lst;
        pds.AllowPaging = true;
        pds.PageSize = m_pagesize;
        rptrDocument.DataSource = pds;
        rptrDocument.DataBind();
        lst.Clear();
    }
}
