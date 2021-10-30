<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditFormProduct.aspx.cs" Inherits="EShop.Admin.EditFormProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <br />
        <br />
        <h4>Editar Producto</h4>
        <hr />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />

        <asp:HiddenField ID="txtId" runat="server" />

        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Introduzca el nombre del Producto:" CssClass="col-md-3" AssociatedControlID="txtProductName"></asp:Label>
            <div class="col-md-9">
                <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El nombre del Producto es obligatorio" ControlToValidate="txtProductName" Text="El nombre del Producto es obligatorio"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Introduzca el texto de la descripción del Producto:" CssClass="col-md-3" AssociatedControlID="txtProductDescription"></asp:Label>
            <div class="col-md-9">
                <asp:TextBox ID="txtProductDescription" runat="server"   CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="La descripción del Producto es obligatoria" ControlToValidate="txtProductDescription" Text="La descripción del Producto es obligatorio"></asp:RequiredFieldValidator>
            </div>
        </div>


        <div class="form-group">
            <asp:Label ID="Label4" runat="server" Text="Introduzca el precio Producto:" CssClass="col-md-3" AssociatedControlID="TextProductPrice"></asp:Label>
            <div class="col-md-2">
                <asp:TextBox ID="textProductPrice" runat="server" CssClass="form-control" Width="232px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El precio del Producto es obligatorio" ControlToValidate="TextProductPrice" Text="El precio del Producto es obligatorio"></asp:RequiredFieldValidator>
            </div>
       </div>



        <div class="form-group">
            <asp:Label ID="Label6" runat="server" Text="Seleccione la categoria :" CssClass="col-md-3" AssociatedControlID="dropDownListCategory"></asp:Label>
            <div class="col-md-2">
                <asp:DropDownList ID="dropDownListCategory" runat="server" CssClass="form-control" Width="232px"></asp:DropDownList>
             
                <asp:RequiredFieldValidator ID="txtIdCategoriaval" runat="server" ErrorMessage="La categoria es obligatoria" ControlToValidate="dropDownListCategory" Text="La  categoria es obligatoria"></asp:RequiredFieldValidator>
            </div>
     
               </div>



        <div class="form-group">
            <asp:Label ID="Label5" runat="server" Text="Introduzca el Stock del Producto:" CssClass="col-md-3" AssociatedControlID="textStock"></asp:Label>
            <div class="col-md-2">
                <asp:TextBox ID="textStock" runat="server" CssClass="form-control" Width="243px"></asp:TextBox>
            </div>
        </div>


         <div class="form-group">
       
           </div>
        
        <div class="form-group">
            <asp:Label ID="Label99" runat="server" Text="Imagen principal:" CssClass="col-md-3"></asp:Label>
            <div class="col-md-4">    <asp:Image ID="image1" runat="server"  class="img-responsive img-thumbnail" Height="300px" Width="300px" />
                 </div>
            <div class="col-md-5">
                <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
            </div>
        </div>
        
  

        <div class="form-group">
            <div class="col-md-1 col-md-offset-3">
                <asp:Button ID="btnSubmit" runat="server" Text="Guardar" CssClass="btn btn-default" OnClick="BtnSubmit_Click" />
            </div>
        </div>

        <hr />
    </div>
</asp:Content>
