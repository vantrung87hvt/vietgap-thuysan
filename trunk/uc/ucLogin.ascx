<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucLogin.ascx.cs" Inherits="uc_ucLogin" %>

<style type="text/css">
	.boxradius
	{
		-moz-border-radius:4px;
		-webkit-border-radius:4px;
		color: #828282;
		border:1px solid 
	}
	.radius input[type="button"]
	{
		-moz-border-radius:4px;
		-webkit-border-radius:4px;
	}
	.form_login .input 
	{
		background: none repeat scroll 0 0 #FBFBFB;
		border: 1px solid #E5E5E5;
		box-shadow: 1px 1px 2px rgba(200, 200, 200, 0.2) inset;
		font-size: 12px;
		font-weight: 200;
		line-height: 1;
		margin-bottom: 2px;
		margin-right: 6px;
		outline: medium none;
		padding: 3px;
		width: 100%;
		-moz-border-radius:4px;
		-webkit-border-radius:4px;
	}
	.form_login .input:focus{
		border:1px solid #CCC;
	}
	.form_login label {
		color: #777777;
		font-size: 10px;
	}
	.form_login input{
    	color: #555555;
	}
	.form_login input[type="submit"]
	{
		background:url(<%= Page.ResolveUrl("~/CSS/Images/button_bg.gif") %>) repeat-x top;
		cursor:pointer;
		border:none;
		color:#FFF;
		font-size:10px;
		font-weight:bold;
		height:20px;
		padding-bottom:4px;
		text-align:center;
		-moz-border-radius:4px;
		-webkit-border-radius:4px;
	}
	.form_login p.err_login
	{
		font-size:10px;
		color:#F33;
		font-style:italic;
	}
	.form_login p.warring_login
	{
		font-size:10px;
		color:#F96;
		font-style:italic;
	}
	.error_text
	{
		border:1px solid #F00 !important;
	}
	ul.succsess_login{
		list-style-type:none;
		margin-left:0px;
		padding-left:0px;
	}
	ul.succsess_login li{
		padding-left:35px;
		margin-bottom:3px;
		height:32px;
		padding-top:3px;
	}
	ul.succsess_login li, ul.succsess_login li a
	{
		color: #4284B0 !important;
		font-size:12px;
		cursor:pointer;
		text-decoration:none;
	}
	ul.succsess_login li a
	{
	    background:none !important;
	}
</style>
<script type="text/javascript">

    function Login(e, buttonid) 
    {
        var evt = e ? e : window.event;
        var bt = document.getElementById(buttonid);
        if (bt) 
        {
            if (evt.keyCode == 13) 
            {
                bt.click();
                return false;
            }
        }
    }  
  
</script>
<div id="pnlogin" class="form_login" runat="server" Visible="true" >
    <h3 style="margin-left:0px;"><asp:Literal ID="ltDangNhap" Text="<%$ Resources:Language, dangnhap%>" runat="server"></asp:Literal></h3>
    <p>
	    <label id="lblTendangnhap" for="login_user">
            <asp:Literal ID="ltrTendangnhap" Text="<%$ Resources:Language, ltrTendangnhap%>" runat="server"></asp:Literal>
        <br />
        <input type="text" class="boxradius input" id="login_user" style="width:100%; " maxlength="16" tabindex="1" runat="server" onkeypress="" />
        </label>
    </p>
    <p>
        <label id="lblMatkhau" for="login_pass_hint">
            <asp:Literal ID="ltrMatkhau" Text="<%$ Resources:Language, ltrMatkhau%>" runat="server"></asp:Literal>                
        <br />
        <input type="password" class="boxradius input" id="login_pass_hint" style="width:100%";  value="Mật Khẩu" tabindex="2" runat="server" />
        </label>
    </p>
    <asp:label runat="server" id="lblThongbao" text=""></asp:label>
    <%--<p class="forgetmenot"><label for="rememberme"><input name="rememberme" type="checkbox" id="rememberme" value="forever" tabindex="90" />Ghi nhớ</label></p>--%>
    <p class="submit radius" style="float:right; margin-bottom:10px;">
        <asp:Button ID="btnLogin" runat="server" Text="<%$ Resources:Language, dangnhap%>" onclick="btnLogin_Click" />
    </p>
    
</div>
<div id="pnsuccess" runat="server" visible="false">
    <asp:label runat="server" text="" id="lblAction"></asp:label>
    <%--<asp:LinkButton ID="lbtWellcome" runat="server"></asp:LinkButton>--%>
</div>
<p></p>
<div style="margin-bottom:10px;"></div>
