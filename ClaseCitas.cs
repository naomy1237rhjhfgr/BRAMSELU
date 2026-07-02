using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAMSELU
{
    public class ClaseCitas
    {
        private string _cliente;
        private int _telefono;
        private string _servicio;
        private string _especialista;
        private string _notas;
        private string _estado;
        private string _precio;

        private ClaseCitas()
        {
            _cliente = string.Empty;
            _telefono = 0;
            _servicio = "";
        }
    }
}
