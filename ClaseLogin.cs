using System;
using System.Data.SqlClient;

namespace BRAMSELU
{
    public class ClaseLogin
    {
        private Conexion conexion = new Conexion();
        private bool exito;
        private string mensaje;
        private string nombreCompleto;
        private string tipoUsuario;
        private bool activo;

        public bool Exito
        {
            get { return exito; }
            set { exito = value; }
        }

        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
        }

        public string TipoUsuario
        {
            get { return tipoUsuario; }
            set { tipoUsuario = value; }
        }

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        public void Autenticar(string usuario, string contrasena)
        {
            this.exito = false;
            this.activo = true;
            this.mensaje = "";

            try
            {
                string query = "SELECT Nombre, Apellido, TipoUsuario, Estado FROM Empleados WHERE Usuario = '" + usuario.Trim() + "' AND Contrasena = '" + contrasena.Trim() + "'";

                using (SqlCommand cmd = new SqlCommand(query, conexion.Abrir()))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.activo = Convert.ToBoolean(reader["Estado"]);

                            if (!this.activo)
                            {
                                this.mensaje = "Este usuario está inactivo. Contacte al administrador.";
                                return;
                            }

                            this.nombreCompleto = reader["Nombre"].ToString() + " " + reader["Apellido"].ToString();
                            this.tipoUsuario = reader["TipoUsuario"].ToString().Trim();
                            this.exito = true;
                        }
                        else
                        {
                            this.mensaje = "Usuario o contraseña incorrectos.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.mensaje = "Ocurrió un error en la base de datos: " + ex.Message;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
    }
}