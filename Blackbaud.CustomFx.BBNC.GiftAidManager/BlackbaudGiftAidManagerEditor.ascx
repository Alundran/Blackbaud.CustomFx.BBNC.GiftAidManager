<%@ assembly Name="Blackbaud.CustomFx.BBNC.GiftAidManager"%>
<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BlackbaudGiftAidManagerEditor.ascx.vb" Inherits="Blackbaud.CustomFx.BBNC.GiftAidManager.BlackbaudGiftAidManagerEditor" %>
<%@ import Namespace="Blackbaud.CustomFx.BBNC.GiftAidManager"%>
<style type="text/css">
    .auto-style2 {
        width: 64px;
    }
</style>
<asp:Label ID="lblError" runat="server" Font-Bold="true" ForeColor="red" />
<p>
    &nbsp;</p>
<asp:Panel ID="Panel1" runat="server" Height="240px" Width="933px">
    Enter your Blackbaud Gift Aid credentials below in order to make a successful connection to the web service.<br />
    <br />
    <table style="width:100%;">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="UsernameLabel" runat="server" Text="Username:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="UsernameText" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="PasswordLabel" runat="server" Text="Password:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="PasswordText" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Panel>
