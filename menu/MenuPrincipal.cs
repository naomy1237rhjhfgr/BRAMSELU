using BRAMSELU.Caja;
using BRAMSELU.Compra;
using BRAMSELU.Mensajes;
using BRAMSELU.Ventas;
using System;
using System.Data;
using System.Windows.Forms;

namespace BRAMSELU
{
    public partial class frmMenuPrincipal : Form
    {
        private string nombreUsuario;
        private string rolUsuario;

        private Form formActivo = null;

        private DashboardDAL dashboardDAL = new DashboardDAL();

        private Timer timerReloj = new Timer();

        public frmMenuPrincipal(string nombreUsuario, string rolUsuario)
        {
            InitializeComponent();

            this.nombreUsuario = nombreUsuario;
            this.rolUsuario = rolUsuario;

            timerReloj.Interval = 1000;
            timerReloj.Tick += TimerReloj_Tick;
            timerReloj.Start();
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuarioActivo.Text = $"{nombreUsuario}  ({rolUsuario})";

            lblRuta.Text = "Inicio";
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lblFecha.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");

            CargarEstadisticas();

           
            if (rolUsuario.Equals("Empleado", StringComparison.OrdinalIgnoreCase))
            {
              
                    btnEmpleados.Visible = false;
                    btnReportes.Visible = false;
                    BtnCompras.Visible = false; 
            

                if (pnlContenido.Controls.ContainsKey("panelClientesRegistrados"))
                {
                    pnlContenido.Controls["panelClientesRegistrados"].Visible = false;
                }

                if (pnlContenido.Controls.ContainsKey("panelEmpleadosActivos"))
                {
                    pnlContenido.Controls["panelEmpleadosActivos"].Visible = false;
                }

                if (pnlContenido.Controls.ContainsKey("panelReportesDisponibles"))
                {
                    pnlContenido.Controls["panelReportesDisponibles"].Visible = false;
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

            lblRuta.Text = "Inicio > " + formHijo.Text;

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
            lblRuta.Text = "Inicio";
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
                if (pnlContenido.Controls.ContainsKey("panelEmpleadosActivos"))
                {
                    pnlContenido.Controls["panelEmpleadosActivos"].Visible = false;
                }
                if (pnlContenido.Controls.ContainsKey("panelReportesDisponibles"))
                {
                    pnlContenido.Controls["panelReportesDisponibles"].Visible = false;
                }
            }
            lblRuta.Text = "Inicio";
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
                if (pnlContenido.Controls.ContainsKey("panelEmpleadosActivos"))
                {
                    pnlContenido.Controls["panelEmpleadosActivos"].Visible = false;
                }
                if (pnlContenido.Controls.ContainsKey("panelReportesDisponibles"))
                {
                    pnlContenido.Controls["panelReportesDisponibles"].Visible = false;
                }
            }
            lblRuta.Text = "Inicio";
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
                DashboardModel datos = dashboardDAL.ObtenerEstadisticas();

                // Actualizar tarjetas
                lblClientesRegistrados.Text = datos.TotalClientes.ToString("D2");
                lblCitas.Text = datos.CitasDelDia.ToString("D2");
                lblProductos.Text = datos.ProductosInventario.ToString("D2");
                lblCategorias.Text = datos.CategoriasActivas.ToString("D2");
                lblVentas.Text = datos.VentasDelDia.ToString("D2");
                lblEmpleados.Text = datos.EmpleadosActivos.ToString("D2");
                lblReportes.Text = datos.ReportesDisponibles.ToString("D2");
                lblIngresos.Text = datos.IngresosDelDia.ToString("C2");

                // Actualizar Grid de Stock Bajo
                CargarProductosStockBajo();
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("No se pudieron actualizar las estadísticas del panel. \n\n" + ex.Message);
            }
        }

        private void TimerDashboard_Tick(object sender, EventArgs e)
        {
            CargarEstadisticas();
        }

        private void TimerReloj_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lblFecha.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        }
        private void CargarProductosStockBajo()
        {
            try
            {
                DataTable dtStockBajo = dashboardDAL.ObtenerProductosStockBajo(10);
                dgvStockBajo.DataSource = dtStockBajo;
                EstilarDataGridView(dgvStockBajo);
                ResaltarFilasStock();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar stock bajo: " + ex.Message);
            }
        }
        private void EstilarDataGridView(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = System.Drawing.Color.FromArgb(235, 237, 240);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.RowTemplate.Height = 38;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 38;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgv.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            dgv.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(225, 238, 250); // Azul suave
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(20, 20, 20);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(225, 238, 250);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(20, 20, 20);
        }

        private void ResaltarFilasStock()
        {
            foreach (DataGridViewRow fila in dgvStockBajo.Rows)
            {
                if (fila.Cells["Stock"].Value != null && int.TryParse(fila.Cells["Stock"].Value.ToString(), out int stock))
                {
                    if (stock == 0)
                    {
                        // Agotado: Fondo rojo suave con texto rojo oscuro (Mismo tono de la tarjeta 'Clientes')
                        fila.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 225, 225);
                        fila.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(20, 20, 20);
                    }
                    else if (stock <= 3)
                    {
                        // Alerta Crítica (<= 3): Fondo amarillo/naranja suave (Mismo tono de la tarjeta 'Categorías')
                        fila.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 243, 205);
                        fila.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(133, 100, 4);
                    }
                }
            }
        }
    }
}