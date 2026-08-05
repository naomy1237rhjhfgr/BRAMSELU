namespace BRAMSELU
{
    public static class SesionActual
    {
        public static string NombreCompleto { get; set; }
        public static string TipoUsuario { get; set; }
        public static bool EstaAutenticado { get; set; } = false;

        public static void IniciarSesion(string nombre, string tipo)
        {
            NombreCompleto = nombre;
            TipoUsuario = tipo;
            EstaAutenticado = true;
        }

        public static void CerrarSesion()
        {
            NombreCompleto = string.Empty;
            TipoUsuario = string.Empty;
            EstaAutenticado = false;
        }
    }
}