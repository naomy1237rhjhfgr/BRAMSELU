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

        public bool AbrirCaja(decimal montoInicial, string usuarioApertura)
        {
            string query = $"INSERT INTO Cajas (FechaApertura, MontoInicial, Estado, UsuarioApertura, TotalVentasEfectivo, TotalCompras, MontoFinal) " +
                           $"VALUES (GETDATE(), {montoInicial}, 'Abierta', '{usuarioApertura}', 0, 0, 0)";
            return conexionObj.EjecutarSQL(query);
        }

        public DataTable ObtenerVentasDeCajaActual(int idCaja)
        {
            string query = "SELECT IdVenta, FechaVenta, Total, EfectivoRecibido, Cambio FROM Ventas WHERE IdCaja = " + idCaja;
            return conexionObj.EjecutarConsultaDataTable(query);
        }
        public decimal ObtenerTotalComprasDeCaja(int idCaja)
        {
            // Obtener la fecha de apertura
            string queryFecha = $"SELECT FechaApertura FROM Cajas WHERE IdCaja = {idCaja}";
            DataTable dtFecha = conexionObj.EjecutarConsultaDataTable(queryFecha);
            if (dtFecha.Rows.Count == 0) return 0;
            DateTime fechaApertura = Convert.ToDateTime(dtFecha.Rows[0]["FechaApertura"]);

            // Sumar compras hechas desde la apertura de caja
            string queryCompras = $"SELECT ISNULL(SUM(Total), 0) FROM Compras WHERE FechaCompra >= '{fechaApertura.ToString("yyyy-MM-dd HH:mm:ss")}'";
            DataTable dtCompras = conexionObj.EjecutarConsultaDataTable(queryCompras);

            if (dtCompras.Rows.Count > 0)
                return Convert.ToDecimal(dtCompras.Rows[0][0]);

            return 0;
        }
        public bool CerrarCaja(int idCaja, decimal montoFinal)
        {
          
            string queryFecha = $"SELECT FechaApertura FROM Cajas WHERE IdCaja = {idCaja}";
            DataTable dtFecha = conexionObj.EjecutarConsultaDataTable(queryFecha);
            if (dtFecha.Rows.Count == 0) return false;
            DateTime fechaApertura = Convert.ToDateTime(dtFecha.Rows[0]["FechaApertura"]);

            string querySumaVentas = "SELECT ISNULL(SUM(Total), 0) FROM Ventas WHERE IdCaja = " + idCaja;
            DataTable dtVentas = conexionObj.EjecutarConsultaDataTable(querySumaVentas);
            decimal totalVentas = Convert.ToDecimal(dtVentas.Rows[0][0]);

           
            string querySumaCompras = $"SELECT ISNULL(SUM(Total), 0) FROM Compras WHERE FechaCompra >= '{fechaApertura.ToString("yyyy-MM-dd HH:mm:ss")}'";
            DataTable dtCompras = conexionObj.EjecutarConsultaDataTable(querySumaCompras);
            decimal totalCompras = Convert.ToDecimal(dtCompras.Rows[0][0]);

            
            string queryCierre = $"UPDATE Cajas SET " +
                                 $"FechaCierre = GETDATE(), " +
                                 $"TotalVentasEfectivo = {totalVentas}, " +
                                 $"TotalCompras = {totalCompras}, " +
                                 $"MontoFinal = {montoFinal}, " +
                                 $"Estado = 'Cerrada' " +
                                 $"WHERE IdCaja = {idCaja}";

            return conexionObj.EjecutarSQL(queryCierre);
        }
    }
}