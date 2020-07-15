<%@ Page Language="C#" EnableViewState="true" AutoEventWireup="true" CodeFile="CandidateGridView.aspx.cs" Inherits="CandidateGridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%--Script for using JQuery--%>

    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-migrate-1.2.1.js" type="text/javascript"></script>
   

    <%--DateTimePicker--%>
    <script src="../Scripts/jquery-ui-1.10.4.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type=" text/javascript"></script>
    <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
<script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />--%>

    <script type="text/javascript">
        $(function () {
            
            $("[id$=textBoxDateOfBirth]").datepicker({
                    //$("#candidateGridView_textBoxDateOfBirth_0").datepicker({
                dateFormat: 'yy-mm-dd',
                changeMonth: true,
                changeYear: true,
                yearRange: "-50:+10"
            });

            //$("#TextBox1").datepicker({

            //    dateFormat: 'yy-mm-dd',
            //    changeMonth: true,
            //    changeYear: true,
            //    yearRange: "-50:+10"
            //});
        });
    </script>

    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="candidateGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" PageSize="4"
                DataKeyNames="CandidateId" OnPageIndexChanging="candidateGridView_PageIndexChanging"
                OnRowCancelingEdit="candidateGridView_RowCancelingEdit"
                 OnRowEditing="candidateGridView_RowEditing" 
                OnRowDeleting="candidateGridView_RowDeleting" 
                OnRowUpdating="candidateGridView_RowUpdating" 
                OnRowDataBound="candidateGridView_RowDataBound" 
                OnRowCommand="candidateGridView_RowCommand"  
                AllowSorting="True" 
                OnSorting="candidateGridView_Sorting" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="CandidateId" HeaderText="Candidate Id" Visible="False" />

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

                    <asp:TemplateField HeaderText="Address" SortExpression="Address">
                        <EditItemTemplate>
                            <asp:TextBox ID="textBoxAddress" Text='<%#Eval("Address") %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="textBoxAddress" runat="server" Text='<%#Eval("Address") %>'></asp:TextBox>
                        </FooterTemplate>

                        <ItemTemplate>
                            <asp:Label ID="labelAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Country">
                        <EditItemTemplate>
                            <asp:Label ID="labelCountryId" runat="server" Visible="false" Text='<%#Eval("CountryId") %>'></asp:Label>
                            <asp:DropDownList ID="dropDownListCountry" OnSelectedIndexChanged="dropDownListCountry_SelectedIndexChanged" AutoPostBack="true" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:Label ID="labelCountryId" runat="server" Text='<%#Eval("CountryId") %>' Visible="false"></asp:Label>
                            <asp:DropDownList ID="dropDownListCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropDownListCountry_SelectedIndexChanged">
                            </asp:DropDownList>
                        </FooterTemplate>

                        <ItemTemplate>
                            <asp:Label ID="labelCountryId" runat="server" Visible="false" Text='<%#Eval("CountryId") %>'></asp:Label>
                            <asp:DropDownList ID="dropDownListCountry" AutoPostBack="true" OnSelectedIndexChanged="dropDownListCountry_SelectedIndexChanged" runat="server" Enabled="false">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="State">
                        <EditItemTemplate>
                            <asp:Label ID="labelStateId" runat="server" Visible="false" Text='<%#Eval("StateId") %>'></asp:Label>
                            <asp:DropDownList ID="dropDownListState" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:Label ID="labelStateId" runat="server" Text='<%#Eval("StateId") %>' Visible="false"></asp:Label>
                            <asp:DropDownList ID="dropDownListState" runat="server">
                            </asp:DropDownList>
                        </FooterTemplate>

                        <ItemTemplate>
                            <asp:Label ID="labelStateId" runat="server" Visible="false" Text='<%#Eval("StateId") %>'></asp:Label>
                            <asp:DropDownList ID="dropDownListState" runat="server" Enabled="false">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email" SortExpression="Email">
                        <EditItemTemplate>
                            <asp:TextBox ID="textBoxEmail" Text='<%#Eval("Email") %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="textBoxEmail" runat="server" Text='<%#Eval("Email") %>'></asp:TextBox>
                        </FooterTemplate>

                        <ItemTemplate>
                            <asp:Label ID="labelEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date Of Birth">
                        <EditItemTemplate>
                            <asp:TextBox ID="textBoxDateOfBirth" Text='<%#Eval("DateOfBirth") %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:TextBox ID="textBoxDateOfBirth" runat="server" Text='<%#Eval("DateOfBirth") %>'></asp:TextBox>
                        </FooterTemplate>

                        <ItemTemplate>
                             <asp:TextBox ID="textBoxDateOfBirth"  runat="server"></asp:TextBox>
                            <%--<asp:Label ID="labelDateOfBirth" runat="server" Text='<%#Eval("DateOfBirth") %>'></asp:Label>--%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Marital Status">
                        <EditItemTemplate>
                            <asp:CheckBox ID="textBoxMaritalStatus" Checked='<%#Eval("MaritalStatus") %>' runat="server"></asp:CheckBox>
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:CheckBox ID="checkBoxMaritalStatus" runat="server"  /> <%--Checked='<%#Eval("MaritalStatus") %>'--%>
                        </FooterTemplate>

                        <ItemTemplate>
                            <asp:CheckBox ID="labelMaritalStatus" runat="server" Checked='<%#Eval("MaritalStatus") %>'></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Gender" SortExpression="Gender">
                        <EditItemTemplate>
                            <asp:Label ID="labelGender" runat="server" Visible="false" Text='<%#Eval("Gender") %>'></asp:Label>
                            <asp:RadioButtonList ID="radioButtonListGender" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:RadioButtonList>
                        </EditItemTemplate>

                        <FooterTemplate>
                            <asp:Label ID="labelGender" runat="server" Text='<%#Eval("Gender") %>' Visible="false"></asp:Label>
                            <asp:RadioButtonList ID="radioButtonListGender" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:Button ID="buttonCancel" CommandName="Cancel" CommandArgument="Insert" runat="server" Text="Cancel" Visible="true" />
                            <asp:Button ID="buttonInsert" CommandName="Insert" CommandArgument="Insert" runat="server" Text="Insert" Visible="true" />
                        </FooterTemplate>

                        <ItemTemplate>
                            <asp:Label ID="labelGender" runat="server" Visible="false" Text='<%#Eval("Gender") %>'></asp:Label>
                            <asp:RadioButtonList ID="radioButtonListGender" Width="75px" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:RadioButtonList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="Action" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" ShowInsertButton="True" />
                    <asp:HyperLinkField Text="Add" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>

        </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </form>
</body>
</html>
