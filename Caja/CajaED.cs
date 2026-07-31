using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAMSELU.Caja
{
    public class CajaED
    {
        public int IdCaja { get; set; }
        public System.DateTime FechaApertura { get; set; }
        public System.DateTime? FechaCierre { get; set; }
        public decimal MontoInicial { get; set; }
        public decimal TotalVentasEfectivo { get; set; }
        public decimal TotalCompras { get; set; }
        public decimal MontoFinal { get; set; }
        public string Estado { get; set; }
        public string UsuarioApertura { get; set; }
    }
}