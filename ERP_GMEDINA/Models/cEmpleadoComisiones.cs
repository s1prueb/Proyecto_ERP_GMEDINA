﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_GMEDINA.Models
{
    [MetadataType(typeof(cEmpleadoComisiones))]
    public partial class tbEmpleadoComisiones
    {
    }
    public class cEmpleadoComisiones
    {

        [Display(Name = "ID Empleado Comision")]
        public int cc_Id { get; set; }

        [Display(Name = "Empleado")]
        [Required(ErrorMessage = "No puede dejar campos vacios.")]
        public int emp_Id { get; set; }

        [Display(Name = "Ingreso")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} de requerido.")]

        public int cin_IdIngreso { get; set; }

        [Display(Name = "Monto")]
        [Required(ErrorMessage = "No puede dejar campos vacios.")]
        public decimal cc_Monto { get; set; }

        [Display(Name = "Fecha Registro")]
        public System.DateTime cc_FechaRegistro { get; set; }

        [Display(Name = "Pagado")]
        public bool cc_Pagado { get; set; }

        [Display(Name = "Creado por")]
        public int cc_UsuarioCrea { get; set; }

        [Display(Name = "Fecha de Creacion")]
        public System.DateTime cc_FechaCrea { get; set; }

        [Display(Name = "Modificado por")]
        public Nullable<int> cc_UsuarioModifica { get; set; }

        [Display(Name = "Fecha Modificacion")]
        public Nullable<System.DateTime> cc_FechaModifica { get; set; }

        [Display(Name = "Activo")]
        public bool cc_Activo { get; set; }
    }
}