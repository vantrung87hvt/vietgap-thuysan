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

public partial class adminx_AdvManager : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!PermissionBRL.CheckPermission("Dangquangcao")) Response.End();
            this.napNhomcaptren(0, Server.HtmlDecode("&nbsp;"));
            ddlPosition_loadData();
            if (Request.QueryString["do"] != null && Request.QueryString["do"] == "add")
            {
                //if (!PermissionBRL.CheckPermission("ManagerAdv")) Response.End();
                setText("");

            }
            else if (Session["AdvID"] != null)
            {
                //if (!PermissionBRL.CheckPermission("ManagerAdv")) Response.End();
                int AdvID = Convert.ToInt32(Session["AdvID"]);

                this.napForm(AdvID);
                btnOK.CommandName = "Edit";
                btnOK.Text = "Lưu";
                btnOK.CommandArgument = AdvID.ToString();

            }
            else
                Response.Redirect("~/adminx/Default.aspx");
        }
    }
    /// <summary>
    /// Nạp danh sách nhóm cấp trên ra listbox
    /// </summary>
    /// <param name="newsID"></param>
    /// <param name="sCap"></param>
    private void napNhomcaptren(int categoryID, string sCap)
    {
        List<CategoryEntity> lstCat = CategoryBRL.GetByTopID(categoryID);
        foreach (CategoryEntity oCat in lstCat)
        {
            ListItem item = (new ListItem(sCap + oCat.sTitle, oCat.iCategoryID.ToString()));
            lstbNhomtin.Items.Add(item);
            napNhomcaptren(oCat.iCategoryID, Server.HtmlDecode("&nbsp;") + sCap + "-");
        }//foreach

    }
    private void napForm(int iAdvID)
    {
        AdvEntity oAdv = AdvBRL.GetOne(iAdvID);
        if (oAdv != null)
        {
            txtAdvDesc.Text = oAdv.sDesc;
            txtLink.Text = oAdv.sLink;
            txtMedia.Text = oAdv.sMedia;
            txtOrder.Text = oAdv.iOrder.ToString();
            txtTitle.Text = oAdv.sTitle;
            cboType.ClearSelection();
            cboType.Items.FindByValue(oAdv.iType.ToString()).Selected = true;
            txtWidth.Text = oAdv.iWidth.ToString();
            txtHeight.Text = oAdv.iHeight.ToString();
            ddlPosition.ClearSelection();
            
            ddlPosition.Items.FindByValue(oAdv.iPositionID.ToString()).Selected = true;
            
            //List nhóm tin
            lstbNhomtin.ClearSelection();
            AdvCategoryBRL.GetByiAdvID(iAdvID).ForEach(
                delegate(AdvCategoryEntity oAdvCat)
                {
                    lstbNhomtin.Items.FindByValue(oAdvCat.iCategoryID.ToString()).Selected = true;
                }
            );
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        Page.Validate("vgQuangcao");
        if (Page.IsValid)
        {
            int Result = 0;
                try
                {
                    AdvEntity oAdv = new AdvEntity();
                    oAdv.sTitle = txtTitle.Text;
                    oAdv.sMedia = txtMedia.Text;
                    oAdv.sLink = txtLink.Text;
                    oAdv.sDesc = txtAdvDesc.Text;
                    oAdv.iOrder = Byte.Parse(txtOrder.Text);
                    oAdv.iType = Byte.Parse(cboType.SelectedValue);
                    oAdv.iWidth = Convert.ToInt16(txtWidth.Text);
                    oAdv.iHeight = Convert.ToInt16(txtHeight.Text);
                    oAdv.iPositionID = Convert.ToInt32(ddlPosition.SelectedValue);
                    if (btnOK.CommandName == "Edit")
                    {
                        oAdv.iAdvID = Convert.ToInt32(btnOK.CommandArgument);
                        bool resultEdit = AdvBRL.Edit(oAdv);
                        //Cập nhật trong AdvCategory
                        foreach (ListItem item in lstbNhomtin.Items)
                        {
                            try
                            {
                                int categoryID = Convert.ToInt32(item.Value);
                                if (!item.Selected)
                                {
                                    AdvCategoryBRL.RemoveByiCategoryID(categoryID);
                                }
                                else
                                {

                                    AdvCategoryEntity oAdvCat = new AdvCategoryEntity();
                                    oAdvCat.iAdvID = oAdv.iAdvID;
                                    oAdvCat.iCategoryID = categoryID;
                                    AdvCategoryBRL.Add(oAdvCat);
                                }
                            }
                            catch { }

                        }
                        if (resultEdit) lblThongbao.Text = Resources.language.capnhapthanhcong;

                    }
                    else
                    {
                        Result = AdvBRL.Add(oAdv);
                        //Thêm bản ghi vào tblAdvCategory
                        if (Result > 0)
                        {
                            foreach (ListItem item in lstbNhomtin.Items)
                            {
                                if (item.Selected)
                                {
                                    AdvCategoryEntity oAdvCat = new AdvCategoryEntity();
                                    oAdvCat.iAdvID = Result;
                                    oAdvCat.iCategoryID = Convert.ToInt32(item.Value);
                                    AdvCategoryBRL.Add(oAdvCat);
                                }
                            }
                        }
                    }

                    if (Result > 0) lblThongbao.Text = Resources.language.quangcaodaduocthietlap;
                    Response.Redirect(Request.Url.ToString());
                }
                catch (Exception ex)
                { lblThongbao.Text = ex.Message; }
            
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        setText("");
        btnOK.Text = Resources.language.them;
        cboType.ClearSelection();
        ddlPosition.ClearSelection();
        lstbNhomtin.ClearSelection();
    }
    private void setText(String sText)
    {
        txtTitle.Text = sText;
        txtOrder.Text = sText;
        txtMedia.Text = sText;
        txtLink.Text = sText;
        txtAdvDesc.Text = sText;
        btnOK.CommandName = "Add";
    }
    private void ddlPosition_loadData()
    {
        ddlPosition.Items.Clear();
        List<PositionEntity> lstPosition = PositionBRL.GetAll();
        foreach (PositionEntity oPos in lstPosition)
        {
            ListItem item = (new ListItem(oPos.sName, oPos.iPositionID.ToString()));

            ddlPosition.Items.Add(item);

        }//foreach
        ddlPosition.SelectedIndex = 0;
    }
}
