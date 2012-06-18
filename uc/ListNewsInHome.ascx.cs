using INVI.Business;
using INVI.Entity;
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
using System.IO;

public partial class uc_ListNewsInHome : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bindCat();
    }

    private void bindCat()
    {
        //int nhomtinID;
        //try
        //{
        //    nhomtinID = Convert.ToInt32(ConfigurationManager.AppSettings["NhomtinGoc"]);
        //}
        //catch { throw new Exception("Cấu hình sai nhóm tin gốc trong web.config"); }
        //List<CategoryEntity> lstCat = CategoryBRL.GtByTopID(nhomtinID);
        
        List<NewsEntity> lstNews = NewsBRL.GetAll();
    }
    //protected void rptrListNhomtinInHome_ItemDataBound(Object sender, RepeaterItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    //    {
    //        Repeater rptrNewsInHome = e.Item.FindControl("rptrNewsInHome") as Repeater;

    //    }
    //    //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    //    //{
    //    //    Repeater rptrNewsInHome = e.Item.FindControl("rptrNewsInHome") as Repeater;
    //    //    Repeater rptrSubCat = e.Item.FindControl("rptrSubCat") as Repeater;
    //    //    CategoryEntity oCat = e.Item.DataItem as CategoryEntity;
    //    //    if (rptrSubCat != null && oCat != null)
    //    //    {
    //    //        rptrSubCat.DataSource = CategoryBRL.GetByTopID(oCat.iCategoryID);
    //    //        rptrSubCat.DataBind();
    //    //    }
    //    //    if (rptrNewsInHome != null && oCat != null)
    //    //    {
    //    //        List<NewsEntity> lstNews = NewsBRL.GetByCategoryID(oCat.iCategoryID).FindAll(
    //    //            delegate(NewsEntity oNews)
    //    //            {
    //    //                return oNews.bVerified;
    //    //            }
    //    //        );
                 
    //    //        if (lstNews.Count > 0)
    //    //        {
    //    //            HyperLink lnkTitle = e.Item.FindControl("lnkTitle") as HyperLink;
    //    //            HyperLink lnkImage = e.Item.FindControl("lnkImage") as HyperLink;
    //    //            Image imgMinhhoa = e.Item.FindControl("imgMinhhoa") as Image;
    //    //            Label lblTitle = e.Item.FindControl("lblTitle") as Label;
    //    //            Label lblDesc = e.Item.FindControl("lblDesc") as Label;
    //    //            if (lnkTitle != null && imgMinhhoa != null && lblTitle != null && lnkImage!=null && lblDesc != null)
    //    //            {
    //    //                lnkTitle.NavigateUrl = "~/Category.aspx?newsID=" + lstNews[0].iNewsID;
    //    //                if (File.Exists(Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + lstNews[0].sImage)))
    //    //                    imgMinhhoa.ImageUrl = ConfigurationManager.AppSettings["UploadPath"] +lstNews[0].sImage;
    //    //                else
    //    //                    imgMinhhoa.ImageUrl = ConfigurationManager.AppSettings["UploadPath"] + "nophoto.jpg";
    //    //                lblTitle.Text =INVI.INVILibrary.INVIString.GetCuttedString(lstNews[0].sTitle,70);
    //    //                lblDesc.Text =INVI.INVILibrary.INVIString.GetCuttedString(lstNews[0].sDesc,150);
    //    //            }
    //    //            lstNews.RemoveAt(0);
    //    //            PagedDataSource pds = new PagedDataSource();
    //    //            pds.AllowPaging = true;
    //    //            pds.PageSize = 3;
    //    //            pds.DataSource = lstNews;
    //    //            rptrNewsInHome.DataSource = pds;
    //    //            rptrNewsInHome.DataBind();
    //    //        }
    //    //    }
    //    //}
    //}
    protected void rptrNewsInHome_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        List<NewsEntity> lstNews = NewsBRL.GetAll().FindAll(
            delegate(NewsEntity oNews)
            {
                return oNews.bVerified;
            }
        );
        if (lstNews.Count > 0)
        {
            HyperLink lnkTitle = e.Item.FindControl("lnkTitle") as HyperLink;
            HyperLink lnkImage = e.Item.FindControl("lnkImage") as HyperLink;
            Image imgMinhhoa = e.Item.FindControl("imgMinhhoa") as Image;
            Label lblTitle = e.Item.FindControl("lblTitle") as Label;
            Label lblDesc = e.Item.FindControl("lblDesc") as Label;
            if (lnkTitle != null && imgMinhhoa != null && lblTitle != null && lnkImage != null && lblDesc != null)
            {
                lnkTitle.NavigateUrl = "~/Category.aspx?newsID=" + lstNews[0].iNewsID;
                if (File.Exists(Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + lstNews[0].sImage)))
                    imgMinhhoa.ImageUrl = ConfigurationManager.AppSettings["UploadPath"] + lstNews[0].sImage;
                else
                    imgMinhhoa.ImageUrl = ConfigurationManager.AppSettings["UploadPath"] + "nophoto.jpg";
                lblTitle.Text = INVI.INVILibrary.INVIString.GetCuttedString(lstNews[0].sTitle, 70);
                lblDesc.Text = INVI.INVILibrary.INVIString.GetCuttedString(lstNews[0].sDesc, 150);
            }
            lstNews.RemoveAt(0);
            
        }
    }
}
