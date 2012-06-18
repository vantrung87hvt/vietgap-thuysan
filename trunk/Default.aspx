<%@ Page Title="" Language="C#"  MasterPageFile="~/mtpBSL.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register src="uc/ImageNews.ascx" tagname="ImageNews" tagprefix="uc1" %>

<%@ Register src="uc/ucMostReadNews.ascx" tagname="ucMostReadNews" tagprefix="uc2" %>

<%@ Register src="uc/ListNewsInHome.ascx" tagname="ListNewsInHome" tagprefix="uc3" %>
<%@ Register src="uc/ListDocument.ascx" tagname="ListDocument" tagprefix="uc4" %>
<%@ Register src="~/uc/ucDanhsachTCCN.ascx" tagname="DanhsachTCCN" tagprefix="uc5" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctContent" Runat="Server">
    <div id="main">
    <uc1:ImageNews ID="ImageNews1" runat="server" />
	<div class="content-separator">
        
    </div>
    
    <uc2:ucMostReadNews ID="ucMostReadNews2" runat="server" />	
    </div>	
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphRight" Runat="Server">
    <div id="rightbar" style="">       
    <uc4:ListDocument ID="ucListDocument" runat="server" />
    <br />
    <uc5:DanhsachTCCN ID="ucDanhsachTCCN" runat="server" />
    </div>
</asp:Content>

