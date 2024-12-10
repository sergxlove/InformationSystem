using InformationSystem.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InformationSystem.DataAccess.Sqlite.Configuration
{
    public class GroupsConfigurations : IEntityTypeConfiguration<GroupsEntity>
    {
        public void Configure(EntityTypeBuilder<GroupsEntity> builder)
        {
            builder.ToTable("Groups");
            builder.HasKey(x => x.Id);
            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();


            builder.HasMany(a => a.Students)
                .WithOne(a => a.Group)
                .HasForeignKey(a => a.IdGroup);
                
        }
    }
}
