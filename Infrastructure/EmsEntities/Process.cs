using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure.EmsEntities
{
    public partial class Process:EmsBaseEntity
    {
        [Key]
        public string ProcessName { get; set; }
        public double Price { get; set; }
    }
}
