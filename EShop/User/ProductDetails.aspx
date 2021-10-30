<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="EShop.User.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-horizontal">
        <br />
        <h4>Detalle de Producto</h4>
            
                <div id="myCarousel" class="carousel slide" data-ride="carousel" style="max-height:400px">
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel" data-slide-to="1"></li>
                        <li data-target="#myCarousel" data-slide-to="2"></li>
                    </ol>

                    <!-- Wrapper for slides -->
                    <div class="carousel-inner">
                        <div class="item active">
                            <asp:Image ID="txtImagePath" runat="server" class="img-responsive center-block" style="max-height:400px"/>
                            <div class="carousel-caption">
                            </div>


                        </div>
                     <asp:Repeater ID="Repeater1" runat="server">
                         <ItemTemplate>

                            <div class="item">
                                <img src="/Content/Images/<%#:Eval("ImageName")%>" class="img-responsive center-block" style="max-height:400px"/>
                                <div class="carousel-caption">
                                </div>
                            </div>

                        </ItemTemplate>
 </asp:Repeater>
                        </div>
                        <!-- Left and right controls -->
                        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                            <span class="glyphicon glyphicon-chevron-left"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="right carousel-control" href="#myCarousel" data-slide="next">
                            <span class="glyphicon glyphicon-chevron-right"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>
        <hr />
    </div>
    <div class="form" style="text-align:center">
    <div class="form-group">
        <asp:Label ID="Label5" runat="server" Text="Label">Artículo: </asp:Label>
        <asp:Label ID="txtProductName" runat="server" Text="Label" Font-Bold="true"></asp:Label>
    </div>
        <div class="form-group">
        <asp:Label ID="Label3" runat="server" Text="Label" >Precio: </asp:Label>
        <asp:Label ID="txtProductPrice" runat="server" Text="Label" Font-Bold="true" ></asp:Label>
    </div>
    <div class="form-group">
        <asp:Label ID="Label4" runat="server" Text="Label">Categoría:</asp:Label>
        <asp:Label ID="txtCategory" runat="server" Text="Label" Font-Bold="true"></asp:Label>
        
    </div>
    <div class="form-group">
        <asp:Label ID="Label2" runat="server" Text="Label">Disponemos de </asp:Label>
    
        <asp:Label ID="txtStock" runat="server" Text="Label" Font-Bold="true"></asp:Label>
        </div>
    
  </div>
    <div class="form-horizontal">
        <div class="form-group">
        <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="true">Descripción: </asp:Label>
        <asp:Label ID="txtProductDescription" runat="server" Text="Label"></asp:Label>
    </div>

    </div>

    <hr />




</asp:Content>
