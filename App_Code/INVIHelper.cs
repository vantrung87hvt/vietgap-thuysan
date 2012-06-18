using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Net.Mail;
using System.Globalization;
using System.Threading;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

using Microsoft.ApplicationBlocks.Data;
using System.Xml;
using System.Globalization;
using System.Collections;
/// <summary>
/// Summary description for INVIHelper
/// </summary>
namespace INVI.INVILibrary
{
    public class INVIHelper
    {
        public INVIHelper()
        {
        }
        public static void PrepareGridViewForExport(Control gv)
        {
            LinkButton lb = new LinkButton();
            Literal l = new Literal();
            string name = String.Empty;
            for (int i = 0; i < gv.Controls.Count; i++)
            {
                if (gv.Controls[i].GetType() == typeof(LinkButton))
                {
                    l.Text = (gv.Controls[i] as LinkButton).Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }
                else if (gv.Controls[i].GetType() == typeof(DropDownList))
                {
                    l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }
                else if (gv.Controls[i].GetType() == typeof(CheckBox))
                {
                    l.Text = (gv.Controls[i] as CheckBox).Checked ? "True" : "False";
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }
                if (gv.Controls[i].HasControls())
                {
                    PrepareGridViewForExport(gv.Controls[i]);
                }
            }
        }
        public static string ReadFile(string FileName)
        {
            try
            {
                String FILENAME = System.Web.HttpContext.Current.Server.MapPath(FileName);
                StreamReader objStreamReader = File.OpenText(FILENAME);
                String contents = objStreamReader.ReadToEnd();
                return contents;
            }
            catch (Exception ex)
            {

            }
            return "";
        }
        public static void Send_Email(string SendTo, string Subject, string Body)
        {
            try
            {
                //MailMessage mail = new MailMessage();
                //SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["smailcontact"]);
                //mail.From = new MailAddress(ConfigurationManager.AppSettings["mailcontact"]);
                //mail.To.Add(SendTo);
                //mail.Subject = Subject;
                //mail.Body = Body.Replace("\n", "<br />");
                //mail.IsBodyHtml = true;
                //SmtpServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings["pomailcontact"]);
                //SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["mailcontact"], ConfigurationManager.AppSettings["pmailcontact"]);
                //SmtpServer.EnableSsl = true;
                //SmtpServer.Send(mail);
                clsSendmail sMail = new clsSendmail();
                sMail.SmtpPort = 587;
                sMail.SmtpServer = "smtp.gmail.com";
                sMail.SmtpUser = "vietgap2012";
                sMail.SmtpPassword = "vietgap2012";
                sMail.SmtpMailFrom = "vietgap2012@gmail.com";
                sMail.SendMail(SendTo, Subject, Body,false);
            }
            catch
            {

            }
        }  
        public static int[] fillColums(int iSocot)
        {
            int[] icolumn = new int[iSocot];
            for (int i = 0; i < iSocot; i++)
                icolumn[i] = i;
            return icolumn;
        }
        public static DataSet getToaDoTheoHuyen(int FK_iHuyenID)
        {
            SqlCommand cmCosonuoitrong = null;
            SqlConnection cnCoso = null;
            SqlDataAdapter daCoso = null;
            try
            {
                cnCoso = new SqlConnection(ConfigurationManager.ConnectionStrings["db_NewsConnectionString"].ToString());
                cmCosonuoitrong = new SqlCommand("sp_tblToadoCosonuoitrong_GetTheoHuyen", cnCoso);
                cmCosonuoitrong.CommandType = CommandType.StoredProcedure;
                cmCosonuoitrong.Parameters.Add(new SqlParameter("@PK_iQuanHuyenID", FK_iHuyenID));
                daCoso = new SqlDataAdapter(cmCosonuoitrong);
                DataSet ds = new DataSet();
                daCoso.Fill(ds, "tblToado");
                if (daCoso != null)
                    return ds;
                else
                    return null;
            }
            catch(Exception e)
            {
                return null;
            }
            finally
            {
                cnCoso.Close();
                cnCoso.Dispose();
                cmCosonuoitrong.Dispose();
                daCoso.Dispose();
            }
        }
        public static DataSet getToaDoCanuoc()
        {
            SqlCommand cmCosonuoitrong = null;
            SqlConnection cnCoso = null;
            SqlDataAdapter daCoso = null;
            try
            {
                cnCoso = new SqlConnection(ConfigurationManager.ConnectionStrings["db_NewsConnectionString"].ToString());
                cmCosonuoitrong = new SqlCommand("sp_tblToadoCosonuoitrong_GetAll", cnCoso);
                cmCosonuoitrong.CommandType = CommandType.StoredProcedure;
                daCoso = new SqlDataAdapter(cmCosonuoitrong);
                DataSet ds = new DataSet();
                daCoso.Fill(ds, "tblToado");
                if (daCoso != null)
                    return ds;
                else
                    return null;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                cnCoso.Close();
                cnCoso.Dispose();
                cmCosonuoitrong.Dispose();
                daCoso.Dispose();
            }
        }
        public static DataSet getThongTinTongHopTheoTinh(int FK_iTinhID)
        {
            SqlCommand cmCosonuoitrong = null;
            SqlConnection cnCoso = null;
            SqlDataAdapter daCoso = null;
            try
            {
                cnCoso = new SqlConnection(ConfigurationManager.ConnectionStrings["db_NewsConnectionString"].ToString());
                cmCosonuoitrong = new SqlCommand("spCosonuoitrong_tongHopthongtinTheoTinh", cnCoso);
                cmCosonuoitrong.CommandType = CommandType.StoredProcedure;
                cmCosonuoitrong.Parameters.Add(new SqlParameter("@FK_iTinhID", FK_iTinhID));
                daCoso = new SqlDataAdapter(cmCosonuoitrong);
                DataSet ds = new DataSet();
                daCoso.Fill(ds, "tblCosonuoitrong");
                if (daCoso != null)
                    return ds;
                else
                    return null;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                cnCoso.Close();
                cnCoso.Dispose();
                cmCosonuoitrong.Dispose();
                daCoso.Dispose();
            }
        }
        public static DataSet getThongTinTongHopTheoTinh(string ISO_3166)
        {
            SqlCommand cmCosonuoitrong = null;
            SqlConnection cnCoso = null;
            SqlDataAdapter daCoso = null;
            try
            {
                cnCoso = new SqlConnection(ConfigurationManager.ConnectionStrings["db_NewsConnectionString"].ToString());
                cmCosonuoitrong = new SqlCommand("spCosonuoitrong_getThongtinTonghoptheoDoituongnuoiByISO3166", cnCoso);
                cmCosonuoitrong.CommandType = CommandType.StoredProcedure;
                cmCosonuoitrong.Parameters.Add(new SqlParameter("@sISO31662", ISO_3166));
                daCoso = new SqlDataAdapter(cmCosonuoitrong);
                DataSet ds = new DataSet();
                daCoso.Fill(ds, "tblCosonuoitrong");
                if (daCoso != null)
                    return ds;
                else
                    return null;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                cnCoso.Close();
                cnCoso.Dispose();
                cmCosonuoitrong.Dispose();
                daCoso.Dispose();
            }
        }
        public static DataSet getHuyenTheoTinh(int PK_iTinhID)
        {
            SqlCommand cmHuyen = null;
            SqlConnection cnHuyen = null;
            SqlDataAdapter daHuyen = null;
            try
            {
                cnHuyen = new SqlConnection(ConfigurationManager.ConnectionStrings["db_NewsConnectionString"].ToString());
                cmHuyen = new SqlCommand("spQuanHuyen_GetByFK_FK_iTinhThanhID", cnHuyen);
                cmHuyen.CommandType = CommandType.StoredProcedure;
                cmHuyen.Parameters.Add(new SqlParameter("@FK_iTinhThanhID", PK_iTinhID));
                daHuyen = new SqlDataAdapter(cmHuyen);
                DataSet ds = new DataSet();
                daHuyen.Fill(ds, "tblHuyen");
                if (daHuyen != null)
                    return ds;
                else
                    return null;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                cnHuyen.Close();
                cnHuyen.Dispose();
                cmHuyen.Dispose();
                daHuyen.Dispose();
            }
        }
        public static void ExportToExcel(string fileName, DataTable dtb)
        {
            HttpContext.Current.Response.ContentType = "application/csv";
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}.xls", fileName));
//            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xls", sFilename));
            HttpContext.Current.Response.ContentEncoding = Encoding.Unicode;
            HttpContext.Current.Response.BinaryWrite(Encoding.Unicode.GetPreamble());
            try
            {

                StringBuilder sb = new StringBuilder();
                //Add Header
                int[] icolumn = fillColums(dtb.Columns.Count);
                for (int count = 0; count < icolumn.Length; count++)
                {
                    if (dtb.Columns[icolumn[count]].ColumnName != null)
                        //thích thì định dạng ở đây
                        sb.Append(dtb.Columns[icolumn[count]].ColumnName);
                    if (count < icolumn.Length - 1)
                    {
                        sb.Append("\t");
                    }
                }
                HttpContext.Current.Response.Write(sb.ToString() + "\n");
                HttpContext.Current.Response.Flush();
                //Append Data
                int soDem = 0;
                while (dtb.Rows.Count >= soDem + 1)
                {
                    sb = new StringBuilder();

                    for (int col = 0; col < icolumn.Length - 1; col++)
                    {
                        if (dtb.Rows[soDem][icolumn[col]] != null)
                            sb.Append(dtb.Rows[soDem][icolumn[col]].ToString().Replace(",", " "));
                        sb.Append("\t");
                    }
                    if (dtb.Rows[soDem][dtb.Columns.Count - 1] != null)
                        sb.Append(dtb.Rows[soDem][dtb.Columns.Count - 1].ToString().Replace(",", " "));

                    HttpContext.Current.Response.Write(sb.ToString() + "\n");
                    HttpContext.Current.Response.Flush();
                    soDem = soDem + 1;
                }

            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
            }

            dtb.Dispose();
            HttpContext.Current.Response.End();
        }
        public static DataTable getAllCosonuoitrong()
        {
            DataTable dt = null;
            SqlCommand cmCosonuoitrong = null;
            SqlConnection cnCoso = null;
            SqlDataAdapter daCoso = null;
            try
            {
                cnCoso = new SqlConnection(ConfigurationManager.ConnectionStrings["db_NewsConnectionString"].ToString());
                cmCosonuoitrong = new SqlCommand("spCosonuoitrong_getAllInformation", cnCoso);
                daCoso = new SqlDataAdapter(cmCosonuoitrong);
                dt = new DataTable();
                daCoso.Fill(dt);
            }
            catch
            {

            }
            finally
            {
                cnCoso.Close();
                cnCoso.Dispose();
                cmCosonuoitrong.Dispose();
                daCoso.Dispose();
            }
            return dt;
        }
        
        public static DataTable getCosonuoitrongThongke(int iTinhID, int iDoituongID)
        {
            DataTable dt = null;
            SqlCommand cmCosonuoitrong = null;
            SqlConnection cnCoso = null;
            SqlDataAdapter daCoso = null;
            try
            {
                cnCoso = new SqlConnection(ConfigurationManager.ConnectionStrings["db_NewsConnectionString"].ToString());
                cmCosonuoitrong = new SqlCommand("spCosonuoitrongThongketheoDoiTuongnuoi", cnCoso);
                cmCosonuoitrong.CommandType = CommandType.StoredProcedure;
                cmCosonuoitrong.Parameters.Add(new SqlParameter("@FK_iDoituongnuoiID",iDoituongID));
                cmCosonuoitrong.Parameters.Add(new SqlParameter("@FK_iTinhID", iTinhID));
                daCoso = new SqlDataAdapter(cmCosonuoitrong);
                dt = new DataTable();
                daCoso.Fill(dt);
            }
            catch
            {

            }
            finally
            {
                cnCoso.Close();
                cnCoso.Dispose();
                cmCosonuoitrong.Dispose();
                daCoso.Dispose();
            }
            return dt;
        }
        public static DataSet getAllInfo(int iQuanHuyenID)
        {
            SqlCommand cmCosonuoitrong = null;
            SqlConnection cnCoso = null;
            SqlDataAdapter daCoso = null;
            try
            {
                cnCoso = new SqlConnection(ConfigurationManager.ConnectionStrings["db_NewsConnectionString"].ToString());
                cmCosonuoitrong = new SqlCommand("spCosonuoitrong_getAllInfoCross", cnCoso);
                cmCosonuoitrong.CommandType = CommandType.StoredProcedure;
                cmCosonuoitrong.Parameters.Add(new SqlParameter("@FK_iQuanHuyenID", iQuanHuyenID));
                daCoso = new SqlDataAdapter(cmCosonuoitrong);
                DataSet ds = new DataSet();
                daCoso.Fill(ds,"tblCosonuoitrong");
                if (daCoso != null)
                    return ds;
                else
                    return null;
            }
            catch(Exception e)
            {
                return null;
            }
            finally
            {
                cnCoso.Close();
                cnCoso.Dispose();
                cmCosonuoitrong.Dispose();
                daCoso.Dispose();
            }
        }
        public static void UploadImage(FileUpload up)
        {
            if (!up.HasFile)
                throw new Exception("Chưa chọn file");
            if (!up.PostedFile.ContentType.Contains("image"))
                throw new Exception("Không phải file ảnh");
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["UploadPath"])))
                throw new Exception("Không tìm thấy thư mục để upload");
            up.SaveAs(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + up.FileName));
        }
    }
    public static class UrlBuilder
    {
        public static string GetCurrentUrl()
        {
            string url = HttpContext.Current.Request.Url.AbsolutePath;
            if (url.EndsWith("?") || url.EndsWith("&"))
                return url;
            if (url.Contains("?"))
                url += "&";
            else
                url += "?";
            return url;
        }
    }
    public static class JsonMethods
    {
        private static List<Dictionary<string, object>>
            RowsToDictionary(DataTable table)
        {
            List<Dictionary<string, object>> objs =
                new List<Dictionary<string, object>>();
            foreach (DataRow dr in table.Rows)
            {
                Dictionary<string, object> drow = new Dictionary<string, object>();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    drow.Add(table.Columns[i].ColumnName, dr[i]);
                }
                objs.Add(drow);
            }

            return objs;
        }
        
        public static Dictionary<string, object> ToJson(DataTable table)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add(table.TableName, RowsToDictionary(table));
            return d;
        }

        public static Dictionary<string, object> ToJson(DataSet data)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            foreach (DataTable table in data.Tables)
            {
                d.Add(table.TableName, RowsToDictionary(table));
            }
            return d;
        }
    }
    public static class EmailSender
    {
        public static void Send(string from, string to, string subject, string content)
        {

        }
    }
    public static class MessageBox
    {
        public static void Show(string content)
        {
            string alert = "<script type='text/javascript'>alert('" + content + "')</script>";
            HttpContext.Current.Response.Write(alert);
        }
    }
    public static class MultiLang
    {
        public static void Init()
        {
            HttpContext context = HttpContext.Current;
            string lang = "vi-VN";
            if (context.Request.Cookies["lang"] != null)
                lang = context.Request.Cookies["lang"].Value;
            CultureInfo ci = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
        public enum Language
        {
            VietNam = 1,
            English = 2,
            Unknown = 3,
        }
        public static Language GetCurrentLanguage()
        {
            if (HttpContext.Current.Request.Cookies["lang"] == null)
                return Language.VietNam;
            switch (HttpContext.Current.Request.Cookies["lang"].Value)
            {
                case "vi-VN":
                    return Language.VietNam;
                    break;
                case "en-US":
                    return Language.English;
                    break;
                default:
                    return Language.Unknown;
            }
        }
        
        public static bool IsVN()
        {
            return GetCurrentLanguage() == Language.VietNam;
        }
        public static bool IsEN()
        {
            return GetCurrentLanguage() == Language.English;
        }
    }
    public class Counter
    {
        public static void Up()
        {
            try
            {

                string filepath = HttpContext.Current.Server.MapPath("~/counter.log");
                if (File.Exists(filepath))
                {
                    string c = File.ReadAllText(filepath);
                    int count;
                    bool result = Int32.TryParse(c, out count);
                    if (!result)
                        count = 0;
                    count++;
                    File.WriteAllText(filepath, count.ToString());
                }
                else
                {
                    //File.Create(filepath);
                    File.WriteAllText(filepath, "123");
                }
            }
            catch { }
        }
        public static string GetCounter()
        {
            try
            {
                string filepath = HttpContext.Current.Server.MapPath("~/counter.log");
                int count = 0;
                if (File.Exists(filepath))
                {
                    string c = File.ReadAllText(filepath);
                    bool result = Int32.TryParse(c, out count);
                    if (!result)
                        count = 0;
                }
                else
                    count = 0;
                return count.ToString();
            }
            catch { return "0"; }
        }
    }
    public class INVIDateTime
    {
        public static string GetDateVN(DateTime dt)
        {
            string thu = "";
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    thu = "Thứ Hai";
                    break;
                case DayOfWeek.Tuesday:
                    thu = "Thứ Ba";
                    break;
                case DayOfWeek.Wednesday:
                    thu = "Thứ Tư";
                    break;
                case DayOfWeek.Thursday:
                    thu = "Thứ Năm";
                    break;
                case DayOfWeek.Friday:
                    thu = "Thứ Sáu";
                    break;
                case DayOfWeek.Saturday:
                    thu = "Thứ Bảy";
                    break;
                case DayOfWeek.Sunday:
                    thu = "Chủ nhật";
                    break;
            }
            return thu;
        }
    }
    public class INVIString
    {
        public static string GetCuttedString(string strOriginal, int length)
        {
            if (strOriginal.Length <= length)
                return strOriginal;
            else
            {
                int i = length;
                //throw new Exception(strOriginal.Substring(i,1));
                while (strOriginal.Substring(i, 1) != " " && i < strOriginal.Length - 1)
                {
                    i++;
                }
                return strOriginal.Substring(0, i + 1) + "...";
            }
        }
        public static string Replace(string str)
        {

            return System.Text.RegularExpressions.Regex.Replace(str, @"\s+", "");

        }

    }
    public class INVISecurity
    {
        public static string MD5(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] arrByteText = Encoding.UTF8.GetBytes(text);
            byte[] arrByteMD5=md5.ComputeHash(arrByteText);
            return BitConverter.ToString(arrByteMD5).Replace("-","");
        }
        
    }
    public class XML2JSON
    {
        public static string XmlToJSON(XmlDocument xmlDoc)
        {
            StringBuilder sbJSON = new StringBuilder();
            sbJSON.Append("{ ");
            XmlToJSONnode(sbJSON, xmlDoc.DocumentElement, true);
            sbJSON.Append("}");
            return sbJSON.ToString();
        }
        public static string GetJSONString(DataTable Dt)
        {

            string[] StrDc = new string[Dt.Columns.Count];

            string HeadStr = string.Empty;
            for (int i = 0; i < Dt.Columns.Count; i++)
            {

                StrDc[i] = Dt.Columns[i].Caption;
                HeadStr += "\"" + StrDc[i] + "\" : \"" + StrDc[i] + i.ToString() + "¾" + "\",";

            }

            HeadStr = HeadStr.Substring(0, HeadStr.Length - 1);
            StringBuilder Sb = new StringBuilder();

            Sb.Append("{\"" + Dt.TableName + "\" : [");
            for (int i = 0; i < Dt.Rows.Count; i++)
            {

                string TempStr = HeadStr;

                Sb.Append("{");
                for (int j = 0; j < Dt.Columns.Count; j++)
                {

                    TempStr = TempStr.Replace(Dt.Columns[j] + j.ToString() + "¾", Dt.Rows[i][j].ToString());

                }
                Sb.Append(TempStr + "},");

            }
            Sb = new StringBuilder(Sb.ToString().Substring(0, Sb.ToString().Length - 1));

            Sb.Append("]}");
            return Sb.ToString();

        }
        //  XmlToJSONnode:  Output an XmlElement, possibly as part of a higher array
        private static void XmlToJSONnode(StringBuilder sbJSON, XmlElement node, bool showNodeName)
        {
            if (showNodeName)
                sbJSON.Append("\"" + SafeJSON(node.Name) + "\": ");
            sbJSON.Append("{");
            // Build a sorted list of key-value pairs
            //  where   key is case-sensitive nodeName
            //          value is an ArrayList of string or XmlElement
            //  so that we know whether the nodeName is an array or not.
            SortedList childNodeNames = new SortedList();

            //  Add in all node attributes
            if (node.Attributes != null)
                foreach (XmlAttribute attr in node.Attributes)
                    StoreChildNode(childNodeNames, attr.Name, attr.InnerText);

            //  Add in all nodes
            foreach (XmlNode cnode in node.ChildNodes)
            {
                if (cnode is XmlText)
                    StoreChildNode(childNodeNames, "value", cnode.InnerText);
                else if (cnode is XmlElement)
                    StoreChildNode(childNodeNames, cnode.Name, cnode);
            }

            // Now output all stored info
            foreach (string childname in childNodeNames.Keys)
            {
                ArrayList alChild = (ArrayList)childNodeNames[childname];
                if (alChild.Count == 1)
                    OutputNode(childname, alChild[0], sbJSON, true);
                else
                {
                    sbJSON.Append(" \"" + SafeJSON(childname) + "\": [ ");
                    foreach (object Child in alChild)
                        OutputNode(childname, Child, sbJSON, false);
                    sbJSON.Remove(sbJSON.Length - 2, 2);
                    sbJSON.Append(" ], ");
                }
            }
            sbJSON.Remove(sbJSON.Length - 2, 2);
            sbJSON.Append(" }");
        }

        //  StoreChildNode: Store data associated with each nodeName
        //                  so that we know whether the nodeName is an array or not.
        private static void StoreChildNode(SortedList childNodeNames, string nodeName, object nodeValue)
        {
            // Pre-process contraction of XmlElement-s
            if (nodeValue is XmlElement)
            {
                // Convert  <aa></aa> into "aa":null
                //          <aa>xx</aa> into "aa":"xx"
                XmlNode cnode = (XmlNode)nodeValue;
                if (cnode.Attributes.Count == 0)
                {
                    XmlNodeList children = cnode.ChildNodes;
                    if (children.Count == 0)
                        nodeValue = null;
                    else if (children.Count == 1 && (children[0] is XmlText))
                        nodeValue = ((XmlText)(children[0])).InnerText;
                }
            }
            // Add nodeValue to ArrayList associated with each nodeName
            // If nodeName doesn't exist then add it
            object oValuesAL = childNodeNames[nodeName];
            ArrayList ValuesAL;
            if (oValuesAL == null)
            {
                ValuesAL = new ArrayList();
                childNodeNames[nodeName] = ValuesAL;
            }
            else
                ValuesAL = (ArrayList)oValuesAL;
            ValuesAL.Add(nodeValue);
        }

        private static void OutputNode(string childname, object alChild, StringBuilder sbJSON, bool showNodeName)
        {
            if (alChild == null)
            {
                if (showNodeName)
                    sbJSON.Append("\"" + SafeJSON(childname) + "\": ");
                sbJSON.Append("null");
            }
            else if (alChild is string)
            {
                if (showNodeName)
                    sbJSON.Append("\"" + SafeJSON(childname) + "\": ");
                string sChild = (string)alChild;
                sChild = sChild.Trim();
                sbJSON.Append("\"" + SafeJSON(sChild) + "\"");
            }
            else
                XmlToJSONnode(sbJSON, (XmlElement)alChild, showNodeName);
            sbJSON.Append(", ");
        }

        // Make a string safe for JSON
        private static string SafeJSON(string sIn)
        {
            StringBuilder sbOut = new StringBuilder(sIn.Length);
            foreach (char ch in sIn)
            {
                if (Char.IsControl(ch) || ch == '\'')
                {
                    int ich = (int)ch;
                    sbOut.Append(@"\u" + ich.ToString("x4"));
                    continue;
                }
                else if (ch == '\"' || ch == '\\' || ch == '/')
                {
                    sbOut.Append('\\');
                }
                sbOut.Append(ch);
            }
            return sbOut.ToString();
        }
    }
    public class INVIFile
    {
        public static string GetContentType(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".doc":
                case ".docx":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".rar":
                    return "application/x-rar-compressed";
                case ".xls":
                case ".csv":
                case ".xlsx":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }
    }
}