using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAMSELU.Compra
{
    public class CompraDAL
    {
        private Conexion conexion = new Conexion();

        public bool RegistrarCompra(DataTable dtDetalle, decimal total, int idProveedor)
        {
            SqlConnection conn = conexion.Abrir();
            SqlTransaction transaccion = conn.BeginTransaction();

            try
            {
                string queryCompra = "INSERT INTO Compras (Fecha, Total, IdProveedor) OUTPUT INSERTED.IdCompra VALUES (GETDATE(), " + total.ToString(System.Globalization.CultureInfo.InvariantCulture) + ", " + idProveedor + ")";

                SqlCommand cmdCompra = new SqlCommand(queryCompra, conn, transaccion);
                int idCompraGenerado = (int)cmdCompra.ExecuteScalar();

                foreach (DataRow row in dtDetalle.Rows)
                {
                    int idProducto = Convert.ToInt32(row["IdProducto"]);
                    int cantidad = Convert.ToInt32(row["Cantidad"]);
                    decimal precio = Convert.ToDecimal(row["PrecioUnitario"]);
                    decimal subtotal = Convert.ToDecimal(row["Subtotal"]);

                    string queryDetalle = "INSERT INTO DetalleCompra (IdCompra, IdProducto, Cantidad, PrecioUnitario, Subtotal) " +
                                          "VALUES (" + idCompraGenerado + ", " + idProducto + ", " + cantidad + ", " + precio.ToString(System.Globalization.CultureInfo.InvariantCulture) + ", " + subtotal.ToString(System.Globalization.CultureInfo.InvariantCulture) + "); " +
                                          "UPDATE Productos SET Stock = Stock + " + cantidad + " WHERE IdProducto = " + idProducto + ";";

                    SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conn, transaccion);
                    cmdDetalle.ExecuteNonQuery();
                }

                transaccion.Commit();
                conexion.Cerrar();
                return true;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                conexion.Cerrar();
                throw new Exception("Error en la Capa de Datos: " + ex.Message);
            }
        }

        public DataTable ListarProductos()
        {
            string query = "SELECT IdProducto, NombreProducto AS Nombre FROM Productos";
            return conexion.EjecutarConsultaDataTable(query);
        }

        public DataTable ListarProveedores()
        {
            string query = "SELECT IdProveedor, NombreEmpresa FROM Proveedores";
            return conexion.EjecutarConsultaDataTable(query);
        }
    }

}
