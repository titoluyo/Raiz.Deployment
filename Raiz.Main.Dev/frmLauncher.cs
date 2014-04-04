using System;
using System.Windows.Forms;
using Raiz.Common.CL;
using Raiz.LFS.Launcher.BE;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace Raiz.Main
{
	public partial class frmLauncher : Form
	{
		public frmLauncher()
		{
			InitializeComponent();
		}

		BindingList<Aplicacion> bapps;
		List<Aplicacion> lapps;
		private void frmLauncher_Load(object sender, EventArgs e)
		{
			lapps = LFSlauncherCL.ListarAplicacionesLFS();
            bapps = new BindingList<Aplicacion>(lapps);
			bapps.AllowNew = false;
			bapps.AllowEdit = false;
			bapps.AllowRemove = true;
			
			lstAplicaciones.DataSource = bapps;
			lstAplicaciones.DisplayMember = "Descripcion";
			lstAplicaciones.ValueMember = "Nombre";
		}

		private void lstAplicaciones_DoubleClick(object sender, EventArgs e)
		{
			btnAceptar_Click(sender, e);
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			actualizaApps();
			CurrencyManager cm = (CurrencyManager)this.BindingContext[bapps];
			Aplicacion app = (Aplicacion)cm.Current;
            if (cm.Position == 0)
            {
                this.Close();
            }
            else
            {
                string mensaje = ActualizaVersionCL.Actualiza(app);
                if (mensaje.Length > 0)
                {
                    MessageBox.Show(mensaje);
                }
                else
                {
                    Process p = new Process();
                    p.StartInfo.FileName = String.Format("{0}{1}", app.RutaClient, app.Nombre);
                    p.StartInfo.Arguments = String.Format(" {0} {1}", Singleton.Instance.GcUser, Singleton.Instance.GcPassword);
                    p.StartInfo.WorkingDirectory = app.RutaClient;
                    p.Start();
                }
            }
		}

		/// <summary>
		/// Actualiza la lista de las aplicaciones
		/// </summary>
		private void actualizaApps()
		{
			bool encontrado = false;
			lapps = LFSlauncherCL.ListarAplicacionesLFS();
			foreach (Aplicacion lapp in lapps)
			{
				encontrado = false;
				foreach (Aplicacion bapp in bapps)
				{
					if (lapp.Nombre == bapp.Nombre)
					{
						encontrado = true;
						if (lapp.VersionPublicada != bapp.VersionPublicada)
						{
							bapp.VersionPublicada = lapp.VersionPublicada;
						}
					}
				}
				if (!encontrado)
				{
					bapps.Add(lapp);
				}
			}
			/*
			foreach (Aplicacion bapp in bapps)
			{
				encontrado = false;
				foreach (Aplicacion lapp in lapps)
				{
					if (lapp.Nombre == bapp.Nombre)
					{
						encontrado = true;
					}
				}
				if (!encontrado)
				{
					int i = bapps.IndexOf(bapp);
					bapps.BorrarAt(i);
					
				}
			}
			*/
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Singleton.Instance.StrToken = "";
			Application.Exit();
		}

	}
}
