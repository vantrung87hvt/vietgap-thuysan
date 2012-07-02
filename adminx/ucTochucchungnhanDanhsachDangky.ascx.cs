using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.DataAccess;
using INVI.Business;
public partial class adminx_ucTochucchungnhanDanhsachDangky : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //DropDownList ddlKetLuan = ucTochuccapphepDanhgia1.FindControl("ddlKetluan") as DropDownList;
        //if (ddlKetLuan != null)
        //{
        //    btnCapPhep.Visible = ddlKetLuan.SelectedValue == "1" ? true : false;
        //}
        if (!Page.IsPostBack)
        {
            List<DangkyHoatdongchungnhanEntity> lstDanhsachTochucchungnhan = DangkyHoatdongchungnhanBRL.GetAll();
            if (lstDanhsachTochucchungnhan != null && lstDanhsachTochucchungnhan.Count > 0)
                DanhsachTochucchungnhanDangky = lstDanhsachTochucchungnhan;
            napTochucchungnhanDangky();
        }
        // Nếu có tham số truyền vào - nạp thông tin về Tổ chức chứng nhận
        if (Request.QueryString["iTochucchungnhanID"] != null)
        {
            Session["PK_iTochucchungnhanID"] = Request.QueryString["iTochucchungnhanID"].ToString();
            int PK_iDangkyChungnhanVietGapID = 0;
            if(Request.QueryString["PK_iDangkyChungnhanVietGapID"] != null)
            {
                PK_iDangkyChungnhanVietGapID = Convert.ToInt32(Request.QueryString["PK_iDangkyChungnhanVietGapID"].ToString());
                //-----------Check duyệts
                DangkyHoatdongchungnhanEntity oDangky = DangkyHoatdongchungnhanBRL.GetOne(PK_iDangkyChungnhanVietGapID);
                if (oDangky != null && oDangky.iTrangthaidangky == 2)
                {
                    btnCapPhep.Visible = false;
                }
                else
                {
                    btnCapPhep.Visible = true;
                }
            }
            pnThongTin.Visible = true;
            NapForm(PK_iDangkyChungnhanVietGapID);
        }
    }
    public List<DangkyHoatdongchungnhanEntity> DanhsachTochucchungnhanDangky
    {
        get
        {
            if (Cache["DanhsachTochucchungnhanDangky"] == null)
                return new List<DangkyHoatdongchungnhanEntity>();
            else
                return (List<DangkyHoatdongchungnhanEntity>)Cache["DanhsachTochucchungnhanDangky"];
        }
        set { Cache["DanhsachTochucchungnhanDangky"] = value; }
    }
    private void napTochucchungnhanDangky()
    {
        List<DangkyHoatdongchungnhanEntity> lstDanhsachTochucchungnhan = new List<DangkyHoatdongchungnhanEntity>();
        // Nếu có dữ liệu trong Cache thì đọc ra
        if (DanhsachTochucchungnhanDangky != null && DanhsachTochucchungnhanDangky.Count > 0)
            lstDanhsachTochucchungnhan = DanhsachTochucchungnhanDangky;
        else
            lstDanhsachTochucchungnhan = DangkyHoatdongchungnhanBRL.GetAll();
        // Lọc dữ liệu theo lần đăng ký
        if (ddlLandangky.SelectedIndex == 0) // lấy danh sách các tổ chức chứng nhận đăng ký lần đầu nhưng chưa được kiểm duyệt
            lstDanhsachTochucchungnhan = lstDanhsachTochucchungnhan.FindAll(delegate(DangkyHoatdongchungnhanEntity oDangkyhoatdongchungnhan)
            {
                return oDangkyhoatdongchungnhan.iLandangky == 1 && oDangkyhoatdongchungnhan.iTrangthaidangky < 2; // chỉ lấy ra các Tổ chức chứng nhận chưa được duyệt
            });
        else
            lstDanhsachTochucchungnhan = lstDanhsachTochucchungnhan.FindAll(delegate(DangkyHoatdongchungnhanEntity oDangkyhoatdongchungnhan)
            {
                return oDangkyhoatdongchungnhan.iLandangky > 1 && oDangkyhoatdongchungnhan.iTrangthaidangky <2; // nhưng phải xử lý thêm, vì 1 TCCN có thể đăng ký nhiều lần
            });
        grvTochuccapphep.DataSource = lstDanhsachTochucchungnhan;
        grvTochuccapphep.DataKeyNames = new String[] { "PK_iDangkyChungnhanVietGapID" };
        grvTochuccapphep.DataBind();
    }
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {

    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {

    }
    protected void grvTochuccapphep_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grvTochuccapphep_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void grvTochuccapphep_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblTentochuc = (Label)e.Row.FindControl("lblTentochuc");
            Label lblQuanHuyen = (Label)e.Row.FindControl("lblQuanHuyen");
            Label lblTrangthai = (Label)e.Row.FindControl("lblTrangthai");
            if (lblTentochuc != null)
            {
                int iFK_tochucID = Convert.ToInt32(lblTentochuc.Text);
                TochucchungnhanEntity oTochucchungnhan = TochucchungnhanBRL.GetOne(iFK_tochucID);
                lblTentochuc.Text = oTochucchungnhan.sTochucchungnhan;
                lblQuanHuyen.Text = QuanHuyenBRL.GetOne(oTochucchungnhan.FK_iQuanHuyenID).sTen;
                int PK_iDangkyChungnhanVietGapID = Convert.ToInt32(lblTrangthai.Text);
                lblTrangthai.Text = getTrangthai((byte)DangkyHoatdongchungnhanBRL.GetOne(PK_iDangkyChungnhanVietGapID).iTrangthaidangky);
            }
        }
        
    }
    protected void grvTochuccapphep_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int DangKyID = Convert.ToInt32(grvTochuccapphep.DataKeys[e.NewSelectedIndex].Values["PK_iDangkyChungnhanVietGapID"]);
        pnThongTin.Visible = true;
        NapForm(DangKyID);
    }
    private void NapForm(int DangKyID)
    {
        //
        DangkyHoatdongchungnhanEntity oDangkyhd = DangkyHoatdongchungnhanBRL.GetOne(DangKyID);
        int idTochucchungnhan = oDangkyhd.FK_iTochucchungnhanID;
        Session["PK_iTochucchungnhanID"] = idTochucchungnhan;
        TochucchungnhanEntity oTCCN = TochucchungnhanBRL.GetOne(idTochucchungnhan);
        lblCoQuanCaptc.Text = oTCCN.sCoquancap;
        lblDiaChitc.Text = oTCCN.sDiachi;
        lblDienthoaitc.Text = oTCCN.sSodienthoai;
        lblEmailtc.Text = oTCCN.sEmail;
        lblFaxtc.Text = oTCCN.sFax;
        lblMaSotc.Text = oTCCN.sMaso;
        lblNoiCapdkkdtc.Text = oTCCN.sNoicapdangkykinhdoanh;
        lblNgayCapdkdtc.Text = oTCCN.dNgaycapdangkykinhdoanh.ToString("dd/MM/yyyy");
        lblSodangkykdtc.Text = oTCCN.sSodangkykinhdoanh;
        imgLogo.ImageUrl = "ViewImage.aspx?ID=" + oTCCN.PK_iTochucchungnhanID.ToString();
        lblTenTochuc.Text = oTCCN.sTochucchungnhan;
        //
        List<HosokemtheoTochucchungnhanEntity> lst = HosokemtheoTochucchungnhanBRL.GetByFK_iDangkyChungnhanVietGapID(DangKyID);
        rptHoSoKemTheo.DataSource = lst;
        rptHoSoKemTheo.DataBind();
        int iSodanhgiavien =0;
        if(Session["iSodanhgiavien"]!=null)
            iSodanhgiavien = Convert.ToInt32(Session["iSodanhgiavien"].ToString());
        //btnCapPhep.Enabled = iSodanhgiavien > 0 ? true : false;

        btnCapPhep.CommandArgument = DangKyID.ToString();
    
    }
    protected void grvTochuccapphep_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {

    }
    private String getTrangthai(byte iTrangthai)
    {
        switch (iTrangthai)
        {
            case 0:
                return "Chưa duyệt hồ sơ";
            case 1:
                return "Đã duyệt hồ sơ";
            case 2:
                return "Hồ sơ hoàn chỉnh";
            default:
                return "";
        }
    }
    protected void rptHoSoKemTheo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblID = (Label)e.Item.FindControl("FK_iGiaytoID");
            Label lblTenGiayTo = (Label)e.Item.FindControl("lblTenGiayTo");
            GiaytoEntity oGiayTo = GiaytoBRL.GetOne(Convert.ToInt32(lblID.Text));
            lblTenGiayTo.Text = oGiayTo.sTengiayto;

        }
    }
    //public static string GetGuidHash()
    //{
    //    return Guid.NewGuid().ToString().GetHashCode().ToString("x");
    //}
    private String randomString(int iLeng)
    {
        string allowedChars = "";
        allowedChars += "1,2,3,4,5,6,7,8,9,0";

        char[] sep = { ',' };
        string[] arr = allowedChars.Split(sep);

        string passwordString = "";

        string temp = "";

        Random rand = new Random();
        for (int i = 0; i < iLeng; i++)
        {
            temp = arr[rand.Next(0, arr.Length)];
            passwordString += temp;
        }
        return passwordString;
    }
    protected void btnCapPhep_Click(object sender, EventArgs e)
    {
        try
        {
            
            int DangKyID = Convert.ToInt32(btnCapPhep.CommandArgument);
            DangkyHoatdongchungnhanEntity oDangkyhd = DangkyHoatdongchungnhanBRL.GetOne(DangKyID);
            int idTochucchungnhan = oDangkyhd.FK_iTochucchungnhanID;
            if (TochucchungnhanBRL.GetOne(idTochucchungnhan).sMaso.Trim().Length > 0 && TochucchungnhanBRL.GetOne(idTochucchungnhan).sKytuviettat.Trim()!="Chưa cấp")
            {
                lblThongbao.Text = "Tổ chức này đã được cấp phép.";
                return;
            }
            string maso = String.Empty;
            maso = "VietGAP-TS-";
            maso += DateTime.Now.Year.ToString().Substring(2, 2)+"-";
            
            // Theo cái mới thì không phải ngẫu nhiên mã số
            // mà con số sau là 2 con số của năm
            // và số lượng mã số được cấp
            //List<TochucchungnhanEntity> lstTochucchungnhan = new List<TochucchungnhanEntity>();
            //do
            //{
            //    maso = randomString(3);
            //    lstTochucchungnhan = TochucchungnhanBRL.GetAll().FindAll(delegate(TochucchungnhanEntity oTochucchungnhan)
            //    {
            //        return oTochucchungnhan.sKytuviettat == maso;
            //    }
            //    );
            //} while (lstTochucchungnhan.Count > 0);
            
            // Đếm số lượng tổ chức chứng nhận đã được chỉ định

            List<TochucchungnhanEntity> lstTochucchungnhan = new List<TochucchungnhanEntity>();
            TochucchungnhanEntity oTCCN = TochucchungnhanBRL.GetOne(idTochucchungnhan);
            TinhEntity oTinh = TinhBRL.GetOne(QuanHuyenBRL.GetOne(oTCCN.FK_iQuanHuyenID).FK_iTinhThanhID);
            // Lấy danh sách các ID tổ chức chứng nhận rồi lọc
            List<DangkyHoatdongchungnhanEntity> lstDanhsachTCCNDangky = DangkyHoatdongchungnhanBRL.GetAll();
            foreach (DangkyHoatdongchungnhanEntity oDanhsachTCCN in lstDanhsachTCCNDangky)
                if (!lstTochucchungnhan.Contains(TochucchungnhanBRL.GetOne(oDanhsachTCCN.FK_iTochucchungnhanID)) && oDanhsachTCCN.iTrangthaidangky==2)
                    //if((QuanHuyenBRL.GetOne(TochucchungnhanBRL.GetOne(oDanhsachTCCN.FK_iTochucchungnhanID).FK_iQuanHuyenID).FK_iTinhThanhID)==oTinh.PK_iTinhID)
                        lstTochucchungnhan.Add(TochucchungnhanBRL.GetOne(oDanhsachTCCN.FK_iTochucchungnhanID));
            // Sắp xếp lại Danh sách các tổ chức chứng nhận để lấy mã số của TCCN có giá trị lớn nhất + 1.
            lstTochucchungnhan.Sort(delegate(TochucchungnhanEntity firstEntity, TochucchungnhanEntity secondEntity)
            {
                return secondEntity.sMaso.CompareTo(firstEntity.sMaso);
            }
            );
            // Lấy thằng mới nhất
            String sMasomoinhat = lstTochucchungnhan[0].sMaso;
            String[] sDulieutrongmaso = sMasomoinhat.Split('-');
            int iStt = Convert.ToInt16(sDulieutrongmaso[sDulieutrongmaso.Length - 1])+1;
            if (iStt < 10)
                maso += "0" + iStt;
            else
                maso += iStt + "";
            //maso += lstTochucchungnhan.Count + 1;
            oTCCN.sKytuviettat = DateTime.Now.Year.ToString().Substring(2, 2) + "-" + maso;
            oTCCN.sMaso = maso;
            oTCCN.iTrangthai = 2;
            
            TochucchungnhanBRL.Edit(oTCCN);
            oDangkyhd.iTrangthaidangky = 2;
            
            DangkyHoatdongchungnhanBRL.Edit(oDangkyhd);
            pnThongTin.Visible = false;
        }
        catch (Exception ex)
        {
            Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=TochucchungnhanDanhsachDangky';</script>");
        }
    }
    protected void ddlLandangky_SelectedIndexChanged(object sender, EventArgs e)
    {
        napTochucchungnhanDangky();
    }
}