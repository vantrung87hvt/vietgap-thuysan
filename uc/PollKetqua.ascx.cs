using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections.Generic;
using INVI.Entity;
using INVI.Business;

namespace INVI.INVIWeb.Module 
{
	public partial class PollKetqua : System.Web.UI.UserControl 
    {
		#region Private Function
		public int iTongsoluotbinhchon;

		private string getQuestionByPollID(int pollID) 
        {
			PollEntity oPoll = PollBRL.GetOne(pollID);
            return oPoll.sQuestion.Trim();
		}

		private List<PollAnswerEntity> getAnswerByPollID(int pollID) 
        {
			List<PollAnswerEntity> lstAnswer =PollAnswerBRL.GetByPollID(pollID);
            return lstAnswer;
		}

		private void bindPanelControl(int pollID) 
        {
			// Add Question
			lblCauhoithamdo.Text = this.getQuestionByPollID(pollID);

			// Add Answers
            rptrKetquabinhchon.DataSource = this.getAnswerByPollID(pollID);
			rptrKetquabinhchon.DataBind();
		}

		private void getTongsobinhchon(int pollID) 
        {
            List<PollAnswerEntity> lst = getAnswerByPollID(pollID);

			iTongsoluotbinhchon = 0;

            for (int i = 0; i < lst.Count; i++)
            {
                iTongsoluotbinhchon += lst[i].iCount;
			}
		}
		#endregion

		#region Methods
		protected void Page_Load(object sender, EventArgs e) {
			if (!this.IsPostBack) {
				if (Request.QueryString.Get("pollID") != null) {
                    int pollID = Convert.ToInt32(Request.QueryString.Get("pollID").Trim());

					// Tính tổng số bình chọn cho câu hỏi có thăm dò ID = pollID
					this.getTongsobinhchon(pollID);
					lblTongsoluotbinhchon.Text = "Tổng số lượt bình chọn cho thăm dò này là: " + iTongsoluotbinhchon.ToString();

					this.bindPanelControl(pollID);
				}
			}
		}

		protected void rptrKetquabinhchon_ItemDataBound(object sender, RepeaterItemEventArgs e) {
			
			// Tính iPhantrambinhchon
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
				PollAnswerEntity oPhuongan = e.Item.DataItem as PollAnswerEntity;
				if (oPhuongan != null) {
					double fPhantrambinhchon=0;
                    if (iTongsoluotbinhchon > 0)
                    {
                        fPhantrambinhchon = Convert.ToDouble(oPhuongan.iCount);
                        fPhantrambinhchon = (fPhantrambinhchon / iTongsoluotbinhchon) * 100;
                    }
					// bind lblPhantrambinhchon
					Label lblPhantrambinhchon = (Label)e.Item.FindControl("lblPhantrambinhchon");
					lblPhantrambinhchon.Text = fPhantrambinhchon.ToString("0.###") + "%";

					// bind pnlThanhphanbieudo
                    Panel pnlThanhphanBieudo = (Panel)e.Item.FindControl("pnlThanhphanBieudo");
                    pnlThanhphanBieudo.BackColor = System.Drawing.Color.Red;
                    pnlThanhphanBieudo.Height = Unit.Pixel(5);
                    pnlThanhphanBieudo.BorderColor = System.Drawing.Color.Black;
                    pnlThanhphanBieudo.BorderWidth = Unit.Pixel(1);
                    pnlThanhphanBieudo.Width = Unit.Percentage(fPhantrambinhchon);
				}
			}
		}
		#endregion
	}
}
