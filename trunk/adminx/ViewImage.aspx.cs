using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.Business;
using INVI.Entity;
public partial class adminx_ViewImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Request.QueryString["ID"]!=null)
            {
                if (Request.QueryString["type"] != null)
                {
                    String sType = Request.QueryString["type"].ToString();
                    if(sType.Equals("Chuyengia"))
                    {
                        ChuyengiaEntity entity;
                        entity = ChuyengiaBRL.GetOne(Convert.ToInt32(Request.QueryString["ID"]));
                        Byte[] bytImage = entity.imAnh;
                        if (bytImage != null)
                        {
                            Response.ContentType = "image/jpg";
                            Response.Expires = 0; Response.Buffer = true;
                            Response.Clear();
                            Response.BinaryWrite(bytImage);
                            Response.End();
                        }
                    }
                }
                else
                {
                    TochucchungnhanEntity entity;
                    entity = TochucchungnhanBRL.GetOne(Convert.ToInt32(Request.QueryString["ID"]));
                    Byte[] bytImage = entity.imgLogo;
                    if (bytImage !=null) 
                    {
                              Response.ContentType ="image/jpg"; 
                              Response.Expires = 0; Response.Buffer =true; 
                              Response.Clear(); 
                              Response.BinaryWrite(bytImage); 
                              Response.End();
                    }
                }
            }
        }
    }
}