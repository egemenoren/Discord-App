using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure.EmsEntities
{
    public partial class User : EmsBaseEntity
    {
        [Key]
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int RankId { get; set; }
        [Column(TypeName = "datetime")]
        public string HexId { get; set; }
        public bool AccessManagementPanel { get; set; }
        public long DiscordId { get; set; }
        public int JobId { get; set; }
    }
}
