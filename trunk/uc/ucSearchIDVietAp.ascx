<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSearchIDVietAp.ascx.cs" Inherits="uc_ucSearchIDVietAp" %>
<style>

fieldset
{
-moz-border-radius: 7px; 
border: 1px #dddddd solid;
margin-bottom: 20px;
width: 550px;
}

fieldset legend
{
border: 1px #1a6f93 solid; 
color: black; 
font-weight:bold;
font-family: Verdana;
font-weight: none;
font-size: 13px;

padding-right: 5px;
padding-left: 5px;
padding-top: 2px;
padding-bottom: 2px;

-moz-border-radius: 3px;
}

/* Main DIV */
.m 
{
width: 560px;
padding: 20px;
height: auto;
}

/* Left DIV */
.l
{
width: 140px;
margin: 0px;
padding-left : 20px; 

float: left;  
text-align: left;
}


/* Right DIV */
.r
{
width: 300px;
margin: 0px;
padding: 0px; 
padding-left:20px;
float: left; 

text-align: left;
}
.rr
{
width: 30px;
margin: 0px;
padding: 0px; 

float: left; 

text-align: center;

}
.a
{
clear: both;
width: 500px;
padding: 10px;
}
input
{
    width:100%;
    }
    
    #backgroundPopup{

position:fixed;
_position:absolute; /* hack for internet explorer 6*/
height:100%;
width:100%;
top:0;
left:0;
background:#000000;
border:1px solid #cecece;
z-index:1;
opacity: 0.7; 
}
#popupContact{

position:fixed;
_position:absolute; /* hack for internet explorer 6*/

background:#FFFFFF;
border:2px solid #cecece;
z-index:2;
padding:12px;
font-size:13px;
margin:auto;
margin-top:-200px;

}
#popupContact h1{
text-align:left;
color:#6FA5FD;
font-size:22px;
font-weight:700;
border-bottom:1px dotted #D3D3D3;
padding-bottom:2px;
margin-bottom:20px;
}
#popupContactClose{
font-size:14px;
line-height:14px;
right:6px;
top:4px;
position:absolute;
color:#6fa5fd;
font-weight:700;
display:block;
}
#button{
text-align:center;
margin:100px;
}
</style>
	<style type="text/css">
		.tooltip {
			border-bottom: 1px dotted #000000; color: #000000; outline: none;
			cursor: help; text-decoration: none;
			position: relative;
			font-size:10pt;
		}
		.tooltip span {
			margin-left: -999em;
			position: absolute;
		}
		.tooltip:hover span {
			border-radius: 5px 5px; -moz-border-radius: 5px; -webkit-border-radius: 5px; 
			box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.1); -webkit-box-shadow: 5px 5px rgba(0, 0, 0, 0.1); -moz-box-shadow: 5px 5px rgba(0, 0, 0, 0.1);
			font-family: Calibri, Tahoma, Geneva, sans-serif;
			position: absolute; left: 1em; top: 2em; z-index: 99;
			margin-left: 0; width: 300px;
			height:auto;
			color:White;
		}
		.tooltip:hover img {
			border: 0; margin: -10px 0 0 -55px;
			float: left; position: absolute;
		}
		.tooltip:hover em {
			font-family: Candara, Tahoma, Geneva, sans-serif; font-size: 1.2em; font-weight: bold;
			display: block; padding: 0.2em 0 0.6em 0;
		}
		.classic { padding: 0.8em 1em; }
		.custom { padding: 0.5em 0.8em 0.8em 2em; }
		* html a:hover { background: transparent; }
		.classic {background: #FFFFAA; border: 1px solid #FFAD33; }
		.critical { background: #FFCCAA; border: 1px solid #FF3334;	}
		.help { background: #9FDAEE; border: 1px solid #2BB0D7;	}
		.info { background: #9FDAEE; border: 1px solid #2BB0D7;	}
		.warning { background: #FFFFAA; border: 1px solid #FFAD33; }
		</style>
<%--
<script language="JavaScript" src="js/jq.js"></script>
<script language="JavaScript">

    ShowTooltip = function (e) {
        var text = $(this).next('.show-tooltip-text');
        if (text.attr('class') != 'show-tooltip-text')
            return false;

        text.fadeIn()
		.css('top', e.pageY)
		.css('left', e.pageX + 10);

        return false;
    }
    HideTooltip = function (e) {
        var text = $(this).next('.show-tooltip-text');
        if (text.attr('class') != 'show-tooltip-text')
            return false;

        text.fadeOut();
    }

    SetupTooltips = function () {
        $('.show-tooltip')
		.each(function () {
		    $(this)
				.after($('<span/>')
					.attr('class', 'show-tooltip-text')
					.html($(this).attr('title')))
				.attr('title', '');
		})
		.hover(ShowTooltip, HideTooltip);
    }

    $(document).ready(function () {
        SetupTooltips();
    });

</script>--%>

<fieldset style="margin-top:30px;"><legend>Thông tin tìm kiếm</legend>
<div class="a"><div class="l"><asp:Label id="lblMaSo" Text = "Mã số Việt Ap: " runat="server"></asp:Label></div><div class="r">
<asp:TextBox ID="txtMaSo" runat="server" Width="100px"></asp:TextBox>
<asp:Button ID="btnSearch" runat="server" Text="Search"  CssClass="button" Width="90"
    onclick="btnSearch_Click" />
    
</div></div>
<div class="a"></div>
</fieldset>    
<asp:Panel ID="pnKQ" runat="server">
<fieldset><legend>Kết quả tìm kiếm</legend>
<div style="padding-left:30px; ">
<asp:Repeater ID="rptRE" runat="server" onitemdatabound="rptRE_ItemDataBound">    
    <ItemTemplate>      
                <a class="tooltip" href="#">
                    <asp:Literal ID="lblTenCoSo" runat="server" Text=""></asp:Literal>
                    <span class="custom info">
                        <img src="CSS/Images/Info.png" alt='' height="48" width="48" />
                        <em><%#Eval("sTencoso")%></em>
                        <asp:Literal ID="lblPK_iCoSoID" runat="server" Text='<%#Eval("PK_iCosonuoitrongID")%>' Visible="false"></asp:Literal>   
                        <table>
                            <tr>                          
                            
                                <td>
                                    <asp:Literal ID="Literal1" runat="server" Text="Mã số Việt Gap: "></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblMaSoVietGap" runat="server" Text=""></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="Literal2" runat="server" Text="Chủ cơ sở: "></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblTenChuCoSo" runat="server" Text=""></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="Literal3" runat="server" Text="Địa chỉ : "></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblDiaChi" runat="server" Text=""></asp:Literal>
                                </td>
                                </tr>                              
                            <tr>
                                <td>
                                    <asp:Literal ID="Literal7" runat="server" Text="Điện thoại: "></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblDienThoai" runat="server" Text=""></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="Literal8" runat="server" Text="Tổng diện tích: "></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblTongDienTich" runat="server" Text=""></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="Literal9" runat="server" Text="Tổng diện tích mặt nước: "></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblTongDienTichMatNuoc" runat="server" Text=""></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="Literal10" runat="server" Text="Đối tượng nuôi : "></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblDoiTuongNuoi" runat="server" Text=""></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="Literal11" runat="server" Text="Năm sản xuất: "></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblNamSanXuat" runat="server" Text=""></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="Literal12" runat="server" Text="Chu kỳ nuôi: "></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblChuKyNuoi" runat="server" Text=""></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="Lable12" runat="server" Text="Ngày đăng ký: "></asp:Literal>
                                </td>
                                <td>
                                    <asp:Literal ID="lblNgayDangKy" runat="server" Text=""></asp:Literal>
                                </td>
                            </tr>
                        </table>                           
                                
                            </span>
                            </a>
 <br />
        <br />
    </ItemTemplate>
</asp:Repeater>
</div>
</fieldset>

</asp:Panel>