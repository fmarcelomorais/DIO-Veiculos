using Dio_Veiculos.API.Domain.Interfaces;
using Dio_Veiculos.API.Domain.Models;
using Dio_Veiculos.API.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dio_Veiculos.API.Infraestructure.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly ApplicationContext _context;

        public AdministratorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAdministrator(Administrator administrator)
        {
            //administrator.Perfil = Perfil.Admin;
            await _context.Administrators.AddAsync(administrator);
            if(_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<Administrator> GetAdministratorById(int id)
        {
            return await _context.Administrators
                .AsNoTracking()
                .FirstOrDefaultAsync(adm => adm.Id == id);
        }

        public async Task<List<Administrator>> GetAllAdministrators()
        {
            return await _context.Administrators.AsNoTracking().ToListAsync();
        }

        public async Task<Administrator> Search(Expression<Func<Administrator, bool>> expression)
        {
            return await _context.Administrators.FirstOrDefaultAsync(expression);
        }
    }
}
