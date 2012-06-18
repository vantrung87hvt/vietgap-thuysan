using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using Aspose.Words;
using Aspose.Words.Drawing;
//using System.Web.UI.MobileControls;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using INVI.Entity;
using INVI.Business;
using INVI.INVILibrary;

public partial class adminx_ucGiayphepVietGap : System.Web.UI.UserControl
{
    int iVietGAPID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["PK_iCosonuoitrongID"] != null)
            {
                // Phải lấy ID của Mã số VIỆT GAP theo Cơ sở nuôi trồng
                
                int PK_iCosonuoitrongID = Convert.ToInt32(Request.QueryString["PK_iCosonuoitrongID"].ToString());
                List<MasovietgapEntity> lstMasoVietgap = MasovietgapBRL.GetByFK_iCosonuoitrongID(PK_iCosonuoitrongID);
                if (lstMasoVietgap != null && lstMasoVietgap.Count > 0)
                {
                    iVietGAPID = (int)lstMasoVietgap[0].PK_iMasoVietGapID;
                    hienChungNhanVietGAPtheoID(iVietGAPID);
                    btnExportToWord.CommandArgument = iVietGAPID.ToString();
                }
                else
                    return;
            }
        }
    }
    
    public void hienChungNhanVietGAPtheoID(Int32 id)
        {
            String sqlCon = ConfigurationManager.ConnectionStrings["thanglongsport_vietgapConnectionString"].ToString();
            SqlConnection Con = new SqlConnection(sqlCon);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter = null;
            try
            {
                Con.Open();
                cmd.CommandText = "spMasovietgap_GetAllInforByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Con;
                cmd.Parameters.Add("@PK_iMasovietgapID", SqlDbType.BigInt);
                cmd.Parameters[0].Value = id;
                adapter = new SqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                adapter.Fill(tbl);
                if (tbl.Rows.Count > 0)
                {
                    DataRow row = tbl.Rows[0];

                    // Coquancaptrren
                    CoquancaptrenEntity cqct = CoquancaptrenBRL.GetOne(Convert.ToInt32(row["PK_iTochucchungnhanID"]));
                    lblCoQuanCapTren.Text = cqct.sTencoquan;

                    //
                    lblMaso.Text = row["sMaso"].ToString();
                    lblTencoquan.Text = row["sTochucchungnhan"].ToString();
                    imgTochuc.ImageUrl = "ViewImage.aspx?ID=" + row["PK_iTochucchungnhanID"].ToString();
                    lblCosonuoi.Text = row["sTencoso"].ToString();
                    lblDiachi.Text = "Xã " + row["sXa"].ToString() + ", ấp " + row["sAp"].ToString();
                    lblMasocoso.Text = row["sMasocoso"].ToString();
                    DateTime dt = DateTime.Parse(row["dNgaycap"].ToString());
                    lblNgaycap.Text = "...................ngày " + dt.Day + " tháng " + dt.Month + " năm " + dt.Year;
                    dt = DateTime.Parse(row["dNgayhethan"].ToString());
                    lblNgayhethan.Text = String.Format("{0:dd/MM/yyyy}", dt);
                    lblDoituong.Text = row["sTendoituong"].ToString();
                    lblDientich.Text = String.Format("{0:0,0.#}", row["fTongdienTichMatNuoc"].ToString()) + " m<sup>2</sup>";
                    lblSanluongdukien.Text = String.Format("{0:#,###}", row["iSanluongdukien"].ToString());


                    //gia hạn
                    List<MasovietgapEntity> lst = MasovietgapBRL.GetByFK_iCosonuoitrongID(Convert.ToInt32(row["PK_iCosonuoitrongID"]));
                    lst = MasovietgapEntity.Sort(lst, "PK_iMasoVietGapID", "DESC");
                    int masocount = lst.Count;
                    int du = masocount % 5 - 1;                    
                    List<MasovietgapEntity> standlst = new List<MasovietgapEntity>();
                    int i = 0;
                    if (du < 0)
                        du = 4;
                    for (i = 0; i < du; i++)
                    {
                        standlst.Add(lst[i]);
                    }
                    standlst = MasovietgapEntity.Sort(standlst, "PK_iMasoVietGapID", "ASC");
                    for (i = du; i < 4; i++)
                    {
                        MasovietgapEntity oentity = new MasovietgapEntity();
                        standlst.Add(oentity);
                    }
                    standlst = MasovietgapEntity.Sort(standlst, "PK_iMasoVietGapID", "DESC");
                    rptGiaHan.DataSource = standlst;
                    rptGiaHan.DataBind();
                    //
                    btnExportToWord.Enabled = true;
                }
                else
                {
                    Response.Write("<script>alert('Mã số không tồn tại!'</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<font color=red>" + ex.Message + "</font>");
            }
            finally
            {
                if (Con.State != ConnectionState.Closed)
                    Con.Close();
                adapter.Dispose();
                cmd.Dispose();
                Con.Dispose();
            }
        }
        
        private DataTable getGetInforById(int id)
        {
            String sqlCon = ConfigurationManager.ConnectionStrings["thanglongsport_vietgapConnectionString"].ToString();
            SqlConnection Con = new SqlConnection(sqlCon);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter = null;
            DataTable tbl = new DataTable();
            try
            {
                Con.Open();
                cmd.CommandText = "spMasovietgap_GetAllInforByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = Con;
                cmd.Parameters.Add("@PK_iMasovietgapID", SqlDbType.BigInt);
                cmd.Parameters[0].Value = iVietGAPID;
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tbl);
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
            }
            finally
            {
                if (Con.State != ConnectionState.Closed)
                    Con.Close();
                Con.Dispose();
            }
            return tbl;
        }

        protected void ExportToWord(object sender, EventArgs e)
        {
            if (btnExportToWord.CommandArgument == null) return;
            iVietGAPID = Int32.Parse(btnExportToWord.CommandArgument);
            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);
            NodeCollection tables = doc.GetChildNodes(NodeType.Table, true);

            builder.PageSetup.Orientation = Aspose.Words.Orientation.Landscape;
            builder.PageSetup.VerticalAlignment = PageVerticalAlignment.Top;
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;


            DataTable tbl = getGetInforById(iVietGAPID);
            DataRow row = tbl.Rows[0];
            DateTime dt = DateTime.Parse(row["dNgaycap"].ToString());
            DateTime dt2 = DateTime.Parse(row["dNgayhethan"].ToString());
            CoquancaptrenEntity cqct = CoquancaptrenBRL.GetOne(Convert.ToInt32(row["PK_iTochucchungnhanID"]));
            
            
            builder.Font.Size = 12;
            builder.Font.Bold = true;
            builder.Font.Underline = Underline.Single;
            builder.Writeln(cqct.sTencoquan);
            builder.Font.Bold = true;
            builder.Writeln("");
            builder.Font.Underline = Underline.None;
            builder.Writeln(row["sTochucchungnhan"].ToString().ToUpper());
            builder.Writeln("");
            builder.Writeln("");
            builder.Writeln("");
            builder.Writeln("");

            builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            builder.Font.Bold = false;
            builder.Write("Số (VGN): ");
            builder.Font.Bold = true;
            builder.Writeln(row["sMaso"].ToString());
            builder.Writeln("");
            builder.Font.Bold = true;
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            builder.Writeln("CHỨNG NHẬN");
            builder.Writeln("");
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            //----
            builder.Font.Size = 12;
            builder.ParagraphFormat.SpaceAfter = 6.0;
            
            builder.Font.Bold = true;
            builder.Write("\t\tCơ sở nuôi: ");
            builder.Font.Bold = false;
            builder.Writeln(row["sTencoso"].ToString());

            builder.Font.Bold = true;
            builder.Write("\t\tĐịa chỉ: ");
            builder.Font.Bold = false;
            builder.Writeln("Xã " + row["sXa"].ToString() + ", ấp " + row["sAp"].ToString());

            builder.Font.Bold = true;
            builder.Write("\t\tMã số cơ sở: ");
            builder.Font.Bold = false;
            builder.Writeln(row["sMasocoso"].ToString());

            builder.Font.Bold = true;
            builder.Write("\t\tDiện tích: ");
            builder.Font.Bold = false;

            builder.Write(row["fTongdienTichMatNuoc"].ToString() + " ");
            builder.InsertHtml("m<sup>2</sup>");
            builder.Writeln("");
            builder.Font.Bold = true;
            builder.Write("\t\tĐối tượng, hình thức nuôi: ");
            builder.Font.Bold = false;
            builder.Writeln(row["sTendoituong"].ToString());

            builder.Font.Bold = true;
            builder.Write("\t\tSản lượng dự kiến (kg): ");
            builder.Font.Bold = false;
            builder.Writeln(row["iSanluongdukien"].ToString());
            //-----------
            builder.Writeln(""); builder.Writeln("");
            builder.Font.Bold = true;
            
            

            builder.Writeln("\t\tSẢN XUẤT THEO QUY PHẠM THỰC HÀNH NUÔI TRỒNG THỦY SẢN TỐT ");
            builder.Writeln("");
            //---------
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;

            builder.Font.Bold = false;
            builder.Font.Size = 12;
            builder.Font.Italic = true;
            builder.Writeln("\t\t\t\t\t\t\t\t\t\t...........ngày.....tháng.....năm.....");
            builder.Font.Bold = true;
            
            builder.Font.Italic = false;
            builder.Writeln("\t\t\t\t\t\t\t\t\t\tTHỦ TRƯỞNG CƠ QUAN CHỨNG NHẬN\t");
            builder.Font.Bold = false;
            builder.Font.Size = 12;
            builder.Font.Italic = true;
            builder.Writeln("\t\t\t\t\t\t\t\t\t\t(Ký tên và đóng dấu)");


            
            //----------
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            builder.Font.Size = 12;
            builder.Font.Bold = true;
            builder.Font.Italic = false;
            builder.ParagraphFormat.SpaceAfter = 0;
            builder.Writeln("\tGiấy chứng nhận có giá trị đến ngày: " + String.Format("{0:dd/MM/yyyy}", dt2));            
            builder.Writeln("\tVà được gia hạn ở mặt sau căn cứ vào kết quả kiểm tra và giám sát");
            
            /*
             * Lưu file
             */
            InsertWatermarkText(doc,Convert.ToInt32(row["PK_iTochucchungnhanID"]));

            builder.InsertBreak(BreakType.PageBreak);
            //Gia hạn
            List<MasovietgapEntity> lst = MasovietgapBRL.GetByFK_iCosonuoitrongID(Convert.ToInt32(row["PK_iCosonuoitrongID"]));
            lst = MasovietgapEntity.Sort(lst, "PK_iMasoVietGapID", "DESC");
            int masocount = lst.Count;
            int du = masocount % 5 - 1;
            //Response.Write(du);
            List<MasovietgapEntity> standlst = new List<MasovietgapEntity>();
            int i = 0;
            if (du < 0)
                du = 4;
            for (i = 0; i < du; i++)
            {
                standlst.Add(lst[i]);
            }


            standlst = MasovietgapEntity.Sort(standlst, "PK_iMasoVietGapID", "ASC");            
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            builder.Font.Bold = true;
            builder.Writeln("GIA HẠN HIỆU LỰC");
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            builder.Font.Bold = false;
            builder.Writeln();
            builder.StartTable();
            builder.PageSetup.LeftMargin = 80;
            builder.RowFormat.AllowAutoFit = false;
            builder.CellFormat.Width = 320;
            //ghi cell tương ứng
            for (i = 0; i < du; i++)
            {
                BuildTable(doc, builder, standlst[i].dNgaycap.ToString("dd/MM/yyyy"), standlst[i].fDientichmorong.ToString(), standlst[i].iSanluongdukienmoi.ToString(), standlst[i].dNgayhethan.ToString("dd/MM/yyyy"), txtTenThuTruong.Text);
                if ((i + 1) % 2 == 0)
                {
                    builder.EndRow();
                }
            }
            //
            for (i = du; i < 4; i++)
            {
                BuildTable(doc, builder, "", "", "", "", "");
                if ((i + 1) % 2 == 0)
                {
                    builder.EndRow();
                }
            }
            //nếu chẵn thì endrow
            //
            builder.EndTable();
            //end gia hạn
           
          //  InsertWatermarkText2(doc);
            doc.Save("GiayChungNhanVietGap.doc", SaveFormat.Doc, SaveType.OpenInBrowser, Response);
            
        }
        
        private void BuildTable(Document doc, DocumentBuilder builder, string ngaygiahan, string dientich, string sanluong, string ngayhethan, string thutruong)
        {
            builder.CellFormat.Borders.LineWidth = 1;
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            builder.Font.Bold = false;
            builder.InsertCell();
            builder.Writeln("- Ngày gia hạn: " + ngaygiahan);
            builder.Writeln("- Diện tích: " + dientich);
            builder.Writeln("- Sản lượng dự kiến: " + sanluong);
            builder.Writeln("- Gia hạn đến: " + ngayhethan);
            builder.Writeln();
            builder.Writeln();
            builder.Writeln();
            builder.Writeln();
            builder.Writeln();
            builder.Writeln();
            builder.Writeln();
            builder.Writeln();
            builder.Writeln();                        
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            builder.Font.Bold = true;
            builder.Writeln(thutruong);
           
        }    
        private static void InsertWatermarkText(Document doc, int PK_iTochucchungnhanID)
        {
            // Create a watermark shape. This will be a WordArt shape.
            // You are free to try other shape types as watermarks.
            Shape watImg = new Shape(doc, ShapeType.Image);
            string imgPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "\\adminx\\img\\giaycn.jpg";
            watImg.ImageData.SetImage(imgPath);
            watImg.Width = 820;
            watImg.Height = 560;
            // Place the watermark in the page center.
            watImg.RelativeHorizontalPosition = RelativeHorizontalPosition.Page;
            watImg.RelativeVerticalPosition = RelativeVerticalPosition.Page;
            watImg.WrapType = WrapType.None;
            watImg.VerticalAlignment = VerticalAlignment.Center;
            watImg.HorizontalAlignment = HorizontalAlignment.Center;           
            ///
            Shape watImg2 = new Shape(doc, ShapeType.Image);
            imgPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "\\adminx\\img\\logo thuysan.png";
            watImg2.ImageData.SetImage(imgPath);
            watImg2.Width = 90;
            watImg2.Height = 75;
            // Place the watermark in the page center.
            watImg2.RelativeHorizontalPosition = RelativeHorizontalPosition.Page;
            watImg2.RelativeVerticalPosition = RelativeVerticalPosition.Page;
            watImg2.WrapType = WrapType.None;
            watImg2.Top = 80;
            watImg2.Left = 90;
            
            Shape watImg3 = new Shape(doc, ShapeType.Image);
            imgPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "\\adminx\\img\\logo thuysan.png";
         
            TochucchungnhanEntity entity    = new TochucchungnhanEntity();
            entity = TochucchungnhanBRL.GetOne(PK_iTochucchungnhanID);
            Byte[] bytImage = entity.imgLogo;
            if (bytImage != null)
            {
                watImg3.ImageData.SetImage(bytImage);
            }            
            watImg3.Width = 90;
            watImg3.Height = 75;
            // Place the watermark in the page center.
            watImg3.RelativeHorizontalPosition = RelativeHorizontalPosition.Page;
            watImg3.RelativeVerticalPosition = RelativeVerticalPosition.Page;
            watImg3.WrapType = WrapType.None;
            watImg3.Top = 80;
            watImg3.Left = 620;
            
            // Create a new paragraph and append the watermark to this paragraph.
            Paragraph watermarkParaImg = new Paragraph(doc);            
            watermarkParaImg.AppendChild(watImg3);
            watermarkParaImg.AppendChild(watImg2);
            watermarkParaImg.AppendChild(watImg);
            
            

            // Insert the watermark into all headers of each document section.


            foreach (Section sect in doc.Sections)
            {
               
                // There could be up to three different headers in each section, since we want
                // the watermark to appear on all pages, insert into all headers.
                sect.PageSetup.DifferentFirstPageHeaderFooter = true;
                //InsertWatermarkIntoHeader(watermarkParaImg, sect, HeaderFooterType.HeaderPrimary);
                InsertWatermarkIntoHeader(watermarkParaImg, sect, HeaderFooterType.HeaderFirst);
                InsertWatermarkIntoHeader(watermarkParaImg, sect, HeaderFooterType.HeaderEven);
                
            }

        }

        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }
        private static void InsertWatermarkIntoHeader(Paragraph watermarkPara, Section sect, HeaderFooterType headerType)
        {
            HeaderFooter header = sect.HeadersFooters[headerType];

            if (header == null)
            {
                // There is no header of the specified type in the current section, create it.
                header = new HeaderFooter(sect.Document, headerType);
                sect.HeadersFooters.Add(header);
            }

            // Insert a clone of the watermark into the header.
            header.AppendChild(watermarkPara.Clone(true));
        }
       
        
        protected void rptGiaHan_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblID = e.Item.FindControl("lblID") as Label;
                Label lblNgayGiaHan = e.Item.FindControl("lblNgayGiaHan") as Label;
                Label lblSanLuong = e.Item.FindControl("lblSanLuongDuKien") as Label;
                Label lblDienTich = e.Item.FindControl("lblDienTich") as Label;
                Label lblGiaHanDen = e.Item.FindControl("lblGiaHanDen") as Label;
                Label lblThuTruong = e.Item.FindControl("lblThuTruong") as Label;
                int ID = Convert.ToInt32(lblID.Text);
               
                if (ID == 0)
                {
                    lblGiaHanDen.Text = "";
                    lblNgayGiaHan.Text = "";
                    lblSanLuong.Text = "";
                    lblDienTich.Text = "";
                    lblThuTruong.Text = "";
                }
                else
                {
                    MasovietgapEntity entity = MasovietgapBRL.GetOne(ID);
                    lblGiaHanDen.Text = entity.dNgayhethan.ToString("dd/MM/yyyy");
                    lblNgayGiaHan.Text = entity.dNgaycap.ToString("dd/MM/yyyy");
                    lblSanLuong.Text = entity.iSanluongdukienmoi.ToString();
                    lblDienTich.Text = entity.fDientichmorong.ToString();
                    lblThuTruong.Text = txtTenThuTruong.Text;
                }


            }
        }
        protected void btnXem_Click(object sender, EventArgs e)
        {
            hienChungNhanVietGAPtheoID(Convert.ToInt32(btnExportToWord.CommandArgument));
        }
}
