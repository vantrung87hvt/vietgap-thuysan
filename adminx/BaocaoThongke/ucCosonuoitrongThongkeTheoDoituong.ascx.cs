

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using INVI.Entity;
using INVI.DataAccess;
using INVI.Business;
using System.Data;
public partial class adminx_BaocaoThongke_ucCosonuoitrongThongkeTheoDoituong : System.Web.UI.UserControl
{
    private static List<TinhEntity> lstTinh = null;
    private static List<QuanHuyenEntity> lstHuyen = null;
    private static List<CosonuoitrongEntity> lstCoso = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!PermissionBRL.CheckPermission("Truycapthongketheodoituong")) Response.End();
        if (!Page.IsPostBack)
        {
            napDoituong();
        }
    }

    public void napDoituong()
    {
        ddlDoituongnuoi.Items.Clear();
        List<DoituongnuoiEntity> lstDoituongnuoi = DoituongnuoiBRL.GetAll();
        ddlDoituongnuoi.DataSource = lstDoituongnuoi;
        ddlDoituongnuoi.DataTextField = "sTendoituong";
        ddlDoituongnuoi.DataValueField = "PK_iDoituongnuoiID";
        ddlDoituongnuoi.DataBind();
        ddlDoituongnuoi.Items.Insert(0, new ListItem("--- Chọn ---", "0"));
    }
   
    private void napgrvTinh()
    {
        List<TinhEntity> lstTinh = TinhBRL.GetAll();
        grvTinh.DataSource = lstTinh;
        grvTinh.DataKeyNames = new string[] { "PK_iTinhID" };        
        grvTinh.DataBind();
    }


    protected void grvTinh_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
               GridView grvHuyen = (GridView)e.Row.FindControl("grvHuyen");        
               short PK_iTinhID = Convert.ToInt16(DataBinder.Eval(e.Row.DataItem, "PK_iTinhID"));
               List<QuanHuyenEntity> lstHuyenTmp = new List<QuanHuyenEntity>();
               lstHuyen.ForEach
                (
                    delegate(QuanHuyenEntity oHuyen)
                    {
                        if (oHuyen.FK_iTinhThanhID == PK_iTinhID)
                        {
                            lstHuyenTmp.Add(oHuyen);
                        }
                    }
                );
               if (lstHuyenTmp.Count > 0)
               {
                   grvHuyen.DataSource = QuanHuyenEntity.Sort(lstHuyenTmp, "sTen", "ASC");
                   grvHuyen.DataBind();
               }
          }
    }
    protected void grvHuyen_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
               GridView grvCoso = (GridView)e.Row.FindControl("grvCoso");
               short PK_iQuanHuyenID = Convert.ToInt16(DataBinder.Eval(e.Row.DataItem, "PK_iQuanHuyenID"));
               List<CosonuoitrongEntity> lstCosoTmp = new List<CosonuoitrongEntity>();
               lstCoso.ForEach
                (
                    delegate(CosonuoitrongEntity oCoso)
                    {
                        if (oCoso.FK_iQuanHuyenID == PK_iQuanHuyenID)
                        {
                            lstCosoTmp.Add(oCoso);
                        }
                    }
                );
               if (lstCosoTmp.Count > 0)
               {
                   grvCoso.DataSource = CosonuoitrongEntity.Sort(lstCosoTmp, "sTencoso", "ASC");
                   grvCoso.DataBind();
               }
          }
    }

    protected void grvTinh_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTinh.PageIndex = e.NewPageIndex;
        napgrvTinh();
    }

    protected string FormatAddress(object sAp, object sXa)
    {       
            string addr = string.Format("{0},{1}", sAp,
                sXa);
            return addr.Trim(",".ToCharArray());     
        
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
        INVI.INVILibrary.INVIHelper.PrepareGridViewForExport(grvTinh);
        HtmlForm frm = new HtmlForm();

        grvTinh.Parent.Controls.Add(frm);
        frm.Attributes["runat"] = "server";
        frm.Controls.Add(grvTinh);
        frm.RenderControl(htmlWrite);
        
        Response.Write("<table cellSpacing='0' cellPadding='0' width='100%' align='center' border='1'");
        Response.Write(stringWrite.ToString());
        Response.Write("</table>");
        Response.End();
    }
 
    protected void lnkXuatraExel_Click(object sender, EventArgs e)
    {
        export2Excel("ThongkeCosonuoitrongTheoDoituongnuoi");
    }

    protected void btnXem_Click(object sender, EventArgs e)
    {
        lstTinh = null;
        lstHuyen = null;
        lstCoso = null;
        lstTinh = new List<TinhEntity>();
        lstHuyen = new List<QuanHuyenEntity>();
        lstCoso = new List<CosonuoitrongEntity>();
        int iTongso = 0;
        int PK_iDoituongID = int.Parse(ddlDoituongnuoi.SelectedValue);
        if (PK_iDoituongID > 0)
        {
            lstCoso = CosonuoitrongBRL.GetAll();
            
            //Lấy các hộ đã được cấp VietGAP
            lstCoso = lstCoso.FindAll(
            delegate(CosonuoitrongEntity oCoso)
            {
                return oCoso.sMaso_vietgap != "" && oCoso.bDuyet == true;
            }
            );
            iTongso = lstCoso.Count;
            //Lấy các hộ nuôi theo đối tượng
            lstCoso = lstCoso.FindAll(
            delegate(CosonuoitrongEntity oCoso)
            {
                return oCoso.FK_iDoituongnuoiID == PK_iDoituongID;
            }
            );

            for (int i = 0; i < lstCoso.Count; ++i)
            {
                QuanHuyenEntity oHuyen = QuanHuyenBRL.GetOne(lstCoso[i].FK_iQuanHuyenID);
                if (!lstHuyen.Exists(delegate (QuanHuyenEntity oQuanHuyen){return oQuanHuyen.PK_iQuanHuyenID == oHuyen.PK_iQuanHuyenID;}))
                {   
                    lstHuyen.Add(oHuyen);
                    TinhEntity oTinh = TinhBRL.GetOne(oHuyen.FK_iTinhThanhID);
                    if (!lstTinh.Exists(delegate(TinhEntity oTinhThanh) { return oTinhThanh.PK_iTinhID == oTinh.PK_iTinhID; }))
                    { 
                        lstTinh.Add(oTinh);
                    }
                }
                
            }
            //-------------------Hiện
            panTomtat.Visible = true;
            lblTranghthai.Text = "Có " + lstCoso.Count + " hộ nuôi " + ddlDoituongnuoi.SelectedItem.Text + " trên tổng số " + iTongso.ToString();
            lblSotinh.Text = lstTinh.Count.ToString();
            lblSohuyen.Text = lstHuyen.Count.ToString();
            lblSoho.Text = lstCoso.Count.ToString();
            grvTinh.DataSource = lstTinh;
            grvTinh.DataKeyNames = new string[] { "PK_iTinhID" };
            grvTinh.DataBind();
        }
    }
}