using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure.EmsEntities
{
    public partial class RegisterInsurance:EmsBaseEntity
    {
        
        public string NameSurname { get; set; }
        public int DoctorId { get; set; }
        public short InsuranceId { get; set; }
        public short CreditsLeft { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ExpireDate { get; set; } = DateTime.Now.AddDays(14);
    }
}
