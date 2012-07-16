<%@ WebHandler Language="C#" Class="VideoHandler" %>

using INVI.Entity;
using INVI.Business;
using INVI.INVILibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Globalization;

public class VideoHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        VideoClipEntity entity = new VideoClipEntity();
        try
        {
            int PK_iVideoClipID = 0;
            if (context.Request.QueryString["iVideoID"] != null)
                PK_iVideoClipID=Convert.ToInt32(context.Request.QueryString["iVideoID"].ToString());
            entity = VideoClipBRL.GetOne(PK_iVideoClipID);
            if (entity!=null)
            {
                context.Response.Clear();
                context.Response.AddHeader("Content-Type", entity.sTentep.ToString());
                context.Response.BinaryWrite((byte[])entity.bVideoClip);
            }
        }
        finally
        {
            entity = null;
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}