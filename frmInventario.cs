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
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = inv.Mostrar();
        }

        private void MostrarEnGrid(DataTable dt)
        {
            dgvDatos.DataSource = dt;

            if (dgvDatos.Columns.Contains("Imagen"))
            {
                dgvDatos.Columns["Imagen"].Visible = false;
            }

            if (dgvDatos.Columns.Contains("FechaRegistro"))
            {
                dgvDatos.Columns["FechaRegistro"].Visible = false;
            }
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

            btnCargarImagen.Enabled = h;
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

            decimal precioValidado;
            if (!decimal.TryParse(txtPrecio.Text.Trim(), out precioValidado) || precioValidado <= 0)
            {
                MessageBox.Show("Ingrese un precio válido, mayor a 0");
                txtPrecio.Focus();
                return false;
            }

            if (txtStock.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el stock");
                txtStock.Focus();
                return false;
            }

            int stockValidado;
            if (!int.TryParse(txtStock.Text.Trim(), out stockValidado) || stockValidado < 0)
            {
                MessageBox.Show("Ingrese un stock válido (0 o mayor)");
                txtStock.Focus();
                return false;
            }

            if (imagenSeleccionada == null)
            {
                MessageBox.Show("Debe cargar una imagen del producto");
                btnCargarImagen.Focus();
                return false;
            }

            return true;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == '.' && !txtPrecio.Text.Contains("."))
                return;

            e.Handled = true;
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            e.Handled = true;
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
            btnEditar.Text = "Editar";
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
                MessageBox.Show("Por favor, seleccione un producto de la lista primero.");
                return;
            }

            if (txtNombre.Enabled == false)
            {
                BloquearCampos(false);
                txtNombre.Focus();
                btnEditar.Text = "Actualizar";
            }
            else
            {
                if (!ValidarCampos())
                    return;

                inv.IdProducto = idSeleccionado;
                inv.NombreProducto = txtNombre.Text;
                inv.Marca = txtMarca.Text;
                inv.Categoria = txtCategoria.Text;
                inv.Precio = Convert.ToDecimal(txtPrecio.Text);
                inv.Stock = Convert.ToInt32(txtStock.Text);
                inv.Imagen = imagenSeleccionada;

                if (inv.Actualizar())
                {
                    MessageBox.Show("Producto modificado con éxito");
                    CargarDatos();
                    Limpiar();
                    BloquearCampos(true);
                    btnEditar.Text = "Editar";
                }
            }
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
                inv.IdProducto = idSeleccionado;
                inv.NombreProducto = txtNombre.Text;
                inv.Marca = txtMarca.Text;
                inv.Categoria = txtCategoria.Text;
                inv.Precio = Convert.ToDecimal(txtPrecio.Text);
                inv.Stock = Convert.ToInt32(txtStock.Text);
                inv.Imagen = imagenSeleccionada;

                if (idSeleccionado == 0)
                {
                    if (inv.Guardar())
                        MessageBox.Show("Producto guardado");
                }
                else
                {
                    if (inv.Actualizar())
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
                    inv.IdProducto = idSeleccionado;

                    if (inv.Eliminar())
                    {
                        MessageBox.Show("Producto eliminado");
                        CargarDatos();
                        Limpiar();
                        BloquearCampos(true);
                    }
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
                if (inv.BuscarPorId(id))
                {
                    txtNombre.Text = inv.NombreProducto;
                    txtMarca.Text = inv.Marca;
                    txtCategoria.Text = inv.Categoria;
                    txtPrecio.Text = inv.Precio.ToString();
                    txtStock.Text = inv.Stock.ToString();

                    imagenSeleccionada = inv.Imagen;

                    if (imagenSeleccionada != null)
                        picImagen.Image = imgHelper.BytesAImagen(imagenSeleccionada);
                    else
                        picImagen.Image = null;

                    idSeleccionado = inv.IdProducto;
                }
                else
                {
                    MessageBox.Show("No se encontró el producto");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido");
            }
        }
    }
}