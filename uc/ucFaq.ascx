<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucFaq.ascx.cs" Inherits="uc_ucFaq" %>
<style type="text/css">
        fieldset
    {
        -moz-border-radius: 7px;
        border: 1px #dddddd solid;
        margin-bottom: 20px;
        width: 350px;
    }
    
    fieldset legend
    {
        border: 1px #1a6f93 solid;
        color: black;
        font-weight: bold;
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
        padding: 0px;
        float: left;
        text-align: right;
    }
    
    
    /* Right DIV */
    .r
    {
        width: 300px;
        margin: 0px;
        padding: 0px;
        padding-left: 20px;
        float: left;
        text-align: left;
    }
    .rbtn
    {
        width: 20%;
        margin: 0px;
        padding: 0px;
        padding-left: 20px;
        float: left;
        text-align: right;
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
        width: 100%;
    }
    #button
    {
        text-align: center;
        margin: 100px;
    }

</style>
<asp:Panel ID="pnDangKyTV" runat="server">
    <div class="m">
        <fieldset>
            <legend>
                <asp:Label ID="lblTieude" runat="server" Text="F.A.Q"></asp:Label>
            </legend>
            <div class="a">
                
                <div class="l">
                    <asp:Label ID="lblCate" runat="server" Text="<%$ Resources:Language, lblChuyenMucL%>"></asp:Label></div>
                <div class="r">
                    <asp:DropDownList ID="ddlCategory" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="rr">
                    &nbsp;
                </div>
            </div>
            <div class="a">
                <div class="l">
                    <asp:Label ID="lblSearch" runat="server" Text="<%$ Resources:Language, lblNoiDungL%>"></asp:Label>
                    </div>
                <div class="r">
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                </div>
                <div class="rr">
                    
                </div>
            </div>
            <div class="a">
                <div class="l">
                    &nbsp;
                    </div>
                <div class="rbtn">
                    <asp:Button ID="btnSearch" runat="server" Text="<%$ Resources:Language, btnTimKiemLD%>" 
                        onclick="btnSearch_Click" />
                </div>
                <div class="rr">
                    
                </div>
            </div>
        </fieldset>
    </div>
</asp:Panel>
<h1><span class="green">
    <asp:Label ID="lblAnswer" runat="server" Text="<%$ Resources:Language, lblCacCauHoiL%>"></asp:Label>    
</span></h1>
<asp:Panel ID="pnlResult" runat="server">
    <div class="panel_item">
    <asp:Repeater ID="rptrResultFaq" runat="server">
    <HeaderTemplate>
    <ol class="nice-list">    
        </HeaderTemplate>
    <ItemTemplate>
        <li>
        <asp:HyperLink  ID="lnkTitle" Text='<%#Eval("sQuestion").ToString()%>' NavigateUrl='<%#"~/Content.aspx?faqID="+Eval("PK_iFaqID") %>' runat="server"/>
        </li>  
    </ItemTemplate>
    <FooterTemplate>
    </ol>
    </FooterTemplate>
</asp:Repeater>
</div>
</asp:Panel>
