<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="ShopAroundWeb.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:Button ID="btnSend" runat="server" Text="Button" OnClick="btnSend_Click" />
    </form>
</body>
</html>
