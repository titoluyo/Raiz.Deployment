using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Raiz.Deployment.ClientManager;
using Raiz.Deployment.DTO;

namespace Raiz.Main.Test
{
    public partial class Form1 : Form
    {
        
        private NotificacionManager _notifier=new NotificacionManager();
        
        public Form1()
        {
            InitializeComponent();
            _notifier.Conectar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var menuLoader = new MenuLoader();
            menuLoader.MdiContainer = this;
            var menu = menuLoader.CargarMenu();
            this.Controls.Add(menu);
            this.MainMenuStrip = menu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _notifier.Notificar();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _notifier.Desconectar();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _notifier.Notificar(new PubComponente() { componente = "Raiz.Modulo1.dll", version = "1.0.2" });

        }
    }
}
