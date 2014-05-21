using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using Raiz.Deployment.DTO;
using Raiz.Deployment.ServerManager.DeployService;

namespace Raiz.Deployment.ServerManager
{
    public class SuscriptionManager
    {

        private DeployServiceClient _objsvc = null;
        private InstanceContext _instanceContext;

        public SuscriptionManager()
        {
            var notifyCallBack = new NotificacionManager();
            _objsvc = new DeployServiceClient(new InstanceContext(notifyCallBack));
        }

        public List<Suscritor> ListarSuscritores()
        {
            if (_objsvc.State == CommunicationState.Faulted)
                MessageBox.Show("Ha ocurrido un error al intentar conectarse al servidor");

            var result = _objsvc.ListarSuscriptores();
            return result;
        }

    }
}
