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
    
    public partial class tbTipoPlanillaDetalleIngreso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbTipoPlanillaDetalleIngreso()
        {
            this.tbHistorialDeIngresosPago = new HashSet<tbHistorialDeIngresosPago>();
        }
    
        public int tpdi_IdDetallePlanillaIngreso { get; set; }
        public int cin_IdIngreso { get; set; }
        public int cpla_IdPlanilla { get; set; }
        public int tpdi_UsuarioCrea { get; set; }
        public System.DateTime tpdi_FechaCrea { get; set; }
        public Nullable<int> tpdi_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> tpdi_FechaModifica { get; set; }
        public bool tpdi_Activo { get; set; }
    
        public virtual tbUsuario tbUsuario { get; set; }
        public virtual tbUsuario tbUsuario1 { get; set; }
        public virtual tbCatalogoDeIngresos tbCatalogoDeIngresos { get; set; }
        public virtual tbCatalogoDePlanillas tbCatalogoDePlanillas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistorialDeIngresosPago> tbHistorialDeIngresosPago { get; set; }
    }
}
