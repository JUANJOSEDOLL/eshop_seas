<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreditCardInfo.aspx.cs" Inherits="EShop.Client.Informar_tarjeta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <br />
    <hr />

    <h3>Pasarela de pago</h3>
    
    Su factura número:
    <asp:Label ID="lblInvoice" runat="server" Text="Label" Font-Bold="true"></asp:Label>
    <br />
    Total a pagar:
    <asp:Label ID="lblIdentificacionTotalToPay" runat="server" Text="Label" Font-Bold="true"></asp:Label>
    <br />
    Su e-mail:
    <asp:Label ID="txtUser" runat="server" Text="Label" Font-Bold="true"></asp:Label>
    <hr />


    
    <link href="../Content/StyleSheet.css" rel="stylesheet" />


    <div class="padding">
        <div class="row">
            <div class="col-sm-6">
                <div class="card">
                    <div class="card-header">
                        <div class="row">
                             <div class="col-sm-4 text-center">
                                  <i class="fa fa-cc-visa fa-2x" aria-hidden="true"></i>
                                 </div>
                             <div class="col-sm-4 text-center">
                            
                                <i class="fa fa-credit-card fa-2x" aria-hidden="true"></i>
                              
                            </div>
                             <div class="col-sm-4 text-center">
                                  <i class="fa fa-cc-mastercard fa-2x" aria-hidden="true"></i>
                            </div>

                        </div>
                    </div>
                

                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="form-group">
                                <label for="txtName">Titular</label>
                                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" placeholder="Nombre del titular" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName" Display="Dynamic"
                                    CssClass="text-danger" ErrorMessage="El campo del Nombre del titular es obligatorio." />


                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="form-group">
                                <label for="txtCreditCardNumber">Número de su tarjeta de crédito</label>

                                <asp:TextBox runat="server" ID="txtCreditCardNumber" CssClass="form-control" placeholder="0000 0000 0000 0000" />

                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCreditCardNumber" Display="Dynamic"
                                    CssClass="text-danger" ErrorMessage="El campo del número de tarjeta es obligatorio." />

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCreditCardNumber" Display="Dynamic"
                                    CssClass="text-danger" ErrorMessage="Número de tarjeta erróneo" ValidationExpression="^(?:4\d([\- ])?\d{6}\1\d{5}|(?:4\d{3}|5[1-5]\d{2}|6011)([\- ])?\d{4}\2\d{4}\2\d{4})$" />

                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group col-sm-4">
                            <label for="ccmonth">Mes</label>

                            <asp:TextBox runat="server" ID="txtCreditCardExpirationDateMonth" CssClass="form-control" TextMode="SingleLine" MaxLength="2" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCreditCardExpirationDateMonth" Display="Dynamic"
                                CssClass="text-danger" ErrorMessage="El campo del mes de expiración de la tarjeta es obligatorio." />

                            <asp:RangeValidator ID="txtCreditCardExpirationDateMonthValidator" ControlToValidate="txtCreditCardExpirationDateMonth"
                                Type="Integer" MinimumValue="1" MaximumValue="12" Display="Dynamic"
                                ErrorMessage="El valor ha de estar entre 1 y 12" CssClass="text-danger"
                                runat="server" />

                        </div>
                        <div class="form-group col-sm-4">
                            <label for="ccyear">Año</label>

                            <asp:TextBox runat="server" ID="txtCreditCardExpirationDateYear" CssClass="form-control" TextMode="SingleLine" MaxLength="4" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCreditCardExpirationDateYear" Display="Dynamic"
                                CssClass="text-danger" ErrorMessage="El campo del año de expiración de la tarjeta es obligatorio." />

                            <asp:RangeValidator ID="txtCreditCardExpirationDateYearValidator" ControlToValidate="txtCreditCardExpirationDateYear"
                                Type="Integer" MinimumValue="<%: DateTime.Now.Year %>" MaximumValue="2100" Display="Dynamic"
                                ErrorMessage="El año ha de ser el corriente o superior" CssClass="text-danger"
                                runat="server" />

                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label for="txtCreditCardCVV">CVV/CVC</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtCreditCardCVV" TextMode="SingleLine" MaxLength="3" placeholder="123" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCreditCardCVV" Display="Dynamic"
                                    CssClass="text-danger" ErrorMessage="El campo del CVV de la tarjeta es obligatorio." />

                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-footer  text-center">
                    <div class="form-group">

                        <asp:Button ID="Button1" runat="server" Text="Finalizar compra" OnClick="ButtonUpdateOrder_Click" />
                    </div>
                </div>


            </div>
        </div>
  
   </div> 
   
  </div> 


</asp:Content>
