using BRAMSELU;
using System;
using System.Data;
using System.Data.SqlClient;
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
            dgvDatos.DataSource = inv.MostrarProductos();

            if (dgvDatos.Columns.Contains("IdProducto"))
                dgvDatos.Columns["IdProducto"].HeaderText = "ID";

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

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvDatos.Rows[e.RowIndex];

                idSeleccionado = Convert.ToInt32(fila.Cells["IdProducto"].Value);

                txtNombre.Text = fila.Cells["NombreProducto"].Value.ToString();
                txtMarca.Text = fila.Cells["Marca"].Value.ToString();
                txtCategoria.Text = fila.Cells["Categoria"].Value.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
                txtStock.Text = fila.Cells["Stock"].Value.ToString();
            }
        }

        private bool ValidarCampos()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingrese el nombre");
                txtNombre.Focus();
                return false;
            }

            if (txtMarca.Text == "")
            {
                MessageBox.Show("Ingrese la marca");
                txtMarca.Focus();
                return false;
            }

            if (txtCategoria.Text == "")
            {
                MessageBox.Show("Ingrese la categoría");
                txtCategoria.Focus();
                return false;
            }

            if (txtPrecio.Text == "")
            {
                MessageBox.Show("Ingrese el precio");
                txtPrecio.Focus();
                return false;
            }

            if (txtStock.Text == "")
            {
                MessageBox.Show("Ingrese el stock");
                txtStock.Focus();
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

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

            txtNombre.Text = "";
            txtMarca.Text = "";
            txtCategoria.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";

            idSeleccionado = 0;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto");
                return;
            }

            MessageBox.Show("Modifique los datos y luego presione Guardar");
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

                MessageBox.Show("Producto eliminado");

                CargarDatos();

                txtNombre.Text = "";
                txtMarca.Text = "";
                txtCategoria.Text = "";
                txtPrecio.Text = "";
                txtStock.Text = "";

                idSeleccionado = 0;
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {

      
            if (txtBuscar.Text == "")
            {
                CargarDatos();
                return;
            }

            int id;

            if (int.TryParse(txtBuscar.Text, out id))
            {
                dgvDatos.DataSource = inv.BuscarPorId(id);
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido");
            }
        }

       
    }
}
