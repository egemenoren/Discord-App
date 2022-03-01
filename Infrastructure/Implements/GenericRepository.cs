using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DiscordContext _context;
        private protected DbSet<T> _dbSet;
        public GenericRepository()
        {
            try
            {
                _context = new DiscordContext();

                _dbSet = _context.Set<T>();
            }
            catch
            {

            }
            
        }
        public IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null)
        {
            try
            {
                if (Filter != null)
                {
                    return _dbSet.Where(Filter);
                }
                return _dbSet;
            }
            catch
            {
                return _dbSet;
            }
            
        }

        public async Task Update(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await SaveChanges();
            }
            catch
            {

            }
            
        }
        public async Task SaveChanges()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {

            }
            
        }
    }
}
