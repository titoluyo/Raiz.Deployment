using System;
using System.Configuration;
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
            //return "http://192.168.105.145/RaizNet/Modulos/";

            var ruta=ConfigurationManager.AppSettings["rutaServidor"];
            return ruta;


        }

        public static string ObtenerRutaLocal()
        {
            string _rutaInstalacion = ConfigurationManager.AppSettings["carpetaLocal"]; //"RaizNetTest";
            var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), _rutaInstalacion);
            return ruta;

        }

        public static  string ObtenerNombreLog()
        {
            //return "Descargas.txt";
            return ConfigurationManager.AppSettings["nombreLog"];

        }

        public static string UsuarioConectado { get; set; }

        public static string OpcionAdministracionMenu()
        {
            //return "RAI0001";
           var opcionAdmin= ConfigurationManager.AppSettings["opcionAdmin"];
           return opcionAdmin;
        }

    }
}
