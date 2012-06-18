<%@ WebHandler Language="C#" Class="ShowTochucLogo" %>

using System;
using System.Web;
using System.IO;
using INVI.Entity;
using INVI.Business;

public class ShowTochucLogo : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        Int32 PK_iTochucID;
        if (context.Request.QueryString["id"] != null)
            PK_iTochucID = Convert.ToInt32(context.Request.QueryString["id"]);
        else
            throw new ArgumentException("Không có tham số PK_iTochucID");

        context.Response.ContentType = "image/jpeg";
        Stream strm = ShowImage(PK_iTochucID);
        byte[] buffer = new byte[4096];
        int byteSeq = strm.Read(buffer, 0, 4096);

        while (byteSeq > 0)
        {
            context.Response.OutputStream.Write(buffer, 0, byteSeq);
            byteSeq = strm.Read(buffer, 0, 4096);
        }        
    }

    public Stream ShowImage(int PK_iTochucID)
    {
        TochucchungnhanEntity oTochuc = TochucchungnhanBRL.GetOne(PK_iTochucID);
        object img = oTochuc.imgLogo;
        try
        {
            return new MemoryStream((byte[])img);
        }
        catch
        {
            return null;
        }
    }
 
    public bool IsReusable 
    {
        get {
            return false;
        }
    }

}