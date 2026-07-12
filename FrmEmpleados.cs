using System;
using System.Data;
using System.Windows.Forms;
using BRAMSELU.Entidades;
using BRAMSELU.BLL;
using System.Collections.Generic;

namespace BRAMSELU
{
    public partial class FrmEmpleados : Form
    {
        private EmpleadoBLL empleadoBLL;
        private int idSeleccionado = 0;

        public FrmEmpleados()
        {
            InitializeComponent();
            empleadoBLL = new EmpleadoBLL();
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            txtIdentidad.Mask = "0000-0000-00000";
            txtTelefono.Mask = "0000-0000";
            CargarDatos();
            BloquearCampos(true);
        }

        private void CargarDatos()
        {
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = empleadoBLL.ObtenerEmpleados();
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
            cmbTipoUsuario.Enabled = h;
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtIdentidad.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Clear();
            txtCorreo.Clear();
            txtUsuario.Clear();
            txtContrasena.Clear();
            cmbTipoUsuario.SelectedIndex = -1;
            idSeleccionado = 0;
        }

        private bool Validar()
        {
            errorProvider1.Clear();
            if (txtNombre.Text.Trim() == "" || !SoloLetras(txtNombre.Text)) return false;
            if (txtApellido.Text.Trim() == "" || !SoloLetras(txtApellido.Text)) return false;
            if (txtIdentidad.Text.Replace("-", "").Trim() == "" || txtIdentidad.Text.Length < 15) return false;
            if (txtTelefono.Text.Replace("-", "").Trim() == "" || txtTelefono.Text.Length < 9) return false;
            if (txtCorreo.Text.Trim() != "" && !txtCorreo.Text.Contains("@")) return false;
            if (txtUsuario.Text.Trim() == "") return false;
            if (txtContrasena.Text.Trim() == "") return false;
            if (cmbTipoUsuario.SelectedIndex == -1) return false;
            return true;
        }

        private bool SoloLetras(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsLetter(c) && c != ' ') return false;
            }
            return true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            BloquearCampos(false);
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            Empleado emp = new Empleado
            {
                IdEmpleado = idSeleccionado,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Identidad = txtIdentidad.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                Correo = txtCorreo.Text,
                Usuario = txtUsuario.Text,
                Contrasena = txtContrasena.Text,
                TipoUsuario = cmbTipoUsuario.Text
            };

            if (idSeleccionado == 0)
            {
                if (empleadoBLL.GuardarEmpleado(emp)) MessageBox.Show("Empleado guardado");
            }
            else
            {
                if (empleadoBLL.ActualizarEmpleado(emp)) MessageBox.Show("Empleado actualizado");
            }
            CargarDatos();
            Limpiar();
            BloquearCampos(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0) return;
            if (txtNombre.Enabled == false)
            {
                BloquearCampos(false);
                btnEditar.Text = "Actualizar";
            }
            else
            {
                btnGuardar_Click(sender, e);
                btnEditar.Text = "Editar";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado != 0 && empleadoBLL.EliminarEmpleado(idSeleccionado))
            {
                MessageBox.Show("Empleado eliminado");
                CargarDatos();
                Limpiar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvDatos.DataSource = empleadoBLL.BuscarEmpleado(txtBuscar.Text);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow fila = dgvDatos.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(fila.Cells[0].Value);
            txtNombre.Text = fila.Cells[1].Value.ToString();
            txtApellido.Text = fila.Cells[2].Value.ToString();
            txtIdentidad.Text = fila.Cells[3].Value.ToString();
            txtTelefono.Text = fila.Cells[4].Value.ToString();
            txtDireccion.Text = fila.Cells[5].Value.ToString();
            txtCorreo.Text = fila.Cells[6].Value.ToString();
            txtUsuario.Text = fila.Cells[7].Value.ToString();
            txtContrasena.Text = fila.Cells[8].Value.ToString();
            cmbTipoUsuario.Text = fila.Cells[9].Value.ToString();
        }
    }
}