using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Raiz.Common.CL;

namespace Raiz.Modulo1
{
    public partial class FrmMod1:Form //: FormBase
    {
        public FrmMod1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StackOverflowExample.Run();
        }
        /*
        public override void CargaMenus(MenuStrip menu)
        {
            menu.Items.Add(modulo1ToolStripMenuItem);
        }
         * */
    }
}
