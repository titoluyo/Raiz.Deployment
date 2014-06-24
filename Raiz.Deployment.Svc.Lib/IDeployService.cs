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

        [OperationContract]
        void RegistrarPublicacion(PubComponente publicacion);

        [OperationContract]
        List<Suscritor> ListarSuscriptores();


        /// <summary>
        /// Subcribes a client for any message broadcast.
        /// </summary>
        /// <returns>An id that will identify a client.</returns>
        [OperationContract]
        Guid Subscribe(Suscritor suscrito);


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
        void Notificar(Guid clientId,List<PubComponente> actualizaciones);

        /// <summary>
        /// Broadcasts a message to other connected clients.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="message">The message to be broadcasted.</param>
        [OperationContract]
        void NotificarUsuario(Guid idOrigen, Guid idDestino, List<PubComponente> actualizaciones);

        
        [OperationContract]
        void EnviarMensajeCliente(Guid idOrigen, Guid idDestino, string mensaje, int msje);

        [OperationContract]
        void ForzarCierreAplicacionCliente(Guid idOrigen, Guid idDestino, string mensaje);

        
        [OperationContract]
        List<DescargaComponente> ListarVersionesInstaladasCliente(Guid idOrigen, Guid idDestino);

        [OperationContract]
        List<PubComponente> ConsultarPublicacionesPorUsuario(string usuario);
    }

    public interface IDeployNotifyCallback
    {
        [OperationContract(IsOneWay = true)]
        void RecepcionarNotificacionMasiva(List<PubComponente> actualizaciones);

        [OperationContract(IsOneWay = true)]
        void RecepcionarNotificacionPersonal(List<PubComponente> actualizaciones);

        [OperationContract(IsOneWay = true)]
        void RecepcionarMensajePersonal(string mensaje,int msje);

        [OperationContract(IsOneWay = true)]
        void ForzarCierreAplicacion(string mensaje);

        [OperationContract(IsOneWay = false)]
        List<DescargaComponente> VersionesInstaladasCliente();

    }


    
    [ServiceContract]
    public interface IMenuService
    {
        [OperationContract]
        int CrearItemMenu(Menu item, string tipo);

        [OperationContract]
        ConsultaRegistroMenu_Result ConsultarMenu(int idMenu);

        [OperationContract]
        List<BuscarMenu_Result> BuscarMenu(int idPadre, int idMenu, string descripcion);

        [OperationContract]
        List<ConsultaMenu_Result> ConsultaMenu(int idMenu, string descripcion, int estado, int visibilidad);

        [OperationContract]
        List<ConsultaMenuHijos_Result> ConsultaMenuHijos(int idMenuPadre);

        [OperationContract]
        List<Menu> ListarMenus(bool estado);
    }
     

}
