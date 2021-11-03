using Infrastructure.EmsEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DiscordContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("CONNSTR");
        }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Insurance> Insurance { get; set; }
        public DbSet<RegisterInsurance> RegInsurance { get; set; }
    }
}
