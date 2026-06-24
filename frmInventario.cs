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
            BloquearCampos(true);
        }

        private void CargarDatos()
        {
            dgvDatos.DataSource = inv.MostrarProductos();
        }

        private void BloquearCampos(bool bloquear)
        {
            bool h = !bloquear;

            txtNombre.Enabled = h;
            txtMarca.Enabled = h;
            txtCategoria.Enabled = h;
            txtPrecio.Enabled = h;
            txtStock.Enabled = h;
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtMarca.Clear();
            txtCategoria.Clear();
            txtPrecio.Clear();
            txtStock.Clear();

            idSeleccionado = 0;
        }

        private bool ValidarCampos()
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre");
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

            if (txtPrecio.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el precio");
                txtPrecio.Focus();
                return false;
            }

            if (txtStock.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el stock");
                txtStock.Focus();
                return false;
            }

            return true;
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

            BloquearCampos(true);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            BloquearCampos(false);
            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            BloquearCampos(false);
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                decimal precio = Convert.ToDecimal(txtPrecio.Text);
                int stock = Convert.ToInt32(txtStock.Text);

                if (idSeleccionado == 0)
                {
                    inv.InsertarProducto(
                        txtNombre.Text,
                        txtMarca.Text,
                        txtCategoria.Text,
                        precio,
                        stock);

                    MessageBox.Show("Producto guardado");
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

                    MessageBox.Show("Producto actualizado");
                }

                CargarDatos();
                Limpiar();
                BloquearCampos(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                try
                {
                    inv.EliminarProducto(idSeleccionado);

                    MessageBox.Show("Producto eliminado");

                    CargarDatos();
                    Limpiar();
                    BloquearCampos(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() == "")
            {
                CargarDatos();
                return;
            }

            int id;

            if (int.TryParse(txtBuscar.Text, out id))
            {
                DataTable dt = inv.BuscarPorId(id);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontró el producto");
                    return;
                }

                dgvDatos.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido");
            }
        }

        

        
    }
}