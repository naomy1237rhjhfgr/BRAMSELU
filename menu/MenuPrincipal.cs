using System;
using System.Windows.Forms;

namespace BRAMSELU
{
    public partial class frmMenuPrincipal : Form
    {
        private string nombreUsuario;
        private string rolUsuario;

        private Form formActivo = null;

        public frmMenuPrincipal(string nombreUsuario, string rolUsuario)
        {
            InitializeComponent();
            this.nombreUsuario = nombreUsuario;
            this.rolUsuario = rolUsuario;
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuarioActivo.Text = $"{nombreUsuario}  ({rolUsuario})";
            //lblBienvenida.Text = $"Hola, {nombreUsuario.Split(' ')[0]}";

     
            if (rolUsuario.Equals("Empleado", StringComparison.OrdinalIgnoreCase))
            {
                btnEmpleados.Visible = false;
                btnReportes.Visible = false;

             
                if (pnlContenido.Controls.ContainsKey("panelClientesRegistrados"))
                {
                    pnlContenido.Controls["panelClientesRegistrados"].Visible = false;
                }
            }
        }

        private void AbrirFormEnPanel(Form formHijo)
        {
            if (formActivo != null)
            {
                formActivo.Close();
            }

            formActivo = formHijo;

            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(formHijo);
            pnlContenido.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmClientes());
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmCitas());
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmServicios());
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmInventario());
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmCategorias());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmVentas());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmReportes());
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmEmpleados());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show(
                "¿Está seguro que desea cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
            }
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            if (formActivo != null)
            {
                formActivo.Close();
            }

            
            if (rolUsuario.Equals("Empleado", StringComparison.OrdinalIgnoreCase))
            {
                if (pnlContenido.Controls.ContainsKey("panelClientesRegistrados"))
                {
                    pnlContenido.Controls["panelClientesRegistrados"].Visible = false;
                }
            }
        }
    }
}