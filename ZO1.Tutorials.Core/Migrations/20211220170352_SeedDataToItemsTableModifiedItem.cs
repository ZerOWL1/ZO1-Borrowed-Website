using Microsoft.EntityFrameworkCore.Migrations;

namespace ZO1.Tutorials.Core.Migrations
{
    public partial class SeedDataToItemsTableModifiedItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 50,
                column: "BorrowerName",
                value: "Card");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 50,
                column: "BorrowerName",
                value: "");
        }
    }
}
