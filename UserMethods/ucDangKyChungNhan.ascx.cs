using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.Business;
public partial class UserMethods_ucDangKyChungNhan : System.Web.UI.UserControl
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGiayToKemTheo();            
            int idCoSoNuoi = Convert.ToInt32(Session["iCosonuoitrongID"]);
            LoadInfo();
            loadTocchucchungnhan();
        }
    }
    private void loadTocchucchungnhan()
    {
        List<TochucchungnhanEntity> lstTochucchungnhan = TochucchungnhanBRL.GetAll();
        ddlTochucchungnhan.DataSource = lstTochucchungnhan;
        ddlTochucchungnhan.DataTextField = "sTochucchungnhan";
        ddlTochucchungnhan.DataValueField = "PK_iTochucchungnhanID";
        ddlTochucchungnhan.DataBind();
    }
    private void LoadGiayToKemTheo()
    {
        List<GiaytoEntity> lstGiayTo = GiaytoBRL.GetAll();        
        cblHoSoCSNTKemtheo.DataTextField = "sTengiayto";
        cblHoSoCSNTKemtheo.DataValueField = "PK_iGiaytoID";
        cblHoSoCSNTKemtheo.DataSource = lstGiayTo;
        cblHoSoCSNTKemtheo.DataBind();
    }
    private void LoadInfo()
    {
        if (Session["iCosonuoitrongID"] == null)
        {
            Response.Write("<script>alert('Cần phải điền đầy đủ các thông tin trước khi gửi đơn đăng ký để được chứng nhận.');</script>");
            return;
        }
        CosonuoitrongEntity csnt = CosonuoitrongBRL.GetOne(Convert.ToInt32(Session["iCosonuoitrongID"]));
        lblDienTichChungNhan.Text = csnt.fTongdientichmatnuoc.ToString();
        lblDienThoai.Text = csnt.sDienthoai;
        lblDoiTuongNuoi.Text = DoituongnuoiBRL.GetOne(csnt.FK_iDoituongnuoiID).sTendoituong;
        lblHinhThucNuoi.Text = HinhthucnuoiBRL.GetOne(csnt.FK_iHinhthucnuoiID).sTenhinhthuc;
        lblFax.Text = csnt.sDienthoai;
        string diachi = "";
        diachi += csnt.sAp + ", " + csnt.sXa + ", " + QuanHuyenBRL.GetOne(csnt.FK_iQuanHuyenID).sTen + ", " + TinhBRL.GetOne(QuanHuyenBRL.GetOne(csnt.FK_iQuanHuyenID).FK_iTinhThanhID).sTentinh;
        lblDiaChi.Text = diachi;
        //        lblHinhThucNuoi.Text = 
        lblNguoiDaiDien.Text = csnt.sTenchucoso;
        lblSanLuongDuKien.Text = csnt.iSanluongdukien.ToString();
        lblTenCoSo.Text = csnt.sTencoso;
        lblTongDienTich.Text = csnt.fTongdientich.ToString();
    }
    protected void btnDangKy_Click(object sender, EventArgs e)
    {
        try
        {
            List<HosodangkychungnhanEntity> lstHonuoitrongdangky = HosodangkychungnhanBRL.GetByFK_iCosonuoiID(Convert.ToInt32(Session["iCosonuoitrongID"]));
            if (lstHonuoitrongdangky != null && lstHonuoitrongdangky.Count > 0)
                if (cbChungNhanLanDau.Checked == true)
                {
                    lblLoi.Text = "Bạn không thể chọn đăng ký lần đầu! Vì bạn đã đăng ký 1 lần.";
                    return;
                }
            List<PhatEntity> lstPhat = PhatBRL.GetByFK_iCosonuoiID(Convert.ToInt32(Session["iCosonuoitrongID"]));
            if (lstPhat != null && lstPhat.Count > 0)
            {
                lstPhat = PhatEntity.Sort(lstPhat, "dNgaythuchien", "DESC");
                TimeSpan oDateTime = DateTime.Now - lstPhat[0].dNgaythuchien;
                int years = oDateTime.Days / 365;
                if (lstPhat[0].iMucdo != 0 && years <= 1)
                {
                    lblLoi.Text = "Bạn không thể đăng ký vì đã vi phạm quy định của tổ chức VietGAP. Vui lòng liên hệ để biết thêm chi tiết";
                    return;
                }
            }
            HosodangkychungnhanEntity entity = new HosodangkychungnhanEntity();
            entity.dNgaydangky = DateTime.Now;
            entity.FK_iCosonuoiID = Convert.ToInt32(Session["iCosonuoitrongID"]);
            entity.bLandau = cbChungNhanLanDau.Checked;
            entity.FK_iTochucchungnhanID = Convert.ToInt32(ddlTochucchungnhan.SelectedValue);
            entity.iTrangthai = 0;
            int IDHoSo = HosodangkychungnhanBRL.Add(entity);
            GiaytonopkemhosoEntity oGiayTo = new GiaytonopkemhosoEntity();
            oGiayTo.PK_iHosodangkychungnhanID = IDHoSo;
            
            for (int i = 0; i < cblHoSoCSNTKemtheo.Items.Count; i++)
            {
                oGiayTo.FK_iGiaytoID = Convert.ToInt32(cblHoSoCSNTKemtheo.Items[i].Value);
                oGiayTo.bTrangthai = cblHoSoCSNTKemtheo.Items[i].Selected;
                GiaytonopkemhosoBRL.Add(oGiayTo);
            }
        }
        catch(Exception ex)
        {
            lblLoi.Text = ex.Message ;
        }
    }
}