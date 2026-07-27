using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAMSELU.Ventas
{
    public class VentaBLL
    {
        private VentaDAL objDAL = new VentaDAL();

        public DataTable ObtenerProductos()
        {
            return objDAL.ObtenerProductos();
        }

        public bool RegistrarVentaFisica(DataTable dtCarrito, decimal total, decimal efectivo, decimal cambio)
        {
            return objDAL.RegistrarVentaFisica(dtCarrito, total, efectivo, cambio);
        }
    }

}
