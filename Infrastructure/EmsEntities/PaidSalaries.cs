using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EmsEntities
{
    public class PaidSalaries : EmsBaseEntity
    {
        public int UserId { get; set; }
        public double Salary { get; set; }
    }
}
