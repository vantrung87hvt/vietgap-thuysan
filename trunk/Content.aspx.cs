using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
public partial class Content : MyUI
{
    protected void Page_Load(object sender, EventArgs e)
    {
            string strControl = String.Empty;
            if (Request.QueryString["newsID"] != null)
            {
                try
                {
                    int newsID = Convert.ToInt16(Request.QueryString["newsID"].ToString());
                    //strControl = "~/uc/ViewNews.ascx?newsID=" + newsID;
                    Session["newsID"] = newsID;
                    strControl = "~/uc/ucViewNews.ascx";
                }
                catch
                {
                    Response.Redirect("~/");
                }
            }
            else if (Request.QueryString["sID"] != null)
            {

                    int sID = Convert.ToInt16(Request.QueryString["sID"].ToString());
                    //strControl = "~/uc/ViewNews.ascx?newsID=" + newsID;
                    Session["sID"] = sID;
                    strControl = "~/uc/ucViewNews.ascx";

            }
            
            else if (Request.QueryString["docID"] != null)
            {
                try
                {
                    int docID = Convert.ToInt16(Request.QueryString["docID"].ToString());
                    Session["docID"] = docID;
                    //strControl = "~/uc/DocDetail.ascx?docID=" + docID;
                    strControl = "~/uc/DocDetail.ascx";
                }
                catch
                {
                    Response.Redirect("~/");
                }
            }
            else if (Request.QueryString["CosonuoitrongID"] != null)
            {
                try
                {
                    int PK_iCosonuoitrongID = Convert.ToInt16(Request.QueryString["CosonuoitrongID"].ToString());
                    Session["CosonuoitrongID"] = PK_iCosonuoitrongID;
                    strControl = "~/uc/ChitietCosonuoitrong.ascx";
                }
                catch
                {
                    Response.Redirect("~/");
                }
            }
            else if (Request.QueryString["faqID"] != null)
            {
                try
                {
                    int faqID = Convert.ToInt16(Request.QueryString["faqID"].ToString());
                    Session["faqID"] = faqID;
                    //strControl = "~/uc/DocDetail.ascx?docID=" + docID;
                    if (faqID == 0)
                        strControl = "~/uc/ucFaq.ascx";
                    else
                        strControl = "~/uc/ucViewFaq.ascx";
                }
                catch
                {
                    Response.Redirect("~/");
                }
            }
            else if (Request.QueryString["TCCNID"] != null)
            {
                try
                {
                    int PK_iTochucchungnhanID = Convert.ToInt16(Request.QueryString["TCCNID"].ToString());
                    Session["TCCNID"] = PK_iTochucchungnhanID;
                    strControl = "~/uc/ucTochucchungnhanChitiet.ascx";
                }
                catch
                {
                    Response.Redirect("~/");
                }
            }
            else if (Request.QueryString["mode"] != null)
            {
                if (Request.QueryString["mode"] == "uc")
                {
                    strControl = "~/uc/uc";
                    strControl += Request.QueryString["page"] + ".ascx";
                }
            }
            else if (Request.QueryString["VideoID"] != null)
            {
                int PK_iVideoID = Convert.ToInt16(Request.QueryString["VideoID"].ToString());
                Session["VideoID"] = PK_iVideoID;
                strControl = "~/uc/ucViewVideoClip.ascx";
            }
            if (File.Exists(Server.MapPath(strControl)))
            {
                Control ctrl = LoadControl(strControl);
                if (ctrl != null)
                {
                    phMain.Controls.Add(ctrl);
                }
            }
            
    }
    
}