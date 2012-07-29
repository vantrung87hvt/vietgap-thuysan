using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.DataAccess;
using INVI.Business;

public partial class adminx_Tochucchungnhan_ucThongtinDangky : System.Web.UI.UserControl
{
    Int32 PK_iHosodangky;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if(!IsPostBack)
        //{
        if (!PermissionBRL.CheckPermission("DuyethosodangkycuaCNST")) Response.End();
            napRptGiaytonopkem();
            HienKetQua();
        //}
    }

    public void napRptGiaytonopkem()
    {
        if (Session["iHosodangkyCSNT"] != null)
            PK_iHosodangky = Convert.ToInt32(Session["iHosodangkyCSNT"].ToString());
        else
        {
            Response.Redirect(ResolveUrl("~/adminx/Tochucchungnhan/Default.aspx?page=DanhsachHosodangky"));
        }
        List<GiaytonopkemhosoEntity> lstGiaytonopkem = GiaytonopkemhosoBRL.GetByPK_iHosodangkychungnhanID(PK_iHosodangky);
        List<GiaytoEntity> lstGiayto = new List<GiaytoEntity>();
        foreach(GiaytonopkemhosoEntity oGiaytonopkem in lstGiaytonopkem)
        {
            lstGiayto.Add(GiaytoBRL.GetOne(oGiaytonopkem.FK_iGiaytoID));
        }
        lstGiaytonopkem = null;
        rptGiaytonopkem.DataSource = lstGiayto;
        rptGiaytonopkem.DataBind();
        lstGiaytonopkem = null;
    }


    public void HienKetQua()
    {
        if (Session["iHosodangkyCSNT"] != null)
            PK_iHosodangky = Convert.ToInt32(Session["iHosodangkyCSNT"].ToString());
        else
        {
            Response.Redirect(ResolveUrl("~/adminx/Tochucchungnhan/Default.aspx?page=DanhsachHosodangky"));
        }
        HosodangkychungnhanEntity oHosodangky = HosodangkychungnhanBRL.GetOne(PK_iHosodangky);
        Int64 PK_iCosonuoitrongID = oHosodangky.FK_iCosonuoiID;
        int iSochitieudatA = 0, iSochitieudatB = 0;
        int iSochitieuA = 0, iSochitieuB = 0;
        MucdoEntity oMucdo;
        ChitieuEntity oChitieu;
        List<ChitieuEntity> lstChitieu = ChitieuBRL.GetAll();
        int iSochitieu = lstChitieu.Count;
        foreach (ChitieuEntity oChitieuItem in lstChitieu)
        {
            oMucdo = MucdoBRL.GetOne(oChitieuItem.FK_iMucdoID);
            if (oMucdo.sTenmucdo == "A")
                iSochitieuA++;
            else
                iSochitieuB++;
        }
        lstChitieu = null;

        List<DanhgiaketquaEntity> lstDanhgiaketqua = DanhgiaketquaBRL.GetByFK_iCosonuoiID(PK_iCosonuoitrongID);
        for (int i = 0; i < lstDanhgiaketqua.Count; ++i)
        {
            oChitieu = ChitieuBRL.GetOne(lstDanhgiaketqua[i].FK_iChitieuID);
            oMucdo = MucdoBRL.GetOne(oChitieu.FK_iMucdoID);
            if (lstDanhgiaketqua[i].iKetqua == 1)
            {
                if (oMucdo.sTenmucdo == "A")
                    ++iSochitieudatA;
                else
                    ++iSochitieudatB;
            }

        }
        lstDanhgiaketqua = null;

        int iSochitieuDat = DanhgiaketquaBRL.CountTrue((int)PK_iCosonuoitrongID);
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
        if (iSochitieudatA == iSochitieuA && ((iSochitieudatA * 100) / iSochitieuA) >= 90)
            Session["bDanhgiaDat"] = true;
        else
            Session["bDanhgiaDat"] = false;
    }
}