using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using INVI.Entity;
using INVI.Business;
using INVI.INVILibrary;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Xml;
/// <summary>
/// Summary description for getData
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class getData : System.Web.Services.WebService {

    public getData () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    
    public string getCosonuoitrongInfo(int iQuanhuyenID)
    {
        DataSet ds = INVI.INVILibrary.INVIHelper.getAllInfo(iQuanhuyenID);
        string[][] JaggedArray = new string[ds.Tables[0].Rows.Count][];
        int i = 0;
        foreach (DataRow rs in ds.Tables[0].Rows)
        {
            JaggedArray[i] = new string[] { rs["sTencoso"].ToString(), rs["Latitude"].ToString(), rs["Longitude"].ToString() };
            i = i + 1;
        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        string strJSON = js.Serialize(JaggedArray);
        return strJSON;
    }
    [WebMethod]
    public string sayHello()
    {
        return "Hello";
    }
    [WebMethod]
    public List<CosonuoitrongEntity> getCosonuoitrong()
    {
        List<CosonuoitrongEntity> lstCosonuoitrong = CosonuoitrongBRL.GetAll();
        return lstCosonuoitrong;
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getCosonuoitrongJSON(int iQuanhuyenID)
    {
        System.Threading.Thread.Sleep(1000);
        DataSet ds = INVI.INVILibrary.INVIHelper.getAllInfo(iQuanhuyenID);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(ds.GetXml());
        String sJSON = INVI.INVILibrary.XML2JSON.XmlToJSON(xmlDoc);
        sJSON = sJSON.Replace(@"\", @"\\");
        return sJSON;
    }
    //private static List<Dictionary<string, object>>
    //    RowsToDictionary(DataTable table)
    //{
    //    List<Dictionary<string, object>> objs =
    //        new List<Dictionary<string, object>>();
    //    foreach (DataRow dr in table.Rows)
    //    {
    //        Dictionary<string, object> drow = new Dictionary<string, object>();
    //        for (int i = 0; i < table.Columns.Count; i++)
    //        {
    //            drow.Add(table.Columns[i].ColumnName, dr[i]);
    //        }
    //        objs.Add(drow);
    //    }

    //    return objs;
    //}

    //public static Dictionary<string, object> ToJson(DataTable table)
    //{
    //    Dictionary<string, object> d = new Dictionary<string, object>();
    //    d.Add(table.TableName, RowsToDictionary(table));
    //    return d;
    //}

    //public static Dictionary<string, object> ToJson(DataSet data)
    //{
    //    Dictionary<string, object> d = new Dictionary<string, object>();
    //    foreach (DataTable table in data.Tables)
    //    {
    //        d.Add(table.TableName, RowsToDictionary(table));
    //    }
    //    return d;
    //}
}
