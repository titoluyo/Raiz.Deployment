using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Raiz.Deployment.ClientManager
{
    public partial class frmAbout : Form
    {
        private LogManager _logger=new LogManager();

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
            var versiones = _logger.ListarDescargas();
            var componentes= versiones.Select(p => p.Componente).Distinct();
            foreach (var componente in componentes)
            {
               var current= versiones.FindLast(p => p.Componente == componente);
                lbVersiones.Items.Add(string.Format("{0} - {1}, descargado el {2}", componente, current.version, current.FechaDescarga));
            }

        }
    }
}
