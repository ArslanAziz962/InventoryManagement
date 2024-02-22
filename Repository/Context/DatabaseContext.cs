using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class DatabaseContext:DbContext
    {
        string connectionString = "Data Source=DESKTOP-UGJCCUS\\MSSQLSERVER01;Initial Catalog=InventoryDb;Persist Security Info=True;User ID=sa;Password=sa123;TrustServerCertificate=True";
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Purchase> Purchases { get; set; }      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Sale>().HasOne(s => s.Product).WithMany(p => p.Sales).HasForeignKey(s => s.ProductId);
            modelBuilder.Entity<Purchase>().HasOne(s => s.Product).WithMany(p => p.Purchases).HasForeignKey(p => p.ProductId);

        }

    }
}
