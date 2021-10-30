<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="EShop.User.ProductList" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <style>
body {
  font-family: "Lato", sans-serif;
}

.sidenav {
  width: 160px;
  position: fixed;
  z-index: 1;
  top: 20px;
  left: 10px;
  background: #fff;
  overflow-x: hidden;
  padding: 8px 8px;
}

.sidenav a {
  padding: 20px 8px 6px 16px;
  text-decoration: none;
  font-size: 15px;
  color: #2196F3;
  display: block;
}

.sidenav a:hover {
  color: #064579;
}

.main .card-body:hover {
  color: #064579;
}

.main {
  margin-left: 140px; 
 margin-top:25px;
}

@media screen and (max-height: 1200px) {
  
  .sidenav {padding-top: 25px;}
  .sidenav a {font-size: 15px;}
}
</style>



    <div class="container" style="margin-top:auto">

       <div class="sidenav" style="margin-top:auto">
           
           <br />
            <br />
                <p>
                    <a href="/User/CartItemList" class="btn btn-default btn-lg">
                        <span class="glyphicon glyphicon-shopping-cart"></span>
                        <br>
                        <span class="badge"><asp:Label ID="txtLabel" runat="server"></asp:Label></span>
                    </a>
                </p>

         <div class="list-group">

             <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>

                
                   <a href="ProductList.aspx?Id=<%#:Eval("Id")%>" class="list-group-item">
                    <%#Eval("CategoryName") %>
                    </a>

                      </ItemTemplate>
            </asp:Repeater>

             </div>
        
         </div>
       

    <div class="main">

          	
        <div class="row">


            <asp:Repeater ID="Repeater1"  OnItemDataBound="R1_ItemDataBound" runat="server">
                <ItemTemplate>

                    	
                    <div class="col-lg-3 col-md-3 col-sm-4">


                        <div class="card  border-info" style="margin: 4px; padding: 4px; border: 1px solid grey;">
                            <div class="card-header">
                                <a href="ProductDetails.aspx?Id=<%#:Eval("Id")%>">
                                  <img  src="/Content/Images/<%#:Eval("ImagePath")%>" class="img-responsive">
                                  </a>

                            </div>
                            <div class="card-body" style="margin: 6px; padding: 6px; text-align: center;">

                                <a href="ProductDetails.aspx?Id=<%#:Eval("Id")%>" >
                                    <h5><%#:Eval("ProductName")%> 
                                    </h5>
                                </a>
                                <div runat="server" visible='<%#Eval("Stock").ToString()=="0" ? true:false %>'>
                                    <b>Sin stock disponible!</b>
                                </div>
                                <div runat="server" visible='<%#Eval("Stock").ToString()!="0" ? true:false %>'>
                                    <p style="color:white">.</p>
                                </div>
                                
                            </div>
                            <div class="footer">

                                <span>
                                    <b>Precio: </b><%#:String.Format("{0:c}", Eval("ProductPrice"))%> 
                                </span>

                                <asp:Label ID="Label1" runat="server" Text='<%#:Eval("Stock")%>' Visible="false"/>

                              <asp:Label ID="Label2" runat="server" Text='<%#: Eval("Id")  %>' Visible="false"/>

                                <asp:LinkButton ID="LinkButton1" CausesValidation="False" CommandName="ParameterToSend" OnClick = "Lbt_Click" CommandArgument = '<% # Eval ("Id")%>' class="btn btn-primary" runat="server" Text="Al carrito"  >
                                   
                                 
                                </asp:LinkButton>

                                

                            </div>
                        </div>



                    </div>


                </ItemTemplate>
            </asp:Repeater>

        </div>
                                               
    </div>

</div>
    
</asp:Content>
