﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiPractica4.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PracticaS12Entities : DbContext
    {
        public PracticaS12Entities()
            : base("name=PracticaS12Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Abonos> Abonos { get; set; }
        public virtual DbSet<Principal> Principal { get; set; }
    
        public virtual ObjectResult<SP_ConsultarProductos_Result> SP_ConsultarProductos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ConsultarProductos_Result>("SP_ConsultarProductos");
        }
    
        public virtual ObjectResult<SP_ORDENADO_Result> SP_ORDENADO()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ORDENADO_Result>("SP_ORDENADO");
        }
    
        public virtual ObjectResult<SP_ProductosPendientes_Result> SP_ProductosPendientes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ProductosPendientes_Result>("SP_ProductosPendientes");
        }
    }
}
