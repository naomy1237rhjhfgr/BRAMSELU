using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BRAMSELU
{
    internal class Conexion
    {
        private SqlConnection conexion;
        private string _cadenaConexion = "Server=localhost;Database=BRAMSELU;Integrated Security=True;TrustServerCertificate=True;";

        public SqlDataReader EjecutarConsulta(string SQL, params SqlParameter[] parametros)
        {
            try
            {
                SqlConnection con = new SqlConnection(_cadenaConexion);
                SqlCommand cmd = new SqlCommand(SQL, con);

                if (parametros != null) cmd.Parameters.AddRange(parametros);

                con.Open();

                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en consulta: " + ex.Message);
                return null;
            }
        }

        public SqlDataReader EjecutarConsultaUno(string SQL, params SqlParameter[] parametros)
        {
            try
            {
                SqlConnection con = new SqlConnection(_cadenaConexion);
                SqlCommand cmd = new SqlCommand(SQL, con);

                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.Read())
                    return reader;

                reader.Close();
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en consulta: " + ex.Message);
                return null;
            }
        }

        public bool EjecutarSQL(string SQL, params SqlParameter[] parametros)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(SQL, con);
                    if (parametros != null) cmd.Parameters.AddRange(parametros);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        public SqlConnection Abrir()
        {
            if (conexion == null)
            {
                conexion = new SqlConnection(_cadenaConexion);
            }

            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }

            return conexion;
        }

        public void Cerrar()
        {
            if (conexion != null)
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public DataTable EjecutarConsultaDataTable(string SQL)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection con = new SqlConnection(_cadenaConexion))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(SQL, con);
                    con.Open();
                    da.Fill(tabla);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la consulta de datos: " + ex.Message);
                }
            }

            return tabla;
        }
    }
}