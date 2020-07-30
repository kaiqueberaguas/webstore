using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webApi.Migrations
{
    public partial class CorrecaoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginRegister",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "OriginRegister",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OriginRegister",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "OriginRegister",
                table: "Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Prices",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 30, 0, 17, 56, 323, DateTimeKind.Local).AddTicks(1306),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 29, 12, 46, 31, 536, DateTimeKind.Local).AddTicks(7557));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OriginRegister",
                table: "SubCategories",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginRegister",
                table: "Products",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 29, 12, 46, 31, 536, DateTimeKind.Local).AddTicks(7557),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 30, 0, 17, 56, 323, DateTimeKind.Local).AddTicks(1306));

            migrationBuilder.AddColumn<string>(
                name: "OriginRegister",
                table: "Prices",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginRegister",
                table: "Categories",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);
        }
    }
}
