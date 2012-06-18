<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListDocument.bak.ascx.cs"
    Inherits="uc_ListDocument" %>
    <h3>
        <%--<asp:Label ID="lblTieudeTailieu" runat="server" Text="<%$ Resources:Language, lblTieudeTailieu%>"></asp:Label>  --%>
        <asp:HyperLink ID="hypTailieu" runat="server" NavigateUrl="../Content.aspx?mode=uc&page=ListDocument" Text="<%$ Resources:Language, lblTieudeTailieu%>"></asp:HyperLink>
        </h3>

        <div class="content-separator" style="margin-top:5px; margin-bottom:5px;">
                    </div>
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tbody>
                <tr>
                    <td>
                        <marquee width="100%" direction="up" scrollamount="2" onmouseover="this.stop()" onmouseout="this.start()">
                            <span id="dnn_ctr410_CMS_ND_HTTinMoi_lblTinMoi" style="display:inline-block;width:100%;">
                            <table width="97%" cellpadding="0" cellspacing="0" border="0">                            
                             <asp:Repeater ID="rptrDocument" runat="server">
                             <ItemTemplate> <tr>
                            <td align="justify">
                            »&nbsp;  <asp:HyperLink ID="lnkTitle" Text='<%#INVI.INVILibrary.INVIString.GetCuttedString(Eval("sTitle").ToString(),60) %>' NavigateUrl='<%#"../Content.aspx?docID="+Eval("PK_iDocumentID") %>'
                    runat="server" />
                            </td>
                            </tr></ItemTemplate>
                             </asp:Repeater>
                            </table>
                            </span></marquee>
                    </td>
                </tr>
            </tbody>
        </table>
