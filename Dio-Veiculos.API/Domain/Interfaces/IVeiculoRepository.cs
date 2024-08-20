using Dio_Veiculos.API.Domain.Models;
using System.Linq.Expressions;

namespace Dio_Veiculos.API.Domain.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<List<Veiculo>> GetAll();
        Task<Veiculo> GetById(int id);
        Task<bool> Created(Veiculo veiculo);
        Task<bool> Update(Veiculo veiculo);
        Task<bool> Delete(Veiculo veiculo);
        Task<Veiculo> SearchForPlaca(Expression<Func<Veiculo, bool>> expression);   
    }
}
