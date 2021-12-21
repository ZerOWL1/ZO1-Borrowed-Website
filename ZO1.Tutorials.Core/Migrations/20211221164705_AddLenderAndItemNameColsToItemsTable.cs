using Microsoft.EntityFrameworkCore.Migrations;

namespace ZO1.Tutorials.Core.Migrations
{
    public partial class AddLenderAndItemNameColsToItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BorrowerName",
                table: "Items",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "Items",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lender",
                table: "Items",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BorrowerName", "ItemName" },
                values: new object[] { "Dennis", "Book" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BorrowerName", "ItemName" },
                values: new object[] { "Frank", "Phone" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BorrowerName", "ItemName" },
                values: new object[] { "John", "Card" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Lender",
                table: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "BorrowerName",
                table: "Items",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "BorrowerName",
                value: "Book");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "BorrowerName",
                value: "Phone");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                column: "BorrowerName",
                value: "Card");
        }
    }
}
