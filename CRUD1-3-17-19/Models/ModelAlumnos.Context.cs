﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ALUMNOS_DBContext : DbContext
    {
        public ALUMNOS_DBContext()
            : base("name=ALUMNOS_DBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ALUMNO> ALUMNO { get; set; }
        public virtual DbSet<PERMISOS> PERMISOS { get; set; }
        public virtual DbSet<ROLES> ROLES { get; set; }
        public virtual DbSet<ROLES_PERMISOS> ROLES_PERMISOS { get; set; }
    }
}
