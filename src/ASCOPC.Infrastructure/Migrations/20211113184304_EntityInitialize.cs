using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASCOPC.Infrastructure.Migrations
{
    public partial class EntityInitialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Feture",
                table: "Components");

            migrationBuilder.InsertData(
                table: "ComponentsTypes",
                columns: new[] { "Id", "CreateAt", "Name", "UpdateAt" },
                values: new object[] { 1, new DateTime(2021, 11, 13, 21, 43, 4, 573, DateTimeKind.Local).AddTicks(8014), "Процессор", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreateAt", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 11, 13, 21, 43, 4, 573, DateTimeKind.Local).AddTicks(7815), "AMD", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 11, 13, 21, 43, 4, 573, DateTimeKind.Local).AddTicks(7823), "Intel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "CreateAt", "SpecificationTitle", "SpecificationValue", "UpdateAt" },
                values: new object[] { 1, new DateTime(2021, 11, 13, 21, 43, 4, 573, DateTimeKind.Local).AddTicks(7999), "Гарантия Страна-производитель Модель Код производителя Год релиза Сокет Система охлаждения в комплекте Термоинтерфейс в комплекте", "12 мес. Китай AMD Ryzen 5 3600 100-0000000312019AM4нетнет", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Id", "BuildsId", "Code", "CreateAt", "Desciption", "InStock", "ManufacturerId", "Name", "Price", "Rating", "TypeId", "UpdateAt", "UrlImage" },
                values: new object[] { 1, null, 1372637, new DateTime(2021, 11, 13, 21, 43, 4, 573, DateTimeKind.Local).AddTicks(8028), "6-ядерный процессор AMD Ryzen 5 3600 OEM порадует высоким уровнем производительности подавляющее большинство пользователей. Устройство будет уверенно себя чувствовать в составе мощной игровой системы. Базовая частота процессора равна 3600 МГц. Турбочастота – 4200 МГц. Важной особенностью процессора является очень большой объем кэша третьего уровня: величина этого показателя равна 32 МБ. Объем кэша L2 – 3 МБ.", true, 1, "AM4, 6 x 3600 МГц, L2 - 3 МБ, L3 - 32 МБ, 2хDDR4-3200 МГц, TDP 65 Вт", 17.699m, 4.5m, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://c.dns-shop.ru/thumb/st4/fit/500/500/6e55c08c071d9744dba9a9582eafd812/fc1ee4a47dc4a1740799e996bf0d478f8908764c5f55f176f6b0bc0ca5f5eef2.jpg.webp" });

            migrationBuilder.InsertData(
                table: "SpecificationsComponents",
                columns: new[] { "ComponentId", "SpecificationId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SpecificationsComponents",
                keyColumns: new[] { "ComponentId", "SpecificationId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentsTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "Feture",
                table: "Components",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
