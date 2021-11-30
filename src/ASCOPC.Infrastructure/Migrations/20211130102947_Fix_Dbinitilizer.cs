using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASCOPC.Infrastructure.Migrations
{
    public partial class Fix_Dbinitilizer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SpecificationsComponents",
                keyColumns: new[] { "ComponentId", "SpecificationId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 30, 13, 29, 46, 874, DateTimeKind.Local).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "ComponentsTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 30, 13, 29, 46, 874, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2021, 11, 30, 13, 29, 46, 874, DateTimeKind.Local).AddTicks(4042));

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2021, 11, 30, 13, 29, 46, 874, DateTimeKind.Local).AddTicks(4052));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CreateAt", "SpecificationTitle", "SpecificationValue", "UpdateAt" },
                values: new object[] { 1, new DateTime(2021, 11, 30, 0, 21, 29, 361, DateTimeKind.Local).AddTicks(9284), "Гарантия Страна-производитель Модель Код производителя Год релиза Сокет Система охлаждения в комплекте Термоинтерфейс в комплекте", "12 мес. Китай AMD Ryzen 5 3600 100-0000000312019AM4нетнет", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "SpecificationsComponents",
                columns: new[] { "ComponentId", "SpecificationId" },
                values: new object[] { 1, 1 });
        }
    }
}
