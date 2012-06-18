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
using Aspose.Words;

public partial class adminx_ucTochuccapphepDanhgia : System.Web.UI.UserControl
{
    int PK_iTochucchungnhanID = 7;
    int PK_iDanhgiatochucID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
      
                if (Session["PK_iTochucchungnhanID"] != null)
                {
                    PK_iTochucchungnhanID = Convert.ToInt32(Session["PK_iTochucchungnhanID"].ToString());
                    NapThongtin(PK_iTochucchungnhanID);
                }
                //NapThongtinTochuc();
                //NapLstDoandanhgia();
       
    }

    public int getThongtindanhgia(int iTochucchungnhanID)
    {
        List<DanhgiatochucchungnhanEntity> lstDanhgiatochuc = DanhgiatochucchungnhanBRL.GetByFK_iTochucchungnhanID(PK_iTochucchungnhanID);
        int PK_iDanhgiatochucID=0;
        if (lstDanhgiatochuc.Count > 0)
            PK_iDanhgiatochucID = lstDanhgiatochuc[0].PK_iDanhgiatochucchungnhanID;
        return PK_iDanhgiatochucID;
    }

    public void NapThongtin(int iTochucchungnhanID)
    {
        TochucchungnhanEntity oTochuc = TochucchungnhanBRL.GetOne(iTochucchungnhanID);
        lblTentochuc.Text = oTochuc.sTochucchungnhan;
        lblDiachi.Text = oTochuc.sDiachi;
        lblSodienthoai.Text = oTochuc.sSodienthoai;
        lblFax.Text = oTochuc.sFax;
        lblEmail.Text = oTochuc.sSodienthoai;
        int PK_iDanhgiatochucID = getThongtindanhgia(iTochucchungnhanID);
        //--------- nạp dữ liệu đánh giá nếu đã tồn tại
        if (PK_iDanhgiatochucID > 0)
        {
            NapLstDoandanhgia(iTochucchungnhanID);
            DanhgiatochucchungnhanEntity oDanhgia = DanhgiatochucchungnhanBRL.GetOne(PK_iDanhgiatochucID);
            txtPhamvideghi.InnerText = oDanhgia.sPhamvinghidinh;
            txtCancudanhgia.InnerText = oDanhgia.sCancudanhgia;
            txtNoidungdanhgia.InnerText = oDanhgia.sNoidungdanhgia;
            txtKetquadanhgia.InnerText = oDanhgia.sKetquadanhgia;
            ddlKetluan.Items.FindByValue(oDanhgia.iKetquadanhgia.ToString()).Selected = true;
            btnExportToWord.Enabled = true;
        }
        NapLstDoandanhgia(iTochucchungnhanID);
        NapThongtinDoandanhgia();
    }

    public void NapThongtinDoandanhgia()
    {
        String sDoan = "<ul style='list-style-type:decimal;'>";
        ddlTruongdoan.Items.Clear();
        int _count = lstDoandanhgiachon.Items.Count;
        if (_count != 0)
         {
             for (int i = 0; i < _count; i++)
             {
                 ListItem item = new ListItem();
                 item.Text = lstDoandanhgiachon.Items[i].Text;
                 item.Value = lstDoandanhgiachon.Items[i].Value;
                 ddlTruongdoan.Items.Add(item);
                 sDoan += "<li>" + lstDoandanhgiachon.Items[i].Text + "</li>";
             }
          }
        sDoan += "</ul>";
        lblCacthanhvien.Text = sDoan;
    }

    public void NapLstDoandanhgia(int iTochuchungnhanID)
    {
        //Nếu chưa tồn tại báo  cáo đánh giá --> thêm vào danh sách đoàn đánh giá tất cả các đánh giá viên
        List<DanhgiavienEntity> lstDanhgiavien = new List<DanhgiavienEntity>();
        
            lstDanhgiavien = DanhgiavienBRL.GetByFK_iTochucchungnhanID(iTochuchungnhanID);
            lstDoandanhgia.DataSource = lstDanhgiavien;
            lstDoandanhgia.DataTextField = "sHoten";
            lstDoandanhgia.DataValueField = "PK_iDanhgiavienID";
            lstDoandanhgia.DataBind();
        //else //Nếu đã tồn tại --> chỉ thêm những đánh giá viên chưa chọn
        //{
        //    List<DoandanhgiatochucchungnhanEntity> lstDoandanhgiaE = DoandanhgiatochucchungnhanBRL.GetByFK_iDanhgiatochucchungnhanID(PK_iDanhgiatochucID);
        //    List<DanhgiavienEntity> lstDanhgiavien = DanhgiavienBRL.GetAll();
        //    List<DanhgiavienEntity> lstDanhgiavienchuachon = new List<DanhgiavienEntity>();
        //    List<DanhgiavienEntity> lstDanhgiaviendachon = new List<DanhgiavienEntity>();
        //    //Thêm vào danh sách 
        //    for (int i = 0; i < lstDanhgiavien.Count; ++i)
        //    {
        //        for (int j = 0; j < lstDoandanhgiaE.Count; ++j)
        //        {
        //            if (lstDanhgiavien[i].PK_iDanhgiavienID != lstDoandanhgiaE[j].FK_iDanhgiavienID)
        //            {
        //                lstDanhgiavienchuachon.Add(lstDanhgiavien[i]);
        //            }
        //            else
        //            {
        //                lstDanhgiaviendachon.Add(lstDanhgiavien[i]);
        //            }
        //            lstDoandanhgiaE.RemoveAt(j); //Loại khỏi danh sách đã chọn để giảm độ phức tạp tìm kiếm
        //        }
        //    }
        //    lstDanhgiavien = null;
            //lstDoandanhgiaE = null;
            //Nạp dữ liệu cho các list
            Session["iSodanhgiavien"] = lstDanhgiavien.Count;
            lstDoandanhgia.DataSource = lstDanhgiavien;
            lstDoandanhgia.DataTextField = "sHoten";
            lstDoandanhgia.DataValueField = "PK_iDanhgiavienID";
            lstDoandanhgia.DataBind();
            //----
            lstDoandanhgiachon.DataSource = lstDanhgiavien;
            lstDoandanhgiachon.DataTextField = "sHoten";
            lstDoandanhgiachon.DataValueField = "PK_iDanhgiavienID";
            lstDoandanhgiachon.DataBind();
        }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                if (lstDoandanhgia.SelectedIndex > -1)
                {

                    string _value = lstDoandanhgia.SelectedItem.Value;

                    string _text = lstDoandanhgia.SelectedItem.Text;

                    ListItem item = new ListItem();

                    item.Text = _text;

                    item.Value = _value;
                    lstDoandanhgiachon.Items.Add(item);

                    lstDoandanhgia.Items.Remove(item);
                    NapThongtinDoandanhgia();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=TochuccapphepDanhgia';</script>");
            }
        }
       
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        if (lstDoandanhgiachon.SelectedIndex > -1)
        {
            
            string _value = lstDoandanhgiachon.SelectedItem.Value;

            string _text = lstDoandanhgiachon.SelectedItem.Text; 

            ListItem item = new ListItem();

            item.Text = _text; 

            item.Value = _value;
            lstDoandanhgiachon.Items.Remove(item);

            lstDoandanhgia.Items.Add(item);
            NapThongtinDoandanhgia();
        }
    }
    protected void btnExportToWord_Click(object sender, EventArgs e)
    {
        TochucchungnhanEntity oTochuc = TochucchungnhanBRL.GetOne(PK_iTochucchungnhanID);
        DanhgiatochucchungnhanEntity oDanhgia = DanhgiatochucchungnhanBRL.GetOne(PK_iDanhgiatochucID);
        DanhgiavienEntity oTruongdoan = DanhgiavienBRL.GetOne(oDanhgia.FK_iTruongdoandanhgiaID);
        List<DoandanhgiatochucchungnhanEntity> lstDoandanhgia = DoandanhgiatochucchungnhanBRL.GetByFK_iDanhgiatochucchungnhanID(PK_iDanhgiatochucID);
        //-----------
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);
        NodeCollection tables = doc.GetChildNodes(NodeType.Table, true);

        builder.PageSetup.PaperSize = PaperSize.A4;

        builder.PageSetup.Orientation = Aspose.Words.Orientation.Portrait;
        builder.PageSetup.VerticalAlignment = PageVerticalAlignment.Top;
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
        builder.Font.Bold = true;
        builder.Font.Italic = false;
        builder.Font.Size = 14;
        builder.Writeln("CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM");
        builder.Writeln("Độc lập - Tự do - Hạnh phúc");
        builder.Writeln("--------------------------");
        builder.Writeln("");
        builder.Font.Bold = false;
        builder.Font.Italic = true;
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Right;
        builder.Writeln("……, ngày ... tháng … năm 20…");
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
        builder.Font.Bold = true;
        builder.Font.Italic = false;
        builder.Writeln("");
        builder.Writeln("BÁO CÁO ĐÁNH GIÁ TỔ CHỨC CHỨNG NHẬN");
        builder.Writeln("");
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
        builder.Writeln("1. Tên tổ chức chứng nhận được đánh giá;");
        builder.Writeln(oTochuc.sTochucchungnhan);
        builder.Writeln("Địa chỉ: " + oTochuc.sDiachi);
        builder.Writeln("Điện thoại: " + oTochuc.sSodienthoai + " Fax: " + oTochuc.sFax + " E-mail: " + oTochuc.sEmail);
        builder.Writeln("2. Phạm vi đề nghị chỉ định: " + oDanhgia.sPhamvinghidinh);
        builder.Writeln("3. Đoàn đánh giá hoặc thành viên đoàn đánh giá: ");
        if (lstDoandanhgia.Count > 0)
        {
            for (int i = 0; i < lstDoandanhgia.Count; ++i)
            {
                builder.Writeln("- " + DanhgiavienBRL.GetOne(lstDoandanhgia[i].FK_iDanhgiavienID).sHoten);
            }
        }
        DateTime dt = DateTime.Parse(oDanhgia.tGiodanhgia.ToString());
        String sGiodanhgia = String.Format("{0:HH/MM/SS}", dt);
        dt = DateTime.Parse(oDanhgia.dNgaydanhgia.ToString());
        String sNgaydanhgia = String.Format("{0:DD/MM/YYYY}", dt);
        builder.Writeln("4. Thời gian đánh giá;" + sGiodanhgia + " ngày " + sNgaydanhgia);
        builder.Writeln("5. Các căn cứ để đánh giá: ");
        builder.Writeln("\t" + oDanhgia.sCancudanhgia);
        builder.Writeln("6. Nội dung đánh giá: ");
        builder.Writeln("\t" + oDanhgia.sNoidungdanhgia);
        builder.Writeln("7. Kết quả đánh giá: ");
        builder.Writeln("\t" + oDanhgia.sKetquadanhgia);
        builder.Writeln("8. Kết luận và kiến nghị của Đoàn đánh giá: " + (oDanhgia.iKetquadanhgia == 1 ? "Đạt" : "Không đạt"));
        //-------Table
        Aspose.Words.Table table = builder.StartTable();
        builder.CellFormat.Width = 260;
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
        builder.InsertCell();
        builder.Font.Bold = true;
        builder.Font.Italic = false;
        builder.Writeln("Các thành viên Đoàn đánh giá");
        builder.Font.Bold = false;
        builder.Writeln("(Ký và ghi rõ họ, tên)");
        if (lstDoandanhgia.Count > 0)
        {
            for (int i = 0; i < lstDoandanhgia.Count; ++i)
            {
                if (lstDoandanhgia[i].FK_iDanhgiavienID != oTruongdoan.PK_iDanhgiavienID)
                {
                    builder.Writeln("- " + DanhgiavienBRL.GetOne(lstDoandanhgia[i].FK_iDanhgiavienID).sHoten);
                }
            }
        }

        builder.InsertCell();
        builder.Font.Bold = true;
        builder.Font.Italic = false;
        builder.Writeln("Các thành viên Đoàn đánh giá");
        builder.Font.Bold = false;
        builder.Writeln("(Ký và ghi rõ họ, tên)");
        builder.Writeln(oTruongdoan.sHoten);
        builder.EndRow();

        builder.EndTable();
        //--------end table
        doc.Save("BaocaodanhgiaTochucchungnhan_" + oTochuc.sKytuviettat + ".doc", SaveFormat.Doc, SaveType.OpenInBrowser, Response);
    }
    protected void btnLuu_Click(object sender, EventArgs e)
    {
        DateTime dt = DateTime.Parse(txtNgaydg.Text);
        Response.Write("Ngày = " + dt.ToString());
        String sGio = (DateTime.Parse(txtGiodg.Text)).ToString();
        Response.Write("Giờ = " + sGio);
        DanhgiatochucchungnhanEntity oDanhgia = new DanhgiatochucchungnhanEntity();
        oDanhgia.sPhamvinghidinh = txtPhamvideghi.InnerText;
        oDanhgia.dNgaydanhgia = DateTime.Parse(txtNgaydg.Text + " " + txtGiodg.Text);
        oDanhgia.sCancudanhgia = txtCancudanhgia.InnerText;
        oDanhgia.sNoidungdanhgia = txtNoidungdanhgia.InnerText;
        oDanhgia.sKetquadanhgia = txtKetquadanhgia.InnerText;
        oDanhgia.sKetquadanhgia = txtKetquadanhgia.InnerText;
        oDanhgia.iKetquadanhgia = short.Parse(ddlKetluan.SelectedItem.Value);
        oDanhgia.FK_iTochucchungnhanID = PK_iTochucchungnhanID;
        oDanhgia.FK_iTruongdoandanhgiaID = int.Parse(ddlTruongdoan.SelectedItem.Value);
        if (PK_iDanhgiatochucID == 0)
        {
            PK_iDanhgiatochucID = DanhgiatochucchungnhanBRL.Add(oDanhgia);
            DoandanhgiatochucchungnhanEntity oDoandanhgiaTmp = new DoandanhgiatochucchungnhanEntity();
            for(int i=0;i<lstDoandanhgiachon.Items.Count; ++i)
            {
                oDoandanhgiaTmp.FK_iDanhgiatochucchungnhanID = PK_iDanhgiatochucID;
                oDoandanhgiaTmp.FK_iDanhgiavienID = int.Parse(lstDoandanhgiachon.Items[i].Value);
                DoandanhgiatochucchungnhanBRL.Add(oDoandanhgiaTmp);
            }
            //Cập nhật trạng thái duyệt của tổ chức được chứng nhận
            TochucchungnhanEntity oTochuc = TochucchungnhanBRL.GetOne(PK_iTochucchungnhanID);
            oTochuc.bDuyet = (Int32.Parse(ddlKetluan.SelectedItem.Value) == 1 ? true : false);
            oTochuc.iTrangthai = 2; // 2 - Hoàn chỉnh hồ sơ
            // Cập nhập giá trị Trạng thái
            TochucchungnhanBRL.Edit(oTochuc);
            lblThongbao.Text = "Lưu thành  công!";
            btnExportToWord.Enabled = true;
        }
        else
        {
            DanhgiatochucchungnhanBRL.Edit(oDanhgia);
            //Xóa danh sách đánh giá viên đã tồn tại
            List<DoandanhgiatochucchungnhanEntity> lstDoandanhgiaE = DoandanhgiatochucchungnhanBRL.GetByFK_iDanhgiatochucchungnhanID(PK_iDanhgiatochucID);
            for(int i=0;i<lstDoandanhgiaE.Count;++i)
            {
                DoandanhgiatochucchungnhanBRL.Remove(lstDoandanhgiaE[i].FK_iDanhgiatochucchungnhanID);
            }
            //Thêm danh sách có trong list đã chọn vào danh sách đoàn đánh giá
            DoandanhgiatochucchungnhanEntity oDoandanhgiaTmp = new DoandanhgiatochucchungnhanEntity();
            for(int i=0;i<lstDoandanhgiachon.Items.Count; ++i)
            {
                oDoandanhgiaTmp.FK_iDanhgiatochucchungnhanID = PK_iDanhgiatochucID;
                oDoandanhgiaTmp.FK_iDanhgiavienID = int.Parse(lstDoandanhgiachon.Items[i].Value);
                DoandanhgiatochucchungnhanBRL.Add(oDoandanhgiaTmp);
            }
            //Cập nhật trạng thái duyệt của tổ chức được chứng nhận
            TochucchungnhanEntity oTochuc = TochucchungnhanBRL.GetOne(PK_iTochucchungnhanID);
            oTochuc.bDuyet = (Int32.Parse(ddlKetluan.SelectedItem.Value) == 1 ? true : false);
            TochucchungnhanBRL.Edit(oTochuc);
            lblThongbao.Text = "Cập nhật thành  công!";
        } 
    }
}