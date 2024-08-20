using Dio_Veiculos.API.Application.DTOs;

namespace Dio_Veiculos.API.Application.Interfaces
{
    public interface IVeiculoService
    {
        Task<bool> Create(VeiculoDto veiculoDto);
        Task<List<VeiculoDto>> GetAll();
        Task<VeiculoDto> GetById(int id);
        Task<bool> Update(int id, VeiculoDto veiculoDto);
        Task<bool> Delete(int id);
        Task<VeiculoDto> SearchForPlaca(string placa);

    }
}
