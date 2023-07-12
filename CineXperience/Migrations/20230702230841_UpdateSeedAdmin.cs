using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineXperience.Migrations
{
    public partial class UpdateSeedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0ad185b9-baf6-4954-99ab-b623aec1c90d");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "cc89bb1e-c55c-476e-9b83-8edc117653ce");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "04806b6c-28d7-40f7-aac6-4b2b1d64d6cb");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "2e817730-a855-4d90-831e-be31f08ff4b3");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "fb37f5d4-a88b-4bad-9dd5-7e1991e72978", "ADMIN@ORT.EDU.AR", "AQAAAAEAACcQAAAAENteCBxF5MwpAHE68legWDO+iISg74W1JBvvWo8GB4+u4UAKxmorsf7RcPOfvr58wg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "022b033e-a65a-436f-9ee6-de1b3b57d41a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d2df8bf2-88aa-4ff0-b4db-20cea9544b30");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "8be4eea6-b6f3-4cf6-8eda-695e5055152c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "e2dc7e04-0909-4b77-846a-33cc173234f3");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "0704b708-8cc8-4d00-810e-4ccb6bcfca04", null, "AQAAAAEAACcQAAAAELdlbuo2WyXkgBEK5CH5aalflmvnXMVst/YOln5IK8sZevU9k+JSFz7ZW/MJ72imSw==" });
        }
    }
}
