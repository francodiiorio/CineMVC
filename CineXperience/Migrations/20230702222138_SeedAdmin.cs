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
                value: "5425fee4-e40e-4b75-a08c-fd84a65dd05c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "60b48afb-c68a-41dc-b25b-6d4ba97dba05");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "c4b4c7ed-1f9c-4532-9c7f-1579070b1b10");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "9407eb76-b39b-4b8f-9601-cccfd1c8d842");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "AccessFailedCount", "Apellido", "ConcurrencyStamp", "Discriminator", "Dni", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nombre", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "admin", "f7c7bf11-9480-48a2-96f8-dc3590f107f1", "Usuario", 0, "admin@ort.edu.ar", false, false, null, "admin", null, null, "AQAAAAEAACcQAAAAEHU6WRdGPCcXClMt/VWjQ1tgUYGt9Afvbzi492+7CakoDxdjvhAF8ET8nKG1fgting==", null, false, null, false, "admin@ort.edu.ar" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
