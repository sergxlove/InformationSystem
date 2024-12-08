using InformationSystem.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InformationSystem.DataAccess.Sqlite.Configuration
{
    public class TeachersConfigurations : IEntityTypeConfiguration<TeachersEntity>
    {
        public void Configure(EntityTypeBuilder<TeachersEntity> builder)
        {
            builder.ToTable("Teachers");
            builder.HasKey(x => x.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.HasMany(a => a.Subjects)
                .WithOne(a => a.Teachers)
                .HasForeignKey(a => a.IdTeacher);
        }
    }
}
