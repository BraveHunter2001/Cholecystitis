using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Bacteria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BacteriumCholecystit");

            migrationBuilder.AddColumn<List<int>>(
                name: "BacteriasIds",
                table: "Cholecystits",
                type: "integer[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BacteriasIds",
                table: "Cholecystits");

            migrationBuilder.CreateTable(
                name: "BacteriumCholecystit",
                columns: table => new
                {
                    BacteriasId = table.Column<int>(type: "integer", nullable: false),
                    CholecystitsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BacteriumCholecystit", x => new { x.BacteriasId, x.CholecystitsId });
                    table.ForeignKey(
                        name: "FK_BacteriumCholecystit_Bacteriums_BacteriasId",
                        column: x => x.BacteriasId,
                        principalTable: "Bacteriums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BacteriumCholecystit_Cholecystits_CholecystitsId",
                        column: x => x.CholecystitsId,
                        principalTable: "Cholecystits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BacteriumCholecystit_CholecystitsId",
                table: "BacteriumCholecystit",
                column: "CholecystitsId");
        }
    }
}
