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
        private decimal montoInicialActual = 0;
        private decimal totalVentasActual = 0;
        private decimal totalComprasActual = 0;

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
                montoInicialActual = Convert.ToDecimal(dt.Rows[0]["MontoInicial"]);
                string usuarioApertura = dt.Rows[0]["UsuarioApertura"] != DBNull.Value ? dt.Rows[0]["UsuarioApertura"].ToString() : "N/D";

                lblEstado.Text = "Estado: CAJA DE SKINCARE ABIERTA";
                lblEstado.ForeColor = System.Drawing.Color.Green;
                lblInfoCaja.Text = $"Abierta por: {usuarioApertura} | Base inicial: L. {montoInicialActual:N2}";

                txtMontoInicial.Enabled = false;
                btnAbrirCaja.Enabled = false;
                txtMontoFinal.Enabled = true;
                btnCerrarCaja.Enabled = true;

                CargarDatosDelTurno(idCajaActual);
            }
            else
            {
                idCajaActual = 0;
                montoInicialActual = 0;
                totalVentasActual = 0;
                totalComprasActual = 0;

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

                if (dgvComprasDelDia != null)
                {
                    dgvComprasDelDia.DataSource = null;
                }

                if (lblTotalVentas != null) lblTotalVentas.Text = "L. 0.00";
                if (lblTotalCompras != null) lblTotalCompras.Text = "L. 0.00";
                if (lblEfectivoEsperado != null) lblEfectivoEsperado.Text = "L. 0.00";
            }
        }

        private void CargarDatosDelTurno(int idCaja)
        {
            try
            {
                DataTable dtVentas = objBLL.ObtenerVentasDeCajaActual(idCaja);
                if (dgvVentasDelDia != null)
                {
                    dgvVentasDelDia.DataSource = dtVentas;
                }

                totalVentasActual = 0;
                foreach (DataRow row in dtVentas.Rows)
                {
                    totalVentasActual += Convert.ToDecimal(row["Total"]);
                }

                DataTable dtCompras = objBLL.ObtenerComprasDeCajaActual(idCaja);
                if (dgvComprasDelDia != null)
                {
                    dgvComprasDelDia.DataSource = dtCompras;
                }

                totalComprasActual = 0;
                foreach (DataRow row in dtCompras.Rows)
                {
                    totalComprasActual += Convert.ToDecimal(row["Total"]);
                }

                decimal efectivoEsperado = (montoInicialActual + totalVentasActual) - totalComprasActual;

                if (lblTotalVentas != null) lblTotalVentas.Text = "L. " + totalVentasActual.ToString("N2");
                if (lblTotalCompras != null) lblTotalCompras.Text = "L. " + totalComprasActual.ToString("N2");
                if (lblEfectivoEsperado != null) lblEfectivoEsperado.Text = "L. " + efectivoEsperado.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los movimientos del turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string usuarioLogueado = "Administrador";

                bool resultado = objBLL.AbrirCaja(montoInicial, usuarioLogueado);

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
                MessageBox.Show("Ingrese el efectivo total contado en caja físicamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal montoFinalContado = Convert.ToDecimal(txtMontoFinal.Text);
                decimal efectivoEsperado = (montoInicialActual + totalVentasActual) - totalComprasActual;
                decimal diferencia = montoFinalContado - efectivoEsperado;

                string mensajeCuadratura = $"Resumen de Cierre:\n" +
                                           $"- Monto Inicial: L. {montoInicialActual:N2}\n" +
                                           $"- Total Ventas (+): L. {totalVentasActual:N2}\n" +
                                           $"- Total Compras (-): L. {totalComprasActual:N2}\n" +
                                           $"- Efectivo Esperado: L. {efectivoEsperado:N2}\n" +
                                           $"- Efectivo Contado: L. {montoFinalContado:N2}\n\n";

                if (diferencia < 0)
                {
                    mensajeCuadratura += $"¡ALERTA! Hay un FALTANTE en caja por: L. {Math.Abs(diferencia):N2}";
                }
                else if (diferencia > 0)
                {
                    mensajeCuadratura += $"¡ATENCIÓN! Hay un SOBRANTE en caja por: L. {diferencia:N2}";
                }
                else
                {
                    mensajeCuadratura += "¡Caja cuadrada perfectamente! Sin diferencias.";
                }

                DialogResult dialogResult = MessageBox.Show(mensajeCuadratura + "\n\n¿Desea proceder a cerrar la caja?", "Confirmación de Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    bool resultado = objBLL.CerrarCaja(idCajaActual, montoFinalContado);

                    if (resultado)
                    {
                        MessageBox.Show("¡Caja cerrada y registrada correctamente en la base de datos!", "Cierre Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMontoFinal.Clear();
                        VerificarEstadoCaja();
                    }
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

        private void txtMontoInicial_TextChanged(object sender, EventArgs e) { }
        private void txtMontoFinal_TextChanged(object sender, EventArgs e) { }
        private void lblEstado_Click(object sender, EventArgs e) { }
    }
}