﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoU2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EcartDBEntities : DbContext
    {
        public EcartDBEntities()
            : base("name=EcartDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
