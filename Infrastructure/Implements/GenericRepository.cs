using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T:EmsBaseEntity
    {
        private readonly DiscordContext _context;
        private protected DbSet<T> _dbSet;
        public GenericRepository()
        {
            _context = new DiscordContext();
            _dbSet = _context.Set<T>();
        }
        public IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null)
        {
            if (Filter != null)
            {
                return _dbSet.Where(Filter);
            }
            return _dbSet;
        }

        public async Task Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
