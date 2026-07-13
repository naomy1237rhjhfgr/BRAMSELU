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
        private SqlConnection conexion;


        public Conexion()
        {
            _nombreDB = "BRAMSELU";
            _server = "localhost";

            _cadenaConexion = $"Server={_server};Database={_nombreDB};Integrated Security=True;TrustServerCertificate=True;";

            conexion = new SqlConnection(_cadenaConexion);
        }


        public void Conectar()
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public bool EjecutarSQL(string SQL)
        {
            Conectar();

            try
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);

                cmd.ExecuteNonQuery();

                Cerrar();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        public SqlDataReader EjecutarConsultaUno(string SQL)
        {
            Conectar();

            try
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return reader;
                }
                else
                {
                    reader.Close();
                    Cerrar();
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        public SqlDataReader EjecutarConsulta(string SQL)
        {
            Conectar();

            try
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);

                SqlDataReader reader = cmd.ExecuteReader();

                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        public DataTable EjecutarConsultaDataTable(string SQL)
        {
            DataTable tabla = new DataTable();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SQL, conexion);

                da.Fill(tabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return tabla;
        }


        public SqlConnection Abrir()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }

            return conexion;
        }


        public void Cerrar()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}