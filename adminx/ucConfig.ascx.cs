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
using INVI.Business;
using INVI.Entity;
public partial class UC_ucConfig : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!PermissionBRL.CheckPermission("EditConfig")) Response.End();
        if (!IsPostBack)
        {
            ddlConfig_loadData();
            pnlNoidung.Visible = false;
        }
    }
    private void ddlConfig_loadData()
    {
        ddlConfigName.Items.Clear();
        List<ConfigEntity> lstConfig = ConfigBRL.GetAll();
        ddlConfigName.DataSource = lstConfig;
        ddlConfigName.DataTextField = "sName";
        ddlConfigName.DataValueField = "iConfigID";
        ddlConfigName.DataBind();
        ddlConfigName.Items.Insert(0, new ListItem("-- Chọn --","0"));
    }
    
    protected void ddlConfigName_SelectedIndexChanged(object sender, EventArgs e)
    {
        int iConfigID = Int16.Parse(ddlConfigName.SelectedItem.Value);
        //txtConfigValue.Text = 
        if (iConfigID > 0)
        {
            ConfigEntity oConfig = ConfigBRL.GetOne(iConfigID);
            ftbNoidung.Text = oConfig.sValue;
            pnlNoidung.Visible = true;
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        
            Page.Validate("vgConfig");
            if (Page.IsValid)
            {
                bool bSuccessed=false;
                try
                {
                    ConfigEntity oConfig = new ConfigEntity();
                    oConfig.sName = ddlConfigName.SelectedItem.Text;
                    oConfig.sValue = ftbNoidung.Text;
                    oConfig.iConfigID = Convert.ToInt32(ddlConfigName.SelectedValue);
                    bSuccessed=ConfigBRL.Edit(oConfig);
                    //Nạp lại dữ liệu
                    //Response.Redirect(Request.Url.ToString());
                    ddlConfigName.ClearSelection();
                    pnlNoidung.Visible = false;
                }
                catch (Exception ex)
                {
                    lblThongbao.Text = ex.Message;
                }
                if(bSuccessed==true)
                    lblThongbao.Text = Resources.language.capnhapthanhcong;
            }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnOK.Text = Resources.language.sua;
        pnlNoidung.Visible = false;
    }
}
