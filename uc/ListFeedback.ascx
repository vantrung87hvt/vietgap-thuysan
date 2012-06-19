<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListFeedback.ascx.cs" Inherits="INVI.INVINews.Module.ListFeedback" %>
<link href="<%=ResolveUrl("~/uc/css/uc-style.css") %>" rel="stylesheet" type="text/css" />
<div class="cssDiv">
	<hr width="400px" align="left"/>
	<asp:Label id="lblMessage" runat="server"></asp:Label>
	<br />
	<asp:Repeater id="rptPhanhoi" runat="server">
		<ItemTemplate>
			<div>
				<asp:Label ID="lblNguoigui" runat="server" Text="<%$Resources:language,nguoigui %>" />:
				<asp:Label CssClass="Hoten" ID="lblHoten" runat="server" Text='<%#Eval("sName")%>'>
				</asp:Label>( <a class="Hoten" href='mailto:<%#Eval("sEmail")%>'>
					<asp:Label ID="lblEmail" Runat="server" Text='<%#Eval("sEmail")%>'/>
				</a>)
			</div>
			<div>
				<asp:Label ID="Label1" runat="server" Text="<%$Resources:language,tieude %>" />: <i>
					<asp:Label ID="lblTieude" CssClass="tieude" runat="server" Text='<%#Eval("sTitle")%>'>
					</asp:Label></i>
			</div>
			<div>
				<asp:Label ID="Label2" runat="server" Text="<%$Resources:language,ngaygui %>" />:
				<asp:Label ID="lblThoidiemgui" CssClass="noidung" runat="server" Text='<%#Eval("tDate","{0:dd/MM/yyyy}")%>'>
				</asp:Label>
			</div>
			<div>
				<asp:Label ID="Label3" runat="server" Text="<%$Resources:language,noidung %>" />:
				<asp:Label ID="lblNoidung" CssClass="noidung" runat="server" Text='<%#Eval("sContent")%>'>
				</asp:Label>
			</div>
		</ItemTemplate>
		<SeparatorTemplate>
			<hr width="200px" align="left" />
		</SeparatorTemplate>
	</asp:Repeater>
	<hr width="400px" align="left"/>
</div>
