using System;
using System.Windows.Forms;
using BRAMSELU.BLL;
using System.Data;

namespace BRAMSELU
{
    public partial class frmLogin : Form
    {
        private LoginBLL loginBLL = new LoginBLL();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow resultado = loginBLL.ValidarLogin(txtUsuario.Text, txtContrasena.Text);

            if (resultado != null)
            {
                string nombreCompleto = $"{resultado["Nombre"]} {resultado["Apellido"]}";
                string tipoUsuario = resultado["TipoUsuario"].ToString().Trim();

                MessageBox.Show($"¡Bienvenido {nombreCompleto}! ({tipoUsuario})", "Inicio de Sesión Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmMenuPrincipal menu = new frmMenuPrincipal(nombreCompleto, tipoUsuario);
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(loginBLL.Mensaje, "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}