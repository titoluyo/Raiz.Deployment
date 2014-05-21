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
            return "http://192.168.105.145/RaizNet/Modulos/";
        }

        public static string ObtenerRutaLocal()
        {
            string _rutaInstalacion = "RaizNetTest";
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), _rutaInstalacion);

        }

        public static  string ObtenerNombreLog()
        {
            return "Descargas.txt";

        }

    }
}
