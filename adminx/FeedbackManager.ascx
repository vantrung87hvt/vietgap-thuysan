<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FeedbackManager.ascx.cs" Inherits="INVI.INVINews.Admin.FeedbackManager" %>
<link href="../css/Grid_View.css" rel="stylesheet" type="text/css" />

<asp:GridView ID="grvFeedback" runat="server" AutoGenerateColumns="False" onrowdatabound="grvFeedback_RowDataBound" 
    AllowPaging="True" AllowSorting="True" 
    onpageindexchanging="grvFeedback_PageIndexChanging" 
    onsorting="grvFeedback_Sorting"
     AlternatingRowStyle-CssClass="GridAltItem"
                HeaderStyle-CssClass="GridHeader"
                CssClass="Grid"
    >
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:CheckBox ID="chkDelete" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="sName" HeaderText="Người gửi" 
            SortExpression="sName" />
        <asp:BoundField DataField="sEmail" HeaderText="Email" 
            SortExpression="sEmail" />
        <asp:BoundField DataField="tDate" HeaderText="Ngày gửi" 
            SortExpression="tDate" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="sTitle" HeaderText="Tiêu đề" 
            SortExpression="sTitle" />
        <asp:CheckBoxField DataField="bVerified" HeaderText="Kiểm duyệt" 
            SortExpression="bVerified" />
        <asp:TemplateField HeaderText="Tin tức">
            <ItemTemplate>
                <asp:HyperLink ID="lnkNews" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <a href="#" class="lnkReadFeedback">Đọc</a>
                <div style="display:none">
                <div style="padding:20px;background-color:lightYellow;border:solid 2px black">
                    <asp:Label ID="lblNoidung" runat="server" Text='<%#Eval("sContent") %>' />
                    <br />
                    <asp:LinkButton ID="lbtnVerifyOne" CommandName="VerifyOne" 
                        CommandArgument='<%#Eval("iFeedbackID") %>' runat="server" CausesValidation="false" 
                        OnClick="lbtnVerify_Click" Text="Kiểm duyệt" />
                        <a href="#" class="closeFB"> | Đóng</a>
                </div>
                </div>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<a href="javascript:inviCheck.CheckAll()">Chọn tất |</a>
<a href="javascript:inviCheck.UnCheckAll()">Bỏ chọn |</a>

<asp:LinkButton ID="llbtnVerify" runat="server" CausesValidation="False" 
    onclick="lbtnVerify_Click">Kiểm duyệt</asp:LinkButton>
