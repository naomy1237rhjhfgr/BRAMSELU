using System;

namespace BRAMSELU.Compra
{
    public class CompraED
    {
        public int IdCompra { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int IdProveedor { get; set; }
        public string NombreEmpleado { get; set; }

       
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}