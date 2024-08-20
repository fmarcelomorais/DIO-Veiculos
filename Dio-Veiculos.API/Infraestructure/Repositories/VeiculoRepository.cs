using Dio_Veiculos.API.Domain.Interfaces;
using Dio_Veiculos.API.Domain.Models;
using Dio_Veiculos.API.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dio_Veiculos.API.Infraestructure.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly ApplicationContext _context;

        public VeiculoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Created(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            var result = await _context.SaveChangesAsync();
            if (result > 0) return true;
            return false;
            
        }

        public async Task<bool> Delete(Veiculo veiculo)
        {
            _context.Remove(veiculo);
            var result = await _context.SaveChangesAsync();
            if (result > 0) return true;
            return false;
        }

        public async Task<List<Veiculo>> GetAll()
        {
            return await _context.Veiculos.AsNoTracking().ToListAsync();
        }

        public async Task<Veiculo> GetById(int id)
        {
            return await _context.Veiculos.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Veiculo> SearchForPlaca(Expression<Func<Veiculo, bool>> expression)
        {
            return await _context.Veiculos.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<bool> Update(Veiculo veiculo)
        {
            _context.Entry<Veiculo>(veiculo).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            if (result > 0) return true;
            return false;
        }
    }
}
