using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure.EmsEntities
{
    public partial class Hierarchy
    {
        [Key]
        public int Id { get; set; }
        public int JobId { get; set; }
        public short HierarchyRank { get; set; }
        public int RankId { get; set; }
        public bool Fix { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateTime { get; set; }
        public int Status { get; set; }
    }
}
