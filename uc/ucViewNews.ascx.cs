using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.Business;

public partial class uc_ucViewNews : System.Web.UI.UserControl
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["newsID"] != null)
        {
            Load_Content_News(Convert.ToInt32(Request.QueryString["newsID"]));
        }
        else if (Request.QueryString["sID"] != null)
        {
            Load_Content_News(Convert.ToInt32(Request.QueryString["sID"]));
        }
        else
        {
            if (Session["Lang"].ToString() == "en-US")
                lblError.Text = "Information not found";
            else
                lblError.Text = "Tin không tồn tại";

        }
    }
    
    private void Load_Content_News(int idNews)
    {
        try
        {
            NewsEntity oNews = NewsBRL.GetOne(idNews);
            if (oNews != null)
            {
                lblTitle.Text = oNews.sTitle;
                lblDateTime.Text = oNews.tDate.ToString("dd/MM/yyyy");                               
                lblContent.Text = oNews.sContent;               
            }
            else
            {
                if (Session["Lang"].ToString() == "en-US")
                    lblError.Text = "This newsr does not exist or not be approved";
                else                    
                    lblError.Text = "Tin Này Không Tồn Tại Hoặc Chưa Được Kiểm Duyệt";                                
                return;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}