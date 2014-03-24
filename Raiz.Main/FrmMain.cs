using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Raiz.Common.CL;

namespace Raiz.Main
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            IList<FormBase> forms = new List<FormBase>();

            var rutaInstalacion = "RaizNet";
            var rutaLocal = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), rutaInstalacion);

            if (!Directory.Exists(rutaLocal))
            {
                Directory.CreateDirectory(rutaLocal);
            }


            var rutaRemota = "http://localhost/RaizNet/";


            var listaAssy = new List<AssemblyType>();
            listaAssy.Add(new AssemblyType("Raiz.Modulo1.dll", "Raiz.Modulo1.FrmMod1"));
            listaAssy.Add(new AssemblyType("Raiz.Modulo2.dll", "Raiz.Modulo2.FrmMod2"));

            foreach (var strAssy in listaAssy)
            {
                var rutaRemotaAssy = Path.Combine(rutaRemota, strAssy.Assembly);
                Console.WriteLine(rutaRemotaAssy);

                using (var client = new WebClient())
                {
                    client.DownloadFile(Path.Combine(rutaRemota, strAssy.Assembly), Path.Combine(rutaLocal, strAssy.Assembly));
                }

                var assembly = Assembly.LoadFrom(Path.Combine(rutaLocal,strAssy.Assembly));
                var type = assembly.GetType(strAssy.Type);
                var form = (FormBase)Activator.CreateInstance(type);
                forms.Add(form);
            }

            foreach (var formBase in forms)
            {
                formBase.CargaMenus(mnuMain);
            }
        }
    }

    public class AssemblyType
    {
        public AssemblyType(String assembly, String type)
        {
            this.Assembly = assembly;
            this.Type = type;
        }
        public String Assembly { get; set; }
        public String Type { get; set; }
    }
}
