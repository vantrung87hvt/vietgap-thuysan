using INVI.Entity;
using INVI.Business;
using System.Collections.Generic;
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using INVI.INVILibrary;

public partial class download : MyUI
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            int docID = Convert.ToInt32(Request.QueryString["id"]);
            DocumentEntity oDoc = DocumentBRL.GetOne(docID);
            if (oDoc != null)
            {
                string filePath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "doc/" + oDoc.sLinkFile);
                if (File.Exists(filePath))
                {
                    Response.ContentType = INVIFile.GetContentType(oDoc.sLinkFile.Substring(oDoc.sLinkFile.LastIndexOf('.')));
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(oDoc.sLinkFile, System.Text.Encoding.UTF8));
                    Response.WriteFile(filePath);
                    oDoc.iDownloadTime = Convert.ToInt32(oDoc.iDownloadTime) + 1;
                    DocumentBRL.Edit(oDoc);
                }
                else
                {
                    Response.Write("<script language=\"javascript\">alert('Rất tiếc! Có thể tệp không tồn tại hoặc đã bị xóa');</script>");
                }
            }
        }
    }
}