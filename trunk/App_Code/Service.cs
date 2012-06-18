using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using INVI.Entity;
using INVI.Business;
using INVI.INVILibrary;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Xml;
using System.Data;
using System.Collections;
/// <summary>
/// Summary description for Service
/// </summary>
[WebService(Namespace = "http://www.vietgap.thanglongsport.vn")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

[System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService {

    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
        
    }

    [WebMethod]
    public void AddLatLon(String sLatLon)
    {
        String[] sData = sLatLon.Split(':');
        String[] aLatLon = sData[0].Split('(');
        int FK_iCosonuoitrongID = Convert.ToInt32(sData[1]);
        for (int i = 1; i < aLatLon.Length; i++)
        {
            aLatLon[i] = aLatLon[i].Substring(0, aLatLon[i].Length - 1);
            String[] arLatLon = aLatLon[i].Split(',');
            ToadoCosonuoiEntity oToado = new ToadoCosonuoiEntity();
            oToado.FK_iCosonuoiID = FK_iCosonuoitrongID;
            oToado.sLat = arLatLon[0];
            oToado.sLon = arLatLon[1];
            ToadoCosonuoiBRL.Add(oToado);
        }
    }

    [WebMethod]
    public List<CosonuoitrongEntity> getCosonuoitrong()
    {
        List<CosonuoitrongEntity> lstCosonuoitrong = CosonuoitrongBRL.GetAll();
        return lstCosonuoitrong;
    }
    [WebMethod]
    public String sayYourname(String sYourname)
    {
        return "Hello, "+sYourname;
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
    public String getCosonuoitrongJSON(int iQuanhuyenID)
    {
        String sJSON = String.Empty;
        try
        {
            DataSet ds = INVI.INVILibrary.INVIHelper.getAllInfo(iQuanhuyenID);
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.LoadXml(ds.GetXml());
            //sJSON = INVI.INVILibrary.XML2JSON.XmlToJSON(xmlDoc);
            //sJSON = sJSON.Replace(@"\", @"\\");
            sJSON = INVI.INVILibrary.XML2JSON.GetJSONString(ds.Tables[0]);
        }
        catch (Exception ex)
        {
            return "";
        }
        return sJSON;
    }
    [WebMethod]
    public String removeLocation(int PK_iCosonuoitrongID)
    {
        String sJSON = String.Empty;
        int iStatus = 0;
        try
        {
            List<ToadoCosonuoiEntity> lstToado = ToadoCosonuoiBRL.GetByFK_iCosonuoiID(PK_iCosonuoitrongID);
            for (int i = 0; i < lstToado.Count; ++i)
            {
                ToadoCosonuoiBRL.Remove(lstToado[i].PK_iToadocosonuoiID);
            }
            sJSON = "{\"tt\":\"OK\"}";
        }
        catch (Exception ex)
        {
            return "";
        }
        return sJSON;
    }
    [WebMethod]
    public String getTonghopTheoTinhJSON(int FK_iTinhID)
    {
        String sJSON = String.Empty;
        try
        {
            DataSet ds = INVI.INVILibrary.INVIHelper.getThongTinTongHopTheoTinh(FK_iTinhID);
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.LoadXml(ds.GetXml());
            //sJSON = INVI.INVILibrary.XML2JSON.XmlToJSON(xmlDoc);
            //sJSON = sJSON.Replace(@"\", @"\\");
            sJSON = INVI.INVILibrary.XML2JSON.GetJSONString(ds.Tables[0]);
        }
        catch (Exception ex)
        {
            return "";
        }
        return sJSON;
    }

    [WebMethod]
    public String getToadoTheoHuyenJSON(int PK_iQuanHuyenID)
    {
        String sJSON = String.Empty;
        try
        {
            DataSet ds = INVI.INVILibrary.INVIHelper.getToaDoTheoHuyen(PK_iQuanHuyenID);
            sJSON = INVI.INVILibrary.XML2JSON.GetJSONString(ds.Tables[0]);
        }
        catch(Exception ex)
        {
            return ex.Message.ToString();
        }
        return sJSON;
    }
    [WebMethod]
    public String getToadoJSON()
    {
        String sJSON = String.Empty;
        try
        {
            DataSet ds = INVI.INVILibrary.INVIHelper.getToaDoCanuoc();
            sJSON = INVI.INVILibrary.XML2JSON.GetJSONString(ds.Tables[0]);
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
        return sJSON;
    }
    [WebMethod]
    public String checkTontaiSodo(int PK_iCosonuoitrongID)
    {
        String sRes = "";
        try
        {
            List<ToadoCosonuoiEntity> lstToado = ToadoCosonuoiBRL.GetByFK_iCosonuoiID(PK_iCosonuoitrongID);
            if (lstToado.Count > 0)
            {
                sRes = "{\"tt\":\"YES\"}";
            }
            else
            {
                sRes = "{\"tt\":\"NO\"}";
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
        return sRes;
    }
    [WebMethod]
    public String getToadoTheoCosonuoitrongIDJSON(int FK_iCosonuoitrongID)
    {
        String sJSON = String.Empty;
        try
        {
            List<ToadoCosonuoiEntity> lstToadoCosonuoi = ToadoCosonuoiBRL.GetByFK_iCosonuoiID(FK_iCosonuoitrongID);
            if (lstToadoCosonuoi != null && lstToadoCosonuoi.Count > 0)
                sJSON = "true";
            else
                sJSON = "false";
            //sJSON = INVI.INVILibrary.XML2JSON.GetJSONString(ds.Tables[0]);
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
        return sJSON;
    }
    [WebMethod]
    public String getTonghopTheoISO_3166JSON(string ISO_3166)
    {
        String sJSON = String.Empty;
        try
        {
            DataSet ds = INVI.INVILibrary.INVIHelper.getThongTinTongHopTheoTinh(ISO_3166);
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.LoadXml(ds.GetXml());
            //sJSON = INVI.INVILibrary.XML2JSON.XmlToJSON(xmlDoc);
            //sJSON = sJSON.Replace(@"\", @"\\");
            sJSON = INVI.INVILibrary.XML2JSON.GetJSONString(ds.Tables[0]);
        }
        catch (Exception ex)
        {
            return "";
        }
        return sJSON;
    }
    //Thử nghiệm hiện popup thông tin tổ chức
    [WebMethod, ScriptMethod]
    public String getAjaxTochucchungnhan()
    {
        //return "liem -------";
        //if (PK_iTochucchungnhanID == "")
        //    return "";
        //int iPK_iTochucchungnhanID = int.Parse(PK_iTochucchungnhanID);
        TochucchungnhanEntity oTochuc = TochucchungnhanBRL.GetOne(7);

        System.Text.StringBuilder _sb = new System.Text.StringBuilder();

        _sb.Append("<b>Tên: </b>").Append(oTochuc.sTochucchungnhan);
        _sb.Append("<br/>");
        _sb.Append("<b>Địa chỉ: </b>").Append(oTochuc.sDiachi);
        _sb.Append("<br/>");
        _sb.Append("<b>Thông tin khác:</b><br/>");
        _sb.Append(oTochuc.sEmail);

        return _sb.ToString();
    }
    [WebMethod]
    public String getHuyenJSON(string PK_iTinhID)
    {
        String sJSON = String.Empty;
        try
        {
            int iPK_iTinhID = int.Parse(PK_iTinhID);
            DataSet ds = INVI.INVILibrary.INVIHelper.getHuyenTheoTinh(iPK_iTinhID);
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.LoadXml(ds.GetXml());
            //sJSON = INVI.INVILibrary.XML2JSON.XmlToJSON(xmlDoc);
            //sJSON = sJSON.Replace(@"\", @"\\");
            sJSON = INVI.INVILibrary.XML2JSON.GetJSONString(ds.Tables[0]);
        }
        catch (Exception ex)
        {
            return "";
        }
        return sJSON;
    }
}
