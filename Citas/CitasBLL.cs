using System;
using System.Data;
using BRAMSELU.DAL;
using BRAMSELU.Entidades;

namespace BRAMSELU.BLL
{
    public class CitaBLL
    {
        private CitaDAL _citaDAL = new CitaDAL();

        private bool ValidarReglas(ClaseCitas cita)
        {

            if (string.IsNullOrWhiteSpace(cita.IdCliente)) return false;

            if (cita.IdServicio <= 0) return false;
            if (cita.IdEmpleado <= 0) return false;
            if (cita.Fecha == DateTime.MinValue) return false;
            if (string.IsNullOrWhiteSpace(cita.Estado)) return false;
            if (cita.Precio <= 0) return false;

            return true;
        }

        public bool GuardarCita(ClaseCitas cita)
        {
            if (!ValidarReglas(cita)) return false;
            return _citaDAL.Guardar(cita);
        }

        public bool ActualizarCita(ClaseCitas cita)
        {
            if (cita.IdCita <= 0 || !ValidarReglas(cita)) return false;
            return _citaDAL.Actualizar(cita);
        }

        public bool EliminarCita(int idCita)
        {
            if (idCita <= 0) return false;
            return _citaDAL.Eliminar(idCita);
        }

        public DataTable ListarCitas()
        {
            return _citaDAL.Mostrar();
        }

        public DataTable ListarClientes()
        {
            return _citaDAL.ObtenerClientes();
        }

        public DataTable ListarServicios()
        {
            return _citaDAL.ObtenerServicios();
        }

        public DataTable ListarEmpleados()
        {
            return _citaDAL.ObtenerEmpleados();
        }
    }
}
