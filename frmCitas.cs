using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRAMSELU
{
    public partial class frmCitas : Form
    {
        private ClaseCitas claseCitas;

        public frmCitas()
        {
            InitializeComponent();
            claseCitas = new ClaseCitas();
            errorProvider1.SetError();
        }
        private void frmCitas_Load(object sender, EventArgs e)
        {
            // Aquí puedes llamar a un método para llenar los ComboBoxes o listar las citas en el DataGridView si es necesario.
            LimpiarFormulario();
        }

        private bool ValidarFormulario()
        {
            // Validar Cliente
            if (CmbCliente.SelectedIndex == -1)
            {
                errorProvider1.SetError(CmbCliente, "Seleccione un cliente");
                return false;
            }
            // Validar Servicio
            if (CmbServicio.SelectedIndex == -1)
            {
                errorProvider1.SetError(CmbServicio, "Seleccione un servicio");
                return false;
            }
            // Validar Especialista
            if (CmbEspecialista.SelectedIndex == -1)
            {
                errorProvider1.SetError(CmbEspecialista, "Seleccione un especialista");
                return false;
            }
            // Validar Precio
            if (string.IsNullOrEmpty(TxtPrecio.Text))
            {
                errorProvider1.SetError(TxtPrecio, "Escriba el precio del servicio");
                return false;
            }
            // Validar Estado
            if (CmbEstado.SelectedIndex == -1)
            {
                errorProvider1.SetError(CmbEstado, "Seleccione el estado de la cita");
                return false;
            }

            object value = errorProvider1.Clear();
            return true;
        }

        private void LimpiarFormulario()
        {
            claseCitas = new ClaseCitas(); // Reinicia la instancia (ID vuelve a 0)
            CmbCliente.SelectedIndex = -1;
            TxtTelefono.Clear();
            CmbServicio.SelectedIndex = -1;
            CmbEspecialista.SelectedIndex = -1;
            DtpFecha.Value = DateTime.Now;
            DtpHora.Value = DateTime.Now;
            TxtDuracion.Clear();
            TxtNotas.Clear();
            CmbEstado.SelectedIndex = -1;
            TxtPrecio.Clear();
            errorProvider1.Clear();
        }

        private void LlenarClaseConCampos()
        {
            claseCitas.Cliente = CmbCliente.SelectedItem.ToString();
            claseCitas.Telefono = TxtTelefono.Text;
            claseCitas.Servicio = CmbServicio.SelectedItem.ToString();
            claseCitas.Especialista = CmbEspecialista.SelectedItem.ToString();
            claseCitas.Fecha = DtpFecha.Value;
            claseCitas.Hora = DtpHora.Value;
            claseCitas.Duracion = TxtDuracion.Text;
            claseCitas.Notas = TxtNotas.Text;
            claseCitas.Estado = CmbEstado.SelectedItem.ToString();

            decimal.TryParse(TxtPrecio.Text, out decimal precio);
            claseCitas.Precio = precio;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                LlenarClaseConCampos();

                if (claseCitas.ID == 0)
                {
                    if (claseCitas.Guardar())
                    {
                        MessageBox.Show("Cita agendada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarFormulario();
                        // Aquí puedes refrescar tu DataGridView
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar la cita.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else 
                {
                    if (claseCitas.Modificar())
                    {
                        MessageBox.Show("Cita modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarFormulario();
                        // Aquí puedes refrescar tu DataGridView
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar la cita.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow != null)
            {
                claseCitas.ID = Convert.ToInt32(dgvCitas.CurrentRow.Cells["id"].Value);

                CmbCliente.Text = dgvCitas.CurrentRow.Cells["cliente"].Value.ToString();
                TxtTelefono.Text = dgvCitas.CurrentRow.Cells["telefono"].Value.ToString();
                CmbServicio.Text = dgvCitas.CurrentRow.Cells["servicio"].Value.ToString();
                CmbEspecialista.SelectedItem = dgvCitas.CurrentRow.Cells["especialista"].Value.ToString();
                DtpFecha.Value = Convert.ToDateTime(dgvCitas.CurrentRow.Cells["fecha"].Value);
                DtpHora.Value = Convert.ToDateTime(dgvCitas.CurrentRow.Cells["hora"].Value);
                TxtDuracion.Text = dgvCitas.CurrentRow.Cells["duracion"].Value.ToString();
                TxtNotas.Text = dgvCitas.CurrentRow.Cells["notas"].Value.ToString();
                CmbEstado.SelectedItem = dgvCitas.CurrentRow.Cells["estado"].Value.ToString();
                TxtPrecio.Text = dgvCitas.CurrentRow.Cells["precio"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una cita de la tabla para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (claseCitas.ID > 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar esta cita?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (claseCitas.Eliminar())
                    {
                        MessageBox.Show("Cita eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarFormulario();
                        // Aquí puedes refrescar tu DataGridView
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la cita.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una cita primero mediante el botón Editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
