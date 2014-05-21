using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiz.Deployment.DTO
{
    public class Suscritor
    {


        public Guid Id { get; set; }
        public string IP { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Notificaciones { get; set; }
        public int TipoUsuario { get; set; } //1 es Administrador, 2//Es cliente
    }

    public struct  MensajesServidor
    {
        public const int USUARIO_DESCONECTADO = 1;
        public const int USUARIO_CONECTADO = 2;
        
    }

}
