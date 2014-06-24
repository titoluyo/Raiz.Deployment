using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raiz.Deployment.Persistencia;
using Raiz.Deployment.DTO;


namespace Raiz.Deployment.BL
{
    public class MenuBL
    {

        public int CrearItemMenu(Menu item, string tipo)
        { 
        
            //1era Forma - Usando SP
            using(var ctx=new RaizNetContext())
            {

                ctx.CreaActualizaMenus(item.idMenu, item.displayName, item.Descripcion, item.formulario, item.componente,item.CodPrograma,
                                       item.idMenuPadre, item.estado, item.UsarVisibilidad, 
                                       item.UsuarioRegistro,tipo);
            }

            //2da forma - Usando EEFF
    
            //using(var ctx=new RaizNetContext())
           // {
             //   ctx.TBMRaizNetMenu.Add(item);
              //  ctx.SaveChanges();
            //}



            return item.idMenu;
        
        }

        //Consultar Menu de Opciones
        public ConsultaRegistroMenu_Result ConsultarMenu(int idMenu)
        {
            using (var ctx = new RaizNetContext())
            {
                var result = new ConsultaRegistroMenu_Result();
                result=ctx.ConsultaRegistroMenu(idMenu).FirstOrDefault();
                return result;
                
            }

        }

        //Consulta Resultado de Busqueda
        public List<BuscarMenu_Result> BuscarMenu(int idPadre, int idMenu, string descripcion)
        {
            using (var ctx = new RaizNetContext())
            {
                var busq = new List<BuscarMenu_Result>();
                busq = ctx.BuscarMenu(idPadre, idMenu, descripcion).ToList();
                return busq;
            }
        }

        //Consulta Menu
        public  List<ConsultaMenu_Result> ConsultaMenu(int idMenu, string descripcion, int estado, int visibilidad)
        {
            using (var ctx = new RaizNetContext())
            {
                var cons = new List<ConsultaMenu_Result>();
                cons = ctx.ConsultaMenu(idMenu, descripcion, estado, visibilidad).ToList();
                return cons;
            }
        }

        //Consulta Menu Hijos
        public List<ConsultaMenuHijos_Result> ConsultaMenuHijos(int idMenuPadre)
        {
            using (var ctx = new RaizNetContext())
            {
                var cons = new List<ConsultaMenuHijos_Result>();
                cons = ctx.ConsultaMenuHijos(idMenuPadre).ToList();
                return cons;
            }
        }

        public List<Menu> ListarMenus(bool estado )
        {
            using (var ctx = new RaizNetContext())
            {
                var result = (from tm in ctx.TBMRaizNetMenu
                              where tm.estado == estado
                              select tm).ToList();
                return result;
            }
        }

    }
}
