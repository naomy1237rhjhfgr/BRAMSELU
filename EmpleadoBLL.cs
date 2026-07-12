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
            if (emp.Nombre == "")
                return false;

            if (emp.Apellido == "")
                return false;

            if (emp.Identidad == "")
                return false;

            if (emp.Telefono == "")
                return false;

            if (emp.Usuario == "")
                return false;

            if (emp.Contrasena == "")
                return false;

            if (emp.TipoUsuario != "Administrador" && emp.TipoUsuario != "Empleado")
                return false;

            return true;
        }

        public bool GuardarEmpleado(Empleado emp)
        {
            if (!ValidarReglas(emp)) return false;
            return _empleadoDAL.Guardar(emp);
        }

        public bool ActualizarEmpleado(Empleado emp)
        {
            if (emp.IdEmpleado <= 0 || !ValidarReglas(emp)) return false;
            return _empleadoDAL.Actualizar(emp);
        }

        public bool EliminarEmpleado(int idEmpleado)
        {
            if (idEmpleado <= 0) return false;
            return _empleadoDAL.Eliminar(idEmpleado);
        }

        public List<Empleado> ObtenerEmpleados()
        {
            return _empleadoDAL.Listar();
        }

        public List<Empleado> BuscarEmpleado(string criterio)
        {
            if (criterio == "") return _empleadoDAL.Listar();
            return _empleadoDAL.BuscarPorTexto(criterio);
        }
    }
}