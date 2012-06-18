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

public partial class adminx_ucImportCSNT : System.Web.UI.UserControl
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        lblLoi.Text = "";
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        
        if (fu.HasFile)
        {
            string strDocFile = uploadFile(fu, "xls|xlsx");
            ViewState["FileName"] = strDocFile;
            DataTable dtCSNT = GetDataFromExcelFile(Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "\\" + strDocFile));
            grvCosonuoitrong.DataSource = dtCSNT;
            grvCosonuoitrong.DataBind();
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
        CosonuoitrongEntity oCSNT = new CosonuoitrongEntity();
        int FK_iQuanHuyenID;
        DataTable dtCSNT = GetDataFromExcelFile(Server.MapPath(ConfigurationManager.AppSettings["UploadPath"] + "\\" + ViewState["FileName"].ToString()));
        if (dtCSNT.Rows.Count > 0)
        {
            for (int i = 0; i < dtCSNT.Rows.Count; i++)
            {                
                if ((dtCSNT.Rows[i]["FK_iUserID"] != null) && (dtCSNT.Rows[i]["FK_iQuanHuyenID"] != null) && (dtCSNT.Rows[i]["FK_iDoituongnuoiID"] != null) && (dtCSNT.Rows[i]["FK_iHinhthucnuoiID"] != null))
                {
                    try
                    {
                        FK_iQuanHuyenID = Convert.ToInt32(dtCSNT.Rows[i]["FK_iQuanHuyenID"]);
                        oCSNT.bDuyet = Convert.ToBoolean(dtCSNT.Rows[i]["bDuyet"]);
                        oCSNT.dNgaydangky = Convert.ToDateTime(dtCSNT.Rows[i]["dNgaydangky"]);
                        oCSNT.fDientichAolang = float.Parse(dtCSNT.Rows[i]["fDientichAolang"].ToString());
                        oCSNT.FK_iDoituongnuoiID = Convert.ToInt32(dtCSNT.Rows[i]["FK_iDoituongnuoiID"]); 
                        oCSNT.FK_iHinhthucnuoiID = Convert.ToInt32(dtCSNT.Rows[i]["FK_iHinhthucnuoiID"]);  
                        oCSNT.FK_iQuanHuyenID = FK_iQuanHuyenID;                        
                        oCSNT.FK_iUserID = Convert.ToInt32(dtCSNT.Rows[i]["FK_iUserID"]);
                        oCSNT.fTongdientich = float.Parse(dtCSNT.Rows[i]["fTongdientich"].ToString());
                        oCSNT.fTongdientichmatnuoc = float.Parse(dtCSNT.Rows[i]["fTongdientichmatnuoc"].ToString());
                        oCSNT.iChukynuoi = Convert.ToInt32(dtCSNT.Rows[i]["iChukynuoi"]);
                        oCSNT.iNamsanxuat = Convert.ToInt32(dtCSNT.Rows[i]["iNamsanxuat"]);
                        oCSNT.iSanluongdukien = Convert.ToInt32(dtCSNT.Rows[i]["iSanluongdukien"]);
                        oCSNT.sAp = dtCSNT.Rows[i]["sAp"].ToString();
                        oCSNT.sDienthoai = dtCSNT.Rows[i]["sDienthoai"].ToString();
                        oCSNT.sMaso_vietgap = dtCSNT.Rows[i]["sMaso_vietgap"].ToString();
                        oCSNT.sMasocoso = dtCSNT.Rows[i]["sMasocoso"].ToString();
                        oCSNT.sSodoaonuoi = dtCSNT.Rows[i]["sSodoaonuoi"].ToString();
                        oCSNT.sTencoso = dtCSNT.Rows[i]["sTencoso"].ToString();
                        oCSNT.sTenchucoso = dtCSNT.Rows[i]["sTenchucoso"].ToString();
                        oCSNT.sXa = dtCSNT.Rows[i]["sXa"].ToString();
                       
                        
                        string diachi = "";
                        if (oCSNT.sAp.Trim().Length>0)
                        {
                            diachi += oCSNT.sAp + ", ";
                        }
                        if (oCSNT.sXa.Trim().Length > 0)
                        {
                            diachi += oCSNT.sXa + ", ";
                        }
                        QuanHuyenEntity oQuanHuyen = QuanHuyenBRL.GetOne(FK_iQuanHuyenID);
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
                        //fu.SaveAs(Server.MapPath(Server.HtmlEncode(dtCSNT.Rows[i]["sSodoaonuoi"].ToString())));                               
                        CosonuoitrongBRL.Add(oCSNT);
                        iOK++;
                    }
                    catch {
                        iNOK++;
                    }
                }
            }
            lblThongbao.Text = "Có " + iOK.ToString() + " import thành công và " + iNOK.ToString() + " thất bại";
        }
    }
}