using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.Business;
using INVI.INVILibrary;
using System.Configuration;
public partial class adminx_ucCosonuoitrongUpdate : System.Web.UI.UserControl
{
    private static int fk_user;    
    private static string addr = "";
    private static int iCosonuoitrongID;

    public int iTinhID
    {
        get
        {
            if (Cache["iTinhID"] == null)
                return -1;
            else
                return (int)Cache["iTinhID"];
        }
        set { Cache["iTinhID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!Page.IsPostBack)
        {
            
            napTinh();
            LoadQuanHuyen(Convert.ToInt32(ddlTinh.SelectedValue));
            napDoituongnuoi();
            napHinhThucNuoi();
            napNamsanxuat();
           // LoadMap(getAdd());
            if (Session["iCosonuoitrongID"] != null&&Request.QueryString["do"]==null)
            {
                iCosonuoitrongID = Convert.ToInt32(Session["iCosonuoitrongID"].ToString());
                // nếu có ID được truyền vào thì là cập nhập
                // không cập nhập thông tin về User ở đây
                // vì 1 cơ sơ nuôi trồng có thể có nhiều Username
                btnDKThongtinCoSoNuoi.CommandName = "Edit";
                btnDKThongtinCoSoNuoi.CommandArgument = iCosonuoitrongID.ToString();                
                pnCSNT.Visible = true;
                napForm(iCosonuoitrongID);
                
            }
            else
            {
                pnCSNT.Visible = true;
                chkKiemduyet.Visible = false;
            }
            FK_iCosonuoitrong.Value = iCosonuoitrongID.ToString();
        }
    }


    
    /// <summary>
    /// 
    /// </summary>
    protected void napTinh()
    {
        ddlTinh.Items.Clear();
        List<TinhEntity> lstTinh = TinhBRL.GetAll();
        ddlTinh.DataSource = lstTinh;
        ddlTinh.DataTextField = "sTentinh";
        ddlTinh.DataValueField = "PK_iTinhID";
        ddlTinh.DataBind();
    }
    protected void napDoituongnuoi()
    {
        ddlDoituongnuoi.Items.Clear();
        List<DoituongnuoiEntity> lstDoituongnuoi = DoituongnuoiBRL.GetAll();
        ddlDoituongnuoi.DataSource = lstDoituongnuoi;
        ddlDoituongnuoi.DataTextField = "sTendoituong";
        ddlDoituongnuoi.DataValueField = "PK_iDoituongnuoiID";
        ddlDoituongnuoi.DataBind();
        ddlDoituongnuoi.Items.Insert(0, new ListItem("--- Chọn ---", "0"));

    }
    protected void napHinhThucNuoi()
    {
        ddlHinhThucNuoi.Items.Clear();
        List<HinhthucnuoiEntity> lstHinhthucnuoi = HinhthucnuoiBRL.GetAll();
        ddlHinhThucNuoi.DataSource = lstHinhthucnuoi;
        ddlHinhThucNuoi.DataTextField = "sTenhinhthuc";
        ddlHinhThucNuoi.DataValueField = "PK_iHinhthucnuoiID";
        ddlHinhThucNuoi.DataBind();
        ddlHinhThucNuoi.Items.Insert(0, new ListItem("--- Chọn ---", "0"));

    }
    private void LoadQuanHuyen(int fk_Tinh)
    {
        ddlHuyen.Items.Clear();
        List<QuanHuyenEntity> lst = QuanHuyenBRL.GetByFK_iTinhThanhID(Convert.ToInt16(fk_Tinh));
        ddlHuyen.DataSource = lst;
        ddlHuyen.DataTextField = "sTen";
        ddlHuyen.DataValueField = "PK_iQuanHuyenID";
        ddlHuyen.DataBind();        
    }
    protected void napNamsanxuat()
    {
        ddlNamSanXuat.Items.Insert(0, new ListItem("--- Chọn ---", "0"));
        for (int i = 2011; i >= 1990; i--)
        {
            ddlNamSanXuat.Items.Add(i.ToString());
        }
    }
    protected void napForm(int iCosonuoitrongID)
    {
        CosonuoitrongEntity oCosonuoitrong;
        try
        {
            oCosonuoitrong = CosonuoitrongBRL.GetOne(iCosonuoitrongID);
            if (oCosonuoitrong != null)
            {
                txtAp.Text = oCosonuoitrong.sAp;
                txtDienTichAoLang.Text = oCosonuoitrong.fDientichAolang.ToString();
                txtChuKyNuoi.Text = oCosonuoitrong.iChukynuoi.ToString();
                txtDienThoai.Text = oCosonuoitrong.sDienthoai;
                txtTenChuCoSo.Text = oCosonuoitrong.sTenchucoso;
                txtTenCoSo.Text = oCosonuoitrong.sTencoso;
                txtTongDienTichCoSoNuoi.Text = oCosonuoitrong.fTongdientich.ToString();
                txtTongDienTichMatNuoc.Text = oCosonuoitrong.fTongdientichmatnuoc.ToString();
                txtXa.Text = oCosonuoitrong.sXa;
                ddlDoituongnuoi.SelectedValue = oCosonuoitrong.FK_iDoituongnuoiID.ToString();
                ddlHinhThucNuoi.SelectedValue = oCosonuoitrong.FK_iHinhthucnuoiID.ToString();
                ddlNamSanXuat.SelectedValue = oCosonuoitrong.iNamsanxuat.ToString();
                ddlTinh.SelectedValue = QuanHuyenBRL.GetOne(oCosonuoitrong.FK_iQuanHuyenID).FK_iTinhThanhID.ToString();
                LoadQuanHuyen(QuanHuyenBRL.GetOne(oCosonuoitrong.FK_iQuanHuyenID).FK_iTinhThanhID);
                ddlHuyen.SelectedValue = oCosonuoitrong.FK_iQuanHuyenID.ToString();
                ToadoEntity oToado = ToadoBRL.GetOne(oCosonuoitrong.FK_iToadoID);
                txtKinhDo1.Text = oToado.Longitude;
                txtViDo1.Text = oToado.Latitude;
                //txtKinhDo.Text = oToado.Longitude;
                //txtViDo.Text = oToado.Latitude;
                txtSanluongdukien.Text = oCosonuoitrong.iSanluongdukien.ToString();
                chkKiemduyet.Checked = oCosonuoitrong.bDuyet;
                int iGroupID = Convert.ToInt32(Session["GroupID"].ToString());
                if(iGroupID==3||iGroupID==2)
                    chkKiemduyet.Visible = false;
                else
                    chkKiemduyet.Visible = true;
                fk_user =Convert.ToInt32(oCosonuoitrong.FK_iUserID);
                if (oCosonuoitrong.sSodoaonuoi.Trim() != String.Empty)
                {
                    img.ImageUrl = "" + ConfigurationManager.AppSettings["UploadPath"] + oCosonuoitrong.sSodoaonuoi;
                    img.Visible = true;
                }
                else
                    img.Visible = false;
            }
        }
        catch { }
        finally
        {
            
        }
    }
    protected void btnRegistry_Click(object sender, EventArgs e)
    {
        ccJoin.ValidateCaptcha(txtCapcha.Text);
        if (!ccJoin.UserValidated)
        {
            lblLoi.Text = "Mã xác nhận không đúng!";
            return;
        }
        try
        {
            string password = INVISecurity.MD5(txtPassword.Text);

            UserEntity us = new UserEntity();
            us.sUsername = txtUsername.Text;
            us.sPassword = password;
            us.sEmail = txtEmail.Text;
            us.bActive = false;
            us.tLastVisit = DateTime.Now;
            us.sIP = Request.ServerVariables["REMOTE_ADDR"].Trim();
            us.iGroupID = 2;
            fk_user = UserBRL.Add(us);
            FK_iUser.Value = fk_user.ToString();
            //Thêm cơ sở nuôi trồng giả định
            List<ToadoEntity> lstToado = ToadoBRL.GetAll();
            List<DoituongnuoiEntity> lstDoituong = DoituongnuoiBRL.GetAll();
            List<HinhthucnuoiEntity> lstHinhthuc = HinhthucnuoiBRL.GetAll();
            CosonuoitrongEntity oCoso = new CosonuoitrongEntity();
            oCoso.sTencoso = "Tên cơ sở";
            oCoso.sTenchucoso = "Tên chủ cơ sở";
            oCoso.FK_iQuanHuyenID = 2;
            oCoso.FK_iToadoID = lstToado[0].PK_iToadoID;
            oCoso.FK_iDoituongnuoiID = lstDoituong[0].PK_iDoituongnuoiID;
            oCoso.FK_iHinhthucnuoiID = lstHinhthuc[0].PK_iHinhthucnuoiID;
            oCoso.FK_iUserID = fk_user;
            iCosonuoitrongID = CosonuoitrongBRL.Add(oCoso);
            FK_iCosonuoitrong.Value = iCosonuoitrongID.ToString();
            btnDKThongtinCoSoNuoi.CommandName = "Edit";
            //List<UserEntity> list = UserBRL.GetAll();
            //list.Sort(
            //    delegate(UserEntity firstEntity, UserEntity secondEntity)
            //    {
            //        return secondEntity.iUserID.CompareTo(firstEntity.iUserID);
            //    }
            //);
            //fk_user = list[0].iUserID;
            SendEmailVerificationToUser(txtUsername.Text, fk_user.ToString());
            lblLoi.Text = "";
            pnDangKyTV.Visible = false;
            pnCSNT.Visible = true;
        }
        catch (Exception ex)
        {
            lblLoi.Text = ex.Message.ToString();
        }
    }
    public void SendEmailVerificationToUser(string strUsername,string iduser)
    {
        string body = "<b>Tài khoản</b>: ##UserName## đã được kích hoạt thành công. Bạn có thể sử dụng tài khoản này để đăng nhập và nhập các thông tin về Cơ sở nuôi trồng.";
        body += "Thực hiện việc gửi hồ sơ trực tuyến, đăng ký để được kiểm định, đánh giá và cấp mã số.";   
        body = body.Replace("##UserName##", strUsername);
        INVIHelper.Send_Email(txtEmail.Text, "Tài khoản bạn đăng ký với Tổ chức chứng nhận đã được kích hoạt.", body);
        
    }

    protected void btnDKThongtinCoSoNuoi_Click(object sender, EventArgs e)
    {
        EditCosonuoitrong();
        //int iQuanhuyenID, iDoituongnuoiID, iChukynuoi,iToadoID,iNamsanxuat,iSanluongdukien=0,iHinhThucNuoi;
        //float fTongdientich, fTongdientichmatnuoc,fDientichaolang;
        //bool bDuyet = false;
        //String sSodoaonuoi = String.Empty,sMacoso=String.Empty;
        //try
        //{            
        //    iQuanhuyenID = Convert.ToInt32(ddlHuyen.SelectedValue);
        //    fTongdientich = float.Parse(txtTongDienTichCoSoNuoi.Text);
        //    fTongdientichmatnuoc = float.Parse(txtTongDienTichMatNuoc.Text);
        //    iToadoID = getFKToaDo();
        //    //csnt.FK_iTinhID = Int32.Parse(ddlTinh.SelectedValue);
        //    iDoituongnuoiID = Int32.Parse(ddlDoituongnuoi.SelectedValue);
        //    iHinhThucNuoi = Int32.Parse(ddlHinhThucNuoi.SelectedValue);
        //    iNamsanxuat = Int32.Parse(ddlNamSanXuat.SelectedItem.Text);
        //    //dNgaydangky = DateTime.Now;
        //    iChukynuoi = int.Parse(txtChuKyNuoi.Text);
        //    iSanluongdukien = Convert.ToInt32(txtSanluongdukien.Text);            
        //    fDientichaolang = float.Parse(txtDienTichAoLang.Text);
        //    if (fuSoDoAoNuoi.HasFile)
        //    {
        //        INVIHelper.UploadImage(fuSoDoAoNuoi);
        //        sSodoaonuoi = fuSoDoAoNuoi.FileName;
        //    }
        //    if (btnDKThongtinCoSoNuoi.CommandName == "Edit")
        //    {
        //        //iCosonuoitrongID = Convert.ToInt32(Session["iCosonuoitrongID"].ToString());
        //        bDuyet = chkKiemduyet.Checked;
        //        CosonuoitrongBRL.Edit(iCosonuoitrongID, txtTenCoSo.Text, txtTenChuCoSo.Text, txtAp.Text, txtXa.Text, iQuanhuyenID, txtDienThoai.Text, fTongdientich, fTongdientichmatnuoc, iToadoID, sSodoaonuoi, iDoituongnuoiID, iNamsanxuat, iChukynuoi, DateTime.Now, fk_user, iSanluongdukien, "", bDuyet,fDientichaolang,iHinhThucNuoi);
        //        Response.Write("<script>alert('Cập nhập thành công!');location='Default.aspx?page=Cosonuoitrong'</script>");
        //    }
        //    else
        //    {
        //        bDuyet = false;
        //        CosonuoitrongBRL.Add(txtTenCoSo.Text, txtTenChuCoSo.Text, txtAp.Text, txtXa.Text, iQuanhuyenID, txtDienThoai.Text, fTongdientich, fTongdientichmatnuoc, iToadoID, sSodoaonuoi, iDoituongnuoiID, iNamsanxuat, iChukynuoi, DateTime.Now, fk_user, iSanluongdukien, "", bDuyet,fDientichaolang,iHinhThucNuoi);
        //        Session["ToaDo"] = null;

        //        Response.Write("<script>alert('Đăng ký thành công!');location='Default.aspx';</script>");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    lblLoi.Text = ex.Message.ToString();
        //    pnCSNT.Visible = true;
        //}
    }

    private void EditCosonuoitrong()
    {
        try
        {
            CosonuoitrongEntity oCosonuoitrong = null;
            if (iCosonuoitrongID > 0)
            {
                oCosonuoitrong = CosonuoitrongBRL.GetOne(iCosonuoitrongID);
            }
            else
            {
                oCosonuoitrong = new CosonuoitrongEntity();
            }
            oCosonuoitrong.sTencoso = txtTenCoSo.Text;
            oCosonuoitrong.sTenchucoso = txtTenChuCoSo.Text;
            oCosonuoitrong.FK_iQuanHuyenID = int.Parse(ddlHuyen.SelectedValue);
            oCosonuoitrong.sXa = txtXa.Text;
            oCosonuoitrong.sAp = txtAp.Text;
            oCosonuoitrong.sDienthoai = txtDienThoai.Text;
            oCosonuoitrong.fTongdientich = float.Parse(txtTongDienTichCoSoNuoi.Text);
            oCosonuoitrong.fTongdientichmatnuoc = float.Parse(txtTongDienTichMatNuoc.Text);
            oCosonuoitrong.fDientichAolang = float.Parse(txtDienTichAoLang.Text);
            if (fuSoDoAoNuoi.HasFile)
            {
                INVIHelper.UploadImage(fuSoDoAoNuoi);
                oCosonuoitrong.sSodoaonuoi = fuSoDoAoNuoi.FileName;
            }
            oCosonuoitrong.FK_iDoituongnuoiID = int.Parse(ddlDoituongnuoi.SelectedValue);
            oCosonuoitrong.FK_iHinhthucnuoiID = int.Parse(ddlHinhThucNuoi.SelectedValue);
            oCosonuoitrong.iChukynuoi = int.Parse(txtChuKyNuoi.Text);
            oCosonuoitrong.iNamsanxuat = int.Parse(ddlNamSanXuat.SelectedValue);
            oCosonuoitrong.iSanluongdukien = int.Parse(txtSanluongdukien.Text);
            oCosonuoitrong.PK_iCosonuoitrongID = iCosonuoitrongID;

            //Cập nhật lại tọa độ
            if (oCosonuoitrong!=null && oCosonuoitrong.FK_iToadoID > 0)
            {
                ToadoEntity oToado = ToadoBRL.GetOne(oCosonuoitrong.FK_iToadoID);
                oToado.Latitude = txtViDo1.Text;
                oToado.Longitude = txtKinhDo1.Text;
                ToadoBRL.Edit(oToado);
                Session["iCosonuoitrongID"] = null;
            }
            else
            {
                ToadoEntity oToado = new ToadoEntity();
                oToado.Latitude = txtViDo1.Text;
                oToado.Longitude = txtKinhDo1.Text;
                ToadoBRL.Add(oToado);
            }
            //Nếu sửa
            if (btnDKThongtinCoSoNuoi.CommandName == "Edit")
            {
                if (chkKiemduyet.Checked)
                {
                    oCosonuoitrong.bDuyet = true;
                }
                CosonuoitrongBRL.Edit(oCosonuoitrong);
                if(HttpContext.Current.Request.Url.AbsolutePath.ToString().Contains("Register"))
                {
                    Response.Write("<script>alert('Đăng ký cơ sở nuôi trồng thành công!');location='Default.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Cập nhập thành công!');location='Default.aspx?page=Cosonuoitrong'</script>");
                }
            }
            else
            {
                oCosonuoitrong.dNgaydangky = DateTime.Now;
                CosonuoitrongBRL.Add(oCosonuoitrong);
                Response.Write("<script>alert('Đăng ký thành công!');location='Default.aspx';</script>");
            }
            
        }
        catch (Exception ex)
        {
            lblLoi.Text = ex.Message;
            pnCSNT.Visible = true;
        }
    }
    
    private int getFKToaDo()
    {
        ToadoEntity toado = new ToadoEntity();
        //if ((txtViDo.Text.Trim()!="") && (txtKinhDo.Text.Trim()!=""))
        //{
        //    toado.Latitude = txtViDo1.Text;
        //    toado.Longitude = txtKinhDo1.Text;
        //}
        //else
        //{
        //    GooglePoint GP = new GooglePoint();
        //    GP.Address = getAdd();
        //    if (GP.GeocodeAddress(ConfigurationManager.AppSettings["GoogleAPIKey"].ToString()))
        //    {
        //        GP.InfoHTML = GP.Address;
        //        toado.Longitude   = GP.Longitude;
        //        toado.Latitude= GP.Latitude;
        //    }
        //}
        
        ToadoBRL.Add(toado);
        List<ToadoEntity> list = ToadoBRL.GetAll();
        list.Sort(
            delegate(ToadoEntity firstEntity, ToadoEntity secondEntity)
            {
                return secondEntity.PK_iToadoID.CompareTo(firstEntity.PK_iToadoID);
            }
        );
        return list[0].PK_iToadoID;
    }
    protected void ddlTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadQuanHuyen(Convert.ToInt32(ddlTinh.SelectedValue));
    }        
    private string getAdd()
    {
        addr = "";
        if (txtXa.Text.Trim() != "")
        {
            addr += txtXa.Text + ", ";
        }        
        addr += ddlHuyen.SelectedItem.Text + ", ";        
        addr += ddlTinh.SelectedItem.Text;
        return addr;
    }   
    
    protected void lbtMaps_Click(object sender, EventArgs e)
    {
        pnCSNT.Visible = true;
    }
    protected void ddlHuyen_SelectedIndexChanged(object sender, EventArgs e)
    {
        PK_iHuyenID.Value = ddlHuyen.SelectedValue.ToString();
    }
}
