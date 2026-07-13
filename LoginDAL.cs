using System.Data;
using System.Data.SqlClient;

namespace BRAMSELU.DAL
{
    public class LoginDAL
    {
        private Conexion conexion = new Conexion();

        public DataTable Autenticar(string usuario, string contrasena)
        {
            DataTable dt = new DataTable();
            string query = "SELECT Nombre, Apellido, TipoUsuario, Estado FROM Empleados WHERE Usuario = @user AND Contrasena = @pass";

            using (SqlCommand cmd = new SqlCommand(query, conexion.Abrir()))
            {
                cmd.Parameters.AddWithValue("@user", usuario);
                cmd.Parameters.AddWithValue("@pass", contrasena);

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