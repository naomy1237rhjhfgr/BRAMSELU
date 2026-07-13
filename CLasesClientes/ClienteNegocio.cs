using BRAMSELU.CLasesClientes;
using BRAMSELU.Entidades; 
using System;
using System.Data;

namespace BRAMSELU.Negocio
{
    public class ClienteNegocio
    {
        private ClienteDatos objetoDatos = new ClienteDatos();

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

        public void InsertarCliente(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Id)) throw new Exception("El ID es obligatorio.");

            ValidarTipoPiel(cliente.TipoPiel);

            objetoDatos.GuardarCliente(cliente);
        }

        public DataTable ListarClientes()
        {
            return objetoDatos.MostrarClientes();
        }

        public void ActualizarCliente(Cliente cliente, string idOriginal)
        {
            ValidarTipoPiel(cliente.TipoPiel);

            objetoDatos.EditarCliente(cliente, idOriginal);
        }

        public void EliminarCliente(string idCliente)
        {
            objetoDatos.ElimiarCliente(idCliente);
        }

        public DataTable BuscarClientes(string buscar)
        {
            return objetoDatos.BuscarCliente(buscar);
        }
    }
}