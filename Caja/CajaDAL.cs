using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAMSELU.Caja
{
    public class CajaDAL
    {
        private Conexion conexionObj = new Conexion();

        public DataTable ObtenerCajaAbierta()
        {
            string query = "SELECT * FROM Cajas WHERE Estado = 'Abierta'";
            return conexionObj.EjecutarConsultaDataTable(query);
        }

        public bool AbrirCaja(decimal montoInicial)
        {
            string query = "INSERT INTO Cajas (FechaApertura, MontoInicial, Estado) VALUES (GETDATE(), " + montoInicial + ", 'Abierta')";
            return conexionObj.EjecutarSQL(query);
        }


        public DataTable ObtenerVentasDeCajaActual(int idCaja)
        {
            string query = "SELECT IdVenta, FechaVenta, Total, EfectivoRecibido, Cambio FROM Ventas WHERE IdCaja = " + idCaja;
            return conexionObj.EjecutarConsultaDataTable(query);
        }

        public bool CerrarCaja(int idCaja, decimal montoFinal)
        {
            string querySuma = "SELECT ISNULL(SUM(Total), 0) FROM Ventas WHERE IdCaja = " + idCaja;
            DataTable dt = conexionObj.EjecutarConsultaDataTable(querySuma);
            decimal totalVentas = Convert.ToDecimal(dt.Rows[0][0]);

            string queryCierre = "UPDATE Cajas SET FechaCierre = GETDATE(), TotalVentasEfectivo = " + totalVentas + ", MontoFinal = " + montoFinal + ", Estado = 'Cerrada' WHERE IdCaja = " + idCaja;
            return conexionObj.EjecutarSQL(queryCierre);
        }
    }

}
