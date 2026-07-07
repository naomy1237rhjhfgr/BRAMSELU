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
        private ClaseCitas claseCita;

        public frmCitas()
        {
            InitializeComponent();
            claseCita = new ClaseCitas();
        }

        private void frmCitas_Load(object sender, EventArgs e)
        {
            DtpFecha.Format = DateTimePickerFormat.Short;
            DtpHora.Format = DateTimePickerFormat.Time;
            DtpHora.ShowUpDown = true;
        }

        private bool Validar()
        {
            errorProvider1.Clear();
            bool esValido = true;

            if (CmbCliente.SelectedIndex == -1)
            {
                errorProvider1.SetError(CmbCliente, "Seleccione un cliente");
                esValido = false;
            }
            if (CmbServicio.SelectedIndex == -1)
            {
                errorProvider1.SetError(CmbServicio, "Seleccione un servicio");
                esValido = false;
            }
            if (CmbEspecialista.SelectedIndex == -1)
            {
                errorProvider1.SetError(CmbEspecialista, "Seleccione un especialista");
                esValido = false;
            }
            if (CmbEstado.SelectedIndex == -1)
            {
                errorProvider1.SetError(CmbEstado, "Seleccione un estado");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(TxtPrecio.Text))
            {
                errorProvider1.SetError(TxtPrecio, "Ingrese el precio");
                esValido = false;
            }
            else if (!decimal.TryParse(TxtPrecio.Text, out _))
            {
                errorProvider1.SetError(TxtPrecio, "El precio debe ser un número válido");
                esValido = false;
            }

            return esValido;
        }

        private void MapearDatos()
        {

            claseCita.Cliente = CmbCliente.Text;
            claseCita.Telefono = TxtTelefono.Text;
            claseCita.Servicio = CmbServicio.Text;
            claseCita.Especialista = CmbEspecialista.Text;
            claseCita.Fecha = DtpFecha.Value;
            claseCita.Hora = DtpHora.Value.ToString("HH:mm");
            claseCita.Duracion =TxtDuracion.Text;
            claseCita.Notas = TxtNotas.Text;
            claseCita.Estado = CmbEstado.Text;
            claseCita.Precio = Convert.ToDecimal(TxtPrecio.Text);
        }

        private void Limpiar()
        {
            claseCita = new ClaseCitas(); 
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                MapearDatos();
                if (claseCita.Guardar())
                {
                    MessageBox.Show("Cita guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    // Aquí deberías llamar a una función para actualizar tu DataGridView
                }
                else
                {
                    MessageBox.Show("Error al guardar la cita.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Validar() && claseCita.ID > 0)
            {
                MapearDatos();
                if (claseCita.Modificar())
                {
                    MessageBox.Show("Cita actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la cita.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una cita existente para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (claseCita.ID > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar esta cita?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (claseCita.Eliminar())
                    {
                        MessageBox.Show("Cita eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la cita.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una cita para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
