using BRAMSELU.CLasesClientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BRAMSELU
{
    public partial class frmClientes : Form
    {
        private ClienteDatos clienteDatos = new ClienteDatos();
        private Cliente cliente;
        private bool esNuevo = false;
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
            dataGridViewclientes.DataSource = null;
            dataGridViewclientes.DataSource = clienteDatos.MostrarClientes();

            if (dataGridViewclientes.Columns["IdCliente"] != null)
            {
                dataGridViewclientes.Columns["IdCliente"].HeaderText = "ID";
                dataGridViewclientes.Columns["Nombre"].HeaderText = "NOMBRE";
                dataGridViewclientes.Columns["Telefono"].HeaderText = "TELEFONO";
                dataGridViewclientes.Columns["Correo"].HeaderText = "CORREO";
                dataGridViewclientes.Columns["Direccion"].HeaderText = "DIRECCION";
                dataGridViewclientes.Columns["TipoPiel"].HeaderText = "TIPO DE PIEL";
            }
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

            txtidcliente.Text = "";
            txtnombrecliente.Clear();
            txttelefonocliente.Text = "";
            txtcorreocliente.Clear();
            txtdireccioncliente.Clear();
            Cmbpiel.SelectedIndex = -1;
            idOriginal = "";
        }

        private bool ValidarFormulario()
        {
            errorProvider1.Clear();
            bool valido = true;

            if (txtidcliente.Text.Replace("-", "").Trim() == "")
            {
                errorProvider1.SetError(txtidcliente, "La identidad es obligatoria.");
                valido = false;
            }
            else if (txtidcliente.Text.Length < 15)
            {
                errorProvider1.SetError(txtidcliente, "Formato incompleto: 0000-0000-00000.");
                valido = false;
            }

            if (txtnombrecliente.Text.Trim() == "")
            {
                errorProvider1.SetError(txtnombrecliente, "El nombre es obligatorio.");
                valido = false;
            }

            if (txttelefonocliente.Text.Replace("-", "").Trim() == "")
            {
                errorProvider1.SetError(txttelefonocliente, "El teléfono es obligatorio.");
                valido = false;
            }
            else if (txttelefonocliente.Text.Length < 9)
            {
                errorProvider1.SetError(txttelefonocliente, "Formato incompleto: 9999-9999.");
                valido = false;
            }

            if (txtcorreocliente.Text.Trim() == "")
            {
                errorProvider1.SetError(txtcorreocliente, "El correo es obligatorio.");
                valido = false;
            }
            else if (!Regex.IsMatch(txtcorreocliente.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProvider1.SetError(txtcorreocliente, "Ingrese un correo electrónico válido.");
                valido = false;
            }

            if (txtdireccioncliente.Text.Trim() == "")
            {
                errorProvider1.SetError(txtdireccioncliente, "La dirección es obligatoria.");
                valido = false;
            }

            if (Cmbpiel.SelectedIndex == -1 || string.IsNullOrWhiteSpace(Cmbpiel.Text))
            {
                errorProvider1.SetError(Cmbpiel, "Debe seleccionar un tipo de piel.");
                valido = false;
            }

            return valido;
        }

        private void Btnnuevo_Click_1(object sender, EventArgs e)
        {
            esNuevo = true;
            LimpiarCampos();
            EstadoCampos(true);
            txtidcliente.Focus();
            bttneditarclientes.Text = "Editar";
        }

        private void bttneditarclientes_Click(object sender, EventArgs e)
        {
           

            if (string.IsNullOrEmpty(idOriginal) || txtidcliente.Text.Replace("-", "").Trim() == "")
            {
                MessageBox.Show("Seleccione primero un cliente de la lista para poder editarlo.");
                return;
            }

            if (txtnombrecliente.Enabled == false)
            {
                esNuevo = false;
                EstadoCampos(true);
                txtidcliente.Focus();
                bttneditarclientes.Text = "Actualizar";
            }
            else
            {
                if (!ValidarFormulario())
                {
                    return;
                }

                iniciarbarra("editar");
            }
        }

        public void EditarCliente()
        {
            try
            {
                cliente = new Cliente(
                    txtidcliente.Text,
                    txtnombrecliente.Text,
                    txttelefonocliente.Text,
                    txtcorreocliente.Text,
                    txtdireccioncliente.Text,
                    Cmbpiel.Text.Trim()
                );

                clienteDatos.EditarCliente(cliente, idOriginal);
                MessageBox.Show("Cliente modificado correctamente");

                CargarClientes();
                LimpiarCampos();
                EstadoCampos(false);
                bttneditarclientes.Text = "Editar";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnguardarcliente_Click(object sender, EventArgs e)
        {

            if (!ValidarFormulario())
            {
                return;
            }

            iniciarbarra("guardar");

            
          
        }

        public void guardarcliente()
        {
            try
            {
                cliente = new Cliente(
                    txtidcliente.Text,
                    txtnombrecliente.Text,
                    txttelefonocliente.Text,
                    txtcorreocliente.Text,
                    txtdireccioncliente.Text,
                    Cmbpiel.Text.Trim()
                );

                if (esNuevo)
                {
                    clienteDatos.GuardarCliente(cliente);
                    MessageBox.Show("Cliente guardado correctamente");
                }
                else
                {
                    clienteDatos.EditarCliente(cliente, idOriginal);
                    MessageBox.Show("Cliente modificado correctamente");
                }

                CargarClientes();
                LimpiarCampos();
                EstadoCampos(false);
                bttneditarclientes.Text = "Editar";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void iniciarbarra(string accionElegida)
        {
            accion = accionElegida;
            progressBarclientes.Value = 0;
            progressBarclientes.Visible = true;
            timer1.Start();
        }

        private void MapearFilaAFormulario(int rowIndex)
        {
            if (rowIndex >= 0)
            {
                errorProvider1.Clear();
                esNuevo = false;
                EstadoCampos(false);
                bttneditarclientes.Text = "Editar";

                DataGridViewRow fila = dataGridViewclientes.Rows[rowIndex];

                idOriginal = fila.Cells["IdCliente"].Value?.ToString() ?? "";
                txtidcliente.Text = idOriginal;
                txtnombrecliente.Text = fila.Cells["Nombre"].Value?.ToString() ?? "";
                txttelefonocliente.Text = fila.Cells["Telefono"].Value?.ToString() ?? "";
                txtcorreocliente.Text = fila.Cells["Correo"].Value?.ToString() ?? "";
                txtdireccioncliente.Text = fila.Cells["Direccion"].Value?.ToString() ?? "";

                string tipoPielDb = fila.Cells["TipoPiel"].Value?.ToString()?.Trim() ?? "";
                int index = Cmbpiel.FindStringExact(tipoPielDb);
                if (index != -1)
                {
                    Cmbpiel.SelectedIndex = index;
                }
                else
                {
                    Cmbpiel.Text = tipoPielDb;
                }
            }
        }

        private void dataGridViewclientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MapearFilaAFormulario(e.RowIndex);
        }

        private void dataGridViewclientes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            MapearFilaAFormulario(e.RowIndex);
        }

        private void bttneliminarclientes_Click(object sender, EventArgs e)
        {
           

            if (string.IsNullOrEmpty(idOriginal) || txtidcliente.Text.Replace("-", "").Trim() == "")
            {
                MessageBox.Show("Seleccione un cliente de la lista para eliminar.");
                return;
            }
            iniciarbarra("eliminar");

        }

        public void EliminarCliente()
        {
            try
            {
                if (MessageBox.Show("¿Está seguro de eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clienteDatos.ElimiarCliente(idOriginal);

                    CargarClientes();
                    LimpiarCampos();
                    EstadoCampos(false);
                    bttneditarclientes.Text = "Editar";

                    MessageBox.Show("Cliente eliminado correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnbuscarclientes_Click(object sender, EventArgs e)
        {
            iniciarbarra("buscar");

        }

        public void BuscarCliente()
        {
            dataGridViewclientes.DataSource = clienteDatos.BuscarCliente(txtbuscarcliente.Text);
        }

        private void txtbuscarcliente_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBarclientes.Increment(5);

            if (progressBarclientes.Value >= 100)
            {
                timer1.Stop();
                progressBarclientes.Visible = false;

                switch (accion)
                {
                    case "guardar":
                        guardarcliente();
                        break;

                    case "buscar":
                        BuscarCliente();
                        break;

                    case "editar":
                        EditarCliente();
                        break;

                    case "eliminar":
                        EliminarCliente();
                        break;

                        
                }
            }
        }
    }
}