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
                string query = @"SELECT U.NombreCompleto, R.NombreRol 
                                 FROM Usuarios U 
                                 INNER JOIN Roles R ON U.IdRol = R.IdRol 
                                 WHERE U.Usuario = @usuario AND U.Contrasena = @contrasena";

                using (SqlCommand cmd = new SqlCommand(query, conexion.Abrir()))
                {
                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
                    cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Text.Trim());

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nombreCompleto = reader["NombreCompleto"].ToString();
                            string rol = reader["NombreRol"].ToString();

                            reader.Close();
                            conexion.Cerrar();

                            MessageBox.Show($"¡Bienvenido {nombreCompleto}!", "Inicio de Sesión Exitoso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            frmMenuPrincipal menu = new frmMenuPrincipal(nombreCompleto, rol);
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