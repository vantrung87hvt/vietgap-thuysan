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

public partial class uc_ListEventNews : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        int nhomtinID;
        try
        {
            nhomtinID = Convert.ToInt32(ConfigurationManager.AppSettings["NhomtinSukien"]);
        }
        catch { throw new Exception("Cấu hình sai nhóm tin sự kiện trong web.config"); }
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = NewsBRL.GetByCategoryID(nhomtinID).FindAll(
            delegate(NewsEntity oNews)
            {
                return oNews.bVerified == true;
            }
        );
        pds.AllowPaging = true;
        pds.PageSize = 3;
        rptrEventNews.DataSource = pds;
        rptrEventNews.DataBind();
    }
}
