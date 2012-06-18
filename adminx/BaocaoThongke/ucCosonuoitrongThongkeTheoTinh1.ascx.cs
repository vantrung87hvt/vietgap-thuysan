

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
public partial class adminx_BaocaoThongke_ucCosonuoitrongThongkeTheoTinh1 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            napGridParent();
           
        }
    }
   
    private void napGridParent()
    {
        List<TinhEntity> lstTinh = TinhBRL.GetAll();
        GridParent.DataSource = lstTinh;
        GridParent.DataKeyNames = new string[] { "PK_iTinhID" };        
        GridParent.DataBind();

    }


    protected void GridParent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         if (e.Row.RowType == DataControlRowType.DataRow)
           {
               GridView gv = (GridView)e.Row.FindControl("GridChild");        
              
               short PK_iTinhID = Convert.ToInt16(DataBinder.Eval(e.Row.DataItem, "PK_iTinhID"));              
               List<QuanHuyenEntity> lstQuanHuyen = QuanHuyenBRL.GetByFK_iTinhThanhID(PK_iTinhID);
               if (lstQuanHuyen.Count > 0)
               {
                   gv.DataSource = QuanHuyenEntity.Sort(lstQuanHuyen, "sTen", "ASC");
                   gv.DataBind();
               }
          }

    }
    protected void GridChild_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
         if (e.Row.RowType == DataControlRowType.DataRow)
           {
               GridView gv = (GridView)e.Row.FindControl("GridGrand");
               short PK_iQuanHuyenID = Convert.ToInt16(DataBinder.Eval(e.Row.DataItem, "PK_iQuanHuyenID"));
               List<CosonuoitrongEntity> lstCosonuoi = CosonuoitrongBRL.GetByFK_iQuanHuyenID(PK_iQuanHuyenID);
                   if (lstCosonuoi.Count > 0)
                   {
                       gv.DataSource = lstCosonuoi;                      
                       gv.DataBind();  
                   }
          }
    }

    protected void GridParent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridParent.PageIndex = e.NewPageIndex;
        napGridParent();
    }

    protected string FormatAddress(object sAp, object sXa)
    {       
            string addr = string.Format("{0},{1}", sAp,
                sXa);
            return addr.Trim(",".ToCharArray());     
        
    }
    /*
    public override void VerifyRenderingInServerForm(Control control)
    {  
    } 
     * */

    private void export2Excel(String sFilename)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xls", sFilename));
        Response.Charset = "UTF-8";
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        //bind lại gv
        GridParent.AllowPaging = false;
        napGridParent();

        HtmlForm frm = new HtmlForm();
        GridParent.Parent.Controls.Add(frm);
        frm.Attributes["runat"] = "server";
        frm.Controls.Add(GridParent);
        frm.RenderControl(htmlWrite);
 
        Response.Write("<table cellSpacing='0' cellPadding='0' width='100%' align='center' border='1'");
        Response.Write(stringWrite.ToString());
        Response.Write("</table>");
        Response.End();

    }
 
    protected void lnkXuatraExel_Click(object sender, EventArgs e)
    {
        INVI.INVILibrary.INVIHelper.PrepareGridViewForExport(GridParent);
        export2Excel("ThongkeCosonuoitrongTheoTinh");
    }
   
  
}