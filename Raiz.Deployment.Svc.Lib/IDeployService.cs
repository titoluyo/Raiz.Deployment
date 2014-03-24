using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Raiz.Deployment.DTO;

namespace Raiz.Deployment.Svc.Lib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract( CallbackContract = typeof(IDeployNotifyCallback))]
    public interface IDeployService
    {
        [OperationContract]
        List<PubComponente> ConsultarPublicaciones();

        [OperationContract]
        PubComponente ConsultarPublicacionPorComponente(string componente);


        /// <summary>
        /// Subcribes a client for any message broadcast.
        /// </summary>
        /// <returns>An id that will identify a client.</returns>
        [OperationContract]
        Guid Subscribe();


        /// <summary>
        /// Unsubscribes a client from any message broadcast.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        [OperationContract(IsOneWay = true)]
        void Unsubscribe(Guid clientId);


        /// <summary>
        /// Broadcasts a message to other connected clients.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="message">The message to be broadcasted.</param>
        [OperationContract]
        void Notificar(Guid clientId, PubComponente actualizacion);

    }


    public interface IDeployNotifyCallback
    {
        [OperationContract(IsOneWay = true)]
        void RecepcionarNotificacion(PubComponente actualizacion);
    }


}
