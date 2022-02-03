using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure.EmsEntities
{
    public partial class Examination : EmsBaseEntity
    {
        [Key]
        public string NameSurname { get; set; }
        public int ProcessId { get; set; }
        public int InsuranceId { get; set; }
        public bool HaveInsurance { get; set; }
        public double Price { get; set; }
        [Column("isJudical")]
        public bool IsJudical { get; set; }
        public string OfficerName { get; set; }
        public int DoctorId { get; set; }
        public string Diagnosis { get; set; }

    }
}
