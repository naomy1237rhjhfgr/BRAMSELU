using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAMSELU.Ventas
{
    public class VentaED
    {
        // Atributos de la tabla Productos
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public string Imagen { get; set; }


        public int CantidadVendida { get; set; }
        public decimal Subtotal { get; set; }

        public decimal TotalPagar { get; set; }
        public decimal EfectivoRecibido { get; set; }
        public decimal Cambio { get; set; }
    }

}
