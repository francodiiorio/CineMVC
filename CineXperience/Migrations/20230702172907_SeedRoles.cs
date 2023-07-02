using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineXperience.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "3b3cb961-14c7-4f73-9167-54a38e11f19c", "Rol", "Admin", "ADMIN" },
                    { 2, "45013f8d-bf2e-41f0-b73c-c556ee340319", "Rol", "Empleado", "EMPLEADO" },
                    { 3, "e6e827ca-4c12-482c-9133-1337ae7af8e5", "Rol", "Cliente", "CLIENTE" },
                    { 4, "225ebad8-ed20-43bd-9207-c66c7455d6ca", "Rol", "Usuario", "USUARIO" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
