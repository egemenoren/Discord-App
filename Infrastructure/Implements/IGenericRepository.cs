using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implements
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null);
        Task Update(T entity);
    }
}
