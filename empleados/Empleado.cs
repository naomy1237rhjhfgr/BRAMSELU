using System;

namespace BRAMSELU.Entidades
{
    public class Empleado
    {
        private int _idEmpleado;
        private string _nombre;
        private string _apellido;
        private string _identidad;
        private string _telefono;
        private string _direccion;
        private string _correo;
        private string _usuario;
        private string _contrasena;
        private string _tipoUsuario;

        public Empleado()
        {
            _idEmpleado = 0;
            _nombre = "";
            _apellido = "";
            _identidad = "";
            _telefono = "";
            _direccion = "";
            _correo = "";
            _usuario = "";
            _contrasena = "";
            _tipoUsuario = "";
        }

        public int IdEmpleado
        {
            get { return _idEmpleado; }
            set { _idEmpleado = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string Identidad
        {
            get { return _identidad; }
            set { _identidad = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public string Contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }

        public string TipoUsuario
        {
            get { return _tipoUsuario; }
            set { _tipoUsuario = value; }
        }
    }
}