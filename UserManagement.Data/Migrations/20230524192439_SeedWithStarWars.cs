using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedWithStarWars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "date_of_birth", "email", "forename", "is_active", "surname" },
                values: new object[,]
                {
                    { 1L, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "luke@jointhealliance.com", "Luke", true, "Skywalker" },
                    { 2L, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "leia@jointhealliance.com", "Leia", true, "Organa" },
                    { 3L, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "han@jointhealliance.com", "Han", false, "Solo" },
                    { 4L, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "vader@thedeathstar.org", "Darth", true, "Vader" },
                    { 5L, new DateTime(896, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "yoda@jointhealliance.com", "Yoda", true, "" },
                    { 6L, new DateTime(57, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "obiwan@jointhealliance.com", "Obi-Wan", true, "Kenobi" },
                    { 7L, new DateTime(41, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "anakin@thedeathstar.org", "Anakin", false, "Skywalker" },
                    { 8L, new DateTime(46, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "padme@jointhealliance.com", "Padmé", false, "Amidala" },
                    { 9L, new DateTime(200, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "chewie@jointhealliance.com", "Chewbacca", false, "" },
                    { 10L, new DateTime(72, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "mace@jointhealliance.com", "Mace", true, "Windu" },
                    { 11L, new DateTime(15, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "rey@jointhealliance.com", "Rey", true, "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 11L);
        }
    }
}
