<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUserData.aspx.cs" Inherits="EShop.Client.EditUserData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

     <asp:HiddenField ID="HiddenField1" runat="server" />

    <div class="form-horizontal">
        <h4>Editar una cuenta</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Correo electrónico</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email"  ReadOnly="true"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="El campo de correo electrónico es obligatorio." />
            </div>
        </div>

    

        <hr />


      

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtFirstName" CssClass="col-md-2 control-label">Nombre</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstName"
                        CssClass="text-danger" ErrorMessage="El campo de nombre es obligatorio." />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtLastName" CssClass="col-md-2 control-label">Apellidos</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLastName"
                        CssClass="text-danger" ErrorMessage="El campo del apellido/s es obligatorio." />
                </div>
            </div>

       


            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtAddress" CssClass="col-md-2 control-label">Dirección</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAddress"
                        CssClass="text-danger" ErrorMessage="El campo dirección es obligatorio." />
                </div>
            </div>


            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtPostalCode" CssClass="col-md-2 control-label">Código Postal</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtPostalCode" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPostalCode"
                        CssClass="text-danger" ErrorMessage="El campo del código postal es obligatorio." />
                </div>
            </div>


       

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtCity" CssClass="col-md-2 control-label">Ciudad</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtCity" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCity"
                        CssClass="text-danger" ErrorMessage="El campo de la ciudad es obligatorio." />
                </div>
            </div>


            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtProvince" CssClass="col-md-2 control-label">Provincia</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtProvince" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtProvince"
                        CssClass="text-danger" ErrorMessage="El campo de la provincia es obligatorio." />
                </div>
            </div>
       


            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtCountry" CssClass="col-md-2 control-label">País</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtCountry" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCountry"
                        CssClass="text-danger" ErrorMessage="El campo del país es obligatorio." />
                </div>
            </div>


            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtPhone" CssClass="col-md-2 control-label">Teléfono</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPhone"
                        CssClass="text-danger" ErrorMessage="El campo del teléfono es obligatorio." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtCif_Nif" CssClass="col-md-2 control-label">Cif_Nif</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txtCif_Nif" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCif_Nif"
                        CssClass="text-danger" ErrorMessage="El campo del txtCif_Nif es obligatorio." />
                </div>
            </div>





        </div>
            
     
        <hr />
      
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="UpdateUser_Click" Text=" Editar registro" CssClass="btn btn-default" />
            </div>
        </div>

    <hr />

    <br />
    
</asp:Content>

