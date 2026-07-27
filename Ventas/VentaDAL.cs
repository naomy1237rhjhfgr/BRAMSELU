using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAMSELU.Ventas
{
    public class VentaDAL
    {
        private Conexion conexionObj = new Conexion();


        public DataTable ObtenerProductos()
        {
            string query = "SELECT IdProducto, NombreProducto, Marca, Categoria, Precio, Stock, FechaRegistro, Imagen FROM Productos WHERE Stock > 0";
            return conexionObj.EjecutarConsultaDataTable(query);
        }

        public bool RegistrarVentaFisica(DataTable dtCarrito, decimal total, decimal efectivo, decimal cambio)
        {
            SqlConnection conexion = conexionObj.Abrir();
            SqlTransaction transaction = conexion.BeginTransaction();

            try
            {

                string queryCaja = "SELECT IdCaja FROM Cajas WHERE Estado = 'Abierta'";
                int idCajaAbierta = 0;

                using (SqlCommand cmdCaja = new SqlCommand(queryCaja, conexion, transaction))
                {
                    object resultadoCaja = cmdCaja.ExecuteScalar();
                    if (resultadoCaja == null)
                    {
                        throw new Exception("No hay ninguna caja abierta. Debe abrir caja antes de realizar ventas.");
                    }
                    idCajaAbierta = Convert.ToInt32(resultadoCaja);
                }


                string queryVenta = "INSERT INTO Ventas (FechaVenta, Total, EfectivoRecibido, Cambio, IdCaja) OUTPUT INSERTED.IdVenta VALUES (GETDATE(), " + total + ", " + efectivo + ", " + cambio + ", " + idCajaAbierta + ")";
                int idVenta = 0;

                using (SqlCommand cmdVenta = new SqlCommand(queryVenta, conexion, transaction))
                {
                    idVenta = Convert.ToInt32(cmdVenta.ExecuteScalar());
                }


                foreach (DataRow row in dtCarrito.Rows)
                {
                    int idProducto = Convert.ToInt32(row["IdProducto"]);
                    int cantidad = Convert.ToInt32(row["Cantidad"]);
                    decimal precio = Convert.ToDecimal(row["Precio"]);
                    decimal subtotal = Convert.ToDecimal(row["Subtotal"]);

                    string queryDetalle = "INSERT INTO DetalleVenta (IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (" + idVenta + ", " + idProducto + ", " + cantidad + ", " + precio + ", " + subtotal + ")";
                    using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion, transaction))
                    {
                        cmdDetalle.ExecuteNonQuery();
                    }

                    string queryStock = "UPDATE Productos SET Stock = Stock - " + cantidad + " WHERE IdProducto = " + idProducto + "";
                    using (SqlCommand cmdStock = new SqlCommand(queryStock, conexion, transaction))
                    {
                        cmdStock.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                conexionObj.Cerrar();
            }
        }
    }

}
