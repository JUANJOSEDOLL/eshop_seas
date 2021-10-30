namespace EShop.CORE
    {
    /// <summary>
    /// Enumerado de los posibles estados de una orden
    /// </summary>
    public enum OrderStatus : int
        {
        /// <summary>
        /// Pendiente de pago
        /// </summary>
        Pendiente = 0,
        /// <summary>
        /// Pago confirmado
        /// </summary>
        Confirmado = 1,
        /// <summary>
        /// Pedido enviado
        /// </summary>
        Enviado = 2,
        /// <summary>
        /// Pedido recepcionado por el cliente
        /// </summary>
        Recepcionado = 3
        }
    }