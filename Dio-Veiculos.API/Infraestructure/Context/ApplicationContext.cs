using Dio_Veiculos.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dio_Veiculos.API.Infraestructure.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Database\\Veiculos.db; Cache=Shared");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>()
                .HasData(
                    new Administrator
                    {
                        Id = 1,
                        Name = "Administrator",
                        Email = "admin@admin.com",
                        Passworld = "123456",
                        Perfil = Perfil.Admin,
                    }
                );
            modelBuilder.Entity<Veiculo>()
                .HasData(
                    new Veiculo
                    {
                        Id = 1,
                        Marca = "GM",
                        Modelo = "Corsa Hatch Maxx",
                        Ano = "2007",
                        Placa = "HYT3151"
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
