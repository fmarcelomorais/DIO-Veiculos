using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO_Veiculos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DIO_Veiculos.Infraestructure
{
    public class Context : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }

        DbSet<Administrator> administrators { get; set; } 
    }
}