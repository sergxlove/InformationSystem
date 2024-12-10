using InformationSystem.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InformationSystem.DataAccess.Sqlite.Configuration
{
    public class SubjectsConfigurations : IEntityTypeConfiguration<SubjectsEntity>
    {
        public void Configure(EntityTypeBuilder<SubjectsEntity> builder)
        {
            builder.ToTable("Subjects");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(a => a.Teachers)
                .WithMany(a => a.Subjects)
                .HasForeignKey(a => a.IdTeacher);

            builder.HasMany(a => a.Results)
                .WithOne(a => a.Subjects)
                .HasForeignKey(a => a.IdSubject);

            builder.HasMany(a => a.Students)
                .WithMany(a => a.Subjects);
        }
    }
}
