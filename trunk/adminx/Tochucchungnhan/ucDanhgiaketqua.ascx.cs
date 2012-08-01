using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using INVI.Entity;
using INVI.Business;
using System.Data.SqlClient;

public partial class uc_ucTinh : System.Web.UI.UserControl
{
    //===============================
    // ID cơ sở nuôi trồng, sau này sẽ thay bằng ID cơ sở của user đăng nhập
    int PK_iCosonuoitrongID = 0;
    //===============================
    bool bDatontai = false;//Kiểm tra cơ sở nuôi trồng hiện tại đã có bảng đánh giá nội bộ chưa
    List<PhuongphapkiemtraEntity> lstPhuongphapkiemtra;
    List<ChitieuEntity> lstChitieu = ChitieuBRL.GetAll();
    List<DanhgiaketquaEntity> lstDanhgiaketqua = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!PermissionBRL.CheckPermission("Danhgianoibo")) Response.End();
        lblThongbao.Text = "";
      
            if (Session["iCosonuoitrongID"] != null)
                PK_iCosonuoitrongID = Convert.ToInt32(Session["iCosonuoitrongID"].ToString());
            else
            {
                Response.Redirect(ResolveUrl("~/adminx/Tochucchungnhan/Default.aspx?page=DanhsachHosodangky"));
            }

            lstDanhgiaketqua = DanhgiaketquaBRL.GetByFK_iCosonuoiID(PK_iCosonuoitrongID);
            if (lstDanhgiaketqua.Count > 0)
                bDatontai = true;
            else
                bDatontai = false;
            napRpt();
    }


    public void HienKetQua()
    {
        int iSochitieudatA = 0, iSochitieudatB = 0;
        int iSochitieuA = 0, iSochitieuB = 0;
        MucdoEntity oMucdo;
        ChitieuEntity oChitieu;
        List<ChitieuEntity> lstChitieu = ChitieuBRL.GetAll();
        int iSochitieu = lstChitieu.Count;
        foreach(ChitieuEntity oChitieuItem in lstChitieu)
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
        if(iSochitieudatA==iSochitieuA&&((iSochitieudatA * 100) / iSochitieuA)>=90)
            Session["bDanhgiaDat"] = true;
    }


    private void napRpt()
    {
        string connStr = ConfigurationManager.ConnectionStrings["db_NewsConnectionString"].ConnectionString;
        SqlConnection mySQLconnection = new SqlConnection(connStr);
        DataSet ds;
        SqlDataAdapter mySqlAdapter;
        if (mySQLconnection.State == ConnectionState.Closed)
        {
            mySQLconnection.Open();
        }
        SqlCommand cmd1 = new SqlCommand("spDanhmucchitieu_Get", mySQLconnection);
        cmd1.CommandType = CommandType.StoredProcedure;
        mySqlAdapter = new SqlDataAdapter(cmd1);
        ds = new DataSet();
        mySqlAdapter.Fill(ds, "Danhmucchitieu");

        SqlCommand cmd2 = new SqlCommand("spChitieu_Get", mySQLconnection);
        cmd2.CommandType = CommandType.StoredProcedure;
        mySqlAdapter = new SqlDataAdapter(cmd2);
        mySqlAdapter.Fill(ds, "Chitieu");
        //Nối hai table trong Dataset ds
        ds.Relations.Add("Danhmucchitieu_Chitieu",
        ds.Tables["Danhmucchitieu"].Columns["PK_iDanhmucchitieuID"],
        ds.Tables["Chitieu"].Columns["FK_iDanhmucchitieuID"]);

        rptDanhmucchitieu.DataSource = ds.Tables["Danhmucchitieu"];
        rptDanhmucchitieu.DataBind();
        mySQLconnection.Close();
        //---Hiện kết quả
        if (bDatontai)
        {
            HienKetQua();
            SetDdlIndex();
        }
    }


    protected void rptDanhmucchitieu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        Session["DanhgiaketquaEdit"] = 1;
        
    }
    protected void lbtnAdd_Click(object sender, EventArgs e)
    {
        btnOK.CommandName = "Add";
        pnAdd.Visible = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnOK.CommandName = "Add";
        pnAdd.Visible = false;
        Response.Redirect("Default.aspx?page=DanhsachHosodangky");
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napRpt();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                LuuKetqua();
                btnCancel.Text = "Quay lại";
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=Danhgiaketqua';</script>");
            }
        }

       
    }

    public String getsTenmucdo(int PK_iMucdoID)
    {
        MucdoEntity item = MucdoBRL.GetOne(PK_iMucdoID);
        return item.sTenmucdo;
    }

    protected void rptChitieu_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        lstPhuongphapkiemtra = PhuongphapkiemtraBRL.GetAll();
        DropDownList ddlPhuongphapkiemtra = (DropDownList)e.Item.FindControl("ddlPhuongphapkiemtra");
        DropDownList ddlKetqua = (DropDownList)e.Item.FindControl("ddlKetqua");
        LinkButton lbtnEdit = (LinkButton)e.Item.FindControl("lbtnEdit");
        ddlPhuongphapkiemtra.Items.Clear();
        ddlPhuongphapkiemtra.DataSource = lstPhuongphapkiemtra;
        ddlPhuongphapkiemtra.DataTextField = "sTenphuongphapkiemtra";
        ddlPhuongphapkiemtra.DataValueField = "PK_iPhuongphapkiemtraID";
        ddlPhuongphapkiemtra.DataBind();
        //if (bDatontai)
        //{
            //ddlPhuongphapkiemtra.Enabled = false;
            //if (Convert.ToByte(Session["DanhgiaketquaEdit"]) == 1)
            //    ddlKetqua.Enabled = true;
            //else
            //    ddlKetqua.Enabled = false;
            //lbtnEdit.Visible = true;
            //ddlPhuongphapkiemtra.Enabled = true;
            //ddlKetqua.Enabled = true;
        //}
        //else
        //{
        //    lbtnEdit.Visible = false;
        //}
    }

    public void SetDdlIndex()
    {
        lstDanhgiaketqua = DanhgiaketquaBRL.GetByFK_iCosonuoiID(PK_iCosonuoitrongID);
        int i = 0;
        DanhgiaketquaEntity oDanhgiaketqua = new DanhgiaketquaEntity();
        foreach (RepeaterItem ri in rptDanhmucchitieu.Items)
        {
            Repeater rptChitieu = (Repeater)ri.FindControl("rptChitieu");
            if (rptChitieu != null)
            {
                foreach (RepeaterItem riChitieu in rptChitieu.Items)
                {
                    DropDownList ddlPhuongphapkiemtra = (DropDownList)riChitieu.FindControl("ddlPhuongphapkiemtra");
                    DropDownList ddlKetqua = (DropDownList)riChitieu.FindControl("ddlKetqua");
                    oDanhgiaketqua = GetDanhgiaketquaByChitieu(lstChitieu[i].PK_iChitieuID);
                    ddlPhuongphapkiemtra.Items.FindByValue(oDanhgiaketqua.FK_iPhuongphapkiemtraID.ToString()).Selected = true;
                    ddlKetqua.Items.FindByValue(oDanhgiaketqua.iKetqua.ToString()).Selected = true;
                    ++i;
                }
            }
        }
    }

    public DanhgiaketquaEntity GetDanhgiaketquaByChitieu(int PK_iChitieuID)
    {
        DanhgiaketquaEntity oDanhgiaketqua = null;
        for (int i = 0; i < lstDanhgiaketqua.Count; ++i)
        {
            if (lstDanhgiaketqua[i].FK_iChitieuID == PK_iChitieuID)
            {
                oDanhgiaketqua = lstDanhgiaketqua[i];
                break;
            }
        }
        return oDanhgiaketqua;
    }

    public void LuuKetqua()
    {
        dellOldData(); //Xóa dữ liệu đã tồn tại
        int iPhuongphapkiemtra;
        short iKetqua;
        int i = 0;
        DanhgiaketquaEntity oDanhgiaketqua = new DanhgiaketquaEntity();
        foreach (RepeaterItem ri in rptDanhmucchitieu.Items)
        {
            Repeater rptChitieu = (Repeater)ri.FindControl("rptChitieu");
            if (rptChitieu != null)
            {
                foreach (RepeaterItem riChitieu in rptChitieu.Items)
                {
                    DropDownList ddlPhuongphapkiemtra = (DropDownList)riChitieu.FindControl("ddlPhuongphapkiemtra");
                    DropDownList ddlKetqua = (DropDownList)riChitieu.FindControl("ddlKetqua");
                    iPhuongphapkiemtra = int.Parse(ddlPhuongphapkiemtra.SelectedItem.Value);
                    iKetqua = short.Parse(ddlKetqua.SelectedItem.Value);
                    //---Lưu kết quả vào Database
                    oDanhgiaketqua.FK_iChitieuID = lstChitieu[i].PK_iChitieuID;
                    oDanhgiaketqua.FK_iCosonuoiID = PK_iCosonuoitrongID;
                    oDanhgiaketqua.FK_iPhuongphapkiemtraID = iPhuongphapkiemtra;
                    oDanhgiaketqua.iKetqua = iKetqua;
                    DanhgiaketquaBRL.Add(oDanhgiaketqua);
                    ++i;
                }
            }
        }
        lblThongbao.Text = "Lưu kết quả thành công!";
        SetDdlIndex();
        HienKetQua();
    }

    public void dellOldData()
    {
        if (Session["iCosonuoitrongID"] != null)
            PK_iCosonuoitrongID = Convert.ToInt32(Session["iCosonuoitrongID"].ToString());
        else
        {
            Response.Redirect(ResolveUrl("~/adminx/Tochucchungnhan/Default.aspx?page=DanhsachHosodangky"));
        }
        //if (Page.IsValid)
        //{
        try
        {
            List<DanhgiaketquaEntity> lstDanhgiaketqua = DanhgiaketquaBRL.GetByFK_iCosonuoiID(PK_iCosonuoitrongID);
            foreach (DanhgiaketquaEntity oDanhgiaketqua in lstDanhgiaketqua)
            {
                DanhgiaketquaBRL.Remove(oDanhgiaketqua.PK_iDanhgiaketquaID);
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=Danhgiaketqua';</script>");
        }
        //}
    }

    public void ltbnDellAll_Click(object sender, EventArgs e)
    {
        dellOldData();
        napRpt();
        lblThongbao.Text = "Hủy kết quả thành công!";
    }
    
}
