using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raiz.Deployment.DTO;

namespace Raiz.Deployment.BL
{
    public sealed class Singleton
    {
        
        class SingletonCreator
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static SingletonCreator()
            {
            }

            internal static readonly Singleton instance = new Singleton();
        }
        public static Singleton Instance
        {
            get
            {
                return SingletonCreator.instance;
            }
        }
        private List<PubComponente> listaPublicaciones=new List<PubComponente>();

        public List<PubComponente> ListaPublicaciones
        {
            get { return listaPublicaciones; }
            set { listaPublicaciones = value; }
        }

        private List<Suscritor> suscritores=new List<Suscritor>();
        public List<Suscritor> Suscritores
        {
            get { return suscritores; }
            set { suscritores = value; }
        }



    }
}
