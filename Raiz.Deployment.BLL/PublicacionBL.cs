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
            var componente = new PubComponente();
            componente.idModulo = 1;
            componente.version = "1.0.1";
            componente.descargaObligatoria = true;
            componente.componente = "Raiz.Modulo1.dll";
            componente.fechaRegistro = DateTime.Now.AddHours(-2);

            _listaComponentes.Add(componente);
            
            componente=new PubComponente();
            componente.idModulo = 2;
            componente.version = "1.0.1";
            componente.descargaObligatoria = true;
            componente.componente = "Raiz.Modulo2.dll";
            componente.fechaRegistro = DateTime.Now;

            _listaComponentes.Add(componente);


            componente = new PubComponente();
            componente.idModulo = 3;
            componente.version = "1.0.1";
            componente.descargaObligatoria = false;
            componente.componente = "Raiz.Reniec.Cliente.dll";
            componente.fechaRegistro = DateTime.Now;
            _listaComponentes.Add(componente);

            componente = new PubComponente();
            componente.idModulo = 8;
            componente.version = "1.0.1";
            componente.descargaObligatoria = false;
            componente.componente = "Raiz.Reniec.BE.dll";
            componente.fechaRegistro = DateTime.Now;
            _listaComponentes.Add(componente);



            componente = new PubComponente();
            componente.idModulo = 4;
            componente.version = "1.0.1";
            componente.descargaObligatoria = false;
            componente.componente = "Raiz.Common.CL.dll";
            componente.fechaRegistro = DateTime.Now;
            _listaComponentes.Add(componente);

            componente = new PubComponente();
            componente.idModulo = 5;
            componente.version = "1.0.1";
            componente.descargaObligatoria = false;
            componente.componente = "Raiz.MGA.Cliente.dll";
            componente.fechaRegistro = DateTime.Now;
            _listaComponentes.Add(componente);

            componente = new PubComponente();
            componente.idModulo = 6;
            componente.version = "1.0.1";
            componente.descargaObligatoria = false;
            componente.componente = "Raiz.MGA.DTO.dll";
            componente.fechaRegistro = DateTime.Now;
            _listaComponentes.Add(componente);

            
        }

        public List<PubComponente> ConsultarPublicaciones()
        {
            return _listaComponentes;
        }

        public PubComponente ConsultarPublicacionPorComponente(string componente)
        {
            return _listaComponentes.Find(p => p.componente == componente);
        }

    }
}
