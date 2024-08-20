using System.ComponentModel.DataAnnotations;

namespace Dio_Veiculos.API.Application.DTOs
{
    public record VeiculoDto
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Placa { get; set; }
    }

    public record CreateVeiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public required string Placa { get; set; }
    }
}
