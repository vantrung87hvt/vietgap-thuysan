using INVI.Entity;
using INVI.Business;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
public partial class adminx_ucCachochuacapphep : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!PermissionBRL.CheckPermission("QuanlyCSNT")) Response.End();
            napGridView();
        }
    }
    private void napGridView()
    {
        List<CosonuoitrongEntity> list = CosonuoitrongBRL.GetAll().FindAll(delegate(CosonuoitrongEntity oCosonuoitrong) { return oCosonuoitrong.bDuyet == false; });
        grvCosonuoitrong.DataSource = list;
        grvCosonuoitrong.DataKeyNames = new string[] { "PK_iCosonuoitrongID" };
        grvCosonuoitrong.DataBind();
    }
    
    protected void lbtnVerify_Click(object sender, EventArgs e)
    {
        // Kiểm duyệt thì phải cấp mã cơ sở - mã của Tổ chức chứng nhận
        if (!PermissionBRL.CheckPermission("VerifyCosonuoitrong")) Response.End();
        String sMasovietgap = String.Empty;
        foreach (GridViewRow row in grvCosonuoitrong.Rows)
        {
            CheckBox chk = row.FindControl("chkVerify") as CheckBox;
            int PK_iCosonuoitrongID = Convert.ToInt32(grvCosonuoitrong.DataKeys[row.RowIndex].Values["PK_iCosonuoitrongID"]);
            if (chk != null&&chk.Checked==true)
            {
                CosonuoitrongEntity oCosonuoitrong = CosonuoitrongBRL.GetOne(PK_iCosonuoitrongID);
                oCosonuoitrong.bDuyet = chk.Checked;
                CosonuoitrongBRL.Edit(oCosonuoitrong);
            }
        }
        //Nap lai du lieu
        Response.Redirect(Request.Url.ToString());
    }
    
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                if (!PermissionBRL.CheckPermission("DeleteCosonuoitrong")) Response.End();
                foreach (GridViewRow row in grvCosonuoitrong.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    if (chkDelete != null && chkDelete.Checked)
                    {
                        int PK_iCosonuoitrongID = Convert.ToInt32(grvCosonuoitrong.DataKeys[row.RowIndex].Values["PK_iCosonuoitrongID"]);
                        CosonuoitrongBRL.Remove(PK_iCosonuoitrongID);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=Cachochuacapphep';</script>");
            }
        }

    }
    
   
    private String sTentinhthanh(int iTinhthanhID)
    {
        String sTentinhthanh = String.Empty;
        TinhEntity oTinhthanh = TinhBRL.GetOne((byte)iTinhthanhID);
        if(oTinhthanh!=null)
            sTentinhthanh = oTinhthanh.sTentinh;
        return sTentinhthanh;
    }
    private String getTendoituongnuoi(byte iDoituongnuoiID)
    {
        String sDoituongnuoi = String.Empty;
        DoituongnuoiEntity oDoituongnuoi = DoituongnuoiBRL.GetOne(iDoituongnuoiID);
        if(oDoituongnuoi!=null)
            sDoituongnuoi = oDoituongnuoi.sTendoituong;
        return sDoituongnuoi;
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        napGridView();
    }
    protected void btnSearchByID_Click(object sender, EventArgs e)
    {
        string strSearch = txtSearchByID.Text;
        int iHo = 0;
        if (txtID.Text.Length == 0 || txtID.Text == "")
            iHo = 0;
        else iHo = Int16.Parse(txtID.Text);
        List<CosonuoitrongEntity> lstCSNT = CosonuoitrongBRL.GetAll();
        if (iHo == 0)
        {
            lstCSNT = lstCSNT.FindAll(
            delegate(CosonuoitrongEntity oCSNT)
            {
                return oCSNT.sTencoso.ToUpper().Contains(strSearch.ToUpper()) && oCSNT.bDuyet == false;
            }
            );
        }
        else
        {
            lstCSNT = lstCSNT.FindAll(
            delegate(CosonuoitrongEntity oCSNT)
            {
                return oCSNT.PK_iCosonuoitrongID == iHo && oCSNT.bDuyet == false;
            }
            );
        }
        lblThongbao.Text = "";
        grvCosonuoitrong.DataSource = lstCSNT;
        grvCosonuoitrong.DataKeyNames = new string[] { "PK_iCosonuoitrongID" };
        grvCosonuoitrong.DataBind();
    }
    
    protected void grvCosonuoitrong_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int csntID = Convert.ToInt32(grvCosonuoitrong.DataKeys[e.NewSelectedIndex].Values["PK_iCosonuoitrongID"]);
        Session["iCosonuoitrongID"] = csntID.ToString(); ;
        Response.Redirect("~/adminx/Default.aspx?page=../uc/ucCosonuoitrongUpdate");
    }
    protected void grvCosonuoitrong_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblTinhthanh = null, lblDoituongnuoi = null;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            lblTinhthanh = (Label)e.Row.FindControl("lblTinhthanh");
            lblDoituongnuoi = (Label)e.Row.FindControl("lblDoituongnuoi");
            if (lblTinhthanh != null)
            {
                int bTinhthanhID = int.Parse(lblTinhthanh.Text);
                lblTinhthanh.Text = sTentinhthanh(bTinhthanhID);
            }
            if (lblDoituongnuoi != null)
            {
                byte bDoituongnuoiID = byte.Parse(lblDoituongnuoi.Text);
                lblDoituongnuoi.Text = getTendoituongnuoi(bDoituongnuoiID);
            }
        }

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Attributes.Add("onmouseover", "MouseEvents(this, event)");
        //    e.Row.Attributes.Add("onmouseout", "MouseEvents(this, event)");
        //}
        
    }
    protected void grvCosonuoitrong_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SortDirection"] == null)
            ViewState["SortDirection"] = "ASC";
        else
        {
            ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        List<CosonuoitrongEntity> list = CosonuoitrongBRL.GetAll().FindAll(delegate(CosonuoitrongEntity oCosonuoitrong) { return oCosonuoitrong.bDuyet == false; });
        grvCosonuoitrong.DataSource = CosonuoitrongEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
        grvCosonuoitrong.DataKeyNames = new string[] { "PK_iCosonuoitrongID" };
        grvCosonuoitrong.DataBind();
    }
    protected void grvCosonuoitrong_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvCosonuoitrong.PageIndex = e.NewPageIndex;
        napGridView();
    }
    protected void grvCosonuoitrong_RowCreated(object sender, GridViewRowEventArgs e)
    {
            
    }
}