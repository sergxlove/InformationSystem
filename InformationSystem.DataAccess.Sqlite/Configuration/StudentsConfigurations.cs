using InformationSystem.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InformationSystem.DataAccess.Sqlite.Configuration
{
    public class StudentsConfigurations : IEntityTypeConfiguration<StudentsEntity>
    {
        public void Configure(EntityTypeBuilder<StudentsEntity> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Group)
                .WithMany(a => a.Students)
                .HasForeignKey(a => a.IdGroup);

            builder.HasMany(a => a.Results)
                .WithOne(a => a.Students)
                .HasForeignKey(a => a.IdStudent);

            builder.HasMany(a => a.Subjects)
                .WithMany(a => a.Students);
        }
    }
}
