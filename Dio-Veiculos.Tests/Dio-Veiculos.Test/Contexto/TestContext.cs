using Dio_Veiculos.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dio_Veiculos.Test.Contexto
{
    public class TestContext : DbContext
    {
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public string DbPath { get; }
        public TestContext()
        {
           DbPath = "F:\\workspace\\DotNet\\Dio-Veiculos\\Dio-Veiculos.Tests\\Dio-Veiculos.Test\\Database";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}\\VeiculosTeste.db; Cache=Shared");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
