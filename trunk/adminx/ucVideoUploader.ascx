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
        
    </style>
    <div id="li-upload">
        <div class="wrapper">
            <div id="btn-upload" class="button-upload">Chọn video</div>
        </div>
        <p>Tệp đã tải lên:</p>
            
        <ol class="files">
        </ol>
    </div>