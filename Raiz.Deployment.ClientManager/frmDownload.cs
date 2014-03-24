using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Raiz.Deployment.DTO;
using Raiz.Deployment.ClientManager.DeployService;


namespace Raiz.Deployment.ClientManager
{
    public partial class frmDownload : Form
    {
        Stopwatch _sw = new Stopwatch();

        private string _rutaDescargaServidor ="";
        private string _rutaInstalacion = "";
        private string _rutaLocal = "";

        private LogManager _logger = new LogManager();
        private ModuleManager _downloader=new ModuleManager();


        public ProgressBar ProgressionBar
        {
            get { return this.progressBar1; }
            set { this.progressBar1 = value; }
        }

        public Label PorcentajeLabel
        {
            get { return this.lblPorcentaje; }
            set { this.lblPorcentaje = value; }

        }

        public Label DescargaLabel
        {
            get { return this.lblDescarga; }
            set { this.lblDescarga = value; }

        }

        public Label VelocidadLabel
        {
            get { return this.lblVelocidad; }
            set { this.lblVelocidad = value; }

        }


        public frmDownload()
        {
            InitializeComponent();
            _rutaLocal = DeploySettings.ObtenerRutaLocal();
            _rutaDescargaServidor = DeploySettings.ObtenerRutaServidor();
        }

        public  PubComponente Actualizacion { get; set; }


        // The event that will fire whenever the progress of the WebClient is changed
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Calculate download speed and output it to labelSpeed.
            this.VelocidadLabel.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / _sw.Elapsed.TotalSeconds).ToString("0.00"));

            // Update the progressbar percentage only when the value is not the same.
            this.ProgressionBar.Value = e.ProgressPercentage;

            // Show the percentage on our label.
            this.PorcentajeLabel.Text = e.ProgressPercentage.ToString() + "%";

            // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading

            this.DescargaLabel.Text = string.Format("{0} MB's / {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
        }

        // The event that will trigger when the WebClient is completed
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            // Reset the stopwatch.
            _sw.Reset();


            if (e.Cancelled == true)
            {
                MessageBox.Show("La descarga ha sido cancelada.");
            }
            else
            {
                MessageBox.Show("Decarga Completada");
                this.btnCancel.Enabled = false;
                this.btnIniciar.Enabled = false;
                this.Close();

            }
        }



        public void DescargarActualizacion(PubComponente actualizacion)
        {

            //Creación de la ruta local
            if (!Directory.Exists(_rutaLocal))
            {
                Directory.CreateDirectory(_rutaLocal);
            }

            var rutaWeb = Path.Combine(_rutaDescargaServidor, actualizacion.componente);
            var rutaLocal = Path.Combine(_rutaLocal, actualizacion.componente);

            if (!_downloader.ValidaComponenteDescargar(actualizacion)) return;
            
           

            using (var client = new WebClient())
            {

                client.DownloadFileCompleted += Completed;
                client.DownloadProgressChanged += ProgressChanged;
                try
                {
                    //Inicia la descarga
                    
                    var descarga = new DescargaComponente();
                    descarga = _downloader.DescargaNuevoComponente(actualizacion, descarga);
                    descarga.estado = DescargaComponente.EstadoDescarga.Iniciado;
                    _logger.RegistrarDescarga(descarga);

                    //Descarga del componente
                    var urlRutaWeb = rutaWeb.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(rutaWeb) : new Uri("http://" + rutaWeb);

                    _sw.Start();
                    //client.DownloadFile(rutaWeb, rutaLocal);
                    client.DownloadFileAsync(urlRutaWeb, rutaLocal);
                    //Finaliza la descarga
                    descarga.estado = DescargaComponente.EstadoDescarga.Finalizado;
                    _logger.RegistrarDescarga(descarga);
                }
                catch (WebException ex)
                {
                    if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotFound)
                    {
                        MessageBox.Show(string.Format("No existe el componente en la ruta:{0}", rutaWeb));
                    }
                }
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            
            DescargarActualizacion(Actualizacion);
        }

    }
}
