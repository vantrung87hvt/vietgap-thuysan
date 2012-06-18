using INVI.Business;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class ucThongKe : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            int GroupID = Convert.ToInt32(Session["GroupID"].ToString());
            if (GroupID == 4 || GroupID == 1 || GroupID == 2)
            {
                if (Path.GetFileName(Request.PhysicalPath).ToString().ToUpper() == "DEFAULT.ASPX")
                {
                    pnAll.Visible = false;
                    pnOne.Visible = true;
                    Literal1.Visible = true;
                }
                else
                {
                    pnAll.Visible = true;
                    pnOne.Visible = false;
                    lblHomNayd.Text = CounterBRL.VisitorInCurrentDay().ToString();
                    lblHomQuad.Text = CounterBRL.VisitorInTomorow().ToString();
                    lblTatCad.Text = CounterBRL.GetAll().Count.ToString();
                    lblTuanNayd.Text = CounterBRL.VisitorInCurrentWeek().ToString();
                    lblTuanTruocd.Text = CounterBRL.VisitorInBeforeWeek().ToString();
                    lblThangNayd.Text = CounterBRL.VisitorInCurrentMonth().ToString();
                    lblThangTruocd.Text = CounterBRL.VisitorInBeforeMonth().ToString();
                    Literal1.Visible = true;
                }
            }
        }
        else
        {
            pnAll.Visible = false;
            pnOne.Visible = false;
            this.Visible = false;
            Literal1.Visible = false;
        }
        
    }

}
