using ColecaoDeLivros.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace ColecaoDeLivros.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Item> Item { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<ItemEmprestado> ItemEmprestado { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ItemDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasOne(m => m.Contato).WithOne().HasForeignKey("Contato","ItemEmprestado");
        }
    }
}
