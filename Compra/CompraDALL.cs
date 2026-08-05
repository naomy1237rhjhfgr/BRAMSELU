using System;
using System.Data;
using System.Data.SqlClient;
using BRAMSELU.Mensajes;

namespace BRAMSELU.Compra
{
    public class CompraDALL
    {
        private Conexion conexionDB = new Conexion();

        public bool RegistrarCompra(CompraED compra, DataTable dtDetalle)
        {
            SqlConnection conexion = conexionDB.Abrir();
            SqlTransaction transaction = null;

            try
            {
                transaction = conexion.BeginTransaction();
                int idCompraGenerado = 0;

                string queryCompra = "INSERT INTO Compras (Fecha, Total, IdProveedor, NombreEmpleado) OUTPUT INSERTED.IdCompra VALUES (@Fecha, @Total, @IdProveedor, @NombreEmpleado)";

                using (SqlCommand cmdCompra = new SqlCommand(queryCompra, conexion, transaction))
                {
                    cmdCompra.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    cmdCompra.Parameters.AddWithValue("@Total", compra.Total);
                    cmdCompra.Parameters.AddWithValue("@IdProveedor", compra.IdProveedor);
                    cmdCompra.Parameters.AddWithValue("@NombreEmpleado", compra.NombreEmpleado ?? "Sistema");

                    idCompraGenerado = (int)cmdCompra.ExecuteScalar();
                }

                foreach (DataRow row in dtDetalle.Rows)
                {
                    string queryDetalle = "INSERT INTO DetalleCompra (IdCompra, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@IdC, @IdP, @Cant, @Precio, @Sub)";

                    using (SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion, transaction))
                    {
                        cmdDetalle.Parameters.AddWithValue("@IdC", idCompraGenerado);
                        cmdDetalle.Parameters.AddWithValue("@IdP", Convert.ToInt32(row["IdProducto"]));
                        cmdDetalle.Parameters.AddWithValue("@Cant", Convert.ToInt32(row["Cantidad"]));
                        cmdDetalle.Parameters.AddWithValue("@Precio", Convert.ToDecimal(row["PrecioUnitario"]));
                        cmdDetalle.Parameters.AddWithValue("@Sub", Convert.ToDecimal(row["Subtotal"]));
                        cmdDetalle.ExecuteNonQuery();
                    }

                    string queryStock = "UPDATE Productos SET Stock = Stock + @Cant WHERE IdProducto = @IdP";

                    using (SqlCommand cmdStock = new SqlCommand(queryStock, conexion, transaction))
                    {
                        cmdStock.Parameters.AddWithValue("@Cant", Convert.ToInt32(row["Cantidad"]));
                        cmdStock.Parameters.AddWithValue("@IdP", Convert.ToInt32(row["IdProducto"]));
                        cmdStock.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                GestorMensajes.Error("Error al registrar compra: " + ex.Message);
                return false;
            }
            finally
            {
                conexionDB.Cerrar();
            }
        }

        public DataTable ObtenerProveedores()
        {
            string query = "SELECT IdProveedor, NombreEmpresa FROM Proveedores";
            return conexionDB.EjecutarConsultaDataTable(query);
        }
    }
}