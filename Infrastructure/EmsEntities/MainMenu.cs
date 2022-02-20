using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure.EmsEntities
{
    public partial class MainMenu:EmsBaseEntity
    {

        public string MenuName { get; set; }
        public string Icon { get; set; }
        public short DisplayOrder { get; set; }
    }
}
