<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucVideoUploader.ascx.cs"
    Inherits="adminx_ucVideoUploader" %>
    <script type="text/javascript" src="js/jquery-1.2.6.min.js"></script>
    <script type="text/javascript" src="js/jquery.ajax_upload.0.6.min.js"></script>
    <script type="text/javascript">/*<![CDATA[*/
$(document).ready(function(){
	var button = $('#btn-upload'), interval;
	$.ajax_upload(button,{
		action: 'FileHandler.ashx',
		name: 'myfile',
		onSubmit : function(file, ext){
            showLoading(true);
//			button.text('Tải lên');
			this.disable();

//			interval = window.setInterval(function(){
//				var text = button.text();
//				if (button.text().length < 13){
//					button.text(button.text() + '.');					
//				} else {
//					button.text('Tải lên');				
//				}
//			}, 200);
		},
		onComplete: function(file, response){
            showLoading(false);
            $('#btn-upload').css("display", "none");
//			button.text('Upload');
//			button.removeClass('hover');
//			window.clearInterval(interval);
//			this.enable();
			$('<li></li>').appendTo('#li-upload .files').text(file);						
		}
	});
	
});
function showLoading(_status)
{
    if(_status)
    {
        $("#loading").css("display", "table-cell");
    }
    else
    {
        $("#loading").css("display", "none");
    }
}
/*]]>*/
    </script>
    <style type="text/css">
        /*
        h1
        {
            color: #C7D92C;
            font-size: 18px;
            font-weight: 400;
        }
        a
        {
            color: white;
        }
        #text
        {
            margin: 25px;
        }
        ul
        {
            list-style: none;
        }
        
        .example
        {
            padding: 0 20px;
            float: left;
            width: 230px;
        }
        
        .wrapper
        {
            width: 133px;
            margin: 0 auto;
        }
        
        div.button
        {
            height: 29px;
            width: 133px;
            background: url(img/button.png) 0 0;
            font-size: 14px;
            color: #C7D92C;
            text-align: center;
            padding-top: 15px;
        }
        div.button.hover
        {
            background: url(img/button.png) 0 56px;
            color: #95A226;
        }
        */
        /***Loading popup - liemqv - 28/07/2012*****/
        #li-upload
        {
            list-style-type:none;
            cursor:pointer;
        }
        #loading
        {
            width:100%;
            height:100%;
            display:none;
            background-color:#fff;
            opacity:0.5;
            text-align:center;
            vertical-align:middle;
            position:absolute;
        }
        #loading .img
        {
            width:235px;
            height:235px;
        }

        /*** button upload ***/
        .button-upload
        {
            height:35px;
            padding-top:25px;
            font-weight:bold;
            width:135px;
            background:url(<%=ResolveUrl("~/css/Images/find_file.png")%>) no-repeat top left;
            padding-left: 65px;
            cursor:pointer;
        }
    </style>
    <div id="li-upload">
        <div class="wrapper">
            <div id="btn-upload" class="button-upload">Chọn video</div>
        </div>
        <p>Tệp đã tải lên:</p>
            
        <ol class="files">
        </ol>
    </div>
    <div id="loading">
        <div class="img">
            <img src="<%=ResolveUrl("~/css/Images/loading.gif") %>" alt="Vui lòng đợi" />
        </div>
    </div>