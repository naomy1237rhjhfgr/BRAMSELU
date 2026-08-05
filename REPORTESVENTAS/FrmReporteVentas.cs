using BRAMSELU.Mensajes;
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

                if (dgvReporte.Columns.Contains("Total"))
                {
                    dgvReporte.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvReporte.Columns["Total"].DefaultCellStyle.Format = "N2";
                }

                if (dgvReporte.Columns.Contains("EfectivoRecibido"))
                {
                    dgvReporte.Columns["EfectivoRecibido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvReporte.Columns["EfectivoRecibido"].DefaultCellStyle.Format = "N2";
                }

                if (dgvReporte.Columns.Contains("Cambio"))
                {
                    dgvReporte.Columns["Cambio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvReporte.Columns["Cambio"].DefaultCellStyle.Format = "N2";
                }

                if (dt.Rows.Count == 0)
                {
                    GestorMensajes.Exito("No se encontraron ventas en el rango de fechas seleccionado.");
                }
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al generar el reporte: " + ex.Message);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}