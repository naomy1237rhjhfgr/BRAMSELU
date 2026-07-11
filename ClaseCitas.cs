using System;
using System.Data;

namespace BRAMSELU
{
    public class ClaseCitas
    {
        private int _id;
        private string _cliente;
        private string _telefono;
        private string _servicio;
        private string _especialista;
        private DateTime _fecha;
        private string _hora;
        private string _duracion;
        private string _notas;
        private string _estado;
        private decimal _precio;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ClaseCitas()
        {
            _id = 0;
            _cliente = string.Empty;
            _telefono = string.Empty;
            _servicio = string.Empty;
            _especialista = string.Empty;
            _fecha = DateTime.Now;
            _hora = string.Empty;
            _duracion = string.Empty;
            _notas = string.Empty;
            _estado = "Pendiente";
            _precio = 0;
        }

        /// <summary>
        /// Constructor completo
        /// </summary>
        public ClaseCitas(int id, string cliente, string telefono, string servicio, string especialista, DateTime fecha, string hora, string duracion, string notas, string estado, decimal precio)
        {
            _id = id;
            _cliente = cliente;
            _telefono = telefono;
            _servicio = servicio;
            _especialista = especialista;
            _fecha = fecha;
            _hora = hora;
            _duracion = duracion;
            _notas = notas;
            _estado = estado;
            _precio = precio;
        }

        public int ID { get { return _id; } set { _id = value; } }
        public string Cliente { get { return _cliente; } set { _cliente = value; } }

        public string Telefono { get { return _telefono; } set { _telefono = value; } }
        public string Servicio { get { return _servicio; } set { _servicio = value; } }
        public string Especialista { get { return _especialista; } set { _especialista = value; } }

        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
        public string Hora { get { return _hora; } set { _hora = value; } }
        public string Duracion { get { return _duracion; } set { _duracion = value; } }
        public string Notas { get { return _notas; } set { _notas = value; } }

        public string Estado { get { return _estado; } set { _estado = value; } }

        public decimal Precio { get { return _precio; } set { _precio = value; } }
    }
}
