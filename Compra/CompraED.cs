using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAMSELU.Compra
{
    public class CompraED
    {
        public int IdCompra { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int IdProveedor { get; set; }


        public int IdDetalle { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }


        public DataTable DetalleTabla { get; set; }
    }
}
