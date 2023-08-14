using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Contacts.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "007bf220-d3fe-42bd-83a3-4fb7e45eee41", "63e68b50-38da-49aa-8143-14b3a2e5a3db", "User", "USER" },
                    { "1f7180cb-77f9-44c0-811b-c2f46514dd31", "64dc810f-031c-44ed-b428-9c3e0a06392c", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "007bf220-d3fe-42bd-83a3-4fb7e45eee41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f7180cb-77f9-44c0-811b-c2f46514dd31");
        }
    }
}
