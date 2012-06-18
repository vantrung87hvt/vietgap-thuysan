<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucSearchIDInHome.ascx.cs" Inherits="uc_ucLogin" %>
<script src="js/jquery-1.7.1.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('.showct').hide().before('<p id="toggle-showct" class="button">Open/Close</p>');
        $('p#toggle-showct').click(function () {
            $('.showct').slideToggle(1000);
            return false;
        });
    });
</script> 

<script type="text/javascript">
    function getOffset(el) {
        var _x = 0;
        var _y = 0;
        while (el && !isNaN(el.offsetLeft) && !isNaN(el.offsetTop)) {
            _x += el.offsetLeft - el.scrollLeft;
            _y += el.offsetTop - el.scrollTop;
            el = el.offsetParent;
        }
        return { top: _y, left: _x };
    }

    $(document).ready(function () {

        $('#nav li a').hover(function (e) {
            //var pos = $(this).offset();
            $(this)
            .parent('li')
            .find('p')
            .css({
                position: 'fixed',
                overflow: 'visible',
                left: eval(getOffset(document.getElementById('sidebar')).left+30),
                top: getOffset(document.getElementById('sidebar')).top
            })
            .removeClass('hidden')
            .stop()
            .animate({ opacity: 0.8 }, 'fast');
        }, function () {
            $(this)
            .parent('li')
            .find('p')
            .addClass('hidden')
            .stop()
            .animate({ opacity: 0 }, 'slow');
        });
    });
</script>
<style type="text/css">
    .boxradius
    {
	    -moz-border-radius:4px;
	    -webkit-border-radius:4px;
	    color: #828282;
    }

</style>
<style type="text/css">     
          
.hidden {
    display: none;
}
        
.boxes {
    width: 173px;    
    padding: 0px; margin: 0px 0px 0px 0px;
    background: white;
}
        

.boxes ul {
    list-style: none;   
    margin:0;
    padding:0; 
}
#nav li
{
    cursor:pointer;
}         
ul#nav li p 
{
    width:300px;
    position: absolute;
    font-size:10pt;
    color:white;
    background-color: #0090ff;
    border-bottom:5px solid #01477d;
    background-color: black;
    z-index:20000;
    padding: 10px;
    margin-top: 5px;
    margin-bottom: 5px;
    font-family: Tahoma,Arial,Helvetica,sans-serif;
    font-size: 1em;
    text-align: left;
    -moz-border-radius: 5px;
    -webkit-border-radius: 5px;
     margin:auto;
     overflow:visible;
}
    
table.info {
    margin: 15px;
    float: left;
    clear: both;
}

.panKetQuaTimKiem
{
    position:relative;
}

</style>

<link href="css/jquery.mCustomScrollbar.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>
<script src="js/jquery.mCustomScrollbar.js" type="text/javascript"></script>
<script src="js/jquery.mousewheel.min.js" type="text/javascript"></script>


<h3 style="margin-left:0px;">
    <asp:Literal ID="ltDangNhap" Text="Tra cứu MS VietGAP" runat="server"></asp:Literal></h3>
    
    <p><input type="text" class="boxradius" id="txtID" value="Mã số Việt Gap" style="width:100%; " maxlength="16"  
           tabindex="1" runat="server" onfocus="if(this.value=='Mã số Việt Gap') {this.value='';}" onblur="if(this.value=='') {this.value='Mã số Việt Gap';}"  /></p>   

    <p style="clear:both;float:right; margin-top:10px;"><asp:Button ID="btnSearch" runat="server"  Text="Tìm kiếm" onclick="btnSearch_Click" /> </p>    
    <p id="lblLoi" runat="server" visible="false" style="clear:both;color:Red;">
        Không tìm thấy kết quả phù hợp
    </p>
<!-- content block -->

<div id="pnKetQua" runat="server" visible="false" style="">
<h3 style="margin-left:0px;clear:both;">
    Kết quả tìm kiếm
    </h3>
<div id="mcs4_container">
	<div class="customScrollBox">
	    
		<div class="container">
    		<div class="content">
        		<div class="boxes" style="clear:both;padding-top:10px;">
        <ul id="nav">        
    <asp:Repeater ID="rptRE" runat="server" onitemdatabound="rptRE_ItemDataBound">    
    <ItemTemplate>  
        <li>
        <a class="aDisplayTooltip"> <asp:Literal ID="lblTenCoSo" runat="server" Text=""></asp:Literal></a>
        <p class="hidden">                   
                        
                          
        <asp:Literal ID="lblPK_iMaSoVietGapID" runat="server" Text='<%#Eval("PK_iMasoVietGapID")%>' Visible='false'></asp:Literal>    
   
                                                    
      <b>
                   
            <asp:Literal ID="Literal1" runat="server" Text="Mã số Việt Gap: " ></asp:Literal>
      </b>
      
            <asp:Literal ID="lblMaSoVietGap" runat="server" Text=""></asp:Literal>
            <br />
        
    
      <b>
            <asp:Literal ID="Literal2" runat="server" Text="Chủ cơ sở: "></asp:Literal>
      </b>
      
            <asp:Literal ID="lblTenChuCoSo" runat="server" Text=""></asp:Literal>
      
   <br />
    
      <b>
            <asp:Literal ID="Literal3" runat="server" Text="Địa chỉ : "></asp:Literal>
      </b>
      
            <asp:Literal ID="lblDiaChi" runat="server" Text=""></asp:Literal>
      <br />
                                     
    
      <b>
            <asp:Literal ID="Literal7" runat="server" Text="Điện thoại: "></asp:Literal>
      </b>
      
            <asp:Literal ID="lblDienThoai" runat="server" Text=""></asp:Literal>
      
   
    <br />
      <b>
            <asp:Literal ID="Literal8" runat="server" Text="Tổng diện tích: "></asp:Literal>
      </b>
      
            <asp:Literal ID="lblTongDienTich" runat="server" Text=""></asp:Literal>
      
   
    
      <br />
      <b>
            <asp:Literal ID="Literal9" runat="server" Text="Tổng diện tích mặt nước: "></asp:Literal>
      </b>
      
            <asp:Literal ID="lblTongDienTichMatNuoc" runat="server" Text=""></asp:Literal>
      <br />
   
    
      <b>
            <asp:Literal ID="Literal10" runat="server" Text="Đối tượng nuôi : "></asp:Literal>
      </b>
      
            <asp:Literal ID="lblDoiTuongNuoi" runat="server" Text=""></asp:Literal>
      <br />
   
    
      <b>
            <asp:Literal ID="Literal11" runat="server" Text="Năm sản xuất: "></asp:Literal>
      </b>
      
            <asp:Literal ID="lblNamSanXuat" runat="server" Text=""></asp:Literal>
      
   
    <br />
      <b>
            <asp:Literal ID="Literal12" runat="server" Text="Chu kỳ nuôi: "></asp:Literal>
      </b>
      
            <asp:Literal ID="lblChuKyNuoi" runat="server" Text=""></asp:Literal>
      
   <br />
    
      <b>
            <asp:Literal ID="Lable12" runat="server" Text="Ngày đăng ký: "></asp:Literal>
      </b>
      
            <asp:Literal ID="lblNgayDangKy" runat="server" Text=""></asp:Literal>
      
                       
</p>
        <%--<div class="showct">--%>            
            

        </li>
<%--</div>--%>
    
    
    </ItemTemplate>
</asp:Repeater>
</ul>
        </div>
			</div>
		</div>
		<div class="dragger_container">
    		<div class="dragger"></div>
		</div>
	</div>
</div>


</div>



<noscript>
	<style type="text/css">
		#mcs_container .customScrollBox,#mcs2_container .customScrollBox,#mcs3_container .customScrollBox,#mcs4_container .customScrollBox,#mcs5_container .customScrollBox{overflow:auto;}
		#mcs_container .dragger_container,#mcs2_container .dragger_container,#mcs3_container .dragger_container,#mcs4_container .dragger_container,#mcs5_container .dragger_container{display:none;}
	</style>
</noscript>

<script>
$(window).load(function() {
	mCustomScrollbars();
});

function mCustomScrollbars(){
	/* 
	
	*/
	$("#mcs_container").mCustomScrollbar("vertical",400,"easeOutCirc",1.05,"auto","yes","yes",10); 
	$("#mcs2_container").mCustomScrollbar("vertical",0,"easeOutCirc",1.05,"auto","yes","no",0); 
	$("#mcs3_container").mCustomScrollbar("vertical",900,"easeOutCirc",1.05,"auto","no","no",0); 
	$("#mcs4_container").mCustomScrollbar("vertical",200,"easeOutCirc",1.25,"fixed","yes","no",0); 
	$("#mcs5_container").mCustomScrollbar("horizontal",500,"easeOutCirc",1,"fixed","yes","yes",20); 
}

/* function to fix the -10000 pixel limit of jquery.animate */
$.fx.prototype.cur = function(){
    if ( this.elem[this.prop] != null && (!this.elem.style || this.elem.style[this.prop] == null) ) {
      return this.elem[ this.prop ];
    }
    var r = parseFloat( jQuery.css( this.elem, this.prop ) );
    return typeof r == 'undefined' ? 0 : r;
}

/* function to load new content dynamically */
function LoadNewContent(id,file){
	$("#"+id+" .customScrollBox .content").load(file,function(){
		mCustomScrollbars();
	});
}
</script>
<script src="../js/jquery.mCustomScrollbar.js" type="text/javascript"></script>
