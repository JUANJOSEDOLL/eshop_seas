<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditFormCategory.aspx.cs" Inherits="EShop.Admin.EditFormCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-horizontal">

        <br />

        <h4>Editar Categoría</h4>
        <hr />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />

      
        <asp:HiddenField ID="txtId" runat="server" />

        <div class="form-group">
            <asp:Label ID="Label4" runat="server" Text="Introduzca la categoria:" CssClass="col-md-3" AssociatedControlID="txtEditCategoryName"></asp:Label>
            <div class="col-md-9">
                <asp:TextBox ID="txtEditCategoryName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Introduzca la categoria" ControlToValidate="txtEditCategoryName" Text="Introduzca la categoria"></asp:RequiredFieldValidator>
            </div>
        </div>



        <br />

        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Introduzca la descripción: " CssClass="col-md-3" AssociatedControlID="txtEditDescription"></asp:Label>
            <div class="col-md-9">

                <asp:TextBox ID="txtEditDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Introduzca la descripción" ControlToValidate="txtEditDescription" Text="Introduzca la descripción"></asp:RequiredFieldValidator>
            </div>
        </div>


        <br />

        <asp:Button ID="btnSubmit" runat="server" Text="Editar" CssClass="btn btn-default" OnClick="BtnSubmit_Click" />
    </div>
</asp:Content>
