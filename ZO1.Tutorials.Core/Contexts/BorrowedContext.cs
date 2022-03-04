using Microsoft.EntityFrameworkCore;
using ZO1.Tutorials.Core.Extensions;
using ZO1.Tutorials.Core.Models.Entities;
using ZO1.Tutorials.Core.Models.EntitiesBase;
using ZO1.Tutorials.Core.Models.EntityConfigs;
using ZO1.Tutorials.Core.Models.Enums;

namespace ZO1.Tutorials.Core.Contexts
{
    public class BorrowedContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }

        public BorrowedContext(DbContextOptions<BorrowedContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Custom Entities Configs
            modelBuilder.ApplyConfiguration(new ItemConfig());
            modelBuilder.ApplyConfiguration(new ExpenseConfig());
            modelBuilder.ApplyConfiguration(new ExpenseTypeConfig());

            //Add Data
            modelBuilder.Seed();
        }

        public void BeforeComplete()
        {
            var entities = ChangeTracker.Entries();

            foreach (var entity in entities)
            {
                if (entity.Entity is IBaseEntities baseEntity)
                {
                    switch (entity.State)
                    {
                        case EntityState.Added:
                            baseEntity.Status = Status.IsActive;
                            break;
                        case EntityState.Modified:
                            break;
                    }
                }
            }
        }
    }
}