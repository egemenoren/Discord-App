using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure.EmsEntities
{
    public partial class Rank:EmsBaseEntity
    {
        [Key]
        public string RankName { get; set; }
        [Column(TypeName = "datetime")]
        public bool AccessJobPanel { get; set; }
        public int JobId { get; set; }
        public byte HierarchyNo { get; set; }
        public int HourlySalary { get; set; }
    }
}
