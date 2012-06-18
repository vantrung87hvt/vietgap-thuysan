<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSearchByVietGAPID.ascx.cs" Inherits="uc_ucSearchByVietGAPID" %>
<h3 style="margin-left:0px;"><asp:Literal ID="ltrTracumasoVietGAP" Text="<%$ Resources:Language, ltrTracumasoVietGAP%>" runat="server"></asp:Literal></h3>
<p>
    <input type="text" class="boxradius" id="txtVietGAPID" value="" style="width:100%; " maxlength="16"  
           tabindex="1" runat="server" />
          <%-- onfocus="if(this.value=='<%$ Resources:Language, ltrTracumasoVietGAP%>') {this.value='';}" onblur="if(this.value=='') {this.value='<%$ Resources:Language, ltrTracumasoVietGAP%>';}" --%>
            </p>   
<p style="clear:both;float:right; margin-top:10px;">
<asp:Button ID="btnSearchVietGAPCode" runat="server"  Text="<%$ Resources:Language, btnSearchVietGAPCode%>" onclick="btnSearch_Click" /> </p> 
