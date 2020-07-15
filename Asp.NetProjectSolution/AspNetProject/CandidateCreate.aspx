<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="CandidateCreate.aspx.cs" Inherits="CandidateCreate" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css" />
   <%-- <link rel="stylesheet" href="/resources/demos/style.css" />--%>
    <style>
        input::-webkit-calendar-picker-indicator {
            display: none;
        }

        input[type="date"]::-webkit-input-placeholder {
            visibility: hidden !important;
        }

        .divTable {
            border: 3px solid green;
            margin-left: auto;
            margin-right: auto;
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
            /*float:right;*/
        }

        .buttonSave {
            float: right;
        }

        .buttonIndex {
            float: left;
        }
    </style>

</head>
<body>
    <%--Script for using JQuery--%>

    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-migrate-1.2.1.js" type="text/javascript"></script>

    <%--DateTimePicker--%>
    <script src="../Scripts/jquery-ui-1.10.4.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type=" text/javascript"></script>


    <script type="text/javascript">
        $(function () {

            $('tableDiv').width = screen.availWidth;
            $('header').width = screen.availWidth;
            $('footer').width = screen.availWidth;
            $('content').width = screen.availWidth;
            $('leftNav').width = screen.availWidth / 10;
            $('formDiv').width = ((screen.availWidth / 90) * 100);
            $('NameDiv').width = ((screen.availWidth / 90) * 100);
            //alert(((screen.availWidth / 90) * 100))
            //For setting left navigation bar to whole window height
            //$('#leftNav').css({ height: $(window).innerHeight() });
            $(window).resize(function () {
                //alert("insde resize function")
                //$('#leftNav').css({ height: $(window).innerHeight() });
            });
            //$('').css({width: $(window).innerWidth()})

            $("#textBoxDate").datepicker({
                dateFormat: 'yy-mm-dd',
                changeMonth: true,
                changeYear: true,
                yearRange: "-50:+10"
            });

        });
    </script>


    <%--table--%>
    <div id="tableDiv" class="divTable">
        <%-- header--%>
        <div id="header" style="background-color: #b5dcb3; height: 20%; border: 3px solid blue;">
            <h1 style="text-align: center">This is Web Page Header Section</h1>
        </div>
        <%--Content, Navigation wrapper--%>
        <div id="content" style="background-color: #aaa; height: 600px; border: 3px solid red;">
            <%--Left Navigation--%>
            <div id="leftNav" style="background-color: #aaa; height: 600px; float: left; border: 3px solid red;">
                <p>Left Navigation</p>
            </div>
            <%--Content--%>
            <div id="formDiv" style="background-color: #eee; height: 600px; border: 3px solid red;">
                <form id="form1" runat="server">
                    <div id="NameDiv">
                        <asp:Label CssClass="label" ID="Label1" runat="server" Text="Name:" Width="145px"></asp:Label>
                        <asp:TextBox CssClass="textBox" ID="textBoxName" runat="server" ViewStateMode="Disabled"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label CssClass="label" ID="Label2" runat="server" Text="Address:" Width="145px"></asp:Label>
                        <asp:TextBox CssClass="textBox" ID="textBoxAddress" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label CssClass="label" ID="Label3" runat="server" Text="Country:" Width="145px"></asp:Label>
                        <asp:DropDownList CssClass="dropDownList" ID="dropDownListCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropDownListCountry_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div>
                        <asp:Label CssClass="label" ID="Label4" runat="server" Text="State:" Width="145px"></asp:Label>
                        <asp:DropDownList CssClass="dropDownList" ID="dropDownListState" runat="server"></asp:DropDownList>
                    </div>
                    <div>
                        <asp:Label CssClass="label" ID="Label5" runat="server" Text="Phone No:" Width="145px"></asp:Label>
                        <asp:TextBox CssClass="textBox" ID="textBoxPhone" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label CssClass="label" ID="Label6" runat="server" Text="Email:" Width="145px"></asp:Label>
                        <asp:TextBox CssClass="textBox" ID="textBoxEmail" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label CssClass="label" ID="Label7" runat="server" Text="Date of Birth:" Width="145px"></asp:Label>
                        <asp:TextBox CssClass="textBox" ID="textBoxDate" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label CssClass="label" ID="Label8" runat="server" Text="Marital Status:" Width="145px"></asp:Label>
                        <asp:CheckBox CssClass="checkBox" ID="checkBoxMarried" runat="server" />
                    </div>

                    <div style="display: inline">

                        <asp:Label CssClass="label" ID="Label9" runat="server" Text="Gender:" Width="145px"></asp:Label>


                        <asp:RadioButtonList ID="radioButtonListGender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>

                    <%--<asp:RadioButton CssClass="radioButtonList" ID="MaleButton" GroupName="Gender" Text="Male" runat="server" />
                        <asp:RadioButton CssClass="radioButtonList" ID="FemaleButton" GroupName="Gender" Text="Female" runat="server" />--%>

                    <%--<div style="clear:both"></div>--%>

                    <div>
                        <asp:Label CssClass="label" ID="Label10" runat="server" Text="Technologies Known:" Width="145px"></asp:Label>
                        <asp:ListBox CssClass="listBox" ID="listBoxTechs" runat="server" SelectionMode="Multiple"></asp:ListBox>
                    </div>

                    <div>
                        <div style="float: left; margin-left: 50px; margin-top: 10px; width: 145px; border: 3px solid green;">

                            <asp:Button CssClass="buttonSave" ID="buttonSave" runat="server" Text="Save" OnClick="buttonSave_Click" />
                        </div>
                        <div style="float: left; margin-left: 10px; border: 3px solid green; margin-top: 10px;">
                            <asp:Button CssClass="buttonIndex" ID="buttonIndex" runat="server" Text="Back to List" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
        <%-- Footer Section--%>
        <div id="footer" style="background-color: #b5dcb3; height: 20%; clear: both; border: 3px solid blue;">
            <h1 style="text-align: center">This is Web Page Footer Section</h1>
        </div>
    </div>
</body>
</html>
