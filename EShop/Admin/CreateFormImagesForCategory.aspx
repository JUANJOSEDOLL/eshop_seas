<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateFormImagesForCategory.aspx.cs" Inherits="EShop.Admin.CreateFormImagesForCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 


    <asp:HiddenField ID="txtId" runat="server" />
    <br />
    <br />
    <br />

    <div class="container mt-3">
        <h4>Carga imagen de categoria</h4>
        <hr />

        <div class="custom-file mb-3">

       <asp:FileUpload ID="FileUpload2" runat="server" />

        </div>
        <br />
    <br />

        <div class="mt-3">


            <asp:Button ID="Button1" runat="server" Text="Salvar imagen" OnClick="BtnSubmit_Click" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Content>
