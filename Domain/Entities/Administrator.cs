using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO_Veiculos.Domain.Entities
{
    public class Administrator
    {
        public Administrator(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        private string Name { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }

    }
}