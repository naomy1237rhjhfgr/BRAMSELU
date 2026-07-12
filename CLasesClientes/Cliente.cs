using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAMSELU
{
    public class Cliente
    {

        public string Id {  get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion {  get; set; }
        public string TipoPiel {  get; set; }

        public Cliente(string id, string nombre, string telefono, string correo, string direccion, string tipoPiel)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
            TipoPiel = tipoPiel;
        }
    }
}
