using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NikeRun.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.DataAccess.EntityConfiguration
{
    internal sealed record RefreshTokenEntityConfiguration : IEntityTypeConfiguration<RefreshTokens>
    {
        public void Configure(EntityTypeBuilder<RefreshTokens> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.JwtId)
                .IsRequired();

            builder.Property(c => c.RefToken)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.IsUsed)
                .IsRequired();

            builder.Property(c => c.IsRevoked)
                .IsRequired();

            builder.Property(c => c.CreatedDate)
                .IsRequired();

            builder.Property(c => c.ExpiryDate)
                .IsRequired();

            builder.HasOne(c => c.Users).WithMany().HasForeignKey(p => p.UserId)
                .IsRequired();
        }
    }
}
