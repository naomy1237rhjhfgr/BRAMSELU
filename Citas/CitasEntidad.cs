using System;

namespace BRAMSELU.Entidades
{
    public class ClaseCitas
    {
        public int IdCita { get; set; }
        public string IdCliente { get; set; }
        public int IdServicio { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Estado { get; set; }
        public decimal Precio { get; set; }
    }
}
