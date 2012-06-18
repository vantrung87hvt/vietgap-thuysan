<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucBandophanboCachonuoitrong.ascx.cs"
    Inherits="Maps_ucBandophanboCachonuoitrong" %>
<script type='text/javascript' src='https://www.google.com/jsapi'></script>
<script src="../js/jquery-1.7.1.js" type="text/javascript"></script>
<script src="http://maps.google.com/maps/api/js?sensor=false" type="text/javascript"></script>
<script src="../js/number-functions.js" type="text/javascript"></script>
<script type="text/javascript">
    function formatCurrency(num) {
        num = num.toString().replace(/\$|\,/g, '');
        if (isNaN(num))
            num = "0";
        sign = (num == (num = Math.abs(num)));
        num = Math.floor(num * 100 + 0.50000000001);
        num = Math.floor(num / 100).toString();
        for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
            num = num.substring(0, num.length - (4 * i + 3)) + ',' +
    num.substring(num.length - (4 * i + 3));
        return (((sign) ? '' : '-') + num);
    }
</script>
<script type="text/javascript">
    var mData = [];
    $dpts = $("#side_bar");
    google.load('visualization', '1.1', { 'packages': ['geochart'] });
    $(document).ready(Startup);
    function Startup() {

        $.ajax({
            type: "POST",
            url: "../Service.asmx/getTonghopTheoTinhJSON",
            data: "{'FK_iTinhID': '" + 0 + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: AjaxSucceeded,
            error: AjaxFailed
        });

        function AjaxSucceeded(result) {
            var dt = new google.visualization.DataTable();
            var data = eval('(' + result + ');');
            dt.addColumn('string', 'City');
            dt.addColumn('string', 'CityName');
            dt.addColumn('number', 'Tổng số hộ nuôi trồng');
            dt.addColumn('number', 'Tổng diện tích');

            //dt.addColumn('number', 'fTongdientichmatnuoc');
            //dt.addColumn('number', 'iTongsanluongdukien');
            for (var i = 0; i < data.tblCosonuoitrong.length; i++) {
                var val1 = data.tblCosonuoitrong[i].ISO31662;
                var val2 = data.tblCosonuoitrong[i].sTentinh;
                var val3 = data.tblCosonuoitrong[i].iSohonuoitrong;
                var val4 = data.tblCosonuoitrong[i].fTongdientich;
                dt.addRow([val1, val2, parseInt(val3), parseFloat(val4)]);
            }

            var options = {};
            options['dataMode'] = 'regions';
            options['resolution'] = 'provinces';
            options['region'] = 'VN';
            options['width'] = '920';
            options['height'] = '700';
            var chart = new google.visualization.GeoChart(document.getElementById('gmap'));
            google.visualization.events.addListener(chart, 'regionClick', function (e) {
//                showTableData(e['region']);
            });
            chart.draw(dt, options);
        }
//        function showTableData(value) {
//            $.ajax({
//                type: "POST",
//                url: "../Service.asmx/getTonghopTheoISO_3166JSON",
//                data: "{'ISO_3166': '" + value + "'}",
//                contentType: "application/json; charset=utf-8",
//                dataType: "json",
//                success: getDataSuccessed,
//                error: AjaxFailed
//            });

//        }
//        function getDataSuccessed(result) {

//            var data = eval('(' + result + ');');
//            var table;
//            table = '<table id=\"hor-minimalist-b\" summary=\"Thông Tin Cơ sở nuôi trồng\">';
//            table += '<thead>';
//            table += '<tr>';
//            table += '<th scope="col">Đối tượng</th>';
//            table += '<th scope="col">T.Số hộ</th>';
//            table += '<th scope="col">T.Diện tích</th>';
//            table += '<th scope="col">T.Sản lượng</th>';
//            table += '</tr>';
//            table += '</thead>';
//            for (var i = 0; i < data.tblCosonuoitrong.length; i++) {
//                table += '<tr>';
//                table += '<td>' + data.tblCosonuoitrong[i].sTendoituong + '</td>';
//                table += '<td>' + data.tblCosonuoitrong[i].iSoho + '</td>';
//                var fTongdientich = data.tblCosonuoitrong[i].fTongdientich;
//                table += '<td>' + formatCurrency(fTongdientich) + '</td>';
//                //bignum.numberFormat("0,0,, million");
//                var iTongsanluongdukien = data.tblCosonuoitrong[i].iSanluongdukien;
//                table += '<td>' + formatCurrency(iTongsanluongdukien) + '</td>';
//                table += '</tr>';
//                //var val5 = 
//                //var val6 = data.tblCosonuoitrong[i].iTongsanluongdukien;
//            }
//            table += '</table>';
//            //                alert(table);
//            $dpts = $("#side_bar");
//            $dpts.html(table);
//        }
        function AjaxFailed(result) {
            alert(result.status + ' ' + result.statusText);
            console.log("AJAX Error!");
        }
    }
</script>
<body>
    <div style="width: 940px; margin-top: 10px; text-align: justify;">
        <div id='gmap'>
        </div>
        
    </div>
</body>
