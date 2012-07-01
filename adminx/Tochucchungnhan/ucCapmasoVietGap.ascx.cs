using INVI.Entity;
using INVI.Business;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.IO;
public partial class adminx_ucCapmasoVietGap : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!PermissionBRL.CheckPermission("licenseGAP")) Response.End();
        if (!Page.IsPostBack)
        {
            
            txtNgaycap_datepicker.Value = DateTime.Now.ToString("dd/MM/yyyy");
            //txtThoihan.Attributes.Add("onblur","return validate(this.value)");
            txtThoihan.Attributes.Add("OnBlur", "javascript:addMonth();");
            Session["iCosonuoitrongID"] = null;
            napGridView();
        }
        
        if (Request.QueryString["FK_iCosonuoiID"] != null)
        {
            int iFK_cosonuoiID = Convert.ToInt32(Request.QueryString["FK_iCosonuoiID"].ToString());
            Session["iCosonuoitrongID"] = Request.QueryString["FK_iCosonuoiID"];
            HienKetQua(iFK_cosonuoiID);
            pnThongtinCosonuoitrong.Visible = true;
        }
    }
    private void napGridView()
    {
        //List<CosonuoitrongEntity> list = CosonuoitrongBRL.GetAll();
        //list=list.FindAll(delegate(CosonuoitrongEntity oCosonuoitrong)
        //{
        //    return ((oCosonuoitrong.bDuyet==true)&&(oCosonuoitrong.sMaso_vietgap==""));
        //});
        int iUserID = Convert.ToInt32(Session["UserID"].ToString());
        List<TochucchungnhanTaikhoanEntity> lstTochucTaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(iUserID);
        
        if (lstTochucTaikhoan.Count <=0)
            return;
        List<HosodangkychungnhanEntity> lstHosodangkychungnhan = HosodangkychungnhanBRL.GetAll().FindAll(delegate(HosodangkychungnhanEntity oHoso) {
            return (oHoso.iTrangthai == 0 && oHoso.FK_iTochucchungnhanID == lstTochucTaikhoan[0].FK_iTochucchungnhanID);
        });
        grvHosodangkychungnhan.DataSource = lstHosodangkychungnhan;
        grvHosodangkychungnhan.DataKeyNames = new string[] { "PK_iHosodangkychungnhanID" };

        grvHosodangkychungnhan.DataBind();
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
        sVietGapCode += oTinh.sKyhieu + "-";
        //sVietGapCode += oQuanHuyen.sKytuviettat+"-";
        //DoituongnuoiEntity oDoituongnuoi = DoituongnuoiBRL.GetOne(oEntity.FK_iDoituongnuoiID);
        //sVietGapCode += oDoituongnuoi.sKytu + "-";
        // Không sinh ngẫu nhiên nữa mà phải đếm xem có bao nhiêu
        //1. Lấy danh sách các CSNT đã được cấp mã số
        List<MasovietgapEntity> lstCSNT_daduocmaso = MasovietgapBRL.GetByFK_iTochucchungnhanID(oTochucchungnhan.PK_iTochucchungnhanID).FindAll(delegate(MasovietgapEntity oHoso)
        {
            return oHoso.iTrangthai == 2 && (QuanHuyenBRL.GetOne(CosonuoitrongBRL.GetOne(oHoso.FK_iCosonuoitrongID).FK_iQuanHuyenID).FK_iTinhThanhID == oTinh.PK_iTinhID);
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
        if (lstCSNT_daduocmaso.Count > 0)
            sMasomoinhat = CosonuoitrongBRL.GetOne(lstCSNT_daduocmaso[lstCSNT_daduocmaso.Count - 1].FK_iCosonuoitrongID).sMaso_vietgap;
        String[] sDulieutrongmaso = sMasomoinhat.Split('-');
        if (sDulieutrongmaso.Length > 0)
            sMasocoso = taoMacoso(Convert.ToInt16(sDulieutrongmaso[sDulieutrongmaso.Length - 1]) + 1);
        //Session["sMasocoso"] = sMasocoso;
        sVietGapCode += sMasocoso;
        return sVietGapCode;
    }
    private String taoMacoso(int iSoCosonuoitrong)
    {
        String sMacoso = String.Empty;
        if (iSoCosonuoitrong > 100)
            sMacoso = "0" + iSoCosonuoitrong + 1;
        else if (iSoCosonuoitrong > 10)
            sMacoso = "00" + iSoCosonuoitrong + 1;
        else if (iSoCosonuoitrong > 0)
            sMacoso = "000" + iSoCosonuoitrong + 1;
        return sMacoso;
    }
    //private String randomString(int iLeng)
    //{
    //    string allowedChars = "";
    //    allowedChars += "1,2,3,4,5,6,7,8,9,0";

    //    char[] sep = { ',' };
    //    string[] arr = allowedChars.Split(sep);

    //    string passwordString = "";

    //    string temp = "";

    //    Random rand = new Random();
    //    for (int i = 0; i < iLeng; i++)
    //    {
    //        temp = arr[rand.Next(0, arr.Length)];
    //        passwordString += temp;
    //    }
    //    return passwordString;
    //}
    
    private String sTentinhthanh(int iTinhthanhID)
    {
        String sTentinhthanh = String.Empty;
        TinhEntity oTinhthanh = TinhBRL.GetOne((byte)iTinhthanhID);
        if(oTinhthanh!=null)
        sTentinhthanh = oTinhthanh.sTentinh;
        return sTentinhthanh;
    }
    private String getTendoituongnuoi(byte iDoituongnuoiID)
    {
        String sDoituongnuoi = String.Empty;
        DoituongnuoiEntity oDoituongnuoi = DoituongnuoiBRL.GetOne(iDoituongnuoiID);
        if(oDoituongnuoi!=null)
            sDoituongnuoi = oDoituongnuoi.sTendoituong;
        return sDoituongnuoi;
    }
    private bool checkIfMasoExist(String sMasoVietGap)
    {
        bool bIsExist = false;
        try
        {
            MasovietgapEntity oMasoVietGap = MasovietgapBRL.GetOne(int.Parse(sMasoVietGap));
            if (oMasoVietGap != null)
                bIsExist = true;
        }
        catch
        {
            bIsExist = false;
        }
        return bIsExist;
    }
       
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearchByID.Text;
        int iHo = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            iHo = 0;
        else iHo = Int16.Parse(txtID.Text);
        List<CosonuoitrongEntity> lstCSNT = CosonuoitrongBRL.GetAll();
        if (iHo == 0)
        {
            lstCSNT = lstCSNT.FindAll(
            delegate(CosonuoitrongEntity oCSNT)
            {
                return oCSNT.sTencoso.ToUpper().Contains(strSearch.ToUpper()) && oCSNT.bDuyet == false;
            }
            );
        }
        else
        {
            lstCSNT = lstCSNT.FindAll(
            delegate(CosonuoitrongEntity oCSNT)
            {
                return oCSNT.PK_iCosonuoitrongID == iHo && oCSNT.bDuyet == false;
            }
            );
        }
        lblThongbao.Text = "";
        grvHosodangkychungnhan.DataSource = lstCSNT;
        grvHosodangkychungnhan.DataKeyNames = new string[] { "PK_iCosonuoitrongID" };
        grvHosodangkychungnhan.DataBind();
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napGridView();
    }

    protected void grvCosonuoitrong_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblTinhthanh = null, lblDoituongnuoi = null, lblCosonuoi = null, lblTongdientich=null,lblSanluong=null;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            lblTinhthanh = (Label)e.Row.FindControl("lblTinhthanh");
            lblDoituongnuoi = (Label)e.Row.FindControl("lblDoituongnuoi");
            lblCosonuoi = (Label)e.Row.FindControl("lblCosonuoi");
            lblTongdientich = (Label)e.Row.FindControl("lblTongdientich");
            lblSanluong = (Label)e.Row.FindControl("lblSanluong");
            long iCosonuoiID = Convert.ToInt64(lblCosonuoi.Text);
            CosonuoitrongEntity oCosonuoi = CosonuoitrongBRL.GetOne(iCosonuoiID);
            if (lblTinhthanh != null)
            {
                int bTinhthanhID = int.Parse(lblTinhthanh.Text);
                QuanHuyenEntity oQuanHuyen = QuanHuyenBRL.GetOne(oCosonuoi.FK_iQuanHuyenID);
                lblTinhthanh.Text = sTentinhthanh(oQuanHuyen.FK_iTinhThanhID);
            }
            if (lblDoituongnuoi != null)
                lblDoituongnuoi.Text = getTendoituongnuoi((byte)oCosonuoi.FK_iDoituongnuoiID);
            if (lblCosonuoi != null) lblCosonuoi.Text = oCosonuoi.sTencoso;
            if (lblTongdientich != null) lblTongdientich.Text = oCosonuoi.fTongdientich.ToString();
            if (lblSanluong != null) lblSanluong.Text = oCosonuoi.iSanluongdukien.ToString();
        }
        
    }
    protected void grvCosonuoitrong_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvHosodangkychungnhan.PageIndex = e.NewPageIndex;
        napGridView();
    }
    protected void grvCosonuoitrong_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<CosonuoitrongEntity> list = CosonuoitrongBRL.GetAll().FindAll(delegate(CosonuoitrongEntity oCosonuoitrong) { return oCosonuoitrong.bDuyet == false; });
        grvHosodangkychungnhan.DataSource = CosonuoitrongEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
        grvHosodangkychungnhan.DataKeyNames = new string[] { "PK_iCosonuoitrongID" };
        grvHosodangkychungnhan.DataBind();
    }
    protected void grvCosonuoitrong_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int iCosonuoitrongID = 0;
        iCosonuoitrongID = Convert.ToInt32(grvHosodangkychungnhan.DataKeys[e.NewSelectedIndex].Values["PK_iCosonuoitrongID"]);
        Session["iCosonuoitrongID"] = iCosonuoitrongID;
        
        HienKetQua(iCosonuoitrongID);
       
    }
    protected void phlChitiet_PreRender(object sender, EventArgs e)
    {
        
    }
    public void HienKetQua(int PK_iCosonuoitrongID)
    {
        int iSochitieudatA = 0, iSochitieudatB = 0;
        MucdoEntity oMucdo;
        ChitieuEntity oChitieu;
        
        List<DanhgiaketquaEntity> lstDanhgiaketqua = DanhgiaketquaBRL.GetByFK_iCosonuoiID(PK_iCosonuoitrongID);
        if (lstDanhgiaketqua.Count == 0) return;
        int iSochitieuA = 0, iSochitieuB = 0;
        for (int i = 0; i < lstDanhgiaketqua.Count; ++i)
        {
            oChitieu = ChitieuBRL.GetOne(lstDanhgiaketqua[i].FK_iChitieuID);
            oMucdo = MucdoBRL.GetOne(oChitieu.FK_iMucdoID);
            if (oMucdo.sTenmucdo == "A")
                iSochitieuA++;
            else
                iSochitieuB++;
            if (lstDanhgiaketqua[i].iKetqua == 1)
            {
                if (oMucdo.sTenmucdo == "A")
                    ++iSochitieudatA;
                else
                    ++iSochitieudatB;
            }

        }
        int iSochitieu = ChitieuBRL.Count();
        int iSochitieuDat = DanhgiaketquaBRL.CountTrue(PK_iCosonuoitrongID);
        lblDatyeucau.Text = iSochitieuDat.ToString();
        lblChuadatyeucau.Text = (iSochitieu - iSochitieuDat).ToString();
        int iPhantramdat = (iSochitieuDat * 100) / iSochitieu;
        lblPhantramdatyeucau.Text = iPhantramdat.ToString();
        lblPhantramchuadatyeucau.Text = (100 - iPhantramdat).ToString();
        //
        lblDatyeucauA.Text = iSochitieudatA.ToString();
        lblPhantramdatyeucauA.Text = ((iSochitieudatA * 100) / iSochitieuA).ToString();

        lblDatyeucauB.Text = iSochitieudatB.ToString();
        lblPhantramdatyeucauB.Text = ((iSochitieudatB * 100) / iSochitieuB).ToString();
        // Nếu số lượng chỉ tiêu Mức A đạt 100%
        // chỉ tiêu Mức B đạt 90%

        // Lấy các giấy phép kèm theo, nếu không có thì ko hiện nút Cấp phép
        List<GiaytonopkemhosoEntity> lstGiaytonopkem = GiaytonopkemhosoBRL.GetByPK_iHosodangkychungnhanID(HosodangkychungnhanBRL.GetByFK_iCosonuoiID(PK_iCosonuoitrongID)[0].PK_iHosodangkychungnhanID);
        if (lstGiaytonopkem != null && lstGiaytonopkem.Count > 0)
        {
            btnCapPhep.Visible = true;
            rptHoSoKemTheo.DataSource = lstGiaytonopkem;
            rptHoSoKemTheo.DataBind();
        }
        else
            btnCapPhep.Visible = false;

        if (iSochitieuA == iSochitieudatA && ((iSochitieudatB * 100) / iSochitieuB)>=90&&lstGiaytonopkem.Count>0)
            btnCapPhep.Visible = true;
        
    }
    protected void btnCapPhep_Click(object sender, EventArgs e)
    {
            try
            {
                if (Session["UserID"] == null || Session["GroupID"] == null)
                {
                    Response.Write("<script>alert('Bạn không có quyền vào trang này');location='./Logon.aspx'</script>");
                    Response.End();
                }

                if (!PermissionBRL.CheckPermission("licenseGAP")) Response.End();
                String sMasovietgap = String.Empty;
                CosonuoitrongEntity oCosonuoitrong = new CosonuoitrongEntity();
                if (Session["iCosonuoitrongID"] == null) return;
                int PK_iCosonuoitrongID = Convert.ToInt32(Session["iCosonuoitrongID"].ToString());
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
                sMasovietgap = genVietGapCode(PK_iCosonuoitrongID, oTochucchungnhan.PK_iTochucchungnhanID);
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
                }
                else
                {
                    INVI.INVILibrary.MessageBox.Show("Cơ sở nuôi trồng đã được cấp mã số");
                }
                //CosonuoitrongBRL.SetVerify(PK_iCosonuoitrongID, chk.Checked);
                //Nap lai du lieu
                //Response.Redirect(Request.Url.ToString());


                Response.Write("<script>alert('CSNT:" + oCosonuoitrong.sTencoso + " đã được cấp mã số:" + oMasoVietGap.sMaso + "');</script>");
                napGridView();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=CapmasoVietGap';</script>");
            }
    }
    protected void rptHoSoKemTheo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblID = (Label)e.Item.FindControl("FK_iGiaytoID");
            Label lblTenGiayTo = (Label)e.Item.FindControl("lblTenGiayTo");
            GiaytoEntity oGiayTo = GiaytoBRL.GetOne(Convert.ToInt32(lblID.Text));
            
        }

    }
    protected void btnXem_Click(object sender, EventArgs e)
    {
        string strControl = "../UserMethods/ucDanhgiaketqua.ascx";
        if (File.Exists(Server.MapPath(strControl)))
        {
            Control ctrl = LoadControl(strControl);
            if (ctrl != null)
            {
                phlBangdanhgianoibo.Controls.Add(ctrl);
            }
        }
    }
}