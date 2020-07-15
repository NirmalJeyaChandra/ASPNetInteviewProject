<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrorHandling.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id$=txtProductDate]").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: 'http://jqueryui.com/demos/datepicker/images/calendar.gif'
            });
            //$("[id$=txtProductDate]").datepicker({
            //    dateFormat: 'yy-mm-dd',
            //    changeMonth: true,
            //    changeYear: true,
            //    yearRange: "-50:+10"
            //});

        });
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns = "false">
    <Columns>
    <asp:BoundField DataField = "ProductName" HeaderText = "Product Name" />
    <asp:TemplateField HeaderText = "Product Date">
    <ItemTemplate>
        <asp:TextBox ID="txtProductDate" runat="server" ReadOnly = "true"></asp:TextBox>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
