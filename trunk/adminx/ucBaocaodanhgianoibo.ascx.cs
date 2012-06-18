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

    CosonuoitrongEntity oCosonuoitrong;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            napDulieu();
        }
    }

    public void napDulieu()
    {
        if (Session["UserID"] == null) Response.End();
        iUserID = Convert.ToInt32(Session["UserID"].ToString());
        oCosonuoitrong = CosonuoitrongBRL.GetByFK_iUserID(iUserID)[0];
        lblTencoso.Text = oCosonuoitrong.sTencoso;
        lblNguoidaidien.Text = oCosonuoitrong.sTenchucoso;
        lblSodienthoai.Text = oCosonuoitrong.sDienthoai;
        lblDiachiCoso.Text = "Xã " + oCosonuoitrong.sXa + ", ấp " + oCosonuoitrong.sAp;
    }
    protected void btnExToWord_Click(object sender, EventArgs e)
    {
        if (Session["UserID"] == null) Response.End();
        iUserID = Convert.ToInt32(Session["UserID"].ToString());
        oCosonuoitrong = CosonuoitrongBRL.GetByFK_iUserID(iUserID)[0];
        //-----------
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);
        NodeCollection tables = doc.GetChildNodes(NodeType.Table, true);

        builder.PageSetup.PaperSize = PaperSize.A4;

        builder.PageSetup.Orientation = Aspose.Words.Orientation.Portrait;
        builder.PageSetup.VerticalAlignment = PageVerticalAlignment.Top;
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;

        builder.Font.Size = 12;
        builder.Font.Bold = true;
        builder.Writeln("BÁO CÁO ĐÁNH GIÁ NỘI BỘ");
        builder.Font.Bold = false;
        builder.Font.Italic = true;
        builder.Writeln("(Ban hành kèm theo Thông tư số  ............/2011/TT-BNNPTNT");
        builder.Writeln("ngày      tháng    năm 2011 của Bộ trưởng Bộ Nông nghiệp và Phát triển nông thôn)");
        builder.Writeln("");
        builder.Font.Bold = true;
        builder.Font.Italic = false;
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
        builder.Writeln("Kính gửi: …………………………………………………………………………….");
        builder.Writeln("");
        builder.ParagraphFormat.SpaceAfter = 1.5;
        builder.Writeln("I. Thông tin chung");
        builder.Font.Bold = false;
        builder.Font.Size = 13;

        builder.Writeln("1. Tên cơ sở nuôi: " + oCosonuoitrong.sTencoso);
        builder.Writeln("2. Địa chỉ cơ sở nuôi: " + "Xã " + oCosonuoitrong.sXa + ", ấp " + oCosonuoitrong.sAp);
        builder.Writeln("3. Số điện thoại: "+ oCosonuoitrong.sDienthoai +"			Fax:");
        builder.Writeln("4. Người đại diện: " + oCosonuoitrong.sTenchucoso);
        builder.Writeln("5. Số lượng thành viên (nếu cơ sở do một tổ chức làm chủ): ");
        builder.Writeln("");builder.Writeln("");
        builder.Font.Bold = true;
        builder.Font.Size = 12;
        builder.Writeln("Sau khi tiến hành đánh giá nội bộ, Cơ sở nuôi chúng tôi xin gửi tới Quý cơ quan kết quả ");
        builder.Writeln("");
        builder.Writeln("kết quả đánh giá (Bảng 1).");
        builder.Writeln("");builder.Writeln("");
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Right;
        builder.Font.Italic = true;
        builder.Font.Bold = false;
        builder.Writeln("Ngày … tháng … năm …\t                     ");
        builder.Writeln(""); builder.Writeln("");
        //-------Table
        Aspose.Words.Table table = builder.StartTable();
        builder.CellFormat.Width = 260;
        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
        builder.InsertCell();
        builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Bottom;
        builder.Font.Bold = true;
        builder.Font.Italic = false;
        builder.Writeln("Người đánh giá");
        builder.Font.Bold = false;
        builder.Font.Italic = true;
        builder.Writeln("(Ký, ghi rõ họ tên)");

        builder.InsertCell();
        builder.Font.Bold = true;
        builder.Font.Italic = false;
        builder.Writeln("Đại diện chủ cơ sở nuôi");
        builder.Font.Bold = false;
        builder.Font.Italic = true;
        builder.Writeln("(Ký, ghi rõ họ tên)");
        builder.EndRow();

        builder.EndTable();
        //--------end table
        /*
         * Lưu file
         */
        doc.Save("Baocaonoibo_"+ oCosonuoitrong.sMaso_vietgap +".doc", SaveFormat.Doc, SaveType.OpenInBrowser, Response);
    }
}