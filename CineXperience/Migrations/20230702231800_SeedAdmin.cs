using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineXperience.Migrations
{
    public partial class SeedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "684d9c7e-961a-4640-80b2-163105ae6845");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "2168e05f-f4b8-49bd-91c6-d173045fada1");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "271439dc-6882-40c5-a06f-a0ac3da27d0f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "ffa04f30-3776-4330-9ab5-3511fdfb58fd");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "AccessFailedCount", "Apellido", "ConcurrencyStamp", "Discriminator", "Dni", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nombre", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "admin", "2f2d9eae-41cd-4301-b14f-182d370b8638", "Usuario", 0, "admin@ort.edu.ar", false, false, null, "admin", null, "ADMIN@ORT.EDU.AR", "AQAAAAEAACcQAAAAEAy0obnwOsVEmFt+ZRzAdIeAHdHWzlCZ6VVWrjsQ+qouz4Dovx4FN6Uf3jSmfxK3sg==", null, false, "7a95025a-6b45-4fce-bbf2-69142f8cad2d", false, "admin@ort.edu.ar" });

            migrationBuilder.InsertData(
                table: "PersonasRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonasRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "3b3cb961-14c7-4f73-9167-54a38e11f19c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "45013f8d-bf2e-41f0-b73c-c556ee340319");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "e6e827ca-4c12-482c-9133-1337ae7af8e5");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "225ebad8-ed20-43bd-9207-c66c7455d6ca");
        }
    }
}
