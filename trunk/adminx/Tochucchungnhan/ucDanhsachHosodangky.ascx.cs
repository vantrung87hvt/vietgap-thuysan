using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.DataAccess;
using INVI.Business;
public partial class uc_ucDanhsachHosodangky : System.Web.UI.UserControl
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
            catch (Exception ex)
            { currentPage = 0; }
        }
        
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
    public List<HosodangkychungnhanEntity> DanhsachHosodangky
    {
        get
        {
            if (Cache["DanhsachHosodangky"] == null)
                return new List<HosodangkychungnhanEntity>();
            else
                return (List<HosodangkychungnhanEntity>)Cache["DanhsachHosodangky"];
        }
        set { Cache["DanhsachHosodangky"] = value; }
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
    private void napRepeaterCosonuoitrong(int currentPage)
    {
        Int64 PK_iUserID = Int64.Parse(Session["UserID"].ToString());

        List<TochucchungnhanTaikhoanEntity> lstTochucchungnhan_Taikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(PK_iUserID);
        List<HosodangkychungnhanEntity> lstHosodangky = new List<HosodangkychungnhanEntity>();
        if (lstTochucchungnhan_Taikhoan != null && lstTochucchungnhan_Taikhoan.Count > 0)
        {
            lstHosodangky.AddRange(HosodangkychungnhanBRL.GetByFK_iTochucchungnhanID(lstTochucchungnhan_Taikhoan[0].FK_iTochucchungnhanID));
        }

        PagedDataSource pds = new PagedDataSource();
        pds.PageSize = m_pagesize;
        pds.CurrentPageIndex = currentPage > 0 ? currentPage : 0;
        pds.DataSource = lstHosodangky;
        pds.AllowPaging = true;

        rptCosonuoitrong.DataSource = pds;
        rptCosonuoitrong.DataBind();


        lbnPrev.Visible = currentPage > 0 ? true : false;
        //lnkNext.Visible = currentPage != 0 && currentPage < pds.PageCount ? true : false;
        lbnNext.Visible = currentPage == 0 || currentPage < pds.PageCount - 1 ? true : false;
        lstHosodangky.Clear();
    }
    protected void lbnPrev_Click(object sender, EventArgs e)
    {
        Session["currentDocPage"] = currentPage - 1;
        Response.Redirect("~/adminx/Tochucchungnhan/Default.aspx?page=DanhsachCosonuoitrong");
    }
    protected void lbnNext_Click(object sender, EventArgs e)
    {
        Session["currentDocPage"] = currentPage + 1;
        Response.Redirect("~/adminx/Tochucchungnhan/Default.aspx?page=DanhsachCosonuoitrong");
    }
    protected void rptCosonuoitrong_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblHuyenID = (Label)e.Item.FindControl("lblHuyenID");
            Label lblCosonuoi = (Label)e.Item.FindControl("lblCosonuoi");
            Label lblChusohuu = (Label)e.Item.FindControl("lblChusohuu");
            if (lblCosonuoi != null && lblChusohuu != null && lblHuyenID != null)
            {
                Int64 PK_iCosonuoitrongID = Int64.Parse(lblCosonuoi.Text);
                CosonuoitrongEntity oCosonuoitrong = CosonuoitrongBRL.GetOne(PK_iCosonuoitrongID);
                QuanHuyenEntity oQuan = QuanHuyenBRL.GetOne(oCosonuoitrong.FK_iQuanHuyenID);
                TinhEntity oTinh = TinhBRL.GetOne(oQuan.FK_iTinhThanhID);
                lblHuyenID.Text = oQuan.sTen + ", " + oTinh.sTentinh;
                lblCosonuoi.Text = oCosonuoitrong.sTencoso;
                lblChusohuu.Text = oCosonuoitrong.sTenchucoso;
                oCosonuoitrong = null;
            }
        }
    }
    protected void rptCosonuoitrong_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        LinkButton lbtnSource;
        lbtnSource = (LinkButton)e.CommandSource;
        switch(lbtnSource.CommandName)
        {
            case "Danhgianoibo":
                Session["iCosonuoitrongID"] = lbtnSource.CommandArgument;
                Response.Redirect(ResolveUrl("~/adminx/Tochucchungnhan/Default.aspx?page=Danhgiaketqua"));
                break;
            case "Giaytokemtheo":
                Session["iHosodangkyCSNT"] = lbtnSource.CommandArgument;
                //Nạp danh sách giấy tờ nộp kèm
                cblGiaytonopkem.Items.Clear();
                napCblGiaytonopkem();
                panGiaytonopkem.Visible = true;
                break;
            case "Capmaso":
                Session["iHosodangkyCSNT"] = lbtnSource.CommandArgument;
                foreach(Control ctr in phCapmasoContent.Controls)
                {
                    phCapmasoContent.Controls.Remove(ctr);
                }
                Control ctrThongtinCapmaso = LoadControl("~/adminx/Tochucchungnhan/ucCapmasoVietGap.ascx");
                phCapmasoContent.Controls.Add(ctrThongtinCapmaso);
                break;
        }
    }

    /// <summary>
    /// Nạp danh sách giấy tờ nộp kèm hồ sơ
    /// </summary>
    public void napCblGiaytonopkem()
    {
        int PK_iHosodangkyCSNT = int.Parse(Session["iHosodangkyCSNT"].ToString());
        List<GiaytonopkemhosoEntity> lstGiaytonopkem = GiaytonopkemhosoBRL.GetByPK_iHosodangkychungnhanID(PK_iHosodangkyCSNT);
        List<GiaytoEntity> lstGiayto = GiaytoBRL.GetAll();
        lstGiayto = lstGiayto.FindAll(
            delegate(GiaytoEntity oGiaytoFound)
                {
                    return oGiaytoFound.bCSNT;
                }
            );
        cblGiaytonopkem.DataSource = lstGiayto;
        cblGiaytonopkem.DataTextField = "sTengiayto";
        cblGiaytonopkem.DataValueField = "PK_iGiaytoID";
        cblGiaytonopkem.DataBind();
        GiaytonopkemhosoEntity oGiaytoNopkem = null;
        if (lstGiaytonopkem != null && lstGiaytonopkem.Count > 0)
        {
            foreach (ListItem chk in cblGiaytonopkem.Items)
            {
                oGiaytoNopkem = null;
                oGiaytoNopkem = lstGiaytonopkem.Find(
                    delegate(GiaytonopkemhosoEntity oGiaytonopkemFound)
                    {
                        return oGiaytonopkemFound.FK_iGiaytoID.ToString().Equals(chk.Value);
                    }
                    );
                if (oGiaytoNopkem != null)
                {
                    chk.Selected = true;
                }
            }
        }
        lstGiayto = null;
        lstGiaytonopkem = null;
    }

    protected void btnLuuGiaytonopkem_Click(object sender, EventArgs e)
    {
        if (Session["iHosodangkyCSNT"] != null)
        {
            int PK_iHosodangkyCSNT = int.Parse(Session["iHosodangkyCSNT"].ToString());
            List<GiaytonopkemhosoEntity> lstGiaytonopkem = GiaytonopkemhosoBRL.GetByPK_iHosodangkychungnhanID(PK_iHosodangkyCSNT);
            GiaytonopkemhosoEntity oGiaytoNopkem = null;
            foreach(ListItem chk in cblGiaytonopkem.Items)
            {
                oGiaytoNopkem = null;
                oGiaytoNopkem = lstGiaytonopkem.Find(
                    delegate(GiaytonopkemhosoEntity oGiaytonopkemFound)
                        {
                            return oGiaytonopkemFound.FK_iGiaytoID.ToString().Equals(chk.Value);
                        }
                    );
                if(oGiaytoNopkem == null)
                {
                    if (chk.Selected)
                    {
                        GiaytonopkemhosoEntity oGiaytonopkemNew = new GiaytonopkemhosoEntity();
                        oGiaytonopkemNew.FK_iGiaytoID = int.Parse(chk.Value);
                        oGiaytonopkemNew.PK_iHosodangkychungnhanID = PK_iHosodangkyCSNT;
                        oGiaytonopkemNew.bTrangthai = true;
                        GiaytonopkemhosoBRL.Add(oGiaytonopkemNew);
                    }
                }
                else
                {
                    if(!chk.Selected)
                    {
                        GiaytonopkemhosoBRL.Remove(oGiaytoNopkem.PK_iGiaytoguikemID);
                    }
                    lstGiaytonopkem.Remove(oGiaytoNopkem); //Loại bỏ phần tử đã tìm thấy để tối ưu
                }
            }
            lstGiaytonopkem = null;
            napCblGiaytonopkem();
            lblThongbao.Text = "Lưu thành công!";
        }
        else
        {
            Response.Redirect(ResolveUrl("~/adminx/Tochucchungnhan/Default.aspx?page=DanhsachCosonuoitrong"));
        }
    }
    protected void btnHuygiaytonopkem_Click(object sender, EventArgs e)
    {
        panGiaytonopkem.Visible = false;
    }
    protected void btnCapmaso_Click(object sender, EventArgs e)
    {

    }
}