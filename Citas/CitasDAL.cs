using System;
using System.Data;
using System.Globalization;
using BRAMSELU.Entidades;

namespace BRAMSELU.DAL
{
    public class CitaDAL
    {
        private Conexion _conexion = new Conexion();

        public DataTable Mostrar()
        {
            string SQL = "SELECT C.IdCita, " +
                         "C.IdCliente, " +
                         "CL.Nombre AS Cliente, " +
                         "C.IdServicio, " +
                         "S.NombreServicio AS Servicio, " +
                         "C.IdEmpleado, " +
                         "E.Nombre AS Especialista, " +
                         "C.Fecha, " +
                         "C.Hora, " +
                         "C.Estado, " +
                         "C.Precio " +
                         "FROM Citas C " +
                         "INNER JOIN Clientes CL ON C.IdCliente = CL.IdCliente " +
                         "INNER JOIN Servicios S ON C.IdServicio = S.IdServicio " +
                         "INNER JOIN Empleados E ON C.IdEmpleado = E.IdEmpleado";

            return _conexion.EjecutarConsultaDataTable(SQL);
        }

        public bool Guardar(ClaseCitas cita)
        {
            string precioFormatted = cita.Precio.ToString(CultureInfo.InvariantCulture);
            string fechaFormatted = cita.Fecha.ToString("yyyy-MM-dd");
            string horaFormatted = cita.Hora.ToString("hh\\:mm\\:ss");

            // Notar las comillas simples '{cita.IdCliente}' porque es VARCHAR
            string SQL = $"INSERT INTO Citas (IdCliente, IdServicio, IdEmpleado, Fecha, Hora, Estado, Precio) " +
                         $"VALUES ('{cita.IdCliente}', {cita.IdServicio}, {cita.IdEmpleado}, '{fechaFormatted}', '{horaFormatted}', '{cita.Estado}', {precioFormatted})";

            return _conexion.EjecutarSQL(SQL);
        }

        public bool Actualizar(ClaseCitas cita)
        {
            string precioFormatted = cita.Precio.ToString(CultureInfo.InvariantCulture);
            string fechaFormatted = cita.Fecha.ToString("yyyy-MM-dd");
            string horaFormatted = cita.Hora.ToString("hh\\:mm\\:ss");

            string SQL = $"UPDATE Citas SET " +
                         $"IdCliente = '{cita.IdCliente}', " +
                         $"IdServicio = {cita.IdServicio}, " +
                         $"IdEmpleado = {cita.IdEmpleado}, " +
                         $"Fecha = '{fechaFormatted}', " +
                         $"Hora = '{horaFormatted}', " +
                         $"Estado = '{cita.Estado}', " +
                         $"Precio = {precioFormatted} " +
                         $"WHERE IdCita = {cita.IdCita}";

            return _conexion.EjecutarSQL(SQL);
        }

        public bool Eliminar(int idCita)
        {
            string SQL = $"DELETE FROM Citas WHERE IdCita = {idCita}";

            return _conexion.EjecutarSQL(SQL);
        }

        public DataTable BuscarPorTexto(string criterio)
        {
            string SQL = "SELECT C.IdCita, " +
                         "C.IdCliente, " +
                         "CL.Nombre AS Cliente, " +
                         "C.IdServicio, " +
                         "S.NombreServicio AS Servicio, " +
                         "C.IdEmpleado, " +
                         "E.Nombre AS Especialista, " +
                         "C.Fecha, " +
                         "C.Hora, " +
                         "C.Estado, " +
                         "C.Precio " +
                         "FROM Citas C " +
                         "INNER JOIN Clientes CL ON C.IdCliente = CL.IdCliente " +
                         "INNER JOIN Servicios S ON C.IdServicio = S.IdServicio " +
                         "INNER JOIN Empleados E ON C.IdEmpleado = E.IdEmpleado " +
                         $"WHERE CL.Nombre LIKE '%{criterio}%'";

            return _conexion.EjecutarConsultaDataTable(SQL);
        }

        public DataTable ObtenerClientes()
        {
            string SQL = "SELECT IdCliente, Nombre FROM Clientes ORDER BY Nombre";

            return _conexion.EjecutarConsultaDataTable(SQL);
        }


        public DataTable ObtenerServicios()
        {
            string SQL = "SELECT IdServicio, NombreServicio FROM Servicios ORDER BY NombreServicio";

            return _conexion.EjecutarConsultaDataTable(SQL);
        }


        public DataTable ObtenerEmpleados()
        {
            string SQL = "SELECT IdEmpleado, Nombre FROM Empleados ORDER BY Nombre";

            return _conexion.EjecutarConsultaDataTable(SQL);
        }
    }
}