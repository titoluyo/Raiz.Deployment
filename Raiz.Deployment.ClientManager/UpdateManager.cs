using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Raiz.Deployment.DTO;

namespace Raiz.Deployment.ClientManager
{
    public class UpdateManager
    {
        private System.Timers.Timer _timer;
        public static Hashtable ComponentesPendientesUpdate=new Hashtable();

        
        public enum NivelForzado
        {
            Notificacion=1,
            NotificacionPersistente=2,
            Forzado=3
        }

        public void Notificar()
        {
            DeploySettings.UsuarioAceptoNotificacion = false;
            if (MessageBox.Show("Existe una actualización pendiente. Guarde sus trabajo y cierre la aplicación y vuelva a ingresar. \n Desea cerrar la aplicación ahora?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                DeploySettings.UsuarioAceptoNotificacion = true;
            }

        }

        public void Notificar(object source,ElapsedEventArgs e)
        {
            if (DeploySettings.UsuarioAceptoNotificacion)
            {
                Notificar();
            }
            
        }
        
        public void RepetirNotificacion()
        {
            _timer = new System.Timers.Timer();
            _timer.Elapsed += new ElapsedEventHandler(Notificar);
            _timer.Interval = 10000;
            _timer.Enabled = true;
        }

        private void Finalizar()
        {
            _timer.Enabled = false;
        }

        public void ForzarCerrado(List<PubComponente> actualizaciones)
        {
            RepetirNotificacion();

            foreach (var actualizacion in actualizaciones)
            {
                ComponentesPendientesUpdate[actualizacion.componente] = actualizacion.componente;
                var menuMng = new MenuLoader();
                menuMng.BloquearFormulariosPorComponente(actualizacion.componente);
            }
            
        }

        public void ForzarCierreInmediatamente(string mensaje)
        {
            AutoClosingMessageBox.Show(string.Format("Se va a cerrar su aplicación por instrucción remota del Administrador de Aplicaciones.{0}",
                        (mensaje.Length > 0 ? string.Format("Mensaje:{0}", mensaje) : string.Empty)), "Notificacion", 5000);

            var notifier = new NotificacionManager();
            notifier.Desconectar();
            Environment.Exit(0);
        }

       



    }
}
