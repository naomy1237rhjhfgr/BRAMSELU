using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BRAMSELU.Categorias
{
    public class CategoriaDatos
    {
        private Conexion conexion = new Conexion();

        public DataTable ObtenerCategorias()
        {
            string sql = " SELECT * FROM Categorias";

            return conexion.EjecutarConsultaDataTable(sql);
        }

        public bool GuardarCategoria(Categoria categoria)
        {
            string sql = $"INSERT INTO Categorias (NombreCategoria, Descripcion)" +
                            $"VALUES ('{categoria.NombreCategoria}','{categoria.Descripcion}')";

            return conexion.EjecutarSQL(sql);
        }

        public bool ActualizarCategoria(Categoria categoria)
        {
            string sql = $"UPDATE Categorias SET " +
                        $"NombreCategoria = '{categoria.NombreCategoria}'," +
                        $"Descripcion = '{categoria.Descripcion}' " +
                        $"WHERE IdCategoria = {categoria.IdCategoria}";

            return conexion.EjecutarSQL(sql);
        }

        public bool EliminarCategoria(int idCategoria)
        {
            string sql = $"DELETE FROM Categorias WHERE IdCategoria = {idCategoria}";

            return conexion.EjecutarSQL(sql);  
        }

        public DataTable BuscarCategoria(string nombre)
        {
            string sql = $"SELECT * FROM Categorias " +
             $"WHERE NombreCategoria LIKE '%{nombre}%' " +
             $"OR Descripcion LIKE '%{nombre}%' " +
             $"OR CAST(IdCategoria AS VARCHAR) LIKE '%{nombre}%'";

            return conexion.EjecutarConsultaDataTable(sql);
        }

        public bool ExisteCategoria(string nombreCategoria, int idCategoria)
        {
            string sql = $"SELECT * FROM Categorias " +
                         $"WHERE NombreCategoria = '{nombreCategoria}' " +
                         $"AND IdCategoria <> {idCategoria}";

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
