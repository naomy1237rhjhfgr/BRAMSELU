using System;
using System.Windows.Forms;
using BRAMSELU.BLL;
using System.Data;
using BRAMSELU.Mensajes;

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
                GestorMensajes.Advertencia("Por favor, ingrese usuario y contraseña");
                return;
            }

            DataRow resultado = loginBLL.ValidarLogin(txtUsuario.Text, txtContrasena.Text);

            if (resultado != null)
            {
                string nombreCompleto = $"{resultado["Nombre"]} {resultado["Apellido"]}";
                string tipoUsuario = resultado["TipoUsuario"].ToString().Trim();

                GestorMensajes.Exito($"¡Bienvenido{nombreCompleto}!({tipoUsuario})");

                frmMenuPrincipal menu = new frmMenuPrincipal(nombreCompleto, tipoUsuario);
                menu.Show();
                this.Hide();
            }
            else
            {
                GestorMensajes.Error(loginBLL.Mensaje);
            }
        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}