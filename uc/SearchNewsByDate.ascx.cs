using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class uc_SearchNewsByDate : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = 1; i <= 31; i++)
                ddlDay.Items.Add(i.ToString());
            for (int i = 1; i <= 12; i++)
                ddlMonth.Items.Add(i.ToString());
            for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 5; i--)
                ddlYear.Items.Add(i.ToString());
            ddlDay.Items.FindByText(DateTime.Now.Day.ToString()).Selected=true;
            ddlMonth.Items.FindByText(DateTime.Now.Month.ToString()).Selected=true;
        }
    }
    protected void btnSearchByDate_Click(object sender, EventArgs e)
    {
        string day=Convert.ToInt32(ddlDay.SelectedItem.Text)>9?ddlDay.SelectedItem.Text:"0"+ddlDay.SelectedItem.Text;
        string month=Convert.ToInt32(ddlMonth.SelectedItem.Text)>9?ddlMonth.SelectedItem.Text:"0"+ddlMonth.SelectedItem.Text;
        Response.Redirect("~/Category.aspx?date=" + day + "/" + month + "/" + ddlYear.SelectedItem.Text);
    }
}
