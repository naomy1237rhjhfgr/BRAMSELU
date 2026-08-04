using System;

namespace BRAMSELU.reporteproductos
{
    public class ReporteProductosVendidosModelo
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public int CantidadVendidaTotal { get; set; }
        public decimal TotalIngresos { get; set; }
    }
}