using BRAMSELU.reportestock;
using BRAMSELU.Ventas;
using System;
using System.Windows.Forms;

namespace BRAMSELU
{
    public partial class frmReportes : Form
    {
        private Form formActivo = null;

        public frmReportes()
        {
            InitializeComponent();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {

        }

        private void AbrirFormularioEnPanel(Form formHijo)
        {
            if (formActivo != null)
            {
                formActivo.Close();
            }

            formActivo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;

            pnlContenedor.Controls.Add(formHijo);
            pnlContenedor.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmReporteCompras frmCompras = new frmReporteCompras();
            AbrirFormularioEnPanel(frmCompras);
        }

        private void btnventa_Click(object sender, EventArgs e)
        {
            FrmReporteVentas frmVentas = new FrmReporteVentas();
            AbrirFormularioEnPanel(frmVentas);
        }

        private void btnventa_Click_1(object sender, EventArgs e)
        {
            FrmReporteVentas frmVentas = new FrmReporteVentas();
            AbrirFormularioEnPanel(frmVentas);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmReporteCompras frmCompras = new frmReporteCompras();
            AbrirFormularioEnPanel(frmCompras);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmReporteStockBajo frmstock = new FrmReporteStockBajo();
            AbrirFormularioEnPanel(frmstock);
        }
    }
}