using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Business;
using INVI.Entity;
using INVI.INVILibrary;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Globalization;

public partial class adminx_ucImportCSNT : System.Web.UI.UserControl
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!PermissionBRL.CheckPermission("BosungCSNT")) Response.End();
        pnLoi.Visible = false;
        lblLoi.Text = "";
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        
        if (fu.HasFile)
        {
            string strDocFile = uploadFile(fu, "xls|xlsx");
            ViewState["FileName"] = strDocFile;
            DataTable dtCSNT = GetDataFromExcelFile(Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "\\" + strDocFile));
            if (dtCSNT.Columns.Count != 20)
            {
                lblLoi.Text = "Dữ liệu đưa vào có số trường khác với quy định";
                lbtImport.Visible = false;
            }
            else
            {
                grvCosonuoitrong.DataSource = dtCSNT;
                grvCosonuoitrong.DataBind();
                lbtImport.Visible = false;
            }
            if (dtCSNT.Rows.Count == 0)
            {
                lbtImport.Visible = false;
            }
            else
            {
                lbtImport.Visible = true;
            }
        }
        else
        {
            lblLoi.Text = "Bạn chưa chọn tệp tin";
        }

    }
    private DataTable GetDataFromExcelFile(String File_name)
    {

        string strConn = null;
        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source= " + File_name + "; Extended Properties=Excel 8.0;";
        OleDbConnection ObjConn = new OleDbConnection(strConn);
        try
        {
            ObjConn.Open();            
            OleDbCommand ObjCmd = new OleDbCommand("SELECT * FROM [Sheet1$]", ObjConn);
            OleDbDataAdapter objDA = new OleDbDataAdapter();
            objDA.SelectCommand = ObjCmd;            
            DataSet ObjDataSet = new DataSet();
            objDA.Fill(ObjDataSet);            
            ObjConn.Close();
            return ObjDataSet.Tables[0];
        }
        catch (Exception excepcion)
        {
            if (ObjConn.State == ConnectionState.Open)
                ObjConn.Close();            
            return null;
        }
    }
    private string uploadFile(FileUpload fu, string strEx)
    {
        if (fu.HasFile)
        {
            string fileEx = fu.FileName.Substring(fu.FileName.LastIndexOf('.')).Remove(0, 1);
            string[] arrEx = strEx.Split('|');
            bool valid = false;
            foreach (string ex in arrEx)
            {
                if (ex.Equals(fileEx, StringComparison.OrdinalIgnoreCase))
                    valid = true;
            }
            if (valid)
            {
                fu.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "\\"+ Server.HtmlEncode(fu.FileName)));   
                return fu.FileName;
            }
            else
                return null;
        }
        else
            return null;
    }
    protected void grvCosonuoitrong_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblQuanHuyen = null, lblDoituongnuoi = null,lblUserName =null,lblTinh=null,lblHinhthucnuoi =null;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblThuTu = (Label)e.Row.FindControl("lblThuTu");
            lblThuTu.Text = (e.Row.RowIndex +1 ).ToString();
            lblQuanHuyen = (Label)e.Row.FindControl("lblIDQuanHuyen");
            lblDoituongnuoi = (Label)e.Row.FindControl("lblDoituongnuoiID");
            lblUserName = (Label)e.Row.FindControl("FK_iUserID");
            lblTinh = (Label)e.Row.FindControl("lblTinhthanh");
            lblHinhthucnuoi = (Label)e.Row.FindControl("lblHinhthucnuoiID");
            if (lblQuanHuyen != null && lblTinh != null && lblQuanHuyen.Text != "")
            {
                int idQuanHuyen = int.Parse(lblQuanHuyen.Text);
                lblQuanHuyen.Text = sTenhuyen(idQuanHuyen);
                lblTinh.Text = sTentinhthanh(idQuanHuyen);
            }
            if (lblDoituongnuoi != null && lblDoituongnuoi.Text != "")
            {
                byte bDoituongnuoiID = byte.Parse(lblDoituongnuoi.Text);
                lblDoituongnuoi.Text = getTendoituongnuoi(bDoituongnuoiID);
            }
            if (lblHinhthucnuoi != null && lblHinhthucnuoi.Text != "")
            {
                int iHinhThuocNuoiID = Convert.ToInt32(lblHinhthucnuoi.Text);
                lblHinhthucnuoi.Text = getHinhthucnuoi(iHinhThuocNuoiID);
            }
            if (lblUserName != null && lblUserName.Text != "")
            {
                int iUserID = Convert.ToInt32(lblUserName.Text);
                lblUserName.Text = getUserName(iUserID);
            }
        }
    }
    private String sTentinhthanh(int FK_iQuanHuyenID)
    {
        String sTentinhthanh = "Không xác định";
        QuanHuyenEntity oQuanHuyen = QuanHuyenBRL.GetOne(FK_iQuanHuyenID);
        TinhEntity oTinhthanh = TinhBRL.GetOne(oQuanHuyen.FK_iTinhThanhID);
        if (oTinhthanh != null)
            sTentinhthanh = oTinhthanh.sTentinh;
        else
            sTentinhthanh = "Không xác định";
        return sTentinhthanh;
    }
    private String sTenhuyen(int FK_iQuanHuyenID)
    {
        String sTenHuyen = String.Empty;
        QuanHuyenEntity oQuanHuyen = QuanHuyenBRL.GetOne(FK_iQuanHuyenID);       
        if (oQuanHuyen != null)
            sTenHuyen = oQuanHuyen.sTen;
        else
            sTenHuyen = "Không xác định";
        return sTenHuyen;
    }
    private String getTendoituongnuoi(byte iDoituongnuoiID)
    {
        String sDoituongnuoi = String.Empty;
        DoituongnuoiEntity oDoituongnuoi = DoituongnuoiBRL.GetOne(iDoituongnuoiID);
        if (oDoituongnuoi != null)
            sDoituongnuoi = oDoituongnuoi.sTendoituong;
        else
            sDoituongnuoi = "Không xác định";
        return sDoituongnuoi;
    }
    private String getHinhthucnuoi(int iHinhthucnuoiID)
    {
        String sHinhthucnuoi = String.Empty;
        HinhthucnuoiEntity oHinhthucnuoi = HinhthucnuoiBRL.GetOne(iHinhthucnuoiID);
        if (oHinhthucnuoi != null)
            sHinhthucnuoi = oHinhthucnuoi.sTenhinhthuc;
        else
            sHinhthucnuoi = "Không xác định";
        return sHinhthucnuoi;
    }
    private String getUserName(int iUserID)
    {
        String sUserName = String.Empty;
        UserEntity oUser = UserBRL.GetOne(iUserID);
        if (oUser != null)
            sUserName = oUser.sUsername;
        else
            sUserName = "Không xác định";
        return sUserName;
    }
    
    
    protected void lbtImport_Click(object sender, EventArgs e)
    {
        int iOK = 0, iNOK = 0;
        DataTable tblLoi = new DataTable();        
        tblLoi.Columns.Add("sTenCoSo", typeof(string));
        tblLoi.Columns.Add("sLoi", typeof(string));


        
        CosonuoitrongEntity oCSNT = new CosonuoitrongEntity();
        int FK_iQuanHuyenID;
        DataTable dtCSNT = GetDataFromExcelFile(Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "\\" + ViewState["FileName"].ToString()));
        if (dtCSNT.Rows.Count > 0)
        {
            for (int i = 0; i < dtCSNT.Rows.Count; i++)
            {
                string loi = "";
                if ((dtCSNT.Rows[i]["FK_iUserID"] != null) && (dtCSNT.Rows[i]["FK_iQuanHuyenID"] != null) && (dtCSNT.Rows[i]["FK_iDoituongnuoiID"] != null) && (dtCSNT.Rows[i]["FK_iHinhthucnuoiID"] != null))
                {
                    try
                    {
                        try
                        {
                            FK_iQuanHuyenID = Convert.ToInt32(dtCSNT.Rows[i]["FK_iQuanHuyenID"]);
                            oCSNT.FK_iQuanHuyenID = FK_iQuanHuyenID;
                        }
                        catch
                        {
                            loi += "- FK_iQuanHuyenID phải là số <br/> ";
                        }
                        try
                        {
                            oCSNT.bDuyet = Convert.ToBoolean(dtCSNT.Rows[i]["bDuyet"]);
                        }
                        catch
                        {
                            loi += "- bDuyet sai định dạng true/false<br/> ";
                        }
                        try
                        {
                            string ngay = dtCSNT.Rows[i]["dNgaydangky"].ToString().Substring(0, 10);
                            oCSNT.dNgaydangky = DateTime.ParseExact(ngay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            loi += "- dNgaydangky sai định dạng dd/MM/yyyy<br/>";
                        }
                        try
                        {
                            oCSNT.fDientichAolang = float.Parse(dtCSNT.Rows[i]["fDientichAolang"].ToString());
                        }
                        catch
                        {
                            loi += "- fDientichAolang phải là số thực<br/>";
                        }
                        try
                        {
                            oCSNT.FK_iDoituongnuoiID = Convert.ToInt32(dtCSNT.Rows[i]["FK_iDoituongnuoiID"]);
                        }
                        catch
                        {
                            loi += "- FK_iDoituongnuoiID phải là số<br/>";
                        }
                        try
                        {
                            oCSNT.FK_iHinhthucnuoiID = Convert.ToInt32(dtCSNT.Rows[i]["FK_iHinhthucnuoiID"]);
                        }
                        catch
                        {
                            loi += "- FK_iHinhthucnuoiID phải là số<br/>";
                        }

                        try
                        {
                            oCSNT.FK_iUserID = Convert.ToInt32(dtCSNT.Rows[i]["FK_iUserID"]);
                        }
                        catch
                        {
                            loi += "- FK_iUserID phải là số <br/>";
                        }
                        try
                        {
                            oCSNT.fTongdientich = float.Parse(dtCSNT.Rows[i]["fTongdientich"].ToString());
                        }
                        catch
                        {
                            loi += "- fTongdientich phải là số thực<br/>";
                        }
                        try
                        {
                            oCSNT.fTongdientichmatnuoc = float.Parse(dtCSNT.Rows[i]["fTongdientichmatnuoc"].ToString());
                        }
                        catch
                        {
                            loi += "- fTongdientichmatnuoc phải là số thực<br/>";
                        }
                        try
                        {
                            oCSNT.iChukynuoi = Convert.ToInt32(dtCSNT.Rows[i]["iChukynuoi"]);
                        }
                        catch
                        {
                            loi += "- iChukynuoi phải là số<br/>";
                        }
                        try
                        {
                            oCSNT.iNamsanxuat = Convert.ToInt32(dtCSNT.Rows[i]["iNamsanxuat"]);
                        }
                        catch
                        {
                            loi += "- iNamsanxuat phải là số<br/>";
                        }
                        try
                        {
                            oCSNT.iSanluongdukien = Convert.ToInt32(dtCSNT.Rows[i]["iSanluongdukien"]);
                        }
                        catch
                        {
                            loi += "- iSanluongdukien phải là số<br/>";
                        }
                        oCSNT.sAp = dtCSNT.Rows[i]["sAp"].ToString();
                        oCSNT.sDienthoai = dtCSNT.Rows[i]["sDienthoai"].ToString();
                        oCSNT.sMaso_vietgap = dtCSNT.Rows[i]["sMaso_vietgap"].ToString();
                        oCSNT.sMasocoso = dtCSNT.Rows[i]["sMasocoso"].ToString();
                        oCSNT.sSodoaonuoi = dtCSNT.Rows[i]["sSodoaonuoi"].ToString();
                        oCSNT.sTencoso = dtCSNT.Rows[i]["sTencoso"].ToString();
                        oCSNT.sTenchucoso = dtCSNT.Rows[i]["sTenchucoso"].ToString();
                        oCSNT.sXa = dtCSNT.Rows[i]["sXa"].ToString();

                        if (QuanHuyenBRL.GetOne(oCSNT.FK_iQuanHuyenID) == null)
                        {
                            loi += "- (FK_iQuanHuyen) Quận huyện không tồn tại<br/> ";
                        }
                        if (DoituongnuoiBRL.GetOne(oCSNT.FK_iDoituongnuoiID) == null)
                        {
                            loi += "- (FK_iDoituongnuoiID) Đối tượng nuôi không tồn tại";
                        }
                        if (HinhthucnuoiBRL.GetOne(oCSNT.FK_iHinhthucnuoiID) == null)
                        {
                            loi += "- (FK_iHinhthucnuoiID) Hình thức nuôi không tồn tại<br/> ";
                        }                       
                        if (UserBRL.GetOne(Convert.ToInt32(oCSNT.FK_iUserID)) == null)
                        {
                            loi += "- (FK_iUserID) Người dùng hệ thống không tồn tại<br/> ";
                        }
                        string diachi = "";
                        if (oCSNT.sAp.Trim().Length > 0)
                        {
                            diachi += oCSNT.sAp + ", ";
                        }
                        if (oCSNT.sXa.Trim().Length > 0)
                        {
                            diachi += oCSNT.sXa + ", ";
                        }
                        QuanHuyenEntity oQuanHuyen = QuanHuyenBRL.GetOne(oCSNT.FK_iQuanHuyenID);
                        if (oQuanHuyen != null)
                        {
                            diachi += oQuanHuyen.sTen + ", ";
                            TinhEntity oTinh = TinhBRL.GetOne(oQuanHuyen.FK_iTinhThanhID);
                            diachi += oTinh.sTentinh;
                        }
                        GooglePoint GP = new GooglePoint();
                        GP.Address = diachi;
                        if (GP.GeocodeAddress(ConfigurationManager.AppSettings["GoogleAPIKey"].ToString()))
                        {
                            GP.InfoHTML = GP.Address;
                            ToadoEntity oToaDo = new ToadoEntity();
                            oToaDo.Latitude = GP.Latitude;
                            oToaDo.Longitude = GP.Longitude;
                            oCSNT.FK_iToadoID = ToadoBRL.Add(oToaDo);
                        }
                        if (oCSNT.FK_iToadoID == null)
                        {
                            loi += "- Không thể xác định tọa độ của địa chỉ trên<br/>";
                        }
                        //fu.SaveAs(Server.MapPath(Server.HtmlEncode(dtCSNT.Rows[i]["sSodoaonuoi"].ToString())));    
                        if (loi.Trim().Length == 0)
                        {
                            CosonuoitrongBRL.Add(oCSNT);
                            iOK++;
                        }
                        else
                        {
                           
                            iNOK++;
                        }
                    }
                    catch (Exception ex)
                    {
                        loi += "Lỗi khi thêm mới: " + ex.Message + "br/>";    
                        iNOK++;
                    }
                    finally {
                        if (loi.Trim().Length > 0)
                        {
                            tblLoi.Rows.Add(oCSNT.sTencoso, loi);
                           
                        }
                    }
                }
            }
            if (tblLoi.Rows.Count > 0)
            {
                pnLoi.Visible = true;
                rptLoi.DataSource = tblLoi;
                rptLoi.DataBind();
            }
            else
            {
                pnLoi.Visible = false;
            }


            lblThongbao.Text = "Có " + iOK.ToString() + " import thành công và " + iNOK.ToString() + " thất bại";
        }
    }
}