using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web.Management;

namespace BRAMSELU
{
    public class ClaseCitas
    {
        private int _id;
        private string _cliente;
        private string _telefono;
        private string _servicio;
        private string _especialista;
        private DateTime _fecha;
        private string _hora;
        private string _duracion;
        private string _notas;
        private string _estado;
        private decimal _precio;
        private Conexion _conexion;


        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ClaseCitas()
        {
            _id = 0;
            _cliente = string.Empty;
            _telefono = string.Empty;
            _servicio = string.Empty;
            _especialista = string.Empty;
            _fecha = DateTime.Now;
            _hora = string.Empty;
            _duracion = string.Empty;
            _notas = string.Empty;
            _estado = "Activo";
            _precio = 0;
            _conexion = new Conexion();
        }

        /// <summary>
        /// Constructor completo
        /// </summary>
        public ClaseCitas(int id, string cliente, string telefono, string servicio, string especialista, DateTime fecha, string hora, string duracion, string notas, string estado, decimal precio)
        {
            _id = id;
            _cliente = cliente;
            _telefono = telefono;
            _servicio = servicio;
            _especialista = especialista;
            _fecha = fecha;
            _hora = hora;
            _duracion = duracion;
            _notas = notas;
            _estado = estado;
            _precio = (decimal)precio;
            _conexion = new Conexion();
        }

        public int ID { get { return _id; } set { _id = value; } }
        public string Cliente { get { return _cliente; } set { _cliente = value; } }
        public string Telefono { get { return _telefono; } set { _telefono = value; } }
        public string Servicio { get { return _servicio; } set { _servicio = value; } }
        public string Especialista { get { return _especialista; } set { _especialista = value; } }
        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
        public string Hora { get { return _hora; } set { _hora = value; } }
        public string Duracion { get { return _duracion; } set { _duracion = value; } }
        public string Notas { get { return _notas; } set { _notas = value; } }
        public string Estado { get { return _estado; } set { _estado = value; } }
        public decimal Precio { get { return (decimal)_precio; } set { _precio = value; } }

        public override string ToString()
        {
            return $"Id: {_id} Cliente: {_cliente} Servicio: {_servicio} Fecha: {_fecha.ToShortDateString()}";
        }

        private bool Validar()
        {
            if (_cliente == string.Empty) return false;
            if (_servicio == string.Empty) return false;
            if (_especialista == string.Empty) return false;
            if (_estado == string.Empty) return false;
            if (_precio < 0) return false;
            return true;
        }
        
        public bool Guardar()
        {
            if (!Validar())
            {
                string strFecha = _fecha.ToString("yyyy-MM-dd");
                string strHora = _hora;
                string strPrecio = _precio.ToString().Replace(',', '.');

                string SQL = $"insert into citas (cliente, telefono, servicio, especialista, fecha, hora, duracion, notas, estado, precio) " +
                             $"values('{_cliente}', '{_telefono}', '{_servicio}', '{_especialista}', '{strFecha}', '{strHora}', '{_duracion}', '{_notas}', '{_estado}', {strPrecio})";

                try
                {
                    SqlConnection cnAbierta = _conexion.Abrir();
                    SqlCommand comando = new SqlCommand(SQL, cnAbierta);
                    comando.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) 
                {
                    throw new Exception("Error al guardar la cita: " + ex.Message);
                }
                finally
                {
                    _conexion.Cerrar();
                }
            }
            else
            {
                return false;
            }
        }

        public bool Modificar()
        {
            if (!Validar() && _id > 0)
            {
                string strFecha = _fecha.ToString("yyyy-MM-dd");
                string strHora = _hora;
                string strPrecio = _precio.ToString().Replace(',', '.');

                string SQL = $"update citas set cliente='{_cliente}', telefono='{_telefono}', servicio='{_servicio}', " +
                             $"especialista='{_especialista}', fecha='{strFecha}', hora='{strHora}', duracion='{_duracion}', " +
                             $"notas='{_notas}', estado='{_estado}', precio={strPrecio} where id={_id}";

                try
                {
                    SqlConnection cnAbierta = _conexion.Abrir();
                    SqlCommand comando = new SqlCommand(SQL, cnAbierta);
                    comando.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) 
                {
                    throw new Exception("Error al guardar la cita: " + ex.Message);
                }
                finally
                {
                    _conexion.Cerrar();
                }
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar()
        {
            if (_id > 0)
            {
                string SQL = $"delete from citas where id={_id}";
                try
                {
                    SqlConnection cnAbierta = _conexion.Abrir();
                    SqlCommand comando = new SqlCommand(SQL, cnAbierta);
                    comando.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al guardar la cita: " + ex.Message);
                }
                finally
                {
                    _conexion.Cerrar();
                }
            }
            else
            {
                return false;
            }
        }
    }
}
