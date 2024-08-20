using Dio_Veiculos.API.Application.DTOs;
using System.Linq.Expressions;

namespace Dio_Veiculos.API.Application.Interfaces
{
    public interface IAdministratorService
    {
        Task<List<AdministratorDto>> GetAdministrators();
        Task<AdministratorDto> GetAdministratorById(int id);
        Task<bool> CreateAdministrator(AdministratorDto administratorDto);
        Task<AdministratorDto> Search(Login login);
    }
}
