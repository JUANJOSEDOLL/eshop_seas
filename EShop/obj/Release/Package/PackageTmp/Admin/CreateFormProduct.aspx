<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateFormProduct.aspx.cs" Inherits="EShop.Admin.CreateFormProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <br />
        <br />
        <h4>Crear Producto</h4>
        <hr />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />



        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Introduzca el nombre del Producto:" CssClass="col-md-3" AssociatedControlID="txtProductName"></asp:Label>
            <div class="col-md-9">
                <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtProductName" ID="RegularExpressionValidator3" ValidationExpression = "^[\s\S]{15,20}$" runat="server" ErrorMessage="Minimum 15 and Maximum 20 characters required."></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="El nombre del Producto es obligatorio" ControlToValidate="txtProductName" Text="El nombre del Producto es obligatorio"></asp:RequiredFieldValidator>
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
            <asp:Label ID="Label6" runat="server" Text="Seleccione la categoria :" CssClass="col-md-3" AssociatedControlID="DropDownList1"></asp:Label>
            <div class="col-md-2">
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Width="232px"></asp:DropDownList>
              
                <asp:RequiredFieldValidator ID="txtIdCategoriaval" runat="server" ErrorMessage="La categoria es obligatoria" ControlToValidate="DropDownList1" Text="La  categoria es obligatoria"></asp:RequiredFieldValidator>
            </div>
     
          </div>



        <div class="form-group">
            <asp:Label ID="Label5" runat="server" Text="Introduzca el Stock del Producto:" CssClass="col-md-3" AssociatedControlID="textStock"></asp:Label>
            <div class="col-md-2">
                <asp:TextBox ID="textStock" runat="server" CssClass="form-control" Width="243px"></asp:TextBox>
            </div>
        </div>
      
        
         <script type="text/javascript">

        function showimagepreview(input) {

            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {

                    document.getElementsByTagName("img")[0].setAttribute("src", e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }

         </script>
 


    <asp:HiddenField ID="txtId" runat="server" />
    

    <div class="container mt-3">
        <h4>Carga imagen principal</h4>
        <hr />

        <div class="custom-file mb-3">

            <asp:FileUpload ID="FileUpload1" runat="server" onchange="showimagepreview(this)"/>

        </div>

        <div class="custom-file mb-3">
            <br />
            <asp:Image ID="image" runat="server" Height="300px" Width="300px"  BackColor="#ff99ff"/>

        </div>


        <div class="mt-3">

            <br />
            <asp:Button ID="Button1" runat="server" Text="Salvar imagen" OnClick="BtnSubmitImagen_Click" />
            <asp:Label ID="txtLabel" runat="server"></asp:Label>
            <asp:Label ID="txtLabelImageName" runat="server" Visible="false"></asp:Label>
        </div>
    </div>
  
        <br />
         <hr />
        <div class="form-group">
            <div class="col-md-1 col-md-offset-3">
                <asp:Button ID="btnSubmit" runat="server" Text="Crear" CssClass="btn btn-success" Width="200px" OnClick="BtnSubmit_Click" />
            </div>
        </div>

       
    </div>
</asp:Content>
