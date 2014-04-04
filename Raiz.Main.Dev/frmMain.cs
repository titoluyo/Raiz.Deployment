using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Deployment.Application;

using Raiz.Common.CL;
using Raiz.Deployment.ClientManager;
using Raiz.Deployment.DTO;

namespace Raiz.Main
{
	public partial class frmMain : Form
	{
		private readonly List<FormBase> _frmHijos = new List<FormBase>();
        private NotificacionManager _notifier = new NotificacionManager();
        

		string usrName = string.Empty;
		public frmMain()
		{
			InitializeComponent();
			this.Icon = Raiz.Common.CL.Properties.Resources.LogoRaiz;
            _notifier.Conectar();
		}
		
		private void frmMain_Load(object sender, EventArgs e)
		{
			if (ApplicationDeployment.IsNetworkDeployed)
			{
				ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
				LogCL.GetLog().AppProductVersion = ad.CurrentVersion.ToString();
				this.Text += " - " + ad.CurrentVersion.ToString();
				//this.Text += " - " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
				//this.Text += " - " + Environment.Version.ToString();
			}
            
            Autentica();
            DeployInit();
            
	    }

        private void DeployInit()
        {
            var menuLoader = new MenuLoader();
            menuLoader.MdiContainer = this;
            var menu = menuLoader.CargarMenu();
            this.Controls.Add(menu);
            this.MainMenuStrip = menu;

            var obj = new ModuleManager();
            obj.VerificarActualizaciones();

        }


	    void f_RaiseReAutentica(object sender, EventArgs e)
		{
			//((Form)sender).Close();
			usrName = null;
			Singleton.Instance.ResetFull();
			Autentica();
		}
		private void Autentica()
		{
			
			sys0000 f = new sys0000();
			f.ShowDialog();
			if (Singleton.Instance.StrToken.Length == 0)
				return;
			formName();
			
		}
		private void formName()
		{
			usrName = AutenticacionCL.GetUsuarioNombre();
			if (usrName != string.Empty)
			{
				this.Text += " - " + usrName;
			}
		}
		public void RevisaPermisosMenu()
		{
			foreach (FormBase fb in _frmHijos)
			{
				fb.RevisaPermisosMenu();
			}
		}
		
		private void mnuSalirExec_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Singleton.Instance.StrToken.Trim() != "")
			{
				DialogResult res = MessageBox.Show(this, "Realmente usted desea salir?", "Confirmación", MessageBoxButtons.YesNo);
				if (res == DialogResult.No)
					e.Cancel = true;
			}

            _notifier.Desconectar();

		}

		private void mnuVistaCascada_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}

		private void mnuVistaMosaicoVertical_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void mnuVistaMosaicoHorizontal_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.ArrangeIcons);
		}

		private void mnuVistaCerrarTodo_Click(object sender, EventArgs e)
		{
			foreach (Form childForm in MdiChildren)
			{
				if (!childForm.Name.EndsWith("Menu"))
				{
					childForm.Close();
				}
			}
		}

	}
}
