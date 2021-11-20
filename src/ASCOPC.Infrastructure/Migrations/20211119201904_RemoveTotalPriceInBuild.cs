using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASCOPC.Infrastructure.Migrations
{
    public partial class RemoveTotalPriceInBuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Builds");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Builds",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 19, 22, 6, 45, 139, DateTimeKind.Local).AddTicks(3927));

            migrationBuilder.UpdateData(
                table: "ComponentsTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 19, 22, 6, 45, 139, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 19, 22, 6, 45, 139, DateTimeKind.Local).AddTicks(3771));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2021, 11, 19, 22, 6, 45, 139, DateTimeKind.Local).AddTicks(3783));

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 19, 22, 6, 45, 139, DateTimeKind.Local).AddTicks(3901));
        }
    }
}
