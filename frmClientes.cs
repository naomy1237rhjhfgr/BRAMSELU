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
        public frmClientes()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            dataGridViewclientes.DataSource = clienteDatos.MostrarClientes();

            dataGridViewclientes.Columns["IdCliente"].HeaderText = "ID";
            dataGridViewclientes.Columns["Nombre"].HeaderText = "NOMBRE";
            dataGridViewclientes.Columns["Telefono"].HeaderText = "TELEFONO";
            dataGridViewclientes.Columns["Correo"].HeaderText = "CORREO";
            dataGridViewclientes.Columns["Direccion"].HeaderText = "DIRECCION";
            dataGridViewclientes.Columns["TipoPiel"].HeaderText = "TIPO DE PIEL";
        }

        private void LimpiarCampos()
        {
            txtidcliente.Clear();
            txtnombrecliente.Clear();
            txttelefonocliente.Clear();
            txtcorreocliente.Clear();
            txtdireccioncliente.Clear();
            txttipopielcliente.Clear();

            txtidcliente.Focus();
        }

        private void btnguardarcliente_Click(object sender, EventArgs e)
        {

           

            if (txtidcliente.Text.Trim() == "" ||
                txtnombrecliente.Text.Trim() == "" ||
                txttelefonocliente.Text.Trim() == "" ||
                txtcorreocliente.Text.Trim() == "" ||
                txtdireccioncliente.Text.Trim() == "" ||
                txttipopielcliente.Text.Trim() == "")
            {
                MessageBox.Show("Debe completar todos los campos");
                return;
            }

            if (txtidcliente.Text.Length != 13)
            {
                MessageBox.Show("El numero de identidad debe contener 13 digitos.");
                txtidcliente.Focus();
                return; 
            }

            if (!Regex.IsMatch(txtcorreocliente.Text,
                 @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ingrese un correo electrónico válido.");
                txtcorreocliente.Focus();
                return;
            }

            try
            {
                cliente = new Cliente(
                txtidcliente.Text,
                txtnombrecliente.Text,
                txttelefonocliente.Text,
                txtcorreocliente.Text,
                txtdireccioncliente.Text,
                txttipopielcliente.Text
                );

                clienteDatos.GuardarCliente(cliente);
                CargarClientes();

                MessageBox.Show("Cliente guardado correctamente");

                LimpiarCampos();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void dataGridViewclientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtidcliente.Text = dataGridViewclientes.Rows[e.RowIndex].Cells["IdCliente"].Value.ToString();
                txtnombrecliente.Text = dataGridViewclientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txttelefonocliente.Text = dataGridViewclientes.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txtcorreocliente.Text = dataGridViewclientes.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
                txtdireccioncliente.Text = dataGridViewclientes.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                txttipopielcliente.Text = dataGridViewclientes.Rows[e.RowIndex].Cells["TipoPiel"].Value.ToString();
            }

                    
            
        }

        private void bttneditarclientes_Click(object sender, EventArgs e)
        {
            try
            {
                cliente = new Cliente(

                    txtidcliente.Text,
                    txtnombrecliente.Text,
                    txttelefonocliente.Text,
                    txtcorreocliente.Text,
                    txtdireccioncliente.Text,
                    txttipopielcliente.Text
                );

                clienteDatos.EditarCliente(cliente);
                CargarClientes();
                LimpiarCampos();

                MessageBox.Show("Cliente editado correctamente");
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bttneliminarclientes_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Estas seguro de eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                {
                    clienteDatos.ElimiarCliente(txtidcliente.Text);

                    CargarClientes();
                    LimpiarCampos();

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
            dataGridViewclientes.DataSource = clienteDatos.BuscarCliente(txtbuscarcliente.Text);
        }

        private void txtbuscarcliente_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscarcliente.Text.Trim() == "")
            {
                CargarClientes();
            }
            else
            {
                dataGridViewclientes.DataSource = clienteDatos.BuscarCliente(txtbuscarcliente.Text);
            }
        }

        private void txtidcliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txttelefonocliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) 
            {
                e.Handled = true;
            }
        }
    }


}
