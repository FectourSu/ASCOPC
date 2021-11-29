using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASCOPC.Infrastructure.Migrations
{
    public partial class FixNameComponents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 29, 13, 33, 21, 615, DateTimeKind.Local).AddTicks(8371));

            migrationBuilder.UpdateData(
                table: "ComponentsTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 29, 13, 33, 21, 615, DateTimeKind.Local).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 29, 13, 33, 21, 615, DateTimeKind.Local).AddTicks(8209));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2021, 11, 29, 13, 33, 21, 615, DateTimeKind.Local).AddTicks(8221));

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 29, 13, 33, 21, 615, DateTimeKind.Local).AddTicks(8339));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 19, 23, 19, 3, 945, DateTimeKind.Local).AddTicks(6196));

            migrationBuilder.UpdateData(
                table: "ComponentsTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 19, 23, 19, 3, 945, DateTimeKind.Local).AddTicks(6182));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 19, 23, 19, 3, 945, DateTimeKind.Local).AddTicks(6026));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2021, 11, 19, 23, 19, 3, 945, DateTimeKind.Local).AddTicks(6037));

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 19, 23, 19, 3, 945, DateTimeKind.Local).AddTicks(6168));
        }
    }
}
