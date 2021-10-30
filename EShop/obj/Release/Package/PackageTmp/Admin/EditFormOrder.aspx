<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditFormOrder.aspx.cs" Inherits="EShop.Admin.EditFormOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">

        <br />
        <h4>Editar</h4>
        <br />

        <hr />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />
        <asp:HiddenField ID="txtId" runat="server" />




        <asp:HiddenField ID="lblUser_Id" runat="server"/>
   

          <div class="form-group">
            <asp:Label ID="Label4" runat="server" Text="Email usuario:" CssClass="col-md-3" AssociatedControlID="txtEmailUser"></asp:Label>
            <div class="col-md-9">
                <asp:TextBox ID="txtEmailUser" runat="server" CssClass="form-control"  Rows="10"></asp:TextBox>
            </div>
        </div>

        



        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Estado de la orden:" CssClass="col-md-3" AssociatedControlID="ddlType"></asp:Label>
            <div class="col-md-3">
                <asp:Label ID="ddlTypeText" runat="server" CssClass="form-control"></asp:Label>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Cambiar estado de la orden:" CssClass="col-md-3" AssociatedControlID="ddlType"></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlType" runat="server"  CssClass="form-control"></asp:DropDownList>
            </div>
        </div>



        <div class="form-group">
            <div class="col-md-1 col-md-offset-3">
                <asp:Button ID="btnSubmit" runat="server" Text="Crear" CssClass="btn btn-default" OnClick="BtnSubmit_Click_Order" />
            </div>
        </div>


    </div>

</asp:Content>

