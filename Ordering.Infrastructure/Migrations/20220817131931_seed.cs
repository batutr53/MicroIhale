using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordering.Infrastructure.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AuctionId", "CreatedAt", "ProductId", "SellerUserName", "TotalPrice", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "7fc039ee-fd6c-4579-9627-744a5cbfe605", new DateTime(2022, 8, 17, 13, 19, 31, 217, DateTimeKind.Utc).AddTicks(3926), "f584dce0-e0db-43dc-bdd8-8bab52a41380", "test@test.com", 1000m, 10m },
                    { 2, "e6df0e19-dec7-4db7-975a-fbfca3e96ba0", new DateTime(2022, 8, 17, 13, 19, 31, 217, DateTimeKind.Utc).AddTicks(3932), "d7bfbfd5-1917-42ff-9456-928dccb22f61", "test1@test.com", 1000m, 10m },
                    { 3, "fd7cccfc-ed02-45a2-9cce-b432fbfe7843", new DateTime(2022, 8, 17, 13, 19, 31, 217, DateTimeKind.Utc).AddTicks(3946), "4a2e584d-cc51-4326-b2a3-41ba81d63a47", "test2@test.com", 1000m, 10m },
                    { 4, "c7148087-3c1c-492e-a712-a5a4afaee9dd", new DateTime(2022, 8, 17, 13, 19, 31, 217, DateTimeKind.Utc).AddTicks(3950), "ccf4bcf2-27a2-4397-8eaa-4521b4a9a69d", "test3@test.com", 1000m, 10m }
                });
        }
    
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
