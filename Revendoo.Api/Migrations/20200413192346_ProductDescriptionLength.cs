using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Revendoo.Api.Migrations
{
    public partial class ProductDescriptionLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("362d1041-b049-47f9-ad3d-4e6036b8d38f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b4cae03a-16b5-49b4-a85c-b709f638fdc2"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AmountStock", "Description", "ExpirationDate", "Name", "Price" },
                values: new object[] { new Guid("6331de20-a020-4e4b-828b-5cb24627dab8"), 10, "Batom", null, "Batom", 20.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AmountStock", "Description", "ExpirationDate", "Name", "Price" },
                values: new object[] { new Guid("eb166e50-2234-40de-bcf6-5a17061880be"), 1, "Rímel", new DateTime(2020, 7, 22, 19, 23, 45, 856, DateTimeKind.Utc).AddTicks(9213), "Rímel", 12.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6331de20-a020-4e4b-828b-5cb24627dab8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eb166e50-2234-40de-bcf6-5a17061880be"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AmountStock", "Description", "ExpirationDate", "Name", "Price" },
                values: new object[] { new Guid("362d1041-b049-47f9-ad3d-4e6036b8d38f"), 10, "Batom", null, "Batom", 20.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AmountStock", "Description", "ExpirationDate", "Name", "Price" },
                values: new object[] { new Guid("b4cae03a-16b5-49b4-a85c-b709f638fdc2"), 1, "Rímel", new DateTime(2020, 7, 20, 20, 24, 17, 973, DateTimeKind.Utc).AddTicks(6652), "Rímel", 12.0 });
        }
    }
}
