using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BRAMSELU
{
    internal class Empleadocomp
    {
        Conexion conexion = new Conexion();

        public void Guardar(Empleado emp)
        {
            string consulta = @"INSERT INTO Empleados
            (Nombre, Apellido, Identidad, Telefono, Direccion, Correo, Usuario, Contrasena, TipoUsuario)
            VALUES
            (@Nombre, @Apellido, @Identidad, @Telefono, @Direccion, @Correo, @Usuario, @Contrasena, @TipoUsuario)";

            SqlCommand cmd = new SqlCommand(consulta, conexion.Abrir());

            cmd.Parameters.AddWithValue("@Nombre", emp.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", emp.Apellido);
            cmd.Parameters.AddWithValue("@Identidad", emp.Identidad);
            cmd.Parameters.AddWithValue("@Telefono", emp.Telefono);
            cmd.Parameters.AddWithValue("@Direccion", emp.Direccion);
            cmd.Parameters.AddWithValue("@Correo", emp.Correo);
            cmd.Parameters.AddWithValue("@Usuario", emp.Usuario);
            cmd.Parameters.AddWithValue("@Contrasena", emp.Contrasena);
            cmd.Parameters.AddWithValue("@TipoUsuario", emp.TipoUsuario);

            cmd.ExecuteNonQuery();
            conexion.Cerrar();
        }

        public void Modificar(Empleado emp)
        {
            string consulta = @"UPDATE Empleados SET
            Nombre=@Nombre,
            Apellido=@Apellido,
            Identidad=@Identidad,
            Telefono=@Telefono,
            Direccion=@Direccion,
            Correo=@Correo,
            Usuario=@Usuario,
            Contrasena=@Contrasena,
            TipoUsuario=@TipoUsuario
            WHERE IdEmpleado=@IdEmpleado";

            SqlCommand cmd = new SqlCommand(consulta, conexion.Abrir());

            cmd.Parameters.AddWithValue("@IdEmpleado", emp.IdEmpleado);
            cmd.Parameters.AddWithValue("@Nombre", emp.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", emp.Apellido);
            cmd.Parameters.AddWithValue("@Identidad", emp.Identidad);
            cmd.Parameters.AddWithValue("@Telefono", emp.Telefono);
            cmd.Parameters.AddWithValue("@Direccion", emp.Direccion);
            cmd.Parameters.AddWithValue("@Correo", emp.Correo);
            cmd.Parameters.AddWithValue("@Usuario", emp.Usuario);
            cmd.Parameters.AddWithValue("@Contrasena", emp.Contrasena);
            cmd.Parameters.AddWithValue("@TipoUsuario", emp.TipoUsuario);

            cmd.ExecuteNonQuery();
            conexion.Cerrar();
        }

        public void Eliminar(int id)
        {
            string consulta = "DELETE FROM Empleados WHERE IdEmpleado=@IdEmpleado";

            SqlCommand cmd = new SqlCommand(consulta, conexion.Abrir());

            cmd.Parameters.AddWithValue("@IdEmpleado", id);

            cmd.ExecuteNonQuery();
            conexion.Cerrar();
        }

        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Empleados",
                conexion.Abrir());

            da.Fill(tabla);

            conexion.Cerrar();

            return tabla;
        }

        public DataTable Buscar(string nombre)
        {
            DataTable tabla = new DataTable();

            string consulta = "SELECT * FROM Empleados WHERE Nombre LIKE @Nombre";

            SqlCommand cmd = new SqlCommand(consulta, conexion.Abrir());

            cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(tabla);

            conexion.Cerrar();

            return tabla;
        }
    }
}
