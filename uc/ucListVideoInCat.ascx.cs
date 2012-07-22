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
using System.Web.UI.WebControls;

public partial class uc_ucListVideoInCat : System.Web.UI.UserControl
{
    private byte m_pagesize = 5;
    public int iStt = 1;
    protected int currentPage = 0;
    public byte PageSize
    {
        get { return m_pagesize; }
        set { m_pagesize = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                if (Session["currentDocPage"] != null)
                    try
                    {
                        currentPage = Convert.ToInt32(Session["currentDocPage"]);
                    }
                    catch { }
                lstVideo_napDulieu(currentPage);
            }
            catch { }
            
        }
    }

    private void lstVideo_napDulieu(int cucurrentPagerPage)
    {
        List<VideoClipEntity> lstVideoClips = new List<VideoClipEntity>();
        lstVideoClips = VideoClipBRL.GetAll();
        if (lstVideoClips.Count > 0)
        {
            PagedDataSource pds = new PagedDataSource();
            pds.PageSize = m_pagesize;
            pds.CurrentPageIndex = currentPage > 0 ? currentPage : 0;
            lstVideoClips = VideoClipEntity.Sort(lstVideoClips, "dNgaytai", "DESC");
            pds.DataSource = lstVideoClips;
            pds.AllowPaging = true;
            
            rptVideoClips.DataSource = pds;
            rptVideoClips.DataBind();
            lbnPrev.Visible = currentPage > 0 ? true : false;
            //lnkNext.Visible = currentPage != 0 && currentPage < pds.PageCount ? true : false;
            lbnNext.Visible = currentPage == 0 || currentPage < pds.PageCount - 1 ? true : false;
            lstVideoClips.Clear();
        }
    }
    protected void lbnPrev_Click(object sender, EventArgs e)
    {
        Session["curVideoPage"] = currentPage - 1;
        Response.Redirect("~/Content.aspx?mode=uc&page=ViewVideoClip");
    }
    protected void lbnNext_Click(object sender, EventArgs e)
    {
        Session["curVideoPage"] = currentPage + 1;
        Response.Redirect("~/Content.aspx?mode=uc&page=ViewVideoClip");
    }
}