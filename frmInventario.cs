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
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                dgvDatos.DataSource = inv.MostrarProductos();

             
                if (dgvDatos.Columns.Contains("IdProducto"))
                {
                    dgvDatos.Columns["IdProducto"].Visible = true;
                    dgvDatos.Columns["IdProducto"].HeaderText = "ID";
                    dgvDatos.Columns["IdProducto"].Width = 50;
                    dgvDatos.Columns["IdProducto"].DisplayIndex = 0;
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
                MessageBox.Show("Error al cargar datos:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow fila = dgvDatos.Rows[e.RowIndex];

                idSeleccionado = Convert.ToInt32(fila.Cells["IdProducto"].Value);
                txtNombre.Text = fila.Cells["NombreProducto"].Value?.ToString();
                txtMarca.Text = fila.Cells["Marca"].Value?.ToString();
                txtCategoria.Text = fila.Cells["Categoria"].Value?.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value?.ToString();
                txtStock.Text = fila.Cells["Stock"].Value?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar fila:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = inv.MostrarProductos();
                DataView dv = dt.DefaultView;

                string texto = txtBuscar.Text.Trim();

                if (string.IsNullOrEmpty(texto))
                {
                    dv.RowFilter = "";
                }
                else if (int.TryParse(texto, out int idBuscar))
                {
                   
                    dv.RowFilter = $"IdProducto = {idBuscar}";
                }
                else
                {
                   
                    dv.RowFilter = $"NombreProducto LIKE '%{texto}%'";
                }

                dgvDatos.DataSource = dv.ToTable();

                if (dgvDatos.Columns.Contains("IdProducto"))
                {
                    dgvDatos.Columns["IdProducto"].HeaderText = "ID";
                    dgvDatos.Columns["IdProducto"].Width = 50;
                    dgvDatos.Columns["IdProducto"].DisplayIndex = 0;
                }
            }
            catch { }
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
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                MessageBox.Show("El campo Marca es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMarca.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                MessageBox.Show("El campo Categoría es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoria.Focus(); return false;
            }
            if (!decimal.TryParse(txtPrecio.Text, out _))
            {
                MessageBox.Show("El Precio debe ser un número válido. Ej: 25.50",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus(); return false;
            }
            if (!int.TryParse(txtStock.Text, out _))
            {
                MessageBox.Show("El Stock debe ser un número entero. Ej: 100",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus(); return false;
            }
            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Primero selecciona un producto de la lista.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Modifica los campos y presiona Guardar.",
                "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNombre.Focus();
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
                        txtNombre.Text.Trim(),
                        txtMarca.Text.Trim(),
                        txtCategoria.Text.Trim(),
                        precio, stock);

                    MessageBox.Show("Producto registrado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    inv.EditarProducto(
                        idSeleccionado,
                        txtNombre.Text.Trim(),
                        txtMarca.Text.Trim(),
                        txtCategoria.Text.Trim(),
                        precio, stock);

                    MessageBox.Show("Producto actualizado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarDatos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Primero selecciona un producto de la lista.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"¿Eliminar el producto \"{txtNombre.Text}\" (ID: {idSeleccionado})?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                inv.EliminarProducto(idSeleccionado);
                MessageBox.Show("Producto eliminado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}