<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="EShop.Admin.CategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css" rel="stylesheet" />
     <br />
    <br />
    <br />
    <h4>Listado de categorias</h4>
    <br />
    <br />
    <br />
    <table id="Categories">
        <thead>
            <tr>
                <th>Add Image</th>
                <th>Eliminar categoria</th>
                <th>CategoryName</th>
                <th>Description</th>
                <th>Editar</th>
                <th></th>

            </tr>
        </thead>
    </table>
    <script src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#Categories").DataTable({
                'bProcessing': true,
                'bServerSide': true,
                'sAjaxSource': '/Admin/CategoryServiceList.ashx',
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.13/i18n/Spanish.json"
                },
                "columns": [
                    { "data": "Id", "Name": "Id", "autoWidth": true },
                    { "data": "Id", "Name": "Id", "autoWidth": true },
                    { "data": "CategoryName", "Name": "CategoryName", "autoWidth": true },
                    { "data": "Description", "Name": "Description", "autoWidth": true }
                   
                ],

                 "columnDefs": [
                    {
                        "render": function (data, type, row) {
                            return "<a href='/Admin/CreateFormImagesForCategory?id=" + row.Id + "' class='btn btn-pink'>" + 'Nueva imagen' + "</a>";
                        },
                        "targets": 0
                    },
                     {
                        "render": function (data, type, row) {
                            return "<a href='/Admin/DeleteRowCategory?id=" + row.Id + "' class='btn btn-pink'>" + 'Eliminar' + "</a>";
                        },
                        "targets": 1
                     },
                     {
                         "render": function (data, type, row) {
                             return "<a href='/Admin/EditFormCategory?id=" + row.Id + "' class='btn btn-pink'>" + 'Editar' + "</a>";
                         },
                         "targets": 4
                     }
                ]

            });



        });
    </script>
</asp:Content>
