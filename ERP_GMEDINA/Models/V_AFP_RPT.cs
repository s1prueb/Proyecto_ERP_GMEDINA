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
    
    public partial class V_AFP_RPT
    {
        public int hipa_IdHistorialDePago { get; set; }
        public int emp_Id { get; set; }
        public string per_Identidad { get; set; }
        public string per_Empleado { get; set; }
        public int depto_Id { get; set; }
        public string depto_descripcion { get; set; }
        public int area_Id { get; set; }
        public string area_Descripcion { get; set; }
        public decimal hipa_AFP { get; set; }
        public int cpla_IdPlanilla { get; set; }
        public int cde_IdDeducciones { get; set; }
        public System.DateTime hipa_FechaPago { get; set; }
    }
}
