//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD1_3_17_19.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PERMISOS
    {
        ALUMNOS_DBContext db = new ALUMNOS_DBContext();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERMISOS()
        {
            this.PERMISOS1 = new HashSet<PERMISOS>();
            this.ROLES_PERMISOS = new HashSet<ROLES_PERMISOS>();
        }
    
        public int ID { get; set; }
        public string NOMBRE_PERMISO { get; set; }
        public string URL { get; set; }
        public Nullable<int> PERMISO_PADRE { get; set; }
        public string FAVICON { get; set; }
        public string CONTROLLER { get; set; }
        public string ACTION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<PERMISOS> PERMISOS1 { get; set; }
        public virtual PERMISOS PERMISOS2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROLES_PERMISOS> ROLES_PERMISOS { get; set; }
    }
}
