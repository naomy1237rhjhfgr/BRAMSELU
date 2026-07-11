using System;
using System.Data;
using System.Windows.Forms;

namespace BRAMSELU
{
    public partial class FrmEmpleados : Form
    {
        private Empleadocomp empleado;
        int idSeleccionado = 0;

        public FrmEmpleados()
        {
            InitializeComponent();
            empleado = new Empleadocomp();
        }


        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            CargarDatos();
            BloquearCampos(true);
        }


        private void CargarDatos()
        {
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = empleado.Listar();
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


        private void Limpiar()
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


        private bool Validar()
        {
            errorProvider1.Clear();


            if (txtNombre.Text.Trim() == "")
            {
                errorProvider1.SetError(txtNombre,"Ingrese el nombre");
                return false;
            }

            if (!SoloLetras(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre,"Solo letras");
                return false;
            }


            if (txtApellido.Text.Trim()=="")
            {
                errorProvider1.SetError(txtApellido,"Ingrese apellido");
                return false;
            }

            if (!SoloLetras(txtApellido.Text))
            {
                errorProvider1.SetError(txtApellido,"Solo letras");
                return false;
            }


            if (txtIdentidad.Text.Trim()=="")
            {
                errorProvider1.SetError(txtIdentidad,"Ingrese identidad");
                return false;
            }


            if (!SoloNumeros(txtIdentidad.Text))
            {
                errorProvider1.SetError(txtIdentidad,"Solo números");
                return false;
            }


            if (txtTelefono.Text.Trim()=="")
            {
                errorProvider1.SetError(txtTelefono,"Ingrese teléfono");
                return false;
            }


            if (!SoloNumeros(txtTelefono.Text))
            {
                errorProvider1.SetError(txtTelefono,"Solo números");
                return false;
            }


            if (txtCorreo.Text.Trim()!="" && !txtCorreo.Text.Contains("@"))
            {
                errorProvider1.SetError(txtCorreo,"Correo inválido");
                return false;
            }


            if (txtUsuario.Text.Trim()=="")
            {
                errorProvider1.SetError(txtUsuario,"Ingrese usuario");
                return false;
            }


            if (txtContrasena.Text.Trim()=="")
            {
                errorProvider1.SetError(txtContrasena,"Ingrese contraseña");
                return false;
            }


            return true;
        }


        private bool SoloNumeros(string texto)
        {
            foreach(char c in texto)
            {
                if(!char.IsDigit(c))
                    return false;
            }

            return true;
        }


        private bool SoloLetras(string texto)
        {
            foreach(char c in texto)
            {
                if(!char.IsLetter(c) && c!=' ')
                    return false;
            }

            return true;
        }



        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
            



        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            BloquearCampos(false);
            txtNombre.Focus();
        }



        private void btnEditar_Click(object sender, EventArgs e)
      
        {
           
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un empleado de la lista primero.");
                return;
            }

          
            if (txtNombre.Enabled == false)
            {
                BloquearCampos(false); 
                txtNombre.Focus();     
                btnEditar.Text = "Actualizar"; 
            }

            
            else
            {
       
                if (!Validar())
                    return;

          
                empleado.IdEmpleado = idSeleccionado;
                empleado.Nombre = txtNombre.Text;
                empleado.Apellido = txtApellido.Text;
                empleado.Identidad = txtIdentidad.Text;
                empleado.Telefono = txtTelefono.Text;
                empleado.Direccion = txtDireccion.Text;
                empleado.Correo = txtCorreo.Text;
                empleado.Usuario = txtUsuario.Text;
                empleado.Contrasena = txtContrasena.Text;
                empleado.TipoUsuario = txtTipoUsuario.Text;

                
                if (empleado.Actualizar())
                {
                    MessageBox.Show("Empleado modificado con éxito");

                  
                    CargarDatos();
                    Limpiar();
                    BloquearCampos(true);
                    btnEditar.Text = "Editar"; 
                }
            }
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if(!Validar())
                return;


            empleado.IdEmpleado = idSeleccionado;
            empleado.Nombre = txtNombre.Text;
            empleado.Apellido = txtApellido.Text;
            empleado.Identidad = txtIdentidad.Text;
            empleado.Telefono = txtTelefono.Text;
            empleado.Direccion = txtDireccion.Text;
            empleado.Correo = txtCorreo.Text;
            empleado.Usuario = txtUsuario.Text;
            empleado.Contrasena = txtContrasena.Text;
            empleado.TipoUsuario = txtTipoUsuario.Text;



            if(idSeleccionado==0)
            {

                if(empleado.Guardar())
                    MessageBox.Show("Empleado guardado");

            }
            else
            {

                if(empleado.Actualizar())
                    MessageBox.Show("Empleado actualizado");

            }


            CargarDatos();
            Limpiar();
            BloquearCampos(true);

        }




        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if(idSeleccionado==0)
            {
                MessageBox.Show("Seleccione un empleado");
                return;
            }


            if(empleado.Eliminar())
            {
                MessageBox.Show("Empleado eliminado");

                CargarDatos();
                Limpiar();
                BloquearCampos(true);
            }

        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if(txtBuscar.Text.Trim()=="")
            {
                CargarDatos();
                return;
            }


            if(empleado.BuscarPorIdentidad(txtBuscar.Text))
            {

                CargarDatos();


                txtNombre.Text = empleado.Nombre;
                txtApellido.Text = empleado.Apellido;
                txtIdentidad.Text = empleado.Identidad;
                txtTelefono.Text = empleado.Telefono;
                txtDireccion.Text = empleado.Direccion;
                txtCorreo.Text = empleado.Correo;
                txtUsuario.Text = empleado.Usuario;
                txtContrasena.Text = empleado.Contrasena;
                txtTipoUsuario.Text = empleado.TipoUsuario;

                idSeleccionado = empleado.IdEmpleado;

            }
            else
            {
                MessageBox.Show("No se encontró el empleado");
            }

        }



        private void btnListar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }



        private void txtIdentidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled=true;
        }



        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled=true;
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; 

            DataGridViewRow fila = dgvDatos.Rows[e.RowIndex];

            
            idSeleccionado = Convert.ToInt32(fila.Cells[0].Value); 
            txtNombre.Text = fila.Cells[1].Value?.ToString() ?? "";
            txtApellido.Text = fila.Cells[2].Value?.ToString() ?? "";
            txtIdentidad.Text = fila.Cells[3].Value?.ToString() ?? "";
            txtTelefono.Text = fila.Cells[4].Value?.ToString() ?? "";
            txtDireccion.Text = fila.Cells[5].Value?.ToString() ?? "";
            txtCorreo.Text = fila.Cells[6].Value?.ToString() ?? "";
            txtUsuario.Text = fila.Cells[7].Value?.ToString() ?? "";
            txtContrasena.Text = fila.Cells[8].Value?.ToString() ?? "";
            txtTipoUsuario.Text = fila.Cells[9].Value?.ToString() ?? "";

            BloquearCampos(true); 
        }

    }
    }
