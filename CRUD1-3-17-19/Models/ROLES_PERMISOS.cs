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
    
    public partial class ROLES_PERMISOS
    {
        public int ID { get; set; }
        public int ROL_ID { get; set; }
        public int PERMISO_ID { get; set; }
        public System.DateTime FECHA_ASIGNACION_ { get; set; }
    
        public virtual PERMISOS PERMISOS { get; set; }
        public virtual ROLES ROLES { get; set; }
    }
}
