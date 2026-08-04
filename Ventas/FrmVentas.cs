using BRAMSELU.clientellamado;
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

        public string dniClienteSeleccionado = string.Empty;

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
            txtDniCliente.ReadOnly = true;
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
            frmllamado llamadoForm = new frmllamado();

            if (llamadoForm.ShowDialog() == DialogResult.OK && llamadoForm.ProductoSeleccionado != null)
            {
                int id = llamadoForm.ProductoSeleccionado.IdProducto;
                string nombre = llamadoForm.ProductoSeleccionado.NombreProducto;
                decimal precio = llamadoForm.ProductoSeleccionado.Precio;
                int stockDisponible = llamadoForm.ProductoSeleccionado.Stock;

                CargarDatosProducto(id, nombre, precio, stockDisponible);
            }
        }

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            Frmclientellamado clienteForm = new Frmclientellamado();

            if (clienteForm.ShowDialog() == DialogResult.OK)
            {
                dniClienteSeleccionado = clienteForm.IdClienteSeleccionado;
                txtDniCliente.Text = dniClienteSeleccionado;

                btnSeleccionarCliente.Enabled = false;
            }
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
            if (string.IsNullOrWhiteSpace(txtDniCliente.Text))
            {
                GestorMensajes.Advertencia("Por favor, seleccione un cliente antes de agregar productos al carrito.");
                return;
            }

            if (idProductoSeleccionado == 0 || string.IsNullOrWhiteSpace(txtProducto.Text))
            {
                GestorMensajes.Advertencia("Por favor, seleccione un producto primero.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                GestorMensajes.Advertencia("Por favor, ingrese una cantidad.");
                return;
            }

            try
            {
                int cantidad = Convert.ToInt32(txtCantidad.Text);

                if (cantidad <= 0)
                {
                    GestorMensajes.Advertencia("La cantidad debe ser mayor a 0.");
                    return;
                }

                if (cantidad > stockSeleccionado)
                {
                    GestorMensajes.Advertencia($"Stock insuficiente. Stock disponible: {stockSeleccionado}");
                    return;
                }

                decimal subtotal = cantidad * precioSeleccionado;
                dtCarrito.Rows.Add(idProductoSeleccionado, nombreProductoSeleccionado, cantidad, precioSeleccionado, subtotal);

                CalcularTotalGeneral();
                LimpiarCamposProducto();
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al agregar producto al carrito: " + ex.Message);
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
                    GestorMensajes.Advertencia("El carrito de compras está vacío.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDniCliente.Text))
                {
                    GestorMensajes.Advertencia("Por favor, seleccione un cliente antes de cobrar.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEfectivo.Text))
                {
                    GestorMensajes.Advertencia("Ingrese el monto en efectivo entregado por el cliente.");
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
                    GestorMensajes.Advertencia("El efectivo entregado es menor al total de la compra.");
                    return;
                }

                decimal cambio = efectivoRecibido - totalGeneral;

                bool resultado = objBLL.RegistrarVentaFisica(dtCarrito, totalGeneral, efectivoRecibido, cambio);

                if (resultado)
                {
                    GestorMensajes.Exito($"¡Venta realizada con éxito!\n\nCliente DNI: {txtDniCliente.Text}\nTotal: L. {totalGeneral:N2}\nEfectivo: L. {efectivoRecibido:N2}\nCambio (Vuelto): L. {cambio:N2}");

                    DialogResult resultadoFactura = GestorMensajes.Confirmacion("¿Desea generar e imprimir la factura para el cliente?");

                    if (resultadoFactura == DialogResult.Yes)
                    {
                        GeneradorFactura factura = new GeneradorFactura();
                        factura.GenerarYMostrar(dtCarrito, totalGeneral, efectivoRecibido, cambio);
                    }
                    txtCantidad.Clear();
                    dtCarrito.Clear();
                    lblTotal.Text = "L. 0.00";
                    txtEfectivo.Clear();
                    txtDniCliente.Clear();
                    dniClienteSeleccionado = string.Empty;
                    btnSeleccionarCliente.Enabled = true;
                    LimpiarCamposProducto();
                }
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al procesar la venta: " + ex.Message);
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