using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure.EmsEntities
{
    public partial class MenuPermission:EmsBaseEntity
    {
        [Key]
        public int MainMenuId { get; set; }
        public int? RankId { get; set; }
        public int? UserId { get; set; }
        public int SubMenuId { get; set; }
        public int? JobId { get; set; }
    }
}
