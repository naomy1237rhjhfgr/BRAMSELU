using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAMSELU.ClasesProducto
{
    public class ClaseProducto
    {
        public int ProductoID {  get; set; }
        public string NombreProducto { get; set; }
        public int CategoriaID { get; set; }
        public string NombreCategoria { get; set; } 
        public string TipoPiel { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public bool Activo { get; set; }

        public ClaseProducto()
        {
            Activo = true;
        }
        public ClaseProducto(string nombreProducto, int categoriaId, string tipoPiel,
                         string descripcion, decimal precioVenta, int stock,
                         int stockMinimo, int stockMaximo)
        {
            NombreProducto = nombreProducto;
            CategoriaID = categoriaId;
            TipoPiel = tipoPiel;
            Descripcion = descripcion;
            PrecioVenta = precioVenta;
            Stock = stock;
            StockMinimo = stockMinimo;
            StockMaximo = stockMaximo;
            Activo = true;
        }

    }

}
