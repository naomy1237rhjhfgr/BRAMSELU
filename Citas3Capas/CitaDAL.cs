using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BRAMSELU
{
    public class CitaDAL
    {

        private Conexion conexion = new Conexion();

        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            string query = "SELECT IdCita, IdCliente, Telefono, IdServicio, IdEspecialista, Fecha, Hora, Duracion, Notas, EstadoCita, Precio FROM Citas";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion.Abrir()))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(tabla);
                    }
                }
            }
            finally
            {
                conexion.Cerrar();
            }
            return tabla;
        }

        public void Guardar(ClaseCitas cita)
        {
            string query = @"INSERT INTO Citas (IdCliente, Telefono, IdServicio, IdEspecialista, Fecha, Hora, Duracion, Notas, EstadoCita, Precio) 
                             VALUES (@IdCliente, @Telefono, @IdServicio, @IdEspecialista, @Fecha, @Hora, @Duracion, @Notas, @EstadoCita, @Precio)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion.Abrir()))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", Convert.ToInt32(cita.Cliente));
                    cmd.Parameters.AddWithValue("@Telefono", cita.Telefono ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdServicio", Convert.ToInt32(cita.Servicio));
                    cmd.Parameters.AddWithValue("@IdEspecialista", Convert.ToInt32(cita.Especialista));
                    cmd.Parameters.AddWithValue("@Fecha", cita.Fecha);
                    cmd.Parameters.AddWithValue("@Hora", cita.Hora ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Duracion", cita.Duracion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Notas", cita.Notas ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EstadoCita", cita.Estado ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Precio", cita.Precio);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                conexion.Cerrar();
            }
        }

        public void Modificar(ClaseCitas cita)
        {
            string query = @"UPDATE Citas 
                             SET IdCliente = @IdCliente, Telefono = @Telefono, IdServicio = @IdServicio, 
                                 IdEspecialista = @IdEspecialista, Fecha = @Fecha, Hora = @Hora, 
                                 Duracion = @Duracion, Notas = @Notas, EstadoCita = @EstadoCita, Precio = @Precio 
                             WHERE IdCita = @IdCita";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion.Abrir()))
                {
                    cmd.Parameters.AddWithValue("@IdCita", cita.ID);
                    cmd.Parameters.AddWithValue("@IdCliente", Convert.ToInt32(cita.Cliente));
                    cmd.Parameters.AddWithValue("@Telefono", cita.Telefono ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdServicio", Convert.ToInt32(cita.Servicio));
                    cmd.Parameters.AddWithValue("@IdEspecialista", Convert.ToInt32(cita.Especialista));
                    cmd.Parameters.AddWithValue("@Fecha", cita.Fecha);
                    cmd.Parameters.AddWithValue("@Hora", cita.Hora ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Duracion", cita.Duracion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Notas", cita.Notas ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EstadoCita", cita.Estado ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Precio", cita.Precio);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                conexion.Cerrar();
            }
        }

        public void Eliminar(int idCita)
        {
            string query = "DELETE FROM Citas WHERE IdCita = @IdCita";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion.Abrir()))
                {
                    cmd.Parameters.AddWithValue("@IdCita", idCita);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                conexion.Cerrar();
            }
        }

        public DataTable Buscar(string texto)
        {
            DataTable tabla = new DataTable();
            string query = @"SELECT IdCita, IdCliente, Telefono, IdServicio, IdEspecialista, Fecha, Hora, Duracion, Notas, EstadoCita, Precio 
                             FROM Citas 
                             WHERE Telefono LIKE @Texto OR EstadoCita LIKE @Texto";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion.Abrir()))
                {
                    cmd.Parameters.AddWithValue("@Texto", "%" + texto + "%");

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(tabla);
                    }
                }
            }
            finally
            {
                conexion.Cerrar();
            }
            return tabla;
        }
    }
}