using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class UserMethods_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null || Session["GroupID"] == null || Session["GroupID"].ToString() != "3")
        {
            Response.Write("<script>alert('Bạn không có quyền vào trang này');location='../default.aspx'</script>");
            Response.End();
        }
        if (Request.QueryString["mode"] != null)
        {

            string strControl ="~/UserMethods/" +   Request.QueryString["mode"] + ".ascx";
            if (File.Exists(Server.MapPath(strControl)))
            {
                Control ctrl = LoadControl(strControl);
                if (ctrl != null)
                {
                    plMain.Controls.Add(ctrl);
                }
            }
        }
    }
    protected void lbtDangXuat_Click(object sender, EventArgs e)
    {
        Session["UserID"] = "";
        string a = Session["UserID"].ToString();
        Session["UserName"] = "";
        Session.Abandon();
        Response.Redirect("../");
    }
}