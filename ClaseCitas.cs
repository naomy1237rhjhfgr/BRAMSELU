using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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
            _estado = "Pendiente, Confirmada, Completada, Cancelada";
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

        public DataTable ListarCitas(string filtro = "")
        {
            return datosDAL.ObtenerCitas(filtro);
        }

        public string Guardar()
        {
            if (string.IsNullOrEmpty(_cliente)) return "Debe seleccionar un cliente.";
            if (string.IsNullOrEmpty(_servicio)) return "Debe seleccionar un tipo de servicio.";
            if (string.IsNullOrEmpty(_telefono) || _telefono.Length < 9) return "El teléfono debe contar con 8 dígitos válidos (XXXX-XXXX).";
            if (_precio < 0) return "El precio asignado no puede ser un valor negativo.";
        
            bool exito;
            if (_id == 0) 
        {
                exito = datosDAL.Nuevo(this);
                }
            else 
                {
                exito = datosDAL.Editar(this);
                }

            return exito ? "OK" : "Error de ejecución en la Base de Datos.";
                }

        public bool Eliminar(int id, out string mensaje)
            {
            if (id <= 0)
            {
                mensaje = "ID no válido.";
                return false;
            }

            bool exito = datosDAL.Eliminar(id);
            mensaje = exito ? "OK" : "No se logró eliminar el registro solicitado.";
            return exito;
        }
    }
}
