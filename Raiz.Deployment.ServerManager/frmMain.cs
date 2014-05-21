using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Raiz.Deployment.ServerManager
{
    public partial class frmMain : Form
    {
        private SourceManager _sourcer=new SourceManager();
        
        public frmMain()
        {
            InitializeComponent();
        }
        

        private void btnBuscarOrigen_Click(object sender, EventArgs e)
        {
            fbd1.ShowDialog();
            this.txtRutaOrigen.Text = this.fbd1.SelectedPath;


        }

        private void btnBuscarComponente_Click(object sender, EventArgs e)
        {
            var ambiente=(rbTesting.Checked? SourceManager.Ambiente.Testing: SourceManager.Ambiente.Produccion);
            var criterio = string.Format("SPPROD{0}*", this.txtPase.Text);
            var ruta = Directory.GetDirectories(this.txtRutaOrigen.Text,criterio).FirstOrDefault();
            
            this.lblPase.Text = string.Format("Pase:{0}", Path.GetFileName(ruta));
            if (!Directory.Exists(ruta))
            {
                //No Existe el directorio de pase
                return;
            }

            this.grillaComponentes.Rows.Clear();
            var componentes= _sourcer.ListarComponentesPorPase(ruta, ambiente);
            foreach (var componente in componentes)
            {
                this.grillaComponentes.Rows.Add(Path.GetFileName(componente.componente), componente.version, string.Empty);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         Conectar();
            
            //Inicializar las variabels del formulario
            this.txtRutaOrigen.Text = PublishSettings.ObtenerRutaPasesRoot();
            this.txtRutaDestino.Text = PublishSettings.ObtenerRutaServidor();
        }

        private void Conectar()
        {
            var notifier = new NotificacionManager();
            notifier.Conectar("Admin");
        }

        private void Desconectar()
        {
            var notifier = new NotificacionManager();
            notifier.Desconectar();
        }

        private void btnBuscarDestino_Click(object sender, EventArgs e)
        {
            fbd2.ShowDialog();
            this.txtRutaDestino.Text = this.fbd2.SelectedPath;
        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {
            PublishSettings.RutaPublicacion = this.txtRutaDestino.Text;

            var ambiente=(rbTesting.Checked? SourceManager.Ambiente.Testing: SourceManager.Ambiente.Produccion);
            var criterio = string.Format("SPPROD{0}*", this.txtPase.Text);
            var ruta = Directory.GetDirectories(this.txtRutaOrigen.Text, criterio).FirstOrDefault();


            var resultados = _sourcer.ValidarVersionesPublicar(ruta, ambiente);

            for (var i = 0; i < this.grillaComponentes.Rows.Count; i++)
            {
                var componente = this.grillaComponentes.Rows[i].Cells[0].Value.ToString();
                var status = resultados.Find(p => p.componente.Trim() == componente.Trim());
                this.grillaComponentes.Rows[i].Cells[2].Value = status.Status;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frmConectados();
            frm.ShowDialog();

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Desconectar();
        }


    }
}
