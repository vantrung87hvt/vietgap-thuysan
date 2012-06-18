using INVI.Entity;
using INVI.Business;
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
using System.Collections.Generic;

public partial class uc_header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<CategoryEntity> lstCat = CategoryBRL.GetByTopID(15);
            if(lstCat.Count>8)lstCat.RemoveRange(8, lstCat.Count-8);
            foreach (CategoryEntity oCat in lstCat)
            {
                System.Web.UI.WebControls.MenuItem mnuTopItem = new System.Web.UI.WebControls.MenuItem();
                mnuTopItem.Text = oCat.sTitle;
                mnuTopItem.NavigateUrl = "~/Category.aspx?catID=" + oCat.iCategoryID;
                List<CategoryEntity> lstChild = CategoryBRL.GetByTopID(oCat.iCategoryID);
                foreach (CategoryEntity oChildCat in lstChild)
                {
                    System.Web.UI.WebControls.MenuItem mnuChildItem = new System.Web.UI.WebControls.MenuItem();
                    mnuChildItem.Text = oChildCat.sTitle;
                    mnuChildItem.NavigateUrl = "~/Category.aspx?catID=" + oChildCat.iCategoryID;
                    mnuTopItem.ChildItems.Add(mnuChildItem);
                }
                mnuTopCat.Items.Add(mnuTopItem);
            }
        }
    }
}
