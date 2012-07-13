using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class adminx_Tochucchungnhan_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["UserID"] == null || Session["GroupID"] == null)
        {
            Response.Write("<script>alert('Bạn không có quyền vào trang này');location='../Logon.aspx'</script>");
            Response.End();
        }

        if (Request.QueryString["page"] != null)
        {
            string strControl = "~/adminx/Tochucchungnhan/"; // thư mục admin/Tochucchungnhan
            if (Request.QueryString["m"] != null) // nếu tham số m khác null
            {
                strControl += Request.QueryString["m"] + "/"; // gắn với thư mục
            }//BaocaoThongke/
            if (Request.QueryString["ctr"] != null)
            {
                if (Request.QueryString["ctr"] == "uc") // nếu có tham số ctr thì load từ thư mục uc nên phải loại cái uc ở trước
                    strControl = "../../uc/uc" + Request.QueryString["page"] + ".ascx";
                else if (Request.QueryString["ctr"] == "adm") // lấy từ thư mục admin
                    strControl = "../uc" + Request.QueryString["page"] + ".ascx";
                else if (Request.QueryString["ctr"] == "tk") // lấy từ thư mục admin
                    strControl = "../BaocaoThongke/uc" + Request.QueryString["page"] + ".ascx";
            }
            else
                strControl += "uc" + Request.QueryString["page"] + ".ascx";

            if (File.Exists(Server.MapPath(strControl)))
            {
                Control ctrl = LoadControl(strControl);
                if (ctrl != null)
                {
                    phMain.Controls.Add(ctrl);
                }
            }
        }
        else if (!Page.IsPostBack) // Tự động hiển thị luôn danh sách các Cơ sở nuôi trồng đăng ký.
        {
            string strControl = "~/adminx/Tochucchungnhan/"; // thư mục admin/Tochucchungnhan
            strControl += "uc" + "DanhsachHosodangky.ascx";

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
}