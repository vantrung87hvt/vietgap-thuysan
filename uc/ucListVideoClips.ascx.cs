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
//            String sVideoContent = String.Format(@"<a  
//			         href='{0}'
//			         style='display:block;width:145px;height:100px'
//			         id='player'> 
//		        </a>
//		        <script>
//		        var player = $f('player', '{1}',{
//                    clip:  {
//                        autoPlay: false,
//                        autoBuffering: true
//                    });
//		        </script>
//            ", sVideoUploadPath + sVideoPath, swfUrl);
            //String sVideoContent = "<div id='player' style='display:block;width:180px;height:120px'></div>";
            //sVideoContent += "<script>var player = $f('player', '" + swfUrl + "',{clip:  { url: '" + sVideoUploadPath + sVideoPath + "',autoPlay: false,autoBuffering: true}});";
            //sVideoContent += "</script>";
            
            //divVideo.InnerHtml = sVideoContent;
            //divVideo.Visible = true;
    }
    private void lstVideo_napDulieu()
    {
        List<VideoClipEntity> lstVideoClips = new List<VideoClipEntity>();
        lstVideoClips = VideoClipBRL.GetAll();
        if (lstVideoClips.Count > 0)
        {
            lstVideoClips = VideoClipEntity.Sort(lstVideoClips, "dNgaytai", "DESC");
            showVideo(lstVideoClips[0].sTentep);
            //lblMota.Text = lstVideoClips[0].sMota;
            List<VideoClipEntity> lstTop5VideoClips = new List<VideoClipEntity>(5);
            int iVideoNums = lstVideoClips.Count > 5 ? 5 : lstVideoClips.Count;
            for (int i = 1; i < iVideoNums-1; i++)
                lstTop5VideoClips.Add(lstVideoClips[i]);
            rptVideoClips.DataSource = lstTop5VideoClips;
            rptVideoClips.DataBind();
        }
    }
    protected string getSubString(String sTieude)
    {
        if (sTieude.Length > 22)
            return sTieude.Substring(0, 21)+"...";
        else
            return sTieude;
    }
}