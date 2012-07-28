<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucVideoUploader.ascx.cs"
    Inherits="adminx_ucVideoUploader" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <title>Demo Page</title>
    <script type="text/javascript" src="js/jquery-1.2.6.min.js"></script>
    <script type="text/javascript" src="js/jquery.ajax_upload.0.6.min.js"></script>
    <script type="text/javascript">/*<![CDATA[*/
$(document).ready(function(){
	var button = $('#button1'), interval;
	$.ajax_upload(button,{
		action: 'FileHandler.ashx',
		name: 'myfile',
		onSubmit : function(file, ext){
			button.text('Tải lên');
			this.disable();
			interval = window.setInterval(function(){
				var text = button.text();
				if (button.text().length < 13){
					button.text(button.text() + '.');					
				} else {
					button.text('Tải lên');				
				}
			}, 200);
		},
		onComplete: function(file, response){
			button.text('Upload');
			button.removeClass('hover');
			window.clearInterval(interval);
			this.enable();
			$('<li></li>').appendTo('#example1 .files').text(file);						
		}
	});
	
	
});/*]]>*/
    </script>
    <style type="text/css">
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
            width: 133px; /* Centering button will not work, so we need to use additional div */
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
    </style>
</head>
<body>
    <ul>
        <li id="example1" class="example">
            <div class="wrapper">
                <div id="button1" class="button">
                    Tải lên</div>
            </div>
            <p>
                Các tệp đã tải lên:</p>
            
            <ol class="files">
            </ol>
        </li>
    </ul>
</body>
</html>
