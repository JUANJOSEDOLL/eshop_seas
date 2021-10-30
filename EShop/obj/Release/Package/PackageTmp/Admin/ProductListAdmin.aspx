<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductListAdmin.aspx.cs" Inherits="EShop.Admin.FormListAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css" rel="stylesheet" />
    <br />
    <br />
    <br />
    <h4>Listado de productos</h4>
    <br />
    <br />
    <br />
    <table id="Products">
        <thead>
            <tr>
                <th>Add Image</th>
                <th>Editar producto</th>
                <th>Eliminar producto</th>
                <th>ProductName</th>
                <th>Description</th>
                <th>ProductPrice</th>
                <th>Stock</th>
                <th></th>
            </tr>
        </thead>
    </table>
    <script src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#Products").DataTable({
                'bProcessing': true,
                'bServerSide': true,
                'sAjaxSource': '/Admin/ProductServiceList.ashx',
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.13/i18n/Spanish.json"
                },
                "columns": [
                    { "data": "Id", "Name": "Id", "autoWidth": true },
                    { "data": "Id", "Name": "Id", "autoWidth": true },
                    { "data": "Id", "Name": "Id", "autoWidth": true },
                    { "data": "ProductName", "Name": "ProductName", "autoWidth": true },
                    { "data": "ProductDescription", "Name": "ProductDescription", "autoWidth": true },
                    { "data": "ProductPrice", "Name": "ProductPrice", "autoWidth": true },
                    { "data": "Stock", "Name": "Stock", "autoWidth": true }

                ],
                "columnDefs": [
                    {
                        "render": function (data, type, row) {
                            return "<a href='/Admin/CreateFormImages?id=" + row.Id + "' class='btn btn-pink'>" + 'Nueva imagen' + "</a>";
                        },
                        "targets": 0
                    },
                    {
                        "render": function (data, type, row) {
                            return "<a href='/Admin/EditFormProduct?id=" + row.Id + "' class='btn btn-pink'>" + 'Editar' + "</a>";
                        },
                        "targets": 1
                    },
                    {
                        "render": function (data, type, row) {
                            return "<a href='/Admin/DeleteRowProduct?id=" + row.Id + "' class='btn btn-pink'>" + 'Eliminar' + "</a>";
                        },
                        "targets": 2
                    }

                ]
            });
        });
    </script>
</asp:Content>
