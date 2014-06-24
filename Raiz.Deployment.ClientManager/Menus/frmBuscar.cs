using System;
using System.Drawing;
using Raiz.Deployment.ClientManager.MenuService;
using System.Windows.Forms;

namespace Raiz.Deployment.ClientManager.Menus
{
    public partial class frmBuscar : frmBase

    {
        private MenuServiceClient _objsvc;
        public int _codigo;
        public frmBuscar()
        {
            InitializeComponent();
            _objsvc = new MenuServiceClient();
        }

        public int Codigo
        {
            set { _codigo = value; }
        }

        private void CargarGrilla()
        {
            int cod = 0;
            if (this.txtCodigo.Text != "")
            {
                string codigo = txtCodigo.Text;
                codigo = codigo.Replace(" ", "");
                cod = Convert.ToInt32(codigo);
            }
            gridMenus.ColumnCount = 2;
            gridMenus.ColumnHeadersVisible = true;


            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Lavender;
            columnHeaderStyle.Font = new Font("Arial", 8, FontStyle.Bold);
            gridMenus.ColumnHeadersDefaultCellStyle = columnHeaderStyle;


            this.gridMenus.Columns[0].Name = "Codigo";
            this.gridMenus.Columns[1].Name = "Descripcion";

            this.gridMenus.Columns[0].Width = 100;
            this.gridMenus.Columns[1].Width = 300;

            this.gridMenus.Rows.Clear();
            var lista = _objsvc.BuscarMenu(_codigo,cod, txtDescripcion.Text);
            foreach (var item in lista)
            {
                this.gridMenus.Rows.Add(item.idMenu, item.displayName);

            }

        }



        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void frmBuscar_Load(object sender, EventArgs e)
        {
            this.gridMenus.ReadOnly = true;
            CargarGrilla();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }


        private void gridMenus_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var codigo = (int)this.gridMenus.Rows[e.RowIndex].Cells[0].Value;
            var nombre = (string)this.gridMenus.Rows[e.RowIndex].Cells[1].Value;
            ((frmNuevoMenu) this.Owner).IdMenu = codigo;
            //((frmNuevoMenu)this.Owner).CargarDatos(codigo);
            ((frmNuevoMenu) this.Owner).Nombre = nombre; 
            //((frmNuevoMenu) this.Owner).id = codigo;
            //((frmNuevoMenu) this.Owner).Mostrar();
            //((frmNuevoMenu)this.Owner).HabButton(true, false, true, true, true, true);
            ((frmNuevoMenu)this.Owner).AsignarMenuPadre();
            this.Close();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
