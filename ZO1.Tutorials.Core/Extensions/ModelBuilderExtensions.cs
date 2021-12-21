using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ZO1.Tutorials.Core.Models.Entities;

namespace ZO1.Tutorials.Core.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasData(
                    new List<Item>
                    {
                        new Item{Id = 1, BorrowerName = "Book"},
                        new Item{Id = 2, BorrowerName = "Phone"},
                        new Item{Id = 3,BorrowerName = "Card"}
                    }
                );
        }
    }
}