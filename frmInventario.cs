using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BRAMSELU
{
    public partial class frmInventario : Form
    {
        private Conexion conexion = new Conexion();
        private bool modoEdicion = false;

        public frmInventario()
        {
            InitializeComponent();
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                // TODO: Reemplazar por el SELECT real de Productos cuando exista la tabla en SQL Server.
                string query = "SELECT * FROM Productos";

                using (SqlCommand cmd = new SqlCommand(query, conexion.Abrir()))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDatos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Cerrar();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            modoEdicion = false;
            // TODO: limpiar campos / habilitar formulario para captura de nuevo registro de Productos.
            MessageBox.Show("Aquí se habilita el formulario para registrar un nuevo elemento.", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro de la tabla para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            modoEdicion = true;
            // TODO: cargar los datos de la fila seleccionada en los campos del formulario.
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro de la tabla para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmar = MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            try
            {
                // TODO: reemplazar por el DELETE real usando el Id de la fila seleccionada.
                MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: reemplazar por el INSERT o UPDATE real según 'modoEdicion', usando parámetros (@param).
                MessageBox.Show("Registro guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
