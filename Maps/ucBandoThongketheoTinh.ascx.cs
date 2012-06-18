using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Text;
public partial class Maps_ucBandophanboCosonuoitrong : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
        }
    }
    private void export2Excel(String sFilename,String sTableContent)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xls", sFilename));
        Response.Charset = "UTF-8";
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWriter = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
        Response.Write("<table cellSpacing='0' cellPadding='0' width='100%' align='center' border='1'");
        Response.Write(sTableContent);
        //hor-minimalist-b
        Response.Write("</table>");
        Response.End();

    }
    private void exportToExcel(String sFilename)
    {
        Session["sISO"] = "VN-44";
        String sISO = Session["sISO"].ToString();
        DataSet ds = INVI.INVILibrary.INVIHelper.getThongTinTongHopTheoTinh(sISO);
        Response.ContentType = "application/csv";
        Response.Charset = "";
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}.xls", sFilename));
        Response.ContentEncoding = Encoding.Unicode;
        Response.BinaryWrite(Encoding.Unicode.GetPreamble());
        Response.Write("<table cellSpacing='0' cellPadding='0' width='100%' align='center' border='1'");
        Response.Write("<tr><td colspan=\"5\"></td></tr>");
        Response.Write("<tr><td>Đối tượng</td><td>T.Số hộ</td><td>T.Diện tích</td><td>T.Diện tích Ao lắng</td><td>T.Sản lượng</td></tr>");
        if (ds.Tables[0].Rows.Count <= 0)
        {
            Response.Write("</table>");
            Response.End();
            return;
        }
        DataRow row;
        for (int i = 0; i < ds.Tables[0].Rows.Count; ++i)
        {
            row = ds.Tables[0].Rows[i];
            Response.Write("<tr>");
            Response.Write("<td>" + row["sTendoituong"].ToString() + "</td>");
            Response.Write("<td>" + row["iSoho"].ToString() + "</td>");
            Response.Write("<td>" + row["fTongdientich"].ToString() + "</td>");
            Response.Write("<td>" + row["fTongdientichAolang"].ToString() + "</td>");
            Response.Write("<td>" + row["iSanluongdukien"].ToString() + "</td>");
            Response.Write("</tr>");
        }
        Response.Write("</table>");
        Response.End();

    }
    protected void lnkExport2Excel_Click(object sender, EventArgs e)
    {
        exportToExcel("Thongketheotinh");
        //export2Excel("Thongketheotinh","");
    }
   
}