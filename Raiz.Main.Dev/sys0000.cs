using System;
using System.Windows.Forms;
using Raiz.Common.CL;

namespace Raiz.Main
{
    public partial class sys0000 : Form
    {
        public sys0000()
        {
            InitializeComponent();
            this.Icon = Raiz.Common.CL.Properties.Resources.LogoRaiz;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            btnAceptar.Enabled = false;
            string u =txtUsuario.Text;
            string p=txtClave.Text;

            string strToken = AutenticacionCL.Autentica(u, p);
            if (strToken == "")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show(strToken);//"Usuario/Clave Incorrecta");
            }
            btnAceptar.Enabled = true;
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length == 4)
                txtClave.Focus();
        }
    }
}
