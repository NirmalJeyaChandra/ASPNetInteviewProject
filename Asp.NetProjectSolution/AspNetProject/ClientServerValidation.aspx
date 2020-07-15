<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientServerValidation.aspx.cs" Inherits="ClientServerValidation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            First Name:
            <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqFieldValidFirstName" runat="server" ErrorMessage="Please fill the first name field..." ControlToValidate="TextBoxFirstName" EnableClientScript="False"></asp:RequiredFieldValidator>
        </div>

        <div>
            Last Name:
            <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqFieldValidLastName" runat="server" ErrorMessage="Please fill the last name field..." ControlToValidate="TextBoxLastName"></asp:RequiredFieldValidator>
        </div>

        <div> <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" /></div>
       
    </form>
</body>
</html>
