using Microsoft.EntityFrameworkCore.Migrations;

namespace ZO1.Tutorials.Core.Migrations
{
    public partial class SeedNewDataToItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BorrowerName" },
                values: new object[] { 3, "Card" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BorrowerName" },
                values: new object[] { 49, "Book" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BorrowerName" },
                values: new object[] { 50, "Phone" });
        }
    }
}
