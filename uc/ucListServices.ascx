<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucListServices.ascx.cs" Inherits="uc_ucListServices" %>
<style>
   .post h2
{
    margin-left:0;
}
.post a {text-decoration: none;}
.post p 
{
    margin-bottom:1em;
}
.post a:hover {text-decoration: underline;}

.post img.left, .post img.right {margin-bottom: 0;}

.post-date {
	color: #777;
	margin: 2px 0 10px;
}
.post-date a {color: #444;}

.post-title h1, .post-title h2, .post-title h3 {margin-bottom: 0;}

.post-meta {
	background: #F6F6F6;
	border: 1px solid #DDD;
	color: #777;
	padding: 6px 10px;
}
.post-meta a {color: #345; }
.post-meta a:hover {color: #001;}

.post-body {font-size: 1.1em;}
.post-body a {color: #039;}
.post-body a:hover {color: #039;}

.post-body img.left, .post-body img.right {margin-bottom: 1em;}


.content-separator {
	background: #D5D5D5;
	clear: both;
	color: #FFE;
	display: block;
	font-size: 0;
	line-height: 0;
	height: 1px;	
}
.content-separator {margin: 20px 0;}
img.bordered{
background-color: white;
border: 1px solid #DDD;
padding: 3px;
}
.green
{
    color:#9EC630;
    }

</style>
<h1><span class="green">
    <span><asp:Label ID="lblDanhSachDichVu" runat="server" Text="<%$ Resources:Language, lblDanhSachDichVu%>"></asp:Label></span>
</span></h1>
<asp:Repeater ID="rptrNewsInHome" runat="server" 
    onitemdatabound="rptrNewsInHome_ItemDataBound" onitemcommand="rptrNewsInHome_ItemCommand" 
       >    
    <ItemTemplate>                    
            <div class="post">
                    <div style="float:left;">
                    <asp:Panel ID="pnAnh" runat="server">
					<p class="bordered" style="width:175px;" >
                        <asp:Label ID="lblIDNews" runat="server" Visible="false" Text='<%#Eval("iNewsID")%>' />
                        <asp:HyperLink ID="lnkImage" runat="server">                
                                <asp:Image ID ="imgMinhhoa" runat="server" Width="175px" Height="127px"/>                
                        </asp:HyperLink>
                    </p>
                    </asp:Panel>
                    </div>
                    <div  class ="mostbody" style="float:left;width:555px; margin-left:10px;">
					<h4>
                       <asp:HyperLink ID="lnkTitle" runat="server">                                                                            
                        </asp:HyperLink>
                    </h4>
					<p>
                        <asp:Label ID="lblDesc" runat="server"></asp:Label>
                    </p>
					<asp:HyperLink ID="lnkChitiet" Text="<%$ Resources:Language, readmore%>" class="more"  runat="server" />          
                    </div>
				</div>
				<div class="content-separator"></div>    
    </ItemTemplate>    
</asp:Repeater>
<p class="newsnavi" style="margin-top:-15px; margin-bottom:25px;">
    <asp:Label ID="lblPage" runat="server">
    
    </asp:Label>
</p>