using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure.EmsEntities
{
    public class Hierarchy : EmsBaseEntity
    {
        public int JobId { get; set; }
        public short HierarchyRank { get; set; }
        public int RankId { get; set; }
    }
}
