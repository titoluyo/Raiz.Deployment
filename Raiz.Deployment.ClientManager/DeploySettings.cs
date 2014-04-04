using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Raiz.Deployment.ClientManager
{
    public class DeploySettings
    {

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
