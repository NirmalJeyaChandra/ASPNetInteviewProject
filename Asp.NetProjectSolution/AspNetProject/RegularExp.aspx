<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegularExp.aspx.cs" Inherits="RegularExp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="lblName" runat="server" Text="Min 1 and Max 10 characters"></asp:Label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Must be alphabet and with min 1 and max 10 characters in length." ValidationExpression="^[a-zA-Z]{1,10}$"></asp:RegularExpressionValidator>
            </div>

            <div>
                <asp:Label ID="lblNumber" runat="server" Text="Value between 1 to 1000"></asp:Label>
                <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtNumber" ErrorMessage="Value must be between 1 and 1000" ValidationExpression="^(1000)|(([1-9])(\d?)(\d?))$"></asp:RegularExpressionValidator>
            </div>

            <div>
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email" ValidationExpression="^([a-zA-Z0-9]{1,10})[@][a-zA-Z]{1,10}[.][a-zA-Z]{2,3}$"></asp:RegularExpressionValidator>
            </div>

            <div>
                <asp:Label ID="lblUrl" runat="server" Text="URL"></asp:Label>
                <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtUrl" ErrorMessage="Invalid URL" ValidationExpression="^(http)s?[:][/][/](?i)www[.][a-zA-Z]{1,10}[.][a-zA-Z]{3}$"></asp:RegularExpressionValidator>
            </div>

             <div>
                <asp:Label ID="lblMatchGrpChars" runat="server" Text="Match Group Of Characters[wrtuv]"></asp:Label>
                <asp:TextBox ID="txtMatchCharGrp" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="rexpVal" runat="server" ControlToValidate="txtMatchCharGrp" ErrorMessage="Invalid Character Included" ValidationExpression="^[wrtuv]{1,5}$"></asp:RegularExpressionValidator>
            </div>

             <div>
                <asp:Label ID="lblCharNotInGrp" runat="server" Text="Match Group Of Characters Not in [uefjx]"></asp:Label>
                <asp:TextBox ID="txtNotInGrp" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtNotInGrp" ErrorMessage="Invalid Character Included" ValidationExpression="^[^uefjx]{1,5}$"></asp:RegularExpressionValidator>
            </div>

             <div>
                <asp:Label ID="lblWordChar" runat="server" Text="Match any word Characters [\w]"></asp:Label>
                <asp:TextBox ID="txtWordChar" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtWordChar" ErrorMessage="Invalid Character Included" ValidationExpression="^\w{1,5}$"></asp:RegularExpressionValidator>
            </div>

             <div>
                <asp:Label ID="lblNonWordChar" runat="server" Text="Match any non-word Characters. Does not accept underscore [\W]"></asp:Label>
                <asp:TextBox ID="txtNonWordChar" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtNonWordChar" ErrorMessage="Invalid Character Included" ValidationExpression="^\W{1,5}$"></asp:RegularExpressionValidator>
            </div>

             <div>
                <asp:Label ID="lblWhiteSpace" runat="server" Text="Accepts only white space Characters.[\s]"></asp:Label>
                <asp:TextBox ID="txtWhiteSpace" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtWhiteSpace" ErrorMessage="Invalid Character Included" ValidationExpression="\s{1,5}"></asp:RegularExpressionValidator>
            </div>

            <div>
                <asp:Label ID="lblNonWhiteSpace" runat="server" Text="Accepts only non-white space Characters.[\S]"></asp:Label>
                <asp:TextBox ID="txtNonWhiteSpace" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtNonWhiteSpace" ErrorMessage="Invalid Character Included" ValidationExpression="^\S{1,4}$"></asp:RegularExpressionValidator>
            </div>

             <div>
                <asp:Label ID="Label1" runat="server" Text="Accepts only alphabets and numbers "></asp:Label>
                <asp:TextBox ID="txtAlphaNumeric" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtAlphaNumeric" ErrorMessage="Invalid Character Included" ValidationExpression="^[a-zA-Z0-9]{1,10}$"></asp:RegularExpressionValidator>
            </div>

            <div>
                <asp:Button ID="btnSubmit" CausesValidation="true" runat="server" Text="Submit" />
            </div>
        </div>

    </form>
</body>
</html>
