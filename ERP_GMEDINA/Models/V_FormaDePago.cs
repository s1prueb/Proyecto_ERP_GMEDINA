//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP_GMEDINA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class V_FormaDePago
    {
        public int fpa_IdFormaPago { get; set; }
        public string fpa_Descripcion { get; set; }
        public int fpa_UsuarioCrea { get; set; }
        public System.DateTime fpa_FechaCrea { get; set; }
        public Nullable<int> fpa_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> fpa_FechaModifica { get; set; }
        public bool fpa_Activo { get; set; }
    }
}