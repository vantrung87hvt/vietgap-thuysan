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
using INVI.Business;
using INVI.Entity;
public partial class adminx_Tochucchungnhan_ucChuyengia : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (!PermissionBRL.CheckPermission("Quanlychuyengia")) Response.End();
            napDdlTochucchungnhan();
            napDdlTrinhdo();
            napCblGiaychungnhan();
            this.napGridView();
        }
        
    }
    private void napForm(short PK_iChuyengiaID)
    {
        ChuyengiaEntity oChuyengia = ChuyengiaBRL.GetOne(PK_iChuyengiaID);
        
        if (oChuyengia != null)
        {
            napDanhgiaychungnhan(PK_iChuyengiaID);
            txtHoten.Text = oChuyengia.sHoten;
            ddlTochucchungnhan.SelectedItem.Selected = false;
            ddlTochucchungnhan.Items.FindByValue(oChuyengia.FK_iTochucchungnhanID.ToString()).Selected = true;
            txtSonamkinhnghiem.Text = oChuyengia.iNamkinhnghiem.ToString();
            txtMaso.Text = oChuyengia.sMaso;
            txtMaso.Enabled = false;
            if (oChuyengia.bDuyet)
            {
                ddlDuyet.Items[0].Selected = true;
            }
            else
            {
                ddlDuyet.Items[1].Selected = true;
            }
            imgAnhthe.ImageUrl = "../ViewImage.aspx?ID=" + oChuyengia.PK_iChuyengiaID + "&type=Chuyengia";
            
            ddlTrinhdo.SelectedValue = oChuyengia.FK_iTrinhdoID.ToString();
            //napGridView();
        }
    }
    private bool luuChungchi(int PK_iChuyengiaID)
    {
        bool bThanhcong = true;
        try
        {
            List<ChungchiChuyengiaEntity> lstChungchichuyengia = ChungchiChuyengiaBRL.GetByFK_iChuyengiaID(PK_iChuyengiaID);
            GiaytonopkemhosoEntity oGiaytoNopkem = null;
            foreach (ListItem chk in cblGiaychungnhan.Items)
            {
                ChungchiChuyengiaEntity oChungchichuyengia = null;
                oChungchichuyengia = lstChungchichuyengia.Find(
                    delegate(ChungchiChuyengiaEntity oChungchichuyengiadaco)
                    {
                        return oChungchichuyengiadaco.FK_iChungchiID.ToString().Equals(chk.Value);
                    }
                    );
                if (oGiaytoNopkem == null)
                {
                    if (chk.Selected)
                    {
                        ChungchiChuyengiaEntity oChungchichuyengiaMoi = new ChungchiChuyengiaEntity();
                        oChungchichuyengiaMoi.FK_iChungchiID = int.Parse(chk.Value);
                        oChungchichuyengiaMoi.FK_iChuyengiaID = PK_iChuyengiaID;
                        ChungchiChuyengiaBRL.Add(oChungchichuyengiaMoi);
                    }
                }
                else
                {
                    if (!chk.Selected)
                    {
                        ChungchiChuyengiaBRL.Remove(oChungchichuyengia.PK_iChungchiChuyengiaID);
                    }
                    lstChungchichuyengia.Remove(oChungchichuyengia); //Loại bỏ phần tử đã tìm thấy để tối ưu
                }
            }
            lstChungchichuyengia = null;
            napDanhgiaychungnhan(PK_iChuyengiaID);
            lblThongbao.Text = "Lưu thành công!";
        }
        catch (Exception ex)
        {
        }
        return bThanhcong;
    }
    private void napDanhgiaychungnhan(int PK_iChuyengiaID)
    {
        List<ChungchiChuyengiaEntity> lstChungchichuyengia = ChungchiChuyengiaBRL.GetByFK_iChuyengiaID(PK_iChuyengiaID);
        ChungchiChuyengiaEntity oChungchichuyengia = null;
        if (lstChungchichuyengia != null && lstChungchichuyengia.Count > 0)
        {
            foreach (ListItem chk in cblGiaychungnhan.Items)
            {
                oChungchichuyengia = null;
                oChungchichuyengia = lstChungchichuyengia.Find(
                    delegate(ChungchiChuyengiaEntity oChungchichuyengiaDaco)
                    {
                        return oChungchichuyengiaDaco.FK_iChungchiID.ToString().Equals(chk.Value);
                    }
                    );
                if (oChungchichuyengia != null)
                {
                    chk.Selected = true;
                }
            }
        }
        lstChungchichuyengia = null;
    }
    public void napCblGiaychungnhan()
    {
        List<ChungchiEntity> lstChungchi = ChungchiBRL.GetAll();
        cblGiaychungnhan.DataSource = lstChungchi;
        cblGiaychungnhan.DataTextField = "sTenchungchi";
        cblGiaychungnhan.DataValueField = "PK_iChungchiID";
        cblGiaychungnhan.DataBind();
        
        
    }
    private void napDdlTochucchungnhan()
    {
        ddlTochucchungnhan.DataSource = TochucchungnhanBRL.GetAll();
        ddlTochucchungnhan.DataTextField = "sTochucchungnhan";
        ddlTochucchungnhan.DataValueField = "PK_iTochucchungnhanID";
        ddlTochucchungnhan.DataBind();
        ddlTochucchungnhan.Enabled = false;
    }

    private void napDdlTrinhdo()
    {
        ddlTrinhdo.DataSource = TrinhdoChuyengiaBRL.GetAll();
        ddlTrinhdo.DataTextField = "sTrinhdo";
        ddlTrinhdo.DataValueField = "PK_iTrinhdochuyengiaID";
        ddlTrinhdo.DataBind();
    }

    private void napGridView()
    {
        grvChuyengia.DataSource = ChuyengiaBRL.GetAll();
        grvChuyengia.DataKeyNames = new string[] { "PK_iChuyengiaID" };
        grvChuyengia.DataBind();
    }
    protected void grvPosition_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<ChuyengiaEntity> list = ChuyengiaBRL.GetAll();
        grvChuyengia.DataSource = ChuyengiaEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
        grvChuyengia.DataBind();
    }
    protected void grvPosition_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        short PK_iChuyengiaID = Convert.ToInt16(grvChuyengia.DataKeys[e.NewSelectedIndex].Values["PK_iChuyengiaID"]);
        btnOK.CommandName = "EDIT";
        btnOK.Text = "Sửa";
        pnlEdit.Visible = true;
        btnOK.CommandArgument = PK_iChuyengiaID.ToString();
        napForm(PK_iChuyengiaID);
    }
  
    protected void btnOK_Click(object sender, EventArgs e)
    {
        //Page.Validate("vgChuyengia");
        //if (Page.IsValid)
        //{
            try
            {
                Int32 PK_iChuyengiaID;
                
                ChuyengiaEntity oChuyengia = new ChuyengiaEntity();
                oChuyengia.sHoten = txtHoten.Text;
                oChuyengia.FK_iTochucchungnhanID = int.Parse(ddlTochucchungnhan.SelectedValue);
                oChuyengia.iNamkinhnghiem = short.Parse(txtSonamkinhnghiem.Text);
                oChuyengia.sMaso = txtMaso.Text;
                oChuyengia.FK_iTrinhdoID = short.Parse(ddlTrinhdo.SelectedValue);
                if (ddlDuyet.SelectedValue.Equals("1"))
                {
                    oChuyengia.bDuyet = true;
                }
                else
                {
                    oChuyengia.bDuyet = false;
                }
                byte[] bytImage = null;
                // xu ly anh
                if (fAnhthe.PostedFile != null)
                {
                    if (fAnhthe.PostedFile.ContentLength > 0)
                    {
                        string strEx = "jpg|jpeg|bmp|png|gif";
                        string fileEx = fAnhthe.FileName.Substring(fAnhthe.FileName.LastIndexOf('.')).Remove(0, 1);
                        string[] arrEx = strEx.Split('|');
                        bool valid = false;
                        foreach (string ex in arrEx)
                        {
                            if (ex.Equals(fileEx, StringComparison.OrdinalIgnoreCase))
                                valid = true;
                        }
                        if (valid)
                        {

                            HttpPostedFile objHttpPostedFile = fAnhthe.PostedFile;
                            int intContentlength = objHttpPostedFile.ContentLength;
                            bytImage = new Byte[intContentlength];
                            objHttpPostedFile.InputStream.Read(bytImage, 0, intContentlength);
                            oChuyengia.imAnh = bytImage;
                        }
                    }
                }
                else
                {
                    
                }

                if (btnOK.CommandName.ToUpper() == "EDIT")
                {
                    PK_iChuyengiaID = Convert.ToInt32(btnOK.CommandArgument);
                    ChuyengiaEntity oChuyengiaOld = ChuyengiaBRL.GetOne(PK_iChuyengiaID);
                    oChuyengia.imAnh = oChuyengiaOld.imAnh;
                    oChuyengia.iTrangthai = oChuyengiaOld.iTrangthai;
                    oChuyengia.PK_iChuyengiaID = PK_iChuyengiaID;
                    luuChungchi(PK_iChuyengiaID);
                    ChuyengiaBRL.Edit(oChuyengia);
                    lblThongbao.Text = "Cập nhật thành công";
                }
                else if(btnOK.CommandName.ToUpper()=="ADDNEW")
                {
                    
                    PK_iChuyengiaID = ChuyengiaBRL.Add(oChuyengia);

                    // Lưu chứng chỉ của chuyên gia
                    foreach (ListItem chk in cblGiaychungnhan.Items)
                    {
                        if (chk.Selected == true)
                        {
                            int PK_iChungchiID = Convert.ToInt32(chk.Value);
                            ChungchiChuyengiaEntity oChungchichuyengiaMoi = new ChungchiChuyengiaEntity();
                            oChungchichuyengiaMoi.FK_iChungchiID = int.Parse(chk.Value);
                            oChungchichuyengiaMoi.FK_iChuyengiaID = PK_iChuyengiaID;
                            ChungchiChuyengiaBRL.Add(oChungchichuyengiaMoi);
                        }
                    }
                    lblThongbao.Text = "Thêm thành công";
                }
                napGridView();
            }
            catch (Exception ex)
            {
                //lblThongbao.Text = ex.Message;
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=Chuyengia';</script>");
            }
            pnlEdit.Visible = false;
        //}
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (btnOK.CommandName.ToUpper() == "EDIT")
            pnlEdit.Visible = false;
    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{
            try
            {
                foreach (GridViewRow row in grvChuyengia.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    short PK_iChuyengiaID = Convert.ToInt16(grvChuyengia.DataKeys[row.RowIndex].Values["PK_iChuyengiaID"]);
                    if (chkDelete != null && chkDelete.Checked)
                    {
                        ChuyengiaBRL.Remove(PK_iChuyengiaID);
                    }
                }
                //Nap lai du lieu
                Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=Chuyengia';</script>");
            }
        //}

    }
    protected void lbtnAddnew_Click(object sender, EventArgs e)
    {
        txtHoten.Text = "";
        txtMaso.Text = "";
        txtSonamkinhnghiem.Text = "";
        //ddlDuyet.SelectedItem.Selected = false;
        //ddlTochucchungnhan.SelectedItem.Selected = false;
        //ddlTrinhdo.SelectedItem.Selected = false;
        btnOK.Text = "Lưu";
        btnOK.CommandName = "ADDNEW";
        pnlEdit.Visible = true;
        foreach (ListItem chk in cblGiaychungnhan.Items)
            chk.Selected = false;
    }
    protected void grvChuyengia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblTochucchungnhan = null, lblTrinhdo = null;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            lblTochucchungnhan = (Label)e.Row.FindControl("lblTochucchungnhan");
            lblTrinhdo = (Label)e.Row.FindControl("lblTrinhdo");
            if (lblTochucchungnhan != null)
            {
                int PK_iTochucchungnhanID = int.Parse(lblTochucchungnhan.Text);
                lblTochucchungnhan.Text = TochucchungnhanBRL.GetOne(PK_iTochucchungnhanID).sTochucchungnhan;
            }
            if (lblTrinhdo != null)
            {
                Int16 FK_iTrinhdoID = byte.Parse(lblTrinhdo.Text);
                if (FK_iTrinhdoID == 0) lblTrinhdo.Text = "";
                else
                    lblTrinhdo.Text = TrinhdoChuyengiaBRL.GetOne(FK_iTrinhdoID).sTrinhdo;
            }
        }
    }
}
