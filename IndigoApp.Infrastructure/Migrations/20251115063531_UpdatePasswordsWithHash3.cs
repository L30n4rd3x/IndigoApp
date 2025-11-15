using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndigoApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePasswordsWithHash3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "/O9jHqsL4PadlA5zexNuDLz09vHegfUIIoYgAmVa+S4=");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "2x7bz7gP2WX+bYo6qypZc5JVZxoLRdwmPZm5rOgennk=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "fcef631eab0be0f69d940e737b136e0cbcf4f6f1de81f50822862002655af92e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "5e22f9fc01b0ef70f4dc218a5f4e26df8d5328f4cb8294848d3f0d18c8f06d79");
        }
    }
}
