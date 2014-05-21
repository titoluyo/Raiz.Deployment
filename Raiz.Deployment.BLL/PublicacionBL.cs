using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raiz.Deployment.DTO;
using Raiz.Deployment.Persistencia;


namespace Raiz.Deployment.BL
{
    public class PublicacionBL
    {

        private List<PubComponente> _listaComponentes=new List<PubComponente>();

        public PublicacionBL()
        {
            
            
        }

        public List<PubComponente> ConsultarPublicaciones()
        {
            return Singleton.Instance.ListaPublicaciones;
            //var publicaciones = Singleton.Instance.ListaPublicaciones;
        }

        public PubComponente ConsultarPublicacionPorComponente(string componente)
        {
            return _listaComponentes.Find(p => p.componente == componente);
        }

        public void RegistrarPublicacion(PubComponente publicacion)
        {
            Singleton.Instance.ListaPublicaciones.RemoveAll(p => p.componente == publicacion.componente);
            Singleton.Instance.ListaPublicaciones.Add(publicacion);
        }

        public List<Suscritor> ListarSuscriptores()
        {
            return Singleton.Instance.Suscritores;
        }

        public List<Suscritor> ListarUsuariosNotificar(List<PubComponente> publicaciones )
        {
            var usuarios = Singleton.Instance.Suscritores;
            var objAut = new AutorizacionBL();
            var notificados = new List<Suscritor>();
            foreach (var usuario  in usuarios)
            {
                var compons = objAut.ListarComponentesUsoPorUsuario(usuario.Usuario);
                if (publicaciones.Exists(p => compons.Any(t => p.componente.Contains(t))))
                {
                    notificados.Add(usuario);
                }
            }
            return notificados;
        }

        public void IncrementarNotificacionesSuscrito(Guid id)
        {
            Singleton.Instance.Suscritores.Find(p => p.Id == id).Notificaciones += 1;
        }


    }
}
