<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucViewNews.ascx.cs" Inherits="uc_ucViewNews" %>
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

</style>
<asp:Label ID="lblError" runat="server">
</asp:Label>
<div class="post">
	<div class="post-title"><h2>
        <asp:Label ID="lblTitle" runat="server" />
    </h2></div>
    <div class="post-date"><asp:Label ID="lblDateTime" runat="server" /></div>    
	<div class="post-body">        
		<asp:Label ID="lblContent" runat="server" />        
	</div>	
    			
</div>