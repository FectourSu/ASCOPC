using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASCOPC.Infrastructure.Migrations
{
    public partial class FixBuilds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Builds_AspNetUsers_UserId",
                table: "Builds");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Builds",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 12, 3, 0, 14, 54, 370, DateTimeKind.Local).AddTicks(5808));

            migrationBuilder.UpdateData(
                table: "ComponentsTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 12, 3, 0, 14, 54, 370, DateTimeKind.Local).AddTicks(5793));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 12, 3, 0, 14, 54, 370, DateTimeKind.Local).AddTicks(5609));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2021, 12, 3, 0, 14, 54, 370, DateTimeKind.Local).AddTicks(5623));

            migrationBuilder.AddForeignKey(
                name: "FK_Builds_AspNetUsers_UserId",
                table: "Builds",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Builds_AspNetUsers_UserId",
                table: "Builds");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Builds",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 12, 3, 0, 10, 44, 646, DateTimeKind.Local).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "ComponentsTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 12, 3, 0, 10, 44, 646, DateTimeKind.Local).AddTicks(5033));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 12, 3, 0, 10, 44, 646, DateTimeKind.Local).AddTicks(4888));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2021, 12, 3, 0, 10, 44, 646, DateTimeKind.Local).AddTicks(4899));

            migrationBuilder.AddForeignKey(
                name: "FK_Builds_AspNetUsers_UserId",
                table: "Builds",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
