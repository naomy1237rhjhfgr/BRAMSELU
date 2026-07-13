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
        private string accion = "";

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
            errorProvider1.Clear();
            btnEditar.Text = "Editar";
        }

        private void iniciarbarra(string accionElegida)
        {
            accion = accionElegida;
            progressBarempleados.Value = 0;
            progressBarempleados.Visible = true;
            timer1.Start();
        }

        private bool Validar()
        {
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "Escriba el nombre");
                return false;
            }
            if (!SoloLetras(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "El nombre solo debe contener letras");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                errorProvider1.SetError(txtApellido, "Escriba el apellido");
                return false;
            }
            if (!SoloLetras(txtApellido.Text))
            {
                errorProvider1.SetError(txtApellido, "El apellido solo debe contener letras");
                return false;
            }

            if (txtIdentidad.Text.Replace("-", "").Trim().Length < 13)
            {
                errorProvider1.SetError(txtIdentidad, "Ingrese una identidad válida");
                return false;
            }

            if (empleadoBLL.ExisteIdentidad(txtIdentidad.Text, idSeleccionado))
            {
                errorProvider1.SetError(txtIdentidad, "Esta identidad ya está registrada");
                return false;
            }

            if (txtTelefono.Text.Replace("-", "").Trim().Length < 8)
            {
                errorProvider1.SetError(txtTelefono, "Ingrese un teléfono válido");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text) || !txtCorreo.Text.Contains("@"))
            {
                errorProvider1.SetError(txtCorreo, "Ingrese un correo válido");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                errorProvider1.SetError(txtUsuario, "El usuario es obligatorio");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                errorProvider1.SetError(txtContrasena, "La contraseña es obligatoria");
                return false;
            }

            if (cmbTipoUsuario.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbTipoUsuario, "Seleccione un tipo de usuario");
                return false;
            }

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

            iniciarbarra("guardar");

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un empleado de la tabla primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNombre.Enabled == false)
            {
                BloquearCampos(false);
                btnEditar.Text = "Actualizar";
            }
            else
            {
                if (!Validar())
                    return;

                iniciarbarra("guardar");
                btnEditar.Text = "Editar";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione el empleado que desea eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este empleado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                iniciarbarra("eliminar");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Por favor, ingrese un criterio de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscar.Focus();
                return;
            }

            iniciarbarra("buscar");
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                CargarDatos();
            }
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            CargarDatos();
            Limpiar();
            BloquearCampos(true);
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

            BloquearCampos(true);
            btnEditar.Text = "Editar";
        }

        private void GuardarEmpleado()
        {
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

        private void BuscarEmpleado()
        {
            dgvDatos.DataSource = empleadoBLL.BuscarEmpleado(txtBuscar.Text);
        }

        private void EliminarEmpleado()
        {
            if (idSeleccionado != 0 && empleadoBLL.EliminarEmpleado(idSeleccionado))
            {
                MessageBox.Show("Empleado eliminado");
                CargarDatos();
                Limpiar();
                BloquearCampos(true);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBarempleados.Increment(5);

            if (progressBarempleados.Value >= 100)
            {
                timer1.Stop();
                progressBarempleados.Visible = false;

                switch (accion)
                {
                    case "guardar":
                        GuardarEmpleado();
                        break;

                    case "buscar":
                        BuscarEmpleado();
                        break;

                    case "eliminar":
                        EliminarEmpleado();
                        break;
                }
            }
        }

     
    }
}