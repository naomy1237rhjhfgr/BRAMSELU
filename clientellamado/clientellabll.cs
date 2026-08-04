using System;
using System.Data;

using BRAMSELU.Ventas;

namespace BRAMSELU.clientellamado
{
    public class clientellabll
    {
       
        private clientelladal objDAL = new clientelladal();

       
        public DataTable ListarClientes()
        {
            try
            {
                return objDAL.ListarClientes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de negocio al listar clientes: ", ex);
            }
        }

       
        public DataTable BuscarClientes(string filtro)
        {
            try
            {
                if (string.IsNullOrEmpty(filtro))
                {
                    return objDAL.ListarClientes();
                }

                return objDAL.BuscarClientes(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de negocio al buscar clientes: ", ex);
            }
        }
    }
}