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
    
    public partial class ALUMNO
    {
        public int ID { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public int EDAD { get; set; }
        public string SEXO { get; set; }
        public System.DateTime FECHA_REGISTRO { get; set; }
        public Nullable<int> ROLES_ID { get; set; }
    
        public virtual ROLES ROLES { get; set; }
    }
}
