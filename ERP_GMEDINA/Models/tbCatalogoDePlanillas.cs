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
    
    public partial class tbCatalogoDePlanillas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbCatalogoDePlanillas()
        {
            this.tbTipoPlanillaDetalleDeduccion = new HashSet<tbTipoPlanillaDetalleDeduccion>();
            this.tbTipoPlanillaDetalleIngreso = new HashSet<tbTipoPlanillaDetalleIngreso>();
            this.tbEmpleados = new HashSet<tbEmpleados>();
            this.tbDecimoCuartoMes = new HashSet<tbDecimoCuartoMes>();
            this.tbDecimoTercerMes = new HashSet<tbDecimoTercerMes>();
        }
    
        public int cpla_IdPlanilla { get; set; }
        public string cpla_DescripcionPlanilla { get; set; }
        public int cpla_FrecuenciaEnDias { get; set; }
        public bool cpla_RecibeComision { get; set; }
        public int cpla_UsuarioCrea { get; set; }
        public System.DateTime cpla_FechaCrea { get; set; }
        public Nullable<int> cpla_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> cpla_FechaModifica { get; set; }
        public bool cpla_Activo { get; set; }
    
        public virtual tbUsuario tbUsuario { get; set; }
        public virtual tbUsuario tbUsuario1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbTipoPlanillaDetalleDeduccion> tbTipoPlanillaDetalleDeduccion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbTipoPlanillaDetalleIngreso> tbTipoPlanillaDetalleIngreso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEmpleados> tbEmpleados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbDecimoCuartoMes> tbDecimoCuartoMes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbDecimoTercerMes> tbDecimoTercerMes { get; set; }
    }
}
