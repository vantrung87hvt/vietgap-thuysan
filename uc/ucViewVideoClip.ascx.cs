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

public partial class uc_ucViewVideoClip : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int PK_iVideoID = 0;
            if (Session["VideoID"] != null)
            {
                PK_iVideoID = Convert.ToInt32(Session["VideoID"].ToString());
                loadVideoClips(PK_iVideoID);
            }
            else // hiển thị Video mới nhất trong danh sách
            {
                List<VideoClipEntity> lstVideoClips = VideoClipBRL.GetAll();
                if (lstVideoClips.Count > 0)
                {
                    VideoClipEntity.Sort(lstVideoClips, "dNgaytai", "DESC");
                    loadVideoClips(lstVideoClips[0].PK_iVideoID);
                }
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
			         style='display:block;width:709px;height:350px'
			         id='player_content'> 
		        </a>
                <script>
		            flowplayer('player', '{1}');
		        </script>
            ", sVideoUploadPath + sVideoPath,swfUrl);
        divVideo.InnerHtml = sVideoContent;
    }
    private void loadVideoClips(int PK_iVideoID)
    {
        VideoClipEntity oVideoClip = VideoClipBRL.GetOne(PK_iVideoID);
        if (oVideoClip != null)
        {
            lblTitle.Text = oVideoClip.sTieude;
            lblDesc.Text = oVideoClip.sMota;
            lblLuotxem.Text = oVideoClip.iSolanxem + " Lượt xem.";
            lblDateTime.Text = oVideoClip.dNgaytai.ToShortDateString();
            oVideoClip.iSolanxem += 1;
            VideoClipBRL.Edit(oVideoClip);
            showVideo(oVideoClip.sTentep);
        }
    }
}