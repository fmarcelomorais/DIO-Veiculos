using Dio_Veiculos.API.Application.DTOs;
using Dio_Veiculos.API.Application.Interfaces;
using Dio_Veiculos.API.Domain.Interfaces;
using Dio_Veiculos.API.Application.MapperConfig;
using System.Linq.Expressions;

namespace Dio_Veiculos.API.Application.Services;

public class AdministratorService : IAdministratorService
{
    private readonly IAdministratorRepository _repository;

    public AdministratorService(IAdministratorRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> CreateAdministrator(AdministratorDto administratorDto)
    {
        return await _repository.CreateAdministrator(Mapper.MapperAdministratorDtoToAdministrator(administratorDto));
    }

    public async Task<AdministratorDto> GetAdministratorById(int id)
    {
        return Mapper.MapperAdministratorToAdministratorDto(await _repository.GetAdministratorById(id));
    }

    public async Task<List<AdministratorDto>> GetAdministrators()
    {
        var administrators = Mapper.MapperListAdministratorToListAdministratorDto(await _repository.GetAllAdministrators());
        return administrators;
    }

    public async Task<AdministratorDto> Search(Login login)
    {
        var administrador = await _repository.Search(adm => adm.Email.ToLower() == login.Email.ToLower() && adm.Passworld.ToLower() == login.Passworld.ToLower() );
        return Mapper.MapperAdministratorToAdministratorDto(administrador);
    }
}
