using System;

namespace BRAMSELU.Productos.Modelos
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaRegistro { get; set; }
        public byte[] Imagen { get; set; }
        public int? IdCategoria { get; set; }
    }
}