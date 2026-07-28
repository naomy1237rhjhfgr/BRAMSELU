using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAMSELU.Compra
{
    public class CompraBLL
    {
        private CompraDAL objDAL = new CompraDAL();

        public bool InsertarCompra(DataTable dtDetalle, decimal total, int idProveedor)
        {
            if (idProveedor <= 0)
            {
                throw new Exception("Debe seleccionar un proveedor válido.");
            }

            if (dtDetalle.Rows.Count == 0)
            {
                throw new Exception("Debe agregar al menos un producto a la compra.");
            }

            if (total <= 0)
            {
                throw new Exception("El total de la compra no es válido.");
            }

            return objDAL.RegistrarCompra(dtDetalle, total, idProveedor);
        }

        public DataTable ObtenerProductos()
        {
            return objDAL.ListarProductos();
        }


        public DataTable ObtenerProveedores()
        {
            return objDAL.ListarProveedores();
        }
    }

}
