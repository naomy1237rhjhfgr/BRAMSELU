using System;
using System.Data;

namespace Entidad
{
    public class Cita
    {
        private int idCita;
        private string idCliente;
        private int idServicio;
        private DateTime fecha;
        private string hora;
        private string estado;
        private string idEmpleado;

        public int IdCita
        {
            get { return idCita; } set { idCita = value; }
        }

        public string IdCliente
        {
            get { return idCliente; } set { idCliente = value; }
        }

        public int IdServicio
        {
            get { return idServicio; } set { idServicio = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; } set { fecha = value; }
        }

        public string Hora
        {
            get { return hora; } set { hora = value; }
        }

        public string Estado
        {
            get { return estado; } set { estado = value; }
        }

        public string IdEmpleado
        {
            get { return idEmpleado; } set { idEmpleado = value; }
        }
    }
}
