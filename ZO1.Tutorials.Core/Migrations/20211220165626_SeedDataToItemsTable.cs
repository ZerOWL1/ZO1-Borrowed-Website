using Microsoft.EntityFrameworkCore.Migrations;

namespace ZO1.Tutorials.Core.Migrations
{
    public partial class SeedDataToItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BorrowerName" },
                values: new object[] { 1, "Book" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BorrowerName" },
                values: new object[] { 2, "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
