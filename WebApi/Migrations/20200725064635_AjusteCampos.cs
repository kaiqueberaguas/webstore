using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webApi.Migrations
{
    public partial class AjusteCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Prices",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 25, 3, 46, 34, 752, DateTimeKind.Local).AddTicks(73),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 25, 1, 32, 27, 597, DateTimeKind.Local).AddTicks(4759));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Prices",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InitialDate",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 25, 1, 32, 27, 597, DateTimeKind.Local).AddTicks(4759),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 25, 3, 46, 34, 752, DateTimeKind.Local).AddTicks(73));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Prices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }
    }
}
