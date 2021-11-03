using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EmsEntities
{
    public class RegisterInsurance:EmsBaseEntity
    {
        public string NameSurname { get; set; }
        public string InsuranceModel { get; set; }
        public string DoctorName { get; set; }
        public int Bill { get; set; }
    }
}
