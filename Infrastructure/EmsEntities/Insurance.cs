using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EmsEntities
{
    public class Insurance : EmsBaseEntity
    {
        public string InsuranceModel { get; set; }
        public int Price { get; set; }
    }
}
