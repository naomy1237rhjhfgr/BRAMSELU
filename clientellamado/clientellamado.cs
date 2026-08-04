using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAMSELU.clientellamado
{
    public class clientellamado
    {
        public string IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string TipoPiel { get; set; }

        public clientellamado()
        {
        }

        public clientellamado(string idCliente, string nombre, string telefono, string correo, string direccion, string tipoPiel)
        {
            IdCliente = idCliente;
            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
            TipoPiel = tipoPiel;
        }
    }
}