using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.DataAccess;
using INVI.Business;
using System.Globalization;
public partial class uc_ucDanhsachHosodangky : System.Web.UI.UserControl
{
    private byte m_pagesize = 20;
    protected int currentPage = 0;
    public Int32 PK_iHosodangky;
    public byte PageSize
    {
        get { return m_pagesize; }
        set { m_pagesize = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!PermissionBRL.CheckPermission("DuyethosodangkycuaCNST")) Response.End();
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
            lstHosodangky.AddRange(HosodangkychungnhanBRL.GetByFK_iTochucchungnhanID(lstTochucchungnhan_Taikhoan[0].FK_iTochucchungnhanID).FindAll(delegate(HosodangkychungnhanEntity entity){
            return entity.iTrangthai == 0;
        }));
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
                panCapmaso.Visible = false;
                break;
            case "Capmaso":
                Session["iHosodangkyCSNT"] = lbtnSource.CommandArgument;
                foreach(Control ctr in phCapmasoContent.Controls)
                {
                    phCapmasoContent.Controls.Remove(ctr);
                }
                Control ctrThongtinCapmaso = LoadControl("~/adminx/Tochucchungnhan/ucThongtinDangky.ascx");
                phCapmasoContent.Controls.Add(ctrThongtinCapmaso);
                panCapmaso.Visible = true;
                panGiaytonopkem.Visible = false;
                //Kiểm tra nút cấp mã số
                if(Session["bDanhgiaDat"] != null && Boolean.Parse(Session["bDanhgiaDat"].ToString()) == true)
                {
                    btnCapmaso.Enabled = true;
                }
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
        
        try
        {
            if (Session["UserID"] == null || Session["GroupID"] == null)
            {
                Response.Write("<script>alert('Bạn không có quyền vào trang này');location='./Logon.aspx'</script>");
                Response.End();
            }

            if (Session["iHosodangkyCSNT"] != null)
                PK_iHosodangky = Convert.ToInt32(Session["iHosodangkyCSNT"].ToString());
            else
            {
                Response.Redirect(ResolveUrl("~/adminx/Tochucchungnhan/Default.aspx?page=DanhsachHosodangky"));
            }
            HosodangkychungnhanEntity oHosodangky = HosodangkychungnhanBRL.GetOne(PK_iHosodangky);
            Int64 PK_iCosonuoitrongID = oHosodangky.FK_iCosonuoiID;

            if (!PermissionBRL.CheckPermission("licenseGAP")) Response.End();
            String sMasovietgap = String.Empty;
            CosonuoitrongEntity oCosonuoitrong = new CosonuoitrongEntity();
            //if (Session["iCosonuoitrongID"] == null) return;
            //PK_iCosonuoitrongID = Convert.ToInt32(Session["iCosonuoitrongID"].ToString());
            MasovietgapEntity oMasoVietGap = new MasovietgapEntity();
            oMasoVietGap.dNgaycap = DateTime.ParseExact(txtNgaycap_datepicker.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            oMasoVietGap.iThoihan = byte.Parse(txtThoihan.Value);
            txtNgayhethan_datepicker.Value = DateTime.ParseExact(txtNgaycap_datepicker.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddMonths(byte.Parse(txtThoihan.Value)).ToString("dd/MM/yyyy");
            oMasoVietGap.dNgayhethan = DateTime.ParseExact(txtNgayhethan_datepicker.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            oMasoVietGap.FK_iCosonuoitrongID = PK_iCosonuoitrongID;
            int iUserID = int.Parse(Session["UserID"].ToString());
            // Chỗ này phải check permission --> vì Admin không thuộc Group hay tổ chức nào
            int iGroupID = Convert.ToInt32(Session["GroupID"].ToString());

            if (iGroupID != 4)
            {
                Response.Write("<script>alert('Tài khoản bạn đang truy cập không phải dành cho Tổ chức chứng nhận. Bạn không thể cấp mã số!!!');location='./Logon.aspx'</script>");
                Response.End();
            }
            List<TochucchungnhanTaikhoanEntity> lstTochucTaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(iUserID);
            if (lstTochucTaikhoan.Count <= 0)
            {
                Response.Write("<script language=\"javascript\">alert('Tài khoản của bạn không gắn với bất cứ Tổ chức chứng nhận nào!!!');</script>");
                return;
            }
            TochucchungnhanEntity oTochucchungnhan = TochucchungnhanBRL.GetOne(lstTochucTaikhoan[0].FK_iTochucchungnhanID);
            List<XulyTochucchungnhanEntity> lstThongtinxuly = XulyTochucchungnhanBRL.GetByFK_iTochucchungnhanID(oTochucchungnhan.PK_iTochucchungnhanID);
            if (lstThongtinxuly.Count > 0)
            {
                XulyTochucchungnhanEntity.Sort(lstThongtinxuly, "dNgaythuchien", "DESC");
                if (lstThongtinxuly[0].iMucdo == 2 || lstThongtinxuly[0].iMucdo == 3)
                {
                    Response.Write("<script language=\"javascript\">alert('Bạn không thể cấp mã số, vì đang bị xử lý phạt');</script>");
                    return;
                }
            }
            oMasoVietGap.FK_iTochucchungnhanID = oTochucchungnhan.PK_iTochucchungnhanID;

            //Kiểm tra xem mã số VietGap này đã có hay chưa
            sMasovietgap = genVietGapCode((int)PK_iCosonuoitrongID, oTochucchungnhan.PK_iTochucchungnhanID);
            oMasoVietGap.sMaso = sMasovietgap;
            // Kiểm tra xem CSNT đã tồn tại hay chưa, vì mỗi một CSNT chỉ được cấp mã số 1 lần
            // Có thể cập nhập mã số - viết một chức năng khác
            List<MasovietgapEntity> lstMasovietgap = MasovietgapBRL.GetByFK_iCosonuoitrongID(PK_iCosonuoitrongID);
            if (lstMasovietgap.Capacity == 0)
            {
                MasovietgapBRL.Add(oMasoVietGap);
                oCosonuoitrong = CosonuoitrongBRL.GetOne(PK_iCosonuoitrongID);
                //oCosonuoitrong.sMasocoso = Session["sMasocoso"].ToString();
                oCosonuoitrong.sMasocoso = oTochucchungnhan.sKytuviettat;
                oCosonuoitrong.sMaso_vietgap = sMasovietgap;
                CosonuoitrongBRL.Edit(oCosonuoitrong);
                HosodangkychungnhanEntity oHoso = HosodangkychungnhanBRL.GetOne(PK_iHosodangky);
                oHoso.iTrangthai = 1; //Đã duyệt
                HosodangkychungnhanBRL.Edit(oHoso);
            }
            else
            {
                INVI.INVILibrary.MessageBox.Show("Cơ sở nuôi trồng đã được cấp mã số");
            }
            //CosonuoitrongBRL.SetVerify(PK_iCosonuoitrongID, chk.Checked);
            //Nap lai du lieu
            //Response.Redirect(Request.Url.ToString());


            Response.Write("<script>alert('CSNT:" + oCosonuoitrong.sTencoso + " đã được cấp mã số:" + oMasoVietGap.sMaso + "');</script>");
            //Ẩn panel
            panCapmaso.Visible = false;
        }
        catch (Exception ex)
        {
            Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=DanhsachHosodangky';</script>");
        }
    }
    protected void btnAncapmaso_Click(object sender, EventArgs e)
    {
        panCapmaso.Visible = false;
    }

    private String genVietGapCode(int PK_iCosonuoitrongID, int PK_iTochucchungnhanID)
    {
        String sVietGapCode = string.Empty;
        CosonuoitrongEntity oEntity = CosonuoitrongBRL.GetOne(PK_iCosonuoitrongID);
        ////Cần phải sửa lại chỗ này để lấy ra mã tỉnh + huyện  
        QuanHuyenEntity oQuanHuyen = QuanHuyenBRL.GetOne(int.Parse(oEntity.FK_iQuanHuyenID.ToString()));
        TinhEntity oTinh = TinhBRL.GetOne(oQuanHuyen.FK_iTinhThanhID);
        TochucchungnhanEntity oTochucchungnhan = TochucchungnhanBRL.GetOne(PK_iTochucchungnhanID);
        // Theo Thông tư mới - chỗ này phải lấy tiền tố của TCCN
        sVietGapCode += oTochucchungnhan.sMaso+"-";
        sVietGapCode += oTinh.sKyhieu + "-";
        //sVietGapCode += oQuanHuyen.sKytuviettat+"-";
        //DoituongnuoiEntity oDoituongnuoi = DoituongnuoiBRL.GetOne(oEntity.FK_iDoituongnuoiID);
        //sVietGapCode += oDoituongnuoi.sKytu + "-";
        // Không sinh ngẫu nhiên nữa mà phải đếm xem có bao nhiêu
        //1. Lấy danh sách các CSNT đã được cấp mã số
        List<MasovietgapEntity> lstCSNT_daduocmaso = MasovietgapBRL.GetByFK_iTochucchungnhanID(oTochucchungnhan.PK_iTochucchungnhanID).FindAll(delegate(MasovietgapEntity oHoso)
        {
            return (QuanHuyenBRL.GetOne(CosonuoitrongBRL.GetOne(oHoso.FK_iCosonuoitrongID).FK_iQuanHuyenID).FK_iTinhThanhID == oTinh.PK_iTinhID);
        }
        );
        lstCSNT_daduocmaso.Sort(delegate(MasovietgapEntity firstEntity, MasovietgapEntity secondEntity)
        {
            return secondEntity.sMaso.CompareTo(firstEntity.sMaso);
        }
        );
        // Sắp xếp rồi lấy ra bác có giá trị lớn nhất rồi cộng
        String sMasomoinhat = String.Empty;
        String sMasocoso = String.Empty;
        String[] sDulieutrongmaso=null;
        if (lstCSNT_daduocmaso.Count > 0)
            sMasomoinhat = CosonuoitrongBRL.GetOne(lstCSNT_daduocmaso[0].FK_iCosonuoitrongID).sMaso_vietgap;
        else
            sMasocoso = taoMacoso(0);
        if(sMasomoinhat.Length>0)
            sDulieutrongmaso = sMasomoinhat.Split('-');
        if (sDulieutrongmaso!=null&&sDulieutrongmaso.Length > 0)
            sMasocoso = taoMacoso(Convert.ToInt16(sDulieutrongmaso[sDulieutrongmaso.Length - 1]));
        
        //Session["sMasocoso"] = sMasocoso;
        sVietGapCode += sMasocoso;
        return sVietGapCode;
    }

    private String taoMacoso(int iSoCosonuoitrong)
    {
        String sMacoso = String.Empty;
        if (iSoCosonuoitrong > 100)
            sMacoso = "0" + (iSoCosonuoitrong + 1);
        else if (iSoCosonuoitrong > 10)
            sMacoso = "00" + (iSoCosonuoitrong + 1);
        else if (iSoCosonuoitrong > 0)
            sMacoso = "000" + (iSoCosonuoitrong + 1);
        
        return sMacoso;
    }
}