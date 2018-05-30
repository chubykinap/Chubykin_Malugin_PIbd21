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
            <asp:Button ID="ChangeData" runat="server" OnClick="Button1_Click" Text="Изменить данные" />
            <br />
            <br />
            <asp:Button ID="StorageButton" runat="server" OnClick="StorageButton_Click" Text="Склад" Width="100px" />
            <br />
            <asp:Button ID="MailButton" runat="server" OnClick="MailButton_Click" Text="Почта" Width="100px" />
            <br />
            <br />
            <asp:Button ID="AddButton" runat="server" OnClick="AddButton_Click" Text="Добавить" Width="100px" />
            <asp:Button ID="ChangeButton" runat="server" OnClick="ChangeButton_Click" Text="Изменить" Width="100px" />
            <asp:Button ID="DeleteButton" runat="server" OnClick="DeleteButton_Click" Text="Удалить" Width="100px" />
            <asp:Button ID="RefreshButton" runat="server" OnClick="RefreshButton_Click" Text="Обновить" Width="100px" />
            <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" DataSourceID="DataSource1">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="ProductId" HeaderText="Номер питания" SortExpression="ProductId">
                    <ControlStyle Width="70px" />
                    <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ProductName" HeaderText="Питание" SortExpression="ProductName">
                    <ControlStyle Width="70px" />
                    <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Count" HeaderText="Количество" SortExpression="Count">
                    <ControlStyle Width="70px" />
                    <ItemStyle Width="150px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="DataSource1" runat="server" SelectMethod="GetList" TypeName="Classes.ImplementationsBD.MainServiceBD"></asp:ObjectDataSource>
            <br />
            <br />
&nbsp;</div>
    </form>
</body>
</html>
