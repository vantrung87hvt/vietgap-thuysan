using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
public partial class Maps_Maps : MyUI
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
            Response.Write("<script>alert('Bạn không có quyền truy cập vào trang này');location='../Default.aspx';</script>");
        string strControl = String.Empty;
        if (Request.QueryString["mode"] != null)
        {
            if (Request.QueryString["mode"] == "uc")
            {
                strControl = Request.QueryString["mode"].ToString();
                strControl += Request.QueryString["page"] + ".ascx";
            }
        }
        loadCtr(strControl);
   }
    private void loadCtr(String strControl)
    {
        if (File.Exists(Server.MapPath(strControl)))
        {
            Control ctrl = LoadControl(strControl);
            if (ctrl != null)
            {
                phMain.Controls.Add(ctrl);
            }
        }
    }
}