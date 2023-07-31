using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIIntro.Data.Migrations
{
    public partial class createdproductcategoryrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 0, 25, 10, 75, DateTimeKind.Utc).AddTicks(1940),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 1, 0, 21, 30, 219, DateTimeKind.Utc).AddTicks(6455));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 0, 25, 10, 75, DateTimeKind.Utc).AddTicks(1655),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 1, 0, 21, 30, 219, DateTimeKind.Utc).AddTicks(6178));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 0, 21, 30, 219, DateTimeKind.Utc).AddTicks(6455),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 1, 0, 25, 10, 75, DateTimeKind.Utc).AddTicks(1940));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 0, 21, 30, 219, DateTimeKind.Utc).AddTicks(6178),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 1, 0, 25, 10, 75, DateTimeKind.Utc).AddTicks(1655));
        }
    }
}
