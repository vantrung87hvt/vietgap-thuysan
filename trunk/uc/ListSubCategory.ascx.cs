using INVI.Business;
using INVI.Entity;
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

public partial class uc_ListSubCategory : System.Web.UI.UserControl
{
    private int m_parentID;
    public int ParentID
    {
        get { return m_parentID; }
        set { m_parentID = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        rptrSubCategory.DataSource = CategoryBRL.GetByTopID(m_parentID);
        rptrSubCategory.DataBind();
    }
}
