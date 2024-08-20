using Dio_Veiculos.API.Domain.Models;

namespace Dio_Veiculos.API.Application.DTOs
{
    public record AdministratorDto()
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Passworld { get; set; }
        public Perfil Perfil { get; set; }
    };
    public record Login(string Email, string Passworld); 

    
}
