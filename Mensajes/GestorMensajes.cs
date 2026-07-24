using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAMSELU.Mensajes
{
    public enum TipoMensaje
    {
        Exito,
        Error,
        Advertencia,
        Informacion
    }
    public static class GestorMensajes
    {
        public static void Mostrar(string mensaje, TipoMensaje tipo)
        {
            frmMensaje frm = new frmMensaje(mensaje, tipo);
            frm.ShowDialog();
        }

        public static void Exito(string mensaje)
        {
            Mostrar(mensaje, TipoMensaje.Exito);
        }

        public static void Error(string mensaje)
        {
            Mostrar(mensaje, TipoMensaje.Error);
        }

        public static void Advertencia(string mensaje)
        {
            Mostrar(mensaje, TipoMensaje.Advertencia);
        }

        public static void Informacion(string mensaje)
        {
            Mostrar(mensaje, TipoMensaje.Informacion);
        }
    }
}
