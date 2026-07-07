using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BRAMSELU.ClasesProducto;

namespace BRAMSELU
{
    public partial class frmInventario : Form
    {
        Inventario inv = new Inventario();
        ImagenProducto imgHelper = new ImagenProducto();

        int idSeleccionado = 0;
        byte[] imagenSeleccionada = null;

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
            MostrarEnGrid(inv.MostrarProductos());
        }

       
        private void MostrarEnGrid(DataTable dt)
        {
            dgvDatos.RowTemplate.Height = 60;
            dgvDatos.DataSource = dt;

            if (dgvDatos.Columns.Contains("Imagen"))
            {
                int index = dgvDatos.Columns["Imagen"].Index;
                dgvDatos.Columns.Remove("Imagen");

                DataGridViewImageColumn colImagen = new DataGridViewImageColumn();
                colImagen.Name = "Imagen";
                colImagen.DataPropertyName = "Imagen";
                colImagen.HeaderText = "Imagen";
                colImagen.ImageLayout = DataGridViewImageCellLayout.Zoom;
                colImagen.Width = 90;

                dgvDatos.Columns.Insert(index, colImagen);
            }

           
            if (dgvDatos.Columns.Contains("FechaRegistro"))
                dgvDatos.Columns["FechaRegistro"].Visible = false;
        }

        
        private void dgvDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDatos.Columns[e.ColumnIndex].Name != "Imagen")
                return;

            if (e.Value == null || e.Value == DBNull.Value)
                return;

            byte[] datos = e.Value as byte[];

            if (datos != null && datos.Length > 0)
            {
                e.Value = imgHelper.BytesAImagen(datos);
                e.FormattingApplied = true;
            }
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

            picImagen.Image = null;
            imagenSeleccionada = null;

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

            object valorImagen = fila.Cells["Imagen"].Value;

            if (valorImagen != null && valorImagen != DBNull.Value)
            {
                imagenSeleccionada = (byte[])valorImagen;
                picImagen.Image = imgHelper.BytesAImagen(imagenSeleccionada);
            }
            else
            {
                imagenSeleccionada = null;
                picImagen.Image = null;
            }

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

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title = "Seleccione una imagen del producto";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (Image imagenOriginal = Image.FromFile(ofd.FileName))
                        {
                            // Se clona para no dejar el archivo bloqueado en disco
                            Image copia = new Bitmap(imagenOriginal);

                            picImagen.Image = copia;
                            imagenSeleccionada = imgHelper.ImagenABytes(copia);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo cargar la imagen: " + ex.Message);
                    }
                }
            }
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
                        stock,
                        imagenSeleccionada);

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
                        stock,
                        imagenSeleccionada);

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

                MostrarEnGrid(dt);
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido");
            }
        }
    }
}