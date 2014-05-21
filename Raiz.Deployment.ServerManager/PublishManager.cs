using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using Raiz.Deployment.DTO;
using Raiz.Deployment.ServerManager.DeployService;

namespace Raiz.Deployment.ServerManager
{
    public class PublishManager
    {
        private string _rutaPublicacion = "";

        private DeployServiceClient _objsvc = null;
        private InstanceContext _instanceContext;

        public PublishManager()
        {
            _rutaPublicacion = PublishSettings.RutaPublicacion;
        }
        
        public System.Version ObtenerComponentePublicado(string componenteName)
        {
            _rutaPublicacion = PublishSettings.RutaPublicacion;
            //Validar la existencia del componente en el directorio según el modulo
            if (Directory.Exists(_rutaPublicacion))
            {
                var rutaComponente =  Path.Combine(_rutaPublicacion, componenteName);
                if (File.Exists(rutaComponente))
                {   
                    //var assy = Assembly.LoadFrom(rutaComponente);
                    //var assy = Assembly.LoadFile(rutaComponente);
                    var assy= AssemblyName.GetAssemblyName(rutaComponente);
                    return assy.Version;
                }
            }
            return null;

            var modulo = GetSeccionName(componenteName, 1);
            var ruta = Path.Combine(_rutaPublicacion, modulo);
            if (Directory.Exists(ruta))
            {
                //Es un módulo y se deberá buscar dentro el componente a buscar
                var rutaComponente = Path.Combine(ruta, componenteName);
                if (File.Exists(rutaComponente))
                {
                    var assy = Assembly.LoadFrom(rutaComponente);
                    return assy.GetName().Version;
                }
            }
            return null;
        }

        public string GetSeccionName(string assemblyName, int seccion)
        {
            var secciones=assemblyName.Split('.');
            try
            {
                return secciones[seccion];
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public void RealizarPublicacion (List<PubComponente> publicaciones)
        {
            var notifyCallBack = new NotificacionManager();
            var objsvc = new DeployServiceClient(new InstanceContext(notifyCallBack));

            notifyCallBack.Conectar("Admin");

            foreach (var publicacion in publicaciones)
            {
                objsvc.RegistrarPublicacion(publicacion);    
            }
            
            notifyCallBack.Notificar(publicaciones);
            notifyCallBack.Desconectar();
        }

        public void CopiarComponente(string rutaOrigen)
        {
            var componenteName = Path.GetFileName(rutaOrigen);
            var rutaPub = Path.Combine(_rutaPublicacion, componenteName);
            
            if (!Directory.Exists(_rutaPublicacion))
            {
                Directory.CreateDirectory(_rutaPublicacion);
            }

            //Verificar que exista la carpeta de BACKUP
            var bkPath = Path.Combine(_rutaPublicacion, "BK");
            if (!Directory.Exists(bkPath))
            {
                Directory.CreateDirectory(bkPath);
            }
            if(File.Exists(rutaPub))
                File.Copy(rutaPub, Path.Combine(bkPath,componenteName ),true);

            File.Copy(rutaOrigen, rutaPub,true);
        }



    }
    

}
