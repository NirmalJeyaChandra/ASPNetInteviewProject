<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaticVariable.aspx.cs" Inherits="StaticVariable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Value: <asp:TextBox ID="txtValue" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnAssignValue" runat="server" Text="Assign Value" OnClick="btnAssignValue_Click" /><br />
        Message:  <asp:TextBox ID="txtMessage" runat="server"></asp:TextBox><br />
         <asp:Button ID="btnAssignMess" runat="server" Text="Assgn Message" OnClick="btnAssignMess_Click" /><br />

        <asp:Button ID="btnMessage" runat="server" Text="Show Message" OnClick="btnMessage_Click" /><br />
       
      <asp:Button ID="btnIncre" runat="server" Text="Incre Value" OnClick="btnIncre_Click"   /> <br />
    <asp:Button ID="btnShowValue" runat="server" Text="Show Value" OnClick="btnShowValue_Click"  /><br />
    
        <asp:Button ID="BtnViewState" runat="server" OnClick="BtnViewState_Click" Text="View State" />
    </div>
    </form>
</body>
</html>
