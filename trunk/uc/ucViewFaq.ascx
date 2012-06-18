<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucViewFaq.ascx.cs" Inherits="uc_ucViewFaq" %>
<asp:Panel ID="pnlFaq" runat="server" Visible="false">
    <h1>
        <span class="green">
            <asp:Label ID="lblInfo" runat="server" Text="<%$ Resources:Language, lblCauHoiL%>"></asp:Label>
        </span>
    </h1>
    <p>
        <b>
            <asp:Literal ID="litQuestionContents" runat="server"></asp:Literal>
        </b>
    </p>
    <h1>
        <span class="green">
            <asp:Label ID="lblAnswer" runat="server" Text="<%$ Resources:Language, lblTraLoiL%>"></asp:Label>
        </span>
    </h1>
        <div class="panel_item">
            <asp:Repeater ID="rptrResultFaq" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                        <asp:Literal ID="ltrAnswer" runat="server" Text='<%#Eval("sContent").ToString()%>'></asp:Literal>
                        <%--<asp:Label ID="lblAnswer" runat="server" Text='<%#Eval("sContent").ToString()%>'></asp:Label>--%>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    <asp:LinkButton ID="lnkBack" runat="server" OnClick="lnkBack_Click"><asp:Label ID="lblQuayLai" runat="server" Text="<%$ Resources:Language, lblQuayLai%>"></asp:Label></asp:LinkButton>
</asp:Panel>
