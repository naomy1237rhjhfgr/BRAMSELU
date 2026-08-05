using System.Data;
using BRAMSELU.DAL;

namespace BRAMSELU.BLL
{
    public class LoginBLL
    {
        private LoginDAL dal = new LoginDAL();
        public string Mensaje { get; private set; }

        public DataRow ValidarLogin(string usuario, string contrasena)
        {
          
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                Mensaje = "El usuario y la contraseña no pueden estar vacíos.";
                return null;
            }

            DataTable dt = dal.Autenticar(usuario.Trim());

            if (dt.Rows.Count == 0)
            {
                Mensaje = "Usuario o contraseña incorrectos.";
                return null;
            }

            DataRow fila = dt.Rows[0];

          
            if (!(bool)fila["Estado"])
            {
                Mensaje = "Este usuario está inactivo. Contacte al administrador.";
                return null;
            }

            string passwordDb = fila["Contrasena"].ToString().Trim();
            if (passwordDb != contrasena.Trim()) 
            {
                Mensaje = "Usuario o contraseña incorrectos.";
                return null;
            }

            return fila;
        }
    }
}