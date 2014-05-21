using System;
using System.IO;

namespace Raiz.Deployment.ClientManager
{
    public class DeploySettings
    {
        private static bool usuarioAceptoNotificacion = true;

        public DeploySettings()
        {
            UsuarioAceptoNotificacion = true;
        }

        public static Guid IdCliente { get; set; }

        public static bool UsuarioAceptoNotificacion
        {
            get { return usuarioAceptoNotificacion; }
            set { usuarioAceptoNotificacion = value; }
        }


        public static string ObtenerRutaServidor()
        {
            return "http://192.168.74.1/RaizNet/Modulos/";
        }

        public static string ObtenerRutaLocal()
        {
            string _rutaInstalacion = "RaizNetTest";
            var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), _rutaInstalacion);
            return ruta;

        }

        public static  string ObtenerNombreLog()
        {
            return "Descargas.txt";

        }

    }
}
