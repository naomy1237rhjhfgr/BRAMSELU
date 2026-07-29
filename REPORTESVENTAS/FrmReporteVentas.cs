using System;
using System.Data;
using System.Windows.Forms;

namespace BRAMSELU.Ventas
{
    public partial class FrmReporteVentas : Form
    {
        private ReporteVentasBLL objBLL = new ReporteVentasBLL();

        public FrmReporteVentas()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = dtpInicio.Value.Date;
                DateTime fechaFin = dtpFin.Value.Date.AddDays(1).AddSeconds(-1);

                DataTable dt = objBLL.ObtenerReporteVentas(fechaInicio, fechaFin);
                dgvReporte.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron ventas en el rango de fechas seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}