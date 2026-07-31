using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BRAMSELU.llamadoinventario.BLL;

namespace BRAMSELU.llamadoinventario.UI
{
    public partial class frmllamado : Form
    {
        private llamadoinventarioBLL bll = new llamadoinventarioBLL();

        public int ProductoIdSeleccionado { get; private set; }
        public string NombreSeleccionado { get; private set; }
        public decimal PrecioSeleccionado { get; private set; }
        public int StockSeleccionado { get; private set; }

        public frmllamado()
        {
            InitializeComponent();
        }

        private void frmllamado_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarGrid();
        }

        private void ConfigurarGrid()
        {
            dgvDatos.EnableHeadersVisualStyles = false;

            dgvDatos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvDatos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDatos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvDatos.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvDatos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvDatos.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvDatos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            dgvDatos.RowTemplate.Height = 30;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.MultiSelect = false;
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersVisible = false;
        }

        private void CargarGrid()
        {
            try
            {
                dgvDatos.DataSource = bll.Listar();

                if (dgvDatos.Columns.Contains("IdProducto"))
                    dgvDatos.Columns["IdProducto"].HeaderText = "Código";

                if (dgvDatos.Columns.Contains("NombreProducto"))
                    dgvDatos.Columns["NombreProducto"].HeaderText = "Producto";

                if (dgvDatos.Columns.Contains("Marca"))
                    dgvDatos.Columns["Marca"].HeaderText = "Marca";

                if (dgvDatos.Columns.Contains("Categoria"))
                    dgvDatos.Columns["Categoria"].HeaderText = "Categoría";

                if (dgvDatos.Columns.Contains("Precio"))
                {
                    dgvDatos.Columns["Precio"].HeaderText = "Precio";
                    dgvDatos.Columns["Precio"].DefaultCellStyle.Format = "C2";
                }

                if (dgvDatos.Columns.Contains("Stock"))
                    dgvDatos.Columns["Stock"].HeaderText = "Existencias";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los productos.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatos.DataSource is DataTable dt)
                {
                    string texto = txtBuscar.Text.Trim().Replace("'", "''");

                    dt.DefaultView.RowFilter =
                        $"Convert(IdProducto,'System.String') LIKE '%{texto}%' " +
                        $"OR NombreProducto LIKE '%{texto}%' " +
                        $"OR Marca LIKE '%{texto}%'";
                }
            }
            catch
            {
               
            }
        }

        private void btnAgregarACompra_Click(object sender, EventArgs e)
        {
           
            if (dgvDatos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ProductoIdSeleccionado = Convert.ToInt32(dgvDatos.CurrentRow.Cells["IdProducto"].Value);
            NombreSeleccionado = dgvDatos.CurrentRow.Cells["NombreProducto"].Value.ToString();
            PrecioSeleccionado = Convert.ToDecimal(dgvDatos.CurrentRow.Cells["Precio"].Value);
            StockSeleccionado = Convert.ToInt32(dgvDatos.CurrentRow.Cells["Stock"].Value);

            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

        private Form formularioActivo = null;

        private void AbrirFormEnPanel(Form formulario)
        {
            if (formularioActivo != null)
                formularioActivo.Close();

            formularioActivo = formulario;

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(formulario);
            panel1.Tag = formulario;

            formulario.BringToFront();
            formulario.Show();
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnAgregarACompra.PerformClick();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}