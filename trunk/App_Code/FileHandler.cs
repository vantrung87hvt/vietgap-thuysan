using System;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.SessionState;

public class FileHandler : IHttpHandler,IReadOnlySessionState
{

    public void ProcessRequest(HttpContext context)
    {
        string strFileName = string.Empty;
        string strMode = string.Empty;
        if (context.Request.QueryString["FileName"] != null)
        {
            strFileName = context.Request.QueryString["FileName"];
            ReadFile(strFileName.Trim(), context);
        }
        else
        {
            string strResponse = "error";
            string strMIMEType = string.Empty;
            try
            {

                strFileName = Path.GetFileName(context.Request.Files[0].FileName);
                string strExtension = Path.GetExtension(context.Request.Files[0].FileName).ToLower();
                switch (strExtension)
                {
                    case ".gif":
                        strMIMEType = "image/gif";
                        break;

                    case ".jpg":
                        strMIMEType = "image/jpeg";
                        break;

                    case ".png":
                        strMIMEType = "image/png";
                        break;

                    case ".mp3":
                        strMIMEType = "audio/mp3";
                        break;

                    case ".flv":
                        strMIMEType = "video/flv";
                        break;
                    case ".mp4":
                        strMIMEType = "video/mp4";
                        break;
                    default:
                        strMIMEType = string.Empty;
                        return;
                }
                byte[] docBytes = new byte[context.Request.Files[0].InputStream.Length];
                context.Request.Files[0].InputStream.Read(docBytes, 0, docBytes.Length);
                UploadFile(context,docBytes, strMIMEType, strFileName);
                strResponse = "Thành công";


            }
            catch
            {

            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(strResponse);
        }
    }

    public void UploadFile(HttpContext context,byte[] bFile, string strMIMEType, string strFileName)
    {
        try
        {
            FileStream newFile = new FileStream(HttpContext.Current.Server.MapPath("~/Upload/Videos/"+strFileName), FileMode.Create);
            newFile.Write(bFile, 0, bFile.Length);
            newFile.Close();
            context.Session["uploadOK"] = true;
            context.Session["strUploadedFile"] = HttpContext.Current.Server.MapPath("~/Upload/Videos/" + strFileName);
        }
        catch (Exception ex)
        {
            HttpContext.Current.Session["uploadOK"] = false;
            
        }
    }

    public void ReadFile(string fileName, HttpContext context)
    {
        using (SqlConnection sCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
        {
            using (SqlCommand sCmd = new SqlCommand("usp_Media_rd", sCon))
            {
                sCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter spFileName = sCmd.Parameters.Add("@i_FileName", SqlDbType.VarChar);
                spFileName.Value = fileName;
                sCon.Open();
                using (SqlDataReader sReader = sCmd.ExecuteReader())
                {
                    if (sReader.Read())
                    {
                        byte[] buffer;
                        string mimeType;

                        buffer = (byte[])sReader["File_BLOB"];
                        mimeType = sReader["File_MIME_Type"].ToString();

                        context.Response.ContentType = mimeType;

                        //  Uncomment this if you want file as attachment
                        //context.Response.AddHeader("content-disposition", "attachment; filename=" + strFileName);

                        context.Response.BinaryWrite(buffer);
                        context.Response.Flush();
                        context.Response.Close();
                    }
                }
            }
        }
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}