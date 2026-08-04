using System;
using System.Data;
using System.Windows.Forms;

namespace BRAMSELU.reporteproductos
{
    public partial class FrmReporteProductosVendidos : Form
    {
        private ReporteProductosVendidosBLL objBLL = new ReporteProductosVendidosBLL();

        public FrmReporteProductosVendidos()
        {
            InitializeComponent();
        }

        private void FrmReporteProductosVendidos_Load(object sender, EventArgs e)
        {
            // Valor predeterminado para el Top
            txtTop.Text = "10";
            CargarReporte();
        }

        private void CargarReporte()
        {
            try
            {
                if (!int.TryParse(txtTop.Text, out int top))
                {
                    MessageBox.Show("Por favor, ingrese un número válido para el ranking.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = objBLL.ObtenerProductosMasVendidos(top);
                dgvProductos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte de productos más vendidos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }
    }
}