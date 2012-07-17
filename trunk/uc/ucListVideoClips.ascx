<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucListVideoClips.ascx.cs"
    Inherits="uc_ucListVideoClips" %>
<table>
    <asp:Repeater ID="rptVideoClips" runat="server">
        <ItemTemplate>
            <tr>
                <td>
                    <object id="player" classid="clsid:6BF52A52-394A-11D3-B153-00C04F79FAA6" height="90"
                        width="150">
                        <param name="url" value='<%=ResolveUrl("~/adminx/VideoHandler.ashx")%><%# "?iVideoID=" + Eval("PK_iVideoID") %>' />
                        <param name="showcontrols" value="true" />
                        <param name="autostart" value="true" />
                    </object>
                    
                </td>
            </tr>
            
        </ItemTemplate>
    </asp:Repeater>
</table>
