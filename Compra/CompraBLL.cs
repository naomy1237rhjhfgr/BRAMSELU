using System.Data;

namespace BRAMSELU.Compra
{
    public class CompraBLL
    {
        private CompraDALL objDALL = new CompraDALL();

        public bool InsertarCompra(DataTable dtDetalle, decimal totalGeneral, int idProveedor, string nombreEmpleado)
        {
            CompraED compra = new CompraED
            {
                Total = totalGeneral,
                IdProveedor = idProveedor,
                NombreEmpleado = nombreEmpleado
            };

            return objDALL.RegistrarCompra(compra, dtDetalle);
        }

        public DataTable ObtenerProveedores()
        {
            return objDALL.ObtenerProveedores();
        }
    }
}