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


public partial class uc_ucListVideoClips : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lstVideo_napDulieu();
        }
    }
    private void lstVideo_napDulieu()
    {
        List<VideoClipEntity> lstVideoClips = new List<VideoClipEntity>();
        lstVideoClips = VideoClipBRL.GetAll();
        if (lstVideoClips.Count > 0)
        {
            lstVideoClips = VideoClipEntity.Sort(lstVideoClips, "dNgaytai", "DESC");
            WindowsMedia1.VideoURL = lstVideoClips[0].sTentep;

            rptVideoClips.DataSource = lstVideoClips;
            rptVideoClips.DataBind();
        }
    }
}