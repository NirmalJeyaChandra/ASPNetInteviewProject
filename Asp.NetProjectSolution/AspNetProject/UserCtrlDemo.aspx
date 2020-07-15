<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserCtrlDemo.aspx.cs" Inherits="UserCtrlDemo" %>
<%--Registering user control--%>
<%@ Register Src="~/UserControlLog.ascx" TagPrefix="uc1" TagName="UserControlLog" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <%--  User Control Event attached to event handler--%>
        <uc1:UserControlLog runat="server" OnuserValidated="loginUserCtrl_Validated" id="UserControlLog" />
    </div>
    </form>
</body>
</html>
