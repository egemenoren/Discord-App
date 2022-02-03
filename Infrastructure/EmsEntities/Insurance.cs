using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure.EmsEntities
{
    public partial class Insurance:EmsBaseEntity
    {
        [Key]
        public string PackageName { get; set; }
        public double Price { get; set; }
        [Column(TypeName = "datetime")]
        public double DiscountRateForBasicProcesses { get; set; }
        public double DiscountRateForMediumProcesses { get; set; }
        public double DiscountRateForCriticalProcesses { get; set; }
        public int Credits { get; set; }
    }
}
