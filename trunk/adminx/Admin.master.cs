using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Business;
using INVI.Entity;

public partial class CMS_CMS_5B : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //BuildMenu();
            if(Session["UserID"] != null)
            {
                int PK_iUser = int.Parse(Session["UserID"].ToString());
                List<TochucchungnhanTaikhoanEntity> lstTochucTaikhoan = TochucchungnhanTaikhoanBRL.GetByFK_iTaikhoanID(PK_iUser);
                if (lstTochucTaikhoan.Count > 0)
                {
                    lblTentochuc.Text = TochucchungnhanBRL.GetOne(lstTochucTaikhoan[0].FK_iTochucchungnhanID).sTochucchungnhan;
                    //Response.Redirect("Default.aspx?m=Tochucchungnhan&page=Dangkytochucchungnhan");
                }
            }
        }
        
    }
    protected void lbtDangXuat_Click(object sender, EventArgs e)
    {
        Session["UserID"] = "";
        string a = Session["UserID"].ToString();
        Session["UserName"] = "";
        Session.Remove("UserName");
        Session.Remove("UserID");
        Response.Redirect("../");
    }
    //private void BuildMenu()
    //{
    //    int GroupID = Convert.ToInt16(Session["GroupID"].ToString());
    //    //List<GroupPermissionEntity> lstper = LoadAllPer(Convert.ToInt32(Session["UserID"]));
    //    List<GroupPermissionEntity> lstper = GroupPermissionBRL.GetByiGroupID(GroupID);
    //    foreach (Control cl in this.form1.Controls)
    //    {
    //        String[] s = cl.ID.Split('_');
    //        if(s.Length>1)
    //            cl.Visible = SetVisible(lstper,Convert.ToInt16(s[1]));
    //    }
    //}
    //private bool SetVisible(List<GroupPermissionEntity> lstGP, int perID)
    //{
    //    int i = 0;
    //    lstGP.ForEach(
    //            delegate(GroupPermissionEntity oGP)
    //            {
    //                if (oGP.iPermissionID == perID)
    //                {
    //                    i = 1;                        
    //                }
    //            }
    //        );
    //    if (i == 1)
    //        return true;
    //    else
    //        return false;
    //}
    
}
