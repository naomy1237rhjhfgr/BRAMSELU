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

        public FrmVentas()
        {
            InitializeComponent();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            CargarProductos();
            InicializarCarrito();
        }

        private void CargarProductos()
        {
            try
            {
                cmbProductos.DataSource = objBLL.ObtenerProductos();
                cmbProductos.DisplayMember = "NombreProducto";
                cmbProductos.ValueMember = "IdProducto";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Por favor, ingrese una cantidad.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataRowView filaSeleccionada = (DataRowView)cmbProductos.SelectedItem;
                int idProducto = Convert.ToInt32(filaSeleccionada["IdProducto"]);
                string nombre = filaSeleccionada["NombreProducto"].ToString();
                decimal precio = Convert.ToDecimal(filaSeleccionada["Precio"]);
                int stockActual = Convert.ToInt32(filaSeleccionada["Stock"]);
                int cantidad = Convert.ToInt32(txtCantidad.Text);

                if (cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor a 0.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cantidad > stockActual)
                {
                    MessageBox.Show($"Stock insuficiente. Stock disponible: {stockActual}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal subtotal = cantidad * precio;
                dtCarrito.Rows.Add(idProducto, nombre, cantidad, precio, subtotal);

                CalcularTotalGeneral();
                txtCantidad.Clear();
                cmbProductos.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar producto al carrito: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                // Registrar venta en la base de datos y descontar stock automáticamente
                bool resultado = objBLL.RegistrarVentaFisica(dtCarrito, totalGeneral, efectivoRecibido, cambio);

                if (resultado)
                {
                    MessageBox.Show($"¡Venta realizada con éxito!\n\nTotal: L. {totalGeneral:N2}\nEfectivo: L. {efectivoRecibido:N2}\nCambio (Vuelto): L. {cambio:N2}",
                                    "Factura Física Generada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dtCarrito.Clear();
                    lblTotal.Text = "L. 0.00";
                    txtEfectivo.Clear();
                    CargarProductos(); // Actualiza el combo con el stock reducido
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
