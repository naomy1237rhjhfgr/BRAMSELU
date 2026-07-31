using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAMSELU.Caja
{
    public class CajaBLL
    {
        private CajaDAL objDAL = new CajaDAL();

        public DataTable ObtenerCajaAbierta()
        {
            return objDAL.ObtenerCajaAbierta();
        }

        public decimal ObtenerTotalComprasDeCaja(int idCaja)
        {
            return objDAL.ObtenerTotalComprasDeCaja(idCaja);
        }

        public bool AbrirCaja(decimal montoInicial, string usuarioApertura)
        {
            return objDAL.AbrirCaja(montoInicial, usuarioApertura);
        }

        public DataTable ObtenerVentasDeCajaActual(int idCaja)
        {
            return objDAL.ObtenerVentasDeCajaActual(idCaja);
        }

       
        public DataTable ObtenerComprasDeCajaActual(int idCaja)
        {
            return objDAL.ObtenerComprasDeCajaActual(idCaja);
        }

        public bool CerrarCaja(int idCaja, decimal montoFinal)
        {
            return objDAL.CerrarCaja(idCaja, montoFinal);
        }
    }
}