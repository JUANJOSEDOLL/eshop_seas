<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateFormImages.aspx.cs" Inherits="EShop.Admin.CreateFormImages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

        function showimagepreview(input) {

            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {

                    document.getElementsByTagName("img")[0].setAttribute("src", e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }

    </script>
 

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <asp:HiddenField ID="txtId" runat="server" />
    <br />
    <br />
    <br />

    <div class="container mt-3">
        <h4>Carga imagen de producto</h4>
        <hr />

        <div class="custom-file mb-3">

            <asp:FileUpload ID="FileUpload1" runat="server" onchange="showimagepreview(this)" />

        </div>

        <div class="custom-file mb-3">
            <br />
            <asp:Image ID="image" runat="server" Height="300px" Width="300px"  BackColor="#ff99ff"/>

        </div>




        <br />
    <br />

        <div class="mt-3">


            <asp:Button ID="Button1" runat="server" Text="Salvar imagen" OnClick="BtnSubmit_Click" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
