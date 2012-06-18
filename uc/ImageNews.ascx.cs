using INVI.Entity;
using INVI.Business;
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
using System.Collections.Generic;

public partial class uc_ImageNews : System.Web.UI.UserControl
{
    protected string imgurl = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //Cấu hình nhóm tin
        int nhomtinID;
        //try
        //{
        //    nhomtinID = Convert.ToInt32(ConfigurationManager.AppSettings["NhomtinAnh"]);
        //}
        //catch (Exception ex) { throw new Exception("Cấu hình sai nhóm tin ảnh trong web.config"); }
        //
        string a = Session["Lang"].ToString();
        if (Session["Lang"].ToString()== "en-US")
        {
            nhomtinID = 5;
        }
        else
        {
            nhomtinID = 3;
        }
        List<NewsEntity> lstNews = NewsBRL.GetByCategoryID(nhomtinID);
        if (lstNews.Count > 0)
        {
            lstNews = lstNews.FindAll
                (
                delegate(NewsEntity oNews)
                {
                    bool bRes = false;
                    if (oNews != null)
                        bRes = oNews.bVerified;
                    return bRes;
                }
            );
            if (lstNews.Count == 0) return;
            lstNews.Sort(NewsEntity.COMPARISON_tDate);
            lstNews.Reverse();
            if (lstNews[0].sTitle.Length > 0)
                if (lstNews[0].sTitle.Length > 60)
                    lnkTitle.Text = INVI.INVILibrary.INVIString.GetCuttedString(lstNews[0].sTitle, 60);
                else
                    lnkTitle.Text = lstNews[0].sTitle;
            else
                lnkTitle.Text = "";
            lblDateTime.Text = lstNews[0].tDate.ToString();
            lnkTitle.NavigateUrl = "~/Content.aspx?newsID=" + lstNews[0].iNewsID;
            lnkLink.NavigateUrl = "~/Content.aspx?newsID=" + lstNews[0].iNewsID;
            lblDesc.Text = INVI.INVILibrary.INVIString.GetCuttedString(lstNews[0].sDesc, 150);
            lnkChitiet.NavigateUrl = "~/Content.aspx?newsID=" + lstNews[0].iNewsID;
            imgurl = ConfigurationManager.AppSettings["UploadPath"] + lstNews[0].sImage;
            img.ImageUrl = imgurl;
            pnNews.Visible = true;
        }
        else
        {
            pnNews.Visible = false;
        }
    }
}
