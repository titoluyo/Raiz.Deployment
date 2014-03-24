using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.Windows.Forms;
using Raiz.Deployment.ClientManager.DeployService;
using Raiz.Deployment.DTO;
using PubComponente = Raiz.Deployment.DTO.PubComponente;


namespace Raiz.Deployment.ClientManager
{
    public class ModuleManager
    {

        private string _rutaDescargaServidor = string.Empty;
        private string _rutaInstalacion =string.Empty;
        private string _rutaLocal = "";
        private LogManager _logger = new LogManager();
        
        public ModuleManager()
        {
            _rutaLocal =DeploySettings.ObtenerRutaLocal() ;
            _rutaDescargaServidor = DeploySettings.ObtenerRutaServidor();
        }
        
        private List<DescargaComponente> ListarComponentesInstalados()
        {

            var lista = _logger.ListarDescargas();
            return lista;
        }

        public DescargaComponente DescargaNuevoComponente(PubComponente componente, DescargaComponente descarga)
        {
            
                descarga = new DescargaComponente();
                descarga.Id = Guid.NewGuid();
                descarga.Componente = componente.componente;
                descarga.version = string.Format("[{0}]", componente.version);
                descarga.FechaDescarga = DateTime.Now;
                descarga.Modulo = componente.idModulo.ToString();
                descarga.descargaObligatoria = (componente.descargaObligatoria ?? false);
                descarga.estado = 0;
            return descarga;
        }

        private void CrearCopiaLocalComponente(string componente,string version)
        {
            var rutaLocal = Path.Combine(_rutaLocal, componente);
            //Copiar la dll actual 
            if (File.Exists(rutaLocal) )
            {
                //Crear la carpeta si no existe
                var directorioVersion = string.Format("{0}_{1}",componente, version);
                if (!Directory.Exists(Path.Combine(_rutaLocal, directorioVersion)))
                {
                    Directory.CreateDirectory(Path.Combine(_rutaLocal, directorioVersion));
                }
                //Ahora realizar la copia de backup
                
                if (!File.Exists(Path.Combine(_rutaLocal,string.Format("{0}/{1}",directorioVersion, componente))))
                {
                    File.Copy(rutaLocal, Path.Combine(_rutaLocal, string.Format("{0}/{1}", directorioVersion, componente)));
                    File.Delete(rutaLocal);
                }
            }

        }

        public PubComponente ObtenerComponenteActualizado(string componente)
        {
            var notifyCallBack = new NotificacionManager();
            //Listar todas las actualizaciones de los componentes del servidor
            var objsvc = new DeployServiceClient(new InstanceContext(notifyCallBack));
            var componentesActualizados = objsvc.ConsultarPublicaciones();
            return componentesActualizados.FindLast(p => p.componente == componente);

        }
        
        public bool ValidaComponenteDescargar(PubComponente componente)
        {
          
            
            bool rpta = false;
            var rutaWeb = Path.Combine(_rutaDescargaServidor, componente.componente);
            var req = (HttpWebRequest)System.Net.WebRequest.Create(rutaWeb);
            try
            {
                var response = (HttpWebResponse)req.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                { 
                    //El componente esta disponible para su descarga
                  rpta= true;
                }
                response.Close();
            }
            catch (WebException ex)
            {
                if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotFound)
                {
                    //No esta disponible la descarga
                    rpta= false;
                }
            }
            
            return rpta;
        }
        
        private void DescargarComponente(PubComponente componente,DescargaComponente descarga)
        {
            
            //Creación de la ruta local
            if (!Directory.Exists(_rutaLocal))
            {
                Directory.CreateDirectory(_rutaLocal);
            }

            var rutaWeb = Path.Combine(_rutaDescargaServidor, componente.componente);
            var rutaLocal = Path.Combine(_rutaLocal, componente.componente);

            if (!ValidaComponenteDescargar(componente)) return; //La descarga esta disponible
            //Crear la copia local del componente si existiese
            CrearCopiaLocalComponente(componente.componente, (descarga==null?componente.version:descarga.version));
            

            using (var client = new WebClient())
            {

                try
                {
                    //Inicia la descarga

                    descarga = DescargaNuevoComponente(componente, descarga);
                    descarga.estado = DescargaComponente.EstadoDescarga.Iniciado;
                    _logger.RegistrarDescarga(descarga);

                    //Descarga del componente
                    client.DownloadFile(rutaWeb, rutaLocal);


                    //Finaliza la descarga
                    descarga.estado = DescargaComponente.EstadoDescarga.Finalizado;
                    _logger.RegistrarDescarga(descarga);
                }
                catch (WebException ex)
                {
                    if (ex.Response != null)
                    {
                        if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotFound)
                        {
                            MessageBox.Show(string.Format("No existe el componente en la ruta:{0}", rutaWeb));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void VerificarActualizaciones()
        {
            var notifyCallBack = new NotificacionManager();
            
            //Listar todas las actualizaciones de los componentes del servidor
            var objsvc = new DeployServiceClient(new InstanceContext(notifyCallBack));
            var componentesActualizados = objsvc.ConsultarPublicaciones();

            var componentesInstaladas = ListarComponentesInstalados();
            foreach (var componente in componentesActualizados)
            {
                //Verificar si existe el componente 
                //Si no existe y la descarga es obligatoria entonces descargar
                var comp = componentesInstaladas.FindLast(p => p.Componente == componente.componente);
                if (comp == null)
                {
                    //No existe el componente
                    if ((componente.descargaObligatoria ?? false))
                        //Descargar Componente
                        DescargarComponente(componente,comp);

                }
                else
                {
                    //Si existe el componente
                    if (componentesInstaladas.Any(p => p.FechaDescarga < componente.fechaRegistro))
                    {
                        if ((componente.descargaObligatoria ?? false))
                            DescargarComponente(componente,comp);
                    }
                }
            }
        }
        
        public  Assembly CargarComponente(string componente)
        {
            if (!File.Exists(Path.Combine(_rutaLocal, componente)))
            {
                //No está instalado, se debe verificar si existe el componente 
                MessageBox.Show("No esta instalado el componente requerido en este equipo.");
                var componenteActualizado = ObtenerComponenteActualizado(componente);
                if (componenteActualizado != null)
                {
                    //Verificar si esta disponible la descarga
                    if (!ValidaComponenteDescargar(componenteActualizado)) return null;
                    //Se consulta al usuario si desea realizar la descarga
                    if (MessageBox.Show(String.Format("¿Hay una versión disponible del componente {0}, versión {1}, desea instalarla? ", componenteActualizado.componente, componenteActualizado.version)
                         , "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var frm = new frmDownload();
                        frm.Actualizacion = componenteActualizado;
                        frm.ShowDialog();
                    }
                }
            }
            //Revisar si las dependencias del componente se encuentran instaladas en la PC
            CargarComponenteDomain(componente,"FrmMisSolicitudes");
            var assy = Assembly.LoadFrom(Path.Combine(_rutaLocal, componente));
            var alreadyLoaded = new Hashtable();
            CargarDependencias(assy, alreadyLoaded,0);
            return assy;
        }

        private void CargarDependencias(Assembly assembly, Hashtable alreadyLoaded, int indent)
        {
            AssemblyName fqn = assembly.GetName();
            if (alreadyLoaded.Contains(fqn.FullName))
            {
                Console.WriteLine("[{0}:{1}]", fqn.Name, fqn.Version);
                return;
            }
            alreadyLoaded[fqn.FullName] = fqn.FullName;
            var depedencias = ListarDependenciasComponente(assembly);

            foreach (var dependencia in depedencias)
            {
                Assembly referenced;
                
                try
                {
                    referenced = Assembly.Load(dependencia);
                    CargarDependencias(referenced, alreadyLoaded, indent + 2);

                }
                catch (FileNotFoundException ex)
                {
                    var dll = string.Format("{0}.dll", dependencia.Name);
                    if (!File.Exists(Path.Combine(_rutaLocal, dll)))
                    {

                        var componenteActualizado = ObtenerComponenteActualizado(dll);
                        if (componenteActualizado != null)
                        {
                            //Verificar si esta disponible la descarga
                            if (!ValidaComponenteDescargar(componenteActualizado)) return;
                            //Se consulta al usuario si desea realizar la descarga
                            DescargarComponente(componenteActualizado, null);
                            referenced = Assembly.LoadFrom(Path.Combine(_rutaLocal, dll));
                            CargarDependencias(referenced, alreadyLoaded, indent + 2);
                        }
                    }
                    //---------------------------------------------

                }
                catch(FileLoadException ex)
                {
                    var dll = string.Format("{0}.dll", dependencia.Name);

                    Console.Write(ex.FusionLog);

                    if (!File.Exists(Path.Combine(_rutaLocal, dll)))
                    {

                        var componenteActualizado = ObtenerComponenteActualizado(dll);
                        if (componenteActualizado != null)
                        {
                            //Verificar si esta disponible la descarga
                            if (!ValidaComponenteDescargar(componenteActualizado)) return;
                            //Se consulta al usuario si desea realizar la descarga
                            DescargarComponente(componenteActualizado, null);
                            referenced = Assembly.LoadFrom(Path.Combine(_rutaLocal, dll));
                            CargarDependencias(referenced, alreadyLoaded, indent + 2);
                        }
                    }
                    else
                    {
                        referenced = Assembly.LoadFrom(Path.Combine(_rutaLocal, dll));
                        CargarDependencias(referenced, alreadyLoaded, indent + 2);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                 

            }
        }

        public List<AssemblyName> ListarDependenciasComponente(Assembly assembly)
        {
            var result = new List<AssemblyName>();
            var fwpath = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
            var gacDependencies = AppDomain.CurrentDomain.GetAssemblies().ToList();


            foreach (var name in assembly.GetReferencedAssemblies())
            {
                if(!gacDependencies.Exists(p=>p.GetName()==name))
                result.Add(name);
            }
            return result;
        }


        public void CargarComponenteDomain(string componente,string formulario)
        {
            var dom = AppDomain.CreateDomain("Modulos");
            var rutaLocal = Path.Combine(_rutaLocal, componente);
            var frm =(Form)dom.CreateInstanceAndUnwrap(rutaLocal, formulario);
            frm.ShowDialog();
            

        }


    }

    public class DescargaComponente
    {

        public enum EstadoDescarga
        {   Pendiente=0,
            Iniciado=1,
            Finalizado=2,
            Interrumpido=3
        }

        public Guid Id { get; set; }
        public string Componente { get; set; }
        public DateTime FechaDescarga { get; set; }
        public string Modulo { get; set; }
        public string version { get; set; }
        public bool descargaObligatoria { get; set; }
        public EstadoDescarga estado { get; set; }
    }

    public class Componente
    {
        public string Nombre { get; set; }
        public Version VersionComponente { get; set; }
        public Byte[] Token { get; set; }

    }


}
