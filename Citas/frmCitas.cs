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
        private bool editando = false;
        private string accion = "";

        private ClaseCitas citaActual;
        private int idCitaEliminar;

        public frmCitas()
        {
            InitializeComponent();
            this.Load += frmCitas_Load;
        }

        private void frmCitas_Load(object sender, EventArgs e)
        {
            dtpHora.Format = DateTimePickerFormat.Custom;
            dtpHora.CustomFormat = "hh:mm tt";
            dtpHora.ShowUpDown = true;


            CargarTablaCitas();

            CargarComboBoxes();


            LimpiarCampos();

            EstadoCampos();
        }

        private void CargarTablaCitas()
        {
            dgvCitas.DataSource = null;
            dgvCitas.DataSource = citaBLL.ListarCitas();

            if (dgvCitas.Columns.Contains("IdCliente")) dgvCitas.Columns["IdCliente"].Visible = false;
            if (dgvCitas.Columns.Contains("IdServicio")) dgvCitas.Columns["IdServicio"].Visible = false;
            if (dgvCitas.Columns.Contains("IdEmpleado")) dgvCitas.Columns["IdEmpleado"].Visible = false;
        }

        private void LimpiarCampos()
        {
            txtIdCita.Clear();

            cmbCliente.SelectedIndex = -1;
            cmbServicio.SelectedIndex = -1;
            cmbEmpleado.SelectedIndex = -1;

            dtpFecha.Value = DateTime.Now;
            dtpHora.Value = DateTime.Now;

            cmbEstado.SelectedIndex = -1;

            txtPrecio.Clear();

            editando = false;
            btnEditar.Text = "Editar";

            EstadoCampos(false);
        }

        private void EstadoCampos(bool habilitado = false)
        {
            txtIdCita.Enabled = false;

            cmbCliente.Enabled = habilitado;
            cmbServicio.Enabled = habilitado;
            cmbEmpleado.Enabled = habilitado;

            dtpFecha.Enabled = habilitado;
            dtpHora.Enabled = habilitado;

            cmbEstado.Enabled = habilitado;
            txtPrecio.Enabled = habilitado;
        }

        private bool ValidarCampos()
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

        private ClaseCitas ObtenerDatos()
        {
            ClaseCitas cita = new ClaseCitas();

            if (!string.IsNullOrEmpty(txtIdCita.Text))
                cita.IdCita = Convert.ToInt32(txtIdCita.Text);

            // IdCliente se maneja como string (VARCHAR)
            cita.IdCliente = cmbCliente.SelectedValue.ToString();
            cita.IdServicio = Convert.ToInt32(cmbServicio.SelectedValue);
            cita.IdEmpleado = Convert.ToInt32(cmbEmpleado.SelectedValue);
            cita.Fecha = dtpFecha.Value;
            cita.Hora = dtpHora.Value.TimeOfDay;
            cita.Estado = cmbEstado.Text;
            cita.Precio = ObtenerPrecioDecimal();

            return cita;
        }
        private void CargarComboBoxes()
        {
            try
            {
                // CLIENTES
                DataTable clientes = citaBLL.ListarClientes();

                cmbCliente.DataSource = clientes;
                cmbCliente.DisplayMember = "Nombre";
                cmbCliente.ValueMember = "IdCliente";
                cmbCliente.SelectedIndex = -1;


                // SERVICIOS
                DataTable servicios = citaBLL.ListarServicios();

                cmbServicio.DataSource = servicios;
                cmbServicio.DisplayMember = "NombreServicio";
                cmbServicio.ValueMember = "IdServicio";
                cmbServicio.SelectedIndex = -1;


                // EMPLEADOS
                DataTable empleados = citaBLL.ListarEmpleados();

                cmbEmpleado.DataSource = empleados;
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

        private decimal ObtenerPrecioDecimal()
        {
            string limpio = txtPrecio.Text.Replace("L.", "").Trim();
            decimal.TryParse(limpio, out decimal precio);
            return precio;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();

            EstadoCampos(true);

            cmbCliente.Focus();

            dgvCitas.ClearSelection();

            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;


            ClaseCitas cita = ObtenerDatos();

            citaActual = cita;

            iniciarBarra("guardar");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (editando)
            {
                if (!ValidarCampos())
                    return;


                ClaseCitas cita = ObtenerDatos();

                cita.IdCita = Convert.ToInt32(txtIdCita.Text);

                citaActual = cita;

                iniciarBarra("guardar");

                return;
            }


            if (dgvCitas.SelectedRows.Count == 0)
            {
                GestorMensajes.Advertencia(
                    "Seleccione una cita para editar."
                );

                return;
            }


            DataGridViewRow fila = dgvCitas.SelectedRows[0];


            txtIdCita.Text =
                fila.Cells["IdCita"].Value.ToString();


            cmbCliente.SelectedValue =
                fila.Cells["IdCliente"].Value.ToString();


            cmbServicio.SelectedValue =
                Convert.ToInt32(
                    fila.Cells["IdServicio"].Value
                );


            cmbEmpleado.SelectedValue =
                Convert.ToInt32(
                    fila.Cells["IdEmpleado"].Value
                );


            dtpFecha.Value =
                Convert.ToDateTime(
                    fila.Cells["Fecha"].Value
                );


            dtpHora.Value =
                DateTime.Today.Add(
                    TimeSpan.Parse(
                        fila.Cells["Hora"].Value.ToString()
                    )
                );


            cmbEstado.Text =
                fila.Cells["Estado"].Value.ToString();


            txtPrecio.Text =
                fila.Cells["Precio"].Value.ToString();



            editando = true;

            EstadoCampos(true);

            btnEditar.Text = "Actualizar";

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                GestorMensajes.Advertencia(
                    "Seleccione una cita antes de eliminar."
                );

                return;
            }


            DataGridViewRow fila =
                dgvCitas.SelectedRows[0];


            int id =
                Convert.ToInt32(
                    fila.Cells["IdCita"].Value
                );


            DialogResult resultado =
                GestorMensajes.Confirmacion(
                    "¿Desea eliminar esta cita?"
                );


            if (resultado == DialogResult.Yes)
            {
                idCitaEliminar = id;

                iniciarBarra("eliminar");
            }
        }

        private void dgvCitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvCitas.Rows[e.RowIndex];

            txtIdCita.Text = fila.Cells[0].Value.ToString();

            // Asignación de ComboBoxes por SelectedValue
            if (fila.Cells[1].Value != DBNull.Value)
                cmbCliente.SelectedValue = fila.Cells[1].Value.ToString();

            if (fila.Cells[3].Value != DBNull.Value)
                cmbServicio.SelectedValue = Convert.ToInt32(fila.Cells[3].Value);

            if (fila.Cells[5].Value != DBNull.Value)
                cmbEmpleado.SelectedValue = Convert.ToInt32(fila.Cells[5].Value);

            dtpFecha.Value = Convert.ToDateTime(fila.Cells[7].Value);

            if (TimeSpan.TryParse(fila.Cells[8].Value.ToString(), out TimeSpan hora))
            {
                dtpHora.Value = DateTime.Today.Add(hora);
            }

            cmbEstado.Text = fila.Cells[9].Value.ToString();

            decimal precio = Convert.ToDecimal(fila.Cells[10].Value);
            txtPrecio.Text = string.Format("L. {0:N2}", precio);

            EstadoCampos();
            btnGuardar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
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
        private void GuardarCita(ClaseCitas cita)
        {
            if (editando)
            {
                if (citaBLL.ActualizarCita(cita))
                {
                    GestorMensajes.Exito(
                        "Cita actualizada correctamente."
                    );
                }
                else
                {
                    GestorMensajes.Error(
                        "No se pudo actualizar la cita."
                    );
                }
            }
            else
            {
                if (citaBLL.GuardarCita(cita))
                {
                    GestorMensajes.Exito(
                        "Cita guardada correctamente."
                    );
                }
                else
                {
                    GestorMensajes.Error(
                        "No se pudo guardar la cita."
                    );
                }
            }


            CargarTablaCitas();

            LimpiarCampos();

            dgvCitas.ClearSelection();

        }
        private void EliminarCita(int id)
        {
            if (citaBLL.EliminarCita(id))
            {
                GestorMensajes.Exito(
                    "Cita eliminada correctamente."
                );

                CargarTablaCitas();

                LimpiarCampos();

                dgvCitas.ClearSelection();
            }
            else
            {
                GestorMensajes.Error(
                    "No se pudo eliminar la cita."
                );
            }
        }
        private void iniciarBarra(string accionElegida)
        {
            accion = accionElegida;

            progressBarCitas.Value = 0;

            progressBarCitas.Visible = true;

            timerCitas.Start();
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

                        GuardarCita(citaActual);

                        break;


                    case "eliminar":

                        EliminarCita(idCitaEliminar);

                        break;
                }
            }
        }
    }
}