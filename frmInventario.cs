using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BRAMSELU.Entidades;
using BRAMSELU.BLL;
using BRAMSELU.ClasesProducto;

namespace BRAMSELU
{
    public partial class frmInventario : Form
    {
        private InventarioBLL inventarioBLL;
        private ImagenProducto imgHelper;

        private int idSeleccionado = 0;
        private byte[] imagenSeleccionada = null;

        public frmInventario()
        {
            InitializeComponent();

            inventarioBLL = new InventarioBLL();
            imgHelper = new ImagenProducto();
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            CargarDatos();
            BloquearCampos(true);
        }

        private void CargarDatos()
        {
            dgvDatos.DataSource = null;
            dgvDatos.DataSource =
                inventarioBLL.ObtenerProductos();

            OcultarImagen();
        }

        private void OcultarImagen()
        {
            if (dgvDatos.Columns.Contains("Imagen"))
                dgvDatos.Columns["Imagen"].Visible = false;
        }

        private void BloquearCampos(bool bloquear)
        {
            bool h = !bloquear;

            txtNombre.Enabled = h;
            txtMarca.Enabled = h;
            CmbCa.Enabled = h;
            txtPrecio.Enabled = h;
            txtStock.Enabled = h;
            btnCargarImagen.Enabled = h;
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtMarca.Clear();
            CmbCa.SelectedIndex = -1;
            txtPrecio.Clear();
            txtStock.Clear();

            picImagen.Image = null;
            imagenSeleccionada = null;

            idSeleccionado = 0;
        }

        private bool Validar()
        {
            errorProvider1.Clear();
            bool valido = true;

            if (txtNombre.Text.Trim() == "")
            {
                errorProvider1.SetError(txtNombre, "Ingrese el nombre del producto");
                valido = false;
            }
            else if (!SoloLetras(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "El nombre solo debe contener letras");
                valido = false;
            }

            if (txtMarca.Text.Trim() == "")
            {
                errorProvider1.SetError(txtMarca, "Ingrese la marca");
                valido = false;
            }

            if (CmbCa.SelectedIndex == -1)
            {
                errorProvider1.SetError(CmbCa, "Seleccione una categoría");
                valido = false;
            }

            decimal precio;

            if (!decimal.TryParse(txtPrecio.Text, out precio) || precio <= 0)
            {
                errorProvider1.SetError(txtPrecio, "Ingrese un precio válido mayor a 0");
                valido = false;
            }

            int stock;

            if (!int.TryParse(txtStock.Text, out stock) || stock < 0)
            {
                errorProvider1.SetError(txtStock, "Ingrese una cantidad válida");
                valido = false;
            }

            if (imagenSeleccionada == null)
            {
                errorProvider1.SetError(picImagen, "Seleccione una imagen");
                valido = false;
            }

            return valido;
        }

        private bool SoloLetras(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }

            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            BloquearCampos(false);
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            Inventario inv = new Inventario
            {
                IdProducto = idSeleccionado,
                NombreProducto = txtNombre.Text,
                Marca = txtMarca.Text,
                Categoria = CmbCa.Text,
                Precio = Convert.ToDecimal(txtPrecio.Text),
                Stock = Convert.ToInt32(txtStock.Text),
                Imagen = imagenSeleccionada
            };

            if (idSeleccionado == 0)
            {
                if (inventarioBLL.GuardarProducto(inv))
                    MessageBox.Show("Producto guardado");
            }
            else
            {
                if (inventarioBLL.ActualizarProducto(inv))
                    MessageBox.Show("Producto actualizado");
            }

            CargarDatos();
            Limpiar();
            BloquearCampos(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
                return;

            if (txtNombre.Enabled == false)
            {
                BloquearCampos(false);
                btnEditar.Text = "Actualizar";
            }
            else
            {
                btnGuardar_Click(sender, e);
                btnEditar.Text = "Editar";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado != 0 &&
                inventarioBLL.EliminarProducto(idSeleccionado))
            {
                MessageBox.Show("Producto eliminado");

                CargarDatos();
                Limpiar();
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            dgvDatos.DataSource =
                inventarioBLL.BuscarProducto(txtBuscar.Text);

            OcultarImagen();
        }

        private void dgvDatos_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila =
                dgvDatos.Rows[e.RowIndex];

            idSeleccionado =
                Convert.ToInt32(fila.Cells[0].Value);

            txtNombre.Text =
                fila.Cells[1].Value.ToString();

            txtMarca.Text =
                fila.Cells[2].Value.ToString();

            CmbCa.Text =
                fila.Cells[3].Value.ToString();

            txtPrecio.Text =
                fila.Cells[4].Value.ToString();

            txtStock.Text =
                fila.Cells[5].Value.ToString();

            Inventario inv =
                (Inventario)fila.DataBoundItem;

            imagenSeleccionada = inv.Imagen;

            if (imagenSeleccionada != null)
                picImagen.Image =
                    imgHelper.BytesAImagen(imagenSeleccionada);
            else
                picImagen.Image = null;

            BloquearCampos(true);
            btnEditar.Text = "Editar";
        }

        private void btnCargarImagen_Click(
            object sender,
            EventArgs e)
        {
            using (OpenFileDialog ofd =
                   new OpenFileDialog())
            {
                ofd.Filter =
                    "Imágenes (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (Image imagenOriginal =
                           Image.FromFile(ofd.FileName))
                    {
                        Image copia =
                            new Bitmap(imagenOriginal);

                        picImagen.Image = copia;

                        imagenSeleccionada =
                            imgHelper.ImagenABytes(copia);
                    }
                }
            }
        }

        private void txtPrecio_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == '.' &&
                !txtPrecio.Text.Contains("."))
                return;

            e.Handled = true;
        }

        private void txtStock_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            e.Handled = true;
        }
    }
}