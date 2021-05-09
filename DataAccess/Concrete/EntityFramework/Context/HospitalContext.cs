using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class HospitalContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=HospitalDb;Trusted_Connection=true");
        }

        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
    }
}
