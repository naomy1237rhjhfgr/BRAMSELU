using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BRAMSELU.Entidades;

namespace BRAMSELU.DAL
{
    public class EmpleadoDAL
    {
        private Conexion _conexion = new Conexion();

        public bool Guardar(Empleado emp)
        {
            string SQL = "INSERT INTO Empleados " +
                "(IdEmpleado, Nombre, Apellido, Identidad, Telefono, Direccion, Correo, Usuario, Contrasena, TipoUsuario, FechaRegistro) " +
                "SELECT ISNULL(MAX(IdEmpleado), 0) + 1, " +
                $"'{emp.Nombre}', " +
                $"'{emp.Apellido}', " +
                $"'{emp.Identidad}', " +
                $"'{emp.Telefono}', " +
                $"'{emp.Direccion}', " +
                $"'{emp.Correo}', " +
                $"'{emp.Usuario}', " +
                $"'{emp.Contrasena}', " +
                $"'{emp.TipoUsuario}', " +
                "GETDATE() FROM Empleados";
            return _conexion.EjecutarSQL(SQL);
        }

        public bool Actualizar(Empleado emp)
        {
            string SQL = $"UPDATE Empleados SET Nombre='{emp.Nombre}', Apellido='{emp.Apellido}', Identidad='{emp.Identidad}', Telefono='{emp.Telefono}', Direccion='{emp.Direccion}', Correo='{emp.Correo}', Usuario='{emp.Usuario}', Contrasena='{emp.Contrasena}', TipoUsuario='{emp.TipoUsuario}' WHERE IdEmpleado={emp.IdEmpleado}";
            return _conexion.EjecutarSQL(SQL);
        }

        public bool Eliminar(int idEmpleado)
        {
            string SQL = $"DELETE FROM Empleados WHERE IdEmpleado={idEmpleado}";
            return _conexion.EjecutarSQL(SQL);
        }

        public int VerificarIdentidad(string identidad, int idEmpleado)
        {
            string SQL = $"SELECT COUNT(*) FROM Empleados WHERE Identidad = '{identidad}' AND IdEmpleado <> {idEmpleado}";
            DataTable dt = _conexion.EjecutarConsultaDataTable(SQL);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public List<Empleado> Listar()
        {
            List<Empleado> lista = new List<Empleado>();
            string SQL = "SELECT * FROM Empleados";
            SqlDataReader reader = _conexion.EjecutarConsulta(SQL);

            if (reader != null)
            {
                while (reader.Read())
                {
                    Empleado emp = new Empleado
                    {
                        IdEmpleado = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        Identidad = reader.GetString(3),
                        Telefono = reader.GetString(4),
                        Direccion = reader.GetString(5),
                        Correo = reader.GetString(6),
                        Usuario = reader.GetString(7),
                        Contrasena = reader.GetString(8),
                        TipoUsuario = reader.GetString(9)
                    };
                    lista.Add(emp);
                }
                reader.Close();
            }
            return lista;
        }

        public List<Empleado> BuscarPorTexto(string criterio)
        {
            List<Empleado> lista = new List<Empleado>();
            string SQL = $"SELECT * FROM Empleados WHERE Nombre LIKE '%{criterio}%' OR Identidad LIKE '%{criterio}%'";
            SqlDataReader reader = _conexion.EjecutarConsulta(SQL);

            if (reader != null)
            {
                while (reader.Read())
                {
                    Empleado emp = new Empleado
                    {
                        IdEmpleado = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        Identidad = reader.GetString(3),
                        Telefono = reader.GetString(4),
                        Direccion = reader.GetString(5),
                        Correo = reader.GetString(6),
                        Usuario = reader.GetString(7),
                        Contrasena = reader.GetString(8),
                        TipoUsuario = reader.GetString(9)
                    };
                    lista.Add(emp);
                }
                reader.Close();
            }
            return lista;
        }
    }
}