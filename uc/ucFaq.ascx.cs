using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INVI.INVILibrary;
using INVI.Entity;
using INVI.DataAccess;
using INVI.Business;
public partial class uc_ucFaq : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            loadData2DdlCateFaq();
        }
    }
    private void loadData2DdlCateFaq()
    {
        try
        {
            ddlCategory.Items.Clear();
            List<CateFaqEntity> lstCategoryFaq = CateFaqBRL.GetAll();
            ddlCategory.DataSource = lstCategoryFaq;
            ddlCategory.DataTextField = "sCateName";
            ddlCategory.DataValueField = "PK_iFaqCateID";
            ddlCategory.DataBind();
            if (Session["Lang"].ToString() == "en-US")
                ddlCategory.Items.Insert(0, new ListItem("--- All ---", "0"));
            else
                ddlCategory.Items.Insert(0, new ListItem("--- Tất cả ---", "0"));
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            String strSearch = txtSearch.Text;
            List<FaqEntity> lstFaq = FaqBRL.GetAll();
            List<FaqEntity> lstResult = new List<FaqEntity>();
            int iFaqCateID = Convert.ToInt32(ddlCategory.SelectedValue.ToString());
            if (iFaqCateID != 0) // Kiểm tra xem có lựa chọn Chuyên mục không
            {
                if (txtSearch.Text.Length == 0 || txtSearch.Text == "")
                {
                    lstFaq.ForEach(
                    delegate(FaqEntity oFaq)
                    {
                        if (oFaq.FK_iFaqCateID == iFaqCateID)
                        {
                            lstResult.Add(oFaq);
                        }
                    }
                    );
                }
                else
                {
                    lstFaq.ForEach(
                    delegate(FaqEntity oFaq)
                    {
                        if (oFaq.sQuestion.ToUpper().Contains(strSearch.ToUpper()) && oFaq.FK_iFaqCateID == iFaqCateID)
                        {
                            lstResult.Add(oFaq);
                        }
                    }
                    );    
                }
            }
            else
            {
                if (txtSearch.Text.Length == 0 || txtSearch.Text == "")
                {
                    lstFaq.ForEach(
                        delegate(FaqEntity oFaq)
                        {
                            if (oFaq.sQuestion.ToUpper().Contains(strSearch.ToUpper()))
                            {
                                lstResult.Add(oFaq);
                            }
                        }
                    );
                }
                else
                {
                    lstResult = lstFaq;
                    //lstFaq.ForEach(
                    //    delegate(FaqEntity oFaq)
                    //    {
                    //            lstResult.Add(oFaq);
                    //    }
                    //);
                }
            }
            rptrResultFaq.DataSource = lstResult;
            rptrResultFaq.DataBind();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

}