using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infastructure.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(x => x.Login).HasMaxLength(30).IsRequired();

            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();

            builder.Property(x => x.Password).HasMaxLength(256).IsRequired();

            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();

            builder.Property(x => x.DateOfBirth).HasColumnType("DATE");
        }
    }
}
