using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRAMSELU.CLasesClientes;
using BRAMSELU.BLL;
using BRAMSELU.Entidades;

namespace BRAMSELU
{
    public partial class frmCitas : Form
    {
        CitaDAL comp = new CitaDAL();

        int idSeleccionado = 0;
        bool modoEdicion = false;

        const string PLACEHOLDER_HORA = "Ej. 02:30 PM";
        const string PLACEHOLDER_DURACION = "Ej. 30 min o 1 Hora";
        const string PLACEHOLDER_PRECIO = "Ej. 0.00";
        const string PLACEHOLDER_NOTAS = "Escriba observaciones aquí...";

        public frmCitas()
        {
            InitializeComponent();
        }

        private void frmCitas_Load(object sender, EventArgs e)
        {
            CargarDatos();
            BloquearCampos(true);
            ActualizarBotones(false);
            InicializarPlaceholders();

            CmbEstado.Items.Clear();
            CmbEstado.Items.Add("Pendiente");
            CmbEstado.Items.Add("Confirmada");
            CmbEstado.Items.Add("Completada");
            CmbEstado.Items.Add("Cancelada");
            CmbEstado.SelectedIndex = 0;

            try
            {
                ClienteDatos clienteDAL = new ClienteDatos();
                LlenarComboBox(CmbCliente, clienteDAL.MostrarClientes(), "Nombre", "IdCliente");


                EmpleadoBLL empleadoBLL = new EmpleadoBLL();

                List<Empleado> empleados = empleadoBLL.ObtenerEmpleados();

                DataTable tablaEmpleados = new DataTable();

                tablaEmpleados.Columns.Add("IdEmpleado");
                tablaEmpleados.Columns.Add("Nombre");

                foreach (Empleado emp in empleados)
                {
                    tablaEmpleados.Rows.Add(emp.IdEmpleado, emp.Nombre);
                }

                LlenarComboBox(CmbEspecialista, tablaEmpleados, "Nombre", "IdEmpleado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las listas de selección: " + ex.Message,
                                "Error de inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos(DataTable tabla = null)
        {
            dgvCitas.DataSource = tabla ?? comp.Mostrar();
        }

        private void BloquearCampos(bool bloquear)
        {
            bool h = !bloquear;
            CmbCliente.Enabled = h;
            TxtTelefono.Enabled = h;
            CmbServicio.Enabled = h;
            CmbEspecialista.Enabled = h;
            DtpFecha.Enabled = h;
            TxtHora.Enabled = h;
            TxtDuracion.Enabled = h;
            TxtPrecio.Enabled = h;
            TxtNotas.Enabled = h;
            CmbEstado.Enabled = h;
        }

        private void ActualizarBotones(bool conRegistro)
        {
            BtnEditar.Enabled = conRegistro;
            BtnEliminar.Enabled = conRegistro;
            BtnGuardar.Enabled = false;
        }

        private void InicializarPlaceholders()
        {
            ConfigurarPlaceholder(TxtHora, PLACEHOLDER_HORA);
            ConfigurarPlaceholder(TxtDuracion, PLACEHOLDER_DURACION);
            ConfigurarPlaceholder(TxtPrecio, PLACEHOLDER_PRECIO);
            ConfigurarPlaceholder(TxtNotas, PLACEHOLDER_NOTAS);
        }

        private void ConfigurarPlaceholder(TextBox txt, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(txt.Text) || txt.Text == placeholder)
            {
                txt.Text = placeholder;
                txt.ForeColor = Color.Gray;
            }
        }

        private void QuitarPlaceholder(TextBox txt, string placeholder)
        {
            if (txt.Text == placeholder)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void LimpiarCampos()
        {
            CmbCliente.SelectedIndex = -1;
            TxtTelefono.Clear();
            CmbServicio.SelectedIndex = -1;
            CmbEspecialista.SelectedIndex = -1;
            DtpFecha.Value = DateTime.Now;
            CmbEstado.SelectedIndex = -1;
            idSeleccionado = 0;

            InicializarPlaceholders();
        }

        private ClaseCitas ObtenerCitaDelFormulario()
        {
            string hora = TxtHora.Text == PLACEHOLDER_HORA ? "" : TxtHora.Text.Trim();
            string duracion = TxtDuracion.Text == PLACEHOLDER_DURACION ? "" : TxtDuracion.Text.Trim();
            string notas = TxtNotas.Text == PLACEHOLDER_NOTAS ? "" : TxtNotas.Text.Trim();
            string precioTexto = TxtPrecio.Text == PLACEHOLDER_PRECIO ? "0" : TxtPrecio.Text.Trim();

            decimal.TryParse(precioTexto, out decimal precio);

            return new ClaseCitas
            {
                ID = idSeleccionado,
                Cliente = CmbCliente.SelectedValue?.ToString() ?? "",
                Telefono = TxtTelefono.Text.Trim(),
                Servicio = CmbServicio.SelectedValue?.ToString() ?? "",
                Especialista = CmbEspecialista.SelectedValue?.ToString() ?? "",
                Fecha = DtpFecha.Value,
                Hora = hora,
                Duracion = duracion,
                Notas = notas,
                Estado = CmbEstado.SelectedItem?.ToString() ?? "Pendiente",
                Precio = precio
            };
        }

        private bool ValidarCampos()
        {
            if (CmbCliente.SelectedIndex == -1 ||
                CmbServicio.SelectedIndex == -1 ||
                TxtHora.Text == PLACEHOLDER_HORA || string.IsNullOrWhiteSpace(TxtHora.Text))
            {
                MessageBox.Show("Cliente, Servicio y Hora son campos obligatorios.",
                                "Campos requeridos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            BloquearCampos(false);
            modoEdicion = false;
            BtnGuardar.Enabled = true;
            BtnEditar.Enabled = false;
            BtnEliminar.Enabled = false;
            CmbCliente.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona una cita en la tabla primero.",
                                "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            BloquearCampos(false);
            modoEdicion = true;
            BtnGuardar.Enabled = true;
            CmbCliente.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                ClaseCitas cita = ObtenerCitaDelFormulario();

                if (modoEdicion)
                    comp.Modificar(cita);
                else
                    comp.Guardar(cita);

                MessageBox.Show("Cita guardada correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarDatos();
                LimpiarCampos();
                BloquearCampos(true);
                BtnGuardar.Enabled = false;
                BtnEditar.Enabled = false;
                BtnEliminar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona una cita en la tabla primero.",
                                "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Estás seguro de que deseas eliminar esta cita?",
                                "Confirmar eliminación",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    comp.Eliminar(idSeleccionado);
                    MessageBox.Show("Cita eliminada correctamente.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatos();
                    LimpiarCampos();
                    BloquearCampos(true);
                    ActualizarBotones(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();

            DataTable resultado = string.IsNullOrEmpty(texto)
                ? comp.Mostrar()
                : comp.Buscar(texto);

            if (resultado.Rows.Count == 0)
                MessageBox.Show("No se encontraron citas coincidentes.",
                                "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarDatos(resultado);
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvCitas.Rows[e.RowIndex];

            idSeleccionado = Convert.ToInt32(fila.Cells["IdCita"].Value);

            CmbCliente.SelectedValue = fila.Cells["IdCliente"].Value;
            TxtTelefono.Text = fila.Cells["Telefono"].Value?.ToString() ?? "";
            CmbServicio.SelectedValue = fila.Cells["IdServicio"].Value;
            CmbEspecialista.SelectedValue = fila.Cells["IdEspecialista"].Value;
            DtpFecha.Value = Convert.ToDateTime(fila.Cells["Fecha"].Value);

            TxtHora.Text = fila.Cells["Hora"].Value?.ToString() ?? "";
            TxtHora.ForeColor = Color.Black;

            TxtDuracion.Text = fila.Cells["Duracion"].Value?.ToString() ?? "";
            TxtDuracion.ForeColor = Color.Black;

            TxtPrecio.Text = fila.Cells["Precio"].Value?.ToString() ?? "";
            TxtPrecio.ForeColor = Color.Black;

            TxtNotas.Text = fila.Cells["Notas"].Value?.ToString() ?? "";
            TxtNotas.ForeColor = Color.Black;

            CmbEstado.SelectedItem = fila.Cells["EstadoCita"].Value?.ToString();

            BloquearCampos(true);
            ActualizarBotones(true);
            BtnGuardar.Enabled = false;
        }
        private void LlenarComboBox(ComboBox combo, DataTable datos, string columnaMostrar, string columnaValor)
        {
            combo.DataSource = datos;
            combo.DisplayMember = columnaMostrar; 
            combo.ValueMember = columnaValor;     
            combo.SelectedIndex = -1;             
        }


        private void txtHora_Enter(object sender, EventArgs e) => QuitarPlaceholder(TxtHora, PLACEHOLDER_HORA);
        private void txtHora_Leave(object sender, EventArgs e) => ConfigurarPlaceholder(TxtHora, PLACEHOLDER_HORA);

        private void txtDuracion_Enter(object sender, EventArgs e) => QuitarPlaceholder(TxtDuracion, PLACEHOLDER_DURACION);
        private void txtDuracion_Leave(object sender, EventArgs e) => ConfigurarPlaceholder(TxtDuracion, PLACEHOLDER_DURACION);

        private void txtPrecio_Enter(object sender, EventArgs e) => QuitarPlaceholder(TxtPrecio, PLACEHOLDER_PRECIO);
        private void txtPrecio_Leave(object sender, EventArgs e) => ConfigurarPlaceholder(TxtPrecio, PLACEHOLDER_PRECIO);

        private void txtNotas_Enter(object sender, EventArgs e) => QuitarPlaceholder(TxtNotas, PLACEHOLDER_NOTAS);
        private void txtNotas_Leave(object sender, EventArgs e) => ConfigurarPlaceholder(TxtNotas, PLACEHOLDER_NOTAS);

       
    }
}
