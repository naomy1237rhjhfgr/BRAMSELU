using System;

namespace BRAMSELU
{
    internal class Empleado
    {
       
        private int idEmpleado;
        private string nombre;
        private string apellido;
        private string identidad;
        private string telefono;
        private string direccion;
        private string correo;
        private string usuario;
        private string contrasena;
        private string tipoUsuario;

       

        public int IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Identidad
        {
            get { return identidad; }
            set { identidad = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        public string TipoUsuario
        {
            get { return tipoUsuario; }
            set { tipoUsuario = value; }
        }
    }
}