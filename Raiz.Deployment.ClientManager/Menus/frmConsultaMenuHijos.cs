using System;
using System.Drawing;
using System.Windows.Forms;
using Raiz.Deployment.ClientManager.MenuService;

namespace Raiz.Deployment.ClientManager.Menus
{
    public partial class frmConsultaMenuHijos : frmBase
    {
        private MenuServiceClient _objsvc;
        public frmConsultaMenuHijos()
        {
            InitializeComponent();
            _objsvc = new MenuServiceClient();
        }

        public int _codigo;

        public void CargarDatos(int codigo)
        {
            TxtMenuPadre.Text = codigo.ToString();
            DgvMenuHijos.ColumnCount = 2;
            DgvMenuHijos.ColumnHeadersVisible = true;


            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Lavender;
            columnHeaderStyle.Font = new Font("Arial", 8, FontStyle.Bold);
            DgvMenuHijos.ColumnHeadersDefaultCellStyle = columnHeaderStyle;


            this.DgvMenuHijos.Columns[0].Name = "Codigo";
            this.DgvMenuHijos.Columns[1].Name = "Descripcion";

            this.DgvMenuHijos.Columns[0].Width = 100;
            this.DgvMenuHijos.Columns[1].Width = 290;

            this.DgvMenuHijos.Rows.Clear();
            var lista = _objsvc.ConsultaMenuHijos(_codigo);
            //var lista = _objsvc.BuscarMenu(_codigo, cod, txtDescripcion.Text);
            foreach (var item in lista)
            {
                this.DgvMenuHijos.Rows.Add(item.idMenu, item.displayName);

            }
        }

        private void frmConsultaMenuHijos_Load(object sender, EventArgs e)
        {
            CargarDatos(_codigo);   
        }

        private void BtnSALIR_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
