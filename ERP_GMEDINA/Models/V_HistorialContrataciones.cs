//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP_GMEDINA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class V_HistorialContrataciones
    {
        public int Id { get; set; }
        public string Nombre_Completo { get; set; }
        public string Departamento { get; set; }
        public string Area { get; set; }
        public string Cargo { get; set; }
        public Nullable<System.DateTime> Fecha_Seleccion_Candidato { get; set; }
        public System.DateTime Fecha_Contrato { get; set; }
        public string Usuario_Crea { get; set; }
        public System.DateTime Fecha_Crea { get; set; }
        public string Usuario_Modifica { get; set; }
        public Nullable<System.DateTime> Fecha_Modifica { get; set; }
        public int IdEmpleado { get; set; }
    }
}
