using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZO1.Tutorials.Core.Models.Entities;

namespace ZO1.Tutorials.Core.Models.EntityConfigs
{
    public class ExpenseTypeConfig : IEntityTypeConfiguration<ExpenseType>
    {
        public void Configure(EntityTypeBuilder<ExpenseType> builder)
        {
            builder.Property(et => et.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}