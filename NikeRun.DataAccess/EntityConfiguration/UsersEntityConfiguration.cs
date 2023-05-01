using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NikeRun.Domain.Entities;

namespace NikeRun.DataAccess.EntityConfiguration
{
     internal sealed record UsersEntityConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.UserName)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.IsAdmin)
                .HasDefaultValue(false);

            builder.Property(p => p.EmailAddress)
                .IsRequired();

            builder.Property(p => p.ContactNumber)
                .IsRequired();
        }
    }
}
