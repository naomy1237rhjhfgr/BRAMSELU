using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRAMSELU.Ventas
{
    public partial class FrmVentas : Form
    {
        private VentaBLL objBLL = new VentaBLL();
        private DataTable dtCarrito;

        public int idProductoSeleccionado;
        public string nombreProductoSeleccionado;
        public decimal precioSeleccionado;
        public int stockSeleccionado;

        public FrmVentas()
        {
            InitializeComponent();

            this.txtCantidad.KeyPress += new KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtEfectivo.KeyPress += new KeyPressEventHandler(this.txtEfectivo_KeyPress);
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            InicializarCarrito();
            txtCantidad.Text = "1";
        }

        private void InicializarCarrito()
        {
            dtCarrito = new DataTable();
            dtCarrito.Columns.Add("IdProducto", typeof(int));
            dtCarrito.Columns.Add("Producto", typeof(string));
            dtCarrito.Columns.Add("Cantidad", typeof(int));
            dtCarrito.Columns.Add("Precio", typeof(decimal));
            dtCarrito.Columns.Add("Subtotal", typeof(decimal));

            dgvCarrito.DataSource = dtCarrito;
        }

        private void btnSeleccionarProducto_Click(object sender, EventArgs e)
        {
            frmInventario inventarioForm = new frmInventario();
            inventarioForm.modoSeleccion = true;
            inventarioForm.ShowDialog();
        }

        public void CargarDatosProducto(int id, string nombre, decimal precio, int stock)
        {
            idProductoSeleccionado = id;
            nombreProductoSeleccionado = nombre;
            precioSeleccionado = precio;
            stockSeleccionado = stock;
            txtProducto.Text = nombre;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0 || string.IsNullOrWhiteSpace(txtProducto.Text))
            {
                MessageBox.Show("Por favor, seleccione un producto primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Por favor, ingrese una cantidad.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int cantidad = Convert.ToInt32(txtCantidad.Text);

                if (cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor a 0.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cantidad > stockSeleccionado)
                {
                    MessageBox.Show($"Stock insuficiente. Stock disponible: {stockSeleccionado}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal subtotal = cantidad * precioSeleccionado;
                dtCarrito.Rows.Add(idProductoSeleccionado, nombreProductoSeleccionado, cantidad, precioSeleccionado, subtotal);

                CalcularTotalGeneral();
                LimpiarCamposProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar producto al carrito: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCamposProducto()
        {
            txtCantidad.Text = "1";
            txtProducto.Clear();
            idProductoSeleccionado = 0;
            nombreProductoSeleccionado = string.Empty;
            precioSeleccionado = 0;
            stockSeleccionado = 0;
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

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtCarrito.Rows.Count == 0)
                {
                    MessageBox.Show("El carrito de compras está vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEfectivo.Text))
                {
                    MessageBox.Show("Ingrese el monto en efectivo entregado por el cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal totalGeneral = 0;
                foreach (DataRow row in dtCarrito.Rows)
                {
                    totalGeneral += Convert.ToDecimal(row["Subtotal"]);
                }

                decimal efectivoRecibido = Convert.ToDecimal(txtEfectivo.Text);

                if (efectivoRecibido < totalGeneral)
                {
                    MessageBox.Show("El efectivo entregado es menor al total de la compra.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal cambio = efectivoRecibido - totalGeneral;

                bool resultado = objBLL.RegistrarVentaFisica(dtCarrito, totalGeneral, efectivoRecibido, cambio);

                if (resultado)
                {
                    MessageBox.Show($"¡Venta realizada con éxito!\n\nTotal: L. {totalGeneral:N2}\nEfectivo: L. {efectivoRecibido:N2}\nCambio (Vuelto): L. {cambio:N2}",
                                    "Factura Física Generada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dtCarrito.Clear();
                    lblTotal.Text = "L. 0.00";
                    txtEfectivo.Clear();
                    LimpiarCamposProducto();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCantidad_TextChanged(object sender, EventArgs e) { }
        private void txtEfectivo_TextChanged(object sender, EventArgs e) { }
    }
}