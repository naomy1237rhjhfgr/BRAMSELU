using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BRAMSELU.Categorias
{
    public class CategoriaBLL
    {
        private CategoriaDatos categoriaDatos = new CategoriaDatos();

        public DataTable ObtenerCategorias()
        {
            return categoriaDatos.ObtenerCategorias();
        }

        public bool GuardarCategoria(Categoria categoria)
        {
            return categoriaDatos.GuardarCategoria(categoria);
        }

        public bool ActualizarCategoria(Categoria categoria)
        {
            return categoriaDatos.ActualizarCategoria(categoria);
        }

        public bool EliminarCategoria(int idCategoria)
        {
            return categoriaDatos.EliminarCategoria(idCategoria);
        }

        public DataTable BuscarCategoria (string nombre)
        {
            return categoriaDatos.BuscarCategoria(nombre);
        }

        public bool ExisteCategoria (string nombreCategoria, int idCategoria)
        {
            return categoriaDatos.ExisteCategoria(nombreCategoria, idCategoria);
        }


    }
}
