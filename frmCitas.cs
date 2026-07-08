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
        private int idCitaSeleccionada = -1;

        private const string PLACEHOLDER_HORA = "Ej. 02:30 PM";
        private const string PLACEHOLDER_DURACION = "Ej. 1 hora / 45 mins";
        private const string PLACEHOLDER_NOTAS = "Escriba observaciones adicionales aquí...";
        private const string PLACEHOLDER_PRECIO = "0.00";

        public frmCitas()
        {
            InitializeComponent();
            claseCita = new ClaseCitas();

            ConfigurarComponentes();
        }
        private void frmCitas_Load(object sender, EventArgs e)
        {
            CargarDatosGrid();
        }
        private void ConfigurarComponentes()
        {
            CmbCliente.Items.AddRange(new string[] { "Juan Pérez", "María López", "Carlos Mendoza", "Ana Martínez" });
            CmbServicio.Items.AddRange(new string[] { "Limpieza facial completa", "Masaje relajante", "Exfoliación corporal", "Tratamiento antiacné" });
            CmbEspecialista.Items.AddRange(new string[] { "Dra. Elena Gómez", "Dra. Valeria Ruiz", "Carlos Estévez" });
            CmbEstado.Items.AddRange(new string[] { "Pendiente", "Confirmada", "Completada", "Cancelada" });

            dgvCitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCitas.MultiSelect = false;
            dgvCitas.ReadOnly = true;
            ConfigurarPlaceholders();

            TxtTelefono.MaxLength = 9;
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

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

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
