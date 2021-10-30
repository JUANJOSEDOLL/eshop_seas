using System;

namespace EShop.Models
    {
    public class ClientOrder
        {
        /// <summary>
        /// Identificador de id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Identificador de número de fra
        /// </summary>
        public string InvoiceNumber { get; set; }
        /// <summary>
        /// Identificador de total fra
        /// </summary>
        public float TotalInvoice { get; set; }
        /// <summary>
        /// Identificador de fecha
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Identificador de status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Identificador de id usuario
        /// </summary>
        public string User_Id { get; set; }

        }
    }