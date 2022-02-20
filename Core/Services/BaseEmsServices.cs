using Infrastructure;
using Infrastructure.EmsEntities;
using Infrastructure.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public abstract class BaseEmsServices<T> where T: EmsBaseEntity
    {
        GenericRepository<T> _repo;
        public BaseEmsServices()
        {
            _repo = new GenericRepository<T>();
        }
        public virtual T CheckData()
        {
            var entity = _repo.Select(x => x.Fix == false).FirstOrDefault();
            if (entity != null)
            {
                return entity;
            }
            return null;
        }
        public virtual List<T> CheckAllData()
        {
            var entity = _repo.Select(x => x.Fix == false);
            if (entity != null)
            {
                return entity.ToList();
            }
            return null;

        }
        public virtual async Task UpdateData(T entity)
        {
            entity.Fix = true;
            await _repo.Update(entity);
        }
        public virtual T GetByParameter(Expression<Func<T,bool>> Filter = null)
        {
            if (Filter == null)
                return null;
            return _repo.Select(Filter).FirstOrDefault();
        }
        public virtual IEnumerable<T> GetAllByParameter(Expression<Func<T, bool>> Filter = null)
        {
            if (Filter == null)
                return _repo.Select();
            return _repo.Select(Filter).ToList();
        }
    }
}
