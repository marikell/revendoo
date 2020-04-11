using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Revendoo.Api.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AmountStock", "Description", "ExpirationDate", "Name", "Price" },
                values: new object[] { new Guid("362d1041-b049-47f9-ad3d-4e6036b8d38f"), 10, "Batom", null, "Batom", 20.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AmountStock", "Description", "ExpirationDate", "Name", "Price" },
                values: new object[] { new Guid("b4cae03a-16b5-49b4-a85c-b709f638fdc2"), 1, "Rímel", new DateTime(2020, 7, 20, 20, 24, 17, 973, DateTimeKind.Utc).AddTicks(6652), "Rímel", 12.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("362d1041-b049-47f9-ad3d-4e6036b8d38f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b4cae03a-16b5-49b4-a85c-b709f638fdc2"));
        }
    }
}
