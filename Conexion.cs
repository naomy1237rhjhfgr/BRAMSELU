using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BRAMSELU
{
    internal class Conexion
    {
        private string _nombreDB;
        private string _server;
        private string _cadenaConexion;
        private SqlConnection _conexion;

        public Conexion()
        {
            _nombreDB = "BRAMSELU";
            _server = "localhost";

            _cadenaConexion = $"Server={_server};Database={_nombreDB};Integrated Security=True;TrustServerCertificate=True;";
            _conexion = new SqlConnection(_cadenaConexion);
        }

     
        public SqlConnection Abrir()
        {
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();

                return _conexion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

     
        public void Cerrar()
        {
            if (_conexion.State == ConnectionState.Open)
                _conexion.Close();
        }

        public bool EjecutarSQL(string SQL)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(SQL, Abrir());
                cmd.ExecuteNonQuery();
                Cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cerrar();
                return false;
            }
        }

    
        public SqlDataReader EjecutarConsultaUno(string SQL)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(SQL, Abrir());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                    return reader;

                reader.Close();
                Cerrar();
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cerrar();
                return null;
            }
        }

     
        public List<Empleado> EjecutarConsultaVarios(string SQL)
        {
            List<Empleado> lista = new List<Empleado>();

            try
            {
                SqlCommand cmd = new SqlCommand(SQL, Abrir());
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Empleado emp = new Empleado();

                    emp.IdEmpleado = reader.GetInt32(0);
                    emp.Nombre = reader.GetString(1);
                    emp.Apellido = reader.GetString(2);
                    emp.Identidad = reader.GetString(3);
                    emp.Telefono = reader.GetString(4);
                    emp.Direccion = reader.GetString(5);
                    emp.Correo = reader.GetString(6);
                    emp.Usuario = reader.GetString(7);
                    emp.Contrasena = reader.GetString(8);
                    emp.TipoUsuario = reader.GetString(9);

                    lista.Add(emp);
                }

                reader.Close();
                Cerrar();

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cerrar();
                return null;
            }
        }
    }
}