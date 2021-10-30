<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImageListView.aspx.cs" Inherits="EShop.Admin.ImageListView" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    
    <h4>Images</h4>

 

    <asp:ListView runat="server" ID="lvImages"
        ItemType="EShop.CORE.Image" SelectMethod="lvImages_GetData"
        OnItemCommand="lvImages_ItemCommand">
        


        <LayoutTemplate>
         
            <div class="row">
                <div runat="server" id="itemPlaceHolder" />
            </div>

        </LayoutTemplate>

        <ItemTemplate>

            <div runat="server" class="Image-container">
                <div class="media">
                    <img src="/Content/Images/<%#Item.ImageName%>" alt="Foto" width="80" height="80" class="pull-left media-object" />
                    <div class="media-body">
                        <h2 class="media-heading"><%#Item.ImageName%></h2>
                       
                        <asp:LinkButton runat="server" ID="btnEliminar" Text="Eliminar" CssClass="pull-right" CommandName="Eliminar" CommandArgument="<%# Item.Id %>" />
                    </div>
                </div>
            </div>

        </ItemTemplate>


        <EmptyDataTemplate>
            No hay imagenes para mostrar.
        </EmptyDataTemplate>


    </asp:ListView>
 
</asp:Content>
