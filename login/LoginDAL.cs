using System.Data;
using System.Data.SqlClient;

namespace BRAMSELU.DAL
{
    public class LoginDAL
    {
        private Conexion conexion = new Conexion();

        public DataTable Autenticar(string usuario)
        {
            DataTable dt = new DataTable();
           
            string query = "SELECT Nombre, Apellido, TipoUsuario, Estado, Contrasena FROM Empleados WHERE Usuario = @Usuario";

            using (SqlCommand cmd = new SqlCommand(query, conexion.Abrir()))
            {
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = usuario;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            conexion.Cerrar();
            return dt;
        }
    }
}