﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZO1.Tutorials.Core.Contexts;

namespace ZO1.Tutorials.Core.Migrations
{
    [DbContext(typeof(BorrowedContext))]
    [Migration("20211220165626_SeedDataToItemsTable")]
    partial class SeedDataToItemsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ZO1.Tutorials.Core.Models.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BorrowerName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 49,
                            BorrowerName = "Book"
                        },
                        new
                        {
                            Id = 50,
                            BorrowerName = ""
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
