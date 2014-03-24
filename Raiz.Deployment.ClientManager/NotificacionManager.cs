using System;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using Raiz.Deployment.ClientManager.DeployService;
using Raiz.Deployment.DTO;


//using PubComponente = Raiz.Deployment.DTO.PubComponente;

namespace Raiz.Deployment.ClientManager
{

    [CallbackBehavior(
        ConcurrencyMode = ConcurrencyMode.Single,
        UseSynchronizationContext = false)]
    public class NotificacionManager: IDeployServiceCallback
    {
        private SynchronizationContext _uiSyncContext = null;
        private DeployServiceClient _objsvc = null;
        private InstanceContext _instanceContext;
        private Guid _idCliente;
        public bool FeedBack { get; set; }
        

        public void Conectar()
        {
            _uiSyncContext = SynchronizationContext.Current;
            _instanceContext = new InstanceContext(this);
            _objsvc = new DeployServiceClient(_instanceContext, "NetTcpBinding_IDeployService");
            _objsvc.Open();

            _idCliente = _objsvc.Subscribe();
        }

        public void Desconectar()
        {
            _objsvc.Close();
            if (_objsvc != null)
            {
                try
                {
                    if (_objsvc.State != CommunicationState.Faulted)
                    {
                        _objsvc.Unsubscribe(_idCliente);
                        _objsvc.Close();
                    }
                }
                catch
                {
                    _objsvc.Abort();
                }
            }
        }

        public void Notificar()
        {
            _objsvc.Notificar(_idCliente, 
                new PubComponente());
        }

        public void Notificar(PubComponente actualizacion)
        {
            _objsvc.Notificar(_idCliente,actualizacion);
        }



        public void RecepcionarNotificacion( PubComponente actualizacion)
        {
            MessageBox.Show(String.Format("Hay una nueva versión del componente {0}, la versión es la siguiente:{1}",actualizacion.componente,actualizacion.version));
            var frm = new frmDownload();
            frm.Actualizacion = actualizacion;
            frm.ShowDialog();

        }


    }


}
