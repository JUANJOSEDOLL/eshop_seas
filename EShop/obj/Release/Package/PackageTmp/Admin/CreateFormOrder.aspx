<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateFormOrder.aspx.cs" Inherits="EShop.Admin.CreateFormOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <div class="form-horizontal">
        <br />
    <br />
    <br />
    <h4>Crear órdenes</h4>
    <br />
    <br />
    <br />
        <hr />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />
        
        

        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Introduzca el estado del pedido:" CssClass="col-md-3" AssociatedControlID="txtStatus"></asp:Label>
            <div class="col-md-9">
                <asp:TextBox ID="txtStatus" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Requiere Status" ControlToValidate="txtStatus" Text="Requiere Status"></asp:RequiredFieldValidator>
            </div>
        </div>


         <div class="form-group">
            <asp:Label ID="Label4" runat="server" Text="Introduzca Id del usuario:" CssClass="col-md-3" AssociatedControlID="txtUser_Id"></asp:Label>
            <div class="col-md-9">
                <asp:TextBox ID="txtUser_Id" runat="server" CssClass="form-control"  Rows="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El usuario ID es obligatorio" ControlToValidate="txtUser_Id" Text="Requiere el Id del usuario"></asp:RequiredFieldValidator>
            </div>
        </div>

          <div class="form-group">
            <asp:Label ID="Label5" runat="server" Text="Introduzca Id del producto:" CssClass="col-md-3" AssociatedControlID="txtIdProducto"></asp:Label>
            <div class="col-md-9">
                <asp:TextBox ID="txtIdProducto" runat="server" CssClass="form-control"  Rows="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="El producto ID es obligatorio" ControlToValidate="txtIdProducto" Text="Requiere el Id de producto"></asp:RequiredFieldValidator>
            </div>
        </div>

           <div class="form-group">
            <asp:Label ID="Label6" runat="server" Text="Introduzca la cantidad de producto:" CssClass="col-md-3" AssociatedControlID="txtCantidad"></asp:Label>
            <div class="col-md-9">
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control"  Rows="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Introduzca la cantidad de producto" ControlToValidate="txtCantidad" Text="Introduzca la cantidad de producto"></asp:RequiredFieldValidator>
            </div>
        </div>

            <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Introduzca nombre:" CssClass="col-md-3" AssociatedControlID="txtName"></asp:Label>
            <div class="col-md-9">
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"  Rows="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El nombre es obligatorio" ControlToValidate="txtName" Text="Requiere el nombre del producto"></asp:RequiredFieldValidator>
            </div>
        </div>

           <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="Introduzca precio:" CssClass="col-md-3" AssociatedControlID="txtPrecio"></asp:Label>
            <div class="col-md-9">
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"  Rows="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="El precio es obligatorio" ControlToValidate="txtPrecio" Text="Requiere el precio"></asp:RequiredFieldValidator>
            </div>
        </div>


        

        <div class="form-group">
            <div class="col-md-1 col-md-offset-3">
               <asp:Button ID="btnSubmit" runat="server" Text="Crear" CssClass="btn btn-default" OnClick="BtnSubmit_Click" />
            </div>
        </div> 


    </div>

</asp:Content>
