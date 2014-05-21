using System;
using System.Linq;
using System.Windows.Forms;

namespace Raiz.Deployment.ServerManager
{
    public partial class frmAbout : Form
    {
        public Guid IdDestino { get; set; }

        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            CargarVersiones();
        }

        private void CargarVersiones()
        {
            var notifier = new NotificacionManager();
            var versiones = notifier.ListarVersionesInstaladasCliente(IdDestino);
            if (versiones == null) return;
            var componentes= versiones.Select(p => p.Componente).Distinct();
            foreach (var componente in componentes)
            {
               var current= versiones.FindLast(p => p.Componente == componente);
                lbVersiones.Items.Add(string.Format("{0} - {1}, descargado el {2}", componente,current.version , current.FechaDescarga));
            }

        }
    }
}
