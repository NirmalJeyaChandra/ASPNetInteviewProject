<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AccessMasterField.aspx.cs" Inherits="AccessMasterField" %>
<%@ MasterType TypeName="MasterPage"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    Hi From Nirmal.........
    <asp:Button ID="ButtonMessage" runat="server" Text="Master Message" OnClick="ButtonMessage_Click" />

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
</asp:Content>

