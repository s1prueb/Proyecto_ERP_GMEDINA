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
    
    public partial class V_HistorialAudienciaDescargo
    {
        public int aude_Id { get; set; }
        public int emp_Id { get; set; }
        public string emp_Nombre { get; set; }
        public bool emp_Estado { get; set; }
        public string aude_Descripcion { get; set; }
        public System.DateTime aude_FechaAudiencia { get; set; }
        public bool aude_Testigo { get; set; }
        public string aude_DireccionArchivo { get; set; }
        public bool aude_Estado { get; set; }
        public string aude_RazonInactivo { get; set; }
        public int aude_UsuarioCrea { get; set; }
        public System.DateTime aude_FechaCrea { get; set; }
        public Nullable<int> aude_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> aude_FechaModifica { get; set; }
    }
}