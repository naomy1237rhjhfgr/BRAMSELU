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
    public partial class FrmEmpleados : Form
    {
        Empleadocomp comp = new Empleadocomp();
        int idSeleccionado = 0;
        bool modoEdicion = false;

        public FrmEmpleados()
        {
            InitializeComponent();
        }

     
        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            CargarDatos();
            BloquearCampos(true);
            ActualizarBotones(false);
        }

        private void CargarDatos(DataTable tabla = null)
        {
            dgvDatos.DataSource = tabla ?? comp.Mostrar();
        }

        private void BloquearCampos(bool bloquear)
        {
            bool h = !bloquear;
            txtNombre.Enabled = h;
            txtApellido.Enabled = h;
            txtIdentidad.Enabled = h;
            txtTelefono.Enabled = h;
            txtDireccion.Enabled = h;
            txtCorreo.Enabled = h;
            txtUsuario.Enabled = h;
            txtContrasena.Enabled = h;
            txtTipoUsuario.Enabled = h;
        }

        private void ActualizarBotones(bool conRegistro)
        {
            btnEditar.Enabled = conRegistro;
            btnEliminar.Enabled = conRegistro;
            btnGuardar.Enabled = false;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtIdentidad.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCorreo.Clear();
            txtUsuario.Clear();
            txtContrasena.Clear();
            txtTipoUsuario.Clear();
            idSeleccionado = 0;
        }

        private Empleado ObtenerEmpleadoDelFormulario()
        {
            return new Empleado
            {
                IdEmpleado = idSeleccionado,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Identidad = txtIdentidad.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Usuario = txtUsuario.Text.Trim(),
                Contrasena = txtContrasena.Text.Trim(),
                TipoUsuario = txtTipoUsuario.Text.Trim()
            };
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Nombre, Apellido, Usuario y Contraseña son obligatorios.",
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
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un empleado en la tabla primero.",
                                "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            BloquearCampos(false);
            modoEdicion = true;
            btnGuardar.Enabled = true;
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                Empleado emp = ObtenerEmpleadoDelFormulario();

                if (modoEdicion)
                    comp.Modificar(emp);
                else
                    comp.Guardar(emp);

                MessageBox.Show("Empleado guardado correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarDatos();
                LimpiarCampos();
                BloquearCampos(true);
                btnGuardar.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
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
                MessageBox.Show("Selecciona un empleado en la tabla primero.",
                                "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Estás seguro de que deseas eliminar este empleado?",
                                "Confirmar eliminación",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    comp.Eliminar(idSeleccionado);
                    MessageBox.Show("Empleado eliminado correctamente.",
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
                MessageBox.Show("No se encontraron empleados con ese numero de identidad.",
                                "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarDatos(resultado);
        }

       
        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvDatos.Rows[e.RowIndex];

            idSeleccionado = Convert.ToInt32(fila.Cells["IdEmpleado"].Value);
            txtNombre.Text = fila.Cells["Nombre"].Value?.ToString() ?? "";
            txtApellido.Text = fila.Cells["Apellido"].Value?.ToString() ?? "";
            txtIdentidad.Text = fila.Cells["Identidad"].Value?.ToString() ?? "";
            txtTelefono.Text = fila.Cells["Telefono"].Value?.ToString() ?? "";
            txtDireccion.Text = fila.Cells["Direccion"].Value?.ToString() ?? "";
            txtCorreo.Text = fila.Cells["Correo"].Value?.ToString() ?? "";
            txtUsuario.Text = fila.Cells["Usuario"].Value?.ToString() ?? "";
            txtContrasena.Text = fila.Cells["Contrasena"].Value?.ToString() ?? "";
            txtTipoUsuario.Text = fila.Cells["TipoUsuario"].Value?.ToString() ?? "";

            BloquearCampos(true);
            ActualizarBotones(true);
            btnGuardar.Enabled = false;
        }
    }
}

