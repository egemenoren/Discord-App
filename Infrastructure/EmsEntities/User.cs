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
        
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int RankId { get; set; }
        public string HexId { get; set; }
        public bool AccessManagementPanel { get; set; } = false;
        public long DiscordId { get; set; }
        public int JobId { get; set; }
    }
}
