using Infrastructure.EmsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class PaidSalaryService:BaseEmsServices<PaidSalaries>
    {
        public PaidSalaries GetLastPaid(int userId)
        {
            try
            {
                var entity = this.GetAllByParameter(x => x.UserId == userId).Last();
                return entity;
            }
            catch
            {
                return null;
            }
        }
    }
}
