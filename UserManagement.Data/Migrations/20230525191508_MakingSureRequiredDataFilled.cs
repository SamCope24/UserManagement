using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakingSureRequiredDataFilled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5L,
                column: "surname",
                value: "???");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 9L,
                column: "surname",
                value: "???");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 11L,
                column: "surname",
                value: "???");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5L,
                column: "surname",
                value: "");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 9L,
                column: "surname",
                value: "");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 11L,
                column: "surname",
                value: "");
        }
    }
}
