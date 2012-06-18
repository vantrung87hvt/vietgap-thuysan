using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.DataAccess;
using INVI.Business;

public partial class uc_ucDanhsachTochucchungnhan : System.Web.UI.UserControl
{
    private byte m_pagesize = 10;
    protected int currentPage = 0;
    public byte PageSize
    {
        get { return m_pagesize; }
        set { m_pagesize = value; }
    }
    public List<QuanHuyenEntity> DanhsachQuanHuyen
    {
        get
        {
            if (Cache["DanhsachQuanHuyen"] == null)
                return new List<QuanHuyenEntity>();
            else
                return (List<QuanHuyenEntity>)Cache["DanhsachQuanHuyen"];
        }
        set { Cache["DanhsachQuanHuyen"] = value; }
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
    private void napDllTinh()
    {
        ddlTinh.DataSource = DanhsachTinh;
        ddlTinh.DataTextField = "sTentinh";
        ddlTinh.DataValueField = "PK_iTinhID";
        ddlTinh.DataBind();
        if (ddlTinh.Items.Count > 0)
            ddlTinh.SelectedIndex = 0;
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
    private void napRepeaterTochucchungnhan(int currentPage)
    {

        if (DanhsachTochucchungnhan == null)
        {
            List<TochucchungnhanEntity> lstTochucchungnhan = TochucchungnhanBRL.GetAll();
            if (lstTochucchungnhan != null && lstTochucchungnhan.Count > 0)
                DanhsachTochucchungnhan = lstTochucchungnhan;
        }
        lblTieude.Text = "Danh sách Tổ chức chứng nhận";

        DanhsachTochucchungnhan.Sort(TochucchungnhanEntity.COMPARISON_sTochucchungnhan);
        DanhsachTochucchungnhan.Reverse();
        PagedDataSource pds = new PagedDataSource();
        pds.PageSize = m_pagesize;
        pds.CurrentPageIndex = currentPage > 0 ? currentPage : 0;
        pds.DataSource = DanhsachTochucchungnhan;
        pds.AllowPaging = true;

        rptTochucchungnhan.DataSource = pds;
        rptTochucchungnhan.DataBind();


        lbnPrev.Visible = currentPage > 0 ? true : false;
        //lnkNext.Visible = currentPage != 0 && currentPage < pds.PageCount ? true : false;
        lbnNext.Visible = currentPage == 0 || currentPage < pds.PageCount - 1 ? true : false;
        DanhsachTochucchungnhan.Clear();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<TochucchungnhanEntity> lstTochucchungnhan = TochucchungnhanBRL.GetAll();
            if (lstTochucchungnhan != null && lstTochucchungnhan.Count > 0)
                DanhsachTochucchungnhan = lstTochucchungnhan;
            //

            List<TinhEntity> lstTinh = TinhBRL.GetAll();
            if (lstTinh != null && lstTinh.Count > 0)
                DanhsachTinh = lstTinh;
            napDllTinh();
        }
        try
        {
            if (Session["currentDocPage"] != null)
                try
                {
                    currentPage = Convert.ToInt32(Session["currentDocPage"]);
                }
                catch { currentPage = 0; }
            else
                currentPage = 0;
            napRepeaterTochucchungnhan(currentPage);
        }
        catch { currentPage = 0; }
    }
    protected void btnXem_Click(object sender, EventArgs e)
    {

    }
    
    protected void lbnPrev_Click(object sender, EventArgs e)
    {
        Session["currentDocPage"] = currentPage - 1;
        Response.Redirect("~/Content.aspx?mode=uc&page=DanhsachTCCNChitiet");
    }
    protected void lbnNext_Click(object sender, EventArgs e)
    {
        Session["currentDocPage"] = currentPage + 1;
        Response.Redirect("~/Content.aspx?mode=uc&page=DanhsachTCCNChitiet");
    }
    protected void rptTochucchungnhan_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblHuyenID = (Label)e.Item.FindControl("lblDiachi");
            Label lblMasovietgap = (Label)e.Item.FindControl("lblMasovietgap");
            Label lblTrangthai = (Label)e.Item.FindControl("lblTrangthai");
            HyperLink hypTochuchungnhan = (HyperLink)e.Item.FindControl("hypTochucchungnhan");
            int iID = 0;
            Label lblID = (Label)e.Item.FindControl("lblTCCNID");
            if (lblID!=null)
                iID = Convert.ToInt32(lblID.Text);
            if (hypTochuchungnhan != null)
                hypTochuchungnhan.NavigateUrl = "~/Content.aspx?TCCNID=" + iID;
            if (lblHuyenID != null)
            {
                int iQuanHuyenID = Convert.ToInt32(lblHuyenID.Text);
                QuanHuyenEntity oQuan = QuanHuyenBRL.GetOne(iQuanHuyenID);
                TinhEntity oTinh = DanhsachTinh.Find(delegate(TinhEntity Tinh) { return Tinh.PK_iTinhID == oQuan.FK_iTinhThanhID; });
                lblHuyenID.Text = oQuan.sTen + ", " + oTinh.sTentinh;
            }
            if (lblMasovietgap != null)
            {
                lblMasovietgap.Text = lblMasovietgap.Text.Length > 0 ? lblMasovietgap.Text : "";
            }
            if (lblTrangthai != null)
            {
                int PK_iTochucchungnhanID = Convert.ToInt32(lblTrangthai.Text);
                List<XulyTochucchungnhanEntity> lstPhat = XulyTochucchungnhanBRL.GetByFK_iTochucchungnhanID(PK_iTochucchungnhanID);
                if (lstPhat == null || lstPhat.Count == 0)
                    lblTrangthai.Text = "Hoạt động";
                else
                {
                    byte iMucdo = Convert.ToByte(lstPhat[0].iMucdo.ToString());
                    switch (iMucdo)
                    {
                        case 0:
                            lblTrangthai.Text = "Cảnh cáo"; lblTrangthai.ToolTip = lstPhat[0].sLydo; break;
                        case 1:
                            lblTrangthai.Text = "Đình chỉ"; lblTrangthai.ToolTip = lstPhat[0].sLydo; break;
                        case 2:
                            lblTrangthai.Text = "Thu hồi"; lblTrangthai.ToolTip = lstPhat[0].sLydo; break;
                        default:
                            lblTrangthai.Text = ""; break;
                    }
                    //lblHuyenID.CssClass = "xuphat";
                    //lblMasovietgap.CssClass = "xuphat";
                    //lblTrangthai.CssClass = "xuphat";
                    //Label lblTencosonuoi = (Label)e.Item.FindControl("lblCosonuoi");
                    //Label lblChusohuu = (Label)e.Item.FindControl("lblChusohuu");
                    //lblTencosonuoi.CssClass = "xuphat";
                    //lblChusohuu.CssClass = "xuphat";
                }
            }
        }
    }
}