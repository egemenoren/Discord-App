using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure.EmsEntities
{
    public partial class SubMenu:EmsBaseEntity
    {
        
        public int MainMenuId { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Icon { get; set; }
        public short DisplayOrder { get; set; } = 1000;
        public bool ToDisplay { get; set; }
    }
}
