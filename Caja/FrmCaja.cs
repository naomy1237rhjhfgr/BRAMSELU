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

namespace BRAMSELU.Caja
{
    public partial class FrmCaja : Form
    {
        private CajaBLL objBLL = new CajaBLL();
        private int idCajaActual = 0;

        public FrmCaja()
        {
            InitializeComponent();

            this.txtMontoInicial.KeyPress += new KeyPressEventHandler(this.txtMontoInicial_KeyPress);
            this.txtMontoFinal.KeyPress += new KeyPressEventHandler(this.txtMontoFinal_KeyPress);
        }

        private void FrmCaja_Load(object sender, EventArgs e)
        {
            VerificarEstadoCaja();
        }

        private void VerificarEstadoCaja()
        {
            DataTable dt = objBLL.ObtenerCajaAbierta();
            if (dt.Rows.Count > 0)
            {
                idCajaActual = Convert.ToInt32(dt.Rows[0]["IdCaja"]);
                decimal montoInicial = Convert.ToDecimal(dt.Rows[0]["MontoInicial"]);

                lblEstado.Text = "Estado: CAJA DE SKINCARE ABIERTA";
                lblEstado.ForeColor = System.Drawing.Color.Green;
                lblInfoCaja.Text = "Caja iniciada con base de: L. " + montoInicial.ToString("N2");

                txtMontoInicial.Enabled = false;
                btnAbrirCaja.Enabled = false;
                txtMontoFinal.Enabled = true;
                btnCerrarCaja.Enabled = true;

                CargarVentasDelDia(idCajaActual);
            }
            else
            {
                idCajaActual = 0;
                lblEstado.Text = "Estado: CAJA DE SKINCARE CERRADA";
                lblEstado.ForeColor = System.Drawing.Color.Red;
                lblInfoCaja.Text = "Debe abrir caja para poder vender productos.";

                txtMontoInicial.Enabled = true;
                btnAbrirCaja.Enabled = true;
                txtMontoFinal.Enabled = false;
                btnCerrarCaja.Enabled = false;


                if (dgvVentasDelDia != null)
                {
                    dgvVentasDelDia.DataSource = null;
                }
            }
        }

        private void CargarVentasDelDia(int idCaja)
        {
            try
            {
                if (dgvVentasDelDia != null)
                {
                    DataTable dtVentas = objBLL.ObtenerVentasDeCajaActual(idCaja);
                    dgvVentasDelDia.DataSource = dtVentas;
                }
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al cargar las transacciones del dia: " + ex.Message);
            }
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMontoInicial.Text))
            {
                GestorMensajes.Advertencia("Ingrese el monto inicial para abrir la caja");
                return;
            }

            try
            {
                decimal montoInicial = Convert.ToDecimal(txtMontoInicial.Text);
                bool resultado = objBLL.AbrirCaja(montoInicial);

                if (resultado)
                {
                    GestorMensajes.Exito("¡Caja abierta con exito! Ya puede realizar ventas.");
                    txtMontoInicial.Clear();
                    VerificarEstadoCaja();
                }
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al abrir caja: " + ex.Message);
            }
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMontoFinal.Text))
            {
                GestorMensajes.Advertencia("Ingrese el efectivo total contado en caja");
                return;
            }

            try
            {
                decimal montoFinal = Convert.ToDecimal(txtMontoFinal.Text);
                bool resultado = objBLL.CerrarCaja(idCajaActual, montoFinal);

                if (resultado)
                {
                    GestorMensajes.Error("¡Caja cerrada correctamente!");
                    txtMontoFinal.Clear();
                    VerificarEstadoCaja();
                }
            }
            catch (Exception ex)
            {
                GestorMensajes.Error("Error al cerrar caja: " + ex.Message);
            }
        }

        private void txtMontoInicial_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtMontoInicial_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMontoFinal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtMontoFinal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}