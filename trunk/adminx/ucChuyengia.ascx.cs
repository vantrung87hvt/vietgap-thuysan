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
using Aspose.Words;
using Aspose.Words.Drawing;
public partial class adminx_Tochucchungnhan_ucChuyengia : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!PermissionBRL.CheckPermission("ManagerGroup")) Response.End();
        if (!IsPostBack)
        {
            napDdlTochucchungnhan();
            napDdlTrinhdo();
            napCblGiaychungnhan();
            this.napGridView();
            lblCoquanchidinh.Text = "TỔNG CỤC THỦY SẢN";
            lblLinhvucdanhgia.Text = "Thủy sản";
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
            btnCapmaso.Visible = oChuyengia.sMaso.Length>0?true:false;
            if (oChuyengia.bDuyet)
            {
                ddlDuyet.Items[0].Selected = true;
            }
            else
            {
                ddlDuyet.Items[1].Selected = true;
            }
            if(Convert.ToInt16(Session["GroupID"].ToString())==4)
                imgAnhthe.ImageUrl = "../ViewImage.aspx?ID=" + oChuyengia.PK_iChuyengiaID + "&type=Chuyengia";
            else if (Convert.ToInt16(Session["GroupID"].ToString()) == 1)
                imgAnhthe.ImageUrl = "ViewImage.aspx?ID=" + oChuyengia.PK_iChuyengiaID + "&type=Chuyengia";
            ddlTrinhdo.SelectedItem.Selected = false;
            lblNamsinh.Text = oChuyengia.iNamsinh.ToString();
            if (oChuyengia.FK_iTrinhdoID != null)
            {
                ddlTrinhdo.Items.FindByValue(oChuyengia.FK_iTrinhdoID.ToString()).Selected = true;
            }

            //ddlTrinhdo.SelectedValue = oChuyengia.FK_iTrinhdoID.ToString();
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
                oChuyengia.iNamsinh = Convert.ToInt16(txtNamsinh.Text);
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
        if(btnOK.CommandName.ToUpper()=="EDIT")
            napForm(Convert.ToInt16(btnOK.CommandArgument));
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
        ddlDuyet.SelectedItem.Selected = false;
        ddlTochucchungnhan.SelectedItem.Selected = false;
        ddlTrinhdo.SelectedItem.Selected = false;
        btnOK.Text = "Lưu";
        btnOK.CommandName = "ADDNEW";
        pnlEdit.Visible = true;
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
    protected void btnCapmaso_Click(object sender, EventArgs e)
    {
        String sMaso = "CGĐG-VietGAP-TS";
        int iSochuyengia=0;
        try
        {
            //Lấy danh sách các Chuyên gia đã được cấp phép
            List<ChuyengiaEntity> lstChuyengiadaduoccapphep = ChuyengiaBRL.GetAll().FindAll(delegate(ChuyengiaEntity oChuyengia)
            {
                return oChuyengia.sMaso.Length > 0;
            });
            //Sắp xếp danh sách theo chiều giảm dần của mã số VietGAP
            if (lstChuyengiadaduoccapphep.Count > 0)
            {
                ChuyengiaEntity.Sort(lstChuyengiadaduoccapphep, "sMaso", "DESC");
                String sMasomoinhat = lstChuyengiadaduoccapphep[0].sMaso;
                iSochuyengia = Convert.ToInt16(sMasomoinhat.Substring(sMasomoinhat.LastIndexOf(' '), sMasomoinhat.Length - 1 - sMasomoinhat.LastIndexOf(' ')));
                sMaso +=" "+taoDinhdangMaso(iSochuyengia + 1);
            }
            else
            {
                iSochuyengia = 1;
                sMaso += " "+taoDinhdangMaso(iSochuyengia);
            }
            int PK_iChuyengiaID = Convert.ToInt32(btnOK.CommandArgument);
            ChuyengiaEntity oChuyengiacancapmaso = ChuyengiaBRL.GetOne(PK_iChuyengiaID);
            oChuyengiacancapmaso.sMaso = sMaso;
            ChuyengiaBRL.Edit(oChuyengiacancapmaso);
            Response.Write("<script language=\"javascript\">alert('Chuyên gia đã được cấp mã số:" + sMaso + ".');></script>");
        }
        catch (Exception ex)
        {
            Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=Chuyengia';</script>");
        }
    }
    private String taoDinhdangMaso(int iSochuyengia)
    {
        String sMacoso = String.Empty;
        if (iSochuyengia > 100)
            sMacoso = "0" + (iSochuyengia);
        else if (iSochuyengia > 10)
            sMacoso = "00" + (iSochuyengia);
        else if (iSochuyengia > 0)
            sMacoso = "000" + (iSochuyengia);
        return sMacoso;
    }
    protected void grvChuyengia_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Thechuyengia")
        {
            LinkButton lbtnThechuyengia = (LinkButton)e.CommandSource;
            Int16 PK_iChuyengiaID = Int16.Parse(lbtnThechuyengia.CommandArgument);
            napThongtinthechuyengia(PK_iChuyengiaID);
        }
    }

    private void napThongtinthechuyengia(Int16 _PK_iChuyengiaID)
    {
        ChuyengiaEntity oChuyengia = ChuyengiaBRL.GetOne(_PK_iChuyengiaID);
        TochucchungnhanEntity oTochuc = TochucchungnhanBRL.GetOne(oChuyengia.FK_iTochucchungnhanID);
        lblCoquanchidinh.Text = "Tổng Cục Thủy Sản";
        lblHoten.Text = oChuyengia.sHoten;
        lblNamsinhThe.Text = oChuyengia.iNamsinh.ToString();
        lblDonnvicongtac.Text = oTochuc.sTochucchungnhan;
        lblLinhvucdanhgia.Text = "Thủy sản"; //Thiếu lĩnh vực đánh giá
        lblMasochuyengia.Text = oChuyengia.sMaso;
        lblTenthutruong.Text = "";
        String sUrlViewImage = ResolveUrl("~/adminx/ViewImage.aspx");
        imgAnhtheChuyengia.ImageUrl = sUrlViewImage + "?ID=" + oChuyengia.PK_iChuyengiaID + "&type=Chuyengia";
        //Gán ID chuyên gia cho nút ExportToWord
        btnExportToWord.CommandArgument = _PK_iChuyengiaID.ToString();
        pnThechuyengia.Visible = true;
        //Disponse
        oChuyengia = null;
        oTochuc = null;
    }
    protected void btnExportToWord_Click(object sender, EventArgs e)
    {
        Int16 PK_iChuyengiaID = Int16.Parse(btnExportToWord.CommandArgument);
        ChuyengiaEntity oChuyengia = ChuyengiaBRL.GetOne(PK_iChuyengiaID);
        TochucchungnhanEntity oTochuc = TochucchungnhanBRL.GetOne(oChuyengia.FK_iTochucchungnhanID);
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);
        NodeCollection tables = doc.GetChildNodes(NodeType.Table, true);

        builder.PageSetup.Orientation = Aspose.Words.Orientation.Portrait;
        builder.PageSetup.VerticalAlignment = PageVerticalAlignment.Top;

        builder.Font.Size = 12;
        //------------------------------
        builder.StartTable(); //Tạo bảng
        builder.RowFormat.AllowAutoFit = false;
        builder.CellFormat.Width = 200;
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
        builder.InsertCell(); //Ô trái
        builder.Font.Bold = true;
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
        builder.Writeln("BỘ NÔNG NGHIỆP VÀ PTNT");
        builder.Writeln(oTochuc.sCoquancap);
        builder.RowFormat.AllowAutoFit = false;
        builder.CellFormat.Width = 250;
        builder.InsertCell(); //Ô phải
        builder.Font.Bold = false;
        builder.Writeln("CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM");
        builder.Writeln("Độc lập - Tự do- Hạnh phúc");
        builder.InsertHtml("<hr width='40%' />");
        builder.EndRow(); //Kết thúc hàng
        //-------------------------------
        builder.RowFormat.AllowAutoFit = false;
        builder.CellFormat.Width = 410;
        builder.InsertCell();
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
        builder.InsertImage(oChuyengia.imAnh, 100.0, 134.0);
        builder.EndRow();
        //-------------------------------
        builder.RowFormat.AllowAutoFit = false;
        builder.CellFormat.Width = 500;
        builder.InsertCell();
        builder.Font.Bold = true;
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
        builder.Writeln("THẺ CHUYÊN GIA ĐÁNH GIÁ VietGAP");
        builder.EndRow();
        //-------------------------------
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
        builder.RowFormat.AllowAutoFit = false;
        builder.CellFormat.Width = 500;
        builder.InsertCell();
        builder.Font.Bold = false;
        builder.ParagraphFormat.LineSpacing = 10.0;
        builder.Writeln("\t\tHọ và tên: " + oChuyengia.sHoten);
        builder.Writeln("\t\tNăm sinh: " + "");
        builder.Writeln("\t\tĐơn vị công tác: " + oTochuc.sTochucchungnhan);
        builder.Writeln("\t\tLĩnh vực đánh giá: " + "");
        builder.Write("\t\tMã số: ");
        builder.Font.Bold = true;
        builder.Writeln(oChuyengia.sMaso);
        builder.EndRow();
        //------------------------------
        builder.RowFormat.AllowAutoFit = false;
        builder.CellFormat.Width = 220;
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
        builder.InsertCell(); //Ô trái
        builder.RowFormat.AllowAutoFit = false;
        builder.CellFormat.Width = 220;
        builder.InsertCell(); //Ô phải
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
        builder.Writeln("... , ngày ... tháng ... năm 20..");
        builder.Font.Bold = true;
        builder.Writeln("Thủ trưởng đơn vị");
        builder.Font.Bold = false;
        builder.Font.Italic = true;
        builder.Writeln("( Ký tên, đóng dấu)");
        builder.EndRow(); //Kết thúc hàng
        builder.EndTable(); //Kết thúc bảng
        doc.Save("Thechuyengia_" + oChuyengia.sMaso + ".doc", SaveFormat.Doc, SaveType.OpenInBrowser, Response);
        //Disponse
        oChuyengia = null;
        oTochuc = null;
    }
    protected void btnVisiblePannel_Click(object sender, EventArgs e)
    {
        pnThechuyengia.Visible = false;
    }
}
