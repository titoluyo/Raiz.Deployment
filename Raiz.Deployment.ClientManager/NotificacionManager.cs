using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using Raiz.Deployment.ClientManager.DeployService;
using Raiz.Deployment.DTO;


//using PubComponente = Raiz.Deployment.DTO.PubComponente;

namespace Raiz.Deployment.ClientManager
{

    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Single,UseSynchronizationContext = false)]
    public class NotificacionManager: IDeployServiceCallback
    {
        //private SynchronizationContext _uiSyncContext = null;
        private DeployServiceClient _objsvc = null;
        private InstanceContext _instanceContext;
        private Guid _idCliente;
        public Suscritor _suscrito=new Suscritor();

        public NotificacionManager()
        {
            _instanceContext = new InstanceContext(this);
            _objsvc = new DeployServiceClient(_instanceContext, "NetTcpBinding_IDeployService");

        }


        public void Conectar(string usuario)
        {
            try
            {
              //  _uiSyncContext = SynchronizationContext.Current;
                _suscrito.IP = LocalIPAddress();
                _suscrito.Usuario = usuario;
                _suscrito.FechaIngreso = DateTime.Now;
                _objsvc.Open();
                _idCliente = _objsvc.Subscribe(_suscrito);
                DeploySettings.IdCliente = _idCliente;
            }
            catch (Exception)
            {

                ;
            }
            
        }

        public void Desconectar()
        {
            //_objsvc.Close();
            if (_objsvc != null)
            {
                try
                {
                    if (_objsvc.State != CommunicationState.Faulted)
                    {
                        _objsvc.Unsubscribe(DeploySettings.IdCliente);
                        _objsvc.Close();
                    }
                }
                catch(Exception ex)
                {
                    _objsvc.Abort();
                }
            }
        }

        public void Notificar()
        {
            _objsvc.Notificar(_idCliente, new List<PubComponente>());
        }

        public void Notificar(List<PubComponente> actualizacion)
        {
            _objsvc.Notificar(_idCliente,actualizacion);
        }

        public string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        public void RecepcionarNotificacionMasiva(List<PubComponente> actualizaciones)
        {
            //MessageBox.Show(String.Format("Hay una nueva versión del componente {0}, la versión es la siguiente:{1}",actualizacion.componente,actualizacion.version));
            //Dependendiendo del nivel de urgencia

            if (actualizaciones.Count > 0)
            {
                var actualizacion = actualizaciones[0];
                actualizacion.nivelUrgencia = 3;

                var update = new UpdateManager();
                if (actualizacion.nivelUrgencia != null && (int)actualizacion.nivelUrgencia == (int)UpdateManager.NivelForzado.Notificacion)
                {
                    //Notificar al cliente que hay una aplicación,
                    //que debe cerrar la aplicación para que se instalen las ultimas versiones
                    update.Notificar();

                }
                else if (actualizacion.nivelUrgencia != null && (int)actualizacion.nivelUrgencia == (int)UpdateManager.NivelForzado.NotificacionPersistente)
                {
                    //Iniciar un periodo de notificaciones hasta que el cliente cierre 
                    //su aplicación y vuelva a ingresar
                    update.RepetirNotificacion();
                }
                else if (actualizacion.nivelUrgencia != null && (int)actualizacion.nivelUrgencia == (int)UpdateManager.NivelForzado.Forzado)
                {
                    //Informarle al usuario que deberá cerrar su aplicación inmediatamente,
                    //y nno se dejará abrir ninguna pantalla del componente que se desea actualizar
                    //se inhabilitará la pantalla y se bloqueará 
                    update.ForzarCerrado(actualizaciones);
                }
            }

        }

        public void RecepcionarNotificacionPersonal(List<PubComponente> actualizaciones)
        {

            if (actualizaciones.Count > 0)
            {
                var actualizacion = actualizaciones[0];
                actualizacion.nivelUrgencia = 3;

                var update = new UpdateManager();
                if (actualizacion.nivelUrgencia != null && (int)actualizacion.nivelUrgencia == (int)UpdateManager.NivelForzado.Notificacion)
                {
                    //Notificar al cliente que hay una aplicación,
                    //que debe cerrar la aplicación para que se instalen las ultimas versiones
                    update.Notificar();

                }
                else if (actualizacion.nivelUrgencia != null && (int)actualizacion.nivelUrgencia == (int)UpdateManager.NivelForzado.NotificacionPersistente)
                {
                    //Iniciar un periodo de notificaciones hasta que el cliente cierre 
                    //su aplicación y vuelva a ingresar
                    update.RepetirNotificacion();
                }
                else if (actualizacion.nivelUrgencia != null && (int)actualizacion.nivelUrgencia == (int)UpdateManager.NivelForzado.Forzado)
                {
                    //Informarle al usuario que deberá cerrar su aplicación inmediatamente,
                    //y nno se dejará abrir ninguna pantalla del componente que se desea actualizar
                    //se inhabilitará la pantalla y se bloqueará 
                    update.ForzarCerrado(actualizaciones);
                }
            }
        }

       public void RecepcionarMensajePersonal(string mensaje,int codigo)
       {
           MessageBox.Show(string.Format("Mensaje:{0}", mensaje), "Mensaje de Notificación", MessageBoxButtons.OK,MessageBoxIcon.Information);
       }

       public void ForzarCierreAplicacion(string mensaje)
       {
           var update = new UpdateManager();
           update.ForzarCierreInmediatamente(mensaje);

       }

       public List<DescargaComponente> VersionesInstaladasCliente()
       {
           var logger = new LogManager();
           return logger.ListarDescargas();
       }


    }


}
