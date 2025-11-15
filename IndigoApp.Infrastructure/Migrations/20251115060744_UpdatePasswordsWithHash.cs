using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndigoApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePasswordsWithHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "jJc+YkhBGwZb0jGZGQ7rYDt0JuAFRYFNKs4vH6KQVZU=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "VyXfHBMVMdH1dJWFh0vXjBqE0bFRXZqvzqLx4gY2F3A=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "adm123");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "user999");
        }
    }
}
