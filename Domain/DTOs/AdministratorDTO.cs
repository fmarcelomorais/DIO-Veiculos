using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO_Veiculos.Domain.DTOs
{
    public record AdministratorDto(string Name, string Email, string Password);
}