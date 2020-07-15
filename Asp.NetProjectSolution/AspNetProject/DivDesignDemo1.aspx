<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DivDesignDemo1.aspx.cs" Inherits="DivDesignDemo1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .divTable {
            border: 3px solid green;
            margin-left: auto;
            margin-right: auto;
            /*display: table;
            padding-top: 10px;
            padding-bottom: 10px;
            padding-right: 10px;
            padding-left: 10px;
            position:relative;*/
        }

        body {
            /*to stop the page from shrinking beyond a particular limit*/
            min-width: 550px;
        }

        .label {
            margin-left: 50px;
            margin-top: 10px;
            text-align: right;
            border: 3px solid green;
        }

        .dropDownList {
            margin-left: 10px;
            margin-top: 10px;
        }

        .textBox {
            margin-left: 10px;
            margin-top: 10px;
            border: 3px solid green;
        }       

        .checkBox {
            margin-left: 10px;
            margin-top: 10px;
            border: 3px solid green;
        }

        .listBox {
            margin-left: 10px;
            margin-top: 10px;
        }

        .radioButtonList {
            margin-left: 10px;
            margin-top: 10px;
            border: 3px solid green;
            vertical-align: middle;
        }
    </style>   

    <script src="Scripts/jquery-1.9.1.js"></script>
</head>
<body> 

    <script type="text/javascript">
        $(function () {
            
            $('header').width = screen.availWidth;
            $('leftNav').width = screen.availWidth / 10;
            $('formDiv').width = ((screen.availWidth / 90) * 100);
            $('NameDiv').width = ((screen.availWidth / 90) * 100);
            $('footer').width = screen.availWidth;      
           
            //$('content').width = screen.availWidth;
            //$('tableDiv').width = screen.availWidth;
            //alert(((screen.availWidth / 90) * 100))
            //For setting left navigation bar to whole window height
            //$('#leftNav').css({ height: $(window).innerHeight() });
            $(window).resize(function () {
                //alert("insde resize function")
                //$('#leftNav').css({ height: $(window).innerHeight() });
            });
            //$('').css({width: $(window).innerWidth()})
        });
    </script>
    <div style="border: 3px solid black;">
    <div id="header" style="background-color: #b5dcb3; height: 20%; border: 3px solid blue;">
            <h1 style="text-align: center">This is Web Page Header Section</h1>
        </div>
     <div id="leftNav" style="background-color: #aaa; height: 600px; float: left; border: 3px solid red;">
                <p>Left Navigation</p>
            </div>
  
           
            <%--Content--%>
         <div id="formDiv" style="background-color: #eee; height: 600px; border: 3px solid red;">
                <form id="form1" runat="server">
                    <div id="NameDiv" >
                        <asp:Label CssClass="label" ID="Label1" runat="server" Text="Name:" Width="145px"></asp:Label>
                        <asp:TextBox CssClass="textBox" ID="TextBox1" runat="server"></asp:TextBox>
                    </div>
                    <div >
                        <asp:Label CssClass="label" ID="Label2" runat="server" Text="Address:" Width="145px"></asp:Label>
                        <asp:TextBox CssClass="textBox" ID="TextBox2" runat="server"></asp:TextBox>
                    </div>
                    <div >
                        <asp:Label CssClass="label" ID="Label3" runat="server" Text="Country:" Width="145px"></asp:Label>
                        <asp:DropDownList CssClass="dropDownList" ID="DropDownList1" runat="server"></asp:DropDownList>
                    </div>
                    <div >
                        <asp:Label CssClass="label" ID="Label4" runat="server" Text="State:" Width="145px"></asp:Label>
                        <asp:DropDownList CssClass="dropDownList" ID="DropDownList2" runat="server"></asp:DropDownList>
                    </div>
                    <div >
                        <asp:Label CssClass="label" ID="Label5" runat="server" Text="Phone No:" Width="145px"></asp:Label>
                        <asp:TextBox CssClass="textBox" ID="TextBox5" runat="server"></asp:TextBox>
                    </div>
                    <div >
                        <asp:Label CssClass="label" ID="Label6" runat="server" Text="Email:" Width="145px"></asp:Label>
                        <asp:TextBox CssClass="textBox" ID="TextBox6" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label CssClass="label" ID="Label7" runat="server" Text="Date of Birth:" Width="145px"></asp:Label>
                        <asp:TextBox CssClass="textBox" ID="TextBox7" runat="server"></asp:TextBox>
                    </div>
                    <div >
                        <asp:Label CssClass="label" ID="Label8" runat="server" Text="Marital Status:" Width="145px"></asp:Label>
                        <asp:CheckBox CssClass="checkBox" ID="CheckBox1" runat="server" />
                    </div>
                    <div style="display: inline">
                        <asp:Label CssClass="label" ID="Label9" runat="server" Text="Gender:" Width="145px"></asp:Label>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>

                    </div>
                    <div >
                        <asp:Label CssClass="label" ID="Label10" runat="server" Text="Technologies Known:" Width="145px"></asp:Label>
                        <asp:ListBox CssClass="listBox" ID="ListBox1" runat="server"></asp:ListBox>
                    </div>
                </form>

            </div>
        
        <%-- Footer Section--%>
        <div id="footer" style="background-color: #b5dcb3; height: 20%; clear: both; border: 3px solid blue;">
            <h1 style="text-align: center">This is Web Page Footer Section</h1>
        </div>
   </div>

</body>
</html>
