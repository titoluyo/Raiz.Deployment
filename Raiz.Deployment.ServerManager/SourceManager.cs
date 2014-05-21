using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Raiz.Deployment.DTO;

namespace Raiz.Deployment.ServerManager
{
    public class SourceManager
    {
        private string _rutaPases = string.Empty;
        private string _testingFolder;
        private string _produccionFolder;
        private string _ejecutableCliente;
        private string _rutaExplorar;

        private PublishManager _publisher = new PublishManager();

        public SourceManager()
        {
            _testingFolder = PublishSettings.GetFolderTesting();
            _produccionFolder = PublishSettings.GetFolderProduccion();
            _ejecutableCliente = PublishSettings.GetEjecutableClienteFolder();
        }


        public enum Ambiente
        { Testing=1, Produccion=2}

        public string[] ObtenerRutasPorPase(string numPase)
        {
            var pases = Directory.GetDirectories(_rutaPases, numPase);
            return pases;
        }

        public List<PubComponente> ListarComponentesPorPase(string ruta, Ambiente ambiente)
        {
            var listaComponentes = new List<PubComponente>();
            if (ambiente == Ambiente.Testing)
               _rutaExplorar= Path.Combine(ruta,_ejecutableCliente,  _testingFolder);
            else
               _rutaExplorar= Path.Combine(ruta,_ejecutableCliente,  _produccionFolder);

            var root=Path.Combine(ruta, _ejecutableCliente);
            if (!Directory.Exists(root))
            {
                return listaComponentes;
            }

            var componentesBase = Directory.GetFiles(root);
            var componentes = Directory.GetFiles(_rutaExplorar,"*.dll*", SearchOption.AllDirectories);
            
            

            foreach (var componente in componentesBase)
            {
                if (componente.EndsWith(".dll") || componente.Contains(".dll"))
                {
                    var publicacion = new PubComponente();
                    var assy = Assembly.LoadFrom(componente);
                    var version = assy.GetName().Version;
                    publicacion.componente = componente;// Path.GetFileName(componente);// assy.GetName().Name;
                    var currentVersion = _publisher.ObtenerComponentePublicado(componente);
                    publicacion.version = version;
                    listaComponentes.Add(publicacion);
                }
            }

            foreach (var componente in componentes)
            {
                if (componente.EndsWith(".dll") || componente.Contains(".dll"))
                {
                    var publicacion = new PubComponente();
                    var assy = Assembly.LoadFrom(componente);
                    var version = assy.GetName().Version;
                    publicacion.componente = componente;// Path.GetFileName(componente);// assy.GetName().Name;
                    var currentVersion = _publisher.ObtenerComponentePublicado(componente);
                    publicacion.version = version;
                    listaComponentes.Add(publicacion);
                }
            }



            return listaComponentes;
        }


        public List<PublicacionStatus> ValidarVersionesPublicar(string ruta,Ambiente ambiente)
        {
            var listaPublicaciones = ListarComponentesPorPase(ruta, ambiente);

            var result = new List<PublicacionStatus>();
            var publicaciones = new List<PubComponente>();

            foreach (var publicacion in listaPublicaciones)
            {
                var statusPublicacion = new PublicacionStatus();
                statusPublicacion.componente =Path.GetFileName(publicacion.componente);
                statusPublicacion.version = publicacion.version;

                var currentVersion = _publisher.ObtenerComponentePublicado(statusPublicacion.componente);
                //Verificar si la versión que se encuentra en el pase es superior
                //a la versión que actualmente esta publicada en el repositorio
                //si no es mas actual, se deberá mostrar al usuario que versión
                //ha sido publicada.
                if (currentVersion==null || currentVersion < publicacion.version)
                {
                    //Si la versión a publicar es más reciente se deberá realizar la publicación
                    //de lo contrario se deberá mostrar al usuario que la versión esta pendiente
                    publicacion.fechaRegistro = DateTime.Now;
                    publicacion.descargaObligatoria = true;
                    _publisher.CopiarComponente(publicacion.componente);
                    publicacion.componente = statusPublicacion.componente;

                    if(publicacion.componente != null && publicacion.componente.EndsWith(".dll"))
                        publicaciones.Add(publicacion);
                    
                    statusPublicacion.Status = "OK";
                }
                else
                {
                    statusPublicacion.Status = string.Format("La versión publicada actualmente es igual o superior. ({0})", currentVersion.ToString());
                }

                result.Add(statusPublicacion);
            }
            _publisher.RealizarPublicacion(publicaciones);

            return result;

        }
    }

    public class PublicacionStatus : PubComponente
    {
        public string Status { get; set; }
    }


}
