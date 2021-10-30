<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="EShop.Client.Invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  

    <div id="imp1">

<h1>FACTURA</h1>
       
      
         <hr style="width:190mm;text-align:left;margin-left:0">
        <h5>DATOS CLIENTE</h5>
        
  
        <asp:Table ID="Table1" runat="server" Width="190mm">
       <asp:TableRow runat="server">
            <asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="40mm" ColumnSpan="2"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell></asp:TableRow><asp:TableRow runat="server">
            <asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="40mm">Nombre:</asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"><asp:Label ID="txtFirstNameLabel" runat="server"/></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell></asp:TableRow><asp:TableRow runat="server">
            <asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="40mm">Apellidos:</asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"><asp:Label ID="txtLastNameLabel" runat="server"/></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell></asp:TableRow><asp:TableRow runat="server">
            <asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="40mm">Dirección: </asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"><asp:Label ID="txtOneLineAddress" runat="server"/></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell></asp:TableRow><asp:TableRow runat="server">
            <asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="40mm">CIF/NIF Cliente:</asp:TableCell><asp:TableCell  ID="txtCif_NifLabel" runat="server" BorderStyle="None" Height="5mm" ColumnSpan="3"></asp:TableCell></asp:TableRow><asp:TableRow runat="server" Width="190mm">
            <asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="40mm">Email Cliente</asp:TableCell><asp:TableCell  ID="txtEmailLabel" runat="server" BorderStyle="None" Height="5mm" ColumnSpan="3"></asp:TableCell></asp:TableRow><asp:TableRow runat="server" Width="190mm">
            <asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="40mm">Teléfono: </asp:TableCell><asp:TableCell ID="txtPhoneLabel"  runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell></asp:TableRow><asp:TableRow runat="server">
            
        </asp:TableRow>
    </asp:Table>
        <hr style="width:190mm;text-align:left;margin-left:0">


       <h5>DATOS FACTURA</h5>
        
        

    <asp:Table ID="TableClient" runat="server" Width="190mm">
       <asp:TableRow runat="server">
            <asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="30mm" ColumnSpan="2"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell></asp:TableRow><asp:TableRow runat="server">
            <asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="30mm">Número factura:</asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"><asp:Label ID="txtFRA" runat="server"/></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell></asp:TableRow><asp:TableRow runat="server">

            <asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="30mm">Número pedido:</asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"><asp:Label ID="txtOrder" runat="server"/></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell></asp:TableRow><asp:TableRow runat="server">

            <asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="30mm">Fecha emisión: </asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"><asp:Label ID="txtDate" runat="server"/></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell></asp:TableRow><asp:TableRow runat="server">
            <asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="30mm">Emisor factura: </asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm">EShop J.J.Doll</asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell></asp:TableRow><asp:TableRow runat="server">
            <asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="30mm">CIF/NIF: </asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm">123456789X</asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell></asp:TableRow><asp:TableRow runat="server">
            <asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="30mm">Dirección: </asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm">c/ Programador, 15 - 08001 Barcelona </asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell></asp:TableRow><asp:TableRow runat="server">
            <asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="40mm">R.M. de Barcelona</asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm" ColumnSpan="3">Tomo 4 - Folio V - Libro XXIV - Hoja 72</asp:TableCell></asp:TableRow><asp:TableRow runat="server" Width="190mm">


            <asp:TableCell runat="server" BorderStyle="None" Height="5mm" HorizontalAlign="Center" ColumnSpan="4"></asp:TableCell></asp:TableRow><asp:TableRow runat="server" Width="190mm">


            <asp:TableCell runat="server" BorderStyle="None" Height="5mm" HorizontalAlign="Center" ColumnSpan="4"></asp:TableCell></asp:TableRow><asp:TableRow runat="server" Width="190mm">
             
                
                
                <asp:TableCell runat="server" BorderStyle="None"  Height="5mm" HorizontalAlign="Left" ColumnSpan="4">DETALLE DE PEDIDO</asp:TableCell></asp:TableRow></asp:Table><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="190mm">
             <Columns>
                <asp:BoundField DataField="Name" HeaderText="Descripción" SortExpression="Name"/>

                <asp:BoundField DataField="Quantity" HeaderText="Cantidad" SortExpression="Quantity" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"   HeaderStyle-HorizontalAlign="Right">
                    <HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>


                <asp:BoundField DataField="Price" HeaderText="Precio" SortExpression="Price" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center" Font-Bold="True"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                 <asp:TemplateField HeaderText="Importe" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"   HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="30mm">
                    <ItemTemplate>
                       <%#: String.Format("{0:c}", ((Convert.ToDouble(Eval("Quantity")) *  Convert.ToDouble(Eval("Price")))))%>
                    </ItemTemplate>
                </asp:TemplateField>

              
            </Columns>
        </asp:GridView>
        
        
        
     
        
     
        
        

    <asp:Table ID="Table2" runat="server" Width="190mm">

       
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm" HorizontalAlign="Right">Total Base Imponible: </asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="30mm" HorizontalAlign="Center"><asp:Label ID="txtBruto" runat="server"/></asp:TableCell></asp:TableRow><asp:TableRow runat="server">
            <asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm" HorizontalAlign="Right">Importe IVA (21%): </asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="30mm" HorizontalAlign="Center"><asp:Label ID="txtTotal" runat="server" /></asp:TableCell></asp:TableRow><asp:TableRow runat="server">
            <asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm" HorizontalAlign="Right">Total factura: </asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="30mm" HorizontalAlign="Center"><asp:Label ID="txtTotalAPagar" runat="server" /></asp:TableCell></asp:TableRow><asp:TableRow runat="server">
            <asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="30mm"></asp:TableCell></asp:TableRow><asp:TableRow runat="server">
            <asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm"></asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm" HorizontalAlign="Right">Forma de pago: </asp:TableCell><asp:TableCell runat="server" BorderStyle="None" Height="5mm" Width="30mm" HorizontalAlign="Center">Contado</asp:TableCell></asp:TableRow></asp:Table></div><br />
    <br />
    <input id="btnPrint" type="button" value="Imprimir factura" class="PrintButton" onclick="javascript:imprim1(imp1);" /> <script>onclick="javascript:imprim1(imp1);"
        function imprim1(imp1) {
            var printContents = document.getElementById('imp1').innerHTML;
            w = window.open();
            w.document.write(printContents);
            w.print();
            w.close();
            return true;
        }
    </script></asp:Content>