//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Raiz.Deployment.DTO
{
    using System;
    
    public partial class BuscarMenu_Result
    {
        public int idMenu { get; set; }
        public string displayName { get; set; }
        public string Descripcion { get; set; }
        public string formulario { get; set; }
        public string componente { get; set; }
        public Nullable<int> idMenuPadre { get; set; }
        public Nullable<bool> estado { get; set; }
        public Nullable<bool> UsarVisibilidad { get; set; }
        public string UsuarioRegistro { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
    }
}
