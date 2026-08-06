using BRAMSELU.Categorias;
using System;
using System.Data;
using System.Windows.Forms;
using BRAMSELU.Mensajes;

namespace BRAMSELU
{
    public partial class frmCategorias : Form
    {
        private CategoriaBLL categoriaBLL = new CategoriaBLL();
        private int idCategoria = 0;
        private bool editando = false;
        private string accion = "";
        private Categoria categoriaActual;
        private int idCategoriaEliminar;
        private string textoBuscar;

        public frmCategorias()
        {
            InitializeComponent();

            dataGridViewcategoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewcategoria.MultiSelect = false;
            dataGridViewcategoria.AllowUserToAddRows = false;

            QuitarSeleccionCategoria();
            EstadoCampos(false);
        }

        private void CargarCategorias()
        {
            dataGridViewcategoria.DataSource = categoriaBLL.ObtenerCategorias();
            QuitarSeleccionCategoria();
        }

        private void CargarProductosPorCategoria(string categoria)
        {
            dataGridViewproCategorias.DataSource = categoriaBLL.ObtenerProductosPorCategoria(categoria);

            if (dataGridViewproCategorias.Columns.Contains("Precio"))
            {
                dataGridViewproCategorias.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dataGridViewproCategorias.ClearSelection();
        }

        private void QuitarSeleccionCategoria()
        {
            dataGridViewcategoria.ClearSelection();
            dataGridViewcategoria.CurrentCell = null;
        }

        private void EstadoCampos(bool habilitado)
        {
            txtidcategoria.Enabled = false;
            txtnombrecategoria.Enabled = habilitado;
            txtdescripcion.Enabled = habilitado;
        }

        private void LimpiarCampos()
        {
            txtidcategoria.Clear();
            txtnombrecategoria.Clear();
            txtdescripcion.Clear();

            idCategoria = 0;
            editando = false;

            EstadoCampos(false);
            bttneditarcategoria.Text = "Editar";
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            QuitarSeleccionCategoria();
            dataGridViewproCategorias.DataSource = null;
        }

        private void Btnnuevocategoria_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            EstadoCampos(true);
            txtnombrecategoria.Focus();
            QuitarSeleccionCategoria();
        }

        private void btnguardarcategoria_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();

            if (!txtnombrecategoria.Enabled)
            {
                GestorMensajes.Advertencia("Presione Nuevo o Editar antes de guardar");
                return;
            }

            if (editando && string.IsNullOrWhiteSpace(txtidcategoria.Text))
            {
                GestorMensajes.Advertencia("Seleccione una categoría antes de actualizar.");
                return;
            }

            categoria.IdCategoria = string.IsNullOrWhiteSpace(txtidcategoria.Text) ? 0 : Convert.ToInt32(txtidcategoria.Text);
            categoria.NombreCategoria = txtnombrecategoria.Text.Trim().Replace("  ", " ");
            categoria.Descripcion = txtdescripcion.Text.Trim().Replace("  ", " ");

            if (string.IsNullOrWhiteSpace(categoria.NombreCategoria))
            {
                GestorMensajes.Advertencia("Ingrese el nombre de la categoria");
                txtnombrecategoria.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(categoria.Descripcion))
            {
                GestorMensajes.Advertencia("Ingrese la descripción.");
                txtdescripcion.Focus();
                return;
            }

            if (categoriaBLL.ExisteCategoria(categoria.NombreCategoria, categoria.IdCategoria))
            {
                GestorMensajes.Advertencia("Ya existe una categoría con ese nombre.");
                txtnombrecategoria.Focus();
                return;
            }

            categoriaActual = categoria;
            iniciarBarra("guardar");
        }
        private void bttneditarcategoria_Click(object sender, EventArgs e)
        {
            if (editando)
            {
                Categoria categoria = new Categoria();

                categoria.IdCategoria = Convert.ToInt32(txtidcategoria.Text);
                categoria.NombreCategoria = txtnombrecategoria.Text.Trim().Replace("  ", " ");
                categoria.Descripcion = txtdescripcion.Text.Trim().Replace("  ", " ");

                categoriaActual = categoria;
                iniciarBarra("guardar");
                return;
            }

            if (dataGridViewcategoria.CurrentRow == null)
            {
                GestorMensajes.Advertencia("Seleccione una categoría para editar.");
                return;
            }

            DataGridViewRow fila = dataGridViewcategoria.CurrentRow;

            idCategoria = Convert.ToInt32(fila.Cells["IdCategoria"].Value);

            txtidcategoria.Text = idCategoria.ToString();
            txtnombrecategoria.Text = fila.Cells["NombreCategoria"].Value.ToString();
            txtdescripcion.Text = fila.Cells["Descripcion"].Value.ToString();

            editando = true;
            EstadoCampos(true);

            txtnombrecategoria.Focus();
            bttneditarcategoria.Text = "Actualizar";
        }


        private void bttneliminarcategoria_Click(object sender, EventArgs e)
        {
            if (dataGridViewcategoria.CurrentRow == null)
            {
                GestorMensajes.Advertencia("Seleccione una categoría antes de eliminar.");
                return;
            }

            int id = Convert.ToInt32(dataGridViewcategoria.CurrentRow.Cells["IdCategoria"].Value);

            DialogResult resultado = GestorMensajes.Confirmacion("¿Desea eliminar esta categoría?");

            if (resultado == DialogResult.Yes)
            {
                idCategoriaEliminar = id;
                iniciarBarra("eliminar");
            }
        }


        private void btnbuscarcategoria_Click(object sender, EventArgs e)
        {
            textoBuscar = txtBuscarcategoria.Text.Trim();

            if (string.IsNullOrWhiteSpace(textoBuscar))
            {
                GestorMensajes.Advertencia("Ingrese un nombre para realizar la búsqueda.");
                txtBuscarcategoria.Focus();
                return;
            }

            iniciarBarra("buscar");
        }


        private void dataGridViewcategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridViewcategoria.Rows[e.RowIndex];

                idCategoria = Convert.ToInt32(fila.Cells["IdCategoria"].Value);

                txtidcategoria.Text = idCategoria.ToString();
                txtnombrecategoria.Text = fila.Cells["NombreCategoria"].Value.ToString();
                txtdescripcion.Text = fila.Cells["Descripcion"].Value.ToString();

                string categoria = fila.Cells["NombreCategoria"].Value.ToString();

                CargarProductosPorCategoria(categoria);

                dataGridViewcategoria.CurrentRow.Selected = true;
            }
        }


        private void GuardarCategoria(Categoria categoria)
        {
            if (editando)
            {
                if (categoriaBLL.ActualizarCategoria(categoria))
                {
                    GestorMensajes.Exito("Categoría actualizada correctamente.");
                }
            }
            else
            {
                if (categoriaBLL.GuardarCategoria(categoria))
                {
                    GestorMensajes.Exito("Categoría guardada correctamente.");
                }
            }

            CargarCategorias();
            LimpiarCampos();
            txtBuscarcategoria.Clear();
            QuitarSeleccionCategoria();
        }


        private void EliminarCategoria(int id)
        {
            if (categoriaBLL.EliminarCategoria(id))
            {
                GestorMensajes.Exito("Categoría eliminada correctamente.");

                CargarCategorias();

                txtBuscarcategoria.Clear();

                QuitarSeleccionCategoria();

                LimpiarCampos();
            }
        }


        private void BuscarCategoria(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                CargarCategorias();
            }
            else
            {
                DataTable resultado = categoriaBLL.BuscarCategoria(nombre);

                if (resultado.Rows.Count > 0)
                {
                    dataGridViewcategoria.DataSource = resultado;
                    QuitarSeleccionCategoria();
                    LimpiarCampos();
                }
                else
                {
                    GestorMensajes.Informacion("No se encontró ninguna categoría con ese nombre.");

                    CargarCategorias();

                    txtBuscarcategoria.Focus();
                    txtBuscarcategoria.SelectAll();
                }
            }
        }
        private void iniciarBarra(string accionElegida)
        {
            accion = accionElegida;
            progressBarcategorias.Value = 0;
            progressBarcategorias.Visible = true;
            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBarcategorias.Increment(5);

            if (progressBarcategorias.Value >= 100)
            {
                timer1.Stop();
                progressBarcategorias.Visible = false;

                switch (accion)
                {
                    case "guardar":
                        GuardarCategoria(categoriaActual);
                        break;

                    case "eliminar":
                        EliminarCategoria(idCategoriaEliminar);
                        break;

                    case "buscar":
                        BuscarCategoria(textoBuscar);
                        break;
                }
            }
        }


        private void txtBuscarcategoria_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscarcategoria.Text))
            {
                CargarCategorias();
                QuitarSeleccionCategoria();
                LimpiarCampos();
            }
        }


        private void lblproductoscategorias_Click(object sender, EventArgs e)
        {

        }


        private void dataGridViewproCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void progressBarcategorias_Click(object sender, EventArgs e)
        {

        }
    }
}