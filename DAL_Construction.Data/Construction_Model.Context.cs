﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL_Construction.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Construction_DBEntities : DbContext
    {
        public Construction_DBEntities()
            : base("name=Construction_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Change_Order> Change_Order { get; set; }
        public DbSet<DailyItem> DailyItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobData> JobDatas { get; set; }
        public DbSet<payment> payments { get; set; }
        public DbSet<tbl_sub_contractor> tbl_sub_contractor { get; set; }
        public DbSet<tblContractor> tblContractors { get; set; }
        public DbSet<tblDailyEquipment> tblDailyEquipments { get; set; }
        public DbSet<tblEquipment> tblEquipments { get; set; }
        public DbSet<tblworkforce> tblworkforces { get; set; }
    }
}