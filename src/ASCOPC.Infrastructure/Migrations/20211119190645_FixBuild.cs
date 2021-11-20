using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASCOPC.Infrastructure.Migrations
{
    public partial class FixBuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "Builds");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Builds",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Builds",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "Index",
                table: "Builds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 13, 21, 43, 4, 573, DateTimeKind.Local).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "ComponentsTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 13, 21, 43, 4, 573, DateTimeKind.Local).AddTicks(8014));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 13, 21, 43, 4, 573, DateTimeKind.Local).AddTicks(7815));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2021, 11, 13, 21, 43, 4, 573, DateTimeKind.Local).AddTicks(7823));

            migrationBuilder.UpdateData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 13, 21, 43, 4, 573, DateTimeKind.Local).AddTicks(7999));
        }
    }
}
