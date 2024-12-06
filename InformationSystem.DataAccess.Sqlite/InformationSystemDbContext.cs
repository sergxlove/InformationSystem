using InformationSystem.DataAccess.Sqlite.Configuration;
using InformationSystem.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace InformationSystem.DataAccess.Sqlite
{
    public class InformationSystemDbContext : DbContext
    {
        public InformationSystemDbContext()
        {
            
        }

        public DbSet<GroupsEntity> Groups { get; set; }

        public DbSet<ResultSessionEntity> ResultSessions { get; set; }

        public DbSet<StudentsEntity> Students { get; set; }

        public DbSet<SubjectsEntity> Subjects { get; set; }

        public DbSet<TeachersEntity> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"D:\projects\InformationSystem\Data\data.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GroupsConfigurations());
            modelBuilder.ApplyConfiguration(new ResultSessionConfigurations());
            modelBuilder.ApplyConfiguration(new StudentsConfigurations());
            modelBuilder.ApplyConfiguration(new SubjectsConfigurations());
            modelBuilder.ApplyConfiguration(new TeachersConfigurations());
            base.OnModelCreating(modelBuilder);
        }
    }
}
