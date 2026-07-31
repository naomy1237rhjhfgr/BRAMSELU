using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BRAMSELU.Productos.BLL;
using BRAMSELU.Productos.Modelos;

namespace BRAMSELU.Productos.UI
{
    public partial class frmProductos : Form
    {
        private ProductoBLL bll = new ProductoBLL();
        private byte[] bytesImagen = null;

        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            CargarGrid();
            LimpiarFormulario();
        }

        private void CargarGrid()
        {
            try
            {
                dgvDatos.DataSource = bll.ListarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtIdProducto.Clear();
            txtNombre.Clear();
            txtMarca.Clear();
            CmbCa.SelectedIndex = -1;
            txtPrecio.Clear();
            txtStock.Clear();
            dtpFechaRegistro.Value = DateTime.Now;
            picImagen.Image = null;
            bytesImagen = null;
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto prod = new Producto();
                if (!string.IsNullOrEmpty(txtIdProducto.Text))
                {
                    prod.IdProducto = Convert.ToInt32(txtIdProducto.Text);
                }

                prod.NombreProducto = txtNombre.Text.Trim();
                prod.Marca = txtMarca.Text.Trim();
                prod.Categoria = CmbCa.Text;
                prod.Precio = Convert.ToDecimal(txtPrecio.Text);
                prod.Stock = Convert.ToInt32(txtStock.Text);
                prod.FechaRegistro = dtpFechaRegistro.Value;
                prod.Imagen = bytesImagen;
                prod.IdCategoria = CmbCa.SelectedIndex + 1;

                bool resultado = bll.Guardar(prod);
                if (resultado)
                {
                    MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picImagen.Image = Image.FromFile(openFileDialog.FileName);
                bytesImagen = File.ReadAllBytes(openFileDialog.FileName);
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvDatos.Rows[e.RowIndex];

                txtIdProducto.Text = fila.Cells["IdProducto"].Value.ToString();
                txtNombre.Text = fila.Cells["NombreProducto"].Value.ToString();
                txtMarca.Text = fila.Cells["Marca"].Value.ToString();
                CmbCa.Text = fila.Cells["Categoria"].Value.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
                txtStock.Text = fila.Cells["Stock"].Value.ToString();

                if (fila.Cells["FechaRegistro"].Value != DBNull.Value)
                    dtpFechaRegistro.Value = Convert.ToDateTime(fila.Cells["FechaRegistro"].Value);

                if (fila.Cells["Imagen"].Value != DBNull.Value && fila.Cells["Imagen"].Value is byte[])
                {
                    bytesImagen = (byte[])fila.Cells["Imagen"].Value;
                    using (MemoryStream ms = new MemoryStream(bytesImagen))
                    {
                        picImagen.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picImagen.Image = null;
                    bytesImagen = null;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdProducto.Text))
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(txtIdProducto.Text);
                    if (bll.EliminarProducto(id))
                    {
                        MessageBox.Show("Producto eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrid();
                        LimpiarFormulario();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (dgvDatos.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = $"NombreProducto LIKE '%{txtBuscar.Text}%' OR Marca LIKE '%{txtBuscar.Text}%'";
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmProductos
            // 
            this.ClientSize = new System.Drawing.Size(1160, 505);
            this.Name = "frmProductos";
            this.ResumeLayout(false);

        }
    }
}