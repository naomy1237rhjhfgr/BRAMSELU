using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BRAMSELU
{
    public partial class frmLogin : Form
    {
        private Conexion conexion = new Conexion();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtContrasena.Text))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Campos vacíos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // El login se valida directamente contra dbo.Empleados,
                // que es donde están Usuario, Contrasena, TipoUsuario y Estado.
                string query = @"SELECT Nombre, Apellido, TipoUsuario, Estado
                                 FROM Empleados
                                 WHERE Usuario = @usuario AND Contrasena = @contrasena";

                using (SqlCommand cmd = new SqlCommand(query, conexion.Abrir()))
                {
                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
                    cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Text.Trim());

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bool activo = Convert.ToBoolean(reader["Estado"]);

                            if (!activo)
                            {
                                reader.Close();
                                conexion.Cerrar();

                                MessageBox.Show("Este usuario está inactivo. Contacte al administrador.",
                                    "Usuario inactivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            string nombreCompleto = reader["Nombre"].ToString() + " " + reader["Apellido"].ToString();
                            string tipoUsuario = reader["TipoUsuario"].ToString().Trim();

                            reader.Close();
                            conexion.Cerrar();

                            // Verifica que el tipo de usuario sea uno de los valores permitidos
                            bool esAdministrador = tipoUsuario.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
                            bool esEmpleado = tipoUsuario.Equals("Empleado", StringComparison.OrdinalIgnoreCase);

                            if (!esAdministrador && !esEmpleado)
                            {
                                MessageBox.Show("El tipo de usuario no es válido. Contacte al administrador.",
                                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            MessageBox.Show($"¡Bienvenido {nombreCompleto}! ({tipoUsuario})", "Inicio de Sesión Exitoso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            frmMenuPrincipal menu = new frmMenuPrincipal(nombreCompleto, tipoUsuario);
                            menu.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Autenticación",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Cerrar();
            }
        }
    }
}