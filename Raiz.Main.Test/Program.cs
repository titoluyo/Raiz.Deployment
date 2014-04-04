using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Raiz.Deployment.ClientManager;

namespace Raiz.Main.Test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Validar Componentes

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var obj = new ModuleManager();
            obj.VerificarActualizaciones();

            Application.Run(new Form1());
        }
    }
}
