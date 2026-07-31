using BRAMSELU.Ventas;
using System;
using System.Data;
using System.Windows.Forms;

namespace BRAMSELU.Ventas
{
    public partial class frmReporteCompras : Form
    {
        private ReporteComprasBLL reporteBLL = new ReporteComprasBLL();

        public frmReporteCompras()
        {
            InitializeComponent();
        }

        private void frmReporteCompras_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpFechaFin.Value = DateTime.Now;

            dtpFechaInicio.Format = DateTimePickerFormat.Custom;
            dtpFechaInicio.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            dtpFechaFin.Format = DateTimePickerFormat.Custom;
            dtpFechaFin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = dtpFechaInicio.Value;
                DateTime fechaFin = dtpFechaFin.Value;

                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha fin.",
                                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dtResultado = reporteBLL.ObtenerReporteCompras(fechaInicio, fechaFin);
                dgvReporte.DataSource = dtResultado;

                if (dtResultado.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros en el rango de fechas seleccionado.",
                                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}