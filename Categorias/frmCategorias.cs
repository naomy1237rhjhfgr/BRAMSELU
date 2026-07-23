using BRAMSELU.Categorias;
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
    public partial class frmCategorias : Form
    {
        private CategoriaBLL categoriaBLL = new CategoriaBLL();
        private int idCategoria = 0;
        private bool editando = false;

        public frmCategorias()
        {
            InitializeComponent();
        }

        private void CargarCategorias()
        {
            dataGridViewcategoria.DataSource = categoriaBLL.ObtenerCategorias();
        }

        private void LimpiarCampos()
        {
            txtidcategoria.Clear();
            txtnombrecategoria.Clear();
            txtdescripcion.Clear();

            idCategoria = 0;
            editando = false;
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void Btnnuevocategoria_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtnombrecategoria.Focus();
        }

        private void btnguardarcategoria_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria ();

            if (string.IsNullOrWhiteSpace(txtidcategoria.Text))
                categoria.IdCategoria = 0;
            else
                categoria.IdCategoria = Convert.ToInt32(txtidcategoria.Text);

            categoria.NombreCategoria = txtnombrecategoria.Text.Trim();
            categoria.Descripcion = txtdescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(categoria.NombreCategoria))
            {
                MessageBox.Show("Ingrese el nombre de la categoría.");
                txtnombrecategoria.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(categoria.Descripcion))
            {
                MessageBox.Show("Ingrese la descripción.");
                txtdescripcion.Focus();
                return;
            }

            if (categoriaBLL.ExisteCategoria(categoria.NombreCategoria, categoria.IdCategoria))
            {
                MessageBox.Show("Ya existe una categoría con ese nombre.");
                txtnombrecategoria.Focus();
                return;
            }

            if (editando)
            {
                if (categoriaBLL.ActualizarCategoria(categoria))
                {
                    MessageBox.Show("Categoría actualizada correctamente.");
                }
            }
            else
            {
                if (categoriaBLL.GuardarCategoria(categoria))
                {
                    MessageBox.Show("Categoría guardada correctamente.");
                }
            }

            CargarCategorias();
            LimpiarCampos();
        }

        private void bttneditarcategoria_Click(object sender, EventArgs e)
        {
            if (dataGridViewcategoria.CurrentRow != null)
            {
                idCategoria = Convert.ToInt32(dataGridViewcategoria.CurrentRow.Cells["IdCategoria"].Value);

                txtidcategoria.Text = idCategoria.ToString();
                txtnombrecategoria.Text = dataGridViewcategoria.CurrentRow.Cells["NombreCategoria"].Value.ToString();
                txtdescripcion.Text = dataGridViewcategoria.CurrentRow.Cells["Descripcion"].Value.ToString();

                editando = true;
            }
        }

        private void bttneliminarcategoria_Click(object sender, EventArgs e)
        {
            if (dataGridViewcategoria.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridViewcategoria.CurrentRow.Cells["IdCategoria"].Value);

                DialogResult resultado = MessageBox.Show(
                    "¿Desea eliminar esta categoría?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    if (categoriaBLL.EliminarCategoria(id))
                    {
                        MessageBox.Show("Categoría eliminada correctamente.");
                        CargarCategorias();
                        LimpiarCampos();
                    }
                }
            }
        }

        private void btnbuscarcategoria_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscarcategoria.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                CargarCategorias();
            }
            else
            {
                dataGridViewcategoria.DataSource = categoriaBLL.BuscarCategoria(nombre);
            }
        }
    }
}
