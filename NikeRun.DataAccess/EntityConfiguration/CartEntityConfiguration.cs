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
    internal sealed record CartEntityConfiguration : IEntityTypeConfiguration<Carts>
    {
        public void Configure(EntityTypeBuilder<Carts> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ProductName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Quantity)
                .IsRequired();

            builder.Property(p => p.Size)
                .IsRequired();

            builder.Property(p => p.Price)
                .IsRequired();

            builder.HasOne(p => p.Users).WithMany().HasForeignKey(p => p.UserId)
                .IsRequired();

            builder.HasOne(p => p.Products).WithMany().HasForeignKey(p => p.ProductId)
                .IsRequired();



        }
    }
}
