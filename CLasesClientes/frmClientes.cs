using BRAMSELU.Negocio;
using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BRAMSELU.Entidades;

namespace BRAMSELU
{
    public partial class frmClientes : Form
    {
        private ClienteNegocio clienteNegocio = new ClienteNegocio();
        private Cliente Cliente;
        private string idOriginal = "";
        private string accion = "";

        public frmClientes()
        {
            InitializeComponent();
            CargarClientes();
            txtidcliente.Mask = "0000-0000-00000";
            txttelefonocliente.Mask = "0000-0000";
            EstadoCampos(false);
        }

        private void CargarClientes()
        {
            dataGridViewclientes.DataSource = clienteNegocio.ListarClientes();
        }

        private void EstadoCampos(bool habilitado)
        {
            txtidcliente.Enabled = habilitado;
            txtnombrecliente.Enabled = habilitado;
            txttelefonocliente.Enabled = habilitado;
            txtcorreocliente.Enabled = habilitado;
            txtdireccioncliente.Enabled = habilitado;
            Cmbpiel.Enabled = habilitado;
        }

        private void LimpiarCampos()
        {
            errorProvider1.Clear();
            txtidcliente.Clear();
            txtnombrecliente.Clear();
            txttelefonocliente.Clear();
            txtcorreocliente.Clear();
            txtdireccioncliente.Clear();
            Cmbpiel.SelectedIndex = -1;
            idOriginal = "";
        }

        private bool ValidarFormulario()
        {
            errorProvider1.Clear();
            bool valido = true;

            if (txtidcliente.Text.Replace("-", "").Replace(" ", "").Trim() == "")
            {
                errorProvider1.SetError(txtidcliente, "La identidad es obligatoria.");
                valido = false;
            }
            if (txtnombrecliente.Text.Trim() == "")
            {
                errorProvider1.SetError(txtnombrecliente, "El nombre es obligatorio.");
                valido = false;
            }
            if (!Regex.IsMatch(txtcorreocliente.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProvider1.SetError(txtcorreocliente, "Correo inválido.");
                valido = false;
            }
            return valido;
        }

        public void EjecutarAccion()
        {
            try
            {
                Cliente = new Cliente(txtidcliente.Text, txtnombrecliente.Text, txttelefonocliente.Text, txtcorreocliente.Text, txtdireccioncliente.Text, Cmbpiel.Text.Trim());

                switch (accion)
                {
                    case "guardar":
                        clienteNegocio.InsertarCliente(Cliente);
                        MessageBox.Show("Cliente guardado correctamente");
                        break;
                    case "editar":
                        clienteNegocio.ActualizarCliente(Cliente, idOriginal);
                        MessageBox.Show("Cliente modificado correctamente");
                        break;
                    case "eliminar":
                        clienteNegocio.EliminarCliente(idOriginal);
                        MessageBox.Show("Cliente eliminado correctamente");
                        break;
                    case "buscar":
                        dataGridViewclientes.DataSource = clienteNegocio.BuscarClientes(txtbuscarcliente.Text);
                        return;
                }
                CargarClientes();
                LimpiarCampos();
                EstadoCampos(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBarclientes.Increment(5);
            if (progressBarclientes.Value >= 100)
            {
                timer1.Stop();
                progressBarclientes.Visible = false;
                EjecutarAccion();
            }
        }

        private void iniciarbarra(string accionElegida)
        {
            accion = accionElegida;
            progressBarclientes.Value = 0;
            progressBarclientes.Visible = true;
            timer1.Start();
        }

        private void Btnnuevo_Click_1(object sender, EventArgs e)
        {
            LimpiarCampos();
            EstadoCampos(true);
        }

        private void btnguardarcliente_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario()) iniciarbarra("guardar");
        }

        private void bttneditarclientes_Click(object sender, EventArgs e)
        {
            if (!txtnombrecliente.Enabled) { EstadoCampos(true); bttneditarclientes.Text = "Actualizar"; }
            else if (ValidarFormulario()) iniciarbarra("editar");
        }

        private void bttneliminarclientes_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idOriginal)) iniciarbarra("eliminar");
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Por favor, ingrese un criterio de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscar.Focus();
                return;
            }

            iniciarbarra("buscar");
        }

        private void dataGridViewclientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridViewclientes.Rows[e.RowIndex];
                idOriginal = fila.Cells[0].Value.ToString();
                txtidcliente.Text = idOriginal;
                txtnombrecliente.Text = fila.Cells[1].Value.ToString();
                txttelefonocliente.Text = fila.Cells[2].Value.ToString();
                txtcorreocliente.Text = fila.Cells[3].Value.ToString();
                txtdireccioncliente.Text = fila.Cells[4].Value.ToString();
                Cmbpiel.Text = fila.Cells[5].Value.ToString();
            }
        }

        private void txtnombrecliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}