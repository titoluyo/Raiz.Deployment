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
