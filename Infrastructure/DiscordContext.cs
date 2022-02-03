using System;
using Infrastructure.EmsEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Infrastructure
{
    public partial class DiscordContext : DbContext
    {
        public DiscordContext()
        {
        }

        public DiscordContext(DbContextOptions<DiscordContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Examination> Examinations { get; set; }
        public virtual DbSet<Hierarchy> Hierarchies { get; set; }
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<MainMenu> MainMenus { get; set; }
        public virtual DbSet<MenuPermission> MenuPermissions { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }
        public virtual DbSet<Process> Processes { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<RegisterInsurance> RegisterInsurances { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<SubMenu> SubMenus { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=94.73.146.5;Database=u0400950_discord; uid=u0400950_egemen1; pwd=KLR54nHi1YuR14l;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
