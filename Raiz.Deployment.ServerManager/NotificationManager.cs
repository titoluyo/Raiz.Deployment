using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Text;
using System.Threading;
using Raiz.Deployment.DTO;
using Raiz.Deployment.ServerManager.DeployService;

namespace Raiz.Deployment.ServerManager
{

    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Single, UseSynchronizationContext = false)]
    public class NotificacionManager : IDeployServiceCallback
    {
        //private SynchronizationContext _uiSyncContext = null;
        private DeployServiceClient _objsvc = null;
        private InstanceContext _instanceContext;
        public Suscritor _suscrito = new Suscritor();

        public NotificacionManager()
        {
            _instanceContext = new InstanceContext(this);
            _objsvc = new DeployServiceClient(_instanceContext, "NetTcpBinding_IDeployService");
        }


        public void Conectar(string usuario)
        {
//            _uiSyncContext = SynchronizationContext.Current;
            _suscrito.IP = LocalIPAddress();
            _suscrito.Usuario = usuario;
            _suscrito.FechaIngreso = DateTime.Now;
            _suscrito.TipoUsuario = 1;
            _objsvc.Open();
            PublishSettings.IdCliente=_objsvc.Subscribe(_suscrito);
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
                        _objsvc.Unsubscribe(PublishSettings.IdCliente);
                        _objsvc.Close();
                    }
                }
                catch
                {
                    _objsvc.Abort();
                }
            }
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

        public void Notificar()
        {
            _objsvc.Notificar(PublishSettings.IdCliente, new List<PubComponente>()); 
        }

        public void Notificar(List<PubComponente> actualizaciones)
        {
            _objsvc.Notificar(PublishSettings.IdCliente, actualizaciones);
        }

        public void ForzarCierreAplicacionCliente(Guid idDestino, string mensaje)
        {
            _objsvc.ForzarCierreAplicacionCliente(PublishSettings.IdCliente, idDestino, mensaje);
        }

        public void EnviarMensajePersonalCliente(Guid idDestino,string mensaje)
        {
            _objsvc.EnviarMensajeCliente(PublishSettings.IdCliente,idDestino,mensaje,0);
        }

        public List<DescargaComponente> ListarVersionesInstaladasCliente(Guid idDestino)
        {
            return _objsvc.ListarVersionesInstaladasCliente(PublishSettings.IdCliente, idDestino);
        }

        public void RecepcionarNotificacionMasiva(List<PubComponente> actualizaciones)
        {
            ;
        }

        public void RecepcionarNotificacionPersonal(List<PubComponente> actualizaciones)
        {
            ;
        }

        public void RecepcionarMensajePersonal(string mensaje,int codigo)
        {
            if (codigo == MensajesServidor.USUARIO_DESCONECTADO || codigo==MensajesServidor.USUARIO_CONECTADO)
            {
                PublishSettings.NotificacionPendiente = true;
            }
        }

        public void ForzarCierreAplicacion(string mensaje)
        {
            ;
        }

        public List<DescargaComponente> VersionesInstaladasCliente()
        {
            return null;
        }


    }

}
