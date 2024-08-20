using Dio_Veiculos.API.Domain.Models;
using System.Linq.Expressions;

namespace Dio_Veiculos.API.Domain.Interfaces
{
    public interface IAdministratorRepository
    {
        Task<List<Administrator>> GetAllAdministrators();
        Task<Administrator> GetAdministratorById(int id);
        Task<bool> CreateAdministrator(Administrator administrator);
        Task<Administrator> Search(Expression<Func<Administrator, bool>> expression);
    }
}
