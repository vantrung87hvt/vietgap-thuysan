<%@ Page Title="" Language="C#" MasterPageFile="~/mtpBSL.master" AutoEventWireup="true" CodeFile="SearchIDVietGap.aspx.cs" Inherits="Default2" %>

<%@ Register src="uc/ucSearchIDVietAp.ascx" tagname="ucSearchIDVietAp" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctContent" Runat="Server">
    <div id="main" style="width:610px;margin-left:10px;text-align:justify;">
<uc1:ucSearchIDVietAp ID="ucSearchIDVietAp1" runat="server" />
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphRight" Runat="Server">
    
</asp:Content>

