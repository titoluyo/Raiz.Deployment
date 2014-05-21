using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raiz.Deployment.DTO;

namespace Raiz.Deployment.BL
{
    public class AutorizacionBL
    {

        public List<Menu> ListarMenuPorUsuario(string usuario)
        {
            var result = new List<Menu>();
            var mnu = new Menu();
            mnu.idMenu = 1;
            mnu.idMenuPadre = 0;
            mnu.displayName = "Reniec";
            mnu.Descripcion = "";
            mnu.formulario = "";
            mnu.componente = "Raiz.Modulo1.dll";
            result.Add(mnu);

            mnu = new Menu();
            mnu.idMenu = 2;
            mnu.idMenuPadre = 0;
            mnu.displayName = "MGA";
            mnu.Descripcion = "";
            mnu.formulario = "";
            mnu.componente = "Raiz.Modulo2.dll";
            result.Add(mnu);

            mnu = new Menu();
            mnu.idMenu = 3;
            mnu.idMenuPadre = 1;
            mnu.displayName = "Consulta Reniec";
            mnu.Descripcion = "";
            mnu.formulario = "FrmMod1";
            mnu.componente = "Raiz.Modulo1.dll";
            result.Add(mnu);

            mnu = new Menu();
            mnu.idMenu = 4;
            mnu.idMenuPadre = 2;
            mnu.displayName = "Nueva Solicitud";
            mnu.Descripcion = "";
            mnu.formulario = "FrmMod2";
            mnu.componente = "Raiz.Modulo2.dll";
            result.Add(mnu);

            mnu = new Menu();
            mnu.idMenu = 5;
            mnu.idMenuPadre = 1;
            mnu.displayName = "Consulta &DNI";
            mnu.Descripcion = "";
            mnu.formulario = "frmReniecDNI";
            mnu.componente = "Raiz.Reniec.Cliente.dll";
            result.Add(mnu);

            mnu = new Menu();
            mnu.idMenu = 6;
            mnu.idMenuPadre = 2;
            mnu.displayName = "Consulta &Solicitudes";
            mnu.Descripcion = "";
            mnu.formulario = "frmMisSolicitudes";
            mnu.componente = "Raiz.MGA.Cliente.dll";
            result.Add(mnu);

            return result;
        }

        public List<string> ListarModulos()
        {
            var result = new List<string>();
            result.Add("Raiz.MGA.Cliente.dll");
            result.Add("Raiz.Reniec.Cliente.dll");
            result.Add("Raiz.Modulo1.Cliente.dll");
            result.Add("Raiz.Modulo2.Cliente.dll");
            return result;
        }

        public List<string> ListarComponentesUsoPorUsuario(string usuario)
        {
            var menus = ListarMenuPorUsuario(usuario);
            return menus.Select(p => p.componente).Distinct().ToList();
        }


        

    }
}
