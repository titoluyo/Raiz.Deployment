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

        private readonly Dictionary<Suscritor, IDeployNotifyCallback> clients =
            new Dictionary<Suscritor, IDeployNotifyCallback>();


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

        public void RegistrarPublicacion(PubComponente publicacion)
        {
            var obj = new PublicacionBL();
            obj.RegistrarPublicacion(publicacion);
        }


        public List<Suscritor> ListarSuscriptores()
        {
            var obj = new PublicacionBL();
            return obj.ListarSuscriptores();
        }


        Guid IDeployService.Subscribe(Suscritor suscrito)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IDeployNotifyCallback>();

            var clientId = Guid.NewGuid();
            suscrito.Id = clientId;

            if (callback != null)
            {
                lock (clients)
                {
                    //Verificar si el cliente ya existe

                    /*
                    if (clients.Count(p => p.Key.IP == suscrito.IP) == 0)
                    {
                        */


                    clients.Add(suscrito, callback);
                    Singleton.Instance.Suscritores.Add(suscrito);
                    NotificarAdministradores(clientId, MensajesServidor.USUARIO_CONECTADO);

                    //}

                }
            }

            return clientId;
        }

        void IDeployService.Unsubscribe(Guid clientId)
        {
            lock (clients)
            {
                var cliente = clients.FirstOrDefault(p => p.Key.Id == clientId);
                if (cliente.Key != null)
                {
                    clients.Remove(cliente.Key);
                    Singleton.Instance.Suscritores.Remove(cliente.Key);
                    //Notificar a los adminmistradores
                    NotificarAdministradores(clientId, MensajesServidor.USUARIO_DESCONECTADO);

                }

            }
        }

        void IDeployService.Notificar(Guid clientId, List<PubComponente> actualizaciones)
        {

            //Aca se debe realizar la validación de a quiénes se les debe notificar de acuerdo 
            //a las actualizaciones. De acuerdo al módulo
            var objBL = new PublicacionBL();
            var suscritos = objBL.ListarUsuariosNotificar(actualizaciones);
            BroadcastMessage(clientId, actualizaciones, suscritos);
        }

        void IDeployService.NotificarUsuario(Guid idOrigen, Guid idDestino, List<PubComponente> actualizaciones)
        {
            var cliente = clients.FirstOrDefault(p => p.Key.Id == idDestino);
            try
            {
                cliente.Value.RecepcionarNotificacionPersonal(actualizaciones);
            }
            catch (Exception)
            {
                if (cliente.Key != null)
                {
                    clients.Remove(cliente.Key);
                    Singleton.Instance.Suscritores.Remove(cliente.Key);
                }

            }

        }

        void IDeployService.EnviarMensajeCliente(Guid idOrigen, Guid idDestino, string mensaje, int msje)
        {
            var cliente = clients.FirstOrDefault(p => p.Key.Id == idDestino);
            try
            {
                cliente.Value.RecepcionarMensajePersonal(mensaje, msje);
            }
            catch (Exception)
            {
                if (cliente.Key != null)
                {
                    clients.Remove(cliente.Key);
                    Singleton.Instance.Suscritores.Remove(cliente.Key);
                }
            }
        }

        void IDeployService.ForzarCierreAplicacionCliente(Guid idOrigen, Guid idDestino, string mensaje)
        {
            var cliente = clients.FirstOrDefault(p => p.Key.Id == idDestino);
            try
            {
                cliente.Value.ForzarCierreAplicacion(mensaje);
            }
            catch (Exception)
            {
                if (cliente.Key != null)
                {
                    //clients.Remove(cliente.Key);
                    Singleton.Instance.Suscritores.Remove(cliente.Key);
                }
            }

        }
        
        List<DescargaComponente> IDeployService.ListarVersionesInstaladasCliente(Guid idOrigen, Guid idDestino)
        {
            var cliente = clients.FirstOrDefault(p => p.Key.Id == idDestino);
            var result = new List<DescargaComponente>();
            try
            {
                result=cliente.Value.VersionesInstaladasCliente();
            }
            catch (Exception)
            {
                if (cliente.Key != null)
                {
                    //clients.Remove(cliente.Key);
                    Singleton.Instance.Suscritores.Remove(cliente.Key);
                }
            }
            return result;
        }
         

        private void BroadcastMessage(Guid clientId,List<PubComponente> actualizaciones,List<Suscritor> Suscritos)
        {
            // Call each client's callback method
            ThreadPool.QueueUserWorkItem
            (
                delegate
                {
                    lock (clients)
                    {
                        var disconnectedClientGuids = new List<Guid>();
                        foreach (KeyValuePair<Suscritor, IDeployNotifyCallback> client in clients)
                        {
                            if (!Suscritos.Exists(p => p == client.Key)) continue;
                            try
                            {
                                client.Value.RecepcionarNotificacionMasiva(actualizaciones);
                            }
                            catch (Exception)
                            {
                                disconnectedClientGuids.Add(client.Key.Id);
                            }
                        }


                        foreach (Guid clientGuid in disconnectedClientGuids)
                        {
                            var cliente = clients.FirstOrDefault(p => p.Key.Id == clientGuid);
                            if (cliente.Key != null)
                            {   clients.Remove(cliente.Key);
                                Singleton.Instance.Suscritores.Remove(cliente.Key);
                            }
                        }


                    }
                }
            );
        }


        private void NotificarAdministradores(Guid clientId,int codigo)
        {
            // Call each client's callback method
            ThreadPool.QueueUserWorkItem
            (
                delegate
                {
                    lock (clients)
                    {
                        var disconnectedClientGuids = new List<Guid>();
                        foreach (KeyValuePair<Suscritor, IDeployNotifyCallback> client in clients)
                        {
                            try
                            {
                                if (client.Key.TipoUsuario != 1) continue;
                                client.Value.RecepcionarMensajePersonal(string.Empty,codigo);
                            }
                            catch (Exception)
                            {
                                disconnectedClientGuids.Add(client.Key.Id);
                            }
                        }


                        foreach (Guid clientGuid in disconnectedClientGuids)
                        {
                            var cliente = clients.FirstOrDefault(p => p.Key.Id == clientGuid);
                            if (cliente.Key != null)
                            {
                                clients.Remove(cliente.Key);
                                Singleton.Instance.Suscritores.Remove(cliente.Key);
                            }
                        }


                    }
                }
            );
        }

    }
}
