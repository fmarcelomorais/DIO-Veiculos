using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO_Veiculos.Domain.Entities;

namespace DIO_Veiculos.Domain.Services
{
    public class CreateAdmin
    {
        public Administrator Create(string name, string email, string password)
        {
            Administrator newAdministrator = new(name, email, password);
            return newAdministrator;
        }
    }
}