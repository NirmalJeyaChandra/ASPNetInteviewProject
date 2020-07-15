<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResourceFileDemo.aspx.cs" Inherits="ResourceFileDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <%-- Getting the Resource file value directly inside the view page--%>
        <asp:Label ID="lblMessage" runat="server" Text="<%$ Resources:MessageResources, PasswordLength %>" ></asp:Label>
    <asp:Label ID="lblPasswordError" runat="server"  ></asp:Label>
    </div>

        <div><asp:GridView ID="gvResourceEditor" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvResourceEditor_RowCancelingEdit" 
            OnRowEditing="gvResourceEditor_RowEditing" OnRowUpdating="gvResourceEditor_RowUpdating"            CellPadding="0" BorderWidth="0px" Width="100%" meta:resourcekey="gvResourceEditorResource1"> 
            <Columns> 
                <asp:TemplateField HeaderText="Key" meta:resourcekey="TemplateFieldResource1"> 
                    <EditItemTemplate> 
                        <asp:Label ID="lblKey" runat="server" Text='<%# Eval("Key") %>' meta:resourcekey="lblKeyResource1"></asp:Label> 
                    </EditItemTemplate> 
                    <ItemTemplate> 
                        <asp:Label ID="lblKey" runat="server" Text='<%# Eval("Key") %>' meta:resourcekey="lblKeyResource2"></asp:Label> 
                    </ItemTemplate> 
                    <ItemStyle CssClass="gridText tenXPadding bottomBorder rightBorder" Wrap="True" VerticalAlign="Top" 
                        Width="10%" /> 
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="TEXT" meta:resourcekey="TemplateFieldResource2"> 
                    <HeaderStyle BorderWidth="0" BorderColor="White" BorderStyle="None" /> 
                    <EditItemTemplate> 
                        <asp:TextBox ID="txtValue" TextMode="MultiLine" CssClass="textBoxEnabled" runat="server" 
                            Text='<%# Bind("Value") %>' Width="100%" Height="150px" meta:resourcekey="txtValueResource1"></asp:TextBox> 
                    </EditItemTemplate> 
                    <ItemTemplate> 
                        <asp:Label ID="lblValue" runat="server" Text='<%# Bind("Value") %>' meta:resourcekey="lblValueResource1"></asp:Label> 
                    </ItemTemplate> 
                    <ItemStyle CssClass="gridText tenXPadding rightBorder bottomBorder" Wrap="True" Width="35%" 
                        VerticalAlign="Top" /> 
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="COMMENTS" meta:resourcekey="TemplateFieldResource3"> 
                    <HeaderStyle BorderWidth="0" BorderColor="White" BorderStyle="None" /> 
                    <EditItemTemplate> 
                        <asp:TextBox ID="txtComment" TextMode="MultiLine" CssClass="textBoxEnabled" runat="server" 
                            Text='<%# Bind("Comment") %>' Width="100%" Height="150px" meta:resourcekey="txtDescriptionResource1"></asp:TextBox> 
                    </EditItemTemplate> 
                    <ItemTemplate> 
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Comment") %>' meta:resourcekey="lblDescriptionResource1"></asp:Label> 
                    </ItemTemplate> 
                    <ItemStyle CssClass="gridText tenXPadding rightBorder bottomBorder" Wrap="True" Width="35%" 
                        VerticalAlign="Top" /> 
                </asp:TemplateField> 
                <asp:CommandField ButtonType="Button" ItemStyle-CssClass="tenXPadding bottomBorder" 
                    ShowEditButton="True" ControlStyle-CssClass="buttonEnabled" ItemStyle-VerticalAlign="Top" 
                    HeaderStyle-BorderColor="White" HeaderStyle-BorderWidth="0" HeaderStyle-BorderStyle="None" 
                    ItemStyle-Width="20%" meta:resourcekey="CommandFieldResource1"> 
                    <ControlStyle CssClass="buttonEnabled"></ControlStyle> 
                    <HeaderStyle BorderColor="White" BorderWidth="0px" BorderStyle="None"></HeaderStyle> 
                    <ItemStyle VerticalAlign="Top" CssClass="tenXPadding bottomBorder" Width="20%"></ItemStyle> 
                </asp:CommandField> 
            </Columns> 
        </asp:GridView></div>
        
    </form>
</body>
</html>
