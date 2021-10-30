<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CartItemList.aspx.cs" Inherits="EShop.User.CartItemList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <link href="https://cdn.datatables.net/1.11.3/css/jquery.dataTables.min.css" rel="stylesheet" />
<link href="https://cdn.datatables.net/rowreorder/1.2.8/css/rowReorder.dataTables.min.css" rel="stylesheet" />
<link href="https://cdn.datatables.net/responsive/2.2.9/css/responsive.dataTables.min.css" rel="stylesheet" />
    <br />
    <br />
    
    <br />
    <br />
    <h3>Carrito de compra</h3>
    <br />
    <br />
    <br />
    <table id="CartItems" class="dataTable  ">
        <thead>
            <tr>
                
                <th>Id</th>
                <th>Fecha</th>
                <th>Descripción</th>
                <th>Precio</th>
                <th>Cantidad</th>
                <th>SubTotal</th>
                <th>Eliminar del carrito</th>

            </tr>
        </thead>
        <tfoot>
            <tr>
                
                
                <th></th>
                <th></th>
                <th></th>
                <th></th>
                <th style="text-align: left" id="ImporteBrutoTh">Importe bruto:</th>
                <th style="text-align: right"><asp:Label ID="txtBruto"  runat="server" Text="Label"></asp:Label></th>
                <th></th>
            </tr>
            <tr>
                
                <th></th>
                <th></th>
                <th></th>
                <th></th>
                <th style="text-align: left">IVA:</th>
                <th style="text-align: right"><asp:Label ID="txtTotal"  runat="server" Text="Label"></asp:Label></th>
                <th></th>
            </tr>
             <tr>
               
                <th></th>
                <th></th>
                <th></th>
                <th></th>
                <th style="text-align: left">Total:</th>
                <th style="text-align: right"><asp:Label  ID="txtTotalAPagar" runat="server" Text="Label"></asp:Label></th>
                <th></th>
            </tr>
        </tfoot>
    </table>
   
           <script src="https://cdn.datatables.net/1.11.3/js/jquery.dataTables.min.js"></script>
           <script src="https://cdn.datatables.net/rowreorder/1.2.8/js/dataTables.rowReorder.min.js"></script>
           <script src="https://cdn.datatables.net/responsive/2.2.9/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#CartItems").DataTable({
                'bProcessing': true,
                'bServerSide': true,
               
                'sAjaxSource': '/User/CartItemServiceList.ashx',
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.13/i18n/Spanish.json"
                },
                "columns": [
                   
                    { "data": "CartId", "Name": "CartId", "autoWidth": true },
                    { "data": "DateCreated", "Name": "DateCreated", "autoWidth": true },
                    { "data": "ProductName", "Name": "ProductName", "autoWidth": true },
                    { "data": "ProductPrice", "Name": "ProductPrice", "autoWidth": true },
                    { "data": "Quantity", "Name": "Quantity", "autoWidth": true },
                    { "data": null, "Name": "SubTotal", "render": function (data, type, row) { return (data["ProductPrice"] * data["Quantity"]) }, "autoWidth": true  }

                ],

                "columnDefs": [
                    {
                        "render": function (data, type, row) {

                            var dateString = data.substr(6);
                            var currentTime = new Date(parseInt(dateString));
                            var month = currentTime.getMonth() + 1;
                            var day = currentTime.getDate();
                            var year = currentTime.getFullYear();
                            var date = day + "/" + month + "/" + year;
                            return date;
                        },
                        "targets": 1
                    },


                    {
                        "render": function (data, type, row) {
                            return "<a href='/User/DeleteRowCartItemList?id=" + row.Id + "' class='btn btn-pink'>" + 'Eliminar' + "</a>";
                        },
                        "targets":6
                    },
                    {
                        "targets": [ 0 ],
                        "visible": false,
                        "searchable": true

                    },

                    {
                        className: 'dt-right',
                        targets:5

                    }

                ],

            });
        });

    </script>
                   <asp:Button ID = "Button1" runat = "server" Text = "Finalizar compra"  OnClick = "ButtonCreateOrder_Click" />


</asp:Content>
