using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApi.Migrations
{
    public partial class fixtimeformat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InitiationDate",
                table: "Projects",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "InitiationDate",
                value: new DateTime(2021, 12, 16, 9, 55, 31, 663, DateTimeKind.Local).AddTicks(8870));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "InitiationDate",
                value: new DateTime(2021, 12, 16, 9, 55, 31, 663, DateTimeKind.Local).AddTicks(8913));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "InitiationDate",
                value: new DateTime(2021, 12, 16, 9, 55, 31, 663, DateTimeKind.Local).AddTicks(8922));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InitiationDate",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "InitiationDate",
                value: "01-01-2021");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "InitiationDate",
                value: "02-01-2021");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "InitiationDate",
                value: "03-01-2021");
        }
    }
}
