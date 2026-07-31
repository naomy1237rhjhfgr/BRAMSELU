using BRAMSELU.Caja;
using BRAMSELU.Compra;
using BRAMSELU.Mensajes;
using BRAMSELU.Ventas;
using System;
using System.Windows.Forms;
namespace BRAMSELU
{
    public partial class frmMenuPrincipal : Form
    {
        private string nombreUsuario;
        private string rolUsuario;

        private Form formActivo = null;

        private DashboardDAL dashboardDAL = new DashboardDAL();
        private Timer timerDashboard;

        public frmMenuPrincipal(string nombreUsuario, string rolUsuario)
        {
            InitializeComponent();

            this.nombreUsuario = nombreUsuario;
            this.rolUsuario = rolUsuario;

            timerDashboard = new Timer();
            timerDashboard.Interval = 1000; // 1 segundo
            timerDashboard.Tick += TimerDashboard_Tick;
            timerDashboard.Start();
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuarioActivo.Text = $"{nombreUsuario}  ({rolUsuario})";

            CargarEstadisticas();

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
            AbrirFormEnPanel(new FrmVentas());
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
            FrmCerrarSesion cerrarSesion = new FrmCerrarSesion();

            DialogResult resultado = cerrarSesion.ShowDialog();

            if (resultado == DialogResult.Yes)
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
                formActivo = null;
            }

            CargarEstadisticas();

            if (rolUsuario.Equals("Empleado", StringComparison.OrdinalIgnoreCase))
            {
                if (pnlContenido.Controls.ContainsKey("panelClientesRegistrados"))
                {
                    pnlContenido.Controls["panelClientesRegistrados"].Visible = false;
                }
            }
        }

        private void BtnInicio_Click(object sender, EventArgs e)
        {
            if (formActivo != null)
            {
                formActivo.Close();
                formActivo = null;
            }

            CargarEstadisticas();

            if (rolUsuario.Equals("Empleado", StringComparison.OrdinalIgnoreCase))
            {
                if (pnlContenido.Controls.ContainsKey("panelClientesRegistrados"))
                {
                    pnlContenido.Controls["panelClientesRegistrados"].Visible = false;
                }
            }
        }

        private void BtnCaja_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmCaja());
        }

        private void BtnCompras_Click(object sender, EventArgs e)
        {

            AbrirFormEnPanel(new FrmCompra());
        }

        private void pnlContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CargarEstadisticas()
        {
            try
            {
                int[] estadisticas = dashboardDAL.ObtenerEstadisticas();

                lblClientesRegistrados.Text = estadisticas[0].ToString("D2");
                lblEmpleados.Text = estadisticas[1].ToString("D2");
                lblProductos.Text = estadisticas[2].ToString("D2");
                
            }
            catch (Exception ex)
            {
                timerDashboard?.Stop();

                MessageBox.Show(
                    "No se pudieron actualizar las estadísticas del panel.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void TimerDashboard_Tick(object sender, EventArgs e)
        {
            CargarEstadisticas();
        }

        private void pnlContenido_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}