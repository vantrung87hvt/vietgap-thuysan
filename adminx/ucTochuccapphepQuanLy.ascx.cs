using INVI.Entity;
using INVI.Business;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminx_ucTochuccapphepQuanLy : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!PermissionBRL.CheckPermission("QuanlyTCCN")) Response.End();   
            List<TochucchungnhanEntity> lstTochucchungnhan = TochucchungnhanBRL.GetAll();
            if (lstTochucchungnhan != null && lstTochucchungnhan.Count > 0)
                //    DanhsachTochucchungnhan = lstTochucchungnhan.FindAll(delegate(TochucchungnhanEntity oTochucchungnhan) { return oTochucchungnhan.iTrangthai == 2; });
                DanhsachTochucchungnhan = lstTochucchungnhan;
            napGridView();
        }
        if (Request.QueryString["PK_iTochucchungnhanID"] != null)
        {
            int PK_iTochucchungnhanID = Convert.ToInt32(Request.QueryString["PK_iTochucchungnhanID"]);
            hienThiThongTinTochuc(PK_iTochucchungnhanID);
        }
    }
    private void hienThiThongTinTochuc(int PK_iTochucchungnhanID)
    {
        TochucchungnhanEntity oTochucchungnhan = TochucchungnhanBRL.GetOne(PK_iTochucchungnhanID);
        if (oTochucchungnhan == null) return;
        
        lblDiachi.Text = oTochucchungnhan.sDiachi;
        lblEmail.Text = oTochucchungnhan.sEmail;
        lblSodangkykinhdoanh.Text = oTochucchungnhan.sSodangkykinhdoanh;
        lblSodienthoai.Text = oTochucchungnhan.sSodienthoai;
        lblTentochuc.Text = oTochucchungnhan.sTochucchungnhan;
        
                
        List<XulyTochucchungnhanEntity> lstXulyTochucchungnhan = XulyTochucchungnhanBRL.GetByFK_iTochucchungnhanID(PK_iTochucchungnhanID);
        if (lstXulyTochucchungnhan != null && lstXulyTochucchungnhan.Count > 0)
        {
            XulyTochucchungnhanEntity.Sort(lstXulyTochucchungnhan, "dNgaythuchien", "DESC");
            lblTinhtrang.Text = getTinhtrang(lstXulyTochucchungnhan[0].iMucdo);
            
        }
        btnXuly.CommandArgument = oTochucchungnhan.PK_iTochucchungnhanID.ToString();
        pnlXuly.Visible = true;
    }
    private String getTinhtrang(short iMucdo)
    {
        String sTinhtrang = "Hoạt động";
        switch (iMucdo)
        {
            case 0:
                sTinhtrang = "Khôi phục"; break;
            case 1:
                sTinhtrang = "Cảnh cáo"; break;
            case 2:
                sTinhtrang = "Đình chỉ"; break;
            case 3:
                sTinhtrang = "Thu hồi"; break;
            default:
                sTinhtrang = "Hoạt động bình thường.";break;
        }
        return sTinhtrang;
    }
    public List<TochucchungnhanEntity> DanhsachTochucchungnhan
    {
        get
        {
            if (Cache["DanhsachTochucchungnhan"] == null)
                return new List<TochucchungnhanEntity>();
            else
                return (List<TochucchungnhanEntity>)Cache["DanhsachTochucchungnhan"];
        }
        set { Cache["DanhsachTochucchungnhan"] = value; }
    }
    private void napGridView()
    {
        List<TochucchungnhanEntity> list = new List<TochucchungnhanEntity>();
        if (DanhsachTochucchungnhan != null)
            list = DanhsachTochucchungnhan;
        else
            list = TochucchungnhanBRL.GetAll();
        grvTochuccapphep.DataSource = TochucchungnhanEntity.Sort(list, "sTochucchungnhan", "DESC");
        grvTochuccapphep.DataKeyNames = new string[] { "PK_iTochucchungnhanID" };
        grvTochuccapphep.DataBind();
    }

    protected void grvTochuccapphep_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTochuccapphep.PageIndex = e.NewPageIndex;
        napGridView();
    }
    protected void grvTochuccapphep_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblQuanHuyen = null, lblTaikhoan = null,lblTrangthai=null;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            lblQuanHuyen = (Label)e.Row.FindControl("lblQuanHuyen");
            lblTaikhoan = (Label)e.Row.FindControl("lblTaikhoan");
            lblTrangthai =(Label)e.Row.FindControl("lblTrangthai");
            if (lblQuanHuyen != null)
            {
                int bTinhthanhID = int.Parse(lblQuanHuyen.Text);
                lblQuanHuyen.Text = sQuanHuyen(bTinhthanhID);
            }
            if (lblTaikhoan != null)
            {
                int iUserID = byte.Parse(lblTaikhoan.Text);
                lblTaikhoan.Text = sTaikhoan(iUserID);
            }
            if (lblTrangthai != null)
            {
                //Byte iTrangthai = Convert.ToByte(lblTrangthai.Text);
                //lblTrangthai.Text = getTrangthai(iTrangthai);
                int PK_iTochucchungnhanID = Convert.ToInt32(grvTochuccapphep.DataKeys[e.Row.RowIndex].Values["PK_iTochucchungnhanID"].ToString());
                lblTrangthai.Text = getTrangthaixuly(PK_iTochucchungnhanID);
            }
        }
        
    }
    private String getTrangthaixuly(int PK_iTochucchungnhanID)
    {
        String sTrangthaiXuly = "Hoạt động bình thường";
        List<XulyTochucchungnhanEntity> lstXulyTochucchungnhan = XulyTochucchungnhanBRL.GetByFK_iTochucchungnhanID(PK_iTochucchungnhanID);
        if (lstXulyTochucchungnhan != null && lstXulyTochucchungnhan.Count > 0)
        {
            XulyTochucchungnhanEntity.Sort(lstXulyTochucchungnhan, "dNgaythuchien", "DESC");
            sTrangthaiXuly = getTinhtrang(lstXulyTochucchungnhan[0].iMucdo);
        }
        return sTrangthaiXuly;
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
                return "Đã cấp mã số";
            default:
                return "";
        }
    }
    private String sQuanHuyen(int iQuanHuyen)
    {
        String sQuanHuyen = String.Empty;
        QuanHuyenEntity oQuanHuyen = QuanHuyenBRL.GetOne(iQuanHuyen);
        
        sQuanHuyen = oQuanHuyen.sTen + ", ";
        TinhEntity oTinhthanh = TinhBRL.GetOne(oQuanHuyen.FK_iTinhThanhID);
        sQuanHuyen += oTinhthanh.sTentinh;
        return sQuanHuyen;
    }
    private String sTaikhoan(int iUserID)
    {
        String sTaikhoan = String.Empty;
        if (iUserID == 0)
            return "Chưa có";
        UserEntity oUser = UserBRL.GetOne(iUserID);
        sTaikhoan = oUser.sUsername;
        return sTaikhoan;
    }

    protected void grvTochuccapphep_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String sCommand = e.CommandName;
        if (e.CommandName == "cmdReport")
        {

            int chkid = Convert.ToInt32(e.CommandArgument);
            GridViewRow row1 = grvTochuccapphep.Rows[chkid];

            TableCell tblCell = row1.Cells[1];
            string PK_iTochucchungnhanID = tblCell.Text;
            Session["PK_iTochucchungnhanID"] = PK_iTochucchungnhanID;
            Response.Redirect("~/adminx/Default.aspx?page=TochuccapphepDanhgia");
        }
        else if (e.CommandName == "cmdInfor")
        {

            int chkid = Convert.ToInt32(e.CommandArgument);
            GridViewRow row1 = grvTochuccapphep.Rows[chkid];

            TableCell tblCell = row1.Cells[1];
            string PK_iTochucchungnhanID = tblCell.Text;
            //btnDummy_ModalPopupExtender.DynamicContextKey = PK_iTochucchungnhanID;
            //btnDummy_ModalPopupExtender.Show();
        }
    }

    protected void grvTochuccapphep_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int iTochuccapphepID = Convert.ToInt32(grvTochuccapphep.DataKeys[e.NewSelectedIndex].Values["PK_iTochucchungnhanID"]);
        //Session["PK_iTochucchungnhanID"] = iTochuccapphepID.ToString();
        Response.Redirect("~/adminx/Default.aspx?page=TochuccapphepUpdate&PK_iTochucchungnhanID="+iTochuccapphepID);
    }
    protected void grvTochuccapphep_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<TochucchungnhanEntity> list = TochucchungnhanBRL.GetAll();
        grvTochuccapphep.DataSource = TochucchungnhanEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
        grvTochuccapphep.DataBind();
    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
      
            try
            {
                foreach (GridViewRow row in grvTochuccapphep.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int ID = Convert.ToInt32(grvTochuccapphep.DataKeys[row.RowIndex].Values["PK_iTochucchungnhanID"]);
                    if (chkDelete != null && chkDelete.Checked)
                    {
                        TochucchungnhanBRL.Remove(ID);
                    }
                }
                //Nap lai du lieu
                Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=TochuccapphepQuanLy';</script>");
            }
       
    }
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearchByID.Text;
        int iTCCNID = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            iTCCNID = 0;
        else iTCCNID = Int16.Parse(txtID.Text);
        List<TochucchungnhanEntity> lstTCCN = new List<TochucchungnhanEntity>();
        if (DanhsachTochucchungnhan != null & DanhsachTochucchungnhan.Count > 0)
            lstTCCN = DanhsachTochucchungnhan;
        else
            lstTCCN = TochucchungnhanBRL.GetAll();
        if (iTCCNID == 0)
        {
            lstTCCN = lstTCCN.FindAll(
            delegate(TochucchungnhanEntity oTCCN)
            {
                return oTCCN.sTochucchungnhan.ToUpper().Contains(strSearch.ToUpper()) || oTCCN.sKytuviettat.ToUpper().Contains(strSearch.ToUpper());
            }
            );
        }
        else
        {
            lstTCCN = lstTCCN.FindAll(
            delegate(TochucchungnhanEntity oTCCN)
            {
                return oTCCN.PK_iTochucchungnhanID == iTCCNID;
            }
            );
        }
        lblThongbao.Text = "";
        grvTochuccapphep.DataSource = lstTCCN;
        grvTochuccapphep.DataSource = TochucchungnhanEntity.Sort(lstTCCN, "sTochucchungnhan", "DESC");
        grvTochuccapphep.DataKeyNames = new string[] { "PK_iTochucchungnhanID" };
        grvTochuccapphep.DataBind();
               
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napGridView();
    }
    
    protected void btnXuly_Click(object sender, EventArgs e)
    {
        XulyTochucchungnhanEntity oXulyTochucchungnhan = new XulyTochucchungnhanEntity();
        oXulyTochucchungnhan.dNgaythuchien = DateTime.Today;
        oXulyTochucchungnhan.iMucdo = Convert.ToByte(ddlHinhthucxuly.SelectedValue);
        oXulyTochucchungnhan.sLydo = txtLydo.Text;
        oXulyTochucchungnhan.FK_iTochucchungnhanID = Convert.ToInt32(btnXuly.CommandArgument);
        XulyTochucchungnhanBRL.Add(oXulyTochucchungnhan);
        Response.Write("<script language=\"javascript\">alert('Xử lý thành công!');location='Default.aspx?page=TochucchuccapphepQuanly';<script>");
    }
    protected void ddlHinhthucxuly_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (ddlHinhthucxuly.SelectedIndex)
        {
            case 0:
                txtLydo.Text = "Đã hoàn tất các thủ tục, khắc phục các lỗi tuân thủ tiêu chuẩn Việt Gap";
                break;
            case 1:
                txtLydo.Text = "Mắc lỗi trong tuân thủ VietGAP";
                txtLydo.Enabled = false;
                break;
            case 2:
                txtLydo.Text = "Không khắc phục các lỗi trong tuân thủ VietGAP";
                txtLydo.Enabled = false;
                break;
            case 3:
                txtLydo.Text = "a. Kết quả kiểm tra giám sát cho thấy bằng chứng không đáp ứng yêu cầu theo VietGAP hoặc sản phẩm nuôi không đảm bảo an toàn thực phẩm\n";
                txtLydo.Text += "b. Từ chối kiểm tra khi được yêu cầu hoặc xin hoãn kiểm tra 2 lần liên tiếp mà không có lý do chính đáng.\n";
                txtLydo.Text += "c. Vi phạm quy định về sử dụng mã số chứng nhận; sử dụng logo VietGAP không đúng theo quy định.\n";
                txtLydo.Text += "d. Vi phạm quy định về kiểm tra chứng nhận, xuất xứ sản phẩm nuôi.";
                break;
        }
    }
}