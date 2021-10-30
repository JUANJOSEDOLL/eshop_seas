<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchUser.aspx.cs" Inherits="EShop.Admin.SearchUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <br />
    <br />
    <h4>Buscar Clientes</h4>
     <hr />
    <br />
      <div class="form-horizontal">

   

    <div class="form-group">
            <asp:Label runat="server"  CssClass="col-md-2 control-label">Buscar por correo</asp:Label>
            <div class="col-md-5">
                <asp:DropDownList ID="DropDownList" runat="server" CssClass="form-control" AppendDataBoundItems="true"  >
                   <asp:ListItem Text="Selecione email de cliente" Value="0" />
                </asp:DropDownList>
             </div>
         <div class="col-md-5">
                <asp:Button ID="Button1" runat="server" Text="Cargar datos cliente" CssClass="form-control"  OnClick="Button1_Click"/>
             </div>

        </div>
    </div>
     <br />
    <br /> <br />
    <br /> <br />
    <br /> <br />
    <br /> <br />
    <br /> <br />
    <br /> <br />
    <br />
    <br /> <br />
    <br /> <br />
    
    <br /> <br />
    <br /> <br />
    
    <br /> <br />
    <br /> <br />
    
    </asp:Content>
