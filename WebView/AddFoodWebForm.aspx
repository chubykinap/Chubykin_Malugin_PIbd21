<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFoodWebForm.aspx.cs" Inherits="WebView.AddFoodWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label" runat="server" Text="Название" Width="100px"></asp:Label>
            <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label0" runat="server" Text="Количество" Width="100px"></asp:Label>
            <asp:TextBox ID="NumberTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="AddButton" runat="server" OnClick="AddButton_Click" Text="Добавить" Width="100px" />
            <asp:Button ID="ChangeButton" runat="server" OnClick="ChangeButton_Click" Text="Изменить" Width="100px" />
            <asp:Button ID="DeleteButton" runat="server" OnClick="DeleteButton_Click" Text="Удалить" Width="100px" />
            <asp:Button ID="RefreshButton" runat="server" OnClick="RefreshButton_Click" Text="Обновить" Width="100px" />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="DataSource1">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                    <asp:BoundField DataField="StorageName" HeaderText="StorageName" SortExpression="StorageName" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="DataSource" runat="server" SelectMethod="GetList" TypeName="Classes.ImplementationsBD.StorageServiceBD"></asp:ObjectDataSource>
            <br />
            <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" Text="Сохранить" Width="100px" />
            <asp:Button ID="CancelButton" runat="server" OnClick="CancelButton_Click" Text="Отмена" Width="100px" />
        </div>
    </form>
</body>
</html>
