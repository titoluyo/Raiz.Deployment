using System;
using System.Drawing;
using System.Windows.Forms;
using Raiz.Deployment.ClientManager.MenuService;
using Menu = Raiz.Deployment.DTO.Menu;

namespace Raiz.Deployment.ClientManager.Menus
{
    public partial class frmConsultaMenu : frmBase
        {
        private MenuServiceClient _objsvc;
        private int _i,_codigo;
        public frmConsultaMenu()
        {
            InitializeComponent();
            _objsvc = new MenuServiceClient();
        }

        private void frmConsultaMenu_Load(object sender, EventArgs e)
        {
            Cargar();
            BtnModificar.Enabled = false;
            BtnEliminar.Enabled = false;
            CargarGrilla();
        }

        public void Cargar()
        {
            CmbEstado.Items.Insert(0, "INACTIVO");
            CmbEstado.Items.Insert(1, "ACTIVO");
            CmbEstado.Items.Insert(2, "TODOS");
            CmbVisibilidad.Items.Insert(0, "NO");
            CmbVisibilidad.Items.Insert(1, "SI");
            CmbVisibilidad.Items.Insert(2, "TODOS");
            CmbEstado.SelectedIndex = 1;
            CmbVisibilidad.SelectedIndex = 2;
        }

        public void CargarGrilla()
        {
            int cod = 0;
            if (this.TxtCodigo.Text != "")
            {
                string codigo = TxtCodigo.Text;
                codigo = codigo.Replace(" ", "");
                cod = Convert.ToInt32(codigo);
            }
          
            this.gridConsulta.Rows.Clear();
            var lista = _objsvc.ConsultaMenu(cod,TxtDescripcion.Text,CmbEstado.SelectedIndex,CmbVisibilidad.SelectedIndex);
            _i = 0;
            //var lista = _objsvc.BuscarMenu(cod, txtDescripcion.Text);
            foreach (var item in lista)
            {
                string est = item.estado.ToString();
                this.gridConsulta.Rows.Add(item.idMenu, item.displayName, item.formulario, item.componente);
                this.gridConsulta.Rows[_i].DefaultCellStyle.ForeColor = est == "True" ? Color.Black : Color.Red;
                _i++;
            }

            if (_i > 0)
            {   BtnModificar.Enabled = true;
                BtnEliminar.Enabled = true;
            }
            else
            {
                BtnModificar.Enabled = false;
                BtnEliminar.Enabled = false;
            }   
        }


        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void gridConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var codigo = (int)this.gridConsulta.Rows[e.RowIndex].Cells[0].Value;

            frmVerConsulta frm2 = new frmVerConsulta();
            frm2.Nombre = "Datos del Menu "+codigo;
            frm2.Codigo = codigo;
            frm2.Show(); 
            
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmNuevoMenu frm3 = new frmNuevoMenu();
            
            frm3.idt = "N";
            frm3.Owner = this;
            frm3.ShowDialog();
            }

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
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

            if (e.KeyChar == (char)Keys.Return)
            {
                CargarGrilla();
            }
        }

        private void TxtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                CargarGrilla();
            }
        }

        private void gridConsulta_SelectionChanged(object sender, EventArgs e)
        {
            if (_i > 0)
            { BtnModificar.Enabled = true; }
            else
            {
                BtnModificar.Enabled = false;
            }
            _codigo = (int)this.gridConsulta.Rows[gridConsulta.CurrentRow.Index].Cells[0].Value;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Estas seguro que deseas eliminar el registro?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool std, vis;
                var item = new Menu();
                item.idMenu = _codigo;
                _objsvc.CrearItemMenu(item, "E");
                MessageBox.Show("Registro Eliminado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            CargarGrilla();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            frmNuevoMenu frm3 = new frmNuevoMenu();
            
            
            frm3.Cargar();
            frm3.idt = "M";
            frm3.CargarDatos(_codigo);
            frm3.Owner = this;
            frm3.ShowDialog(); 
            //frm3.Show();
            
            
        }

    }

    }

