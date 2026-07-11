using System;
using System.Windows.Forms;

namespace BRAMSELU
{
    public partial class frmLogin : Form
    {
        private ClaseLogin loginServicio = new ClaseLogin();

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

            loginServicio.Autenticar(txtUsuario.Text, txtContrasena.Text);

            if (loginServicio.Exito)
            {
                bool esAdministrador = loginServicio.TipoUsuario.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
                bool esEmpleado = loginServicio.TipoUsuario.Equals("Empleado", StringComparison.OrdinalIgnoreCase);

                if (!esAdministrador && !esEmpleado)
                {
                    MessageBox.Show("El tipo de usuario no es válido. Contacte al administrador.",
                        "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show($"¡Bienvenido {loginServicio.NombreCompleto}! ({loginServicio.TipoUsuario})", "Inicio de Sesión Exitoso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmMenuPrincipal menu = new frmMenuPrincipal(loginServicio.NombreCompleto, loginServicio.TipoUsuario);
                menu.Show();
                this.Hide();
            }
            else
            {
                if (!loginServicio.Activo)
                {
                    MessageBox.Show(loginServicio.Mensaje, "Usuario inactivo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(loginServicio.Mensaje, "Error de Autenticación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}