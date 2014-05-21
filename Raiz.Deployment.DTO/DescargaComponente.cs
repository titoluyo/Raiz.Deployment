using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiz.Deployment.DTO
{
    public class DescargaComponente
    {

        public enum EstadoDescarga
        {
            Pendiente = 0,
            Iniciado = 1,
            Finalizado = 2,
            Interrumpido = 3
        }

        public Guid Id { get; set; }
        public string Componente { get; set; }
        public DateTime FechaDescarga { get; set; }
        public string Modulo { get; set; }
        public Version version { get; set; }
        public bool descargaObligatoria { get; set; }
        public EstadoDescarga estado { get; set; }
    }
}
