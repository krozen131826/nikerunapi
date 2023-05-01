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
    internal sealed record ProductDetailsEntityConfiguration : IEntityTypeConfiguration<ProductDetails>
    {
        public void Configure(EntityTypeBuilder<ProductDetails> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Price)
                .IsRequired();

            builder.Property(e => e.Description)
                .IsRequired();

            builder.HasOne(p => p.Product).WithMany(x => x.ProductDetails).HasForeignKey(c => c.ProductId);
                
        }
    }
}
