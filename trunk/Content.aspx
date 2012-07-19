<%@ Page Title="" Language="C#" MasterPageFile="~/mtpBSL.master" AutoEventWireup="true" CodeFile="Content.aspx.cs" Inherits="Content" %>

<%@ Register src="uc/ucViewNews.ascx" tagname="ucViewNews" tagprefix="uc1" %>
<%@ Register src="~/uc/DocDetail.ascx" tagname="ucDocDetail" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="js/jquery-1.7.1.js" type="text/javascript"></script>
    <script src='<%=ResolveUrl("~/Plugin/flowplayer/flowplayer-3.2.10.min.js") %>' type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctContent" Runat="Server">
    <link href="css/formInMain.css" rel="stylesheet" type="text/css" />
    <div id="main" style="width:78%;margin-left:10px;text-align:justify;">
        <asp:PlaceHolder ID="phMain" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphRight" Runat="Server">
    
</asp:Content>

