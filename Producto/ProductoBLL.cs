using System;
using System.Data;
using BRAMSELU.Productos.DAL;
using BRAMSELU.Productos.Modelos;

namespace BRAMSELU.Productos.BLL
{
    public class ProductoBLL
    {
        private ProductoDAL dal = new ProductoDAL();

        public DataTable ListarProductos()
        {
            return dal.Listar();
        }

        public bool Guardar(Producto prod)
        {
            if (string.IsNullOrWhiteSpace(prod.NombreProducto))
                throw new Exception("El nombre del producto es obligatorio.");

            if (prod.Precio <= 0)
                throw new Exception("El precio debe ser mayor a cero.");

            if (prod.IdProducto == 0)
            {
                return dal.Insertar(prod);
            }
            else
            {
                return dal.Actualizar(prod);
            }
        }

        public bool EliminarProducto(int id)
        {
            return dal.Eliminar(id);
        }
    }
}