using Microsoft.EntityFrameworkCore.Migrations;

namespace ZO1.Tutorials.Core.Migrations
{
    public partial class SeedDataToItemsTableModifiedItemId2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "BorrowerName",
                value: "Phone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "BorrowerName",
                value: "Card");
        }
    }
}
