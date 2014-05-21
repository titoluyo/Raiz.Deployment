using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using Raiz.Deployment.ServerManager.Properties;

namespace Raiz.Deployment.ServerManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var tray = new TrayManager();
            Application.Run();


        }
    }

    internal class TrayManager
    {
        private NotifyIcon _icon=new NotifyIcon();
        private ContextMenuStrip _mnuContext = new ContextMenuStrip();
        private ToolStripMenuItem _mnuDeploy=new ToolStripMenuItem("&Deployment");
        private ToolStripMenuItem _mnuConectados=new ToolStripMenuItem("Ver &Conectados");
        private ToolStripMenuItem _mnuSalir = new ToolStripMenuItem("&Salir");

        public TrayManager()
        {
            _mnuContext.Items.Add(_mnuDeploy);
            _mnuContext.Items.Add(_mnuConectados);
            _mnuContext.Items.Add(_mnuSalir);

            _icon.Icon = Resources.LogoRaiz;
            _icon.ContextMenuStrip = _mnuContext;
            _icon.Visible = true;
            _mnuDeploy.Click += _mnuDeploy_Click;
            _mnuConectados.Click += _mnuConectados_Click;
            _mnuSalir.Click += _mnuSalir_Click;
            _icon.ShowBalloonTip(7000, "RaizNet Deployment","Realiza publicaciones en RaizNet", ToolTipIcon.Info);
            _icon.DoubleClick += _icon_DoubleClick;
            VerificarRegistroStartUp();
        }

        void _icon_DoubleClick(object sender, EventArgs e)
        {
            var frm = new frmMain();
            frm.Show();
        }

        void _mnuSalir_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Environment.Exit(0);
        }

        void _mnuConectados_Click(object sender, EventArgs e)
        {
            var frm = new frmConectados();
            frm.ShowDialog();
        }

        void _mnuDeploy_Click(object sender, EventArgs e)
        {
            var frm = new frmMain();
            frm.Show();

        }
        private void VerificarRegistroStartUp()
        {
            RegistryKey rk = Registry.CurrentUser;
            RegistryKey StartupPath;
            StartupPath = rk.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            var path = StartupPath.GetValue("RaizNetDeploymentServer");
            if (path== null)
            {
                StartupPath.SetValue("RaizNetDeploymentServer", Application.ExecutablePath, RegistryValueKind.ExpandString);
            }
            //Write(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", "WordWatcher", "\"" + Application.ExecutablePath.ToString() + "\"");

        }
        public bool Write(RegistryKey baseKey, string keyPath, string KeyName, object Value)
        {
            try
            {
                // Setting 
                RegistryKey rk = baseKey;
                // I have to use CreateSubKey 
                // (create or open it if already exits), 
                // 'cause OpenSubKey open a subKey as read-only 
                RegistryKey sk1 = rk.CreateSubKey(keyPath);
                // Save the value 
                sk1.SetValue(KeyName.ToUpper(), Value);

                return true;
            }
            catch (Exception e)
            {
                // an error! 
                MessageBox.Show(e.Message, "Writing registry " + KeyName.ToUpper());
                return false;
            }
        }

    }

}
