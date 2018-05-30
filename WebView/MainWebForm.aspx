<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainWebForm.aspx.cs" Inherits="WebView.MainWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="ChangeData" runat="server" OnClick="ChangeData_Click" Text="Изменить данные" style="height: 25px" />
            <br />
            <br />
            <asp:Button ID="StorageButton" runat="server" OnClick="StorageButton_Click" Text="Склад" Width="100px" />
            <br />
            <asp:Button ID="MailButton" runat="server" OnClick="MailButton_Click" Text="Почта" Width="100px" />
            <br />
            <br />
            <br />
            <asp:Button ID="AddButton" runat="server" OnClick="AddButton_Click" Text="Добавить" Width="100px" />
            <asp:Button ID="ChangeButton" runat="server" OnClick="ChangeButton_Click" Text="Изменить" Width="100px" />
            <asp:Button ID="DeleteButton" runat="server" OnClick="DeleteButton_Click" Text="Удалить" Width="100px" />
            <asp:Button ID="RefreshButton" runat="server" OnClick="RefreshButton_Click" Text="Обновить" Width="100px" />
            <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" DataSourceID="DataSource1">
                <Columns>
                    <asp:CommandField ShowSelectButton="True">
                    <ItemStyle Width="50px" />
                    </asp:CommandField>
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID">
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FoodName" HeaderText="FoodName" SortExpression="FoodName">
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="DataSource1" runat="server" SelectMethod="GetList" TypeName="Classes.ImplementationsBD.FoodServiceBD"></asp:ObjectDataSource>
&nbsp;</div>
    </form>
</body>
</html>
