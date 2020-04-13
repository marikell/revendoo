using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Revendoo.Api.Migrations
{
    public partial class RemoveSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6331de20-a020-4e4b-828b-5cb24627dab8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eb166e50-2234-40de-bcf6-5a17061880be"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AmountStock", "Description", "ExpirationDate", "Name", "Price" },
                values: new object[] { new Guid("6331de20-a020-4e4b-828b-5cb24627dab8"), 10, "Batom", null, "Batom", 20.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AmountStock", "Description", "ExpirationDate", "Name", "Price" },
                values: new object[] { new Guid("eb166e50-2234-40de-bcf6-5a17061880be"), 1, "Rímel", new DateTime(2020, 7, 22, 19, 23, 45, 856, DateTimeKind.Utc).AddTicks(9213), "Rímel", 12.0 });
        }
    }
}
