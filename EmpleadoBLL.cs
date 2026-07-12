using System;
using System.Collections.Generic;
using System.Data;
using BRAMSELU.Entidades;
using BRAMSELU.DAL;

namespace BRAMSELU.BLL
{
    public class EmpleadoBLL
    {
        private EmpleadoDAL _empleadoDAL = new EmpleadoDAL();

        private bool ValidarReglas(Empleado emp)
        {
            if (emp.Nombre == string.Empty)
                return false;

            if (emp.Apellido == string.Empty)
                return false;

            if (emp.Identidad == string.Empty)
                return false;

            if (emp.Telefono == string.Empty)
                return false;

            if (emp.Usuario == string.Empty)
                return false;

            if (emp.Contrasena == string.Empty)
                return false;

            if (emp.TipoUsuario != "Administrador" && emp.TipoUsuario != "Empleado")
                return false;

            return true;
        }

        public bool ExisteIdentidad(string identidad, int idEmpleado)
        {
            return _empleadoDAL.VerificarIdentidad(identidad, idEmpleado) > 0;
        }

        public bool GuardarEmpleado(Empleado emp)
        {
            if (ExisteIdentidad(emp.Identidad, 0))
                return false;

            if (!ValidarReglas(emp))
                return false;

            return _empleadoDAL.Guardar(emp);
        }

        public bool ActualizarEmpleado(Empleado emp)
        {
            if (ExisteIdentidad(emp.Identidad, emp.IdEmpleado))
                return false;

            if (emp.IdEmpleado <= 0 || !ValidarReglas(emp))
                return false;

            return _empleadoDAL.Actualizar(emp);
        }

        public bool EliminarEmpleado(int idEmpleado)
        {
            if (idEmpleado <= 0)
                return false;

            return _empleadoDAL.Eliminar(idEmpleado);
        }

        public List<Empleado> ObtenerEmpleados()
        {
            return _empleadoDAL.Listar();
        }
        public List<Empleado> BuscarEmpleado(string criterio)
        {
            if (string.IsNullOrWhiteSpace(criterio))
                return _empleadoDAL.Listar();

            return _empleadoDAL.BuscarPorTexto(criterio);
        }
    }
}