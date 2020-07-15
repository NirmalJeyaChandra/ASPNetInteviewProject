<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditUpdateCandidate.aspx.cs" Inherits="EditUpdateCandidate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .label {
            margin-left: 50px;
            margin-top: 10px;
            text-align: right;
            Width: 175px;
            border: 3px solid green;
        }

        .textBox {
            margin-left: 10px;
            margin-top: 10px;
            border: 3px solid green;
        }

        .lblClass {
            text-align: right;
        }

        .txtClass {
            text-align: left;
        }
    </style>
</head>
<body style="background-color:lightgrey">
    <form id="form1" runat="server">
        <table style="width: 100%; text-align: center">
            <tr>
                <td class="lblClass">
                    <asp:Label ID="lblName" Text="Name:" runat="server"></asp:Label></td>
                <td class="txtClass">
                    <asp:TextBox ID="txtBoxName" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td class="lblClass">
                    <asp:Label ID="lblAddress" Text="Address:" runat="server"></asp:Label></td>
                <td class="txtClass">
                    <asp:TextBox ID="txtBoxAddress" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td class="lblClass">
                    <asp:Label ID="lblCountry" Text="Country:" runat="server"></asp:Label></td>
                <td class="txtClass">
                    <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>

            <tr>
                <td class="lblClass">
                    <asp:Label ID="lblState" Text="State:" runat="server"></asp:Label></td>
                <td class="txtClass">
                    <asp:DropDownList ID="ddlState" runat="server"></asp:DropDownList></td>
            </tr>

            <tr>
                <td class="lblClass">
                    <asp:Label ID="lblPhone" Text="Phone Number:" runat="server"></asp:Label></td>
                <td class="txtClass">
                    <asp:TextBox ID="txtBoxPhone" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td class="lblClass">
                    <asp:Label ID="lblEmail" Text="Email:" runat="server"></asp:Label></td>
                <td class="txtClass">
                    <asp:TextBox ID="txtBoxEmail" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td class="lblClass">
                    <asp:Label ID="lblDateOfBirth" Text="Date Of Birth:" runat="server"></asp:Label></td>
                <td class="txtClass">
                    <asp:TextBox ID="txtBoxDateOfBirth" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td class="lblClass">
                    <asp:Label ID="lblMarried" Text="Married:" runat="server"></asp:Label></td>
                <td class="txtClass">
                    <asp:CheckBox ID="chkBoxMarried" Text="" runat="server"></asp:CheckBox></td>
            </tr>

            <tr>
                <td class="lblClass">
                    <asp:Label ID="lblGender" Text="Gender:" runat="server"></asp:Label></td>
                <td class="txtClass">
                    <asp:RadioButtonList ID="rdbtnListGender" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                   
                </td>
            </tr>

            <tr style="text-align:center">
                <td colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                    <asp:Button ID="btnReset" runat="server" Text="Reset" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
