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
    internal sealed record ImagesEntityConfiguration : IEntityTypeConfiguration<Images>
    {
        public void Configure(EntityTypeBuilder<Images> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.ImageLink)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(p => p.Product).WithMany(x => x.Image).HasForeignKey(c => c.ProductId)
                .IsRequired();
        }
    }
}
