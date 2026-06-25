using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BRAMSELU.CLasesClientes
{
    public class ClienteDatos
    {
        private Conexion conexion = new Conexion();
        private SqlCommand comando = new SqlCommand();

        public void GuardarCliente(Cliente cliente)
        {
            comando.Parameters.Clear();

            comando.Connection = conexion.Abrir();

            comando.CommandText = "INSERT INTO Clientes ( IdCliente, Nombre, Telefono, Correo, Direccion, TipoPiel ) VALUES ( @IdCliente, @Nombre, @Telefono, @Correo, @Direccion, @TipoPiel ) "; 
            
            comando.Parameters.AddWithValue("@IdCliente", cliente.Id);

            comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);

            comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);

            comando.Parameters.AddWithValue("@Correo", cliente.Correo);

            comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);

            comando.Parameters.AddWithValue("@TipoPiel", cliente.TipoPiel);

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new Exception("Ya existe un cliente con este ID.");
            }
            finally
            {
                conexion.Cerrar();
            }

           
        }

        public DataTable MostrarClientes()
        {
            DataTable tabla = new DataTable();
            comando.Parameters.Clear();
            comando.Connection = conexion.Abrir();
            comando.CommandText = "SELECT * FROM Clientes";

            SqlDataAdapter adaptador = new
                SqlDataAdapter(comando);
            adaptador.Fill(tabla);

            conexion.Cerrar();

            return tabla;

        }

        public void EditarCliente(Cliente cliente)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.Abrir();

            comando.CommandText = @"UPDATE Clientes
                               SET Nombre = @Nombre,
                               Telefono = @Telefono,
                               Correo = @Correo,
                               Direccion = @Direccion,
                               TipoPiel = @TipoPiel
                               WHERE IdCliente = @IdCliente";

            comando.Parameters.AddWithValue("@IdCliente", cliente.Id);
            comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
            comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
            comando.Parameters.AddWithValue("@Correo", cliente.Correo);
            comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);
            comando.Parameters.AddWithValue("@TipoPiel", cliente.TipoPiel);

            comando.ExecuteNonQuery();
            conexion.Cerrar();
        }

        public void ElimiarCliente(string idCliente)
        {
            comando.Parameters.Clear();
            comando.Connection = conexion.Abrir();

            comando.CommandText = "DELETE FROM Clientes WHERE IdCliente = @IdCliente";

            comando.Parameters.AddWithValue("@IdCliente", idCliente);

            comando.ExecuteNonQuery();
            conexion.Cerrar();
        }

        public DataTable BuscarCliente(string buscar)
        {
            DataTable tabla = new DataTable();

            comando.Parameters.Clear();
            comando.Connection = conexion.Abrir();

            comando.CommandText = @"SELECT * FROM Clientes WHERE IdCliente LIKE @Buscar OR Nombre LIKE @Buscar";

            comando.Parameters.AddWithValue("@Buscar", "%" + buscar + "%");

            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            adaptador.Fill(tabla);

            conexion.Cerrar();

            return tabla;
        }

    }

    
    
}
