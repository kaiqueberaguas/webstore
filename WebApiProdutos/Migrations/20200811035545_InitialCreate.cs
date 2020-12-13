using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "AvailableQuantity",
                table: "Products",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValue: 0L);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPromotional",
                table: "Prices",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Prices",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 11, 0, 55, 45, 248, DateTimeKind.Local).AddTicks(8068),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 2, 12, 52, 35, 792, DateTimeKind.Local).AddTicks(8646));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "AvailableQuantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPromotional",
                table: "Prices",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 2, 12, 52, 35, 792, DateTimeKind.Local).AddTicks(8646),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 8, 11, 0, 55, 45, 248, DateTimeKind.Local).AddTicks(8068));
        }
    }
}
