using System.Data;

namespace BRAMSELU.llamadoinventario.DAL
{
    public class llamadoinventarioDAL
    {
        public DataTable Listar()
        {
       
            Conexion conexionBD = new Conexion();

            string query = "SELECT IdProducto, NombreProducto, Marca, Categoria, Precio, Stock, FechaRegistro, Imagen, IdCategoria FROM Productos";

           
            return conexionBD.EjecutarConsultaDataTable(query);
        }
    }
}