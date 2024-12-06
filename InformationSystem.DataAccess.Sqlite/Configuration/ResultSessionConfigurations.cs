using InformationSystem.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InformationSystem.DataAccess.Sqlite.Configuration
{
    public class ResultSessionConfigurations : IEntityTypeConfiguration<ResultSessionEntity>
    {
        public void Configure(EntityTypeBuilder<ResultSessionEntity> builder)
        {
            builder.ToTable("ResultSession");
            builder.HasKey(a =>  a.Id);

            builder.HasOne(a => a.Students)
                .WithMany(a => a.Results)
                .HasForeignKey(a => a.IdStudent);

            builder.HasOne(a => a.Subjects)
                .WithMany(a => a.Results)
                .HasForeignKey(a => a.IdSubject);
        }
    }
}
