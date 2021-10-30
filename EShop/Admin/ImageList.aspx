<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImageList.aspx.cs" Inherits="EShop.Admin.ImageList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css" rel="stylesheet" />
    <br />
    <br />
    <br />
    <h4>Listado de imágenes</h4>
    <br />
    <br />
    <br />

    <table id="Categories">
        <thead>
            <tr>
                <th>Eliminar imagen</th>
                <th>ImageName</th>
                <th>Product_Id</th>
                <th></th>
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
                'sAjaxSource': '/Admin/ImageServiceList.ashx',
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.13/i18n/Spanish.json"
                },
                "columns": [
                    { "data": "Id", "Name": "Id", "autoWidth": true },
                    { "data": "ImageName", "Name": "ImageName", "autoWidth": true },
                    { "data": "Product_Id", "Name": "Product_Id", "autoWidth": true }
                           ],
                "columnDefs": [
                    {
                        "render": function (data, type, row) {
                            return "<a href='/Admin/DeleteRowImage?id=" + row.Id + "' class='btn btn-pink'>"+'Eliminar imagen'+"</a>";
                        },
                        "targets": 0
                    }
                ]

            });
        });
    </script>
</asp:Content>
