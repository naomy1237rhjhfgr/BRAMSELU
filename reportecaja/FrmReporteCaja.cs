using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRAMSELU.Mensajes;

namespace BRAMSELU.reportecaja
{
    public partial class FrmReporteCaja : Form
    {
        private ReporteCajaBLL objBLL = new ReporteCajaBLL();

        public FrmReporteCaja()
        {
            InitializeComponent();
        }

        private void FrmReporteCaja_Load(object sender, EventArgs e)
        {
            
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;
            CargarReporte();
        }

        private void CargarReporte()
        {
            try
            {
                DateTime inicio = dtpFechaInicio.Value;
                DateTime fin = dtpFechaFin.Value;

                DataTable dt = objBLL.ObtenerArqueoCajaPorFecha(inicio, fin);
                dgvReporteCaja.DataSource = dt;
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al cargar el reporte de caja: " + ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }
    }
}