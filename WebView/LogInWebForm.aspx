<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInWebForm.aspx.cs" Inherits="WebView.LogInForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div aria-orientation="vertical" aria-sort="ascending" style="height: 203px; width: 249px; position: absolute; top: 33px; left: 749px; bottom: 601px;" aria-multiselectable="True">
            <asp:Button ID="RegButton" runat="server" OnClick="RegButton_Click" Text="Регистрация" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Логин" Width="70px"></asp:Label>
            <asp:TextBox ID="LoginTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Пароль" Width="70px"></asp:Label>
            <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="EnterButton" runat="server" OnClick="EnterButton_Click" Text="Войти" />
        </div>
    </form>
</body>
</html>
