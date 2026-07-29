using System;

namespace BRAMSELU.Ventas
{
    public class ReporteVentas
    {
        public int IdVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal Total { get; set; }
        public decimal EfectivoRecibido { get; set; }
        public decimal Cambio { get; set; }
        public int IdCaja { get; set; }
    }
}