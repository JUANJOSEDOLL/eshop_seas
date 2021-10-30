<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FullManagement.aspx.cs" Inherits="EShop.Admin.FullManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="form-horizontal">
        <br />
        <br />
        <h2>Cuadro de visualización de Datos integrado</h2>
        <hr />
           <br />
         <h4>Eliminación de lineas de carrito obsoletas</h4>
              <br />
          <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id" DataSourceID="SqlDataSource1">
              <AlternatingItemTemplate>
                  <tr style="">
                      <td>
                          <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Eliminar" />
                      </td>
                      <td>
                          <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                      </td>
                      <td>
                          <asp:Label ID="CartIdLabel" runat="server" Text='<%# Eval("CartId") %>' />
                      </td>
                      <td>
                          <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' />
                      </td>
                      <td>
                          <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' />
                      </td>
                      <td>
                          <asp:Label ID="ProductPriceLabel" runat="server" Text='<%# Eval("ProductPrice") %>' />
                      </td>
                      <td>
                          <asp:Label ID="DateCreatedLabel" runat="server" Text='<%# Eval("DateCreated") %>' />
                      </td>
                      <td>
                          <asp:Label ID="Product_IdLabel" runat="server" Text='<%# Eval("Product_Id") %>' />
                      </td>
                  </tr>
              </AlternatingItemTemplate>
              <EditItemTemplate>
                  <tr style="">
                      <td>
                          <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                          <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                      </td>
                      <td>
                          <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
                      </td>
                      <td>
                          <asp:TextBox ID="CartIdTextBox" runat="server" Text='<%# Bind("CartId") %>' />
                      </td>
                      <td>
                          <asp:TextBox ID="QuantityTextBox" runat="server" Text='<%# Bind("Quantity") %>' />
                      </td>
                      <td>
                          <asp:TextBox ID="ProductNameTextBox" runat="server" Text='<%# Bind("ProductName") %>' />
                      </td>
                      <td>
                          <asp:TextBox ID="ProductPriceTextBox" runat="server" Text='<%# Bind("ProductPrice") %>' />
                      </td>
                      <td>
                          <asp:TextBox ID="DateCreatedTextBox" runat="server" Text='<%# Bind("DateCreated") %>' />
                      </td>
                      <td>
                          <asp:TextBox ID="Product_IdTextBox" runat="server" Text='<%# Bind("Product_Id") %>' />
                      </td>
                  </tr>
              </EditItemTemplate>
              <EmptyDataTemplate>
                  <table runat="server" style="">
                      <tr>
                          <td>No se han devuelto datos.</td>
                      </tr>
                  </table>
              </EmptyDataTemplate>
              <InsertItemTemplate>
                  <tr style="">
                      <td>
                          <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                          <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                      </td>
                      <td>&nbsp;</td>
                      <td>
                          <asp:TextBox ID="CartIdTextBox" runat="server" Text='<%# Bind("CartId") %>' />
                      </td>
                      <td>
                          <asp:TextBox ID="QuantityTextBox" runat="server" Text='<%# Bind("Quantity") %>' />
                      </td>
                      <td>
                          <asp:TextBox ID="ProductNameTextBox" runat="server" Text='<%# Bind("ProductName") %>' />
                      </td>
                      <td>
                          <asp:TextBox ID="ProductPriceTextBox" runat="server" Text='<%# Bind("ProductPrice") %>' />
                      </td>
                      <td>
                          <asp:TextBox ID="DateCreatedTextBox" runat="server" Text='<%# Bind("DateCreated") %>' />
                      </td>
                      <td>
                          <asp:TextBox ID="Product_IdTextBox" runat="server" Text='<%# Bind("Product_Id") %>' />
                      </td>
                  </tr>
              </InsertItemTemplate>
              <ItemTemplate>
                  <tr style="">
                      <td>
                          <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Eliminar" />
                      </td>
                      <td>
                          <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                      </td>
                      <td>
                          <asp:Label ID="CartIdLabel" runat="server" Text='<%# Eval("CartId") %>' />
                      </td>
                      <td>
                          <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' />
                      </td>
                      <td>
                          <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' />
                      </td>
                      <td>
                          <asp:Label ID="ProductPriceLabel" runat="server" Text='<%# Eval("ProductPrice") %>' />
                      </td>
                      <td>
                          <asp:Label ID="DateCreatedLabel" runat="server" Text='<%# Eval("DateCreated") %>' />
                      </td>
                      <td>
                          <asp:Label ID="Product_IdLabel" runat="server" Text='<%# Eval("Product_Id") %>' />
                      </td>
                  </tr>
              </ItemTemplate>
              <LayoutTemplate>
                  <table runat="server">
                      <tr runat="server">
                          <td runat="server">
                              <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                  <tr runat="server" style="">
                                      <th runat="server"></th>
                                      <th runat="server">Id</th>
                                      <th runat="server">CartId</th>
                                      <th runat="server">Quantity</th>
                                      <th runat="server">ProductName</th>
                                      <th runat="server">ProductPrice</th>
                                      <th runat="server">DateCreated</th>
                                      <th runat="server">Product_Id</th>
                                  </tr>
                                  <tr id="itemPlaceholder" runat="server">
                                  </tr>
                              </table>
                          </td>
                      </tr>
                      <tr runat="server">
                          <td runat="server" style="">
                              <asp:DataPager ID="DataPager1" runat="server">
                                  <Fields>
                                      <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                  </Fields>
                              </asp:DataPager>
                          </td>
                      </tr>
                  </table>
              </LayoutTemplate>
              <SelectedItemTemplate>
                  <tr style="">
                      <td>
                          <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Eliminar" />
                      </td>
                      <td>
                          <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                      </td>
                      <td>
                          <asp:Label ID="CartIdLabel" runat="server" Text='<%# Eval("CartId") %>' />
                      </td>
                      <td>
                          <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' />
                      </td>
                      <td>
                          <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' />
                      </td>
                      <td>
                          <asp:Label ID="ProductPriceLabel" runat="server" Text='<%# Eval("ProductPrice") %>' />
                      </td>
                      <td>
                          <asp:Label ID="DateCreatedLabel" runat="server" Text='<%# Eval("DateCreated") %>' />
                      </td>
                      <td>
                          <asp:Label ID="Product_IdLabel" runat="server" Text='<%# Eval("Product_Id") %>' />
                      </td>
                  </tr>
              </SelectedItemTemplate>
         </asp:ListView>
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
          <br />
       <hr />
           <br />
         <h4>Edición de lineas de Cliente</h4>
              <br />
         
         <asp:ListView ID="ListView2" runat="server" DataKeyNames="Id" DataSourceID="SqlDataSource2" InsertItemPosition="LastItem" style="margin-right: 0px">
             <AlternatingItemTemplate>
                 <tr style="">
                     <td>
                         <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Eliminar" />
                         <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Editar" />
                     </td>
                     <td>
                         <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                     </td>
                     <td>
                         <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                     </td>
                     <td>
                         <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                     </td>
                     <td>
                         <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' />
                     </td>
                     <td>
                         <asp:Label ID="PostalCodeLabel" runat="server" Text='<%# Eval("PostalCode") %>' />
                     </td>
                     <td>
                         <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />
                     </td>
                     <td>
                         <asp:Label ID="ProvinceLabel" runat="server" Text='<%# Eval("Province") %>' />
                     </td>
                     <td>
                         <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                     </td>
                     <td>
                         <asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Phone") %>' />
                     </td>
                     <td>
                         <asp:Label ID="Cif_NifLabel" runat="server" Text='<%# Eval("Cif_Nif") %>' />
                     </td>
                 </tr>
             </AlternatingItemTemplate>
             <EditItemTemplate>
                 <tr style="">
                     <td>
                         <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                         <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                     </td>
                     <td>
                         <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
                     </td>
                     <td>
                         <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
                     </td>
                     <td>
                         <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                     </td>
                     <td>
                         <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' />
                     </td>
                     <td>
                         <asp:TextBox ID="PostalCodeTextBox" runat="server" Text='<%# Bind("PostalCode") %>' />
                     </td>
                     <td>
                         <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' />
                     </td>
                     <td>
                         <asp:TextBox ID="ProvinceTextBox" runat="server" Text='<%# Bind("Province") %>' />
                     </td>
                     <td>
                         <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
                     </td>
                     <td>
                         <asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' />
                     </td>
                     <td>
                         <asp:TextBox ID="Cif_NifTextBox" runat="server" Text='<%# Bind("Cif_Nif") %>' />
                     </td>
                 </tr>
             </EditItemTemplate>
             <EmptyDataTemplate>
                 <table runat="server" style="">
                     <tr>
                         <td>No se han devuelto datos.</td>
                     </tr>
                 </table>
             </EmptyDataTemplate>
             <InsertItemTemplate>
                 <tr style="">
                     <td>
                         <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                         <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                     </td>
                     <td>
                         <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                     </td>
                     <td>
                         <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
                     </td>
                     <td>
                         <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                     </td>
                     <td>
                         <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' />
                     </td>
                     <td>
                         <asp:TextBox ID="PostalCodeTextBox" runat="server" Text='<%# Bind("PostalCode") %>' />
                     </td>
                     <td>
                         <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' />
                     </td>
                     <td>
                         <asp:TextBox ID="ProvinceTextBox" runat="server" Text='<%# Bind("Province") %>' />
                     </td>
                     <td>
                         <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
                     </td>
                     <td>
                         <asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' />
                     </td>
                     <td>
                         <asp:TextBox ID="Cif_NifTextBox" runat="server" Text='<%# Bind("Cif_Nif") %>' />
                     </td>
                 </tr>
             </InsertItemTemplate>
             <ItemTemplate>
                 <tr style="">
                     <td>
                         <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Eliminar" />
                         <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Editar" />
                     </td>
                     <td>
                         <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                     </td>
                     <td>
                         <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                     </td>
                     <td>
                         <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                     </td>
                     <td>
                         <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' />
                     </td>
                     <td>
                         <asp:Label ID="PostalCodeLabel" runat="server" Text='<%# Eval("PostalCode") %>' />
                     </td>
                     <td>
                         <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />
                     </td>
                     <td>
                         <asp:Label ID="ProvinceLabel" runat="server" Text='<%# Eval("Province") %>' />
                     </td>
                     <td>
                         <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                     </td>
                     <td>
                         <asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Phone") %>' />
                     </td>
                     <td>
                         <asp:Label ID="Cif_NifLabel" runat="server" Text='<%# Eval("Cif_Nif") %>' />
                     </td>
                 </tr>
             </ItemTemplate>
             <LayoutTemplate>
                 <table runat="server">
                     <tr runat="server">
                         <td runat="server">
                             <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                 <tr runat="server" style="">
                                     <th runat="server"></th>
                                     <th runat="server">Id</th>
                                     <th runat="server">FirstName</th>
                                     <th runat="server">LastName</th>
                                     <th runat="server">Address</th>
                                     <th runat="server">PostalCode</th>
                                     <th runat="server">City</th>
                                     <th runat="server">Province</th>
                                     <th runat="server">Country</th>
                                     <th runat="server">Phone</th>
                                     <th runat="server">Cif_Nif</th>
                                 </tr>
                                 <tr id="itemPlaceholder" runat="server">
                                 </tr>
                             </table>
                         </td>
                     </tr>
                     <tr runat="server">
                         <td runat="server" style="">
                             <asp:DataPager ID="DataPager1" runat="server">
                                 <Fields>
                                     <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                 </Fields>
                             </asp:DataPager>
                         </td>
                     </tr>
                 </table>
             </LayoutTemplate>
             <SelectedItemTemplate>
                 <tr style="">
                     <td>
                         <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Eliminar" />
                         <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Editar" />
                     </td>
                     <td>
                         <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                     </td>
                     <td>
                         <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                     </td>
                     <td>
                         <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                     </td>
                     <td>
                         <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' />
                     </td>
                     <td>
                         <asp:Label ID="PostalCodeLabel" runat="server" Text='<%# Eval("PostalCode") %>' />
                     </td>
                     <td>
                         <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />
                     </td>
                     <td>
                         <asp:Label ID="ProvinceLabel" runat="server" Text='<%# Eval("Province") %>' />
                     </td>
                     <td>
                         <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                     </td>
                     <td>
                         <asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Phone") %>' />
                     </td>
                     <td>
                         <asp:Label ID="Cif_NifLabel" runat="server" Text='<%# Eval("Cif_Nif") %>' />
                     </td>
                 </tr>
             </SelectedItemTemplate>
         </asp:ListView>



         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [AspNetUsers] WHERE [Id] = @Id" InsertCommand="INSERT INTO [AspNetUsers] ([Id], [FirstName], [LastName], [Address], [PostalCode], [City], [Province], [Country], [Phone], [Cif_Nif]) VALUES (@Id, @FirstName, @LastName, @Address, @PostalCode, @City, @Province, @Country, @Phone, @Cif_Nif)" SelectCommand="SELECT [Id], [FirstName], [LastName], [Address], [PostalCode], [City], [Province], [Country], [Phone], [Cif_Nif] FROM [AspNetUsers]" UpdateCommand="UPDATE [AspNetUsers] SET [FirstName] = @FirstName, [LastName] = @LastName, [Address] = @Address, [PostalCode] = @PostalCode, [City] = @City, [Province] = @Province, [Country] = @Country, [Phone] = @Phone, [Cif_Nif] = @Cif_Nif WHERE [Id] = @Id">
             <DeleteParameters>
                 <asp:Parameter Name="Id" Type="String" />
             </DeleteParameters>
             <InsertParameters>
                 <asp:Parameter Name="Id" Type="String" />
                 <asp:Parameter Name="FirstName" Type="String" />
                 <asp:Parameter Name="LastName" Type="String" />
                 <asp:Parameter Name="Address" Type="String" />
                 <asp:Parameter Name="PostalCode" Type="String" />
                 <asp:Parameter Name="City" Type="String" />
                 <asp:Parameter Name="Province" Type="String" />
                 <asp:Parameter Name="Country" Type="String" />
                 <asp:Parameter Name="Phone" Type="String" />
                 <asp:Parameter Name="Cif_Nif" Type="String" />
             </InsertParameters>
             <UpdateParameters>
                 <asp:Parameter Name="FirstName" Type="String" />
                 <asp:Parameter Name="LastName" Type="String" />
                 <asp:Parameter Name="Address" Type="String" />
                 <asp:Parameter Name="PostalCode" Type="String" />
                 <asp:Parameter Name="City" Type="String" />
                 <asp:Parameter Name="Province" Type="String" />
                 <asp:Parameter Name="Country" Type="String" />
                 <asp:Parameter Name="Phone" Type="String" />
                 <asp:Parameter Name="Cif_Nif" Type="String" />
                 <asp:Parameter Name="Id" Type="String" />
             </UpdateParameters>
         </asp:SqlDataSource>




</asp:Content>
