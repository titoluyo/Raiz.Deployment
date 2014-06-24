using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Raiz.Deployment.ClientManager
{
    public partial class frmBase : Form
    {
        public frmBase()
        {
            InitializeComponent();
            this.Icon = Raiz.Common.CL.Properties.Resources.LogoRaiz;
        }
    }
}
