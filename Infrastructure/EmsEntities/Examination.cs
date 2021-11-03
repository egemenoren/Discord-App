using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EmsEntities
{
    public class Examination : EmsBaseEntity
    {
        public string NameSurname { get; set; }
        public string Process { get; set; }
        public int Bill { get; set; }
        public bool HaveInsurance { get; set; }
        public string DoctorName { get; set; }
        public bool isJudical { get; set; }
        public string OfficeName { get; set; }

    }
}
