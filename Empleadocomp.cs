using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BRAMSELU
{
    internal class Empleadocomp
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

        private Conexion _conexion;


        public Empleadocomp()
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
            _tipoUsuario = "Empleado";

            _conexion = new Conexion();
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



        private bool Validar()
        {
            if (_nombre == "")
                return false;

            if (_apellido == "")
                return false;

            if (_identidad == "")
                return false;

            if (_telefono == "")
                return false;

            if (_usuario == "")
                return false;

            if (_contrasena == "")
                return false;


            return true;
        }



        public bool Guardar()
        {
            if (Validar())
            {
                string SQL = $"INSERT INTO Empleados(Nombre,Apellido,Identidad,Telefono,Direccion,Correo,Usuario,Contrasena,TipoUsuario) VALUES('{_nombre}','{_apellido}','{_identidad}','{_telefono}','{_direccion}','{_correo}','{_usuario}','{_contrasena}','{_tipoUsuario}')";

                _conexion.EjecutarSQL(SQL);

                return true;
            }

            return false;
        }



        public bool Actualizar()
        {
            if (Validar())
            {
                string SQL = $"UPDATE Empleados SET Nombre='{_nombre}',Apellido='{_apellido}',Identidad='{_identidad}',Telefono='{_telefono}',Direccion='{_direccion}',Correo='{_correo}',Usuario='{_usuario}',Contrasena='{_contrasena}',TipoUsuario='{_tipoUsuario}' WHERE IdEmpleado={_idEmpleado}";

                _conexion.EjecutarSQL(SQL);

                return true;
            }

            return false;
        }



        public bool Eliminar()
        {
            string SQL = $"DELETE FROM Empleados WHERE IdEmpleado={_idEmpleado}";

            _conexion.EjecutarSQL(SQL);

            return true;
        }



        public List<Empleado> Listar()
        {
            string SQL = "SELECT * FROM Empleados";

            return _conexion.EjecutarConsultaVarios(SQL);
        }



        public bool BuscarPorIdentidad(string identidad)
        {

            string SQL = $"SELECT * FROM Empleados WHERE Identidad='{identidad}'";


            SqlDataReader reader = _conexion.EjecutarConsultaUno(SQL);


            if (reader != null)
            {

                _idEmpleado = reader.GetInt32(0);
                _nombre = reader.GetString(1);
                _apellido = reader.GetString(2);
                _identidad = reader.GetString(3);
                _telefono = reader.GetString(4);
                _direccion = reader.GetString(5);
                _correo = reader.GetString(6);
                _usuario = reader.GetString(7);
                _contrasena = reader.GetString(8);
                _tipoUsuario = reader.GetString(9);


                reader.Close();

                return true;
            }


            return false;
        }



        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();

            try
            {

                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM Empleados",
                    _conexion.Abrir());


                da.Fill(tabla);

                _conexion.Cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return tabla;
        }

    }
}