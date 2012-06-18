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
using INVI.Entity;
using INVI.Business;
using skmControls2.GoogleChart;
public partial class adminx_BaocaoThongke_ucCosonuoitrongThongke : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            napTinh();
            napDoituongnuoi();
        }
    }
    public List<CosonuoitrongEntity> DanhsachCosonuoitrong
    {
        get
        {
            if (Cache["DanhsachCosonuoitrong"] == null)
                return new List<CosonuoitrongEntity>();
            else
                return (List<CosonuoitrongEntity>)Cache["DanhsachCosonuoitrong"];
        }
        set { Cache["DanhsachCosonuoitrong"] = value; }
    }
    private void napTinh()
    {
        List<TinhEntity> lstTinh = TinhBRL.GetAll();
        ddlTinh.DataSource = lstTinh;
        ddlTinh.DataTextField = "sTentinh";
        ddlTinh.DataValueField = "PK_iTinhID";
        ddlTinh.DataBind();
        ddlTinh.Items.Add(new ListItem("Tất cả", "0"));
        if (ddlTinh.Items.Count > 0)
            ddlTinh.SelectedValue = "0";
    }
    private void napDoituongnuoi()
    {
        List<DoituongnuoiEntity> lstDoituongnuoi = DoituongnuoiBRL.GetAll();
        ddlDoituongnuoi.DataSource = lstDoituongnuoi;
        ddlDoituongnuoi.DataTextField = "sTendoituong";
        ddlDoituongnuoi.DataValueField = "PK_iDoituongnuoiID";
        ddlDoituongnuoi.DataBind();
        ddlDoituongnuoi.Items.Add(new ListItem("Tất cả", "0"));
        if (ddlDoituongnuoi.Items.Count > 0)
            ddlDoituongnuoi.SelectedValue = "0";
    }
    private void napRepeater()
    {
        int iTinhID = Convert.ToInt32(ddlTinh.SelectedValue);
        int iDoituongID = Convert.ToInt32(ddlDoituongnuoi.SelectedValue);
        rptCosonuoitrongThongke.DataSource = INVI.INVILibrary.INVIHelper.getCosonuoitrongThongke(iTinhID, iDoituongID);
        rptCosonuoitrongThongke.DataBind();
    }
    protected void btnXem_Click(object sender, EventArgs e)
    {
        short FK_iTinhID = Convert.ToInt16(ddlTinh.SelectedValue);
        if (FK_iTinhID > 0)
        {
            List<QuanHuyenEntity> lstQuanHuyen = QuanHuyenBRL.GetByFK_iTinhThanhID(FK_iTinhID);
            List<CosonuoitrongEntity> lstCosonuoitrong = new List<CosonuoitrongEntity>();
            foreach (QuanHuyenEntity oQuanHuyen in lstQuanHuyen)
                lstCosonuoitrong.AddRange(CosonuoitrongBRL.GetByFK_iQuanHuyenID(oQuanHuyen.PK_iQuanHuyenID));
            if (lstCosonuoitrong != null && lstCosonuoitrong.Count > 0)
                DanhsachCosonuoitrong = lstCosonuoitrong;
        }
        napRepeater();
    }
    protected void btnXuatraExcel_Click(object sender, EventArgs e)
    {
        export2Excel("BaocaoThongkeCosonuoitrongTheoDoiTuongnuoi");
    }
    private void export2Excel(String sFilename)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xls", sFilename));
        Response.Charset = "UTF-8";
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptCosonuoitrongThongke.RenderControl(htmlWrite);
        Response.Write("<table cellSpacing='0' cellPadding='0' width='100%' align='center' border='1'");
        Response.Write(stringWrite.ToString());
        Response.Write("</table>");
        Response.End();
        
    }
    protected void rptCosonuoitrongThongke_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            Literal ltrHeader = (Literal)e.Item.FindControl("ltrHeader");
            ltrHeader.Text = "<h3>Thống kê thông tin về cơ sở nuôi trồng theo - "+ddlDoituongnuoi.SelectedItem.Text+"</h3>";
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            // Số hộ
            Chart barChartCosonuoi = (Chart)e.Item.FindControl("chartCosonuoiSoho");
            barChartCosonuoi.ChartType = ChartTypes.PieChart;
            DataTable dt = getDataSource(0);
            barChartCosonuoi.DataValueField = "value";
            barChartCosonuoi.DataLabelField = "category";
            barChartCosonuoi.ToolTip = "Tỉ lệ số hộ nuôi trồng theo đối tượng nuôi";
            barChartCosonuoi.ChartTitle = "Tỉ lệ số hộ";
            
            barChartCosonuoi.DataSource = dt;

            // Diện tích
            Chart chartCosonuoiDientich = (Chart)e.Item.FindControl("chartCosonuoiDientich");
            chartCosonuoiDientich.ChartType = ChartTypes.PieChart;
            dt = getDataSource(1);
            chartCosonuoiDientich.DataValueField = "value";
            chartCosonuoiDientich.DataLabelField = "category";
            chartCosonuoiDientich.ToolTip = "Tỉ lệ diện tích theo đối tượng nuôi";
            chartCosonuoiDientich.ChartTitle = "Tỉ lệ diện tích";
            chartCosonuoiDientich.DataSource = dt;

            // Sản lượng dự kiến
            Chart chartSanluong = (Chart)e.Item.FindControl("chartSanluong");
            chartSanluong.ChartType = ChartTypes.PieChart;
            dt = getDataSource(2);
            chartSanluong.DataValueField = "value";
            chartSanluong.DataLabelField = "category";
            
            chartSanluong.ToolTip = "Tỉ lệ sản lượng theo đối tượng nuôi";
            chartSanluong.ChartTitle = "Tỉ lệ sản lượng";

            chartSanluong.DataSource = dt;
        }
    }
    /// <summary>
    /// Lấy dữ liệu tổng hợp về Cơ sở nuôi trồng theo:
    /// </summary>
    /// <param name="bType"></param>
    /// 0: số hộ
    /// 1: diện tích
    /// 2: sản lượng dự kiến
    /// <returns>DataTable</returns>
    private DataTable getDataSource(byte bType)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("value", typeof(Int32));
        dt.Columns.Add("category", typeof(String));

        List<CosonuoitrongEntity> lstCosonuoitrong = new List<CosonuoitrongEntity>();
        List<DoituongnuoiEntity> lstDoituongnuoi = DoituongnuoiBRL.GetAll();

        switch(bType)
        {
            case 0:
                {
                    foreach (DoituongnuoiEntity oDoituongnuoi in lstDoituongnuoi)
                    {
                        //lstCosonuoitrong = CosonuoitrongBRL.GetByFK_iDoituongnuoiID(oDoituongnuoi.PK_iDoituongnuoiID);
                        if (DanhsachCosonuoitrong != null && DanhsachCosonuoitrong.Count > 0)
                        {
                            lstCosonuoitrong = DanhsachCosonuoitrong.FindAll(delegate(CosonuoitrongEntity oCosonuoitrong)
                            {
                                return oCosonuoitrong.FK_iDoituongnuoiID == oDoituongnuoi.PK_iDoituongnuoiID;
                            });
                        }
                        else
                            lstCosonuoitrong = CosonuoitrongBRL.GetByFK_iDoituongnuoiID(oDoituongnuoi.PK_iDoituongnuoiID);
                        int iSoho = lstCosonuoitrong.Count;
                        dt.Rows.Add(iSoho.ToString(), oDoituongnuoi.sTendoituong);
                    }
                    break;
                }
            case 1:
                {
                    foreach (DoituongnuoiEntity oDoituongnuoi in lstDoituongnuoi)
                    {
                        //lstCosonuoitrong = CosonuoitrongBRL.GetByFK_iDoituongnuoiID(oDoituongnuoi.PK_iDoituongnuoiID);
                        if (DanhsachCosonuoitrong != null && DanhsachCosonuoitrong.Count > 0)
                        {
                            lstCosonuoitrong = DanhsachCosonuoitrong.FindAll(delegate(CosonuoitrongEntity oCosonuoitrong)
                            {
                                return oCosonuoitrong.FK_iDoituongnuoiID == oDoituongnuoi.PK_iDoituongnuoiID;
                            });
                        }
                        else
                            lstCosonuoitrong = CosonuoitrongBRL.GetByFK_iDoituongnuoiID(oDoituongnuoi.PK_iDoituongnuoiID);
                        float fTongdientich = 0;
                        foreach (CosonuoitrongEntity oCosonuoi in lstCosonuoitrong)
                        {
                            fTongdientich += oCosonuoi.fTongdientich;
                        }
                        dt.Rows.Add(fTongdientich.ToString(), oDoituongnuoi.sTendoituong);
                    }
                    break;
                }
            case 2:
                {
                    foreach (DoituongnuoiEntity oDoituongnuoi in lstDoituongnuoi)
                    {
                        //lstCosonuoitrong = CosonuoitrongBRL.GetByFK_iDoituongnuoiID(oDoituongnuoi.PK_iDoituongnuoiID);
                        if (DanhsachCosonuoitrong != null && DanhsachCosonuoitrong.Count > 0)
                        {
                            lstCosonuoitrong = DanhsachCosonuoitrong.FindAll(delegate(CosonuoitrongEntity oCosonuoitrong)
                            {
                                return oCosonuoitrong.FK_iDoituongnuoiID == oDoituongnuoi.PK_iDoituongnuoiID;
                            });
                        }
                        else
                            lstCosonuoitrong = CosonuoitrongBRL.GetByFK_iDoituongnuoiID(oDoituongnuoi.PK_iDoituongnuoiID);
                        Int64 iTongsanluong = 0;
                        foreach (CosonuoitrongEntity oCosonuoi in lstCosonuoitrong)
                        {
                            iTongsanluong += oCosonuoi.iSanluongdukien;
                        }
                        dt.Rows.Add(iTongsanluong.ToString(), oDoituongnuoi.sTendoituong);
                    }
                    break;
                }
        }
        return dt;
    }

    protected void rptCosonuoitrongThongke_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
}

