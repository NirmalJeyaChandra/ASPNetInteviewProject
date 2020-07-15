<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUploadForm.aspx.cs" Inherits="FileUploadForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:FileUpload id="FileUploadControl" runat="server" />
    <asp:Button runat="server" id="UploadButton" text="Upload" onclick="UploadButton_Click" />
    <br /><br />
    <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
    </div>
        
        <div><asp:Button ID="ButtonDownload" runat="server" Text="Download" OnClick="ButtonDownload_Click" /></div>
    </form>
</body>
</html>
