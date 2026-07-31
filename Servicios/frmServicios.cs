using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRAMSELU.Servicios;
using BRAMSELU.Mensajes;

namespace BRAMSELU
{
    public partial class frmServicios : Form
    {
        private ServicioBLL servicioBLL = new ServicioBLL();
        private int idservicios = 0;
        private bool editando = false;

        private string accion = "";
        private Servicio servicioActual;
        private int idServicioEliminar;
        private string textoBuscar;

        public frmServicios()
        {
            InitializeComponent();
            EstadoCampos(false);
        }

        private void EstadoCampos(bool habilitado)
        {
            txtIdservicio.Enabled = false;

            txtnombreservicio.Enabled = habilitado;
            txtdescripcionservicio.Enabled = habilitado;
            txtprecioservicio.Enabled = habilitado;
            txtduracionservicio.Enabled = habilitado;
            comboBoxestadoservicio.Enabled = habilitado;
        }

        private void LimpiarCampos()
        {
            txtIdservicio.Clear();
            txtnombreservicio.Clear();
            txtdescripcionservicio.Clear();
            txtprecioservicio.Clear();
            txtduracionservicio.Clear();

            comboBoxestadoservicio.SelectedIndex = -1;

            idservicios = 0;
            editando = false;

            minutosahoras.Text = "";
            minutosahoras.Visible = false;

            EstadoCampos(false);
            bttneditarservicio.Text = "Editar";
        }

        private void CargarServicios()
        {
            dataGridViewservicio.DataSource = servicioBLL.ObtenerServicios();

            dataGridViewservicio.ClearSelection();
            LimpiarCampos();
        }

        private void frmServicios_Load(object sender, EventArgs e)
        {
            CargarServicios();
        }

        private void Btnnuevoservicio_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            EstadoCampos(true);
            txtnombreservicio.Focus();
            dataGridViewservicio.ClearSelection();

        }

        private void btnguardarservicio_Click(object sender, EventArgs e)
        {
            Servicio servicio = new Servicio();

            if (string.IsNullOrWhiteSpace(txtnombreservicio.Text))
            {
                GestorMensajes.Advertencia("Ingrese el nombre del servicio.");
                txtnombreservicio.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtdescripcionservicio.Text))
            {
                GestorMensajes.Advertencia("Ingrese la descripción.");
                txtdescripcionservicio.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtprecioservicio.Text))
            {
                GestorMensajes.Advertencia("Ingrese el precio.");
                txtprecioservicio.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtduracionservicio.Text))
            {
                GestorMensajes.Advertencia("Ingrese la duración.");
                txtduracionservicio.Focus();
                return;
            }

            if (comboBoxestadoservicio.SelectedIndex == -1)
            {
                GestorMensajes.Advertencia("Seleccione el estado.");
                comboBoxestadoservicio.Focus();
                return;
            }

            if (!decimal.TryParse(txtprecioservicio.Text, out decimal precio))
            {
                GestorMensajes.Advertencia("Precio inválido.");
                txtprecioservicio.Focus();
                return;
            }

            if (!int.TryParse(txtduracionservicio.Text, out int duracion))
            {
                GestorMensajes.Advertencia("Duración inválida.");
                txtduracionservicio.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIdservicio.Text))
                servicio.IdServicio = 0;
            else
                servicio.IdServicio = Convert.ToInt32(txtIdservicio.Text);

            servicio.NombreServicio = txtnombreservicio.Text.Trim().Replace("  ", " ");
            servicio.Descripcion = txtdescripcionservicio.Text.Trim().Replace("  ", " ");
            servicio.Precio = precio;
            servicio.Duracion = duracion;
            servicio.Estado = comboBoxestadoservicio.SelectedIndex == 0;

            if (servicioBLL.ExisteServicio(servicio.NombreServicio, servicio.IdServicio))
            {
                GestorMensajes.Advertencia("Ya existe un servicio con ese nombre.");
                txtnombreservicio.Focus();
                return;
            }

            servicioActual = servicio;
            iniciarBarra("guardar");
        }

        private void iniciarBarra(string accionElegida)
        {
            accion = accionElegida;
            progressBarservicio.Value = 0;
            progressBarservicio.Visible = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBarservicio.Increment(5);

            if (progressBarservicio.Value >= 100)
            {
                timer1.Stop();
                progressBarservicio.Visible = false;

                switch (accion)
                {
                    case "guardar":
                        GuardarServicio(servicioActual);
                        break;

                    case "eliminar":
                        EliminarServicio(idServicioEliminar);
                        break;

                    case "buscar":
                        BuscarServicio(textoBuscar);
                        break;
                }
            }
        }

        private void GuardarServicio(Servicio servicio)
        {
            if (editando)
            {
                if (servicioBLL.ActualizarServicio(servicio))
                {
                    GestorMensajes.Exito("Servicio actualizado correctamente.");
                }
            }
            else
            {
                if (servicioBLL.GuardarServicio(servicio))
                {
                    GestorMensajes.Exito("Servicio guardado correctamente.");
                }
            }

            CargarServicios();
            txtBuscarservicio.Clear();
            dataGridViewservicio.ClearSelection();
            editando = false;
            idservicios = 0;
        }

        private void EliminarServicio(int id)
        {
            if (servicioBLL.EliminarServicio(id))
            {
                GestorMensajes.Exito("Servicio eliminado correctamente.");
                CargarServicios();

                txtIdservicio.Clear();
                txtnombreservicio.Clear();
                txtdescripcionservicio.Clear();
                txtprecioservicio.Clear();
                txtduracionservicio.Clear();
                comboBoxestadoservicio.SelectedIndex = -1;

                dataGridViewservicio.ClearSelection();
                txtBuscarservicio.Clear();

                editando = false;
                idservicios = 0;
            }
        }

        private void BuscarServicio(string dato)
        {
            if (string.IsNullOrWhiteSpace(dato))
            {
                CargarServicios();
            }
            else
            {
                DataTable resultado = servicioBLL.BuscarServicio(dato);

                if (resultado.Rows.Count > 0)
                {
                    dataGridViewservicio.DataSource = resultado;
                    dataGridViewservicio.ClearSelection();
                }
                else
                {
                    GestorMensajes.Informacion("No se encontró ningún servicio.");
                    CargarServicios();
                    txtBuscarservicio.Focus();
                    txtBuscarservicio.SelectAll();
                }
            }
        }

        private void dataGridViewservicio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridViewservicio.Rows[e.RowIndex];

                idservicios = Convert.ToInt32(fila.Cells["IdServicio"].Value);
                txtIdservicio.Text = fila.Cells["IdServicio"].Value.ToString();
                txtnombreservicio.Text = fila.Cells["NombreServicio"].Value.ToString();
                txtdescripcionservicio.Text = fila.Cells["Descripcion"].Value.ToString();
                txtprecioservicio.Text = fila.Cells["Precio"].Value.ToString();
                txtduracionservicio.Text = fila.Cells["Duracion"].Value.ToString();

                comboBoxestadoservicio.SelectedIndex =
                    Convert.ToBoolean(fila.Cells["Estado"].Value) ? 0 : 1;

                EstadoCampos(false);
                editando = false;
                bttneditarservicio.Text = "Editar";
            }
        }

        private void bttneditarservicio_Click(object sender, EventArgs e)
        {
            if (editando)
            {
                Servicio servicio = new Servicio();

                servicio.IdServicio = Convert.ToInt32(txtIdservicio.Text);
                servicio.NombreServicio = txtnombreservicio.Text.Trim().Replace("  ", " ");
                servicio.Descripcion = txtdescripcionservicio.Text.Trim().Replace("  ", " ");
                servicio.Precio = Convert.ToDecimal(txtprecioservicio.Text);
                servicio.Duracion = Convert.ToInt32(txtduracionservicio.Text);
                servicio.Estado = comboBoxestadoservicio.SelectedIndex == 0;

                servicioActual = servicio;
                iniciarBarra("guardar");
                return;
            }

            if (dataGridViewservicio.SelectedRows.Count == 0)
            {
                GestorMensajes.Advertencia("Seleccione un servicio para editar.");
                return;
            }

            EstadoCampos(true);

            txtnombreservicio.Focus();
            editando = true;
            bttneditarservicio.Text = "Actualizar";
        }

        private void bttneliminarservicio_Click(object sender, EventArgs e)
        {
            if (idservicios == 0)
            {
                GestorMensajes.Informacion("Seleccione un servicio para eliminar.");
                return;
            }

            DialogResult resultado = GestorMensajes.Confirmacion("¿Desea eliminar este servicio?");

            if (resultado == DialogResult.Yes)
            {
                idServicioEliminar = idservicios;
                iniciarBarra("eliminar");
            }
        }

        private void btnbuscarservicio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarservicio.Text))
            {
                GestorMensajes.Informacion("Ingrese un dato para buscar.");
                txtBuscarservicio.Focus();
                return;
            }

            textoBuscar = txtBuscarservicio.Text.Trim();
            iniciarBarra("buscar");
        }

        private void txtBuscarservicio_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscarservicio.Text))
            {
                CargarServicios();
                dataGridViewservicio.ClearSelection();
            }
        }

        private void txtduracionservicio_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtduracionservicio.Text))
            {
                minutosahoras.Text = "";
                minutosahoras.Visible = false;
                return;
            }

            if (int.TryParse(txtduracionservicio.Text, out int minutos))
            {
                int horas = minutos / 60;
                int minutosRestantes = minutos % 60;

                if (horas > 0)
                {
                    if (minutosRestantes > 0)
                        minutosahoras.Text = $"{horas} hora{(horas > 1 ? "s" : "")} {minutosRestantes} minuto{(minutosRestantes > 1 ? "s" : "")}";
                    else
                        minutosahoras.Text = $"{horas} hora{(horas > 1 ? "s" : "")}";
                }
                else
                {
                    minutosahoras.Text = $"{minutos} minuto{(minutos > 1 ? "s" : "")}";
                }

                minutosahoras.Visible = true;
            }
            else
            {
                minutosahoras.Text = "";
                minutosahoras.Visible = false;
            }
        }

        private void txtnombreservicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtprecioservicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == '.' && !txtprecioservicio.Text.Contains("."))
                return;

            e.Handled = true;
        }

        private void txtduracionservicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
        !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtdescripcionservicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) ||
        char.IsControl(e.KeyChar) ||
        char.IsWhiteSpace(e.KeyChar) ||
        e.KeyChar == '.' ||
        e.KeyChar == ',' ||
        e.KeyChar == '(' ||
        e.KeyChar == ')' ||
        e.KeyChar == '-')
            {
                return;
            }

            e.Handled = true;  
        }
    }
}
