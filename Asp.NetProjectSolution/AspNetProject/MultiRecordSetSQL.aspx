<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MultiRecordSetSQL.aspx.cs" Inherits="MultiRecordSetSQL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
    <div>

        <asp:GridView ID="GridViewRecordSet" runat="server"></asp:GridView><br />
    <asp:Button ID="Table1" runat="server" Text="Table1" OnClick="Table1_Click" /> &nbsp; 
    <asp:Button ID="Table2" runat="server" Text="Table2" OnClick="Table2_Click" />&nbsp;
    <asp:Button ID="Table3" runat="server" Text="Table3" OnClick="Table3_Click" />
    </div>
    </form>
</body>
</html>
