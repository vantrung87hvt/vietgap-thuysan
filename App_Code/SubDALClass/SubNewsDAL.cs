using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using INVI.DataAccess.Base;
using INVI.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using INVI.DataAccess;
/// <summary>
/// Summary description for SubNewsDAL
/// </summary>
public  class SubNewsDAL:NewsDAL
{
    static SubNewsDAL()
    {
        InitReader();
    }
    public static List<NewsEntity> Search(string tieude, int categoryID, string username, DateTime dateStart, DateTime dateEnd)
    {
        SqlParameter[] arr = new SqlParameter[5];
        arr[0] = new SqlParameter("sTieude", tieude);
        arr[1] = new SqlParameter("FK_CategoryID", categoryID);
        arr[2] = new SqlParameter("sUsername", username);
        arr[3] = new SqlParameter("sNgaydang1", dateStart);
        arr[4] = new SqlParameter("sNgaydang2", dateEnd);
        return GetList("spNews_Search", arr);
    }
    /// <summary>
    /// Demo Get All
    /// </summary>
    /// <returns></returns>
    public static List<NewsEntity> GetByPK()
    {
        return GetList("spNews_Get");
    }
}
