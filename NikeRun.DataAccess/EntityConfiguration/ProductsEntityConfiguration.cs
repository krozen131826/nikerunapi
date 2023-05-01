using Microsoft.EntityFrameworkCore;
using NikeRun.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.DataAccess.EntityConfiguration
{
    internal sealed record ProductsEntityConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
