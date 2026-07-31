using System;

namespace BRAMSELU.reportecaja
{
    public class CajaReporteModelo
    {
        public int IdCaja { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime FechaCierre { get; set; }
        public decimal MontoInicial { get; set; }
        public decimal TotalVentasEfectivo { get; set; }
        public decimal MontoFinal { get; set; }
        public string Estado { get; set; }
        public string UsuarioApertura { get; set; }
        public decimal TotalCompras { get; set; }
    }
}