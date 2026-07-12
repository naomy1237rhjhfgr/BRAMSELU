using System.Collections.Generic;
using BRAMSELU.Entidades;
using BRAMSELU.DAL;

namespace BRAMSELU.BLL
{
    public class InventarioBLL
    {
        private InventarioDAL _inventarioDAL = new InventarioDAL();

        private bool ValidarReglas(Inventario inv)
        {
            if (inv.NombreProducto == "")
                return false;

            if (inv.Marca == "")
                return false;

            if (inv.Categoria == "")
                return false;

            if (inv.Precio <= 0)
                return false;

            if (inv.Stock < 0)
                return false;

            if (inv.Imagen == null)
                return false;

            return true;
        }

        public bool GuardarProducto(Inventario inv)
        {
            if (!ValidarReglas(inv))
                return false;

            return _inventarioDAL.Guardar(inv);
        }

        public bool ActualizarProducto(Inventario inv)
        {
            if (inv.IdProducto <= 0 || !ValidarReglas(inv))
                return false;

            return _inventarioDAL.Actualizar(inv);
        }

        public bool EliminarProducto(int idProducto)
        {
            if (idProducto <= 0)
                return false;

            return _inventarioDAL.Eliminar(idProducto);
        }

        public List<Inventario> ObtenerProductos()
        {
            return _inventarioDAL.Listar();
        }

        public List<Inventario> BuscarProducto(string criterio)
        {
            if (criterio == "")
                return _inventarioDAL.Listar();

            return _inventarioDAL.BuscarPorTexto(criterio);
        }
    }
}