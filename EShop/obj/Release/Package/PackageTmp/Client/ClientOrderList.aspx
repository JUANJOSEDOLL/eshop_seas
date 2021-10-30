<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientOrderList.aspx.cs" Inherits="EShop.Client.ClientOrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <link href="https://cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css" rel="stylesheet" />
    <br />
    <br />
    <br />
    <h4>Listado de facturas</h4>
    <br />
    <br />
    <br />
    <table id="OrdersForDataTable">
        <thead>
            <tr>
                <th>Ver detalle factura</th>
                <th></th>
                <th>Invoice</th>
                <th>TotalInvoice</th>
                <th>CreatedDate</th>
                <th>Status</th>
                <th></th>
                <th></th>
            </tr>
        </thead>
    </table>
    <script src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#OrdersForDataTable").DataTable({
                'bProcessing': true,
                'bServerSide': true,
                'sAjaxSource': '/Client/ClientOrderServiceList.ashx',
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.13/i18n/Spanish.json"
                },
                "columns": [
                    { "data": "Id", "Name": "Id", "autoWidth": true },
                    { "data": "Id", "Name": "Id", "autoWidth": true },
                    { "data": "InvoiceNumber", "Name": "InvoiceNumber", "autoWidth": true },
                    { "data": "TotalInvoice", "Name": "TotalInvoice", "autoWidth": true },
                    { "data": "CreatedDate", "Name": "CreatedDate", "autoWidth": true },
                    { "data": "Status", "Name": "Status", "autoWidth": true }
                   
                ],
                "columnDefs": [
                    {
                        "render": function (data, type, row) {
                            return "<a href='/Client/Invoice?id=" + row.Id + "' class='btn btn-pink'>" + 'Ver factura' + "</a>";
                        },
                        "targets": 0
                    },
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
                        "targets": 4
                    }
                     

                ]
            });
        });
    </script>
</asp:Content>
