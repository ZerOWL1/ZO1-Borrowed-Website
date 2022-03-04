using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZO1.Tutorials.Core.Models.Entities;

namespace ZO1.Tutorials.Core.Models.EntityConfigs
{
    public class ExpenseConfig : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.Property(e => e.ExpenseName)
                .HasMaxLength(500)
                .IsRequired()
                .HasColumnName("Expense");

            builder.HasOne(e => e.ExpenseType)
                .WithMany(et => et.Expenses)
                .HasForeignKey(e => e.ExpenseTypeId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}