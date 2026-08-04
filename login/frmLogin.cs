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
        private bool verPassword = false;

        public frmLogin()
        {
            InitializeComponent();

            txtContrasena.PasswordChar = '●';
            if (btnVerContrasena != null) btnVerContrasena.Text = "👁";
        }

        private void btnVerContrasena_Click_1(object sender, EventArgs e)
        {
            verPassword = !verPassword;
            if (verPassword)
            {
                txtContrasena.PasswordChar = '\0';
                btnVerContrasena.Text = "🙈";
            }
            else
            {
                txtContrasena.PasswordChar = '●';
                btnVerContrasena.Text = "👁";
            }
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

                GestorMensajes.Exito($"¡Bienvenido {nombreCompleto}! ({tipoUsuario})");

                frmMenuPrincipal menu = new frmMenuPrincipal(nombreCompleto, tipoUsuario);
                menu.Show();
                this.Hide();
            }
            else
            {
                txtContrasena.Clear();
                txtContrasena.Focus();
                verPassword = false;
                txtContrasena.PasswordChar = '●';
                if (btnVerContrasena != null) btnVerContrasena.Text = "👁";

                GestorMensajes.Error(loginBLL.Mensaje);
            }
        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {

        }

        

       
    }
}