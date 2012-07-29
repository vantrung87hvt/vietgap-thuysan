using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.DataAccess;
using INVI.Business;
public partial class adminx_BaocaoThongke_ucThongkeCosonuoitrongTheoTochucchungnhan : System.Web.UI.UserControl
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
        if (!PermissionBRL.CheckPermission("TruycapthongketheoTCCN")) Response.End();
        if (!Page.IsPostBack)
        {
            List<TochucchungnhanEntity> lstTochucchungnhan = TochucchungnhanBRL.GetAll();
            if (lstTochucchungnhan != null && lstTochucchungnhan.Count > 0)
                DanhsachTochucchungnhan = lstTochucchungnhan;
            try
            {
                if (Session["currentDocPage"] != null)
                    try
                    {
                        currentPage = Convert.ToInt32(Session["currentDocPage"]);
                    }
                    catch { }
                napRepeaterCosonuoiTheoToChucchungnhan(currentPage);
            }
            catch { }
            napRepeaterCosonuoiTheoToChucchungnhan(currentPage);
        }
    }
    protected void rptCosonuoitrong_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int iTongsanluong = 0, iCosonuoitrongID = 0;
        //float fTongdientich = 0, fTongdientichmatnuoc = 0, fTongdientichAolang = 0;
        CosonuoitrongEntity oCosonuoitrong = new CosonuoitrongEntity();
        if (e.Item.ItemType == ListItemType.Item||e.Item.ItemType== ListItemType.AlternatingItem)
        {
            Literal ltrCosonuoitrongID = (Literal)e.Item.FindControl("ltrCosonuoitrongID");
            Literal ltrDiachi = (Literal)e.Item.FindControl("ltrDiachi");
            if (ltrCosonuoitrongID != null && ltrDiachi != null)
            {
                iCosonuoitrongID = Convert.ToInt32(ltrCosonuoitrongID.Text);
                oCosonuoitrong = CosonuoitrongBRL.GetOne(iCosonuoitrongID);
                QuanHuyenEntity oQuanHuyen = QuanHuyenBRL.GetOne(oCosonuoitrong.FK_iQuanHuyenID);
                if (oCosonuoitrong.sAp.Length > 0)
                    ltrDiachi.Text = oCosonuoitrong.sAp +", ";
                if(oCosonuoitrong.sXa.Length>0)
                    ltrDiachi.Text += oCosonuoitrong.sXa +", ";
                if (oCosonuoitrong.sXa.Length > 0)
                    ltrDiachi.Text += oQuanHuyen.sTen;
                
                //fTongdientich += oCosonuoitrong.fTongdientich;
                //fTongdientichAolang += oCosonuoitrong.fDientichAolang;
                //fTongdientichmatnuoc += oCosonuoitrong.fTongdientichmatnuoc;
                //iTongsanluong += oCosonuoitrong.iSanluongdukien;
                //Session["fTongdientich"] = fTongdientich;
                //Session["fTongdientichAolang"] = fTongdientichAolang;
                //Session["fTongdientichmatnuoc"] = fTongdientichmatnuoc;
                //Session["iTongsanluong"] = iTongsanluong;
            }
        }
        //else if (e.Item.ItemType == ListItemType.Footer)
        //{
        //    Label lblTongdientich = (Label)e.Item.FindControl("lblTongdientich");
        //    Label lblTongdientichmatnuoc = (Label)e.Item.FindControl("lblTongdientichmatnuoc");
        //    Label lblTongdientichAolang = (Label)e.Item.FindControl("lblTongdientichAolang");
        //    Label lblSanluongdukien = (Label)e.Item.FindControl("lblSanluongdukien");

        //    lblTongdientich.Text = Session["fTongdientich"].ToString();
        //    lblTongdientichAolang.Text = Session["fTongdientichAolang"].ToString();
        //    lblTongdientichmatnuoc.Text = Session["fTongdientichmatnuoc"].ToString();
        //    lblSanluongdukien.Text = Session["iTongsanluong"].ToString();
        //}
    }
    public List<TochucchungnhanEntity> DanhsachTochucchungnhan
    {
        get
        {
            if (Cache["DanhsachTochucchungnhan"] == null)
                return new List<TochucchungnhanEntity>();
            else
                return (List<TochucchungnhanEntity>)Cache["DanhsachTochucchungnhan"];
        }
        set { Cache["DanhsachTochucchungnhan"] = value; }
    }
    public List<CosonuoitrongEntity> DanhsachCosonuoitrong
    {
        get
        {
            if (Cache["DanhsachCosonuoitrong"] == null)
                return new List<CosonuoitrongEntity>();
            else
                return (List<CosonuoitrongEntity>)Cache["DanhsachCosonuoitrong"];
        }
        set { Cache["DanhsachCosonuoitrong"] = value; }
    }
    private void napRepeaterCosonuoiTheoToChucchungnhan(int currentPage)
    {
        pds = new PagedDataSource();
        pds.PageSize = m_pagesize;
        pds.CurrentPageIndex = currentPage > 0 ? currentPage : 0;
        pds.DataSource = DanhsachTochucchungnhan;
        pds.AllowPaging = true;

        rptCosonuoitrongThongke.DataSource = pds;
        rptCosonuoitrongThongke.DataBind();
        lbnPrev.Visible = currentPage > 0 ? true : false;
        lbnNext.Visible = currentPage == 0 || currentPage < pds.PageCount - 1 ? true : false;
    }

    protected void rptCosonuoitrongThongke_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        
        if (e.Item.ItemType == ListItemType.Item)
        {
            Literal ltrTochucchungnhanID = (Literal)e.Item.FindControl("ltrTochucchungnhanID");
            short PK_iTochucchungnhanID = Convert.ToInt16(ltrTochucchungnhanID.Text);
            Repeater rptCosonuoitrong = (Repeater)e.Item.FindControl("rptCosonuoitrong");
            if (rptCosonuoitrong != null)
            {
                List<CosonuoitrongEntity> lstCosonuoitrong = new List<CosonuoitrongEntity>();
                // Lấy theo Mã số Việt Gap để lấy Cơ sở nuôi trồng
                // dựa vào Mã số Việt GAP mới xác định được CSNT nào được cấp phép bởi Tổ chức chứng nhận nào
                List<MasovietgapEntity> lstMasoVietGap = MasovietgapBRL.GetByFK_iTochucchungnhanID(PK_iTochucchungnhanID);
                if (lstMasoVietGap == null) return;
                foreach (MasovietgapEntity oMasoVietGap in lstMasoVietGap)
                    lstCosonuoitrong.Add(CosonuoitrongBRL.GetOne(oMasoVietGap.FK_iCosonuoitrongID));
                if (lstCosonuoitrong.Count == 0) return;
                
                rptCosonuoitrong.DataSource = lstCosonuoitrong;
                rptCosonuoitrong.DataBind();
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
        rptCosonuoitrongThongke.DataSource = DanhsachTochucchungnhan;
        rptCosonuoitrongThongke.DataBind();
        rptCosonuoitrongThongke.RenderControl(htmlWrite);
        Response.Write("<table cellSpacing='0' cellPadding='0' width='100%' align='center' border='1'");
        Response.Write(stringWrite.ToString());
        Response.Write("</table>");
        Response.End();

    }
    protected void lnkExport2Excel_Click(object sender, EventArgs e)
    {
        export2Excel("ThongkeHonuoitrongtheoTochucchungnhan");
    }
    protected void lbnPrev_Click(object sender, EventArgs e)
    {
        Session["currentDocPage"] = currentPage - 1;
        Response.Redirect("Default.aspx?page=BaocaoThongke/ucThongkeCosonuoitrongTheoTochucchungnhan");
    }
    protected void lbnNext_Click(object sender, EventArgs e)
    {
        Session["currentDocPage"] = currentPage + 1;
        Response.Redirect("Default.aspx?page=BaocaoThongke/ucThongkeCosonuoitrongTheoTochucchungnhan");
    }
}