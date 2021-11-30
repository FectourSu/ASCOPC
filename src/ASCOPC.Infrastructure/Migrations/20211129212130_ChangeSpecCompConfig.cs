using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASCOPC.Infrastructure.Migrations
{
    public partial class ChangeSpecCompConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 30, 0, 21, 29, 361, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.UpdateData(
                table: "ComponentsTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 30, 0, 21, 29, 361, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 30, 0, 21, 29, 361, DateTimeKind.Local).AddTicks(9128));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2021, 11, 30, 0, 21, 29, 361, DateTimeKind.Local).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 30, 0, 21, 29, 361, DateTimeKind.Local).AddTicks(9284));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 30, 0, 1, 48, 458, DateTimeKind.Local).AddTicks(2424));

            migrationBuilder.UpdateData(
                table: "ComponentsTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 30, 0, 1, 48, 458, DateTimeKind.Local).AddTicks(2402));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 30, 0, 1, 48, 458, DateTimeKind.Local).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2021, 11, 30, 0, 1, 48, 458, DateTimeKind.Local).AddTicks(2224));

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 30, 0, 1, 48, 458, DateTimeKind.Local).AddTicks(2381));
        }
    }
}
