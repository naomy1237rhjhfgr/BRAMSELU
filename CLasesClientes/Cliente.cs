using System;

namespace BRAMSELU.Entidades
{
    public class Cliente
    {
        private string _id;
        private string _nombre;
        private string _telefono;
        private string _correo;
        private string _direccion;
        private string _tipoPiel;

        public Cliente()
        {
            _id = "";

            _nombre = "";

            _telefono = "";

            _correo = "";

            _direccion = "";

            _tipoPiel = "";
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public string TipoPiel
        {
            get { return _tipoPiel; }
            set { _tipoPiel = value; }
        }
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