using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddBacterias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bacteriums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Escherichia coli");

            migrationBuilder.InsertData(
                table: "Bacteriums",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Klebsiella spp" },
                    { 3, "Enterobacter spp" },
                    { 4, "Bacteroides" },
                    { 5, "Clostridia spp" },
                    { 6, "Fusobacterium spp" },
                    { 7, "enterococci" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bacteriums",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bacteriums",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bacteriums",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bacteriums",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bacteriums",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bacteriums",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Bacteriums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Test");
        }
    }
}
