using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASCOPC.Infrastructure.Migrations
{
    public partial class typoFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecificationsComponents_Specifications_ComponentId",
                table: "SpecificationsComponents");

            migrationBuilder.RenameColumn(
                name: "Desciption",
                table: "Components",
                newName: "Description");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 12, 11, 18, 57, 15, 386, DateTimeKind.Local).AddTicks(8724));

            migrationBuilder.UpdateData(
                table: "ComponentsTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 12, 11, 18, 57, 15, 386, DateTimeKind.Local).AddTicks(8712));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 12, 11, 18, 57, 15, 386, DateTimeKind.Local).AddTicks(8589));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2021, 12, 11, 18, 57, 15, 386, DateTimeKind.Local).AddTicks(8598));

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationsComponents_SpecificationId",
                table: "SpecificationsComponents",
                column: "SpecificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationsComponents_Specifications_SpecificationId",
                table: "SpecificationsComponents",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecificationsComponents_Specifications_SpecificationId",
                table: "SpecificationsComponents");

            migrationBuilder.DropIndex(
                name: "IX_SpecificationsComponents_SpecificationId",
                table: "SpecificationsComponents");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Components",
                newName: "Desciption");

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 12, 4, 19, 2, 47, 385, DateTimeKind.Local).AddTicks(3404));

            migrationBuilder.UpdateData(
                table: "ComponentsTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 12, 4, 19, 2, 47, 385, DateTimeKind.Local).AddTicks(3376));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 12, 4, 19, 2, 47, 385, DateTimeKind.Local).AddTicks(3184));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2021, 12, 4, 19, 2, 47, 385, DateTimeKind.Local).AddTicks(3195));

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationsComponents_Specifications_ComponentId",
                table: "SpecificationsComponents",
                column: "ComponentId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
