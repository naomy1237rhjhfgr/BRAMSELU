using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAMSELU.Servicios
{
    public class Servicio
    {
        public int IdServicio { get; set; }
        public string NombreServicio { get; set; }
        public string Descripcion { get; set; }     
        public decimal Precio { get; set; }
        public int Duracion { get; set; }
        public bool Estado { get; set; }

    }
}
