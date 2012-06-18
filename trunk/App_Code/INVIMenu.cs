/*
 * Create by : xtrung(invi.vn@gmail.com)
 * Description:
 * Làm cho Web.sitemap thêm thuộc tính icon
*/
using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
[XmlRoot("siteMap")]
public class INVIMenu
{
    public MenuItem siteMapNode;
    public INVIMenu()
    {
    }
    public List<MenuItem> GetItems()
    {
        XmlSerializer xs=new XmlSerializer(typeof(INVIMenu));
        XmlTextReader xtr=new XmlTextReader(HttpContext.Current.Server.MapPath("../Web.sitemap"));
        INVIMenu oMenu = xs.Deserialize(xtr) as INVIMenu;
        return oMenu.siteMapNode.Items;
    }
}
[XmlRoot("siteMapNode")]
public class MenuItem
{
    private string m_title;
    private string m_url;
    private string m_desc;
    private string m_icon;
    [XmlAttribute("title")]
    public string Title
    {
        get{return m_title;}
        set{m_title=value;}
    }
    [XmlAttribute("url")]
    public string Url
    {
        get{return m_url;}
        set{m_url=value;}
    }
    [XmlAttribute("description")]
    public string Desc
    {
        get{return m_desc;}
        set{m_desc=value;}
    }
    [XmlAttribute("icon")]
    public string Icon
    {
        get { return m_icon; }
        set { m_icon = value; }
    }
    private List<MenuItem> m_lstMenuItem;
    [XmlElement("siteMapNode")]
    public List<MenuItem> Items
    {
        get { return m_lstMenuItem; }
        set { m_lstMenuItem = value; }
    }
}