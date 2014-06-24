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

            using (var ctx = new RaizNetContext())
            {

                var listaPre = ctx.ListarPublicacionesVigentes().ToList();

                var resultPre = (from tm in ctx.TBMRaizNetPubComponente
                              //from td in listaPre 
                              //where tm.idPublicacion == td.idPublicacion
                              select tm).ToList();

                var result = (from a in resultPre
                              join d in listaPre on a.idPublicacion equals d.idPublicacion
                              select a).ToList();
                

                return result;
            }
        }

        public List<PubComponente> ConsultarPublicaciones(string usuario)
        {

            using (var ctx = new RaizNetContext())
            {
                var resultfinal = new List<PubComponente>();

                var listaPre = ctx.ListarPublicacionesVigentes().ToList();
                var resultPre = (from tm in ctx.TBMRaizNetPubComponente
                                 select tm).ToList();

                var result = (from a in resultPre
                              join d in listaPre on a.idPublicacion equals d.idPublicacion
                              select a).ToList();

                var objAut = new AutorizacionBL();
                var compons = objAut.ListarComponentesUsoPorUsuario(usuario);
                foreach (var componente in result)
                {
                    if (compons.Exists(p => componente.componente.Contains(p)))
                    {
                        resultfinal.Add(componente);

                    }

                }
                return resultfinal;
            }
        }

        public PubComponente ConsultarPublicacionPorComponente(string componente)
        {
            using (var ctx = new RaizNetContext())
            {
                var result = (from tm in ctx.TBMRaizNetPubComponente
                              where tm.componente == componente
                              select tm).LastOrDefault();
                return result;

            }

            //return _listaComponentes.Find(p => p.componente == componente);
        }

        public void RegistrarPublicacion(PubComponente publicacion)
        {
//            Singleton.Instance.ListaPublicaciones.RemoveAll(p => p.componente == publicacion.componente);
  //          Singleton.Instance.ListaPublicaciones.Add(publicacion);
            
            using (var ctx = new RaizNetContext())
            {
                ctx.TBMRaizNetPubComponente.Add(publicacion);
                ctx.SaveChanges();
            }

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
