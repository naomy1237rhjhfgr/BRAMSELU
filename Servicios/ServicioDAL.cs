using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BRAMSELU.Servicios
{
    public class ServicioDAL
    {
        private Conexion conexion = new Conexion();

        public DataTable ObtenerServicios()
        {
            string sql = "SELECT * FROM Servicios";
            return conexion.EjecutarConsultaDataTable(sql);
        }

        public bool GuardarServicio(Servicio servicio)
        {
            string sql = $"INSERT INTO Servicios (NombreServicio, Descripcion, Precio, Duracion, Estado) " +
                         $"VALUES ('{servicio.NombreServicio}','{servicio.Descripcion}',{servicio.Precio},{servicio.Duracion},{(servicio.Estado ? 1 : 0)})";

            return conexion.EjecutarSQL(sql);
        }

        public bool ActualizarServicio(Servicio servicio)
        {
            string sql = $"UPDATE Servicios SET " +
                         $"NombreServicio = '{servicio.NombreServicio}', " +
                         $"Descripcion = '{servicio.Descripcion}', " +
                         $"Precio = {servicio.Precio}, " +
                         $"Duracion = {servicio.Duracion}, " +
                         $"Estado = {(servicio.Estado ? 1 : 0)} " +
                         $"WHERE IdServicio = {servicio.IdServicio}";

            return conexion.EjecutarSQL(sql);
        }

        public bool EliminarServicio(int idServicio)
        {
            string sql = $"DELETE FROM Servicios WHERE IdServicio = {idServicio}";
            return conexion.EjecutarSQL(sql);
        }

        public DataTable BuscarServicio(string dato)
        {
            string sql = $"SELECT * FROM Servicios " +
                  $"WHERE NombreServicio LIKE '%{dato}%' " +
                  $"OR Descripcion LIKE '%{dato}%' " +
                  $"OR CAST(IdServicio AS VARCHAR) LIKE '%{dato}%'";

            return conexion.EjecutarConsultaDataTable(sql);
        }

        public bool ExisteServicio(string nombreServicio, int idServicio)
        {
            string sql = $"SELECT * FROM Servicios " +
                         $"WHERE NombreServicio = '{nombreServicio}' " +
                         $"AND IdServicio <> {idServicio}";

            SqlDataReader reader = conexion.EjecutarConsultaUno(sql);

            if (reader != null)
            {
                reader.Close();
                conexion.Cerrar();
                return true;
            }

            return false;
        }

    }
}
