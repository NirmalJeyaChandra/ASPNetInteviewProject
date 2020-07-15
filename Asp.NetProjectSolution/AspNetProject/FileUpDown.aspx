<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUpDown.aspx.cs" Inherits="FileUpDown" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmDefault" enctype="multipart/form-data" runat="server">
<div style="width: 400px">
    <div style="clear: both; width: 100%">
        <input type="file" name="fileInput" />
        <asp:Button ID="btnUpload" Text="Upload File" runat="server" 
            onclick="btnUpload_Click" />
    </div>
    <div style="margin-top: 5px; clear: both">
        <asp:GridView ID="gvFiles" CssClass="GridViewStyle"
            AutoGenerateColumns="true" runat="server">
            <FooterStyle CssClass="GridViewFooterStyle" />
            <RowStyle CssClass="GridViewRowStyle" />    
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
            <PagerStyle CssClass="GridViewPagerStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink runat="server"
                            NavigateUrl='<%# Eval("ID", "GetFile.aspx?ID={0}") %>'
                            Text="Download"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>
</form>
</body>
</html>
