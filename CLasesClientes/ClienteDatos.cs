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

        private void ValidarTipoPiel(string tipoPiel)
        {
            if (string.IsNullOrEmpty(tipoPiel))
            {
                throw new Exception("El tipo de piel no puede estar vacío.");
            }

            string limpio = tipoPiel.Trim();

            if (limpio != "Piel Normal" &&
                limpio != "Piel Seca" &&
                limpio != "Piel Grasa" &&
                limpio != "Piel Mixta" &&
                limpio != "Piel Sensible" &&
                limpio != "Piel Deshidratada" &&
                limpio != "Piel Madura" &&
                limpio != "Piel Acneica" &&
                limpio != "Piel Reactiva" &&
                limpio != "Todo Tipo de Piel")
            {
                throw new Exception($"El tipo de piel '{limpio}' seleccionado no es válido.");
            }
        }

        public void GuardarCliente(Cliente cliente)
        {
            ValidarTipoPiel(cliente.TipoPiel);

            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = conexion.Abrir();
                comando.CommandText = $"INSERT INTO Clientes ( [IdCliente], [Nombre], [Telefono], [Correo], [Direccion], [TipoPiel] ) VALUES ( '{cliente.Id}', '{cliente.Nombre}', '{cliente.Telefono}', '{cliente.Correo}', '{cliente.Direccion}', '{cliente.TipoPiel}' )";

                try
                {
                    comando.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        throw new Exception("Ya existe un cliente con este ID.");
                    }
                    else
                    {
                        throw new Exception($"Error de Base de Datos: {ex.Message}");
                    }
                }
                finally
                {
                    conexion.Cerrar();
                }
            }
        }

        public DataTable MostrarClientes()
        {
            DataTable tabla = new DataTable();

            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = conexion.Abrir();
                comando.CommandText = "SELECT * FROM Clientes";

                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                {
                    adaptador.Fill(tabla);
                }
            }

            conexion.Cerrar();
            return tabla;
        }

        public void EditarCliente(Cliente cliente, string idOriginal)
        {
            ValidarTipoPiel(cliente.TipoPiel);

            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = conexion.Abrir();
                comando.CommandText = $"UPDATE Clientes SET [IdCliente] = '{cliente.Id}', [Nombre] = '{cliente.Nombre}', [Telefono] = '{cliente.Telefono}', [Correo] = '{cliente.Correo}', [Direccion] = '{cliente.Direccion}', [TipoPiel] = '{cliente.TipoPiel}' WHERE [IdCliente] = '{idOriginal}'";

                try
                {
                    comando.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        throw new Exception("El nuevo ID asignado ya le pertenece a otro cliente.");
                    }
                    else
                    {
                        throw new Exception($"Error al modificar en la Base de Datos: {ex.Message}");
                    }
                }
                finally
                {
                    conexion.Cerrar();
                }
            }
        }

        public void ElimiarCliente(string idCliente)
        {
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = conexion.Abrir();
                comando.CommandText = $"DELETE FROM Clientes WHERE [IdCliente] = '{idCliente}'";

                try
                {
                    comando.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Error al eliminar en la Base de Datos: {ex.Message}");
                }
                finally
                {
                    conexion.Cerrar();
                }
            }
        }

        public DataTable BuscarCliente(string buscar)
        {
            DataTable tabla = new DataTable();

            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = conexion.Abrir();
                comando.CommandText = $"SELECT * FROM Clientes WHERE [IdCliente] LIKE '%{buscar}%' OR [Nombre] LIKE '%{buscar}%'";

                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                {
                    adaptador.Fill(tabla);
                }
            }

            conexion.Cerrar();
            return tabla;
        }
    }
}