using Edenmao.Core.Interfaces;
using Edenmao.Domain.ClaseBase;
using Edenmao.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _entites;
        protected RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
            _entites = context.Set<T>();
        }
        public async virtual Task AddAsync(T entity)
        {
            _entites.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool?> DeleteByIdAsync(int id)
        {
            var entity = await _entites.FindAsync(id);

            if (entity == null)
                return null;

            entity.Eliminado = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entites.Where(e => e.Eliminado == false).ToListAsync();
        }

        public async virtual Task<T> GetByIdAsync(int id)
        {
            return await _entites.Where(e => e.Id == id && e.Eliminado == false).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entites.Where(predicate).ToListAsync();
        }

        public async virtual Task UpdateAsync(T entity)
        {
            var existingEntity = await _entites.Where(e => e.Id == entity.Id && e.Eliminado == false).FirstOrDefaultAsync();

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            _context.Entry(existingEntity).Property(e => e.FechaRegistro).IsModified = false;

            await _context.SaveChangesAsync();
        }
    }
}
