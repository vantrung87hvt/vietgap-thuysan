using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.Business;
using INVI.INVILibrary;
using System.Configuration;
public partial class adminx_ucGiahanGiayphepVietGap : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            //napTinh();
            //txtNgaygiahan_datepicker.Value = DateTime.Now.ToString("dd/MM/yyyy");
            ////txtThoihan.Attributes.Add("onblur","return validate(this.value)");
            //txtThoigiangiahan.Attributes.Add("onKeyUp", "javascript:addMonth();");
            //LoadQuanHuyen(Convert.ToInt32(ddlTinh.SelectedValue));
            //napCosonuoi(Convert.ToInt32(ddlQuanHuyen.SelectedValue));
            napGridView();
        }
    }
    private void napGridView()
    {
        List<long> lstCosonuoitrongID = new List<long>();
        List<MasovietgapEntity> lstMasoVietGap = MasovietgapBRL.GetAll();
        foreach (MasovietgapEntity oMasoVietGap in lstMasoVietGap)
            if (!lstCosonuoitrongID.Contains(oMasoVietGap.FK_iCosonuoitrongID))
                lstCosonuoitrongID.Add(oMasoVietGap.FK_iCosonuoitrongID);
        lstMasoVietGap = new List<MasovietgapEntity>();
        foreach (long lCosonuoitrongID in lstCosonuoitrongID)
        {
            List<MasovietgapEntity> lstTemp = MasovietgapBRL.GetByFK_iCosonuoitrongID(lCosonuoitrongID);
            //Sắp xếp theo thời gian để lấy ra ông gần nhất
            MasovietgapEntity.Sort(lstTemp, "dNgayhethan", "DESC");
            if (DateTime.Now.AddMonths(1) >= lstTemp[0].dNgayhethan)
                lstMasoVietGap.Add(lstTemp[0]);
        }
        
        grvMasoVietGap.DataSource = MasovietgapEntity.Sort(lstMasoVietGap, "sMaso", "DESC");
        grvMasoVietGap.DataKeyNames = new string[] { "PK_iMasoVietGapID" };
        grvMasoVietGap.DataBind();
    }
    protected void grvMasoVietGap_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblTochuc = null, lblCoso = null;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            lblCoso = (Label)e.Row.FindControl("lblCoso");
            lblTochuc = (Label)e.Row.FindControl("lblTochuc");
        }
        if (lblCoso != null)
        {
            int iCosoID = int.Parse(lblCoso.Text);
            lblCoso.Text = CosonuoitrongBRL.GetOne(iCosoID).sTencoso;
        }
        if (lblTochuc != null)
        {
            int iTochucID = byte.Parse(lblTochuc.Text);
            lblTochuc.Text = TochucchungnhanBRL.GetOne(iTochucID).sTochucchungnhan;
        }
    }
    //protected void napTinh()
    //{
    //    ddlTinh.Items.Clear();
    //    List<TinhEntity> lstTinh = TinhBRL.GetAll();
    //    ddlTinh.DataSource = lstTinh;
    //    ddlTinh.DataTextField = "sTentinh";
    //    ddlTinh.DataValueField = "PK_iTinhID";
    //    ddlTinh.DataBind();
    //    if (ddlTinh.Items.Count > 0)
    //        ddlTinh.SelectedIndex = 0;
    //}
    //private void LoadQuanHuyen(int fk_Tinh)
    //{
    //    ddlQuanHuyen.Items.Clear();
    //    List<QuanHuyenEntity> lst = QuanHuyenBRL.GetByFK_iTinhThanhID(Convert.ToInt16(fk_Tinh));
    //    ddlQuanHuyen.DataSource = lst;
    //    ddlQuanHuyen.DataTextField = "sTen";
    //    ddlQuanHuyen.DataValueField = "PK_iQuanHuyenID";

    //    ddlQuanHuyen.DataBind();
    //    if(ddlQuanHuyen.Items.Count>0)
    //        ddlQuanHuyen.SelectedIndex = 0;
    //}
    //private void napCosonuoi(int FK_iHuyenID)
    //{
    //    List<CosonuoitrongEntity> lstCosonuoi = CosonuoitrongBRL.GetByFK_iQuanHuyenID(FK_iHuyenID);
    //    List<CosonuoitrongEntity> lstCosonuoiTheoHuyenDaDuocCapMaso = new List<CosonuoitrongEntity>();
    //    List<TochucchungnhanEntity> lstTochucchungnhan = TochucchungnhanBRL.GetByFK_iUserID(Convert.ToInt32(Session["UserID"].ToString()));
    //    if (lstTochucchungnhan.Count > 0)
    //    {
    //        List<MasovietgapEntity> lstMasoVietGap = MasovietgapBRL.GetByFK_iTochucchungnhanID(lstTochucchungnhan[0].PK_iTochucchungnhanID);
    //        foreach (CosonuoitrongEntity oCosonuoitrong in lstCosonuoi)
    //        {
    //            for (int i = 0; i < lstMasoVietGap.Count; i++)
    //                if (CosonuoitrongBRL.GetOne(lstMasoVietGap[i].FK_iCosonuoitrongID).PK_iCosonuoitrongID == oCosonuoitrong.PK_iCosonuoitrongID)
    //                    if (!lstCosonuoiTheoHuyenDaDuocCapMaso.Contains(oCosonuoitrong))
    //                        lstCosonuoiTheoHuyenDaDuocCapMaso.Add(oCosonuoitrong);
    //        }
    //    }
    //    ddlCosonuoi.DataSource = lstCosonuoiTheoHuyenDaDuocCapMaso;
    //    ddlCosonuoi.DataTextField = "sTencoso";
    //    ddlCosonuoi.DataValueField = "PK_iCosonuoitrongID";
    //    ddlCosonuoi.DataBind();
    //    if (ddlCosonuoi.Items.Count > 0)
    //        ddlCosonuoi.SelectedIndex = 0;
    //    lstCosonuoiTheoHuyenDaDuocCapMaso.Clear();
    //}
    //protected void ddlTinh_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    LoadQuanHuyen(Convert.ToInt32(ddlTinh.SelectedValue));
    //}
    //protected void ddlQuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    napCosonuoi(Convert.ToInt32(ddlQuanHuyen.SelectedValue));
    //}
    //protected void ddlCosonuoi_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    List<MasovietgapEntity> lstMasoVietGap = MasovietgapBRL.GetByFK_iCosonuoitrongID(Convert.ToInt32(ddlCosonuoi.SelectedValue));
    //    if (lstMasoVietGap.Count > 0)
    //    {
    //        txtMaso.Text = lstMasoVietGap[0].sMaso;
    //        btnOK.CommandArgument = lstMasoVietGap[0].PK_iMasoVietGapID.ToString();
    //    }
    //    else
    //        txtMaso.Text = "";
    //}
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                MasovietgapEntity oMasoVietgap = MasovietgapBRL.GetOne(Convert.ToInt32(btnOK.CommandArgument));
                oMasoVietgap.dNgaycap = DateTime.ParseExact(txtNgaygiahan_datepicker.Value, "dd/MM/yyyy", null);
                oMasoVietgap.dNgayhethan = DateTime.ParseExact(txtNgaygiahan_datepicker.Value, "dd/MM/yyyy", null).AddMonths(Convert.ToByte(txtThoigiangiahan.Text));
                //oMasoVietgap.FK_iCosonuoitrongID = oMasoVietgap.FK_iCosonuoitrongID;
                oMasoVietgap.FK_iTochucchungnhanID = oMasoVietgap.FK_iTochucchungnhanID;
                oMasoVietgap.iThoihan = Convert.ToByte(txtThoigiangiahan.Text);
                oMasoVietgap.sMaso = txtMaso.Text;
                oMasoVietgap.iSanluongdukienmoi = Convert.ToInt32(txtSanLuongMoi.Text);
                oMasoVietgap.fDientichmorong = Convert.ToInt32(txtDienTichMoi.Text);
                MasovietgapBRL.Add(oMasoVietgap);
                // Không được gia hạn quá 4 tháng
                Response.Write("<script language='javascript'>alert('Gia hạn thành công');location='Default.aspx';</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=GiahanGiayphepVietGap';</script>");
            }
        }
       
    }
    protected void grvMasoVietGap_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvMasoVietGap.PageIndex = e.NewPageIndex;
        grvMasoVietGap.DataBind();
    }
    
    protected void grvMasoVietGap_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        
        int PK_iMasoVietGapID = Convert.ToInt32(grvMasoVietGap.DataKeys[e.NewSelectedIndex].Values["PK_iMasoVietGapID"].ToString());
        MasovietgapEntity oMasovietgap = MasovietgapBRL.GetOne(PK_iMasoVietGapID);
        List<MasovietgapEntity> lstMasoVietGap = MasovietgapBRL.GetByFK_iCosonuoitrongID(oMasovietgap.FK_iCosonuoitrongID);
        if (lstMasoVietGap.Count >= 2)
        {
            MasovietgapEntity.Sort(lstMasoVietGap, "dNgayhethan", "DESC");
            if (lstMasoVietGap[0].dNgayhethan.Year == DateTime.Now.Year)
                Response.Write("<script language=\"javascript\">alert('Cơ sơ nuôi trồng này đã được gia hạn một lần trong năm.');location='Default.aspx?page=GiahanGiayphepVietGap';</script>");
        }
        //if(MasovietgapBRL.GetByFK_iCosonuoitrongID(oMasovietgap.FK_iCosonuoitrongID).Count>=2)
        // Cần check nếu số bản ghi trong MasoVietgap >=2, kiểm tra xem năm của lần gần nhất = hiện tại thì không cho phép gia hạn nữa.
        if (oMasovietgap != null)
        {
            txtMaso.Text = oMasovietgap.sMaso;
            btnOK.CommandArgument = PK_iMasoVietGapID.ToString();
            txtThoigiangiahan.Text = "4";
            
            txtThoigiangiahan.Enabled = false;
            txtNgaygiahan_datepicker.Value = DateTime.Today.ToString("dd/MM/yyyy");
            lblNgayhethan.Text = DateTime.ParseExact(txtNgaygiahan_datepicker.Value, "dd/MM/yyyy", null).AddMonths(Convert.ToByte(txtThoigiangiahan.Text)).ToString("dd/MM/yyyy");
        }
        pnlGiahan.Visible = true;
    }
    protected void grvMasoVietGap_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
}