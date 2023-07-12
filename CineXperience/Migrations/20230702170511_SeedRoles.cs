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
                    { 1, "fd6c26a4-7260-4629-8ab7-f09ec5d61e30", "Rol", "Admin", null },
                    { 2, "86234e37-f0b0-4424-81e7-27cd55e21d87", "Rol", "Cliente", null },
                    { 3, "7638661c-ce59-4e91-bdf6-616f5c093c3e", "Rol", "Empleado", null },
                    { 4, "8316af5f-6c19-4eb3-ad77-7a305558d037", "Rol", "Usuario", null }
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
