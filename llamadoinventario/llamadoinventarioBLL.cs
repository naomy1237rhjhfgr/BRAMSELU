using System.Data;
using BRAMSELU.llamadoinventario.DAL;

namespace BRAMSELU.llamadoinventario.BLL
{
    public class llamadoinventarioBLL
    {
        private llamadoinventarioDAL dal = new llamadoinventarioDAL();

        public DataTable Listar()
        {
            return dal.Listar();
        }
    }
}