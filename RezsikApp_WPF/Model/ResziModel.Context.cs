﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RezsikApp_WPF.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ResziModelContainer : DbContext
    {
        public ResziModelContainer()
            : base("name=ResziModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Rezsik> RezsikSet { get; set; }
        public virtual DbSet<Felhasznalok> FelhasznalokSet { get; set; }
        public virtual DbSet<Tipusok> TipusokSet { get; set; }
    }
}
