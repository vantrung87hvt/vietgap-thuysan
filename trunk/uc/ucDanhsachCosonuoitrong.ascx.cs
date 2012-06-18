using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.DataAccess;
using INVI.Business;
public partial class uc_ucDanhsachCosonuoitrong : System.Web.UI.UserControl
{
    private byte m_pagesize = 20;
    protected int currentPage = 0;
    public byte PageSize
    {
        get { return m_pagesize; }
        set { m_pagesize = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<CosonuoitrongEntity> lstCosonuoitrong = CosonuoitrongBRL.GetAll();
            if (lstCosonuoitrong != null && lstCosonuoitrong.Count > 0)
                DanhsachCosonuoi = lstCosonuoitrong;
            //
            if (Session["VietGAPID"] != null)
            {
                DanhsachCosonuoi = DanhsachCosonuoi.FindAll(
                    delegate(CosonuoitrongEntity oCosonuoi)
                    {
                        return oCosonuoi.sMaso_vietgap.ToUpper()==Session["VietGAPID"].ToString().ToUpper();
                    });
                Session["VietGAPID"] = null;
            }
            List<TinhEntity> lstTinh = TinhBRL.GetAll();
            if (lstTinh != null && lstTinh.Count > 0)
                DanhsachTinh = lstTinh;
            napDllTinh();
            napDllDoituongnuoi();
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
            napRepeaterCosonuoitrong(currentPage);
        }
        catch { currentPage = 0; }
    }
    public List<CosonuoitrongEntity> DanhsachCosonuoi
    {
        get
        {
            if (Cache["DanhsachCosonuoi"] == null)
                return new List<CosonuoitrongEntity>();
            else
                return (List<CosonuoitrongEntity>)Cache["DanhsachCosonuoi"];
        }
        set { Cache["DanhsachCosonuoi"] = value; }
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
    private void napDllDoituongnuoi()
    {
        List<DoituongnuoiEntity> lstDoituongnuoi = DoituongnuoiBRL.GetAll();
        ddlDoituongnuoi.DataSource = lstDoituongnuoi;
        ddlDoituongnuoi.DataTextField = "sTendoituong";
        ddlDoituongnuoi.DataValueField = "PK_iDoituongnuoiID";
        ddlDoituongnuoi.DataBind();
        if (ddlDoituongnuoi.Items.Count > 0)
            ddlDoituongnuoi.SelectedIndex = 0;
    }
    private void napRepeaterCosonuoitrong(int currentPage)
    {

        if (DanhsachCosonuoi == null)
        {
            List<CosonuoitrongEntity> lstCosonuoitrong = CosonuoitrongBRL.GetAll();
            if (lstCosonuoitrong != null && lstCosonuoitrong.Count > 0)
                DanhsachCosonuoi = lstCosonuoitrong;
        }
        lblTieude.Text = "Danh sách các hộ nuôi trồng";

        DanhsachCosonuoi.Sort(CosonuoitrongEntity.COMPARISON_bDuyet);
        DanhsachCosonuoi.Reverse();
        PagedDataSource pds = new PagedDataSource();
        pds.PageSize = m_pagesize;
        pds.CurrentPageIndex = currentPage > 0 ? currentPage : 0;
        pds.DataSource = DanhsachCosonuoi;
        pds.AllowPaging = true;

        rptCosonuoitrong.DataSource = pds;
        rptCosonuoitrong.DataBind();


        lbnPrev.Visible = currentPage > 0 ? true : false;
        //lnkNext.Visible = currentPage != 0 && currentPage < pds.PageCount ? true : false;
        lbnNext.Visible = currentPage == 0 || currentPage < pds.PageCount - 1 ? true : false;
        DanhsachCosonuoi.Clear();
    }
    protected void lbnPrev_Click(object sender, EventArgs e)
    {
        Session["currentDocPage"] = currentPage - 1;
        Response.Redirect("~/Content.aspx?mode=uc&page=DanhsachCosonuoitrong");
    }
    protected void lbnNext_Click(object sender, EventArgs e)
    {
        Session["currentDocPage"] = currentPage + 1;
        Response.Redirect("~/Content.aspx?mode=uc&page=DanhsachCosonuoitrong");
    }
    protected void rptCosonuoitrong_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblHuyenID = (Label)e.Item.FindControl("lblHuyenID");
            Label lblMasovietgap = (Label)e.Item.FindControl("lblMasovietgap");
            Label lblTrangthai = (Label)e.Item.FindControl("lblTrangthai");
            if (lblHuyenID != null)
            {
                int iQuanHuyenID = Convert.ToInt32(lblHuyenID.Text);
                QuanHuyenEntity oQuan = QuanHuyenBRL.GetOne(iQuanHuyenID);
                TinhEntity oTinh = DanhsachTinh.Find(delegate(TinhEntity Tinh) { return Tinh.PK_iTinhID == oQuan.FK_iTinhThanhID; });
                lblHuyenID.Text = oQuan.sTen + ", " + oTinh.sTentinh;
            }
            if (lblMasovietgap != null)
            {
                lblMasovietgap.Text = lblMasovietgap.Text.Length > 0 ? lblMasovietgap.Text : "Chưa có";
            }
            if (lblTrangthai != null)
            {
                int PK_iCosonuoitrongID = Convert.ToInt32(lblTrangthai.Text);
                List<PhatEntity> lstPhat = PhatBRL.GetByFK_iCosonuoiID(PK_iCosonuoitrongID);
                if (lstPhat == null || lstPhat.Count == 0)
                    lblTrangthai.Text = "Hoạt động";
                else
                {
                    byte iMucdo = Convert.ToByte(lstPhat[0].iMucdo.ToString());
                    switch (iMucdo)
                    {
                        case 0:
                            lblTrangthai.Text = "Cảnh cáo";lblTrangthai.ToolTip=lstPhat[0].sLydo; break;
                        case 1:
                            lblTrangthai.Text = "Đình chỉ";lblTrangthai.ToolTip=lstPhat[0].sLydo;break;
                        case 2:
                            lblTrangthai.Text = "Thu hồi";lblTrangthai.ToolTip=lstPhat[0].sLydo;break;
                        default:
                            lblTrangthai.Text = "";break;
                    }
                    lblHuyenID.CssClass = "xuphat";
                    lblMasovietgap.CssClass = "xuphat";
                    lblTrangthai.CssClass = "xuphat";
                    Label lblTencosonuoi = (Label)e.Item.FindControl("lblCosonuoi");
                    Label lblChusohuu = (Label)e.Item.FindControl("lblChusohuu");
                    lblTencosonuoi.CssClass = "xuphat";
                    lblChusohuu.CssClass = "xuphat";
                }
            }
        }
    }
    protected void btnXem_Click(object sender, EventArgs e)
    {
        List<CosonuoitrongEntity> lstCosonuoi = new List<CosonuoitrongEntity>();
        List<QuanHuyenEntity> lstQuanHuyen = QuanHuyenBRL.GetByFK_iTinhThanhID(Convert.ToInt16(ddlTinh.SelectedValue));
        if(DanhsachCosonuoi!=null&&DanhsachCosonuoi.Count>0)
            foreach(QuanHuyenEntity oQuanHuyen in lstQuanHuyen)
            {
                lstCosonuoi.AddRange(DanhsachCosonuoi.FindAll(delegate(CosonuoitrongEntity oCosonuoi) {
                    return oCosonuoi.FK_iQuanHuyenID==oQuanHuyen.FK_iTinhThanhID;
                }
               ));
            }
        else
        {
            foreach(QuanHuyenEntity oQuanHuyen in lstQuanHuyen)
            {
                lstCosonuoi.AddRange(CosonuoitrongBRL.GetByFK_iQuanHuyenID(oQuanHuyen.PK_iQuanHuyenID));
            }
        }
        lstCosonuoi = lstCosonuoi.FindAll(
            delegate(CosonuoitrongEntity oCosonuoi)
            {
                return oCosonuoi.FK_iDoituongnuoiID == Convert.ToInt16(ddlDoituongnuoi.SelectedValue);
            });
        //
        if(!txtMasoVietGAP.Text.Trim().Equals(""))
        {
            lstCosonuoi = lstCosonuoi.FindAll(
                delegate(CosonuoitrongEntity oCosonuoi)
                {
                    return oCosonuoi.sMaso_vietgap.ToUpper().Contains(txtMasoVietGAP.Text.Trim().ToUpper());
                });
        }

        if (!txtTencoso.Text.Trim().Equals(""))
        {
            lstCosonuoi = lstCosonuoi.FindAll(
                delegate(CosonuoitrongEntity oCosonuoi)
                {
                    return oCosonuoi.sTencoso.ToUpper().Contains(txtTencoso.Text.Trim().ToUpper());
                });
        }

        DanhsachCosonuoi = lstCosonuoi;
        napRepeaterCosonuoitrong(0);
    }

}