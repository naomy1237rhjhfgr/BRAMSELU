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
        private int idCitaSeleccionada = 0;

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
            RefrescarGrid();
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
            dgvCitas.AllowUserToAddRows = false;

            ConfigurarPlaceholders();

            TxtTelefono.MaxLength = 9;
        }
        private void RefrescarGrid(string filtro = "")
        {
            dgvCitas.DataSource = claseCita.ListarCitas(filtro);
            FormatearColumnasGrid();
        }
        private void FormatearColumnasGrid()
        {
            if (dgvCitas.Columns.Count > 0)
            {
                if (dgvCitas.Columns["Id"] != null) dgvCitas.Columns["Id"].Visible = false;
                if (dgvCitas.Columns["Notas"] != null) dgvCitas.Columns["Notas"].Visible = false;

                if (dgvCitas.Columns["Precio"] != null)
            {
                    dgvCitas.Columns["Precio"].DefaultCellStyle.Format = "L. #,##0.00";
            }
            }
            }
        #region PLACEHOLDER MANAGEMENT
        private void ConfigurarPlaceholders()
            {
            SetPlaceholder(TxtHora, PLACEHOLDER_HORA);
            SetPlaceholder(TxtDuracion, PLACEHOLDER_DURACION);
            SetPlaceholder(TxtNotas, PLACEHOLDER_NOTAS);
            SetPlaceholder(TxtPrecio, PLACEHOLDER_PRECIO);
            }

        private void SetPlaceholder(TextBox txtHora, string pLACEHOLDER_HORA)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region VALIDACIONES DE ENTRADA
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
            {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) e.Handled = true;
            }

        private void txtPrecio_Leave(object sender, EventArgs e)
            {
            if (TxtPrecio.Text != PLACEHOLDER_PRECIO && decimal.TryParse(TxtPrecio.Text, out decimal result))
            {
                TxtPrecio.Text = result.ToString("F2");
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            TxtTelefono.TextChanged -= txtTelefono_TextChanged;
            string num = TxtTelefono.Text.Replace("-", "");
            if (num.Length > 4)
            {
                TxtTelefono.Text = num.Insert(4, "-");
                TxtTelefono.SelectionStart = TxtTelefono.Text.Length;
        }
            TxtTelefono.TextChanged += txtTelefono_TextChanged;
        }
        #endregion

        #region ACCIONES CRUD (BOTONES)

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string cliente = CmbCliente.SelectedItem?.ToString() ?? "";
            string telefono = TxtTelefono.Text.Trim();
            string servicio = CmbServicio.SelectedItem?.ToString() ?? "";
            string especialista = CmbEspecialista.SelectedItem?.ToString() ?? "No asignado";
            DateTime fecha = DtpFecha.Value;
            string hora = TxtHora.Text == PLACEHOLDER_HORA ? "" : TxtHora.Text.Trim();
            string duracion = TxtDuracion.Text == PLACEHOLDER_DURACION ? "" : TxtDuracion.Text.Trim();
            string notas = TxtNotas.Text == PLACEHOLDER_NOTAS ? "" : TxtNotas.Text.Trim();
            string estado = CmbEstado.SelectedItem?.ToString() ?? "Pendiente";

            decimal.TryParse(TxtPrecio.Text, out decimal precioFinal);

            claseCita = new ClaseCitas(idCitaSeleccionada, cliente, telefono, servicio, especialista, fecha, hora, duracion, notas, estado, precioFinal);

            string resultado = claseCita.Guardar();

            if (resultado == "OK")
            {
                MessageBox.Show("Operación realizada con éxito.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                RefrescarGrid();
        }
            else
            {
                MessageBox.Show(resultado, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow != null)
            {
                DataGridViewRow fila = dgvCitas.CurrentRow;

                idCitaSeleccionada = Convert.ToInt32(fila.Cells["Id"].Value);

                CmbCliente.SelectedItem = fila.Cells["Cliente"].Value.ToString();
                TxtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                CmbServicio.SelectedItem = fila.Cells["Servicio"].Value.ToString();
                CmbEspecialista.SelectedItem = fila.Cells["Especialista"].Value.ToString();
                DtpFecha.Value = Convert.ToDateTime(fila.Cells["Fecha"].Value);

                TxtHora.Text = fila.Cells["Hora"].Value.ToString();
                TxtHora.ForeColor = Color.Black;

                string duracion = fila.Cells["Duracion"].Value.ToString();
                TxtDuracion.Text = string.IsNullOrEmpty(duracion) ? PLACEHOLDER_DURACION : duracion;
                TxtDuracion.ForeColor = string.IsNullOrEmpty(duracion) ? Color.Gray : Color.Black;

                string notas = fila.Cells["Notas"].Value.ToString();
                TxtNotas.Text = string.IsNullOrEmpty(notas) ? PLACEHOLDER_NOTAS : notas;
                TxtNotas.ForeColor = string.IsNullOrEmpty(notas) ? Color.Gray : Color.Black;

                CmbEstado.SelectedItem = fila.Cells["Estado"].Value.ToString();

                TxtPrecio.Text = Convert.ToDecimal(fila.Cells["Precio"].Value).ToString("F2");
                TxtPrecio.ForeColor = Color.Black;
            }
            else
            {
                MessageBox.Show("Seleccione una fila de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // BOTÓN ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow != null)
            {
                var confirmacion = MessageBox.Show("¿Desea eliminar este registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    int idEliminar = Convert.ToInt32(dgvCitas.CurrentRow.Cells["Id"].Value);

                    // Llamamos al método Eliminar pasándole el ID
                    if (claseCita.Eliminar(idEliminar, out string mensaje))
                    {
                        MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarFormulario();
                        RefrescarGrid();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }
            else
        {
                MessageBox.Show("Seleccione la fila que desea eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RefrescarGrid(txtBuscar.Text.Trim());
            }
        #endregion

        private void LimpiarFormulario()
            {
            CmbCliente.SelectedIndex = -1;
            CmbServicio.SelectedIndex = -1;
            CmbEspecialista.SelectedIndex = -1;
            CmbEstado.SelectedIndex = -1;
            TxtTelefono.Clear();
            DtpFecha.Value = DateTime.Now;

            ConfigurarPlaceholders();
            idCitaSeleccionada = 0; // Vuelve a modo de inserción limpia
        }

        
    }
}
