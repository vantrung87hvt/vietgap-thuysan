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
using INVI.Entity;
using INVI.Business;
using System.IO;
using Aspose.Words;
using System.Text.RegularExpressions;

public partial class uc_DocDetail : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["docID"] != null)
        {
            try
            {
                DocumentEntity oDoc = DocumentBRL.GetOne(Convert.ToInt32(Session["docID"]));

                if (oDoc != null)
                {
                    lblTieude.Text = oDoc.sTitle;
                    lblNgaydang.Text = oDoc.tDate.ToString("dd/MM/yyyy");
                    //imgMinhhoa.ImageUrl = ConfigurationManager.AppSettings["UploadPath"] + oDoc.sImage;
                    //imgMinhhoa.Visible = (File.Exists(Server.MapPath(imgMinhhoa.ImageUrl))) ? true : false;
                    lblNoidung.Text = oDoc.sDesc;
                    lblDownload.Text = "Download(" + oDoc.iDownloadTime + ")";
                    lnkDownload.NavigateUrl = "~/download.aspx?id=" + oDoc.PK_iDocumentID;
                    lblNgaybanhanh.Text = oDoc.dNgaybanhanh.ToShortDateString();
                    lblNgaydangcongbao.Text = oDoc.dNgaydangcongbao.ToShortDateString();
                    lblTacgia.Text = oDoc.sAuthor;
                    lblSokyhieu.Text = oDoc.sSokyhieu;
                    lblCoquanbanhanh.Text = oDoc.sCoquanbanhanh;
                    lblNgayhethieuluc.Text = oDoc.dNgayhethieuluc.ToShortDateString();


                    
                    string strFileName = "upload/doc/" + oDoc.sLinkFile;
                    string[] strSep = oDoc.sLinkFile.Split('.');
                    int arrLength = strSep.Length - 1;
                    string strExt = strSep[arrLength].ToString().ToUpper();

                    //if (strExt.ToUpper().Equals("DOC"))
                    //{
                    //    ltView.Text = " <iframe src=" + strFileName + ".htm width=\"740px\" height=\"700\" frameborder=\"0\"></iframe>";
                    //}
                    if (strExt.ToUpper().Equals("DOC"))
                    {
                        Document doc = new Document(Server.MapPath("upload/doc/") + oDoc.sLinkFile);
                        doc.Save(Server.MapPath("upload/doc/") + oDoc.sLinkFile + ".htm");

                        string html = "";
                        using (StreamReader reader = new StreamReader(Server.MapPath("upload/doc/") + oDoc.sLinkFile + ".htm"))
                        {
                            String line = "";
                            while ((line = reader.ReadLine()) != null)
                            {
                                html += line;
                            }
                        }
                        string ProcessedText = Regex.Replace(html, "(?<=img+.+src\\=[\x27\x22])(?<Url>[^\x27\x22]*)(?=[\x27\x22])", "upload/doc/picW.png");

                      
                        ltView.Text += ProcessedText;
                       
                            File.Delete(Server.MapPath("upload/doc/") + oDoc.sLinkFile + ".htm");
                            string[] filePaths = Directory.GetFiles(Server.MapPath("upload/doc/"), oDoc.sLinkFile + ".*");
                            string j = Server.MapPath("upload/doc/") + oDoc.sLinkFile;
                            for (int i = 0; i < filePaths.Length; i++)
                            { 
                                try
                                 {
                                    if (filePaths[i] != j)                            
                                    {
                                       
                                       
                                        File.Delete(filePaths[i]); 
                                      }
                                 }catch { }
                       
                           
                        }
                       
                    }
                    else
                    {
                        ltView.Text = "<script type='text/javascript'>function embedPDF() {var myPDF = new PDFObject({url: '" + strFileName + "' }).embed('viewdoc');    }     window.onload = embedPDF; </script>";
                    }
                    lblLoaitailieu.Text = LoaivanbanBRL.GetOne(oDoc.FK_iLoaivanbanID).sTenloai;
                }
                else
                {
                    lblMessage.Text = "Không tồn tại tài liệu này";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            
        }
    }
}
