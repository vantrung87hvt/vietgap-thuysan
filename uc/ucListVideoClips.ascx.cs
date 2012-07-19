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
using System.IO;

public partial class uc_ucListVideoClips : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lstVideo_napDulieu();
        }
    }
    private void showVideo(String sVideoPath)
    {
        //LinkButton lbtnXemvideo = (LinkButton)e.CommandSource;
        String swfUrl = ResolveUrl("~/Plugin/flowplayer/flowplayer-3.2.11.swf");
            String sVideoUploadPath = ResolveUrl("~/upload/videos/");
            String sVideoContent = String.Format(@"
                <a  
			         href='{0}'
			         style='display:block;width:145px;height:100px'
			         id='player'> 
		        </a>
		        <script>
		            flowplayer('player', '{1}');
		        </script>
            ", sVideoUploadPath + sVideoPath, swfUrl);
            divVideo.InnerHtml = sVideoContent;
            divVideo.Visible = true;
    }
    private void lstVideo_napDulieu()
    {
        List<VideoClipEntity> lstVideoClips = new List<VideoClipEntity>();
        lstVideoClips = VideoClipBRL.GetAll();
        if (lstVideoClips.Count > 0)
        {
            lstVideoClips = VideoClipEntity.Sort(lstVideoClips, "dNgaytai", "DESC");
            showVideo(lstVideoClips[0].sTentep);

            rptVideoClips.DataSource = lstVideoClips;
            rptVideoClips.DataBind();
        }
    }
}