using System;
using System.Windows.Forms;
using Raiz.Deployment.ClientManager.MenuService;

namespace Raiz.Deployment.ClientManager.Menus
{
    public partial class frmVerConsulta : frmBase
    {
        private MenuServiceClient _objsvc;
        public frmVerConsulta()
        {
            InitializeComponent();
            _objsvc = new MenuServiceClient();
        }

        private string _nombre;
        private int _codigo;
        public String Nombre
        { set { _nombre = value; gbConsulta.Text = _nombre; } }

        public int Codigo
        {
            set { _codigo = value;
                TxtCodigo.Text = _codigo.ToString();
            }
        }

        public void CargarDatos()
        {
          var itemMenu = _objsvc.ConsultarMenu(_codigo);
          //var dat = new Consulta();
          TxtNombre.Text = itemMenu.DisplayName;
          TxtDescripcion.Text = itemMenu.Descripcion;
          TxtFormulario.Text = itemMenu.Formulario;
          TxtComponente.Text = itemMenu.Componente;
          TxtPrograma.Text = itemMenu.CodPrograma;
          string estado = itemMenu.Estado.ToString();
          string visible = itemMenu.UsarVisibilidad.ToString();
          TxtEstado.Text = estado == "True" ? "Activado" : "Desactivado";
          TxtVisibilidad.Text = visible == "True" ? "SI" : "NO";
          TxtMenuPadre.Text = itemMenu.NomMenuPadre;
        }


        private void frmVerConsulta_Load(object sender, EventArgs e)
        {
            CargarDatos();
            var lista = _objsvc.ConsultaMenuHijos(_codigo);
            int _cont = 0;
            foreach (var item in lista)
            {
                _cont = _cont + 1;

            }

            if (_cont >0) { BtnMenuHijos.Enabled = true; }
            else { BtnMenuHijos.Enabled = false; }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMenuHijos_Click(object sender, EventArgs e)
        {
            frmConsultaMenuHijos frm3 = new frmConsultaMenuHijos();
            frm3.Owner = this;
            frm3._codigo = Convert.ToInt32(TxtCodigo.Text);
            frm3.ShowDialog();
        }
    }
}
