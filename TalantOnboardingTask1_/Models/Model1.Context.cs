﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TalantOnboardingTask1_.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TalentEntities : DbContext
    {
        public TalentEntities()
            : base("name=TalentEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer_> Customer_ { get; set; }
        public virtual DbSet<Product_> Product_ { get; set; }
        public virtual DbSet<Sales_> Sales_ { get; set; }
        public virtual DbSet<Store_> Store_ { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
