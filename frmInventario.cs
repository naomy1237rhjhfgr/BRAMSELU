using System;
using System.Data;
using System.Windows.Forms;

namespace BRAMSELU
{
    public partial class frmInventario : Form
    {
        Inventario inv = new Inventario();
        int idSeleccionado = 0;

        public frmInventario()
        {
            InitializeComponent();
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            dgvDatos.AutoGenerateColumns = true;
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                dgvDatos.DataSource = null;
                dgvDatos.AutoGenerateColumns = true;
                dgvDatos.DataSource = inv.MostrarProductos();

                if (dgvDatos.Columns.Contains("IdProducto"))
                {
                    dgvDatos.Columns["IdProducto"].HeaderText = "ID";
                    dgvDatos.Columns["IdProducto"].Width = 60;
                }

                if (dgvDatos.Columns.Contains("NombreProducto"))
                    dgvDatos.Columns["NombreProducto"].HeaderText = "Producto";

                if (dgvDatos.Columns.Contains("Marca"))
                    dgvDatos.Columns["Marca"].HeaderText = "Marca";

                if (dgvDatos.Columns.Contains("Categoria"))
                    dgvDatos.Columns["Categoria"].HeaderText = "Categoría";

                if (dgvDatos.Columns.Contains("Precio"))
                    dgvDatos.Columns["Precio"].HeaderText = "Precio";

                if (dgvDatos.Columns.Contains("Stock"))
                    dgvDatos.Columns["Stock"].HeaderText = "Stock";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvDatos.Rows[e.RowIndex];

            idSeleccionado = Convert.ToInt32(fila.Cells["IdProducto"].Value);

            txtNombre.Text = fila.Cells["NombreProducto"].Value.ToString();
            txtMarca.Text = fila.Cells["Marca"].Value.ToString();
            txtCategoria.Text = fila.Cells["Categoria"].Value.ToString();
            txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
            txtStock.Text = fila.Cells["Stock"].Value.ToString();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvDatos.DataSource = inv.BuscarProducto(txtBuscar.Text.Trim());
            }
            catch
            {
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtMarca.Clear();
            txtCategoria.Clear();
            txtPrecio.Clear();
            txtStock.Clear();

            idSeleccionado = 0;

            txtNombre.Focus();
        }

        private bool ValidarCampos()
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre del producto");
                txtNombre.Focus();
                return false;
            }

            if (txtMarca.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la marca");
                txtMarca.Focus();
                return false;
            }

            if (txtCategoria.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la categoría");
                txtCategoria.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrecio.Text, out _))
            {
                MessageBox.Show("Ingrese un precio válido");
                txtPrecio.Focus();
                return false;
            }

            if (!int.TryParse(txtStock.Text, out _))
            {
                MessageBox.Show("Ingrese un stock válido");
                txtStock.Focus();
                return false;
            }

            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                decimal precio = decimal.Parse(txtPrecio.Text);
                int stock = int.Parse(txtStock.Text);

                if (idSeleccionado == 0)
                {
                    inv.InsertarProducto(
                        txtNombre.Text,
                        txtMarca.Text,
                        txtCategoria.Text,
                        precio,
                        stock);

                    MessageBox.Show("Producto guardado correctamente");
                }
                else
                {
                    inv.EditarProducto(
                        idSeleccionado,
                        txtNombre.Text,
                        txtMarca.Text,
                        txtCategoria.Text,
                        precio,
                        stock);

                    MessageBox.Show("Producto actualizado correctamente");
                }

                CargarDatos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            txtNombre.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Desea eliminar este producto?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                inv.EliminarProducto(idSeleccionado);

                MessageBox.Show("Producto eliminado correctamente");

                CargarDatos();
                LimpiarCampos();
            }
        }
    }
}