﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarCommunicator.Common.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarCommunicatorEntities : DbContext
    {
        public CarCommunicatorEntities()
            : base("name=CarCommunicatorEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CarData> CarData { get; set; }
        public DbSet<CarInformation> CarInformation { get; set; }
        public DbSet<LoggerBase> LoggerBase { get; set; }
        public DbSet<LoggerInformation> LoggerInformation { get; set; }
    }
}
