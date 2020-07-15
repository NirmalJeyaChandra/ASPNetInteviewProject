<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WCFDebuggingTest.aspx.cs" Inherits="WCFDebuggingTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBoxNum" runat="server"></asp:TextBox>
        <asp:Button ID="btnShowValue" runat="server" OnClick="btnShowValue_Click" style="height: 26px" Text="ShowValue" />

        <div></div>
        
    <div><asp:Button ID="HttpsService" runat="server" Text="HttpsService" OnClick="HttpsService_Click"  /></div>
    </div>

    </form>
</body>
</html>
