using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI.Model
{
    public partial class BenchmarkPerformance : DbContext
    {
        public BenchmarkPerformance()
        {
        }

        public BenchmarkPerformance(DbContextOptions<BenchmarkPerformance> options)
            : base(options)
        {
        }

        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Sport> Sport { get; set; }
        public virtual DbSet<Team> Team { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\;Database=BenchmarkORM;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasOne(d => d.Team)
                    .WithMany(p => p.InverseTeam)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_Player_Player");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasOne(d => d.Sport)
                    .WithMany(p => p.InverseSport)
                    .HasForeignKey(d => d.Sportid)
                    .HasConstraintName("FK_Team_Team");
            });
        }
    }
}
