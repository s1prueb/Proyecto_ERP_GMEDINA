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
    
    public partial class V_PlanillaIngresos
    {
        public int cpla_IdPlanilla { get; set; }
        public string cpla_DescripcionPlanilla { get; set; }
        public int cpla_FrecuenciaEnDias { get; set; }
        public int tpdi_IdDetallePlanillaIngreso { get; set; }
        public int cin_IdIngreso { get; set; }
        public string cin_DescripcionIngreso { get; set; }
    }
}
