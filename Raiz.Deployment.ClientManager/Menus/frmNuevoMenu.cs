using System;
using System.Windows.Forms;
using Raiz.Deployment.ClientManager.MenuService;
using Menu = Raiz.Deployment.DTO.Menu;
using Consulta = Raiz.Deployment.DTO.ConsultaRegistroMenu_Result;



namespace Raiz.Deployment.ClientManager.Menus
{
    public partial class frmNuevoMenu : frmBase
       
    {
        private MenuServiceClient _objsvc;
        public int IdMenu { get; set; }
        public string Nombre { get; set; }
        public string idt;
        public int cont = 0;
        public int id;

        public frmNuevoMenu()
        {
            InitializeComponent();
            _objsvc = new MenuServiceClient();
        }
   #region metodos

        public void Mostrar()
        {
            MessageBox.Show(IdMenu.ToString());
           // MessageBox.Show(Nombre);
            MessageBox.Show(id.ToString());

        }

        public void Cargar()
        {
            CmbEstado.Items.Insert(0, "ACTIVO");
            CmbEstado.Items.Insert(1, "INACTIVO");
            CmbVisibilidad.Items.Insert(0,"SI");
            CmbVisibilidad.Items.Insert(1,"NO");
        }

        public void AsignarMenuPadre()
        {
            TxtMenuPadre.Text = Nombre;
            BtnCancelar.Enabled = true;
        }

        public void HabButton(bool n,bool g,bool m,bool e,bool s,bool b)
        {
            BtnNuevo.Enabled = n;
            BtnGuardar.Enabled = g;
            BtnModificar.Enabled = m;
            BtnEliminar.Enabled = e;
            BtnSalir.Enabled = s;
            BtnBuscar.Enabled = b;
        }

        public void Inhabilitar()
        {
            TxtNomMenu.Enabled = false;
            TxtComponente.Enabled = false;
            TxtDescripcion.Enabled = false;
            TxtFormulario.Enabled = false;
            CmbEstado.Enabled = false;
            CmbVisibilidad.Enabled = false;
        }

        public void Habilitar()
        {
            TxtNomMenu.Enabled = true;
            TxtComponente.Enabled = true;
            TxtDescripcion.Enabled = true;
            TxtFormulario.Enabled = true;
            CmbEstado.Enabled = true;
            CmbVisibilidad.Enabled = true;
            TxtNomMenu.Focus();
        }

        public void LimpiarDatos()
        {
            TxtNomMenu.Text = "";
            TxtDescripcion.Text = "";
            TxtComponente.Text = "";
            TxtFormulario.Text = "";
        }


        public void CargarDatos(int num)
        {
            var itemMenu = _objsvc.ConsultarMenu(num); 
            var dat = new Consulta();
            TxtNomMenu.Text = itemMenu.DisplayName;
            TxtDescripcion.Text = itemMenu.Descripcion;
            TxtFormulario.Text = itemMenu.Formulario;
            TxtComponente.Text = itemMenu.Componente;
            TxtPrograma.Text = itemMenu.CodPrograma;
            string estado = itemMenu.Estado.ToString();
            string visible = itemMenu.UsarVisibilidad.ToString();
            CmbEstado.SelectedIndex = estado == "True" ? 0 : 1;
            CmbVisibilidad.SelectedIndex = visible == "True" ? 0 : 1;
            TxtMenuPadre.Text = itemMenu.IdMenuPadre > 0 ? itemMenu.NomMenuPadre : "";
            IdMenu = Convert.ToInt32(itemMenu.IdMenuPadre);
            id = num;
        }
        public void Nuevo()
        {
            Habilitar();
            LimpiarDatos();
            HabButton(true, true, false, false, true, true);
            CmbEstado.SelectedIndex = 0;
            CmbVisibilidad.SelectedIndex = 0;
            BtnNuevo.Text = "Cancelar";
            ((frmConsultaMenu)this.Owner).CargarGrilla();  
        }

        public void Eliminar()
        {
            if (MessageBox.Show("¿Estas seguro que deseas eliminar el registro?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cont = 0;
                bool std, vis;
                var item = new Menu();
                item.idMenu = id;
                item.displayName = TxtNomMenu.Text;
                item.Descripcion = TxtDescripcion.Text;
                item.formulario = TxtFormulario.Text;
                item.componente = TxtComponente.Text;
                if (CmbEstado.SelectedIndex == 0) std = true; else std = false;
                item.estado = std;
                if (CmbVisibilidad.SelectedIndex == 0) vis = true; else vis = false;
                item.UsarVisibilidad = vis;
                item.UsuarioRegistro = DeploySettings.UsuarioConectado;
                _objsvc.CrearItemMenu(item, "E");
                MessageBox.Show("Registro Eliminado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarDatos();
                HabButton(true, false, false, false, true, false);
                Inhabilitar();
                this.Close();

            }    

        }

        public void Modificar()
        {
            if (cont == 0)
            {
                cont = cont + 1;
                Habilitar();
                HabButton(true, false, true, false, true, true);
                BtnNuevo.Text = "Cancelar";
            }
            else
            {
                
                bool std, vis;
                var item = new Menu();
                item.idMenu = id;
                item.displayName = TxtNomMenu.Text;
                item.Descripcion = TxtDescripcion.Text;
                item.formulario = TxtFormulario.Text;
                item.componente = TxtComponente.Text;
                item.CodPrograma = TxtPrograma.Text;
                if (CmbEstado.SelectedIndex == 0) std = true;
                else std = false;
                item.estado = std;
                if (CmbVisibilidad.SelectedIndex == 0) vis = true;
                else vis = false;
                item.UsarVisibilidad = vis;
                item.UsuarioRegistro = DeploySettings.UsuarioConectado;
                item.idMenuPadre = TxtMenuPadre.Text != "" ? IdMenu : 0;
                //MessageBox.Show(id.ToString());
                //MessageBox.Show(IdMenu.ToString());
                //return;
                _objsvc.CrearItemMenu(item, "A");
                MessageBox.Show("Registro Actualizado Correctamente", "Mensaje", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                HabButton(true, false, true, true, true, false);
                Inhabilitar();
                BtnNuevo.Text = "Nuevo";
                //frmConsultaMenu frm3 = new frmConsultaMenu();
                //frm3.CargarGrilla();
                ((frmConsultaMenu)this.Owner).CargarGrilla();  
                cont = 0;
                this.Close();
            }

        }
        #endregion
        private void frmNuevoMenu_Load(object sender, EventArgs e)
        {

            #region ValidaCarga

            if (idt != "N")
            {
                Inhabilitar();
                HabButton(true, false, false, true, true, true);
                BtnCancelar.Enabled = false;
                Modificar();
            }
            else
            {
                Cargar();
                Nuevo();
            }

            #endregion

            if (TxtMenuPadre.Text == "") { BtnCancelar.Enabled = false; }
            else{ BtnCancelar.Enabled = true;}
            //MessageBox.Show(idt);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (BtnNuevo.Text=="Nuevo")
            {
                Nuevo();
            }
            else
            {
                HabButton(true, false, false, true, true,false);
                Inhabilitar();
                LimpiarDatos();
                BtnNuevo.Text = "Nuevo";
                cont = 0;
                this.Close();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            bool std, vis;
            var item = new Menu();
            item.displayName = TxtNomMenu.Text;
            item.Descripcion = TxtDescripcion.Text;
            item.formulario = TxtFormulario.Text;
            item.componente = TxtComponente.Text;
            if (CmbEstado.SelectedIndex == 0) std = true; else std = false;
            item.estado = std;
            if (CmbVisibilidad.SelectedIndex == 0) vis = true; else vis = false;
            item.UsarVisibilidad = vis;
            item.UsuarioRegistro = DeploySettings.UsuarioConectado;
            item.idMenuPadre = TxtMenuPadre.Text != "" ? IdMenu : 0;
            item.CodPrograma = TxtPrograma.Text;
            var rpta = _objsvc.CrearItemMenu(item,"I");
            MessageBox.Show("Registro Guardado Satisfactoriamente","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
            BtnNuevo.Text = "Nuevo";
            HabButton(true,false,true,true,true,false);
            Inhabilitar();
            ((frmConsultaMenu)this.Owner).CargarGrilla();  
            this.Close();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
                Modificar();
            
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscar frm = new frmBuscar();
            frm.Owner = this;
            frm.Codigo = id;
            //frm2.Codigo = codigo;
            frm.ShowDialog();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TxtMenuPadre.Text = "";
            IdMenu = 0;
            BtnCancelar.Enabled = false;
        }
    }


        
    }

