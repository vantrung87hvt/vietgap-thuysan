using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.DataAccess;
using INVI.Business;
public partial class adminx_BaocaoThongke_ucCosonuoitrongThongkeTheoTinh : System.Web.UI.UserControl
{
    private byte m_pagesize = 5;
    protected int currentPage = 0;
    PagedDataSource pds = new PagedDataSource();
    public byte PageSize
    {
        get { return m_pagesize; }
        set { m_pagesize = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!PermissionBRL.CheckPermission("Xemcacthongketonghop")) Response.End();
        if (!Page.IsPostBack)
        {
            List<TinhEntity> lstTinh = TinhBRL.GetAll();
            if (lstTinh != null && lstTinh.Count > 0)
                DanhsachTinh = lstTinh;
            try
            {
                if (Session["currentDocPage"] != null)
                    try
                    {
                        currentPage = Convert.ToInt32(Session["currentDocPage"]);
                    }
                    catch { }
                napRepeaterCosonuoiTheoTinh(currentPage);
            }
            catch { }

            
        }
    }
    public List<TinhEntity> DanhsachTinh
    {
        get
        {
            if (Cache["DanhsachTinh"] == null)
                return new List<TinhEntity>();
            else
                return (List<TinhEntity>)Cache["DanhsachTinh"];
        }
        set { Cache["DanhsachTinh"] = value; }
    }
    private void napRepeaterCosonuoiTheoTinh(int currentPage)
    {
        pds = new PagedDataSource();
        pds.PageSize = m_pagesize;
        pds.CurrentPageIndex = currentPage > 0 ? currentPage : 0;
        pds.DataSource = DanhsachTinh;
        pds.AllowPaging = true;

        rptCosonuoitrongThongke.DataSource = pds;
        rptCosonuoitrongThongke.DataBind();
        lbnPrev.Visible = currentPage > 0 ? true : false;
        //lnkNext.Visible = currentPage != 0 && currentPage < pds.PageCount ? true : false;
        lbnNext.Visible = currentPage == 0 || currentPage < pds.PageCount - 1 ? true : false;
    }

    protected void rptCosonuoitrongThongke_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item||e.Item.ItemType==ListItemType.AlternatingItem)
        {
            Literal ltrTinhID = (Literal)e.Item.FindControl("ltrTinhID");
            short iTinhID = Convert.ToInt16(ltrTinhID.Text);
            Repeater rptCosonuoitrong = (Repeater)e.Item.FindControl("rptCosonuoitrong");
            if (rptCosonuoitrong != null)
            {
                List<QuanHuyenEntity> lstQuanHuyen = QuanHuyenBRL.GetByFK_iTinhThanhID(iTinhID);
                List<CosonuoitrongEntity> lstCosonuoitrong = new List<CosonuoitrongEntity>();
                foreach (QuanHuyenEntity oQuanhuyen in lstQuanHuyen)
                {
                    lstCosonuoitrong.AddRange(CosonuoitrongBRL.GetByFK_iQuanHuyenID(oQuanhuyen.PK_iQuanHuyenID));
                }
                rptCosonuoitrong.DataSource = lstCosonuoitrong;
                rptCosonuoitrong.DataBind();
            }
        }
    }
    protected void rptCosonuoitrong_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            Literal ltrCosonuoitrongID = (Literal)e.Item.FindControl("ltrCosonuoitrongID");
            Literal ltrDiachi = (Literal)e.Item.FindControl("ltrDiachi");
            if (ltrCosonuoitrongID != null&&ltrDiachi!=null)
            {
                int iCosonuoitrongID = Convert.ToInt32(ltrCosonuoitrongID.Text);
                CosonuoitrongEntity oCosonuoitrong = CosonuoitrongBRL.GetOne(iCosonuoitrongID);
                QuanHuyenEntity oQuanHuyen = QuanHuyenBRL.GetOne(oCosonuoitrong.FK_iQuanHuyenID);
                if (oCosonuoitrong.sAp.Length > 0)
                    ltrDiachi.Text = oCosonuoitrong.sAp + ", ";
                if (oCosonuoitrong.sXa.Length > 0)
                    ltrDiachi.Text += oCosonuoitrong.sXa + ", ";
                    ltrDiachi.Text += oQuanHuyen.sTen;
            }
        }
    }
    private void export2Excel(String sFilename)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xls", sFilename));
        Response.Charset = "UTF-8";
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        //pds = new PagedDataSource();
        //pds.DataSource = DanhsachTinh;
        //pds.AllowPaging = false;

        rptCosonuoitrongThongke.DataSource = DanhsachTinh;
        rptCosonuoitrongThongke.DataBind();
        rptCosonuoitrongThongke.RenderControl(htmlWrite);
        Response.Write("<table cellSpacing='0' cellPadding='0' width='100%' align='center' border='1'");
        Response.Write(stringWrite.ToString());
        Response.Write("</table>");
        Response.End();

    }
    protected void lnkExport2Excel_Click(object sender, EventArgs e)
    {
        export2Excel("ThongkeCosonuoitrongTheoTinh");
    }
    protected void lbnPrev_Click(object sender, EventArgs e)
    {
        Session["currentDocPage"] = currentPage - 1;
        Response.Redirect("Default.aspx?page=BaocaoThongke/ucCosonuoitrongThongkeTheotinh");
    }
    protected void lbnNext_Click(object sender, EventArgs e)
    {
        Session["currentDocPage"] = currentPage + 1;
        Response.Redirect("Default.aspx?page=BaocaoThongke/ucCosonuoitrongThongkeTheotinh");
    }
}