using BRAMSELU.Mensajes;
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
                    GestorMensajes.Advertencia("Por favor, ingrese un número válido para el límite de stock.");
                    return;
                }

                DataTable dt = objBLL.ObtenerProductosStockBajo(limite);
                dgvStockBajo.DataSource = dt;

                if (dgvStockBajo.Columns.Contains("Precio"))
                {
                    dgvStockBajo.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvStockBajo.Columns["Precio"].DefaultCellStyle.Format = "N2";
                }
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al cargar el reporte de stock bajo: " + ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}