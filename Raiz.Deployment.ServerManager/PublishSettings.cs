using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiz.Deployment.ServerManager
{
    public class PublishSettings
    {

        public static string RutaPublicacion { get; set; }
        public static string RutaOrigen { get; set; }

        public static Guid IdCliente { get; set; }
        public static bool NotificacionPendiente { get; set; }


        public static string ObtenerRutaServidor()
        {
            return @"\\192.168.105.145\RaizNet\Modulos";
            return @"C:\inetpub\wwwroot\RaizNet\Modulos";
        }
        public static string GetEjecutableClienteFolder()
        {

            return "Ejecutables Cliente";
        }


        public static string ObtenerRutaPasesRoot()
        {
            return @"\\Dopsi05\Preproduccion\PasesProduccion";
        }

        public static string GetFolderTesting()
        {
            return "testing";

        }

        public static  string GetFolderProduccion()
        {
            return "Produccion";
        }
    }
}
