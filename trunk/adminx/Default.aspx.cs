using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class adminx_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null || Session["GroupID"] == null)
        {
            Response.Write("<script>alert('Bạn không có quyền vào trang này');location='./Logon.aspx'</script>");
            Response.End();
        }
        if (Request.QueryString["page"] != null)
        {
            string strControl = "~/adminx/"; // thư mục admin
            if (Request.QueryString["m"] != null) // nếu tham số m khác null
            {
                strControl += Request.QueryString["m"]+"/"; // gắn với thư mục
            }//BaocaoThongke/
            if(Request.QueryString["ctr"]!=null&&Request.QueryString["ctr"]=="uc") // nếu có tham số ctr thì load từ thư mục uc nên phải loại cái uc ở trước
                strControl += "../uc/uc"+Request.QueryString["page"] + ".ascx";
            else
                strControl += "uc"+ Request.QueryString["page"] + ".ascx";

            if (File.Exists(Server.MapPath(strControl)))
            {
                Control ctrl = LoadControl(strControl);
                if (ctrl != null)
                {
                    phMain.Controls.Add(ctrl);
                }
            }
        }
        //if (!Page.IsPostBack)
        //{
        //    int iGroupID = Convert.ToInt32(Session["GroupID"].ToString());
        //    if(iGroupID==4)
                
        //}
    }
}
