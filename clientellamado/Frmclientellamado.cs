using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRAMSELU.clientellamado;
using BRAMSELU.Mensajes;

namespace BRAMSELU.clientellamado
{
    public partial class Frmclientellamado : Form
    {
        private clientellabll objBLL = new clientellabll();

        public string IdClienteSeleccionado { get; set; }
        public string NombreClienteSeleccionado { get; set; }

        public Frmclientellamado()
        {
            InitializeComponent();
        }

        private void Frmclientellamado_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "Selección de Clientes";
            lblBuscar.Text = "Buscar Cliente";
            btnAgregarACompra.Text = "Seleccionar Cliente";
            this.Text = "Clientes - Selección de Cliente";

            dgvDatos.DataSource = objBLL.ListarClientes();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();
            dgvDatos.DataSource = objBLL.BuscarClientes(filtro);
        }

        private void btnAgregarACompra_Click(object sender, EventArgs e)
        {
            SeleccionarCliente();
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SeleccionarCliente();
            }
        }

        private void SeleccionarCliente()
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                int rowIndex = dgvDatos.SelectedRows[0].Index;
                IdClienteSeleccionado = dgvDatos.Rows[rowIndex].Cells["IdCliente"].Value.ToString();
                NombreClienteSeleccionado = dgvDatos.Rows[rowIndex].Cells["Nombre"].Value.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                GestorMensajes.Advertencia("Por favor, seleccione un cliente de la lista.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}