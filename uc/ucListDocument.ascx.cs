using INVI.Entity;
using INVI.Business;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

public partial class uc_ListDocument : System.Web.UI.UserControl
{
    private byte m_pagesize = 5;
    public int iStt = 1;
    protected int currentPage = 0;
    public byte PageSize
    {
        get { return m_pagesize; }
        set { m_pagesize = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            LoadLoaiVanBan();

            try
            {
                if (Session["currentDocPage"] != null)
                    try
                    {
                        currentPage = Convert.ToInt32(Session["currentDocPage"]);
                    }
                    catch { }
                bindDoc(currentPage);
            }
            catch { }
        }

    }
    private void LoadLoaiVanBan()
    {
        try
        {
            ddlLoaiVanBan.Items.Clear();
            List<LoaivanbanEntity> lstLoaivanban = LoaivanbanBRL.GetAll();
            //lstLoaivanban.Sort();
            ddlLoaiVanBan.DataSource = lstLoaivanban;
            ddlLoaiVanBan.DataValueField = "PK_iLoaivanbanID";
            ddlLoaiVanBan.DataTextField = "sTenloai";
            ddlLoaiVanBan.DataBind();
            if (Session["Lang"].ToString()=="vi-VN")
                ddlLoaiVanBan.Items.Insert(0, new ListItem("-- Chọn --", "0"));
            else
                ddlLoaiVanBan.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        catch (Exception ex)
        {

        }
            
    }
    private void bindDoc(int currentPage)
    {
       
        List<DocumentEntity> lst = DocumentBRL.GetAll();
        if (txtNoiDung.Text.Trim().Length > 0)
        {
           lst =  lst.FindAll(delegate(DocumentEntity oDoc) { return (oDoc.sTitle.Contains(txtNoiDung.Text) ||oDoc.sDesc.Contains(txtNoiDung.Text)) ; });
        }
        if (txtSoKyHieu.Text.Trim().Length > 0)
        {
            lst = lst.FindAll(delegate(DocumentEntity oDoc) { return oDoc.sSokyhieu.Contains(txtSoKyHieu.Text); });
        }
        if (ddlLoaiVanBan.SelectedValue!="0")
        {
            lst = lst.FindAll(delegate(DocumentEntity oDoc) { return oDoc.FK_iLoaivanbanID.ToString() == ddlLoaiVanBan.SelectedValue; });
        }
        lst.Sort(DocumentEntity.COMPARISON_tDate);
        lst.Reverse();
        PagedDataSource pds = new PagedDataSource();
        pds.PageSize = m_pagesize;
        pds.CurrentPageIndex = currentPage > 0 ? currentPage : 0;
        pds.DataSource = lst;
        pds.AllowPaging = true;
        
        rptrDocument.DataSource = pds;
        rptrDocument.DataBind();
        lbnPrev.Visible = currentPage > 0 ? true : false;
        //lnkNext.Visible = currentPage != 0 && currentPage < pds.PageCount ? true : false;
        lbnNext.Visible = currentPage==0 || currentPage < pds.PageCount-1 ? true : false;
        lst.Clear();

    }
    protected void lbnPrev_Click(object sender, EventArgs e)
    {
        Session["currentDocPage"] = currentPage - 1;
        Response.Redirect("~/Content.aspx?mode=uc&page=ListDocument");
    }
    protected void lbnNext_Click(object sender, EventArgs e)
    {
        Session["currentDocPage"] = currentPage + 1;
        Response.Redirect("~/Content.aspx?mode=uc&page=ListDocument");
    }
    protected void btnTimKiem_Click(object sender, EventArgs e)
    {
        try
        {
            Session["currentDocPage"] = 0;
            if (Session["currentDocPage"] != null)
                try
                {
                    currentPage = Convert.ToInt32(Session["currentDocPage"]);
                }
                catch { }
            bindDoc(currentPage);
        }
        catch { }
    }
}
