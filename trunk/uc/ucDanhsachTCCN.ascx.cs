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

public partial class uc_ucDanhsachTCCN : System.Web.UI.UserControl
{
    private byte m_pagesize = 8;
    public byte PageSize
    {
        get { return m_pagesize; }
        set { m_pagesize = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            bindDanhsachTCCN();
        }
        catch { }
    }
    private void bindDanhsachTCCN()
    {
        List<TochucchungnhanEntity> lstTCCN = TochucchungnhanBRL.GetAll().FindAll(delegate(TochucchungnhanEntity oTCCN)
                {
                    return oTCCN.iTrangthai == 2;
                }
                );

        lstTCCN.Sort(TochucchungnhanEntity.COMPARISON_sTochucchungnhan);
        lstTCCN.Reverse();
        String tmp = String.Empty;
        String sDoc = "<ul id='lstTCCN'>";
        for (int i = 0; i < lstTCCN.Count; ++i)
        {
            if (lstTCCN[i].sTochucchungnhan.Length > 50)
            {
                tmp = lstTCCN[i].sTochucchungnhan.Substring(0, 50) + "...";
            }
            else
            {
                tmp = lstTCCN[i].sTochucchungnhan;
            }
            sDoc += "<li><a target='_blank' title='" + lstTCCN[i].sKytuviettat + "' href='" + ResolveUrl("~/") + "Content.aspx?TCCNID=" + lstTCCN[i].PK_iTochucchungnhanID + "'>" + tmp + "</a></li>";
        }
        sDoc += "</ul>";
        lblDanhsachTochucchungnhan.Text = sDoc;

    }
}