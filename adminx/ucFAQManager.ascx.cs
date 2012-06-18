using INVI.Entity;
using INVI.Business;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Globalization;
using Aspose.Words;

namespace INVI.INVINews.Admin
{
    public partial class DocumentManager : System.Web.UI.UserControl
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!PermissionBRL.CheckPermission("ManagerFAQ")) Response.End();
            if (!IsPostBack)
            {
                this.napGridView();
                napDdlLoaicauhoi();
            }
        }

        private void napGridView()
        {
            grvFAQ.DataSource = FaqBRL.GetAll();
            grvFAQ.DataKeyNames = new string[] { "PK_iFaqID" };
            grvFAQ.DataBind();
        }      
        protected void grvFAQ_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int faqID = Convert.ToInt32(grvFAQ.DataKeys[e.NewSelectedIndex].Values["PK_iFaqID"]);
            btnOK.CommandName = "Edit";
            btnOK.Text = "Sửa";
            btnOK.CommandArgument = faqID.ToString();
            btnOK.CausesValidation = false;
            napForm(faqID);
        }
        public void napDdlLoaicauhoi()
        {
            try
            {
                ddlLoaiCauHoi.Items.Clear();
                List<CateFaqEntity> lstLoaicauhoi = CateFaqBRL.GetAll();                
                ddlLoaiCauHoi.DataSource = lstLoaicauhoi;
                ddlLoaiCauHoi.DataValueField = "PK_iFaqCateID";
                ddlLoaiCauHoi.DataTextField = "sCateName";                
                ddlLoaiCauHoi.DataBind();               
            }
            catch (Exception ex)
            {

            }
        }
        private void napForm(int faqID)
        {
            FaqEntity oFAQ = FaqBRL.GetOne(faqID);
            if (oFAQ != null)
            {
                txtCauhoi.Text = oFAQ.sQuestion;
                ddlLoaiCauHoi.SelectedValue = oFAQ.FK_iFaqCateID.ToString();
                List<FaqAnswersEntity> lstanswer = FaqAnswersBRL.GetByFK_iFaqID(faqID);
                if (lstanswer != null && lstanswer.Count > 0)
                {
                    txtCautraloi.Text = lstanswer[0].sContent;
                    btnReset.CommandArgument = lstanswer[0].PK_iFaqAnswerID.ToString();
                    
                }
                pnEdit.Visible = true;
            }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
                try
                {
                    if (Session["UserID"] == null)
                        Response.Redirect("~/");
                    FaqEntity oFAQ = new FaqEntity();
                    oFAQ.FK_iFaqCateID = Convert.ToInt32(ddlLoaiCauHoi.SelectedValue);
                    oFAQ.sQuestion = txtCauhoi.Text;
                    //
                    FaqAnswersEntity oFAQAnswer = new FaqAnswersEntity();
                    oFAQAnswer.sContent = txtCautraloi.Text;
                    //
                    if (Session["UserID"] != null)
                    {
                        int userID = Convert.ToInt32(Session["UserID"]);
                        oFAQ.FK_iUserID = userID;

                        if (btnOK.CommandName == "Edit")
                        {
                            int faqID = Convert.ToInt32(btnOK.CommandArgument);
                            int faqanswerID = Convert.ToInt32(btnReset.CommandArgument);
                            oFAQ.PK_iFaqID = faqID;
                            oFAQAnswer.PK_iFaqAnswerID = faqanswerID;
                            oFAQAnswer.FK_iFaqID = faqID;
                            FaqBRL.Edit(oFAQ);
                            FaqAnswersBRL.Edit(oFAQAnswer);
                            btnOK.CausesValidation = true;
                        }
                        else
                        {
                            int faqAddID = FaqBRL.Add(oFAQ);
                            oFAQAnswer.FK_iFaqID = faqAddID;
                            FaqAnswersBRL.Add(oFAQAnswer);
                        }
                        lblThongbao.Text = "Cập nhật thành công";
                        btnOK.Text = "Thêm";
                        //Nạp lại dữ liệu
                        pnEdit.Visible = false;
                        Response.Redirect(Request.Url.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=FAQManager';</script>");
                }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            btnOK.CommandName = "Add";
            btnOK.Text = "Thêm";
            pnEdit.Visible = false;
            clearForm();
        }
        public void clearForm()
        {
            txtCauhoi.Text = "";            
            txtCautraloi.Text = "";
            ddlLoaiCauHoi.SelectedIndex = 0;
        }
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
                try
                {
                    foreach (GridViewRow row in grvFAQ.Rows)
                    {
                        System.Web.UI.WebControls.CheckBox chkDelete = row.FindControl("chkDelete") as System.Web.UI.WebControls.CheckBox;
                        int FAQID = Convert.ToInt32(grvFAQ.DataKeys[row.RowIndex].Values["PK_iFaqID"]);
                        if (chkDelete != null && chkDelete.Checked)
                        {
                            List<FaqAnswersEntity> lst = FaqAnswersBRL.GetByFK_iFaqID(FAQID);
                            foreach (FaqAnswersEntity faqAnswer in lst)
                            {
                                FaqAnswersBRL.Remove(faqAnswer.PK_iFaqAnswerID);
                            }
                            FaqBRL.Remove(FAQID);
                        }
                    }
                    //Nap lai du lieu
                    Response.Redirect(Request.Url.ToString());
                }
                catch (Exception ex)
                {
                    Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=FAQManager';</script>");
                }
        }
        protected void grvFAQ_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvFAQ.PageIndex = e.NewPageIndex;
            napGridView();
        }
        protected void grvFAQ_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null)
                ViewState["SortDirection"] = "ASC";
            else
            {
                ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
            }
            List<FaqEntity> list=FaqBRL.GetAll();
            grvFAQ.DataSource = FaqEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
            grvFAQ.DataBind();
        }       
        protected void lnkAddnew_Click(object sender, EventArgs e)
        {
            btnOK.CommandName = "Add";
            pnEdit.Visible = true;
            clearForm();
        }
        protected void btnSearchByID_Click(object sender, EventArgs e)
        {
            string strSearch = txtSearchByID.Text;
            int faqID = 0;
            if (txtID.Text.Length == 0 || txtID.Text == "")
                faqID = 0;
            else faqID = Int16.Parse(txtID.Text);
            List<FaqEntity> lstFAQ = FaqBRL.GetAll();
            if (faqID == 0)
            {
                lstFAQ = lstFAQ.FindAll(
                delegate(FaqEntity oCat)
                {
                    return oCat.sQuestion.ToUpper().Contains(strSearch.ToUpper());
                }
                );
            }
            else
            {
                lstFAQ = lstFAQ.FindAll(
                delegate(FaqEntity oCat)
                {
                    return oCat.PK_iFaqID == faqID;
                }
                );
            }
            lblThongbao.Text = "";
            grvFAQ.DataSource = lstFAQ;            
            grvFAQ.DataKeyNames = new string[] { "PK_iFaqID" };
            grvFAQ.DataBind();
            

        }
        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            napGridView();
        }
}
}