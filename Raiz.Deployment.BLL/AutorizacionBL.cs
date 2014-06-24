using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raiz.Deployment.DTO;
using Raiz.Deployment.Persistencia;

namespace Raiz.Deployment.BL
{
    public class AutorizacionBL
    {

        public List<Menu> ListarMenuPorUsuario(string usuario)
        {
            var result = new List<Menu>();
            

            using (var ctx = new RaizNetContext())
            {
                var listaMenu = ctx.ListarMenuPorUsuario(usuario);

                foreach (var item in listaMenu)
                {
                    var mnu = new Menu();
                    mnu.idMenu = item.idMenu;
                    mnu.idMenuPadre = item.idMenuPadre;
                    mnu.displayName = item.displayName;
                    mnu.Descripcion = item.Descripcion;
                    mnu.formulario = item.formulario;
                    mnu.componente = item.componente;
                    mnu.estado = item.estado;
                    mnu.UsarVisibilidad = item.usarVisibilidad;
                    result.Add(mnu);
                    
                }
            }

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
