using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.INVILibrary;
using INVI.Entity;
using INVI.Business;
public partial class uc_ucActiveAccount : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["code"] != null)
            {
                Active(Request.QueryString["code"]);

            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
        
           
    }
    private void Active(string code)
    {
        List<UserEntity> lstUser = UserBRL.GetAll();
        lstUser.ForEach(
            delegate(UserEntity oUser)
            {
                if (INVISecurity.MD5(oUser.sUsername) == code)
                {
                    oUser.bActive = true;
                    UserBRL.Edit(oUser);
                    Response.Write("<script>alert('Kích hoạt thành công!');location='Default.aspx';</script>");
                    return;
                }
            }
            );
    }
}