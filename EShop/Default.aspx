<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EShop._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/StyleSheet_landingPage.css" rel="stylesheet" />
    <div class="jumbotron">
        <a runat="server" href="~/User/ProductList" style="text-decoration:none">
        <h1>ESHOP</h1>
        <p class="right"><strong>En nuestra tienda podrá encontrar todo tipo de joyas en oro, plata o platino,</strong><br>
        <p class="right"><strong>desde el regalo más fino y económico en plata,</strong><br>
        <p class="right"><strong> hasta el brillante más valioso, déjese asesorar por nuestros expertos.</strong></p>
        </a>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div>
                    <h2>Oro</h2>
                    <p>
                        El oro es un metal blando, brillante y maleable que se obtiene de la naturaleza con tono amarillento.
                Pero no solo existe el oro amarillo, como sabéis en el mundo de la alta joyería es común ver joyas realizadas
                en oro blanco y oro rosa. Estos tres tipos de oro tienen la misma composición y las mismas cualidades,
                el cambio de color se debe únicamente a la mezcla del oro con otros metales.
                    </p>

                </div>

            </div>
            <div class="col-md-6">
                <div>

                    <img src="Content/Images_landingPage/oro.jpg"   class="img-responsive" />
                    </div>

            </div>
        </div>


        <div class="row">
            <div class="col-md-6">
                <div>

                    <img src="Content/Images_landingPage/pepita-del-platino.jpg"   class="img-responsive"/>
               
                </div>

            </div>
            <div class="col-md-6">
                <div>
                    <h2>Platino</h2>
            <p>
               Efectivamente el Platino se trata de un metal de color blanco grisáceo, precioso, pesado, muy dúctil y maleable.
                Sin embargo es resistente a la corrosión y no se disuelve en la mayoría de los ácidos.También puede encontrarse
                mezclado en otros minerales como por ejemplo el níquel y el cobre.
                Este mineral fue descubierto en el año 1735 por el español Antonio de Ulloa en Colombia, dónde ya era utilizado
                por los indios pre-colombinos, fue él quién inició su traslado a Europa (aunque en el viaje fue interceptado por 
                piratas ingleses, pero ésta, es otra historia…). Su nombre es debido a su gran parecido con la Plata, 
                lo cual hizo creer en un primer momento que se trataba de este último material. Años después, se encontraron 
                yacimientos de Platino en Rusia (Montes Urales), en Canadá y en Sudáfrica. Estos siguen siendo hoy en día los 
                mayores yacimientos de Platino en el mundo.
            </p>


                </div>

            </div>
        </div>

         <div class="row">
            <div class="col-md-6">
                <div>
                     <h2>Plata</h2>
            <p>
               La plata es un elemento químico de símbolo Ag (del latín argentum: “blanco” o “brillante”), clasificado como un metal 
                de transición y considerado un metal precioso, como el oro y el platino. Además, es fundamental en numerosas industrias
                humanas, como la electrónica, la fotografía y la joyería, siendo también un poderoso catalizador de numerosas reacciones
                químicas.
                 </p>
                </div>

            </div>
            <div class="col-md-6">
                <div>

         
                    <img src="Content/Images_landingPage/plata.jpg"  class="img-responsive" />
                </div>

            </div>
        </div>
    </div>



</asp:Content>
