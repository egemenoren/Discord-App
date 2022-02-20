using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EmsEntities
{
    public class PayChecks : EmsBaseEntity
    {
        public int UserId { get; set; }
        public double CurrentPay { get; set; } = 0;
        public bool IsPaid { get; set; } = false;
    }
}
