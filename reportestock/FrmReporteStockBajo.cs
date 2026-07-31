using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BRAMSELU.reportestock
{
    public partial class FrmReporteStockBajo : Form
    {
        private ReporteStockBLL objBLL = new ReporteStockBLL();

        public FrmReporteStockBajo()
        {
            InitializeComponent();
        }

        private void FrmReporteStockBajo_Load(object sender, EventArgs e)
        {
            txtStockLimite.Text = "5"; // O déjalo en blanco si prefieres que el usuario lo escriba
            CargarReporte();
        }

        private void CargarReporte()
        {
            try
            {
                if (!int.TryParse(txtStockLimite.Text, out int limite))
                {
                    MessageBox.Show("Por favor, ingrese un número válido para el límite de stock.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = objBLL.ObtenerProductosStockBajo(limite);
                dgvStockBajo.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte de stock bajo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }
    }
}