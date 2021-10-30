<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CartItemsList.aspx.cs" Inherits="EShop.Admin.CartItemsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="CartId" HeaderText="CartId" SortExpression="CartId" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
            <asp:BoundField DataField="ProductPrice" HeaderText="ProductPrice" SortExpression="ProductPrice" />
            <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" />
            <asp:BoundField DataField="Product_Id" HeaderText="Product_Id" SortExpression="Product_Id" />
        </Columns>
    </asp:GridView>




    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [CartItems] WHERE [Id] = @Id" InsertCommand="INSERT INTO [CartItems] ([CartId], [Quantity], [ProductName], [ProductPrice], [DateCreated], [Product_Id]) VALUES (@CartId, @Quantity, @ProductName, @ProductPrice, @DateCreated, @Product_Id)" SelectCommand="SELECT * FROM [CartItems]" UpdateCommand="UPDATE [CartItems] SET [CartId] = @CartId, [Quantity] = @Quantity, [ProductName] = @ProductName, [ProductPrice] = @ProductPrice, [DateCreated] = @DateCreated, [Product_Id] = @Product_Id WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CartId" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="ProductName" Type="String" />
            <asp:Parameter Name="ProductPrice" Type="Single" />
            <asp:Parameter Name="DateCreated" Type="DateTime" />
            <asp:Parameter Name="Product_Id" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="CartId" Type="String" />
            <asp:Parameter Name="Quantity" Type="Int32" />
            <asp:Parameter Name="ProductName" Type="String" />
            <asp:Parameter Name="ProductPrice" Type="Single" />
            <asp:Parameter Name="DateCreated" Type="DateTime" />
            <asp:Parameter Name="Product_Id" Type="Int32" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>




</asp:Content>
