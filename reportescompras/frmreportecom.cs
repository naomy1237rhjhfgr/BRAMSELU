using System;
using System.Data;
using System.Windows.Forms;
using BRAMSELU.Ventas;

namespace BRAMSELU.reportescompras
{
    public partial class frmreportecom : Form
    {
        private ReporteComprasBLL objBLL = new ReporteComprasBLL();

        public frmreportecom()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = dtpInicio.Value.Date;
                DateTime fechaFin = dtpFin.Value.Date.AddDays(1).AddSeconds(-1);

                DataTable dt = objBLL.ObtenerReporteCompras(fechaInicio, fechaFin);
                dgvReporte.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron compras en el rango de fechas seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte de compras: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}