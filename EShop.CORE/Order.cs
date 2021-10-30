using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.CORE
#region Entidad de dominio de las ordenes
    {
    /// <summary>
    /// Entidad de dominio de las ordenes
    /// </summary>    
    public class Order
        {
        /// <summary>
        /// Identificador de la orden o pedido
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Número de factura
        /// </summary>
        public string InvoiceNumber { get; set; }


        /// <summary>
        /// Importe total factura
        /// </summary>

        public float TotalInvoice { get; set; }

        /// <summary>
        /// Fecha de creación de la orden o pedido
        /// </summary>
        public DateTime CreatedDate { get; set; }


        /// <summary>
        /// Estado del pedido: pendiente cobro, cobrado, enviado, recepcionado
        /// </summary>
        public OrderStatus Status { get; set; }


        /// <summary>
        /// Usuario que ha creado la orden
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Identificador del usuario que ha creado la orden
        /// </summary>
        [ForeignKey("User")]
        public string User_Id { get; set; }

        /// <summary>
        /// Colección de lineas de detalle de pedido
        /// </summary>
        public virtual List<OrderDetail> OrderDetails { get; set; }
        } 
    #endregion
    }
