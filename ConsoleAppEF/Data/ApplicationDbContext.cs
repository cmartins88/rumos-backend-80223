using ConsoleAppEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppEF.Data
{
    // COMANDOS PARA EXECUTAREM NA PACKAGE MANAGER CONSOLE PARA CRIAR A BD
    // (não se esqueçam de alterar a connection string que está no ficheiro appsettings para se ligar a uma base de dados local criada por vós)
    //
    // - Add-Migration
    // - Update-Database

    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();*/

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=Rumos; Integrated Security=SSPI; Persist Security Info=False;");
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
