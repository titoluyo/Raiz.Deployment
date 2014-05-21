using System;
using System.Threading;
using System.Windows.Forms;
using Raiz.Deployment.ServerManager.Properties;


namespace Raiz.Deployment.ServerManager
{
    public partial class frmConectados : Form
    {
        private SuscriptionManager _suscriber=new SuscriptionManager();
        private Thread _myThread;
        private bool _boolContinua=true;
        public frmConectados()
        {
            InitializeComponent();
            
        }

        
        public void CargarConectados()
        {
            var result=_suscriber.ListarSuscritores();
            try
            {
                var resource = Resources.dull_green_circle;
                this.lvConectados.SmallImageList=new ImageList();
                this.lvConectados.SmallImageList.Images.Add(resource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
            foreach (var suscritor in result)
            {
                this.lvConectados.Items.Add(suscritor.Id.ToString(), string.Format("{0}-{1}", suscritor.IP, suscritor.Usuario), 0);
            }
            RevisionContinua();
        }

        private void RevisionContinua()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            _myThread = new System.Threading.Thread( delegate()
            {

                while (true)
                {
                    if (!PublishSettings.NotificacionPendiente) continue;
                    if(!_boolContinua)break;
                    var result = _suscriber.ListarSuscritores();

                    this.lvConectados.Items.Clear();
                    foreach (var suscritor in result)
                    {
                        this.lvConectados.Items.Add(suscritor.Id.ToString(), string.Format("{0}-{1}", suscritor.IP, suscritor.Usuario), 0);
                    }

                    PublishSettings.NotificacionPendiente = false;
                }
            });
            _myThread.Start();

        }
      


        private void frmConectados_Load(object sender, EventArgs e)
        {
            CargarConectados();
        }

        private void btnForzarCierre_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar la sesión del usuario remotamenet?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                var id = this.lvConectados.SelectedItems[0];
                var notifier = new NotificacionManager();
                var idDestino = new Guid(id.Name);
                notifier.ForzarCierreAplicacionCliente(idDestino, "Prueba");
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            var notifier = new NotificacionManager();
            var id = this.lvConectados.SelectedItems[0];
            var idDestino = new Guid(id.Name);
            notifier.EnviarMensajePersonalCliente(idDestino,this.txtMensaje.Text);
        }

        private void frmConectados_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_myThread.Interrupt();
            ;
            _boolContinua = false;
        }

        private void btnVersInst_Click(object sender, EventArgs e)
        {

            var id = this.lvConectados.SelectedItems[0];
            var idDestino = new Guid(id.Name);
            var frm = new frmAbout();
            frm.IdDestino = idDestino;
            frm.ShowDialog();

        }
    }
}
