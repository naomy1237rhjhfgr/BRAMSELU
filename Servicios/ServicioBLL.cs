using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BRAMSELU.Servicios
{
    public class ServicioBLL
    {
        private ServicioDAL servicioDAL = new ServicioDAL();

        public DataTable ObtenerServicios()
        {
            return servicioDAL.ObtenerServicios();
        }

        public bool GuardarServicio(Servicio servicio)
        {
            return servicioDAL.GuardarServicio(servicio);
        }

        public bool ActualizarServicio(Servicio servicio)
        {
            return servicioDAL.ActualizarServicio(servicio);
        }

        public bool EliminarServicio(int idServicio)
        {
            return servicioDAL.EliminarServicio(idServicio);
        }

        public DataTable BuscarServicio(string dato)
        {
            return servicioDAL.BuscarServicio(dato);
        }

        public bool ExisteServicio(string nombreServicio, int idServicio)
        {
            return servicioDAL.ExisteServicio(nombreServicio, idServicio);
        }
    }
}
