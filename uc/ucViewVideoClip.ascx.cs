﻿using INVI.Entity;
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

public partial class uc_ucViewVideoClip : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int PK_iVideoID = 0;
            if(Session["VideoID"]!=null)
            {
                PK_iVideoID = Convert.ToInt32(Session["VideoID"].ToString());
                loadVideoClips(PK_iVideoID);
            }
        }
    }
    private void showVideo(String sVideoPath)
    {
        //LinkButton lbtnXemvideo = (LinkButton)e.CommandSource;
        String sVideoUploadPath = ResolveUrl("~/upload/videos/");
        String swfUrl = ResolveUrl("~/Plugin/flowplayer/flowplayer-3.2.11.swf");
        String sVideoContent = String.Format(@"
                <a  
			         href='{0}'
			         style='display:block;width:520px;height:330px'
			         id='player_content'> 
		        </a>
                <script>
		            flowplayer('player', '{1}');
		        </script>
            ", sVideoUploadPath + sVideoPath,swfUrl);
        divVideo.InnerHtml = sVideoContent;
        divVideo.Visible = true;
    }
    private void loadVideoClips(int PK_iVideoID)
    {
        VideoClipEntity oVideoClip = VideoClipBRL.GetOne(PK_iVideoID);
        if (oVideoClip != null)
        {
            lblTitle.Text = oVideoClip.sTieude;
            lblDesc.Text = oVideoClip.sMota;
            lblDateTime.Text = oVideoClip.dNgaytai.ToShortDateString();
            showVideo(oVideoClip.sTentep);
        }
    }
}