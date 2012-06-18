<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucXulyvipham.ascx.cs" Inherits="adminx_ucXulyvipham" %>
<frameset>
    <legend>Xử lý vi phạm đối với cơ sở nuôi</legend>
    <table>
        <tr>
            <td>Thông tin cơ sở nuôi: </td>
            <td>
                <ul>
                    <li><b>Tên cơ sở nuôi: </b><asp:Label ID="lblTencosonuoi" runat="server"></asp:Label></li>
                    <li><b>Địa chỉ: </b><asp:Label ID="lblDiachi" runat="server"></asp:Label>;</li>
                    <li><b>Số điện thoại: </b><asp:Label ID="lblSodienthoai" runat="server"></asp:Label></li>
                    <li><b>Fax: </b><asp:Label ID="lblSoFax" runat="server"></asp:Label></li>
                </ul>
            </td>
        </tr>
        <tr>
            <td>
                <b>Tình trạng:</b>
            </td>
            <td>
                <asp:Label ID="lblTinhtrang" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Hình thức xử lý vi phạm: </td>
            <td>
                <asp:DropDownList ID="ddlHinhthucxuly" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlHinhthucxuly_SelectedIndexChanged">
                    <asp:ListItem Value="0">Khôi phục</asp:ListItem>
                    <asp:ListItem Value="1">Cảnh cáo</asp:ListItem>
                    <asp:ListItem Value="2">Đình chỉ</asp:ListItem>
                    <asp:ListItem Value="3">Thu hồi Giấy chứng nhận VIETGAP</asp:ListItem>
                </asp:DropDownList>
                <%--<ul>
                    <li><input type="radio" name="rdoCanhcao" />Cảnh cáo</li>
                    <li><input type="radio" name="rdoCanhcao" />Đình chỉ</li>
                    <li><input type="radio" name="rdoCanhcao" />Thu hồi Giấy chứng nhận VietGAP</li>
                </ul>--%>
            </td>
        </tr>
        <tr>
            <td>
                Lý do:
            </td>
            <td>
                <%--<ul style="list-style-type:lower-alpha">
                    <li>Kết quả kiểm tra giám sát cho thấy bằng chứng không đáp ứng yêu cầu theo VietGAP hoặc sản phẩm nuôi không đảm bảo an toàn thực phẩm;</li>
                    <li>Từ chối kiểm tra khi được yêu cầu hoặc xin hoãn kiểm tra 2 lần liên tiếp mà không có lý do chính đáng</li>
                    <li>Vi phạm quy định về sử dụng mã số chứng nhận; sử dụng logo VietGAP không đúng theo quy định.</li>
                    <li>Vi phạm quy định về kiểm tra chứng nhận, xuất xứ sản phẩm nuôi.</li>
                    
                </ul>--%>
                <asp:TextBox ID="txtLydo" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right"><asp:Button ID="btnXuly" runat="server" Text="Xử lý" 
                    onclick="btnXuly_Click"></asp:Button>
                
            </td>
        </tr>
    </table>
    </frameset>