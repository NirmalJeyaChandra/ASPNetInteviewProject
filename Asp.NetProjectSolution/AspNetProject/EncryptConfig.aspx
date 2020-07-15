<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EncryptConfig.aspx.cs" Inherits="EncryptConfig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span>
                <asp:TextBox ID="txtEncryptSection" runat="server"></asp:TextBox>
            </span>

            <span>
                <asp:Button ID="btnEncrypt" runat="server" Text="Encrypt" OnClick="btnEncrypt_Click" />
            </span>

            <span>
                <asp:Button ID="btnUnEncrypt" runat="server" Text="Unencrypt" OnClick="btnUnEncrypt_Click" />
            </span>
        </div>
    </form>

</body>

</html>
