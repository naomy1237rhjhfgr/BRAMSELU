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

        public FrmCompra()
        {
            InitializeComponent();

           
            this.txtCantidad.KeyPress += new KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtPrecio.KeyPress += new KeyPressEventHandler(this.txtPrecio_KeyPress);
        }

        private void FrmCompra_Load(object sender, EventArgs e)
        {
            CargarComboProveedores();
            CargarComboProductos();
            InicializarCarrito();
        }

        private void CargarComboProveedores()
        {
            try
            {
                cmbProveedores.DataSource = objBLL.ObtenerProveedores();
                cmbProveedores.DisplayMember = "NombreEmpresa";
                cmbProveedores.ValueMember = "IdProveedor";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message);
            }
        }

        private void CargarComboProductos()
        {
            try
            {
                cmbProductos.DataSource = objBLL.ObtenerProductos();
                cmbProductos.DisplayMember = "Nombre";
                cmbProductos.ValueMember = "IdProducto";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
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

            dgvDetalle.DataSource = dtCarrito;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Por favor, complete la cantidad y el precio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProducto = Convert.ToInt32(cmbProductos.SelectedValue);
            string nombreProducto = cmbProductos.Text;
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            decimal precio = Convert.ToDecimal(txtPrecio.Text);
            decimal subtotal = cantidad * precio;

            dtCarrito.Rows.Add(idProducto, nombreProducto, cantidad, precio, subtotal);

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
            lblTotal.Text = "L. " + total.ToString("N2");
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProveedores.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, seleccione un proveedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idProveedor = Convert.ToInt32(cmbProveedores.SelectedValue);
                decimal totalGeneral = 0;
                foreach (DataRow row in dtCarrito.Rows)
                {
                    totalGeneral += Convert.ToDecimal(row["Subtotal"]);
                }

                bool respuesta = objBLL.InsertarCompra(dtCarrito, totalGeneral, idProveedor);

                if (respuesta)
                {
                    MessageBox.Show("¡Compra registrada correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtCarrito.Clear();
                    lblTotal.Text = "L. 0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al finalizar la compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtCantidad.Clear();
            txtPrecio.Clear();
            cmbProductos.Focus();
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
    }
}