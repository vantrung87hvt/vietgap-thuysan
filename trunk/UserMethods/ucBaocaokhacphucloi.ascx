<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucBaocaokhacphucloi.ascx.cs" Inherits="adminx_ucBaocaokhacphucloi" %>
<table>
<tr>
    <td>
    <h1>BÁO CÁO ĐÁNH GIÁ KHẮC PHỤC LỖI</h1>
    </td>
</tr>
<tr>
<td>
    <b>Thông tin chung:</b>
    <ol>
        <li>Tên cơ sở nuôi:<asp:Label ID="lblTencosonuoi" runat="server" Text=""></asp:Label>
        </li>
        <li>Địa chỉ, vùng nuôi:<asp:Label ID="lblDiachi" runat="server" Text=""></asp:Label>
        </li>
        <li>Số điện thoại:<asp:Label ID="lblDienthoai" runat="server" Text=""></asp:Label>&nbsp;Fax:<asp:Label ID="lblFax" runat="server" Text=""></asp:Label>
        </li>
    </ol>
</td>
</tr>
<tr>
    <td><b>Tóm tắt kết quả khắc phục lỗi sai:</b>
        
    </td>
    
</tr>
<tr>
    <td align="right">
        <asp:Button ID="btnBosung" runat="server" Text="Bổ sung" 
            onclick="btnBosung_Click" />
    </td>
    
</tr>
<tr>
    <td>
        
        <asp:GridView ID="grvBaocaokhacphucloiChitiet" runat="server" 
            AutoGenerateColumns="False" EnableModelValidation="True">
            <Columns>
                <asp:BoundField HeaderText="TT" />
                <asp:BoundField DataField="sLoisai" HeaderText="Sai lỗi" 
                    SortExpression="sLoisai" />
                <asp:BoundField DataField="sBienphapkhacphuc" HeaderText="Biện pháp khắc phục" 
                    SortExpression="sBienphapkhacphuc" />
                <asp:BoundField DataField="iKetqua" HeaderText="Kết quả" 
                    SortExpression="iKetqua" />
            </Columns>
        </asp:GridView>
        
    </td>
</tr>
<tr>
    <td>
        Tài liệu kèm theo (nếu có):<asp:TextBox ID="txtTailieukemtheo" runat="server"></asp:TextBox>
    </td>
</tr>
    

</table>