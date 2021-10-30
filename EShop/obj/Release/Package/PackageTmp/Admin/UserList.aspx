<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="EShop.Admin.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css" rel="stylesheet" />
     <br />
    <br />
    <br />
    <h4>Listado de Clientes</h4>
    <br />
    <br />
    <br />
    <table id="Clients">
        <thead>
            <tr>

                
                <th>FirstName</th>
                <th>LastName</th>
                

            </tr>
        </thead>
    </table>
    <script src="https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#Clients").DataTable({
                'bProcessing': true,
                'bServerSide': true,
                'sAjaxSource': '/Admin/UserServiceList.ashx',
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.13/i18n/Spanish.json"
                },
                "columns": [
                  
                    { "data": "FirstName", "Name": "FirstName", "autoWidth": true },
                    { "data": "LastName", "Name": "LastName", "autoWidth": true }
                   
                ],

                 "columnDefs": [
                    {
                        "render": function (data, type, row) {
                            return "<a href='/Admin/EditUserData?id=" + row.LastName + "' class='btn btn-pink'>" + 'Editar' + "</a>";
                        },
                        "targets": 0
                    }
                ]

            });



        });
    </script>



     <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>

    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="">LinkButton</asp:LinkButton>

    <select id="Select1"
              multiple="true" 
              runat="server"/>


    <br />

    
    </asp:Content>
