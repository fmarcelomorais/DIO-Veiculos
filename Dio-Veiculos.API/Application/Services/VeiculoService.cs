using Dio_Veiculos.API.Application.DTOs;
using Dio_Veiculos.API.Application.Interfaces;
using Dio_Veiculos.API.Application.MapperConfig;
using Dio_Veiculos.API.Domain.Interfaces;

namespace Dio_Veiculos.API.Application.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _repository;

        public VeiculoService(IVeiculoRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Create(VeiculoDto veiculoDto)
        {
            return await _repository.Created(Mapper.MapperVeiculoDtoToVeiculo(veiculoDto));
        }

        public async Task<bool> Delete(int id)
        {
            var veiculo = await _repository.GetById(id);
            return await _repository.Delete(veiculo);
        }

        public async Task<List<VeiculoDto>> GetAll()
        {
            return Mapper.MapperListVeiculoToListVeiculoDto(await _repository.GetAll());
        }

        public async Task<VeiculoDto> GetById(int id)
        {
            return Mapper.MapperVeiculoToVeiculoDto(await _repository.GetById(id));
        }

        public async Task<VeiculoDto> SearchForPlaca(string placa)
        {
            return Mapper.MapperVeiculoToVeiculoDto(await _repository.SearchForPlaca(veiculo => veiculo.Placa.ToLower() == placa.ToLower()));
        }

        public async Task<bool> Update(int id, VeiculoDto veiculoDto)
        {
            var veiculo = await _repository.GetById(id);
            veiculo.Marca = veiculoDto.Marca;
            veiculo.Modelo = veiculoDto.Modelo;
            veiculo.Placa = veiculoDto.Placa;
            veiculo.Ano = veiculoDto.Ano;

            return await _repository.Update(veiculo);
        }
    }
}
