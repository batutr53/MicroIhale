using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroIhale.Infrastructure.Migrations
{
    public partial class isadminadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsAdmin", "IsBuyer", "IsSeller", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8085cced-1f54-4021-a36f-1ddb9ce35034", 0, "ffa68780-0b68-4e3c-b258-691cbf4b1d47", null, false, "User", false, false, true, "User Last", false, null, null, null, null, null, false, "224a28da-4796-43cb-8a53-da019674684e", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8085cced-1f54-4021-a36f-1ddb9ce35034");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AspNetUsers");
        }
    }
}
