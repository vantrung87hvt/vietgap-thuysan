using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Entity;
using INVI.Business;
using INVI.INVILibrary;

public partial class Maps_ucBandoCosonuoitrong : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            napTinh();
            LoadQuanHuyen(Convert.ToInt32(ddlTinh.SelectedValue));
        }
        //if (!ClientScript.IsStartupScriptRegistered("load"))
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(),
        //        "load", "load();", true);
        //}
    }
    protected void ddlTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadQuanHuyen(Convert.ToInt32(ddlTinh.SelectedValue));
    }
    protected void napTinh()
    {
        ddlTinh.Items.Clear();
        List<TinhEntity> lstTinh = TinhBRL.GetAll();
        ddlTinh.DataSource = lstTinh;
        ddlTinh.DataTextField = "sTentinh";
        ddlTinh.DataValueField = "PK_iTinhID";
        ddlTinh.DataBind();
    }
    private void LoadQuanHuyen(int fk_Tinh)
    {
        ddlHuyen.Items.Clear();
        List<QuanHuyenEntity> lst = QuanHuyenBRL.GetByFK_iTinhThanhID(Convert.ToInt16(fk_Tinh));
        ddlHuyen.DataSource = lst;
        ddlHuyen.DataTextField = "sTen";
        ddlHuyen.DataValueField = "PK_iQuanHuyenID";

        ddlHuyen.DataBind();
        ddlHuyen.SelectedIndex = 0;
    }
}