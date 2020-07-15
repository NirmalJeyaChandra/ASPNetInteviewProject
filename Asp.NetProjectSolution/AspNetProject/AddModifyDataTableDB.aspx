<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddModifyDataTableDB.aspx.cs" Inherits="AddModifyDataTableDB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">       
        <div>
            <asp:GridView ID="gridViewTechnologies" runat="server" AutoGenerateColumns="False" 
                OnRowCancelingEdit="gridViewTechnologies_RowCancelingEdit" 
                OnRowCommand="gridViewTechnologies_RowCommand" 
                OnRowEditing="gridViewTechnologies_RowEditing" 
                OnRowUpdating="gridViewTechnologies_RowUpdating" DataKeyNames="TechnologyId" OnRowDeleting="gridViewTechnologies_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="TechnologyId" HeaderText="TechnologyId" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="Name" Visible="false"/>

                     <asp:TemplateField HeaderText="Name" SortExpression="Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="textBoxName" Text='<%#Eval("Name") %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="textBoxName" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                        </FooterTemplate>

                        <ItemTemplate>
                            <asp:Label ID="labelName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField HeaderText="Edit" Text="Edit" />
                    <asp:CommandField ShowEditButton="True"   />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    <div>
     <asp:Button ID="UpdateDb" runat="server" Text="UpdateDb" OnClick="UpdateDb_Click" />
    </div>
    </form>
</body>
</html>
