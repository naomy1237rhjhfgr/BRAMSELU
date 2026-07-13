using System;
using System.Data;
using System.Data.SqlClient;
using BRAMSELU.Entidades;

namespace BRAMSELU.CLasesClientes
{
    public class ClienteDatos
    {
        private Conexion conexion = new Conexion();

        public void GuardarCliente(Cliente cliente)
        {
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = conexion.Abrir();
                comando.CommandText = $"INSERT INTO Clientes ([IdCliente], [Nombre], [Telefono], [Correo], [Direccion], [TipoPiel]) VALUES ('{cliente.Id}', '{cliente.Nombre}', '{cliente.Telefono}', '{cliente.Correo}', '{cliente.Direccion}', '{cliente.TipoPiel}')";
                try { comando.ExecuteNonQuery(); }
                catch (SqlException ex) { throw new Exception(ex.Number == 2627 || ex.Number == 2601 ? "Ya existe un cliente con este ID." : $"Error: {ex.Message}"); }
                finally { conexion.Cerrar(); }
            }
        }

        public DataTable MostrarClientes()
        {
            DataTable tabla = new DataTable();
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = conexion.Abrir();
                comando.CommandText = "SELECT * FROM Clientes";
                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando)) { adaptador.Fill(tabla); }
            }
            conexion.Cerrar();
            return tabla;
        }

        public void EditarCliente(Cliente cliente, string idOriginal)
        {
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = conexion.Abrir();
                comando.CommandText = $"UPDATE Clientes SET [IdCliente] = '{cliente.Id}', [Nombre] = '{cliente.Nombre}', [Telefono] = '{cliente.Telefono}', [Correo] = '{cliente.Correo}', [Direccion] = '{cliente.Direccion}', [TipoPiel] = '{cliente.TipoPiel}' WHERE [IdCliente] = '{idOriginal}'";
                try { comando.ExecuteNonQuery(); }
                catch (SqlException ex) { throw new Exception(ex.Number == 2627 || ex.Number == 2601 ? "El nuevo ID ya pertenece a otro cliente." : $"Error: {ex.Message}"); }
                finally { conexion.Cerrar(); }
            }
        }

        public void ElimiarCliente(string idCliente)
        {
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = conexion.Abrir();
                comando.CommandText = $"DELETE FROM Clientes WHERE [IdCliente] = '{idCliente}'";
                try { comando.ExecuteNonQuery(); }
                catch (SqlException ex) { throw new Exception($"Error: {ex.Message}"); }
                finally { conexion.Cerrar(); }
            }
        }

        public DataTable BuscarCliente(string buscar)
        {
            DataTable tabla = new DataTable();
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = conexion.Abrir();
                comando.CommandText = $"SELECT * FROM Clientes WHERE [IdCliente] LIKE '%{buscar}%' OR [Nombre] LIKE '%{buscar}%'";
                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando)) { adaptador.Fill(tabla); }
            }
            conexion.Cerrar();
            return tabla;
        }
    }
}