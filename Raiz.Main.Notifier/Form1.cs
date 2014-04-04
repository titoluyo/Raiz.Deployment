using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Raiz.Deployment.ClientManager;
using Raiz.Deployment.DTO;

namespace Raiz.Main.Notifier
{
    public partial class Form1 : Form
    {

        private NotificacionManager _notifier = new NotificacionManager();

        public Form1()
        {
            InitializeComponent();
            _notifier.Conectar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNotify_Click(object sender, EventArgs e)
        {
            
            _notifier.Notificar(new PubComponente(){ componente = "Raiz.Modulo2.dll", version = "1.0.2"});
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _notifier.Desconectar();
        }
    }
}
