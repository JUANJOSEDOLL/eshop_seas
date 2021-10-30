<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateFormCategory.aspx.cs" Inherits="EShop.Admin.CreateFormCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-horizontal">

        <br />

        <h4>Crear Categoría</h4>
        <hr />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />

      


        <div class="form-group">
            <asp:Label ID="Label4" runat="server" Text="Introduzca la categoria:" CssClass="col-md-3" AssociatedControlID="txtCategoryName"></asp:Label>
            <div class="col-md-9">
                <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Introduzca la categoria" ControlToValidate="txtCategoryName" Text="Introduzca la categoria"></asp:RequiredFieldValidator>
            </div>
        </div>



        <br />

        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Introduzca la descripción: " CssClass="col-md-3" AssociatedControlID="txtDescription"></asp:Label>
            <div class="col-md-9">

                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Introduzca la descripción" ControlToValidate="txtDescription" Text="Introduzca la descripción"></asp:RequiredFieldValidator>
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
