using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.Business;
using System.Data;

using System.Text;
public partial class adminx_ucCosonuoitrong : System.Web.UI.UserControl
{
    List<CosonuoitrongEntity> lstCosonuoitrong;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            napGridView();
        }
    }
    private void napGridView()
    {
        int iGroupID = Convert.ToInt16(Session["GroupID"].ToString());
        
        int iUserID = Convert.ToInt32(Session["UserID"].ToString());
        if (iGroupID != 1)
        {
            // Lấy danh sách tổ chức chứng nhận được sử dụng bởi User.
            List<TochucchungnhanTaikhoanEntity> lstTochucTaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(iUserID);
            if (lstTochucTaikhoan.Count == 0)
            {
                Response.Write("<script>alert('Tổ chức này không quản lý bất cứ Cơ sở nuôi trồng nào.');</script>");
                return;
            }
            TochucchungnhanEntity oTochucchungnhan = TochucchungnhanBRL.GetOne(lstTochucTaikhoan[0].FK_iTochucchungnhanID);
            lstCosonuoitrong = CosonuoitrongBRL.GetByFK_iTochucchungnhanID(oTochucchungnhan.PK_iTochucchungnhanID);
            Session["oTochucchungnhan"] = oTochucchungnhan;
        }
        else
            lstCosonuoitrong = CosonuoitrongBRL.GetAll();
        grvCosonuoitrong.DataSource = lstCosonuoitrong;
        grvCosonuoitrong.DataKeyNames = new string[] { "PK_iCosonuoitrongID" };

        grvCosonuoitrong.DataBind();
    }

    private void ExportToExcel(string strFileName, DataGrid dg)
    {
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=" + strFileName);
        Response.ContentType = "application/excel";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        dg.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
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
    private String taoMacoso()
    {
        String sRnd = string.Empty;
        List<CosonuoitrongEntity> lstCosonuoitrong = new List<CosonuoitrongEntity>();
        do
        {   sRnd = randomString(5);
            lstCosonuoitrong = CosonuoitrongBRL.GetAll().FindAll(delegate(CosonuoitrongEntity oCosonuoitrong) {
                return oCosonuoitrong.sMasocoso == sRnd;
            });
        }
        while (lstCosonuoitrong.Count > 0);
        return sRnd;
    }
    protected void lbtnVerify_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grvCosonuoitrong.Rows)
        {
            CheckBox chk = row.FindControl("chkVerify") as CheckBox;
            String sMacoso = String.Empty;
            int csntID = Convert.ToInt32(grvCosonuoitrong.DataKeys[row.RowIndex].Values["PK_iCosonuoitrongID"]);
            if (chk != null)
            {
                // Nếu checkbox được check thì mới tạo mã số
                CosonuoitrongEntity oCosonuoitrong = CosonuoitrongBRL.GetOne(csntID);
                if (chk.Checked)
                {
                    if (oCosonuoitrong.sMasocoso.Length > 0)
                        sMacoso = oCosonuoitrong.sMasocoso;
                    else
                    {
                        TochucchungnhanEntity oTochucchungnhan;
                        if (Session["oTochucchungnhan"] != null)
                        {
                            oTochucchungnhan = (TochucchungnhanEntity)Session["oTochucchungnhan"];
                            sMacoso = oTochucchungnhan.sKytuviettat;
                        }
                    }
                }
                oCosonuoitrong.sMasocoso = sMacoso;
                CosonuoitrongBRL.Edit(oCosonuoitrong);
            }
        }
        //Nap lai du lieu
        Response.Redirect(Request.Url.ToString());
    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
            try
            {
                foreach (GridViewRow row in grvCosonuoitrong.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    if (chkDelete != null && chkDelete.Checked)
                    {
                        int csntID = Convert.ToInt32(grvCosonuoitrong.DataKeys[row.RowIndex].Values["PK_iCosonuoitrongID"]);
                        CosonuoitrongBRL.Remove(csntID);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=Cosonuoitrong';</script>");
            }
    }
    protected void grvNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvCosonuoitrong.PageIndex = e.NewPageIndex;
        napGridView();
    }
    protected void grvNews_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int iCosonuoitrongID = Convert.ToInt32(grvCosonuoitrong.DataKeys[e.NewSelectedIndex].Values["PK_iCosonuoitrongID"]);
        Session["iCosonuoitrongID"] = iCosonuoitrongID.ToString(); ;
        Response.Redirect("~/adminx/Default.aspx?page=CosonuoitrongUpdate_");
    }
    protected void grvNews_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<CosonuoitrongEntity> list = CosonuoitrongBRL.GetAll();
        grvCosonuoitrong.DataSource = CosonuoitrongEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
        grvCosonuoitrong.DataBind();
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
                return oCSNT.sTencoso.ToUpper().Contains(strSearch.ToUpper());
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
        grvCosonuoitrong.DataSource = lstCSNT;
        grvCosonuoitrong.DataKeyNames = new string[] { "PK_iCosonuoitrongID" };
        grvCosonuoitrong.DataBind();

    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napGridView();
    }
    protected void grvNews_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblQuanHuyen = null, lblDoituongnuoi = null,lblTrangthai=null;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            lblQuanHuyen = (Label)e.Row.FindControl("lblTinhthanh");
            lblDoituongnuoi = (Label)e.Row.FindControl("lblDoituongnuoi");
            lblTrangthai = (Label)e.Row.FindControl("lblTrangthai");
            if (lblQuanHuyen != null && lblQuanHuyen.Text != "")
            {
                int bTinhthanhID = int.Parse(lblQuanHuyen.Text);
                lblQuanHuyen.Text = sTentinhthanh(bTinhthanhID);
            }
            if (lblDoituongnuoi != null&&lblDoituongnuoi.Text!="")
            {
                byte bDoituongnuoiID = byte.Parse(lblDoituongnuoi.Text);
                lblDoituongnuoi.Text = getTendoituongnuoi(bDoituongnuoiID);
            }
            if(lblTrangthai!=null)
            {
                lblTrangthai.Text = getTrangThai(Convert.ToInt32(lblTrangthai.Text));
            }
        }
        
    }
    private String getTrangThai(int iCosonuoiID)
    {
        String sTrangthai = String.Empty;
        List<PhatEntity> lstPhat = PhatBRL.GetByFK_iCosonuoiID(iCosonuoiID);
        if (lstPhat.Count > 0)
        {
            PhatEntity.Sort(lstPhat, "dNgaythuchien", "DESC");
            switch (lstPhat[0].iMucdo)
            {
                case 0:
                    sTrangthai = "Hoạt động"; break;
                case 1:
                    sTrangthai = "Cảnh cáo"; break;
                case 2:
                    sTrangthai = "Đình chỉ"; break;
                case 3:
                    sTrangthai = "Thu hồi"; break;
            }
        }
        else
            sTrangthai = "Hoạt động";
        return sTrangthai;
    }
    private String sTentinhthanh(int FK_iQuanHuyenID)
    {
        String sTentinhthanh = String.Empty;
        QuanHuyenEntity oQuanHuyen = QuanHuyenBRL.GetOne(FK_iQuanHuyenID);
        TinhEntity oTinhthanh = TinhBRL.GetOne(oQuanHuyen.FK_iTinhThanhID);
        if(oTinhthanh!=null)
            sTentinhthanh = oTinhthanh.sTentinh;
        return sTentinhthanh;
    }
    private String getTendoituongnuoi(byte iDoituongnuoiID)
    {
        String sDoituongnuoi = String.Empty;
        DoituongnuoiEntity oDoituongnuoi = DoituongnuoiBRL.GetOne(iDoituongnuoiID);
        sDoituongnuoi = oDoituongnuoi.sTendoituong;
        return sDoituongnuoi;
    }
    
    protected void lbtnExport_Click(object sender, EventArgs e)
    {
        if (export("cosonuoitrong.xls") == true)
        {
            this.grvCosonuoitrong.AllowPaging = true;
            napGridView();
        }
    }
    private bool export(String sFilename)
    {
        bool bSuccessed = true;
        try
        {
            this.grvCosonuoitrong.AllowPaging = false;
            napGridView();
            GridViewExportUtil.Export(sFilename, this.grvCosonuoitrong);
        }
        catch
        {
            bSuccessed = false;
        }
        return bSuccessed;
    }

    protected void lbtnExportAll_Click(object sender, EventArgs e)
    {
        INVI.INVILibrary.INVIHelper.ExportToExcel("CosonuoitrongFull.xls", INVI.INVILibrary.INVIHelper.getAllCosonuoitrong());
    }

    protected void grvCosonuoitrong_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}