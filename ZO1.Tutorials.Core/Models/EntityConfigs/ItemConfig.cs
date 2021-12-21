using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZO1.Tutorials.Core.Models.Entities;

namespace ZO1.Tutorials.Core.Models.EntityConfigs
{
    public class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.BorrowerName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(i => i.ItemName)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(i => i.Lender)
                .HasMaxLength(255);
        }
    }
}