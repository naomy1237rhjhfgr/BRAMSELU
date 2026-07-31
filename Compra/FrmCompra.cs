using BRAMSELU.llamadoinventario.UI;
using BRAMSELU.Mensajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRAMSELU.Compra
{
    public partial class FrmCompra : Form
    {
        private CompraBLL objBLL = new CompraBLL();
        private DataTable dtCarrito;

        public int idProductoSeleccionado;
        public string nombreProductoSeleccionado;
        public decimal precioSeleccionado;

        public FrmCompra()
        {
            InitializeComponent();

            this.txtCantidad.KeyPress += new KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtPrecio.KeyPress += new KeyPressEventHandler(this.txtPrecio_KeyPress);
        }

        private void FrmCompra_Load(object sender, EventArgs e)
        {

      
        CargarComboProveedores();
            InicializarCarrito();
        }

        private void CargarComboProveedores()
        {
            try
            {
                DataTable dtProveedores = objBLL.ObtenerProveedores();

                if (dtProveedores != null && dtProveedores.Rows.Count > 0)
                {
                    cmbProveedor.DataSource = null;
                    cmbProveedor.Items.Clear();
                    cmbProveedor.DataSource = dtProveedores;
                    cmbProveedor.DisplayMember = "NombreEmpresa";
                    cmbProveedor.ValueMember = "IdProveedor";
                    cmbProveedor.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("No se encontraron proveedores registrados en la base de datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InicializarCarrito()
        {
            dtCarrito = new DataTable();
            dtCarrito.Columns.Add("IdProducto", typeof(int));
            dtCarrito.Columns.Add("Producto", typeof(string));
            dtCarrito.Columns.Add("Cantidad", typeof(int));
            dtCarrito.Columns.Add("PrecioUnitario", typeof(decimal));
            dtCarrito.Columns.Add("Subtotal", typeof(decimal));

            dgvCarrito.DataSource = dtCarrito;
        }

        private void btnSeleccionarProducto_Click(object sender, EventArgs e)
        {
            frmllamado llamadoForm = new frmllamado();

           
            if (llamadoForm.ShowDialog() == DialogResult.OK || llamadoForm.ProductoIdSeleccionado > 0)
            {
               
                int id = llamadoForm.ProductoIdSeleccionado;
                string nombre = llamadoForm.NombreSeleccionado;
                decimal precio = llamadoForm.PrecioSeleccionado;

               
                CargarDatosProducto(id, nombre, precio);
            }
        }

        private void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0 || string.IsNullOrWhiteSpace(txtProducto.Text))
            {
                MessageBox.Show("Por favor, seleccione un producto primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                GestorMensajes.Advertencia("Por favor completa la cantidad y el precio");
                return;
            }

            int cantidad = Convert.ToInt32(txtCantidad.Text);
            decimal precio = Convert.ToDecimal(txtPrecio.Text);
            decimal subtotal = cantidad * precio;

            dtCarrito.Rows.Add(idProductoSeleccionado, nombreProductoSeleccionado, cantidad, precio, subtotal);

            CalcularTotalGeneral();
            LimpiarCampos();
        }

        private void CalcularTotalGeneral()
        {
            decimal total = 0;
            foreach (DataRow row in dtCarrito.Rows)
            {
                total += Convert.ToDecimal(row["Subtotal"]);
            }
            lblTotalGrl.Text = "L. " + total.ToString("N2");
        }

        private void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProveedor.SelectedValue == null)
                {
                    GestorMensajes.Advertencia("Por favor seleccione un proveedor");
                    return;
                }

                if (dtCarrito.Rows.Count == 0)
                {
                    MessageBox.Show("El carrito está vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idProveedor = Convert.ToInt32(cmbProveedor.SelectedValue);
                decimal totalGeneral = 0;
                foreach (DataRow row in dtCarrito.Rows)
                {
                    totalGeneral += Convert.ToDecimal(row["Subtotal"]);
                }

                string nombreEmpleado = "UsuarioLogueado";

                bool respuesta = objBLL.InsertarCompra(dtCarrito, totalGeneral, idProveedor, nombreEmpleado);

                if (respuesta)
                {
                    GestorMensajes.Exito("¡Compra registrada correctamente!");
                    dtCarrito.Clear();
                    lblTotalGrl.Text = "L. 0.00";
                    idProductoSeleccionado = 0;
                    nombreProductoSeleccionado = string.Empty;
                    cmbProveedor.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la compra en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al finalizar la compra: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtCantidad.Text = "1";
            txtPrecio.Clear();
            txtProducto.Clear();
            idProductoSeleccionado = 0;
            nombreProductoSeleccionado = string.Empty;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && txt.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        public void CargarDatosProducto(int id, string nombre, decimal precio)
        {
            idProductoSeleccionado = id;
            nombreProductoSeleccionado = nombre;
            txtProducto.Text = nombre;
            txtPrecio.Text = precio.ToString("0.00");
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e) { }

        private void txtCantidad_TextChanged(object sender, EventArgs e) { }

        private void txtProducto_TextChanged(object sender, EventArgs e) { }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e) { }

       
    }
}