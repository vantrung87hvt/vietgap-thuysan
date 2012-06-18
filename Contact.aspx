<%@ Page Title="" Language="C#" MasterPageFile="~/mtpBSL.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<%@ Register src="uc/ucContactList.ascx" tagname="ucContactList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ctContent" Runat="Server">
<div id="main" style="width:78%;margin-left:10px;text-align:justify;">
       
    <uc1:ucContactList ID="ucContactList1" runat="server" />
       
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphRight" Runat="Server">

</asp:Content>

