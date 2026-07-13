using System;
using System.Data.SqlClient;

namespace BRAMSELU
{
    public class ClaseLogin
    {
        private Conexion conexion = new Conexion();
        private bool exito;
        private string mensaje;
        private string nombreCompleto;
        private string tipoUsuario;
        private bool activo;

        public bool Exito
        {
            get { return exito; }
            set { exito = value; }
        }

        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
        }

        public string TipoUsuario
        {
            get { return tipoUsuario; }
            set { tipoUsuario = value; }
        }

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

       
        }
    }
}