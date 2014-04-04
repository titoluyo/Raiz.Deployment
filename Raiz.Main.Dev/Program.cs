using System;
using System.Windows.Forms;
using Raiz.Common.CL;
using Raiz.Deployment.ClientManager;


//using Raiz.Scoring.Cliente.Integracion;
//using Raiz.UB.Log.Reportes.Cliente;

namespace Raiz.Main
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			if (args.Length != 0 && args.Length != 4)
			{
				MessageBox.Show(string.Format("Cantidad de argumentos inválida\r\n{0}",args[0]));
				return;
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if (args.Length == 4)
			{
				string gcUser = args[0];
				string gcPassword = args[1];
				string gcCodOfi = args[2];
				switch (args[3])
				{
					case "RENIEC":
						CallReniec();
						break;
					default:
						MessageBox.Show("Parámetro de destino inválido");
						Application.Exit();
						break;
				}
			}
            
			Application.Run(new frmMain());
		}

		private static void CallReniec()
		{
			//Application.Run(new frmReniecDNI());
			Application.Exit();
		}
	}
}
