using BRAMSELU.BLL;
using BRAMSELU.Entidades;
using BRAMSELU.Mensajes;
using System;
using System.Data;
using System.Windows.Forms;

namespace BRAMSELU
{
    public partial class frmCitas : Form
    {
        private CitaBLL citaBLL = new CitaBLL();

        // Variables de control estandarizadas (como en Inventario)
        private int idSeleccionado = 0;
        private string accion = "";

        public frmCitas()
        {
            InitializeComponent();
            this.Load += frmCitas_Load;
        }

        private void frmCitas_Load(object sender, EventArgs e)
        {
            // Formato de hora
            dtpHora.Format = DateTimePickerFormat.Custom;
            dtpHora.CustomFormat = "hh:mm tt";
            dtpHora.ShowUpDown = true;

            CargarComboBoxes();
            CargarTablaCitas();

            Limpiar();
            BloquearCampos(true); // Iniciamos con los campos bloqueados
        }

        private void CargarTablaCitas()
        {
            dgvCitas.DataSource = null;
            dgvCitas.DataSource = citaBLL.ListarCitas();

            if (dgvCitas.Columns.Contains("IdCliente")) dgvCitas.Columns["IdCliente"].Visible = false;
            if (dgvCitas.Columns.Contains("IdServicio")) dgvCitas.Columns["IdServicio"].Visible = false;
            if (dgvCitas.Columns.Contains("IdEmpleado")) dgvCitas.Columns["IdEmpleado"].Visible = false;

            // Formato de moneda para el precio
            if (dgvCitas.Columns.Contains("Precio"))
            {
                dgvCitas.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCitas.Columns["Precio"].DefaultCellStyle.Format = "N2";
            }

            dgvCitas.ClearSelection();
        }

        private void CargarComboBoxes()
        {
            try
            {
                // CLIENTES
                cmbCliente.DataSource = citaBLL.ListarClientes();
                cmbCliente.DisplayMember = "Nombre";
                cmbCliente.ValueMember = "IdCliente";
                cmbCliente.SelectedIndex = -1;

                // SERVICIOS
                cmbServicio.DataSource = citaBLL.ListarServicios();
                cmbServicio.DisplayMember = "NombreServicio";
                cmbServicio.ValueMember = "IdServicio";
                cmbServicio.SelectedIndex = -1;

                // EMPLEADOS
                cmbEmpleado.DataSource = citaBLL.ListarEmpleados();
                cmbEmpleado.DisplayMember = "Nombre";
                cmbEmpleado.ValueMember = "IdEmpleado";
                cmbEmpleado.SelectedIndex = -1;

                // ESTADOS
                cmbEstado.Items.Clear();
                cmbEstado.Items.Add("Pendiente");
                cmbEstado.Items.Add("Confirmada");
                cmbEstado.Items.Add("Cancelada");
                cmbEstado.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Bloquea o desbloquea los controles de entrada (como en Inventario)
        private void BloquearCampos(bool bloquear)
        {
            bool h = !bloquear;
            cmbCliente.Enabled = h;
            cmbServicio.Enabled = h;
            cmbEmpleado.Enabled = h;
            dtpFecha.Enabled = h;
            dtpHora.Enabled = h;
            cmbEstado.Enabled = h;
            txtPrecio.Enabled = h;

            txtIdCita.Enabled = false; // El ID siempre debe estar bloqueado

            // Control de botones
            btnGuardar.Enabled = h;
            btnNuevo.Enabled = bloquear;
        }

        private void Limpiar()
        {
            errorProvider1.Clear();
            txtIdCita.Clear();
            cmbCliente.SelectedIndex = -1;
            cmbServicio.SelectedIndex = -1;
            cmbEmpleado.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            dtpHora.Value = DateTime.Now;
            cmbEstado.SelectedIndex = -1;
            txtPrecio.Clear();

            idSeleccionado = 0;
            btnEditar.Text = "Editar";
        }

        private bool Validar()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (cmbCliente.SelectedIndex == -1 || cmbCliente.SelectedValue == null)
            {
                errorProvider1.SetError(cmbCliente, "Seleccione un cliente");
                valido = false;
            }

            if (cmbServicio.SelectedIndex == -1 || cmbServicio.SelectedValue == null)
            {
                errorProvider1.SetError(cmbServicio, "Seleccione un servicio");
                valido = false;
            }

            if (cmbEmpleado.SelectedIndex == -1 || cmbEmpleado.SelectedValue == null)
            {
                errorProvider1.SetError(cmbEmpleado, "Seleccione un especialista");
                valido = false;
            }

            if (cmbEstado.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbEstado, "Seleccione el estado de la cita");
                valido = false;
            }

            if (ObtenerPrecioDecimal() <= 0)
            {
                errorProvider1.SetError(txtPrecio, "Ingrese un precio válido mayor a 0");
                valido = false;
            }

            return valido;
        }

        private decimal ObtenerPrecioDecimal()
        {
            string limpio = txtPrecio.Text.Replace("L.", "").Trim();
            decimal.TryParse(limpio, out decimal precio);
            return precio;
        }

        private void iniciarBarra(string accionElegida)
        {
            accion = accionElegida;
            progressBarCitas.Value = 0;
            progressBarCitas.Visible = true;
            timerCitas.Start();
        }

        // Lógica unificada para Guardar o Actualizar
        private void GuardarCita()
        {
            ClaseCitas cita = new ClaseCitas
            {
                IdCita = idSeleccionado,
                IdCliente = cmbCliente.SelectedValue.ToString(),
                IdServicio = Convert.ToInt32(cmbServicio.SelectedValue),
                IdEmpleado = Convert.ToInt32(cmbEmpleado.SelectedValue),
                Fecha = dtpFecha.Value,
                Hora = dtpHora.Value.TimeOfDay,
                Estado = cmbEstado.Text,
                Precio = ObtenerPrecioDecimal()
            };

            if (idSeleccionado == 0) // Si el ID es 0, es un registro nuevo
            {
                if (citaBLL.GuardarCita(cita))
                    GestorMensajes.Exito("Cita guardada correctamente.");
                else
                    GestorMensajes.Error("No se pudo guardar la información.");
            }
            else // Si hay un ID, es una actualización
            {
                if (citaBLL.ActualizarCita(cita))
                    GestorMensajes.Exito("Cita actualizada correctamente.");
                else
                    GestorMensajes.Error("No se pudo actualizar la información.");
            }

            CargarTablaCitas();
            Limpiar();
            BloquearCampos(true);
        }

        private void EliminarCita()
        {
            if (idSeleccionado != 0 && citaBLL.EliminarCita(idSeleccionado))
            {
                GestorMensajes.Exito("Cita eliminada correctamente.");
                CargarTablaCitas();
                Limpiar();
                BloquearCampos(true);
            }
            else
            {
                GestorMensajes.Error("No se pudo eliminar la cita.");
            }
        }

        private void BuscarCita()
        {
            string texto = txtBuscar.Text.Trim();
            DataTable tabla = citaBLL.ListarCitas();
            DataView vista = tabla.DefaultView;

            // Recuerda asegurarte de que tu consulta SQL devuelva la columna "Cliente"
            vista.RowFilter = $"Cliente LIKE '%{texto}%' OR Estado LIKE '%{texto}%'";
            dgvCitas.DataSource = vista;
        }

        // --- EVENTOS DE BOTONES ---

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            BloquearCampos(false);
            cmbCliente.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;
            iniciarBarra("guardar");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                GestorMensajes.Advertencia("Seleccione una cita en la tabla primero.");
                return;
            }

            if (!cmbCliente.Enabled) // Si los campos están bloqueados, los abrimos para edición
            {
                BloquearCampos(false);
                btnEditar.Text = "Actualizar";
            }
            else // Si ya estaban abiertos, validamos y guardamos (actualizamos)
            {
                if (!Validar()) return;

                iniciarBarra("guardar");
                btnEditar.Text = "Editar";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                GestorMensajes.Advertencia("Seleccione la cita que desea eliminar.");
                return;
            }

            DialogResult respuesta = GestorMensajes.Confirmacion("¿Está seguro que desea eliminar esta cita?");
            if (respuesta == DialogResult.Yes)
            {
                iniciarBarra("eliminar");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                GestorMensajes.Advertencia("Ingrese un texto para iniciar la búsqueda.");
                txtBuscar.Focus();
                return;
            }
            iniciarBarra("buscar");
        }

        // --- OTROS EVENTOS (Grid, TextBox, Timer) ---

        private void dgvCitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvCitas.Rows[e.RowIndex];

            idSeleccionado = Convert.ToInt32(fila.Cells["IdCita"].Value);
            txtIdCita.Text = idSeleccionado.ToString();

            if (fila.Cells["IdCliente"].Value != DBNull.Value)
                cmbCliente.SelectedValue = fila.Cells["IdCliente"].Value.ToString();

            if (fila.Cells["IdServicio"].Value != DBNull.Value)
                cmbServicio.SelectedValue = Convert.ToInt32(fila.Cells["IdServicio"].Value);

            if (fila.Cells["IdEmpleado"].Value != DBNull.Value)
                cmbEmpleado.SelectedValue = Convert.ToInt32(fila.Cells["IdEmpleado"].Value);

            dtpFecha.Value = Convert.ToDateTime(fila.Cells["Fecha"].Value);

            if (TimeSpan.TryParse(fila.Cells["Hora"].Value.ToString(), out TimeSpan hora))
                dtpHora.Value = DateTime.Today.Add(hora);

            cmbEstado.Text = fila.Cells["Estado"].Value.ToString();

            decimal precio = Convert.ToDecimal(fila.Cells["Precio"].Value);
            txtPrecio.Text = string.Format("L. {0:N2}", precio);

            // Al seleccionar, bloqueamos los campos hasta que presione "Editar"
            BloquearCampos(true);
            btnEditar.Text = "Editar";
        }

        private void timerCitas_Tick(object sender, EventArgs e)
        {
            progressBarCitas.Increment(5);

            if (progressBarCitas.Value >= 100)
            {
                timerCitas.Stop();
                progressBarCitas.Visible = false;

                switch (accion)
                {
                    case "guardar":
                        GuardarCita();
                        break;
                    case "eliminar":
                        EliminarCita();
                        break;
                    case "buscar":
                        BuscarCita();
                        break;
                }
            }
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPrecio.Text.Replace("L.", "").Trim(), out decimal precio))
            {
                txtPrecio.Text = string.Format("L. {0:N2}", precio);
            }
        }

        private void txtPrecio_Enter(object sender, EventArgs e)
        {
            txtPrecio.Text = txtPrecio.Text.Replace("L.", "").Trim();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}