using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.Business;
using Aspose.Words;
using Aspose.Words.Drawing;

public partial class adminx_ucBaocaodanhgianoibo : System.Web.UI.UserControl
{
    //==============Ví dụ, sau này sẽ thay bằng user đăng nhập
    int iUserID = 0;
    //-----------------------
    TochucchungnhanEntity oTochuc;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            napDulieu();
        }
    }

    public void napDulieu()
    {
        if (Session["userID"] == null) return;
        iUserID = Convert.ToInt32(Session["userID"].ToString());
        List<TochucchungnhanTaikhoanEntity> lstTochucTaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(iUserID);
        if (lstTochucTaikhoan.Count > 0)
        {
            oTochuc = TochucchungnhanBRL.GetOne(lstTochucTaikhoan[0].FK_iTochucchungnhanID);
            lblTentochuc.Text = oTochuc.sTochucchungnhan;
            lblDiachi.Text = oTochuc.sDiachi;
            lblDienthoai.Text = oTochuc.sSodienthoai;
            lblFax.Text = oTochuc.sFax;
            lblEmail.Text = oTochuc.sEmail;
            lblCoquancap.Text = oTochuc.sCoquancap;
            DateTime dt = DateTime.Parse(oTochuc.dNgaycapdangkykinhdoanh.ToString());
            lblNgaycap.Text = String.Format("{0:dd/MM/yyyy}", dt);
            lblNoicap.Text = oTochuc.sNoicapdangkykinhdoanh;
            lblTentochuclamdon.Text = oTochuc.sTochucchungnhan;
            //danh sách hồ sơ
            String sLst = "";
            List<DangkyHoatdongchungnhanEntity> lstDangky = DangkyHoatdongchungnhanBRL.GetByFK_iTochucchungnhanID(lstTochucTaikhoan[0].FK_iTochucchungnhanID);
            if (lstDangky.Count > 0)
            {
                List<HosokemtheoTochucchungnhanEntity> lstHoso = HosokemtheoTochucchungnhanBRL.GetByFK_iDangkyChungnhanVietGapID(lstDangky[0].PK_iDangkyChungnhanVietGapID);
                if (lstHoso.Count > 0)
                {
                    foreach (HosokemtheoTochucchungnhanEntity et in lstHoso)
                    {
                        sLst += "-  " + GiaytoBRL.GetOne(et.FK_iGiaytoID).sTengiayto + "<br/>";
                    }
                    lblHosokemtheo.Text = sLst;
                }
                lblTentochucinnghieng.Text = oTochuc.sTochucchungnhan;
            }
        }
        else
        {
            Response.Write("<script>alert('Chưa đăng ký tổ chức chứng nhận!');</script>");
            btnExToWord.Enabled = false;
        }
    }
    protected void btnExToWord_Click(object sender, EventArgs e)
    {
        if (Session["userID"] == null) return;
        iUserID = Convert.ToInt32(Session["userID"].ToString());
        List<TochucchungnhanTaikhoanEntity> lstTochucTaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(iUserID);
        int iTochucID = 0;
        if (lstTochucTaikhoan.Count > 0)
            iTochucID = lstTochucTaikhoan[0].FK_iTochucchungnhanID;

        oTochuc = TochucchungnhanBRL.GetOne(iTochucID);
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
        builder.Writeln("-------");
        builder.Writeln("");
        builder.Font.Bold = false;
        builder.Font.Italic = true;
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Right;
        builder.Writeln("……, ngày ... tháng … năm 20…");
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
        builder.Font.Bold = true;
        builder.Font.Italic = false;
        builder.Writeln("ĐƠN ĐĂNG KÝ");
        builder.Font.Bold = false;
        builder.Writeln("HOẠT ĐỘNG CHỨNG NHẬN VIETGAP");
        builder.Font.Bold = true;
        builder.Write("Kính gửi: ");
        builder.Font.Bold = false;
        builder.Writeln("Cơ quan công nhận Tổ chức Chứng nhận");
        builder.Writeln("");
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
        builder.Writeln("- Tên tổ chức: " + oTochuc.sTochucchungnhan);
        builder.Writeln("- Địa chỉ liên lạc: " + oTochuc.sDiachi);
        builder.Writeln("- Điện thoại: " + oTochuc.sSodienthoai + " Fax: " + oTochuc.sFax + " E-mail: " + oTochuc.sEmail);
        builder.Write("- Quyết định thành lập (nếu có) hoặc Giấy đăng ký kinh doanh số "+ oTochuc.sSodangkykinhdoanh +" do Cơ ");
        DateTime dt = DateTime.Parse(oTochuc.dNgaycapdangkykinhdoanh.ToString());
        String sNgaycap = String.Format("{0:dd/MM/yyyy}", dt);
        builder.Writeln("quan cấp: " + oTochuc.sCoquancap + " cấp ngày " + sNgaycap + " tại " + oTochuc.sNoicapdangkykinhdoanh);
        builder.Writeln("Sau khi nghiên cứu các điều kiện hoạt động chứng nhận VietGAP theo Thông tư số     /2011/TT-BNNPTNT ngày    tháng     năm 2011 của Bộ trưởng Bộ Nông nghiệp và Phát triển nông thôn ban hành Thông tư chứng nhận thực hành Nuôi trồng thuỷ sản tốt (VietGAP) chúng tôi nhận thấy có đủ các điều kiện để hoạt động chứng nhận VietGAP cho " + oTochuc.sTochucchungnhan);
        builder.Writeln("Hồ sơ kèm theo: ");
        builder.Writeln("");
        List<DangkyHoatdongchungnhanEntity> lstDangky = DangkyHoatdongchungnhanBRL.GetByFK_iTochucchungnhanID(iTochucID);
        if (lstDangky.Count > 0)
        {
            List<HosokemtheoTochucchungnhanEntity> lstHoso = HosokemtheoTochucchungnhanBRL.GetByFK_iDangkyChungnhanVietGapID(lstDangky[0].PK_iDangkyChungnhanVietGapID);
            if (lstHoso.Count > 0)
            {
                foreach (HosokemtheoTochucchungnhanEntity et in lstHoso)
                {
                    builder.Writeln("- " + GiaytoBRL.GetOne(et.FK_iGiaytoID).sTengiayto);
                }
            }
        }
        builder.Write("Đề nghị ");
        builder.Font.Italic = true;
        builder.Font.Bold = true;
        builder.Write("Cơ quan công nhận ");
        builder.Font.Italic = false;
        builder.Font.Bold = false;
        builder.Write("Tổ chức Chứng nhận xem xét để công nhận (tên tổ");
        builder.Writeln("chức) được hoạt động chứng nhận VietGAP cho: ");
        builder.Writeln("\t-\tĐăng ký công nhận lần đầu:");
        builder.Writeln("\t-\tĐăng ký công nhận lại:");
        builder.Writeln("\t-\tĐăng ký mở rộng hoạt động chứng nhận:");
        builder.Writeln("Chúng tôi xin cam kết thực hiện đúng các quy định về hoạt động chứng nhận VietGAP./.");

        //-------Table
        Aspose.Words.Table table = builder.StartTable();
        builder.CellFormat.Width = 260;
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
        builder.InsertCell();

        builder.InsertCell();
        builder.Font.Bold = true;
        builder.Font.Italic = false;
        builder.Writeln("Đại diện Tổ chức ...");
        builder.Font.Bold = false;
        builder.Font.Italic = true;
        builder.Writeln("(Ký tên, đóng dấu)");
        builder.EndRow();

        builder.EndTable();
        //--------end table
        /*
         * Lưu file
         */
        doc.Save("DonDangKy_" + oTochuc.PK_iTochucchungnhanID + ".doc", SaveFormat.Doc, SaveType.OpenInBrowser, Response);
    }
}