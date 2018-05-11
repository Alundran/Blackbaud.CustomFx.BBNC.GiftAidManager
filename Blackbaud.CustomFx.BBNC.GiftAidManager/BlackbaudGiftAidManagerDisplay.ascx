<%@ assembly Name="Blackbaud.CustomFx.BBNC.GiftAidManager"%>
<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BlackbaudGiftAidManagerDisplay.ascx.vb" Inherits="Blackbaud.CustomFx.BBNC.GiftAidManager.BlackbaudGiftAidManagerDisplay" %>
<%@ import Namespace="Blackbaud.CustomFx.BBNC.GiftAidManager"%>
<style type="text/css">
    .auto-style2 {
        width: 91px;
    }
    .auto-style6 {
        width: 122px;
        height: 24px;
    }
    .auto-style7 {
        height: 24px;
    }
    .auto-style9 {
        width: 122px;
    }
    .auto-style10 {
        width: 122px;
        height: 34px;
    }
    .auto-style11 {
        height: 34px;
    }
</style>
<asp:Label ID="lblError" runat="server" Font-Bold="true" ForeColor="red" />
<br />
<asp:Label ID="LabelConsoleLog" runat="server"></asp:Label>
<br />
<br />
<asp:Panel ID="Panel1" runat="server" Height="265px" Width="607px">
    <asp:Label ID="lblCaptionHeader" runat="server" Text="By ensuring you have a valid Gift Aid declaration with our charity, we can claim the basic rate tax of your gift at no extra cost to you. This means that the value of your donation can be increased by 25% which further helps our efforts. Click Submit below to see if we hold a valid declaration for you."></asp:Label>
    <br />
    <br />
    <table style="width:100%;">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="ConsIDLabel" runat="server" Text="Constituent ID:"></asp:Label>
            </td>
            <td style="margin-left: 40px">
                <asp:TextBox ID="ConsIDText" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Submit" />
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style10">
                            <asp:Label ID="Surname_Label" runat="server" Font-Bold="True" Font-Size="Large" Text="Surname:" Visible="False"></asp:Label>
                        </td>
                        <td class="auto-style11">
                            <asp:Label ID="Surname_Result_Label" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                            <asp:Label ID="CreatedOn_Label" runat="server" Font-Bold="True" Font-Size="Large" Text="Created On:" Visible="False"></asp:Label>
                        </td>
                        <td class="auto-style7">
                            <asp:Label ID="CreatedOn_Result_Label" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>
<p>
    &nbsp;</p>
