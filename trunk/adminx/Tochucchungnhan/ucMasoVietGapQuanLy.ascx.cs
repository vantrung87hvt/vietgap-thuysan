using INVI.Entity;
using INVI.Business;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class adminx_ucMasoVietGapQuanLy : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            napDllCosonuoitrong();
            napGridView();
        }
    }
    private void napGridView()
    {
        List<MasovietgapEntity> list = MasovietgapBRL.GetAll();
        grvMasoVietGap.DataSource = MasovietgapEntity.Sort(list, "sMaso", "DESC");
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
    private void napDllCosonuoitrong()
    {
        List<CosonuoitrongEntity> lstCosonuoitrong = CosonuoitrongBRL.GetAll();
        if (lstCosonuoitrong != null && lstCosonuoitrong.Count > 0)
        {
            ddlCosonuoitrong.DataSource = lstCosonuoitrong;
            ddlCosonuoitrong.DataTextField = "sTencoso";
            ddlCosonuoitrong.DataValueField = "PK_iCosonuoitrongID";
            ddlCosonuoitrong.DataBind();
        }
    }
    private void napDllTochuccapphep()
    {
        List<TochucchungnhanEntity> lstTochucchungnhan = TochucchungnhanBRL.GetAll();
        if (lstTochucchungnhan != null && lstTochucchungnhan.Count > 0)
        {
            ddlTochucchungnhan.DataSource = lstTochucchungnhan;
            ddlTochucchungnhan.DataTextField = "sTochucchungnhan";
            ddlTochucchungnhan.DataValueField = "PK_iTochucchungnhanID";
            ddlTochucchungnhan.DataBind();
        }
    }
    protected void grvMasoVietGap_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvMasoVietGap.PageIndex = e.NewPageIndex;
        napGridView();
    }
    protected void grvMasoVietGap_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int iMasoVietGapID = Convert.ToInt32(grvMasoVietGap.DataKeys[e.NewSelectedIndex].Values["PK_iMasoVietGapID"].ToString());
        MasovietgapEntity oMasoVietGap = MasovietgapBRL.GetOne(iMasoVietGapID);
        if (oMasoVietGap != null)
        {
            txtMaso.Text = oMasoVietGap.sMaso;
            txtNgaycap.Text = oMasoVietGap.dNgaycap.ToString("dd/MM/yyyy");
            txtNgayhethan.Text = oMasoVietGap.dNgayhethan.ToString("dd/MM/yyyy");
            txtThoihan.Text = oMasoVietGap.iThoihan.ToString();
            CosonuoitrongEntity oCosonuoitrong = CosonuoitrongBRL.GetOne(oMasoVietGap.FK_iCosonuoitrongID);
            txtDiachi.Text = oCosonuoitrong.sAp + ", " + oCosonuoitrong.sXa +", "+ QuanHuyenBRL.GetOne(oCosonuoitrong.FK_iQuanHuyenID).sTen + ", " + TinhBRL.GetOne(QuanHuyenBRL.GetOne(oCosonuoitrong.FK_iQuanHuyenID).FK_iTinhThanhID).sTentinh ;
            pnlEdit.Visible = true;
            if (Convert.ToInt16(Session["GroupID"].ToString()) == 4)
            {
                ddlTochucchungnhan.Visible = false;
                txtTochucchungnhan.Text = TochucchungnhanBRL.GetOne(oMasoVietGap.FK_iTochucchungnhanID).sTochucchungnhan;
                txtTochucchungnhan.Visible = true;
            }
            else if (Convert.ToInt16(Session["GroupID"].ToString()) == 1)
            {
                ddlTochucchungnhan.Visible = true;
                napDllTochuccapphep();
                if (ddlTochucchungnhan.Items.Count > 0)
                    ddlTochucchungnhan.SelectedValue = oMasoVietGap.FK_iTochucchungnhanID.ToString();
                txtTochucchungnhan.Text = "";
                txtTochucchungnhan.Visible = false;
            }
            if (ddlCosonuoitrong.Items.Count > 0)
                ddlCosonuoitrong.SelectedValue = oMasoVietGap.FK_iCosonuoitrongID.ToString();
            btnOk.CommandArgument = oMasoVietGap.PK_iMasoVietGapID.ToString();
        }
    }
    protected void grvMasoVietGap_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {

    }
    
    protected void lnbCapphep_Click(object sender, EventArgs e)
    {

    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                MasovietgapEntity oMasoVietGap = MasovietgapBRL.GetOne(Convert.ToInt32(btnOk.CommandArgument));
                // Check lại, vì chỉ thể sửa đổi thời hạn, chứ không thể sửa đổi được tổ chức cấp phép --> cơ sở nuôi trồng.
                // Có chăng thì sẽ thêm mới 1 bản ghi vào --> lằng nhằng quá...
                if (oMasoVietGap != null)
                {
                    oMasoVietGap.iThoihan = Convert.ToByte(txtThoihan.Text);
                    oMasoVietGap.FK_iCosonuoitrongID = Convert.ToInt32(ddlCosonuoitrong.SelectedValue);
                    if (Convert.ToInt16(Session["GroupID"].ToString()) == 1)
                        oMasoVietGap.FK_iTochucchungnhanID = Convert.ToInt32(ddlTochucchungnhan.SelectedValue);
                    oMasoVietGap.dNgaycap = DateTime.ParseExact(txtNgaycap.Text, "dd/MM/yyyy", null);
                    oMasoVietGap.dNgayhethan = DateTime.ParseExact(txtNgayhethan.Text, "dd/MM/yyyy", null);
                    MasovietgapBRL.Edit(oMasoVietGap);
                    Response.Write("<script language=\"javascript\">alert('Cập nhập thành công');location='Default.aspx?page=MasoVietGapQuanLy';</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=MasoVietGapQuanLy';</script>");
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        pnlEdit.Visible = false;
    }
}