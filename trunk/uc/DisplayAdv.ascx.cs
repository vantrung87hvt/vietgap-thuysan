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
using System.Net;

public partial class uc_DisplayAdv : System.Web.UI.UserControl
{
    private string m_vitri;
    public string Vitri
    {
        get { return m_vitri; }
        set { m_vitri = value; }
    }
    private RepeatDirection m_huong;
    public RepeatDirection Huong
    {
        get { return m_huong; }
        set { m_huong = value; }
    }
    private int m_maxwidth = 0;
    public int MaxWidth
    {
        get { return m_maxwidth; }
        set { m_maxwidth = value; }
    }
    private int m_maxheight = 0;
    public int MaxHeight
    {
        get { return m_maxheight; }
        set { m_maxheight = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        PositionEntity oPos = PositionBRL.GetAll().Find(
            delegate(PositionEntity entity)
            {
                return entity.sName.Equals(m_vitri, StringComparison.OrdinalIgnoreCase);
            }
        );
        if (oPos != null)
        {
            List<AdvEntity> lstAdv = AdvBRL.GetByPositionID(oPos.iPositionID);
            if (Request.QueryString["catID"] != null)
            {
                int categoryID;
                bool result = Int32.TryParse(Request.QueryString["catID"], out categoryID);
                if (result)
                {
                    lstAdv = lstAdv.FindAll(
                        delegate(AdvEntity obj)
                        {
                            AdvCategoryEntity oAdvCat = AdvCategoryBRL.GetByFK(obj.iAdvID,categoryID);
                            return oAdvCat != null;
                        }
                    );
                }
            }
            if (Request.QueryString["newsID"] != null)
            {
                int newsID;
                bool result = Int32.TryParse(Request.QueryString["newsID"], out newsID);
                if (result)
                {
                    lstAdv = lstAdv.FindAll(
                        delegate(AdvEntity obj)
                        {
                            List<NewsCategoryEntity> lstNewsCat = NewsCategoryBRL.GetByiNewsID(newsID);
                            foreach (NewsCategoryEntity oNewsCat in lstNewsCat)
                            {
                                AdvCategoryEntity oAdvCat = AdvCategoryBRL.GetByFK(obj.iAdvID, oNewsCat.iCategoryID);
                                if (oAdvCat != null) return true;
                            }
                            return false;
                        }
                    );
                }
            }
            dlstQuangcao.RepeatDirection = m_huong;
            dlstQuangcao.DataSource = lstAdv;
            dlstQuangcao.DataBind();
        }
    }
    protected void dlstQuangcao_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            try
            {
                AdvEntity oAdv = e.Item.DataItem as AdvEntity;
                HyperLink lnkQuangcao = e.Item.FindControl("lnkQuangcao") as HyperLink;
                Literal ltr1 = e.Item.FindControl("ltr1") as Literal;
                if (oAdv != null && lnkQuangcao != null && ltr1 != null)
                {
                    lnkQuangcao.NavigateUrl = oAdv.sLink;
                    if (oAdv.iType == 1)//image
                    {
                        System.Drawing.Image img;
                        if (oAdv.sMedia.StartsWith("http:"))
                        {
                            HttpWebRequest hwr = HttpWebRequest.Create(oAdv.sMedia) as HttpWebRequest;
                            img = System.Drawing.Image.FromStream(hwr.GetResponse().GetResponseStream());
                        }
                        else
                            img = System.Drawing.Image.FromFile(Server.MapPath(oAdv.sMedia));
                        int imgWidth = oAdv.iWidth > 0 ? oAdv.iWidth : img.Width;
                        int imgHeight = oAdv.iHeight > 0 ? oAdv.iHeight : img.Height;
                        int width = (m_maxwidth > 0 && imgWidth > m_maxwidth) ? m_maxwidth : imgWidth;
                        int height = (m_maxheight > 0 && imgHeight > m_maxheight) ? m_maxheight : imgHeight;

                        ltr1.Text = String.Format("<img src='{0}' title='{1}' width='{2}' height='{3}' />", oAdv.sMedia, oAdv.sTitle, width, height);
                    }
                    else//flash
                    {
                        int width = (m_maxwidth > 0 && oAdv.iWidth > m_maxwidth) ? m_maxwidth : oAdv.iWidth;
                        int height = (m_maxheight > 0 && oAdv.iHeight > m_maxheight) ? m_maxheight : oAdv.iHeight;
                        ltr1.Text = String.Format("<embed src='{0}' quality='high' wmode='transparent' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' width='{1}' height='{2}'></embed>", oAdv.sMedia,width,height);                        
                    }
                }
            }
            catch { }
        }
    }
}
