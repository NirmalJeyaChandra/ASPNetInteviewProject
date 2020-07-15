<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CandidateListView.aspx.cs" Inherits="CandidateListView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <%--InsertItemPosition="LastItem"--%>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView ID="ListViewCandidates" runat="server" DataKeyNames="CandidateId" DataSourceID="SqlDataSourceCandidates"  OnItemDataBound="ListViewCandidates_ItemDataBound" OnItemCreated="ListViewCandidates_ItemCreated" OnItemUpdated="ListViewCandidates_ItemUpdated" OnItemCommand="ListViewCandidates_ItemCommand">

                <LayoutTemplate>                     
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                  <%--  Header--%>
                                    <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                        <th runat="server">                                            
                                            <asp:LinkButton runat="server" ID="LinkButtonCandidateId" Text="CandidateId" CommandName="Sort" CommandArgument="CandidateId" />
                                        </th>
                                        <th runat="server">                                            
                                            <asp:LinkButton runat="server" ID="LinkButtonName" Text="Name" CommandName="Sort" CommandArgument="CandidateId" />
                                        </th>
                                        <th runat="server">                                            
                                            <asp:LinkButton runat="server" ID="LinkButtonAddress" Text="Address" CommandName="Sort" CommandArgument="CandidateId" />
                                        </th>
                                        <th runat="server">                                            
                                            <asp:LinkButton runat="server" ID="LinkButton1" Text="CountryId" CommandName="Sort" CommandArgument="CandidateId" />
                                        </th>
                                        <th runat="server">                                            
                                            <asp:LinkButton runat="server" ID="LinkButton2" Text="StateId" CommandName="Sort" CommandArgument="CandidateId" />
                                        </th>
                                        <th runat="server">                                            
                                            <asp:LinkButton runat="server" ID="LinkButton3" Text="PhoneNumber" CommandName="Sort" CommandArgument="CandidateId" />
                                        </th>
                                        <th runat="server">
                                           <asp:LinkButton runat="server" ID="LinkButton4" Text="Email" CommandName="Sort" CommandArgument="CandidateId" /> 
                                        </th>
                                        <th runat="server">                                            
                                            <asp:LinkButton runat="server" ID="LinkButton5" Text="DateOfBirth" CommandName="Sort" CommandArgument="CandidateId" /> 
                                        </th>
                                        <th runat="server">                                            
                                            <asp:LinkButton runat="server" ID="LinkButton6" Text="Marrried" CommandName="Sort" CommandArgument="CandidateId" /> 
                                        </th>
                                        <th runat="server">                                            
                                             <asp:LinkButton runat="server" ID="LinkButton7" Text="Gender" CommandName="Sort" CommandArgument="CandidateId" /> 
                                        </th>
                                        <th><asp:LinkButton runat="server" ID="LinkButton8" Text="Action" CommandName="Sort" CommandArgument="CandidateId" /> </th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <%--Paging--%>
                        <tr runat="server">
                            <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                                <asp:DataPager PageSize="4" ID="DataPager1" runat="server">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowNextPageButton="true" ShowPreviousPageButton="true" />
                                        <asp:NumericPagerField ButtonCount="5" PreviousPageText="<--"     NextPageText="-->" />
                                       
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>

                <ItemTemplate>
                    <tr style="background-color:#DCDCDC;color: #000000;">
                        <td>
                            <asp:Label ID="CandidateIdLabel" runat="server" Text='<%# Eval("CandidateId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CountryIdLabel" runat="server" Visible="false" Text='<%# Eval("CountryId") %>' />                            
                             <asp:DropDownList ID="dropDownListCountry"  runat="server" Enabled="false">
                            </asp:DropDownList>                            
                        </td>
                        <td>
                            <asp:Label ID="StateIdLabel" runat="server" Visible="false" Text='<%# Eval("StateId") %>' />                            
                             <asp:DropDownList ID="dropDownListState"  runat="server" Enabled="false">
                            </asp:DropDownList>                             
                        </td>
                        <td>
                            <asp:Label ID="PhoneNumberLabel" runat="server" Text='<%# Eval("PhoneNumber") %>' />
                        </td>
                        <td>
                            <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DateOfBirthLabel" runat="server" Text='<%# Eval("DateOfBirth") %>' />
                        </td>
                        <td>
                            <asp:CheckBox ID="MaritalStatusCheckBox" runat="server" Checked='<%# Eval("MaritalStatus") %>' Enabled="false" />
                            </td>
                        <td>
                            <asp:Label ID="GenderLabel" runat="server" Text='<%# Eval("Gender") %>' />
                        </td>
                        <td>
                            <asp:LinkButton runat="server" ID="LinkButton7" Text="Edit" CommandName="Edit"/> 
                             <asp:LinkButton runat="server" ID="LinkButton9" Text="Delete" CommandName="Delete"/> 
                        </td>
                    </tr>
                </ItemTemplate>

                <AlternatingItemTemplate>
                    <tr style="background-color:#FFF8DC;">
                        <td>
                            <asp:Label ID="CandidateIdLabel" runat="server" Text='<%# Eval("CandidateId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' />
                        </td>
                        <td>
                              <asp:Label ID="CountryIdLabel" runat="server" Visible="false" Text='<%# Eval("CountryId") %>' />                            
                             <asp:DropDownList ID="dropDownListCountry"  runat="server" Enabled="false">
                            </asp:DropDownList>                            
                        </td>
                        <td>                            
                            <asp:Label ID="StateIdLabel" runat="server" Visible="false" Text='<%# Eval("StateId") %>' />
                             <asp:DropDownList ID="dropDownListState"   runat="server" Enabled="false">
                            </asp:DropDownList>                     
                           
                        </td>
                        <td>
                            <asp:Label ID="PhoneNumberLabel" runat="server" Text='<%# Eval("PhoneNumber") %>' />
                        </td>
                        <td>
                            <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DateOfBirthLabel" runat="server" Text='<%# Eval("DateOfBirth") %>' />
                        </td>
                        <td>
                            <asp:CheckBox ID="MaritalStatusCheckBox" runat="server" Checked='<%# Eval("MaritalStatus") %>' Enabled="false" />
                        </td>
                        <td>
                            <asp:Label ID="GenderLabel" runat="server" Text='<%# Eval("Gender") %>' />
                        </td>
                        <td>
                            <asp:LinkButton runat="server" ID="LinkButton7" Text="Edit" CommandName="Edit"/> 
                             <asp:LinkButton runat="server" ID="LinkButton9" Text="Delete" CommandName="Delete"/> 
                        </td>
                    </tr>
                </AlternatingItemTemplate>

                <SelectedItemTemplate>
                    <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                        <td>
                            <asp:Label ID="CandidateIdLabel" runat="server" Text='<%# Eval("CandidateId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Eval("CountryId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="StateIdLabel" runat="server" Text='<%# Eval("StateId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="PhoneNumberLabel" runat="server" Text='<%# Eval("PhoneNumber") %>' />
                        </td>
                        <td>
                            <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DateOfBirthLabel" runat="server" Text='<%# Eval("DateOfBirth") %>' />
                        </td>
                        <td>
                            <asp:CheckBox ID="MaritalStatusCheckBox" runat="server" Checked='<%# Eval("MaritalStatus") %>' Enabled="false" />
                        </td>
                        <td>
                            <asp:Label ID="GenderLabel" runat="server" Text='<%# Eval("Gender") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>

                <%--  <EditItemTemplate>
                    <tr style="background-color:#008A8C;color: #FFFFFF;">
                        
                        <td>
                            <asp:Label ID="CandidateIdLabel1" runat="server" Text='<%# Eval("CandidateId") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CountryIdLabel" runat="server" Visible="false" Text='<%# Bind("CountryId") %>' />
                             <asp:DropDownList ViewStateMode="Enabled" ID="dropDownListCountry" OnSelectedIndexChanged="dropDownListCountry_SelectedIndexChanged" DataSourceID="SqlDataSourceCountry" DataTextField="Name" AppendDataBoundItems="true" SelectedValue='<%# Bind("CountryId") %>'  DataValueField="CountryId"    AutoPostBack="true" runat="server">
                            </asp:DropDownList>
                             <asp:SqlDataSource ID="SqlDataSourceCountry" runat="server" ConnectionString="<%$ ConnectionStrings:MVCProjectConnectionString %>" SelectCommand="SELECT * FROM [Countries]"></asp:SqlDataSource>
                        </td>
                        <td>
                            <asp:Label ID="StateIdLabel" runat="server" Visible="false" Text='<%# Bind("StateId") %>' />
                            <asp:DropDownList ViewStateMode="Enabled" ID="dropDownListState" AppendDataBoundItems="true"  runat="server">
                            </asp:DropDownList>
                        <asp:DropDownList ViewStateMode="Enabled" ID="dropDownList1" AppendDataBoundItems="true" DataSourceID="SqlDataSourceState"  DataTextField="Name" DataValueField="StateId" runat="server">
                            </asp:DropDownList>
                         <asp:SqlDataSource ID="SqlDataSourceState"  
                                  ConnectionString="<%$ ConnectionStrings:MVCProjectConnectionString %>" runat="server"
                                SelectCommand="Select [CountryId], [StateId], [Name] from States" FilterExpression="CountryId='{0}'">  
             <FilterParameters>
                <asp:ControlParameter Name="CountryParam" ControlID="dropDownListCountry"
                     PropertyName="SelectedValue" />
                </FilterParameters>     
                                    </asp:SqlDataSource>
                     </td>
                        <td>
                            <asp:TextBox ID="PhoneNumberTextBox" runat="server" Text='<%# Bind("PhoneNumber") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="DateOfBirthTextBox" runat="server" Text='<%# Bind("DateOfBirth") %>' />
                        </td>
                        <td>
                            <asp:CheckBox ID="MaritalStatusCheckBox" runat="server" Checked='<%# Bind("MaritalStatus") %>' />
                        </td>
                        <td>
                            <asp:Label ID="GenderLabel" runat="server" Visible="false" Text='<%# Bind("Gender") %>' />
                             <asp:RadioButtonList ID="radioButtonListGender"  runat="server" RepeatDirection="Vertical" RepeatLayout="Flow">
                                <asp:ListItem >Male</asp:ListItem>
                                <asp:ListItem >Female</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                         <td>
                            <asp:LinkButton runat="server" ID="LinkButton7" Text="Update" CommandName="Update"/> 
                             <asp:LinkButton runat="server" ID="LinkButton9" Text="Cancel" CommandName="Cancel"/> 
                        </td>
                    </tr>
                </EditItemTemplate>--%>

                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>

                <%-- <InsertItemTemplate>
                    <tr style="">
                       
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' />
                        </td>
                        <td>
                             <asp:DropDownList ViewStateMode="Enabled" ID="dropDownListCountry" OnSelectedIndexChanged="dropDownListCountry_SelectedIndexChanged" DataSourceID="SqlDataSourceCountry" DataTextField="Name" AppendDataBoundItems="true" SelectedValue='<%# Bind("CountryId") %>'  DataValueField="CountryId"    AutoPostBack="true" runat="server">
                            </asp:DropDownList>
                             <asp:SqlDataSource ID="SqlDataSourceCountry" runat="server" ConnectionString="<%$ ConnectionStrings:MVCProjectConnectionString %>" SelectCommand="SELECT * FROM [Countries]"></asp:SqlDataSource>
                        </td>
                        <td>
                              <asp:Label ID="StateIdLabel" runat="server" Visible="false" Text='<%# Bind("StateId") %>' />
                            <asp:DropDownList ViewStateMode="Enabled" ID="dropDownListState" AppendDataBoundItems="true"  runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="PhoneNumberTextBox" runat="server" Text='<%# Bind("PhoneNumber") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="DateOfBirthTextBox" runat="server" Text='<%# Bind("DateOfBirth") %>' />
                        </td>
                        <td>
                            <asp:CheckBox ID="MaritalStatusCheckBox" runat="server" Checked='<%# Bind("MaritalStatus") %>' />
                        </td>
                        <td>
                            <asp:Label ID="GenderLabel" runat="server" Visible="true" Text='<%# Bind("Gender") %>' />
                             <asp:RadioButtonList ID="radioButtonListGender" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                         <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        </td>
                    </tr>
                </InsertItemTemplate>--%>   

               

            </asp:ListView>
        </div>
        
      
        <asp:SqlDataSource ID="SqlDataSourceCandidates" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MVCProjectConnectionString %>" 
            SelectCommand="SELECT * FROM [Candidates]" 
            DeleteCommand="DELETE FROM Candidates WHERE (CandidateId = @CandidateId)" 
            UpdateCommand="UPDATE Candidates SET Address =@Address, Name =@Name, CountryId =@CountryId, StateId =@StateId, PhoneNumber =@PhoneNumber, Email =@Email, DateOfBirth =@DateOfBirth, MaritalStatus =@MaritalStatus, Gender =@Gender where CandidateId =@CandidateId" 
            InsertCommand="INSERT INTO Candidates(Name, Address, CountryId, StateId, PhoneNumber, Email, DateOfBirth, MaritalStatus, Gender) VALUES (@Name,@Address,@CountryId,@StateId,@PhoneNumber,@Email,@DateOfBirth,@MaritalStatus,@Gender)"
           
            >
            <DeleteParameters>
                <asp:Parameter Name="CandidateId" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Name" />
                <asp:Parameter Name="Address" />
                 <asp:Parameter Name="CountryId" />
                <asp:Parameter Name="StateId" />
                <asp:Parameter Name="PhoneNumber" />
                <asp:Parameter Name="Email" />
                <asp:Parameter Name="DateOfBirth" />
                <asp:Parameter Name="MaritalStatus" />
                <asp:Parameter Name="Gender" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Address" />
                <asp:Parameter Name="Name" />
                <asp:Parameter Name="CountryId" />
                <asp:Parameter Name="StateId" />
                <asp:Parameter Name="PhoneNumber" />
                <asp:Parameter Name="Email" />
                <asp:Parameter Name="DateOfBirth" />
                <asp:Parameter Name="MaritalStatus" />
                <asp:Parameter Name="Gender" />
                <asp:ControlParameter ControlID="ListViewCandidates" Name="CandidateId" PropertyName="SelectedValue" />
            </UpdateParameters>
            
        </asp:SqlDataSource>
    </form>
</body>
</html>
