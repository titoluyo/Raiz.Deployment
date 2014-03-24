using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using Raiz.Deployment.BL;
using Raiz.Deployment.DTO;


namespace Raiz.Deployment.Svc.Lib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class DeployService : IDeployService
    {

        private readonly Dictionary<Guid, IDeployNotifyCallback> clients = new Dictionary<Guid, IDeployNotifyCallback>();


        public List<PubComponente> ConsultarPublicaciones()
        {
            var obj = new PublicacionBL();
            return obj.ConsultarPublicaciones();
        }

        public PubComponente ConsultarPublicacionPorComponente(string componente)
        {
            var obj = new PublicacionBL();
            return obj.ConsultarPublicacionPorComponente(componente);
        }

        Guid IDeployService.Subscribe()
        {
            var callback = OperationContext.Current.GetCallbackChannel<IDeployNotifyCallback>();

            var clientId = Guid.NewGuid();

            if (callback != null)
            {
                lock (clients)
                {
                    clients.Add(clientId, callback);
                }
            }

            return clientId;
        }

        void IDeployService.Unsubscribe(Guid clientId)
        {
            lock (clients)
            {
                if (clients.ContainsKey(clientId))
                {
                    clients.Remove(clientId);
                }
            }
        }

        void IDeployService.Notificar(Guid clientId,PubComponente actualizacion)
        {
            BroadcastMessage(clientId, actualizacion);
        }

        private void BroadcastMessage(Guid clientId, PubComponente actualizacion)
        {
            // Call each client's callback method
            ThreadPool.QueueUserWorkItem
            (
                delegate
                {
                    lock (clients)
                    {
                        var disconnectedClientGuids = new List<Guid>();

                        foreach (KeyValuePair<Guid, IDeployNotifyCallback> client in clients)
                        {
                            try
                            {
                                client.Value.RecepcionarNotificacion(actualizacion);
                            }
                            catch (Exception)
                            {
                                disconnectedClientGuids.Add(client.Key);
                            }
                        }

                        foreach (Guid clientGuid in disconnectedClientGuids)
                        {
                            clients.Remove(clientGuid);
                        }
                    }
                }
            );
        }

    }
}
