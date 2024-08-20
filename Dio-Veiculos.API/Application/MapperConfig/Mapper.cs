using Dio_Veiculos.API.Application.DTOs;
using Dio_Veiculos.API.Domain.Models;

namespace Dio_Veiculos.API.Application.MapperConfig
{
    public static class Mapper
    {
        public static AdministratorDto MapperAdministratorToAdministratorDto(Administrator administrator)
        {
            if (administrator is null) return new AdministratorDto();
            AdministratorDto admin = new()
            {
                Id = administrator.Id,
                Name = administrator.Name,
                Email = administrator.Email,
                Passworld = administrator.Passworld,
                Perfil = administrator.Perfil
            };
            return admin;
        }
        public static List<AdministratorDto> MapperListAdministratorToListAdministratorDto(List<Administrator> administrators)
        {
            List<AdministratorDto> list = [];

            foreach(var adm in administrators)
            {
                list.Add(MapperAdministratorToAdministratorDto(adm));
            }

            return list;
        }
        public static Administrator MapperAdministratorDtoToAdministrator(AdministratorDto administratorDto)
        {
            if (administratorDto is null) return new Administrator();
            Administrator admin = new()
            {
                Id = administratorDto.Id,
                Name = administratorDto.Name,
                Email = administratorDto.Email,
                Passworld = administratorDto.Passworld,
                Perfil = administratorDto.Perfil
            };
            return admin;
        }
        public static List<Administrator> MapperListAdministratorDtoToListAdministrator(List<AdministratorDto> administratorsDto)
        {
            List<Administrator> list = [];

            foreach (var adm in administratorsDto)
            {
                list.Add(MapperAdministratorDtoToAdministrator(adm));
            }

            return list;
        }
    
        public static Veiculo MapperVeiculoDtoToVeiculo(VeiculoDto veiculoDto)
        {
            Veiculo veiculo = new()
            {
                Id = veiculoDto.Id,
                Marca = veiculoDto.Marca,
                Modelo = veiculoDto.Modelo,
                Ano = veiculoDto.Ano,
                Placa = veiculoDto.Placa,
            };

            return veiculo;
        }
        public static VeiculoDto MapperVeiculoToVeiculoDto(Veiculo veiculo)
        {
            if (veiculo is null) return new VeiculoDto();

            VeiculoDto veiculoDto = new()
            {
                Id = veiculo.Id,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Ano = veiculo.Ano,
                Placa = veiculo.Placa,
            };

            return veiculoDto;
        }
        public static List<Veiculo> MapperListVeiculoDtoToListVeiculo(List<VeiculoDto> list)
        {
            List<Veiculo> veiculos = [];

            foreach(var veiculo in list)
            {
                veiculos.Add(MapperVeiculoDtoToVeiculo(veiculo));
            }
            return veiculos;
        } 
        public static List<VeiculoDto> MapperListVeiculoToListVeiculoDto(List<Veiculo> list)
        {
            List<VeiculoDto> veiculos = [];

            foreach(var veiculo in list)
            {
                veiculos.Add(MapperVeiculoToVeiculoDto(veiculo));
            }
            return veiculos;
        }
    
    }
}
