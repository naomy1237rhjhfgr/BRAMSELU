using System;
using System.Data.SqlClient;

namespace BRAMSELU
{
    internal class Conexion
    {
      
        private SqlConnection cn = new SqlConnection("Server=localhost;Database=BRAMSELU;Trusted_Connection=True;TrustServerCertificate=True");

        
        public SqlConnection Abrir()
        {
            try
            {
                if (cn.State == System.Data.ConnectionState.Closed)
                {
                    cn.Open();
                }
                return cn;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir la conexión: " + ex.Message);
            }
        }

       
        public void Cerrar()
        {
            try
            {
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la conexión: " + ex.Message);
            }
        }
    }
}