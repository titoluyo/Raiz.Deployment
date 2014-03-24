using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Raiz.Deployment.DTO;
using Menu = Raiz.Deployment.DTO.Menu;

namespace Raiz.Deployment.ClientManager
{
    public class MenuLoader
    {
        MenuStrip _mainMenu=new MenuStrip();
        Form _mdiContainer=new Form();
        private bool _seCargoInfoMenu = false;

        private List<Menu> _dbMenus=new List<Menu>();
        public Form MdiContainer
        {
            get { return _mdiContainer; }
            set { _mdiContainer = value; }
        }

        public MenuLoader()
        {
            var mnu = new Menu();
            mnu.idMenu = 1;
            mnu.idMenuPadre = 0;
            mnu.displayName = "Reniec";
            mnu.Descripcion = "";
            mnu.formulario = "";
            mnu.componente = "Raiz.Modulo1.dll";
            _dbMenus.Add(mnu);

            mnu = new Menu();
            mnu.idMenu = 2;
            mnu.idMenuPadre = 0;
            mnu.displayName = "MGA";
            mnu.Descripcion = "";
            mnu.formulario = "";
            mnu.componente = "Raiz.Modulo2.dll";
            _dbMenus.Add(mnu);

            mnu = new Menu();
            mnu.idMenu = 3;
            mnu.idMenuPadre = 1;
            mnu.displayName = "Consulta Reniec";
            mnu.Descripcion = "";
            mnu.formulario = "FrmMod1";
            mnu.componente = "Raiz.Modulo1.dll";
            _dbMenus.Add(mnu);

            mnu = new Menu();
            mnu.idMenu = 4;
            mnu.idMenuPadre = 2;
            mnu.displayName = "Nueva Solicitud";
            mnu.Descripcion = "";
            mnu.formulario = "FrmMod2";
            mnu.componente = "Raiz.Modulo2.dll";
            _dbMenus.Add(mnu);

            mnu = new Menu();
            mnu.idMenu = 5;
            mnu.idMenuPadre = 1;
            mnu.displayName = "Consulta &DNI";
            mnu.Descripcion = "";
            mnu.formulario = "frmReniecDNI";
            mnu.componente = "Raiz.Reniec.Cliente.dll";
            _dbMenus.Add(mnu);

            mnu = new Menu();
            mnu.idMenu = 6;
            mnu.idMenuPadre = 2;
            mnu.displayName = "Consulta &Solicitudes";
            mnu.Descripcion = "";
            mnu.formulario = "frmMisSolicitudes";
            mnu.componente = "Raiz.MGA.Cliente.dll";
            _dbMenus.Add(mnu);

        }

        public List<Menu> ListarMenus(int parent)
        {
            return _dbMenus.FindAll(p => p.idMenuPadre == parent);
        }

        public MenuStrip CargarMenu()
        {
             CargarMenu(null, 0);
             CrearMenuInfo();
            return _mainMenu;
        }

        private MenuStrip CargarMenu(ToolStripMenuItem menuChild, int posicion)
        {
            var listaMenu = ListarMenus(posicion);//root menu
            if (listaMenu.Count > 0)
            {
                foreach (var menu in listaMenu)
                {
                    if (posicion == 0)
                    {
                        var rootMenu = new ToolStripMenuItem(menu.displayName);
                        CargarMenu(rootMenu, menu.idMenu);
                        _mainMenu.Items.Add(rootMenu);
                    }
                    else
                    {
                        var childMenu = new ToolStripMenuItem(menu.displayName, null,
                            new EventHandler(LoadFormulario),string.Format("{0}/{1}",menu.componente,menu.formulario) );
                        menuChild.DropDownItems.Add(childMenu);

                    }
                }
            }
            
            return _mainMenu;
        }

        public void LoadFormulario(object sender,EventArgs e)
        {
            var moduleManager = new ModuleManager();
            var rutaForm = ((ToolStripMenuItem) sender).Name;
            var elements=rutaForm.Split('/');
            var componente = elements[0];
            var formName = elements[1];

            var assembly = moduleManager.CargarComponente(componente);
            if (assembly == null)
            {
                MessageBox.Show("No se encuentra instalado el componente requerido en este equipo.");
                return;
            }

            try
            {
                var tipos = assembly.GetTypes();
                foreach (Type tipo in tipos)
                {
                    if (tipo.BaseType == null) continue;

                    if (tipo.BaseType == typeof(Form) || tipo.BaseType.BaseType == typeof(Form))
                    {
                        if (tipo.Name.ToUpper() == formName.ToUpper())
                        {
                            var frmShow = (Form)assembly.CreateInstance(tipo.ToString());
                            foreach (var form in MdiContainer.MdiChildren)
                            {
                                form.Close();
                            }
                            frmShow.MdiParent = MdiContainer;
                            frmShow.WindowState = FormWindowState.Maximized;
                            frmShow.Show();
                            return;
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                var excepciones = ex.LoaderExceptions;
                foreach (var excepcion in excepciones)
                {
                    MessageBox.Show(excepcion.Message);

                }

            }
            catch (TargetInvocationException ex)
            {
                MessageBox.Show(ex.InnerException.Message);
                throw ex;

            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            

           
            //---------------------------------------
        }

        public void CrearMenuInfo()
        {
            var rootMenu = new ToolStripMenuItem("Acerca de");
            var childMenu = new ToolStripMenuItem("Versiones", null, LoadInfoForm);
            rootMenu.DropDown.Items.Add(childMenu);
            _mainMenu.Items.Add(rootMenu);
        }


        public void LoadInfoForm(object sender, EventArgs e)
        {
            var frm = new frmAbout();
            
            frm.ShowDialog();
        }

    }
}
