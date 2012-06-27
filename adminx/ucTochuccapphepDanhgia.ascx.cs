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
        
        //getThongtindanhgia(PK_iDanhgiatochucID);
        if (!IsPostBack)
        {
            if (Session["PK_iTochucchungnhanID"] != null)
            {
                PK_iTochucchungnhanID = Convert.ToInt32(Session["PK_iTochucchungnhanID"].ToString());
                napDoandanhgiavien(PK_iTochucchungnhanID);
                NapThongtin(PK_iTochucchungnhanID);
            }
        }
    }

    public int getThongtindanhgia(int iTochucchungnhanID)
    {
        List<DanhgiatochucchungnhanEntity> lstDanhgiatochuc = DanhgiatochucchungnhanBRL.GetByFK_iTochucchungnhanID(PK_iTochucchungnhanID);
        DanhgiatochucchungnhanEntity.Sort(lstDanhgiatochuc, "dNgaydanhgia", "DESC");
        if (lstDanhgiatochuc.Count > 0)
            PK_iDanhgiatochucID = lstDanhgiatochuc[0].PK_iDanhgiatochucchungnhanID;
        return PK_iDanhgiatochucID;
    }
     public void napDoandanhgiavien(int iTochucchungnhanID)
    {
        List<ChuyengiaEntity> lstDoandanhgia = ChuyengiaBRL.GetByFK_iTochucchungnhanID(iTochucchungnhanID);

        ddlTruongdoan.Items.Clear();
        ddlTruongdoan.DataSource = lstDoandanhgia;
        ddlTruongdoan.DataTextField = "sHoten";
        ddlTruongdoan.DataValueField = "PK_iChuyengiaID";
        ddlTruongdoan.DataBind();

        cblDoandanhgia.Items.Clear();
        cblDoandanhgia.DataSource = lstDoandanhgia;
        cblDoandanhgia.DataTextField = "sHoten";
        cblDoandanhgia.DataValueField = "PK_iChuyengiaID";
        cblDoandanhgia.DataBind();
    }
    public void NapThongtin(int PK_iTochucchungnhanID)
    {
        TochucchungnhanEntity oTochuc = TochucchungnhanBRL.GetOne(PK_iTochucchungnhanID);
        lblTentochuc.Text = oTochuc.sTochucchungnhan;
        lblDiachi.Text = oTochuc.sDiachi;
        lblSodienthoai.Text = oTochuc.sSodienthoai;
        lblFax.Text = oTochuc.sFax;
        lblEmail.Text = oTochuc.sSodienthoai;
        int PK_iDanhgiatochucID = getThongtindanhgia(PK_iTochucchungnhanID);
        //--------- nạp dữ liệu đánh giá nếu đã tồn tại
        if (PK_iDanhgiatochucID > 0)
        {
            //NapLstDoandanhgia();
            DanhgiatochucchungnhanEntity oDanhgia = DanhgiatochucchungnhanBRL.GetOne(PK_iDanhgiatochucID);
            txtPhamvideghi.InnerText = oDanhgia.sPhamvinghidinh;
            txtCancudanhgia.InnerText = oDanhgia.sCancudanhgia;
            txtNoidungdanhgia.InnerText = oDanhgia.sNoidungdanhgia;
            txtKetquadanhgia.InnerText = oDanhgia.sKetquadanhgia;
            DateTime dt = DateTime.Parse(oDanhgia.dNgaydanhgia.ToString());
            txtNgaydg.Text = String.Format("{0:dd/MM/yyyy}", dt);
            dt = DateTime.Parse(oDanhgia.tGiodanhgia.ToString());
            txtGiodg.Text = String.Format("{0:HH:mm:ss}", dt); 
            ddlKetluan.Items.FindByValue(oDanhgia.iKetquadanhgia.ToString()).Selected = true;
            txtaKiennghi.InnerText = oDanhgia.sKiennghi;
            if(ddlTruongdoan.Items.Count>0)
                ddlTruongdoan.Items.FindByValue(oDanhgia.FK_iTruongdoandanhgiaID.ToString()).Selected = true;
            //----------Nạp danh sách đánh giá viên
            List<ChuyengiaEntity> lstDoandg = ChuyengiaBRL.GetByFK_iTochucchungnhanID(PK_iTochucchungnhanID);
            //if (lstDoandg.Count > 0)
            //{
            //    for (int i = 0; i < cblDoandanhgia.Items.Count; ++i)
            //    {
            //        if (lstDoandg.FindAll
            //            (
            //                delegate(DoandanhgiatochucchungnhanEntity oDg)
            //                {
            //                    return (oDg.FK_iChuyengiaID == int.Parse(cblDoandanhgia.Items[i].Value));
            //                }
            //            ).Count > 0)
            //        {
            //            cblDoandanhgia.Items[i].Selected = true;
            //        }
            //    }
                //
                String sDoan = "<ul style='list-style-type:decimal;'>";
                //DanhgiavienEntity oDanhgiavien = new DanhgiavienEntity();
                foreach(ChuyengiaEntity oChuyengia in lstDoandg)
                    sDoan += "<li>" + oChuyengia.sHoten + "</li>";
                sDoan += "</ul>";
                lblCacthanhvien.Text = sDoan;
            }
            //----
            btnExportToWord.Enabled = true;
            }
    
   
    
    protected void btnExportToWord_Click(object sender, EventArgs e)
    {
         if (Session["PK_iTochucchungnhanID"] != null)
            PK_iTochucchungnhanID = Convert.ToInt32(Session["PK_iTochucchungnhanID"].ToString());
        TochucchungnhanEntity oTochuc = TochucchungnhanBRL.GetOne(PK_iTochucchungnhanID);
        PK_iDanhgiatochucID = getThongtindanhgia(PK_iTochucchungnhanID);
        DanhgiatochucchungnhanEntity oDoandanhgia = DanhgiatochucchungnhanBRL.GetOne(PK_iDanhgiatochucID);
        ChuyengiaEntity oTruongdoan = ChuyengiaBRL.GetOne(oDoandanhgia.FK_iTruongdoandanhgiaID);
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
        builder.Writeln("\t" + oTochuc.sTochucchungnhan);
        builder.Write("\tĐịa chỉ: ");
        builder.Bold = false;
        builder.Writeln(oTochuc.sDiachi);
        builder.Bold = true;
        builder.Write("\tĐiện thoại: ");
        builder.Bold = false;
        builder.Write(oTochuc.sSodienthoai);
        builder.Bold = true;
        builder.Write(" Fax: ");
        builder.Bold = false;
        builder.Write(oTochuc.sFax);
        builder.Bold = true;
        builder.Write("E-mail: ");
        builder.Writeln(oTochuc.sEmail);
        builder.Bold = true;
        builder.Writeln("2. Phạm vi đề nghị chỉ định: ");
        builder.Bold = false;
        builder.Writeln("\t" + oDoandanhgia.sPhamvinghidinh);
        builder.Bold = true;
        builder.Writeln("3. Đoàn đánh giá hoặc thành viên đoàn đánh giá: ");
        builder.Bold = false;
        if (lstDoandanhgia.Count > 0)
        {
            for (int i = 0; i < lstDoandanhgia.Count; ++i)
            {
                builder.Writeln("\t- " + ChuyengiaBRL.GetOne(lstDoandanhgia[i].FK_iChuyengiaID).sHoten);
            }
        }
        DateTime dt = DateTime.Parse(oDoandanhgia.tGiodanhgia.ToString());
        String sGiodanhgia = String.Format("{0:HH:mm:ss}", dt);
        dt = DateTime.Parse(oDoandanhgia.dNgaydanhgia.ToString());
        String sNgaydanhgia = String.Format("{0:dd/MM/yyyy}", dt);
        builder.Bold = true;
        builder.Writeln("4. Thời gian đánh giá;");
        builder.Bold = false;
        builder.Writeln("\t" + sGiodanhgia + " ngày " + sNgaydanhgia);
        builder.Bold = true;
        builder.Writeln("5. Các căn cứ để đánh giá: ");
        builder.Bold = false;
        builder.Writeln("\t" + oDoandanhgia.sCancudanhgia);
        builder.Bold = true;
        builder.Writeln("6. Nội dung đánh giá: ");
        builder.Bold = false;
        builder.Writeln("\t" + oDoandanhgia.sNoidungdanhgia);
        builder.Bold = true;
        builder.Writeln("7. Kết quả đánh giá: ");
        builder.Bold = false;
        builder.Writeln("\t" + oDoandanhgia.sKetquadanhgia);
        builder.Bold = true;
        builder.Write("8. Kết luận và kiến nghị của Đoàn đánh giá: ");
        builder.Bold = false;
        builder.Writeln(oDoandanhgia.iKetquadanhgia == 1 ? "Đạt" : "Không đạt");
        builder.Writeln("\t" + oDoandanhgia.sKiennghi);
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
                if (lstDoandanhgia[i].FK_iChuyengiaID != oTruongdoan.PK_iChuyengiaID)
                {
                    builder.Writeln("- " + ChuyengiaBRL.GetOne(lstDoandanhgia[i].FK_iChuyengiaID).sHoten);
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
        //DateTime dt = DateTime.Parse(txtNgaydg.Text);
        //Response.Write("Ngày = " + dt.ToString());
        //String sGio = (DateTime.Parse(txtGiodg.Text)).ToString();
        //Response.Write("Giờ = " + sGio);
        //DateTime dt = DateTime.Parse(txtNgaydg.Text);
        //Response.Write("Ngày = " + dt.ToString());
        //String sGio = (DateTime.Parse(txtGiodg.Text)).ToString();
        //Response.Write("Giờ = " + sGio);
        //return;
        if (Session["PK_iTochucchungnhanID"] != null)
            PK_iTochucchungnhanID = Convert.ToInt32(Session["PK_iTochucchungnhanID"].ToString());
        
        PK_iDanhgiatochucID = getThongtindanhgia(PK_iTochucchungnhanID);

        DanhgiatochucchungnhanEntity oDanhgia = new DanhgiatochucchungnhanEntity();
        oDanhgia.sPhamvinghidinh = txtPhamvideghi.InnerText;
        oDanhgia.dNgaydanhgia = DateTime.Parse(txtNgaydg.Text + " " + txtGiodg.Text);
        oDanhgia.sCancudanhgia = txtCancudanhgia.InnerText;
        oDanhgia.sNoidungdanhgia = txtNoidungdanhgia.InnerText;
        oDanhgia.sKetquadanhgia = txtKetquadanhgia.InnerText;
        oDanhgia.sKetquadanhgia = txtKetquadanhgia.InnerText;
        oDanhgia.iKetquadanhgia = short.Parse(ddlKetluan.SelectedItem.Value);
        oDanhgia.sKiennghi = txtaKiennghi.InnerText;
        oDanhgia.FK_iTochucchungnhanID = PK_iTochucchungnhanID;
        oDanhgia.FK_iTruongdoandanhgiaID = int.Parse(ddlTruongdoan.SelectedItem.Value);
        if (PK_iDanhgiatochucID == 0)
        {
            bool bTruongdoancotrongdanhsach = false;
            PK_iDanhgiatochucID = DanhgiatochucchungnhanBRL.Add(oDanhgia);
            DoandanhgiatochucchungnhanEntity oDoandanhgiaTmp = new DoandanhgiatochucchungnhanEntity();
            for(int i=0;i<cblDoandanhgia.Items.Count; ++i)
            {
                if (cblDoandanhgia.Items[i].Selected)
                {
                    oDoandanhgiaTmp.FK_iDanhgiatochucchungnhanID = PK_iDanhgiatochucID;
                    oDoandanhgiaTmp.FK_iChuyengiaID = int.Parse(cblDoandanhgia.Items[i].Value);
                    DoandanhgiatochucchungnhanBRL.Add(oDoandanhgiaTmp);
                    if (ddlTruongdoan.SelectedValue == cblDoandanhgia.Items[i].Value)
                    {
                        bTruongdoancotrongdanhsach = true;
                    }
                }
            }
            if (!bTruongdoancotrongdanhsach)
            {
                oDoandanhgiaTmp.FK_iDanhgiatochucchungnhanID = PK_iDanhgiatochucID;
                oDoandanhgiaTmp.FK_iChuyengiaID = int.Parse(ddlTruongdoan.SelectedValue);
                DoandanhgiatochucchungnhanBRL.Add(oDoandanhgiaTmp);
            }
            //Cập nhật trạng thái duyệt của tổ chức được chứng nhận
            TochucchungnhanEntity oTochuc = TochucchungnhanBRL.GetOne(PK_iTochucchungnhanID);
            oTochuc.bDuyet = (Int32.Parse(ddlKetluan.SelectedItem.Value) == 1 ? true : false);
            oTochuc.iTrangthai = 2; // 2 - Hoàn chỉnh hồ sơ
            oTochuc.sKytuviettat = " ";
            // Cập nhập giá trị Trạng thái
            TochucchungnhanBRL.Edit(oTochuc);
            lblThongbao.Text = "Lưu thành  công!";
            btnExportToWord.Enabled = true;
            NapThongtin(PK_iTochucchungnhanID);
        }
        else
        {

            oDanhgia.PK_iDanhgiatochucchungnhanID = PK_iDanhgiatochucID;
            DanhgiatochucchungnhanBRL.Edit(oDanhgia);
            //Xóa danh sách đánh giá viên đã tồn tại
            List<DoandanhgiatochucchungnhanEntity> lstDoandanhgiaE = DoandanhgiatochucchungnhanBRL.GetByFK_iDanhgiatochucchungnhanID(PK_iDanhgiatochucID);
            for(int i=0;i<lstDoandanhgiaE.Count;++i)
            {
                DoandanhgiatochucchungnhanBRL.Remove(lstDoandanhgiaE[i].PK_iDoandanhgiatochucchungnhanID);
            }
            bool bTruongdoancotrongdanhsach = false;
            DoandanhgiatochucchungnhanEntity oDoandanhgiaTmp = new DoandanhgiatochucchungnhanEntity();
            for(int i=0;i<cblDoandanhgia.Items.Count; ++i)
            {
                if (cblDoandanhgia.Items[i].Selected)
                {
                    oDoandanhgiaTmp.FK_iDanhgiatochucchungnhanID = PK_iDanhgiatochucID;
                    oDoandanhgiaTmp.FK_iChuyengiaID = int.Parse(cblDoandanhgia.Items[i].Value);
                    DoandanhgiatochucchungnhanBRL.Add(oDoandanhgiaTmp);
                    if (ddlTruongdoan.SelectedValue == cblDoandanhgia.Items[i].Value)
                    {
                        bTruongdoancotrongdanhsach = true;
                    }
                }
            }
            if (!bTruongdoancotrongdanhsach)
            {
                oDoandanhgiaTmp.FK_iDanhgiatochucchungnhanID = PK_iDanhgiatochucID;
                oDoandanhgiaTmp.FK_iChuyengiaID = int.Parse(ddlTruongdoan.SelectedValue);
                DoandanhgiatochucchungnhanBRL.Add(oDoandanhgiaTmp);
            }
            //Cập nhật trạng thái duyệt của tổ chức được chứng nhận
            TochucchungnhanEntity oTochuc = TochucchungnhanBRL.GetOne(PK_iTochucchungnhanID);
            oTochuc.bDuyet = (Int32.Parse(ddlKetluan.SelectedItem.Value) == 1 ? true : false);
            string sNamCapPhep = DateTime.Today.Year.ToString("yy");
            string sSoThuTuCuaToChuc = TochucchungnhanBRL.GetAll().Count + 1+"";
            oTochuc.sMaso = "VietGAP-TS-"+sNamCapPhep+"-"+sSoThuTuCuaToChuc;
            TochucchungnhanBRL.Edit(oTochuc);
            lblThongbao.Text = "Cập nhật thành  công!";
            NapThongtin(PK_iTochucchungnhanID);
        } 
    }
}