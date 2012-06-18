using INVI.Entity;
using INVI.Business;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
namespace INVI.INVINews.Admin
{
    public partial class PollManager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!PermissionBRL.CheckPermission("ManagerPoll")) Response.End();
            if (!IsPostBack)
            {

                try
                {
                    int nhomtinGoc = 0;
                    try
                    {
                        nhomtinGoc = Convert.ToInt32(ConfigurationManager.AppSettings["NhomtinGoc"]);
                    }
                    catch { }

                    this.napNhomcaptren(nhomtinGoc, Server.HtmlDecode("&nbsp;"));
                    
                    if (Session["NewsID"] != null)
                        lblThongbao.Text = "Quản lý thăm dò cho tin tức :" + NewsBRL.GetOne(Convert.ToInt32(Session["NewsID"])).sTitle;
                    this.napGridView();
                    AnswerManager1.NapListbox();
                    AnswerManager1.Visible = true;
                }
                catch (Exception ex)
                {
                    lblThongbao.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// Nạp danh sách nhóm cấp trên ra listbox
        /// </summary>
        /// <param name="newsID"></param>
        /// <param name="sCap"></param>
        private void napNhomcaptren(int categoryID, string sCap)
        {
            List<CategoryEntity> lstCat = CategoryBRL.GetByTopID(categoryID);
            foreach (CategoryEntity oCat in lstCat)
            {
                ListItem item = (new ListItem(sCap + oCat.sTitle, oCat.iCategoryID.ToString()));
                lstbNhomtin.Items.Add(item);
                napNhomcaptren(oCat.iCategoryID, Server.HtmlDecode("&nbsp;") + sCap + "-");
            }//foreach

        }
        private void napGridView()
        {
            grvPoll.DataSource = Session["NewsID"]==null ? PollBRL.GetAll() : PollBRL.GetByNewsID(Convert.ToInt32(Session["NewsID"]));
            grvPoll.DataKeyNames = new string[] { "iPollID", "iNewsID" };
            grvPoll.DataBind();
        }
        protected void grvPoll_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int newsID = Convert.ToInt32(grvPoll.DataKeys[e.Row.RowIndex].Values["iNewsID"]);
                Label lblNews = e.Row.FindControl("lblNews") as Label;
                if (lblNews != null)
                {
                    NewsEntity oNews=NewsBRL.GetOne(newsID);
                    if (oNews != null)
                    {
                        lblNews.Text = getShortOf(oNews.sTitle);
                    }
                }
            }
        }
        protected void grvPoll_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int pollID = Convert.ToInt32(grvPoll.DataKeys[e.NewSelectedIndex].Values["iPollID"]);
            btnOK.CommandName = "Edit";
            btnOK.CommandArgument = pollID.ToString();
            napForm(pollID);
        }

        private void napForm(int pollID)
        {
            PollEntity oPoll = PollBRL.GetOne(pollID);
            if (oPoll != null)
            {
                txtQuestion.Text = oPoll.sQuestion;
                txtOrder.Text = oPoll.iOrder.ToString();
                txtDate.Text = oPoll.tDate.ToString("dd/MM/yyyy");
                chkHomepage.Checked = oPoll.bHomepage;
                Session["PollID"] = pollID;
                AnswerManager1.NapListbox();
                AnswerManager1.Visible = true;
                //List nhóm tin
                lstbNhomtin.ClearSelection();
                PollCategoryBRL.GetByiPollID(pollID).ForEach(
                    delegate(PollCategoryEntity oPollCat)
                    {
                        lstbNhomtin.Items.FindByValue(oPollCat.iCategoryID.ToString()).Selected = true;
                    }
                );
            }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    PollEntity oPoll = new PollEntity();
                    oPoll.sQuestion = txtQuestion.Text;
                    oPoll.tDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", null);
                    oPoll.iOrder = Convert.ToByte(txtOrder.Text);
                    oPoll.bHomepage = chkHomepage.Checked;
                    if (Session["NewsID"] != null)
                    {
                        int newsID;
                        bool result = Int32.TryParse(Session["NewsID"].ToString(), out newsID);
                        if (result) oPoll.iNewsID = newsID;
                    }
                    if (btnOK.CommandName == "Edit")
                    {
                        oPoll.iPollID = Convert.ToInt32(btnOK.CommandArgument);
                        PollBRL.Edit(oPoll);
                        //Cập nhật trong PollCategory
                        foreach (ListItem item in lstbNhomtin.Items)
                        {
                            try
                            {
                                int categoryID = Convert.ToInt32(item.Value);
                                if (!item.Selected)
                                {
                                    PollCategoryBRL.RemoveByiCategoryID(categoryID);
                                }
                                else
                                {
                                    PollCategoryEntity oPollCat = new PollCategoryEntity();
                                    oPollCat.iPollID = oPoll.iPollID;
                                    oPollCat.iCategoryID = categoryID;
                                    PollCategoryBRL.Add(oPollCat);
                                }
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        int pollID = PollBRL.Add(oPoll);
                        //Thêm bản ghi vào tblAdvCategory
                        if (pollID > 0)
                        {
                            foreach (ListItem item in lstbNhomtin.Items)
                            {
                                if (item.Selected)
                                {
                                    PollCategoryEntity oPollCat = new PollCategoryEntity();
                                    oPollCat.iPollID = pollID;
                                    oPollCat.iCategoryID = Convert.ToInt32(item.Value);
                                    PollCategoryBRL.Add(oPollCat);
                                }
                            }
                        }
                    }
                    lblThongbao.Text = "Cập nhật thành công";
                    //Nạp lại dữ liệu
                    Response.Redirect(Request.Url.ToString());
                }
                catch (Exception ex)
                {
                    Response.Write("<script language=\"javascript\">alert('" + ex.Message + "');location='Default.aspx?page=PollManager';</script>");
                }
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            btnOK.CommandName = "Add";
            txtQuestion.Text = "";
            txtOrder.Text = "0";
            txtDate.Text = "";
            chkHomepage.Checked = false;
            AnswerManager1.Visible = false;
            lstbNhomtin.ClearSelection();
            Session.Remove("PollID");
        }
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in grvPoll.Rows)
                {
                    CheckBox chkDelete = row.FindControl("chkDelete") as CheckBox;
                    int pollID = Convert.ToInt32(grvPoll.DataKeys[row.RowIndex].Values["iPollID"]);
                    if (chkDelete != null && chkDelete.Checked)
                    {
                        //Remove Answer
                        PollAnswerBRL.RemoveByPollID(pollID);
                        //Remove Poll
                        PollEntity oPoll = new PollEntity();
                        oPoll.iPollID = pollID;
                        PollBRL.Remove(oPoll);
                    }
                }
                //Nap lai du lieu
                Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ex)
            {
                lblThongbao.Text = ex.Message;
            }
        }
        protected void grvPoll_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grvPoll.PageIndex = e.NewPageIndex;
                napGridView();
            }
            catch(Exception ex)
            { lblThongbao.Text = ex.Message; }
        }
        protected string getShortOf(Object x)
        {
            if (x.ToString().Length < 50)
                return x.ToString();
            else
                return x.ToString().Substring(0, 50);
        }
        protected void grvPoll_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                if (ViewState["SortDirection"] == null)
                    ViewState["SortDirection"] = "ASC";
                else
                {
                    ViewState["SortDirection"] = ViewState["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
                }
                List<PollEntity> list = Session["NewsID"] == null ? PollBRL.GetAll() : PollBRL.GetByNewsID(Convert.ToInt32(Session["NewsID"]));
                grvPoll.DataSource = PollEntity.Sort(list, e.SortExpression, ViewState["SortDirection"].ToString());
                grvPoll.DataBind();
            }
            catch (Exception ex)
            {
                lblThongbao.Text = ex.Message;
            }
        }
        
}
}