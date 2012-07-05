using INVI.Entity;
using INVI.Business;
using INVI.INVILibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Globalization;

public partial class ucTochuccapphepUpdate : System.Web.UI.UserControl
{
    private static byte[] logo = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblLoi.Text = "";
        if (!Page.IsPostBack)
        {
            napTinh();
            napUser();
            //LoadQuanHuyen(Convert.ToInt32(ddlTinh.SelectedValue));
            napCoquancaptrenDll();
            pnTochuccaphep.Visible = true;
            if (Request.QueryString["do"] != null && Request.QueryString["do"] == "add")
            {                
                if (!PermissionBRL.CheckPermission("AddTochuccapphep")) Response.End();
                clearForm();
                pnDuyet.Visible = false;
                btnOk.CommandName = "Add";
                btnOk.Text = "Thêm";
            }
            else if (Request.QueryString["PK_iTochucchungnhanID"] != null)
            {
                
                if (!PermissionBRL.CheckPermission("EditTochuccapphep")) Response.End();
                // Bị lỗi cái chỗ khỉ này
                int PK_iTochucchungnhanID = Convert.ToInt32(Request.QueryString["PK_iTochucchungnhanID"].ToString());
                this.napForm(PK_iTochucchungnhanID);
                btnOk.CommandName = "Edit";
                btnOk.Text = "Sửa";
                pnDuyet.Visible = true;
                btnOk.CommandArgument = PK_iTochucchungnhanID.ToString();
            }
            else if (Session["iTochucchungnhanID"] != null)
            {
                int PK_iTochucchungnhanID = Convert.ToInt32(Session["iTochucchungnhanID"].ToString());
                this.napForm(PK_iTochucchungnhanID);
                btnOk.CommandName = "Edit";
                btnOk.Text = "Sửa";
                pnDuyet.Visible = false;
                btnOk.CommandArgument = PK_iTochucchungnhanID.ToString();
            }
            else
            {
                if(Convert.ToInt32(Session["GroupID"].ToString())==1)
                    Response.Redirect("~/adminx/Default.aspx");
                else if(Convert.ToInt32(Session["GroupID"].ToString())==4)
                    Response.Redirect("~/adminx/Tochucchungnhan/Default.aspx");
            }
        }
    }
    private void clearForm()
    {
        txtTochucchungnhan.Text = String.Empty;
        txtDiachi.Text = String.Empty;
        //txtKytuviettat.Text = String.Empty;
        Session.Remove("PK_iTochucchungnhanID");
    }
    private void napForm(int PK_iTochucchungnhanID)
    {
        TochucchungnhanEntity entity = TochucchungnhanBRL.GetOne(PK_iTochucchungnhanID);
        if (entity != null)
        {
            txtTochucchungnhan.Text = entity.sTochucchungnhan;
            txtDiachi.Text = entity.sDiachi;
            //txtKytuviettat.Text = entity.sKytuviettat;
            txtDienthoai.Text = entity.sSodienthoai;
            
            QuanHuyenEntity oQuanHuyen = QuanHuyenBRL.GetOne(entity.FK_iQuanHuyenID);
            //TinhEntity oTinh = TinhBRL.GetOne(oQuanHuyen.FK_iTinhThanhID);
            ddlTinh.SelectedValue = oQuanHuyen.FK_iTinhThanhID.ToString();
            LoadQuanHuyen(Convert.ToInt32(ddlTinh.SelectedValue));
            ddlQuanHuyen.SelectedValue = entity.FK_iQuanHuyenID.ToString();
            imgLogo.ImageUrl = "ViewImage.aspx?ID=" + PK_iTochucchungnhanID;
            if (imgLogo != null)
                Session["hasLogo"] = true;
            logo = entity.imgLogo;

            List<TochucchungnhanTaikhoanEntity> lstTochucTaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTochucchungnhanID(entity.PK_iTochucchungnhanID);

            if (lstTochucTaikhoan.Count > 0)
                ddlTaikhoan.SelectedValue = lstTochucTaikhoan[0].FK_iTaikhoanID.ToString();
            if(Convert.ToInt32(entity.FK_iCoquancaptrenID)>0)
                ddlCoquancaptren.SelectedValue = entity.FK_iCoquancaptrenID.ToString();
            cbDuyet.Checked = entity.bDuyet;
            btnOk.CommandArgument = entity.PK_iTochucchungnhanID.ToString();
        }
    }
    protected void napTinh()
    {
        ddlTinh.Items.Clear();
        List<TinhEntity> lstTinh = TinhBRL.GetAll();
        ddlTinh.DataSource = lstTinh;
        ddlTinh.DataTextField = "sTentinh";
        ddlTinh.DataValueField = "PK_iTinhID";
        ddlTinh.DataBind();
    }

    protected void napUser()
    {
        ddlTaikhoan.Items.Clear();
        List<UserEntity> lstUser = UserBRL.GetAll();        
        //List<UserEntity> lst = new List<UserEntity>();
        //lstUser.ForEach(
        //        delegate(UserEntity oUser)
        //        {
        //            if (oUser.iGroupID == 4 && TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(oUser.iUserID).Count==0)
        //                lst.Add(oUser);
        //        }
        //    );
        ddlTaikhoan.DataTextField = "sUsername";
        ddlTaikhoan.DataValueField = "iUserID";
        ddlTaikhoan.DataSource = lstUser;
        ddlTaikhoan.DataBind();
        ddlTaikhoan.Items.Insert(0, new ListItem("--- Chọn ---", "0"));

    }
    private void napCoquancaptrenDll()
    {
        List<CoquancaptrenEntity> lstCoquancaptren = CoquancaptrenBRL.GetAll();
        ddlCoquancaptren.DataSource = lstCoquancaptren;
        ddlCoquancaptren.DataTextField = "sTencoquan";
        ddlCoquancaptren.DataValueField = "PK_iCoquancaptrenID";
        ddlCoquancaptren.DataBind();
    }
    private void LoadQuanHuyen(int fk_Tinh)
    {
        ddlQuanHuyen.Items.Clear();
        List<QuanHuyenEntity> lst = QuanHuyenBRL.GetByFK_iTinhThanhID(Convert.ToInt16(fk_Tinh));
        ddlQuanHuyen.DataSource = lst;
        ddlQuanHuyen.DataTextField = "sTen";
        ddlQuanHuyen.DataValueField = "PK_iQuanHuyenID";
        ddlQuanHuyen.DataBind();
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {

                TochucchungnhanEntity entity = new TochucchungnhanEntity();
                Int64 PK_iUserID = 0;
                entity.sTochucchungnhan = txtTochucchungnhan.Text;
                entity.sSodienthoai = txtDienthoai.Text;
                entity.sDiachi = txtDiachi.Text;
                //if (Session["UserID"] != null)
                //    PK_iUserID = int.Parse(Session["UserID"].ToString());
                PK_iUserID = Convert.ToInt64(ddlTaikhoan.SelectedValue);
                List<TochucchungnhanTaikhoanEntity> lstTochucTaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(PK_iUserID);

                if (lstTochucTaikhoan.Count > 0)
                {
                    if (Convert.ToInt32(ddlTaikhoan.SelectedValue) > 0)
                        lstTochucTaikhoan[0].FK_iTaikhoanID = Convert.ToInt32(ddlTaikhoan.SelectedValue);
                    ddlTaikhoan.SelectedValue = lstTochucTaikhoan[0].FK_iTaikhoanID.ToString();
                }// Xử lý lại. Vì khi tạo mới làm gì đã có tổ chức chứng nhận mà gắn vào.
                //else
                //{
                //    TochucchungnhanTaikhoanEntity oTochucTaikhoan = new TochucchungnhanTaikhoanEntity();
                //    oTochucTaikhoan.bActive = cbDuyet.Checked;
                //    oTochucTaikhoan.dNgaythuchien = DateTime.Today;
                //    oTochucTaikhoan.FK_iTaikhoanID = Convert.ToInt32(ddlTaikhoan.SelectedValue);

                //    oTochucTaikhoan.FK_iTochucchungnhanID = Convert.ToInt32(btnOk.CommandArgument);
                //    TochucchungnhanTaikhoanBRL.Add(oTochucTaikhoan);
                //}
                entity.FK_iQuanHuyenID = Convert.ToInt32(ddlQuanHuyen.SelectedValue);
                entity.FK_iCoquancaptrenID = Convert.ToInt32(ddlCoquancaptren.SelectedValue);
                entity.bDuyet = false;
                entity.sKytuviettat = " ";
                byte[] bytImage = null;
                // xu ly anh
                if (fuLogo.PostedFile != null)
                {
                    if (fuLogo.PostedFile.ContentLength > 0)
                    {
                        string strEx = "jpg|jpeg|bmp|png|gif";
                        string fileEx = fuLogo.FileName.Substring(fuLogo.FileName.LastIndexOf('.')).Remove(0, 1);
                        string[] arrEx = strEx.Split('|');
                        bool valid = false;
                        foreach (string ex in arrEx)
                        {
                            if (ex.Equals(fileEx, StringComparison.OrdinalIgnoreCase))
                                valid = true;
                        }
                        if (valid)
                        {

                            HttpPostedFile objHttpPostedFile = fuLogo.PostedFile;
                            int intContentlength = objHttpPostedFile.ContentLength;
                            bytImage = new Byte[intContentlength];
                            objHttpPostedFile.InputStream.Read(bytImage, 0, intContentlength);
                            entity.imgLogo = bytImage;
                        }
                    }
                    else if (btnOk.CommandName == "Add")
                    {
                        lblLoi.Text = "Bạn chưa chọn logo";
                        return;
                    }
                    else if (logo != null)
                    {
                        entity.imgLogo = logo;
                        logo = null;
                    }
                    else
                    {
                        // Nếu là sửa chữa thì check xem nếu đã có logo trong CSDL thì thôi không thông báo
                        if(!Convert.ToBoolean(Session["hasLogo"].ToString())==true)
                            lblLoi.Text = "Bạn chưa chọn logo";
                        return;
                    }
                }
                //
                if (btnOk.CommandName == "Edit")
                {
                    entity.bDuyet = cbDuyet.Checked;
                    entity.PK_iTochucchungnhanID = Convert.ToInt32(btnOk.CommandArgument);
                    TochucchungnhanEntity oTochucchungnhan = TochucchungnhanBRL.GetOne(entity.PK_iTochucchungnhanID);
                    entity.iTrangthai = TochucchungnhanBRL.GetOne(entity.PK_iTochucchungnhanID).iTrangthai;
                    if (oTochucchungnhan.sKytuviettat.Trim().Length == 0)
                        entity.sKytuviettat = "Chưa cấp";
                    else
                        entity.sKytuviettat = oTochucchungnhan.sKytuviettat;
                    entity.PK_iTochucchungnhanID = Convert.ToInt32(btnOk.CommandArgument);
                    
                    TochucchungnhanBRL.Edit(entity);
                    // Lấy dữ liệu về Tài khoản theo TCCN
                    List<TochucchungnhanTaikhoanEntity> lsTochucchungnhantaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTochucchungnhanID(entity.PK_iTochucchungnhanID);
                    if (lsTochucchungnhantaikhoan.Count > 0) // 
                    {
                        TochucchungnhanTaikhoanEntity oTochucchungnhanTaikhoan = lsTochucchungnhantaikhoan[0];
                        oTochucchungnhanTaikhoan.FK_iTaikhoanID = Convert.ToInt32(ddlTaikhoan.SelectedValue);
                        oTochucchungnhanTaikhoan.FK_iTochucchungnhanID = entity.PK_iTochucchungnhanID;
                        oTochucchungnhanTaikhoan.dNgaythuchien = DateTime.Today;
                        oTochucchungnhanTaikhoan.bActive = true;
                        TochucchungnhanTaikhoanBRL.Edit(oTochucchungnhanTaikhoan);
                    }
                }
                else
                {
                    int iTochucchungnhanID=TochucchungnhanBRL.Add(entity);
                    lblLoi.Text = "Bổ sung thành công";
                    TochucchungnhanTaikhoanEntity oTochucTaikhoan = new TochucchungnhanTaikhoanEntity();
                    oTochucTaikhoan.bActive = cbDuyet.Checked;

                    oTochucTaikhoan.dNgaythuchien = DateTime.Today;
                    oTochucTaikhoan.FK_iTaikhoanID = Convert.ToInt32(ddlTaikhoan.SelectedValue);
                    oTochucTaikhoan.FK_iTochucchungnhanID = iTochucchungnhanID;
                    TochucchungnhanTaikhoanBRL.Add(oTochucTaikhoan);
                    Response.Write("<script language=\"javascript\">alert('Bổ sung thành công!');location='Default.aspx?page=TochuccapphepQuanly';</script>");

                }
                //Nạp lại dữ liệu
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=TochuccapphepUpdate';</script>");
            }
        }

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        clearForm();
    }
    protected void ddlTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadQuanHuyen(Convert.ToInt32(ddlTinh.SelectedValue));
    }

    protected void ddlTaikhoan_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iUserID = Convert.ToInt32(ddlTaikhoan.SelectedValue);
        List<TochucchungnhanTaikhoanEntity> lstTochucTaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(iUserID);
        if (lstTochucTaikhoan != null && lstTochucTaikhoan.Count > 0 && lstTochucTaikhoan[0].FK_iTochucchungnhanID!=Convert.ToInt32(btnOk.CommandArgument))
        {
            lblLoi.Text = "User này đã sử dụng cho Tổ chức CN khác";
            return;
        }
        else if (UserBRL.GetOne(iUserID).bActive == false)
        {
            lblLoi.Text = "Tài khoản này chưa được kích hoạt";
            return;
        }
    }
}