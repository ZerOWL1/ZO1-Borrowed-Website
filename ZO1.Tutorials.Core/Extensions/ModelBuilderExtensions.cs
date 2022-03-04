using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ZO1.Tutorials.Core.Models.Entities;

namespace ZO1.Tutorials.Core.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Seed Item
            modelBuilder.Entity<Item>()
                .HasData(
                    new List<Item>
                    {
                        new Item{Id = 1, BorrowerName = "Dennis", ItemName = "Book"},
                        new Item{Id = 2, BorrowerName = "Frank", ItemName = "Phone"},
                        new Item{Id = 3,BorrowerName = "John", ItemName = "Card"}
                    }
                );

            //Seed Expense
            modelBuilder.Entity<Expense>()
                .HasData(
                    new List<Expense>
                    {
                        new Expense{Id = 1, ExpenseName = "Tax", Amount = 10},
                        new Expense{Id = 2, ExpenseName = "Bill", Amount = 25},
                        new Expense{Id = 3, ExpenseName = "Payment", Amount = 30},
                    }
                );

            //Seed Expense Type

        }
    }
}