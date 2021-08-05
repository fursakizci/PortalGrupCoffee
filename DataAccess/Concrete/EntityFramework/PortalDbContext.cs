using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class PortalDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Server=DESKTOP-AV372PO\SQLEXPRESS;Database=PortalGrupDb;Trusted_Connection=true");

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
