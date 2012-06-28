using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.Business;
using System.IO;

public partial class adminx_ucDangkytochucchungnhan : System.Web.UI.UserControl
{
    public int PK_iUserID;
    public int iTochucID = 0;
    public int iDangkychungnhan = 0;

    public List<DangkyHoatdongchungnhanEntity> DanhsachDangkyHoatdongchungnhan
    {
        get
        {
            if (Cache["DanhsachDangkyHoatdongchungnhan"] == null)
                return new List<DangkyHoatdongchungnhanEntity>();
            else
                return (List<DangkyHoatdongchungnhanEntity>)Cache["DanhsachDangkyHoatdongchungnhan"];
        }
        set { Cache["DanhsachDangkyHoatdongchungnhan"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
            Response.Redirect("~/");
        else
            PK_iUserID = int.Parse(Session["userID"].ToString());
        // Lấy danh sách tổ chức chứng nhận dựa trên userID
        // chú ý:
        // 1. Dựa trên bảng Tổ chức chứng nhận - Tài khoản
        // 2. Do kiểu thiết kế nên 1 User có thể quản lý nhiều TCCN; Nhưng cần phải kiểm soát để không cho phép gán nhiều hơn 1 user cho 1 TCCN
        // buộc phải xóa đi 1 User để có thể gán User mới

        
        List<TochucchungnhanTaikhoanEntity> lstTochucTaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(PK_iUserID);

        if (lstTochucTaikhoan.Count > 0)
            iTochucID = lstTochucTaikhoan[0].FK_iTochucchungnhanID;
        PK_iUserID = int.Parse(Session["userID"].ToString());
        if (!IsPostBack)
        {
            LoadGiayToKemTheo();
            NapDllQuanhuyen();
            CheckByUserID(PK_iUserID);
        }
        if (!Page.IsPostBack)
        {
            // Lấy dữ liệu ra đưa vào Cache
            List<DangkyHoatdongchungnhanEntity> lstDangkyhoatdongChungnhan = DangkyHoatdongchungnhanBRL.GetByFK_iTochucchungnhanID(iTochucID);
            if (lstDangkyhoatdongChungnhan != null && lstDangkyhoatdongChungnhan.Count > 0) // Nếu đã từng đăng ký
            {// sắp xếp danh sách giảm dần theo thời gian đăng ký, để lấy ra lần đăng ký gần nhất
                DangkyHoatdongchungnhanEntity.Sort(lstDangkyhoatdongChungnhan, "dNgaydangky", "DESC");
                DanhsachDangkyHoatdongchungnhan = lstDangkyhoatdongChungnhan;
            }
        }
    }

    public void FillData(TochucchungnhanEntity obj)
    {
        txtTentochuc.Value = obj.sTochucchungnhan;
        txtKytuviettat.Value = obj.sKytuviettat;
        txtDiachi.Value = obj.sDiachi;
        ddlQuanhuyen.Items.FindByValue(obj.FK_iQuanHuyenID.ToString()).Selected = true;
        //---Load img
        if (obj.imgLogo != null)
        {
            imgLogo.ImageUrl = "~/adminx/ShowTochucLogo.ashx?id=" + obj.PK_iTochucchungnhanID;
            if (imgLogo != null)
            {
                RequiredFieldValidatorimg.Enabled = false;
                imgLogo.Visible = true;
            }
        }
        //---Load tài liệu
        
        if (DanhsachDangkyHoatdongchungnhan.Count > 0)
        {
            List<HosokemtheoTochucchungnhanEntity> lstHoso = HosokemtheoTochucchungnhanBRL.GetByFK_iDangkyChungnhanVietGapID(DanhsachDangkyHoatdongchungnhan[0].PK_iDangkyChungnhanVietGapID);
            if (DanhsachDangkyHoatdongchungnhan[0].iLandangky > 1)
            {
                lblThongbao.Text = "Tổ chức đã đăng ký: " + DanhsachDangkyHoatdongchungnhan[0].iLandangky + " lần.";
                lblThongbao.Visible = true;
            }
            for (int i = 0; i < cblGiaytonopkem.Items.Count; ++i)
            {
                if (lstHoso.FindAll
                    (
                        delegate(HosokemtheoTochucchungnhanEntity oHoso)
                        {
                            return (oHoso.FK_iGiaytoID == int.Parse(cblGiaytonopkem.Items[i].Value));
                        }
                    ).Count > 0)
                {
                    cblGiaytonopkem.Items[i].Selected = true;
                }
            }
        }
        //----
        txtSodienthoai.Value = obj.sSodienthoai;
        txtFax.Value = obj.sFax;
        txtEmail.Value = obj.sEmail;
        txtSodangkydinhdoanh.Value = obj.sSodangkykinhdoanh;
        txtNoicap.Value = obj.sNoicapdangkykinhdoanh;
        txtNgaycap_datepicker.Value = obj.dNgaycapdangkykinhdoanh.ToString("dd/MM/yyyy");
        if (obj.bDuyet)
            lblTrangthai.Text = "Ðã duyệt";
        else
            lblTrangthai.Text = "Chưa duyệt";
    }

    public void Reset()
    {
        txtTentochuc.Value = "";
        txtKytuviettat.Value = "";
        txtDiachi.Value = "";
        txtSodienthoai.Value = "";
        txtFax.Value = "";
        txtEmail.Value = "";
        txtSodangkydinhdoanh.Value = "";
        txtNoicap.Value = "";
        lblTrangthai.Text = "";
        txtNgaycap_datepicker.Value = "";
        btnSua.Visible = true;
        btnHuy.Visible = false;
        btnLuu.Visible = false;
        CheckByUserID(PK_iUserID);
        lblThongbao.Text = "";
    }

    public void CheckByUserID(Int32 PK_iUserID)
    {
        List<TochucchungnhanTaikhoanEntity> lstTochucTaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(PK_iUserID);

        if (lstTochucTaikhoan.Count > 0){
            iTochucID = lstTochucTaikhoan[0].FK_iTochucchungnhanID;
            btnAdd.CommandArgument = iTochucID.ToString();
        }
        if (iTochucID != 0)
        {

            if (DanhsachDangkyHoatdongchungnhan != null && DanhsachDangkyHoatdongchungnhan.Count > 0)
            {
                btnAdd.Visible = true; // nếu đã có thì đổi Text = "Đăng ký lại";
                btnAdd.Text = "Đăng ký lại (lần"+(DanhsachDangkyHoatdongchungnhan[0].iLandangky+1)+")";
                btnSua.Visible = false;
            }
            else
            {
                btnAdd.Visible = true;
                btnAdd.Text = "Đăng ký";
            }
            TochucchungnhanEntity oTochuc = TochucchungnhanBRL.GetOne(iTochucID);
            FillData(oTochuc);
            OnOffEdit(false);
        }
        else // nếu chưa có thì ẩn nút sửa? để đăng ký
        {
            OnOffEdit(true);
            btnLuu.Visible = false;
        }
    }

    public void NapDllQuanhuyen()
    {
        List<QuanHuyenEntity> lstQuanhuyen = QuanHuyenBRL.GetAll();
        ddlQuanhuyen.Items.Clear();
        ddlQuanhuyen.DataSource = lstQuanhuyen;
        ddlQuanhuyen.DataTextField = "sTen";
        ddlQuanhuyen.DataValueField = "PK_iQuanHuyenID";
        ddlQuanhuyen.DataBind();
    }
    private void LoadGiayToKemTheo()
    {
        List<GiaytoEntity> lstGiayTo = GiaytoBRL.GetAll().FindAll(delegate(GiaytoEntity oGiayto) { return oGiayto.bCSNT==false; });
        cblGiaytonopkem.DataSource = lstGiayTo;
        cblGiaytonopkem.DataTextField = "sTengiayto";
        cblGiaytonopkem.DataValueField = "PK_iGiaytoID";
        cblGiaytonopkem.DataBind();
    }
    public void AddTochucchungnhan(object sender, EventArgs e)
    {
        //TochucchungnhanEntity oTochucchungnhan = new TochucchungnhanEntity();
        //oTochucchungnhan.sTochucchungnhan = txtTentochuc.Value;
        //oTochucchungnhan.sKytuviettat = txtKytuviettat.Value;
        //oTochucchungnhan.sDiachi = txtDiachi.Value;
        //oTochucchungnhan.FK_iQuanHuyenID = int.Parse(ddlQuanhuyen.SelectedValue);
        //oTochucchungnhan.sSodienthoai = txtSodienthoai.Value;
        //oTochucchungnhan.FK_iUserID = PK_iUserID;
        //oTochucchungnhan.imgLogo = CreateImgByte();
        //oTochucchungnhan.sFax = txtFax.Value;
        //oTochucchungnhan.sEmail = txtEmail.Value;
        //oTochucchungnhan.sSodangkykinhdoanh = txtSodangkydinhdoanh.Value;
        //oTochucchungnhan.sCoquancap = txtCoquancapphep.Value;
        //oTochucchungnhan.dNgaycapdangkykinhdoanh = DateTime.Parse(txtNgaycap_datepicker.Value);
        //oTochucchungnhan.sNoicapdangkykinhdoanh = txtNoicap.Value;
        //oTochucchungnhan.bDuyet = false;
        //iTochucID = TochucchungnhanBRL.Add(oTochucchungnhan);
        

        // Ở đây chỉ lấy iTochucID để lấy thông tin về Hồ sơ kèm theo

        iTochucID = Convert.ToInt32(btnAdd.CommandArgument);

        // Truy vấn để xác định nếu vẫn đang bị phạt < 1 năm thì không cho phép đăng ký

        List<XulyTochucchungnhanEntity> lstXulytochucchungnhan = XulyTochucchungnhanBRL.GetByFK_iTochucchungnhanID(iTochucID);
        if (lstXulytochucchungnhan != null && lstXulytochucchungnhan.Count > 0)
        {
            XulyTochucchungnhanEntity.Sort(lstXulytochucchungnhan, "dNgaythuchien", "DESC");
            if (lstXulytochucchungnhan[0].iMucdo==3&&DateTime.Today.Year - lstXulytochucchungnhan[0].dNgaythuchien.Year < 1)
            {
                lblThongbao.Text = "Hiện tại tổ chức bị xử lý chưa quá 1 năm...";
                lblThongbao.Visible = true;
            }
        }
        DangkyHoatdongchungnhanEntity oDangky = new DangkyHoatdongchungnhanEntity();
        oDangky.FK_iTochucchungnhanID = iTochucID;
        oDangky.iTrangthaidangky = 0;
        oDangky.dNgaydangky = DateTime.Today;
        if (DanhsachDangkyHoatdongchungnhan.Count > 0)
            oDangky.iLandangky = (short)((int)DanhsachDangkyHoatdongchungnhan[0].iLandangky + 1);
        else
            oDangky.iLandangky = 1; // đăng ký lần đầu
        iDangkychungnhan = DangkyHoatdongchungnhanBRL.Add(oDangky);
        if (iDangkychungnhan > 0)
        {
            HosokemtheoTochucchungnhanEntity oHoso = new HosokemtheoTochucchungnhanEntity();
            //----------Lưu giấy tờ nộp kèm
            for (int i = 0; i < cblGiaytonopkem.Items.Count; ++i)
            {
                if (cblGiaytonopkem.Items[i].Selected)
                {
                    oHoso.FK_iDangkyChungnhanVietGapID = iDangkychungnhan;
                    oHoso.FK_iGiaytoID = int.Parse(cblGiaytonopkem.Items[i].Value);
                    HosokemtheoTochucchungnhanBRL.Add(oHoso);
                }
            }
        }
        //--------------------------------------
        lblThongbao.Text = "Ðăng ký thành công!";
        OnOffEdit(false);
        CheckByUserID(PK_iUserID);
    }

    public Byte[] CreateImgByte()
    {
        Byte[] imgByte = null;
        try
        {
            FileUpload img = (FileUpload)imgUpload;
            if (img.HasFile && img.PostedFile != null)
            {
                //To create a PostedFile
                HttpPostedFile File = imgUpload.PostedFile;
                //Create byte Array with file len
                imgByte = new Byte[File.ContentLength];
                //force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength);
                return imgByte;
            }
        }
        catch
        {
            lblThongbao.Text = "Không tải được logo!";
        }
        return imgByte;
    }

    public void OnOffEdit(bool f)
    {
        txtTentochuc.Disabled = !f;
        txtKytuviettat.Disabled = !f;
        txtDiachi.Disabled = !f;
        ddlQuanhuyen.Enabled = f;
        cblGiaytonopkem.Enabled = f;
        txtSodienthoai.Disabled = !f;
        imgUpload.Enabled = f;
        txtFax.Disabled = !f;
        txtEmail.Disabled = !f;
        txtSodangkydinhdoanh.Disabled = !f;
        txtCoquancapphep.Disabled = !f;
        txtNgaycap_datepicker.Disabled = !f;
        txtNoicap.Disabled = !f;     
        btnLuu.Visible = f;
        btnHuy.Visible = f;
        btnSua.Visible = !f;

    }
    protected void EditTochucchungnhan(object sender, EventArgs e)
    {
        OnOffEdit(true);
    }
    protected void SaveChange(object sender, EventArgs e)
    {
        TochucchungnhanEntity oTochucchungnhan = TochucchungnhanBRL.GetOne(iTochucID);
        oTochucchungnhan.sTochucchungnhan = txtTentochuc.Value;
        oTochucchungnhan.sKytuviettat = txtKytuviettat.Value;
        oTochucchungnhan.sDiachi = txtDiachi.Value;
        oTochucchungnhan.FK_iQuanHuyenID = int.Parse(ddlQuanhuyen.SelectedValue);
        oTochucchungnhan.sSodienthoai = txtSodienthoai.Value;
        FileUpload img = (FileUpload)imgUpload;
        if (img.HasFile)
        {
            oTochucchungnhan.imgLogo = CreateImgByte();
        }
        oTochucchungnhan.sFax = txtFax.Value;
        oTochucchungnhan.sEmail = txtEmail.Value;
        oTochucchungnhan.sSodangkykinhdoanh = txtSodangkydinhdoanh.Value;
        oTochucchungnhan.sCoquancap = txtCoquancapphep.Value;
        oTochucchungnhan.dNgaycapdangkykinhdoanh = DateTime.Parse(txtNgaycap_datepicker.Value);
        oTochucchungnhan.sNoicapdangkykinhdoanh = txtNoicap.Value;
        oTochucchungnhan.sKytuviettat = " ";
        TochucchungnhanBRL.Edit(oTochucchungnhan);
        //---Cập nhật lại tài liệu
        List<DangkyHoatdongchungnhanEntity> lstDangky = DangkyHoatdongchungnhanBRL.GetByFK_iTochucchungnhanID(oTochucchungnhan.PK_iTochucchungnhanID);
        if (lstDangky.Count > 0)
        {
            List<HosokemtheoTochucchungnhanEntity> lstHoso = HosokemtheoTochucchungnhanBRL.GetByFK_iDangkyChungnhanVietGapID(lstDangky[0].PK_iDangkyChungnhanVietGapID);
            for (int i = 0; i < lstHoso.Count; ++i)
            {
                HosokemtheoTochucchungnhanBRL.Remove(lstHoso[i].PK_iHosokemtheoID);
            }
            HosokemtheoTochucchungnhanEntity oHoso = new HosokemtheoTochucchungnhanEntity();
            //----------Lưu giấy tờ nộp kèm
            for (int i = 0; i < cblGiaytonopkem.Items.Count; ++i)
            {
                if (cblGiaytonopkem.Items[i].Selected)
                {
                    oHoso.FK_iDangkyChungnhanVietGapID = lstDangky[0].PK_iDangkyChungnhanVietGapID;
                    oHoso.FK_iGiaytoID = int.Parse(cblGiaytonopkem.Items[i].Value);
                    HosokemtheoTochucchungnhanBRL.Add(oHoso);
                }
            }
        }
       
        lblThongbao.Text = "Cập nhật thông tin thành công!";
        OnOffEdit(false);
        CheckByUserID(PK_iUserID);
    }
    protected void Huy(object sender, EventArgs e)
    {
        Reset();
    }
    
}