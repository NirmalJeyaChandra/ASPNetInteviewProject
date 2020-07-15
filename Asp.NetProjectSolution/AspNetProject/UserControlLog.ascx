<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControlLog.ascx.cs" Inherits="UserControlLog" %>
<asp:Panel ID="Panel1" runat="server">
    <div>User Name: <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox></div>
    <div>Password: <asp:TextBox ID="TxtPassword" runat="server"></asp:TextBox></div>
    <div><asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" /></div>
</asp:Panel>
